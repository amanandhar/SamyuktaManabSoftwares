using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.Shared.Enums;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlUserTransactionRepository : IUserTransactionRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlUserTransactionRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<UserTransaction> GetUserTransactions(UserTransactionFilter userTransactionFilter)
        {
            var userTransactions = new List<UserTransaction>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Action], [ActionType], " +
                "[PartyId], [PartyNumber], [BankName], [IncomeExpense], [Narration], " +
                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.MemberId))
            {
                query += "AND ISNULL([PartyId], '') = @PartyId ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.Action))
            {
                query += "AND [Action] = @Action ";
            }

            query += "ORDER BY [Id] ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)userTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)userTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)userTransactionFilter?.Action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PartyId", ((object)userTransactionFilter?.MemberId) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var userTransaction = new UserTransaction
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    PartyId = reader["PartyId"].ToString(),
                                    PartyNumber = reader["PartyNumber"].ToString(),
                                    BankName = reader["BankName"].ToString(),
                                    IncomeExpense = reader["IncomeExpense"].ToString(),
                                    Narration = reader["Narration"].ToString(),
                                    DueReceivedAmount = Convert.ToDecimal(reader["DueReceivedAmount"].ToString()),
                                    DuePaymentAmount = Convert.ToDecimal(reader["DuePaymentAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString()),
                                    AddedBy = reader["AddedBy"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedBy = reader["UpdatedBy"].ToString(),
                                    UpdatedDate = reader.IsDBNull(16) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                userTransactions.Add(userTransaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return userTransactions;
        }

        public IEnumerable<MemberTransactionView> GetMemberTransactions(MemberTransactionFilter memberTransactionFilter)
        {
            var memberTransactionViews = new List<MemberTransactionView>();
            var query = @"SELECT " +
                "ut.[Id], ut.[EndOfDay], ut.[Action], " +
                "CASE WHEN ut.[ActionType] = '" + Constants.CHEQUE + "' THEN ut.[ActionType] + ' - ' + ut.[BankName] ELSE ut.[ActionType] END AS [ActionType], " +
                "ut.[PartyNumber], ut.[DueReceivedAmount], ut.[ReceivedAmount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "WHERE 1 = 1 " +
                "AND ut.[Action] IN ('" + Constants.SALES + "', '" + Constants.RECEIPT + "') ";

            if (!string.IsNullOrWhiteSpace(memberTransactionFilter?.DateFrom))
            {
                query += "AND ut.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(memberTransactionFilter?.DateTo))
            {
                query += "AND ut.[EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(memberTransactionFilter.MemberId))
            {
                query += "AND ISNULL(ut.[PartyId], '') = @MemberId ";
            }

            if (!string.IsNullOrWhiteSpace(memberTransactionFilter?.Action))
            {
                query += "AND ut.[Action] = @Action ";
            }

            query += "ORDER BY ut.[Id] DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)memberTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)memberTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MemberId", ((object)memberTransactionFilter?.MemberId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)memberTransactionFilter?.Action) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var memberTransactionView = new MemberTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    InvoiceNo = reader["PartyNumber"].ToString(),
                                    DueReceivedAmount = Convert.ToDecimal(reader["DueReceivedAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    Balance = Constants.DEFAULT_DECIMAL_VALUE
                                };

                                memberTransactionViews.Add(memberTransactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return memberTransactionViews;
        }

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierFilter)
        {
            var supplierTransactionViews = new List<SupplierTransactionView>();
            var query = @"SELECT " +
                "ut.[Id], ut.[EndOfDay], ut.[Action], " +
                "CASE WHEN ut.[ActionType] = '" + Constants.CHEQUE + "' THEN ut.[ActionType] + ' - ' + ut.[BankName] ELSE ut.[ActionType] END AS [ActionType], " +
                "ut.[PartyNumber], " +
                "ut.[DuePaymentAmount], ut.[PaymentAmount], " +
                "CASE " +
                "WHEN ut.[Action] = '" + Constants.INCOME + "' THEN " + Constants.DEFAULT_DECIMAL_VALUE + " " +
                "ELSE ( " +
                "SELECT SUM(ISNULL(ut1.[DuePaymentAmount], 0) - ISNULL(ut1.[PaymentAmount], 0)) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut1 " +
                "WHERE 1 = 1 " +
                "AND ut1.[AddedDate] <= ut.[AddedDate] ";
            if (!string.IsNullOrWhiteSpace(supplierFilter.SupplierId))
            {
                query += "AND ISNULL(ut1.[PartyId], '') = @PartyId ";
            }

            query += ") END AS [Balance] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(supplierFilter?.DateFrom))
            {
                query += "AND ut.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(supplierFilter?.DateTo))
            {
                query += "AND ut.[EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(supplierFilter.SupplierId))
            {
                query += "AND ISNULL(ut.[PartyId], '') = @PartyId ";
            }

            if (!string.IsNullOrWhiteSpace(supplierFilter?.Action))
            {
                query += "AND ut.[Action] = @Action ";
            }

            query += "ORDER BY ut.[Id] DESC ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)supplierFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)supplierFilter.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PartyId", ((object)supplierFilter.SupplierId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)supplierFilter.Action) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var supplierTransactionView = new SupplierTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    BillNo = reader["PartyNumber"].ToString(),
                                    DuePaymentAmount = Convert.ToDecimal(reader["DuePaymentAmount"].ToString()),
                                    PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString()),
                                    Balance = Convert.ToDecimal(reader["Balance"].ToString())
                                };

                                supplierTransactionViews.Add(supplierTransactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return supplierTransactionViews;
        }

        public UserTransaction GetLastUserTransaction(PartyNumberType transactionNumberType, string addedBy)
        {
            var userTransaction = new UserTransaction();
            var query = @"SELECT " +
                "TOP 1 " +
                "[Id], [EndOfDay], [Action], [ActionType], " +
                "[PartyId], [PartyNumber], [BankName], [IncomeExpense], [Narration], " +
                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 ";


            if (transactionNumberType == PartyNumberType.Bill)
            {
                query += "AND ([PartyNumber] IS NOT NULL " +
                    "AND DATALENGTH([PartyNumber]) > 0) " +
                    "AND [Action] IN ('" + Constants.PURCHASE + "', '" + Constants.PAYMENT + "') ";
            }
            else if (transactionNumberType == PartyNumberType.Invoice)
            {
                query += "AND ([PartyNumber] IS NOT NULL " +
                    "AND DATALENGTH([PartyNumber]) > 0) " +
                    "AND [Action] IN ('" + Constants.SALES + "', '" + Constants.RECEIPT + "') ";
            }

            if (!string.IsNullOrWhiteSpace(addedBy))
            {
                query += "AND ISNULL([AddedBy], '') = @AddedBy ";
            }

            query += "ORDER BY [Id] DESC ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AddedBy", ((object)addedBy) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                userTransaction.Id = Convert.ToInt64(reader["Id"].ToString());
                                userTransaction.EndOfDay = reader["EndOfDay"].ToString();
                                userTransaction.Action = reader["Action"].ToString();
                                userTransaction.ActionType = reader["ActionType"].ToString();
                                userTransaction.PartyId = reader["PartyId"].ToString();
                                userTransaction.PartyNumber = reader["PartyNumber"].ToString();
                                userTransaction.BankName = reader["BankName"].ToString();
                                userTransaction.IncomeExpense = reader["IncomeExpense"].ToString();
                                userTransaction.Narration = reader["Narration"].ToString();
                                userTransaction.DueReceivedAmount = Convert.ToDecimal(reader["DueReceivedAmount"].ToString());
                                userTransaction.DuePaymentAmount = Convert.ToDecimal(reader["DuePaymentAmount"].ToString());
                                userTransaction.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                userTransaction.PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString());
                                userTransaction.AddedBy = reader["AddedBy"].ToString();
                                userTransaction.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                userTransaction.UpdatedBy = reader["UpdatedBy"].ToString();
                                userTransaction.UpdatedDate = reader.IsDBNull(16) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return userTransaction;
        }

        public string GetLastInvoiceNo()
        {
            string query = @"SELECT " +
                "TOP 1 " +
                "[PartyNumber] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "WHERE 1 = 1 " +
                "AND [PartyNumber] IS NOT NULL " +
                "AND EXISTS ( " +
                "SELECT 1 FROM " + Constants.TABLE_USER_TRANSACTION + " ut1 " +
                "WHERE " +
                "1 = 1 " +
                "AND ut.[Id] = ut1.[Id] " +
                "AND (ut1.[Action] = '" + Constants.SALES + "' OR ut1.[Action] = '" + Constants.RECEIPT + "') " +
                ") " +
                "ORDER BY [Id] DESC ";
            string invoiceNo = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            invoiceNo = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return invoiceNo;
        }

        public IEnumerable<string> GetInvoices()
        {
            var invoices = new List<string>();
            var query = @"SELECT " +
                "DISTINCT [PartyNumber] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [PartyNumber] IS NOT NULL " +
                "AND EXISTS ( " +
                "SELECT 1 FROM " + Constants.TABLE_USER_TRANSACTION + " ut1 " +
                "WHERE " +
                "1 = 1 " +
                "AND ut.[Id] = ut1.[Id] " +
                "AND (ut1.[Action] = '" + Constants.SALES + "' OR ut1.[Action] = '" + Constants.RECEIPT + "') " +
                ") " +
                "ORDER BY [PartyNumber] ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var invoice = reader["PartyNumber"].ToString();

                                invoices.Add(invoice);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return invoices;
        }

        public IEnumerable<DailyTransactionView> GetDailyTransactions(DailyTransactionFilter dailyTransactionFilter)
        {
            var transactionViewList = new List<DailyTransactionView>();
            var query = @"SELECT " +
                "ut.[Id], ut.[EndOfDay], " +
                "ut.[Action], ut.[ActionType], " +
                "ut.[PartyId], ut.[PartyNumber], ut.[BankName], ut.[IncomeExpense], " +
                "CASE " +
                    "WHEN ut.[Action]='" + Constants.PURCHASE + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DuePaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.SALES + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DueReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.SALES + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.SHARE_CAPITAL + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.BANK_TRANSFER + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[PaymentAmount] " +
                    "ELSE " + Constants.DEFAULT_DECIMAL_VALUE + " " +
                "END AS [Amount], " +
                "ut.[AddedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "WHERE 1 = 1 " +
                "AND [Action] != '" + Constants.INCOME + "' ";

            if (dailyTransactionFilter.Date != null)
            {
                query += "AND ut.[EndOfDay] = '" + dailyTransactionFilter.Date + "' ";
            }

            if (dailyTransactionFilter.Purchase != null)
            {
                query += " AND ut.[Action] = '" + Constants.PURCHASE + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Purchase + "' ";
            }
            else if (dailyTransactionFilter.Sales != null)
            {
                query += " AND ut.[Action] = '" + Constants.SALES + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Sales + "' ";
            }
            else if (dailyTransactionFilter.Payment != null)
            {
                query += " AND ut.[Action] = '" + Constants.PAYMENT + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Payment + "' ";
            }
            else if (dailyTransactionFilter.Expense != null)
            {
                query += " AND ut.[Action] = '" + Constants.EXPENSE + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Expense + "' ";
            }
            else if (dailyTransactionFilter.BankTransfer != null)
            {
                query += " AND ut.[Action] = '" + Constants.BANK_TRANSFER + "' AND ut.[ActionType] = '" + dailyTransactionFilter.BankTransfer + "' ";
            }
            else if (dailyTransactionFilter.Receipt != null)
            {
                query += " AND ut.[Action] = '" + Constants.RECEIPT + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Receipt + "' ";
            }
            else if (dailyTransactionFilter.InvoiceNo != null)
            {
                query += " AND ISNULL(ut.[PartyNumber], '') = '" + dailyTransactionFilter.InvoiceNo + "' ";
            }
            else if (dailyTransactionFilter.Username != null)
            {
                query += " AND ut.[AddedBy] = '" + dailyTransactionFilter.Username + "' ";
            }
            else
            {
                query += " ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var transactionView = new DailyTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    PartyId = reader["PartyId"].ToString(),
                                    PartyNumber = reader["PartyNumber"].ToString(),
                                    BankName = reader["BankName"].ToString(),
                                    IncomeExpense = reader["IncomeExpense"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString())
                                };

                                transactionViewList.Add(transactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return transactionViewList;
        }

        public IEnumerable<ShareMemberTransactionView> GetShareMemberTransactions(ShareMemberTransactionFilter shareMemberTransactionFilter)
        {
            var shareMemberTransactionViewList = new List<ShareMemberTransactionView>();
            var query = @"SELECT " +
                "bt.[Id], bt.[EndOfDay], " +
                "sm.[Id] AS [ShareMemberId], sm.[Name], sm.[ContactNo], " +
                "bt.[Narration] AS [Description], " +
                "CASE WHEN bt.[Action] = 1 THEN '" + Constants.DEPOSIT + "' ELSE '" + Constants.WITHDRAWL + "' END AS [Type], " +
                "bt.[Debit], bt.[Credit], (bt.[Debit] - bt.[Credit]) AS [Balance] " +
                "FROM " + Constants.TABLE_SHARE_MEMBER + " sm " +
                "LEFT JOIN " +
                "( " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "INNER JOIN " + Constants.TABLE_BANK_TRANSACTION + " bt " +
                "ON ut.[id] = bt.[UserTransactionId] " +
                ") " +
                "ON sm.[Id] = ut.[ShareMemberId] " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(shareMemberTransactionFilter?.DateFrom))
            {
                query += "AND ut.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(shareMemberTransactionFilter?.DateTo))
            {
                query += "AND ut.[EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(shareMemberTransactionFilter?.ShareMemberId))
            {
                query += "AND ISNULL(ut.[ShareMemberId], '') = @ShareMemberId ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)shareMemberTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)shareMemberTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ShareMemberId", ((object)Convert.ToInt64(shareMemberTransactionFilter?.ShareMemberId)) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var shareMemberTransactionView = new ShareMemberTransactionView
                                {
                                    Id = reader.IsDBNull(0) ? 0 : Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    ShareMemberId = reader["ShareMemberId"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    ContactNo = reader.IsDBNull(4) ? 0 : Convert.ToInt64(reader["ContactNo"].ToString()),
                                    Description = reader["Description"].ToString(),
                                    Type = reader["Type"].ToString(),
                                    Debit = reader.IsDBNull(7) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(8) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Balance = reader.IsDBNull(9) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Balance"].ToString())
                                };

                                shareMemberTransactionViewList.Add(shareMemberTransactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return shareMemberTransactionViewList;
        }

        public IEnumerable<SalesReturnTransactionView> GetSalesReturnTransactions(SalesReturnTransactionFilter salesReturnTransactionFilter)
        {
            var salesReturnTransactionViewList = new List<SalesReturnTransactionView>();
            var query = @"SELECT " +
                "ut.[Id], ut.[EndOfDay], ut.[BillNo] AS [Description], " +
                "i.[Code] AS [ItemCode], i.[Name] AS [ItemName], " +
                "pi.[Quantity] AS [ItemQuantity], pi.[Price] AS [ItemPrice], " +
                "ut.[RecievedAmount] AS [SalesProfit], (CAST((pi.[Quantity] * pi.[Price]) AS DECIMAL(18,2)) + ut.[RecievedAmount]) AS [Amount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "INNER JOIN " + Constants.TABLE_PURCHASED_ITEM + " pi " +
                "ON ut.[BillNo] = pi.[BillNo] " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON pi.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND ut.[Action] = '" + Constants.PURCHASE + "' " +
                "AND ut.[ActionType] = '" + Constants.CASH + "' " +
                "AND ut.[Expense] = '" + Constants.SALES_RETURN + "' ";

            if (!string.IsNullOrWhiteSpace(salesReturnTransactionFilter?.DateFrom))
            {
                query += "AND ut.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(salesReturnTransactionFilter?.DateTo))
            {
                query += "AND ut.[EndOfDay] <= @DateTo ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)salesReturnTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)salesReturnTransactionFilter?.DateTo) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var salesReturnTransactionView = new SalesReturnTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["ItemName"].ToString(),
                                    ItemQuantity = Convert.ToDecimal(reader["ItemQuantity"].ToString()),
                                    ItemPrice = Convert.ToDecimal(reader["ItemPrice"].ToString()),
                                    SalesProfit = Convert.ToDecimal(reader["SalesProfit"].ToString()),
                                    Amount = Convert.ToDecimal(reader["Amount"].ToString())
                                };

                                salesReturnTransactionViewList.Add(salesReturnTransactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return salesReturnTransactionViewList;
        }

        public UserTransaction AddUserTransaction(UserTransaction userTransaction)
        {
            string query = "INSERT INTO " + Constants.TABLE_USER_TRANSACTION + " " +
                    "(" +
                        "[EndOfDay], [Action], [ActionType], " +
                        "[PartyId], [PartyNumber], [BankName], [IncomeExpense], [Narration], " +
                        "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                        "[AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @Action, @ActionType, " +
                        "@PartyId, @PartyNumber, @BankName, @IncomeExpense, @Narration, " +
                        "@DueReceivedAmount, @DuePaymentAmount, @ReceivedAmount, @PaymentAmount, " +
                        "@AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", userTransaction.EndOfDay);
                        command.Parameters.AddWithValue("@Action", userTransaction.Action);
                        command.Parameters.AddWithValue("@ActionType", userTransaction.ActionType);
                        command.Parameters.AddWithValue("@PartyId", ((object)userTransaction.PartyId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PartyNumber", ((object)userTransaction.PartyNumber) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BankName", ((object)userTransaction.BankName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IncomeExpense", ((object)userTransaction.IncomeExpense) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Narration", ((object)userTransaction.Narration) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DueReceivedAmount", ((object)userTransaction.DueReceivedAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                        command.Parameters.AddWithValue("@DuePaymentAmount", ((object)userTransaction.DuePaymentAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                        command.Parameters.AddWithValue("@ReceivedAmount", ((object)userTransaction.ReceivedAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                        command.Parameters.AddWithValue("@PaymentAmount", ((object)userTransaction.PaymentAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                        command.Parameters.AddWithValue("@AddedBy", userTransaction.AddedBy);
                        command.Parameters.AddWithValue("@AddedDate", userTransaction.AddedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return userTransaction;
        }

        public bool DeleteUserTransaction(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return result;
        }

        public bool DeleteUserTransaction(string invoiceNo)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [PartyNumber] = @PartyNumber ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PartyNumber", ((object)invoiceNo) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return result;
        }
    }
}
