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
                "[PartyId], [PartyNumber], [BankName], [Narration], " +
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

            query += "ORDER BY [AddedDate] DESC ";

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
                                    Narration = reader["Narration"].ToString(),
                                    DueReceivedAmount = Convert.ToDecimal(reader["DueReceivedAmount"].ToString()),
                                    DuePaymentAmount = Convert.ToDecimal(reader["DuePaymentAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString()),
                                    AddedBy = reader["AddedBy"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedBy = reader["UpdatedBy"].ToString(),
                                    UpdatedDate = reader.IsDBNull(15) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
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

            query += "ORDER BY ut.[AddedDate] DESC";

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

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierTransactionFilter)
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
            
            if (!string.IsNullOrWhiteSpace(supplierTransactionFilter?.SupplierId))
            {
                query += "AND ISNULL(ut1.[PartyId], '') = @PartyId ";
            }

            query += ") END AS [Balance] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(supplierTransactionFilter?.DateFrom))
            {
                query += "AND ut.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(supplierTransactionFilter?.DateTo))
            {
                query += "AND ut.[EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(supplierTransactionFilter.SupplierId))
            {
                query += "AND ISNULL(ut.[PartyId], '') = @PartyId ";
            }

            query += "ORDER BY ut.[AddedDate] ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)supplierTransactionFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)supplierTransactionFilter.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PartyId", ((object)supplierTransactionFilter.SupplierId) ?? DBNull.Value);

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
                "[PartyId], [PartyNumber], [BankName], [Narration], " +
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
                                userTransaction.Narration = reader["Narration"].ToString();
                                userTransaction.DueReceivedAmount = Convert.ToDecimal(reader["DueReceivedAmount"].ToString());
                                userTransaction.DuePaymentAmount = Convert.ToDecimal(reader["DuePaymentAmount"].ToString());
                                userTransaction.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                userTransaction.PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString());
                                userTransaction.AddedBy = reader["AddedBy"].ToString();
                                userTransaction.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                userTransaction.UpdatedBy = reader["UpdatedBy"].ToString();
                                userTransaction.UpdatedDate = reader.IsDBNull(15) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
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

        public IEnumerable<DailyTransactionView> GetDailyTransactions(DailyTransactionFilter dailyTransactionFilter)
        {
            var includeBankTransaction = false;
            var transactionViewList = new List<DailyTransactionView>();
            var query = @"SELECT " +
                "ut.[Id], ut.[EndOfDay], " +
                "ut.[Action], ut.[ActionType], " +
                "ut.[PartyId], ut.[PartyNumber], ut.[BankName], " +
                "CASE " +
                    "WHEN ut.[Action]='" + Constants.PURCHASE + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DuePaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.SALES + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DueReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.SALES + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.SHARE_CAPITAL + "' THEN ut.[ReceivedAmount] " +
                    "ELSE " + Constants.DEFAULT_DECIMAL_VALUE + " " +
                "END AS [Amount], " +
                "ut.[AddedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "WHERE 1 = 1 ";

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
            else if (dailyTransactionFilter.Receipt != null)
            {
                query += " AND ut.[Action] = '" + Constants.RECEIPT + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Receipt + "' ";
            }
            else if (dailyTransactionFilter.PartyNumber != null)
            {
                query += " AND ISNULL(ut.[PartyNumber], '') = '" + dailyTransactionFilter.PartyNumber + "' ";
            }
            else if (dailyTransactionFilter.Username != null)
            {
                query += " AND ut.[AddedBy] = '" + dailyTransactionFilter.Username + "' ";
                includeBankTransaction = true;
            }
            else
            {
                query += " ";
            }

            if (includeBankTransaction
                || dailyTransactionFilter.Payment == Constants.CASH
                || dailyTransactionFilter.IsAll)
            {
                query += "UNION " +
                "SELECT bt.[Id], bt.[EndOfDay], bt.[Action], " +
                "bt.[Narration] AS [ActionType], " +
                "'' AS [PartyId], '' AS [PartyNumber], " +
                "b.[Name] AS [BankName], bt.[Debit] AS [Amount], bt.[AddedDate] " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " bt " +
                "INNER JOIN " + Constants.TABLE_BANK + " b " +
                "ON bt.[BankId] = b.[Id] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(bt.[Action], '') = '" + Constants.BANK_TRANSFER + "' ";

                if (dailyTransactionFilter.Date != null)
                {
                    query += "AND bt.[EndOfDay] = '" + dailyTransactionFilter.Date + "' ";
                }
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

            query += "ORDER BY ut.[AddedDate] DESC ";

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

        public decimal GetTotalMemberSaleAmount(string shareMemberId)
        {
            decimal totalAmount = Constants.DEFAULT_DECIMAL_VALUE;
            var query = @"SELECT " +
                "SUM(ut.[DueReceivedAmount] + ut.[ReceivedAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "INNER JOIN " +
                " " + Constants.TABLE_MEMBER + " m " +
                "ON " +
                "ut.[PartyId] = m.[MemberId] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(ut.[Action], '') = '" + Constants.SALES + "' " +
                "AND ISNULL(m.[ShareMemberId], '') = @ShareMemberId ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ShareMemberId", ((object)shareMemberId) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            totalAmount = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return totalAmount;
        }

        public UserTransaction AddUserTransaction(UserTransaction userTransaction)
        {
            string query = "INSERT INTO " + Constants.TABLE_USER_TRANSACTION + " " +
                    "(" +
                        "[EndOfDay], [Action], [ActionType], " +
                        "[PartyId], [PartyNumber], [BankName], [Narration], " +
                        "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                        "[AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @Action, @ActionType, " +
                        "@PartyId, @PartyNumber, @BankName, @Narration, " +
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

        #region Daily Transaction Methods
        public bool DeleteBill(long id, string billNo)
        {
            var result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Delete row from bank transaction table
                        string deleteBankTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [TransactionId] = @TransactionId ";
                        using (SqlCommand command = new SqlCommand(deleteBankTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@TransactionId", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from user transaction table
                        var deleteUserTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [Id] = @Id ";
                        using (SqlCommand command = new SqlCommand(deleteUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from purchased item table
                        string deletePurchasedItem = @"DELETE " +
                            "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                            "WHERE 1 = 1 " +
                            "AND [BillNo] = @BillNo ";
                        using (SqlCommand command = new SqlCommand(deletePurchasedItem, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@BillNo", ((object)billNo) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                        result = true;
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
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

        public bool DeleteInvoice(string invoiceNo)
        {
            var result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Delete row from pos detail table
                        string deletePosDetail = @"DELETE " +
                            "FROM " + Constants.TABLE_POS_DETAIL + " " +
                            "WHERE 1 = 1 " +
                            "AND ISNULL([InvoiceNo], '') = @InvoiceNo";
                        using (SqlCommand command = new SqlCommand(deletePosDetail, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@InvoiceNo", ((object)invoiceNo) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from user transaction table
                        string deleteUserTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [PartyNumber] = @PartyNumber ";
                        using (SqlCommand command = new SqlCommand(deleteUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@PartyNumber", ((object)invoiceNo) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from sold item table
                        string deleteSoldItem = @"DELETE " +
                            "FROM " + Constants.TABLE_SOLD_ITEM + " " +
                            "WHERE 1 = 1 " +
                            "AND InvoiceNo = @InvoiceNo ";
                        using (SqlCommand command = new SqlCommand(deleteSoldItem, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@InvoiceNo", ((object)invoiceNo) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                        result = true;
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
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

        #endregion

        #region POS Methods
        public bool SaveSalesDetail(List<SoldItem> soldItems, UserTransaction userTransaction, POSDetail posDetail, string username)
        {
            var result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Add rows into the sold item table
                        string insertSoldItem = @"INSERT INTO " + Constants.TABLE_SOLD_ITEM + " " +
                            "( " +
                                "[EndOfDay], [MemberId], [InvoiceNo], [ItemId], [Profit], [Unit], [Quantity], [Price], [Discount], [AddedBy], [AddedDate]  " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @MemberId, @InvoiceNo, @ItemId, @Profit, @Unit, @Quantity, @Price, @Discount, @AddedBy, @AddedDate " +
                            ") ";

                        foreach (var soldItem in soldItems)
                        {
                            using (SqlCommand command = new SqlCommand(insertSoldItem, connection, sqlTransaction))
                            {
                                command.Parameters.AddWithValue("@EndOfDay", soldItem.EndOfDay);
                                command.Parameters.AddWithValue("@MemberId", soldItem.MemberId);
                                command.Parameters.AddWithValue("@InvoiceNo", soldItem.InvoiceNo);
                                command.Parameters.AddWithValue("@ItemId", soldItem.ItemId);
                                command.Parameters.AddWithValue("@Profit", soldItem.Profit);
                                command.Parameters.AddWithValue("@Unit", soldItem.Unit);
                                command.Parameters.AddWithValue("@Quantity", soldItem.Quantity);
                                command.Parameters.AddWithValue("@Price", soldItem.Price);
                                command.Parameters.AddWithValue("@Discount", soldItem.Discount);
                                command.Parameters.AddWithValue("@AddedBy", soldItem.AddedBy);
                                command.Parameters.AddWithValue("@AddedDate", soldItem.AddedDate);

                                command.ExecuteNonQuery();
                            }
                        }

                        // Add row into the user transaction table
                        string insertUserTransaction = "INSERT INTO " + Constants.TABLE_USER_TRANSACTION + " " +
                            "(" +
                                "[EndOfDay], [Action], [ActionType], " +
                                "[PartyId], [PartyNumber], [BankName], [Narration], " +
                                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                                "[AddedBy], [AddedDate] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @Action, @ActionType, " +
                                "@PartyId, @PartyNumber, @BankName, @Narration, " +
                                "@DueReceivedAmount, @DuePaymentAmount, @ReceivedAmount, @PaymentAmount, " +
                                "@AddedBy, @AddedDate " +
                            ") ";

                        using (SqlCommand command = new SqlCommand(insertUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@EndOfDay", userTransaction.EndOfDay);
                            command.Parameters.AddWithValue("@Action", userTransaction.Action);
                            command.Parameters.AddWithValue("@ActionType", userTransaction.ActionType);
                            command.Parameters.AddWithValue("@PartyId", ((object)userTransaction.PartyId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@PartyNumber", ((object)userTransaction.PartyNumber) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@BankName", ((object)userTransaction.BankName) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Narration", ((object)userTransaction.Narration) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DueReceivedAmount", ((object)userTransaction.DueReceivedAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@DuePaymentAmount", ((object)userTransaction.DuePaymentAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@ReceivedAmount", ((object)userTransaction.ReceivedAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@PaymentAmount", ((object)userTransaction.PaymentAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@AddedBy", userTransaction.AddedBy);
                            command.Parameters.AddWithValue("@AddedDate", userTransaction.AddedDate);

                            command.ExecuteNonQuery();
                        }

                        // Get the last id from the user transaction table
                        long lastUserTransactionId = 0;
                        string selectLastTransaction = @"SELECT " +
                            "TOP 1 " +
                            "[Id] " +
                            "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND ([PartyNumber] IS NOT NULL " +
                            "AND DATALENGTH([PartyNumber]) > 0) " +
                            "AND [Action] IN ('" + Constants.SALES + "', '" + Constants.RECEIPT + "') " +
                            "ORDER BY[Id] DESC ";

                        using (SqlCommand command = new SqlCommand(selectLastTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@AddedBy", ((object)username) ?? DBNull.Value);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    lastUserTransactionId = Convert.ToInt64(reader["Id"].ToString());
                                }
                            }
                        }

                        // Add row into the pos detail table
                        posDetail.UserTransactionId = lastUserTransactionId;
                        string insertPOSDetail = @"INSERT INTO " +
                            " " + Constants.TABLE_POS_DETAIL + " " +
                            "( " +
                                "[EndOfDay], [UserTransactionId], [InvoiceNo], [SubTotal], " +
                                "[DiscountPercent], [Discount], [VatPercent], [Vat], " +
                                "[DeliveryChargePercent], [DeliveryCharge], [DeliveryPersonId] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @UserTransactionId, @InvoiceNo, @SubTotal, " +
                                "@DiscountPercent, @Discount, @VatPercent, @Vat, " +
                                "@DeliveryChargePercent, @DeliveryCharge, @DeliveryPersonId " +
                            ") ";

                        using (SqlCommand command = new SqlCommand(insertPOSDetail, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@EndOfDay", ((object)posDetail.EndOfDay) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@UserTransactionId", ((object)posDetail.UserTransactionId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@InvoiceNo", ((object)posDetail.InvoiceNo) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@SubTotal", ((object)posDetail.SubTotal) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DiscountPercent", ((object)posDetail.DiscountPercent) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Discount", ((object)posDetail.Discount) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@VatPercent", ((object)posDetail.VatPercent) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Vat", ((object)posDetail.Vat) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DeliveryChargePercent", ((object)posDetail.DeliveryChargePercent) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DeliveryCharge", ((object)posDetail.DeliveryCharge) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DeliveryPersonId", ((object)posDetail.DeliveryPersonId) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                        result = true;
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
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

        #endregion
    }
}
