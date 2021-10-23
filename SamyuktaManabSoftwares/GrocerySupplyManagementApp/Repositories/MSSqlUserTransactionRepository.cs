using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
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
                "[Id], [EndOfDay], " +
                "[InvoiceNo], [BillNo], [MemberId], [ShareMemberId], [SupplierId], [DeliveryPersonId], " +
                "[Action], [ActionType], [Bank], [Income], [Expense], [Narration], " +
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
                query += "AND ISNULL([MemberId], '') = @MemberId ";
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
                        command.Parameters.AddWithValue("@MemberId", ((object)userTransactionFilter?.MemberId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)userTransactionFilter?.Action) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var userTransaction = new UserTransaction
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    BillNo = reader["BillNo"].ToString(),
                                    MemberId = reader["MemberId"].ToString(),
                                    ShareMemberId = Convert.ToInt64(reader["ShareMemberId"].ToString()),
                                    SupplierId = reader["SupplierId"].ToString(),
                                    DeliveryPersonId = reader["DeliveryPersonId"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    Bank = reader["Bank"].ToString(),
                                    Income = reader["Income"].ToString(),
                                    Expense = reader["Expense"].ToString(),
                                    Narration = reader["Narration"].ToString(),
                                    DueReceivedAmount = Convert.ToDecimal(reader["DueReceivedAmount"].ToString()),
                                    DuePaymentAmount = Convert.ToDecimal(reader["DuePaymentAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString()),
                                    AddedBy = reader["AddedBy"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedBy = reader["UpdatedBy"].ToString(),
                                    UpdatedDate = reader.IsDBNull(21) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
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
                UtilityService.ShowExceptionMessageBox();
            }

            return userTransactions;

        }

        public IEnumerable<UserTransaction> GetDeliveryPersonTransactions(DeliveryPersonTransactionFilter deliveryPersonTransactionFilter)
        {
            var userTransactions = new List<UserTransaction>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], " +
                "[InvoiceNo], [BillNo], [MemberId], [ShareMemberId], [SupplierId], [DeliveryPersonId], " +
                "[Action], [ActionType], [Bank], [Income], [Expense], [Narration], " +
                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Income], '') = '" + Constants.DELIVERY_CHARGE + "' ";

            if (!string.IsNullOrWhiteSpace(deliveryPersonTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(deliveryPersonTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(deliveryPersonTransactionFilter?.EmployeeId))
            {
                query += "AND ISNULL([DeliveryPersonId], '') = @DeliveryPersonId ";
            }

            query += "ORDER BY [Id] ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)deliveryPersonTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)deliveryPersonTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryPersonId", ((object)deliveryPersonTransactionFilter?.EmployeeId) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var userTransaction = new UserTransaction
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    BillNo = reader["BillNo"].ToString(),
                                    MemberId = reader["MemberId"].ToString(),
                                    ShareMemberId = Convert.ToInt64(reader["ShareMemberId"].ToString()),
                                    SupplierId = reader["SupplierId"].ToString(),
                                    DeliveryPersonId = reader["DeliveryPersonId"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    Bank = reader["Bank"].ToString(),
                                    Income = reader["Income"].ToString(),
                                    Expense = reader["Expense"].ToString(),
                                    Narration = reader["Narration"].ToString(),
                                    DueReceivedAmount = Convert.ToDecimal(reader["DueReceivedAmount"].ToString()),
                                    DuePaymentAmount = Convert.ToDecimal(reader["DuePaymentAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString()),
                                    AddedBy = reader["AddedBy"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedBy = reader["UpdatedBy"].ToString(),
                                    UpdatedDate = reader.IsDBNull(21) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
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
                UtilityService.ShowExceptionMessageBox();
            }

            return userTransactions;
        }

        public IEnumerable<MemberTransactionView> GetMemberTransactions(MemberTransactionFilter memberTransactionFilter)
        {
            var memberTransactionViews = new List<MemberTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Action], " +
                "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[InvoiceNo], [DueReceivedAmount], [ReceivedAmount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [MemberId] IS NOT NULL " +
                "AND ISNULL([Income], '') != '" + Constants.DELIVERY_CHARGE + "' " +
                "AND ISNULL([Expense], '') != '" + Constants.SALES_DISCOUNT + "' ";
            
            if(!string.IsNullOrWhiteSpace(memberTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(memberTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if(!string.IsNullOrWhiteSpace(memberTransactionFilter.MemberId))
            {
                query += "AND ISNULL([MemberId], '') = @MemberId ";
            }

            if (!string.IsNullOrWhiteSpace(memberTransactionFilter?.Action))
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
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
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
                UtilityService.ShowExceptionMessageBox();
            }

            return memberTransactionViews;
        }

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierFilter)
        {
            var supplierTransactionViews = new List<SupplierTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Action], " +
                "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[BillNo], " +
                "CASE WHEN [Action] = '" + Constants.INCOME + "' THEN [ReceivedAmount] ELSE [DuePaymentAmount] END AS [DuePaymentAmount], " +
                "CASE WHEN [Action] = '" + Constants.INCOME + "' THEN [ReceivedAmount] ELSE [PaymentAmount] END AS [PaymentAmount], " +
                "CASE " +
                "WHEN [Action] = '" +Constants.INCOME + "' THEN " + Constants.DEFAULT_DECIMAL_VALUE + " " +
                "ELSE (SELECT SUM(ISNULL(b.[DuePaymentAmount], 0) - ISNULL(b.[PaymentAmount], 0)) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " b " +
                "WHERE 1 = 1 " +
                "AND b.[AddedDate] <= a.[AddedDate] ";
            if (!string.IsNullOrWhiteSpace(supplierFilter.SupplierId))
            {
                query += "AND ISNULL([SupplierId], '') = @SupplierId ";
            }

            query += ") END AS [Balance] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " a " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(supplierFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(supplierFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(supplierFilter.SupplierId))
            {
                query += "AND ISNULL([SupplierId], '') = @SupplierId ";
            }

            if (!string.IsNullOrWhiteSpace(supplierFilter?.Action))
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
                        command.Parameters.AddWithValue("@DateFrom", ((object)supplierFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)supplierFilter.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SupplierId", ((object)supplierFilter.SupplierId) ?? DBNull.Value);
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
                                    BillNo = reader["BillNo"].ToString(),
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
                UtilityService.ShowExceptionMessageBox();
            }

            return supplierTransactionViews;
        }
        
        public UserTransaction GetLastUserTransaction(string addedBy, string option)
        {
            var userTransaction = new UserTransaction();
            var query = @"SELECT " +
                "TOP 1 " +
                "[Id], [EndOfDay], " +
                "[InvoiceNo], [BillNo], [MemberId], [ShareMemberId], [SupplierId], [DeliveryPersonId], " +
                "[Action], [ActionType], [Bank], [Income], [Expense], [Narration], " +
                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(option))
            {
                if(option.StartsWith(Constants.INVOICE_NO_PREFIX))
                {
                    query += "AND ([InvoiceNo] IS NOT NULL " +
                        "AND DATALENGTH([InvoiceNo]) > 0) ";
                }
                else if(option.StartsWith(Constants.BILL_NO_PREFIX))
                {
                    query += "AND ([BillNo] IS NOT NULL " +
                        "AND DATALENGTH([BillNo]) > 0) ";
                }
            }

            if(!string.IsNullOrWhiteSpace(addedBy))
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
                                userTransaction.InvoiceNo = reader["InvoiceNo"].ToString();
                                userTransaction.BillNo = reader["BillNo"].ToString();
                                userTransaction.MemberId = reader["MemberId"].ToString();
                                userTransaction.ShareMemberId = Convert.ToInt64(reader["ShareMemberId"].ToString());
                                userTransaction.SupplierId = reader["SupplierId"].ToString();
                                userTransaction.DeliveryPersonId = reader["DeliveryPersonId"].ToString();
                                userTransaction.Action = reader["Action"].ToString();
                                userTransaction.ActionType = reader["ActionType"].ToString();
                                userTransaction.Bank = reader["Bank"].ToString();
                                userTransaction.Income = reader["Income"].ToString();
                                userTransaction.Expense = reader["Expense"].ToString();
                                userTransaction.Narration = reader["Narration"].ToString();
                                userTransaction.DueReceivedAmount = Convert.ToDecimal(reader["DueReceivedAmount"].ToString());
                                userTransaction.DuePaymentAmount = Convert.ToDecimal(reader["DuePaymentAmount"].ToString());
                                userTransaction.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                userTransaction.PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString());
                                userTransaction.AddedBy = reader["AddedBy"].ToString();
                                userTransaction.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                userTransaction.UpdatedBy = reader["UpdatedBy"].ToString();
                                userTransaction.UpdatedDate = reader.IsDBNull(21) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return userTransaction;
        }

        public string GetLastInvoiceNo()
        {
            string query = @"SELECT " +
                "TOP 1 " +
                "[InvoiceNo] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [InvoiceNo] IS NOT NULL " +
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
                UtilityService.ShowExceptionMessageBox();
            }

            return invoiceNo;
        }

        public IEnumerable<string> GetInvoices()
        {
            var invoices = new List<string>();
            var query = @"SELECT " +
                "DISTINCT [InvoiceNo] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [InvoiceNo] IS NOT NULL " +
                "ORDER BY [InvoiceNo] ";
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
                                var invoice = reader["InvoiceNo"].ToString();

                                invoices.Add(invoice);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return invoices;
        }

        public IEnumerable<DailyTransactionView> GetDailyTransactions(DailyTransactionFilter dailyTransactionFilter)
        {
            var includeBankTransaction = false;
            var transactionViewList = new List<DailyTransactionView>();
            var query = @"SELECT " +
                "ut.[Id], ut.[EndOfDay], " +
                "CASE " +
                    "WHEN ut.[MemberId] IS NULL THEN ut.[SupplierId] ELSE ut.[MemberId] " +
                "END AS [MemberSupplierId], " +
                "ut.[Action], " +
                "ut.[ActionType], " +
                "ISNULL(ut.[Bank], '') AS [Bank], " +
                "CASE " +
                    "WHEN ut.[MemberId] IS NULL THEN ut.[BillNo] " +
                    "ELSE ut.[InvoiceNo] " +
                "END AS [InvoiceBillNo], " +
                "ut.[Income], " +
                "ut.[Expense], " +
                "CASE " +
                    "WHEN ut.[Action]='" + Constants.PURCHASE + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DuePaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.PURCHASE + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.SALES + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DueReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.SALES + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DueReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.SHARE_CAPITAL + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DuePaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DuePaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.BANK_TRANSFER + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.BANK_TRANSFER + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[PaymentAmount] " +
                    "ELSE ut.[DueReceivedAmount] " +
                "END  AS [Amount]," +
                "ut.[AddedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "WHERE 1 = 1 " +
                "AND ISNULL(ut.[Income], '') NOT IN " +
                "(" +
                "'" + Constants.DELIVERY_CHARGE + "', '" + Constants.MEMBER_FEE + "', " +
                "'" + Constants.OTHER_INCOME + "', '" + Constants.SALES_PROFIT + "' " +
                ") " +
                "AND ISNULL(ut.[Expense], '') NOT IN " +
                "( " +
                "'" + Constants.SALES_DISCOUNT + "' " +
                ") ";

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
                query += " AND ut.[Action] = '" + Constants.EXPENSE + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Expense + "' AND ISNULL(ut.[Expense], '') NOT IN ('" + Constants.SALES_DISCOUNT + "') ";
            }
            else if (dailyTransactionFilter.BankTransfer != null)
            {
                query += " AND ut.[Action] = '" + Constants.BANK_TRANSFER + "' AND ut.[ActionType] = '" + dailyTransactionFilter.BankTransfer + "' ";
            }
            else if (dailyTransactionFilter.Receipt != null)
            {
                query += " AND ut.[Action] = '" + Constants.RECEIPT + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Receipt + "'  AND ISNULL(ut.[Income], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "') ";
            }
            else if (dailyTransactionFilter.InvoiceNo != null)
            {
                query += " AND ISNULL(ut.[InvoiceNo], '') = '" + dailyTransactionFilter.InvoiceNo + "' ";
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

            // Including Owner Equity from Bank Transaction table
            if (includeBankTransaction 
                || dailyTransactionFilter.Receipt == Constants.OWNER_EQUITY 
                || dailyTransactionFilter.IsAll)
            {
                query += "UNION " +
                "SELECT bt.[Id], bt.[EndOfDay], '' AS [MemberSupplierId], " +
                "CASE " +
                "WHEN bt.[Action] = 1 THEN '" + Constants.DEPOSIT + "' " +
                "ELSE '" + Constants.WITHDRAWL + "' " +
                "END AS [Action], bt.[Narration] AS [ActionType], " +
                "b.[Name] AS [Bank], '' AS [InvoiceBillNo], '' AS [Income], '' AS [Expense], bt.[Debit] AS [Amount], bt.[AddedDate] " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " bt " +
                "INNER JOIN " + Constants.TABLE_BANK + " b " +
                "ON bt.[BankId] = b.[Id] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(bt.[Narration], '') = '" + Constants.OWNER_EQUITY + "' ";

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
                                    MemberSupplierId = reader.IsDBNull(2) ? string.Empty : reader["MemberSupplierId"].ToString(),
                                    Action = reader.IsDBNull(3) ? string.Empty : reader["Action"].ToString(),
                                    ActionType = reader.IsDBNull(4) ? string.Empty : reader["ActionType"].ToString(),
                                    Bank = reader.IsDBNull(5) ? string.Empty : reader["Bank"].ToString(),
                                    InvoiceBillNo = reader.IsDBNull(6) ? string.Empty : reader["InvoiceBillNo"].ToString(),
                                    Income = reader.IsDBNull(7) ? string.Empty : reader["Income"].ToString(),
                                    Expense = reader.IsDBNull(8) ? string.Empty : reader["Expense"].ToString(),
                                    Amount = reader.IsDBNull(9) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Amount"].ToString()),
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
                UtilityService.ShowExceptionMessageBox();
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
                "ON ut.[id] = bt.[TransactionId] " +
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
                UtilityService.ShowExceptionMessageBox();
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

            if(!string.IsNullOrWhiteSpace(salesReturnTransactionFilter?.DateTo))
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
                UtilityService.ShowExceptionMessageBox();
            }

            return salesReturnTransactionViewList;
        }

        public UserTransaction AddUserTransaction(UserTransaction userTransaction)
        {
            string query = "INSERT INTO " + Constants.TABLE_USER_TRANSACTION + " " +
                    "(" +
                        "[EndOfDay], " +
                        "[InvoiceNo], [BillNo], [MemberId], [ShareMemberId], [SupplierId], [DeliveryPersonId], " +
                        "[Action], [ActionType], [Bank], [Income], [Expense], [Narration], " +
                        "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                        "[AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, " +
                        "@InvoiceNo, @BillNo, @MemberId, @ShareMemberId, @SupplierId, @DeliveryPersonId, " +
                        "@Action, @ActionType, @Bank, @Income, @Expense, @Narration, " +
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
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)userTransaction.InvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BillNo", ((object)userTransaction.BillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MemberId", ((object)userTransaction.MemberId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ShareMemberId", ((object)userTransaction.ShareMemberId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SupplierId", ((object)userTransaction.SupplierId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryPersonId", ((object)userTransaction.DeliveryPersonId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", userTransaction.Action);
                        command.Parameters.AddWithValue("@ActionType", userTransaction.ActionType);
                        command.Parameters.AddWithValue("@Bank", ((object)userTransaction.Bank) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Income", ((object)userTransaction.Income) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Expense", ((object)userTransaction.Expense) ?? DBNull.Value);
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
                UtilityService.ShowExceptionMessageBox();
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
                UtilityService.ShowExceptionMessageBox();
            }

            return result;
        }

        public bool DeleteUserTransaction(string invoiceNo)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [InvoiceNo] = @InvoiceNo ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)invoiceNo) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return result;
        }
    }
}
