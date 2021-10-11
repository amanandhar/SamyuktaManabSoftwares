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
        private readonly string connectionString;

        public MSSqlUserTransactionRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<UserTransaction> GetUserTransactions()
        {
            var userTransactions = new List<UserTransaction>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], " +
                "[InvoiceNo], [BillNo], [MemberId], [ShareMemberId], [SupplierId], [DeliveryPersonId], " +
                "[Action], [ActionType], [Bank], [Income], [Expense], [Narration], " +
                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "ORDER BY Id ";

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
                throw new Exception(ex.Message);
            }

            return userTransactions;
        }

        public IEnumerable<UserTransaction> GetUserTransactions(string memberId)
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
                "AND MemberId = @MemberId " +
                "ORDER BY Id ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberId", ((object)memberId) ?? DBNull.Value);

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
                throw new Exception(ex.Message);
            }

            return userTransactions;
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
                "WHERE 1=1 ";

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
                query += "AND [MemberId] = @MemberId ";
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
                throw new Exception(ex.Message);
            }

            return userTransactions;

        }

        public IEnumerable<UserTransaction> GetUserTransactions(DeliveryPersonFilter deliveryPersonFilter)
        {
            var userTransactions = new List<UserTransaction>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], " +
                "[InvoiceNo], [BillNo], [MemberId], [ShareMemberId], [SupplierId], [DeliveryPersonId], " +
                "[Action], [ActionType], [Bank], [Income], [Expense], [Narration], " +
                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1=1 " +
                "AND [Income] = '" + Constants.DELIVERY_CHARGE + "' ";

            if (!string.IsNullOrWhiteSpace(deliveryPersonFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(deliveryPersonFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(deliveryPersonFilter?.EmployeeId))
            {
                query += "AND [DeliveryPersonId] = @DeliveryPersonId ";
            }

            query += "ORDER BY [Id] ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)deliveryPersonFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)deliveryPersonFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryPersonId", ((object)deliveryPersonFilter?.EmployeeId) ?? DBNull.Value);

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
                throw new Exception(ex.Message);
            }

            return userTransactions;
        }

        public IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId)
        {
            var memberTransactionViews = new List<MemberTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Action], " +
                "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[InvoiceNo], [DueReceivedAmount], [ReceivedAmount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Income], '') != '" + Constants.DELIVERY_CHARGE + "' " +
                "AND ISNULL([Expense], '') != '" + Constants.SALES_DISCOUNT + "' " +
                "AND [MemberId] IS NOT NULL ";

            if (!string.IsNullOrWhiteSpace(memberId))
            {
                query += "AND ISNULL([MemberId], '') = @MemberId ";
            }

            query += "ORDER BY [Id] ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberId", ((object)memberId) ?? DBNull.Value);

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
                                    Balance = 0.00m
                                };

                                memberTransactionViews.Add(memberTransactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return memberTransactionViews;
        }

        public IEnumerable<MemberTransactionView> GetMemberTransactions(MemberFilter memberFilter)
        {
            var memberTransactionViews = new List<MemberTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Action], " +
                "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[InvoiceNo], [DueReceivedAmount], [ReceivedAmount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Income], '') != '" + Constants.DELIVERY_CHARGE + "' " +
                "AND ISNULL([Expense], '') != '" + Constants.SALES_DISCOUNT + "' " +
                "AND [MemberId] IS NOT NULL ";
            
            if(!string.IsNullOrEmpty(memberFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrEmpty(memberFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrEmpty(memberFilter?.Action))
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
                        command.Parameters.AddWithValue("@DateFrom", ((object)memberFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)memberFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)memberFilter?.Action) ?? DBNull.Value);

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
                                    Balance = 0.00M
                                };

                                memberTransactionViews.Add(memberTransactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return memberTransactionViews;
        }

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(string supplierId)
        {
            var supplierTransactionViews = new List<SupplierTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Action], " +
                "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[BillNo], [DuePaymentAmount], [PaymentAmount], " +
                "(SELECT SUM(ISNULL(b.[DuePaymentAmount], 0) - ISNULL(b.[PaymentAmount], 0)) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " b " +
                "WHERE b.[AddedDate] <= a.[AddedDate] AND [SupplierId] = @SupplierId) AS Balance " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " a " +
                "WHERE 1 = 1 " +
                "AND [SupplierId] = @SupplierId " + 
                "ORDER BY Id ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", ((object)supplierId) ?? DBNull.Value);

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
                throw new Exception(ex.Message);
            }

            return supplierTransactionViews;
        }

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierFilter)
        {
            var supplierTransactionViews = new List<SupplierTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Action], " +
                "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[BillNo], [DuePaymentAmount], [PaymentAmount], " +
                "(SELECT SUM(ISNULL(b.[DuePaymentAmount], 0) - ISNULL(b.[PaymentAmount], 0)) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " b " +
                "WHERE 1 = 1 " +
                "AND b.[AddedDate] <= a.[AddedDate] ";
            if (!string.IsNullOrWhiteSpace(supplierFilter.SupplierId))
            {
                query += "AND [SupplierId] = @SupplierId ";
            }

            query += ") AS Balance " +
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
                query += "AND [SupplierId] = @SupplierId ";
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
                throw new Exception(ex.Message);
            }

            return supplierTransactionViews;
        }

        public IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter expenseTransactionFilter)
        {
            var expenseTransactionViews = new List<ExpenseTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Action], " +
                "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[Expense], [Narration], [DuePaymentAmount], [PaymentAmount], " +
                "(ISNULL([DuePaymentAmount], 0) - ISNULL([PaymentAmount], 0)) AS Amount " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] = '" + Constants.EXPENSE + "' ";

      
            if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.DateFrom))
            {
                query += " AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.DateTo))
            {
                query += " AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.Expense))
            {
                query += " AND [Expense] = @Expense ";
            }

            query += "ORDER BY [Id] ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)expenseTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)expenseTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Expense", ((object)expenseTransactionFilter?.Expense) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var expenseTransactionView = new ExpenseTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    Expense = reader["Expense"].ToString(),
                                    Narration = reader["Narration"].ToString(),
                                    DuePaymentAmount = Convert.ToDecimal(reader["DuePaymentAmount"].ToString()),
                                    PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString()),
                                    Amount = Convert.ToDecimal(reader["Amount"].ToString())
                                };

                                expenseTransactionViews.Add(expenseTransactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return expenseTransactionViews;
        }

        public UserTransaction GetUserTransaction(long userTransactionId)
        {
            var userTransaction = new UserTransaction();
            var query = @"SELECT " +
                "[Id], [EndOfDay], " +
                "[InvoiceNo], [BillNo], [MemberId], [ShareMemberId], [SupplierId], [DeliveryPersonId], " +
                "[Action], [ActionType], [Bank], [Income], [Expense], [Narration], " +
                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id " +
                "AND ISNULL([Income], '') != '" + Constants.DELIVERY_CHARGE + "' " +
                "AND ISNULL([Expense], '') != '" + Constants.SALES_DISCOUNT + "' ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)userTransactionId) ?? DBNull.Value);

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
                throw new Exception(ex.Message);
            }

            return userTransaction;
        }

        public UserTransaction GetUserTransaction(string invoiceNo)
        {
            var userTransaction = new UserTransaction();
            var query = @"SELECT " +
                "[Id], [EndOfDay], " +
                "[InvoiceNo], [BillNo], [MemberId], [ShareMemberId], [SupplierId], [DeliveryPersonId], " +
                "[Action], [ActionType], [Bank], [Income], [Expense], [Narration], " +
                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [InvoiceNo] = @InvoiceNo " +
                "AND ISNULL([Income], '') != '" + Constants.DELIVERY_CHARGE + "' " +
                "AND ISNULL([Expense], '') != '" + Constants.SALES_DISCOUNT + "' ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)invoiceNo) ?? DBNull.Value);

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
                throw new Exception(ex.Message);
            }

            return userTransaction;
        }
        
        public UserTransaction GetLastUserTransaction(string option)
        {
            var userTransaction = new UserTransaction();
            var query = @"SELECT " +
                "TOP 1 " +
                "[Id], [EndOfDay], " +
                "[InvoiceNo], [BillNo], [MemberId], [ShareMemberId], [SupplierId], [DeliveryPersonId], " +
                "[Action], [ActionType], [Bank], [Income], [Expense], [Narration], " +
                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ";

            if(!string.IsNullOrWhiteSpace(option))
            {
                if(option.StartsWith(Constants.INVOICE_NO_PREFIX))
                {
                    query += "WHERE 1 = 1 AND ([InvoiceNo] IS NOT NULL AND DATALENGTH([InvoiceNo]) > 0) ";
                }
                else if(option.StartsWith(Constants.BILL_NO_PREFIX))
                {
                    query += "WHERE 1 = 1 AND ([BillNo] IS NOT NULL AND DATALENGTH([BillNo]) > 0) ";
                }
            }
            
            query += "ORDER BY [Id] DESC ";
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
                throw new Exception(ex.Message);
            }

            return userTransaction;
        }

        public string GetLastInvoiceNo()
        {
            string query = @"SELECT " +
                "TOP 1 [InvoiceNo] " +
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
                throw new Exception(ex.Message);
            }

            return invoiceNo;
        }

        public decimal GetMemberTotalBalance(UserTransactionFilter userTransactionFilter)
        {
            decimal balance = 0.00m;
            string query = @"SELECT " +
                "SUM(Temp.[Amount]) " +
                "FROM " +
                "( " +
                "SELECT " +
                "CASE " +
                "WHEN [Action] = '" + Constants.SALES + "' AND [ActionType] = '" + Constants.CASH + "' THEN 0.00 " +
                "ELSE ([DueReceivedAmount] - [ReceivedAmount]) " +
                "END AS [Amount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Income], '') != '" + Constants.DELIVERY_CHARGE + "' " +
                "AND ISNULL([Expense], '') != '" + Constants.SALES_DISCOUNT + "' ";

            if(!string.IsNullOrWhiteSpace(userTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.MemberId))
            {
                query += "AND [MemberId] = @MemberId ";
            }
            else
            {
                query += "AND [MemberId] IS NOT NULL ";
            }

            query += ") Temp";

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

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            balance = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return balance;
        }

        public decimal GetSupplierTotalBalance(SupplierTransactionFilter supplierTransactionFilter)
        {
            decimal balance = 0.00m;
            string query = @"SELECT " +
                "SUM([DuePaymentAmount]) - SUM([PaymentAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 ";
            
            if(!string.IsNullOrWhiteSpace(supplierTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(supplierTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(supplierTransactionFilter?.SupplierId))
            {
                query += "AND [SupplierId] = @SupplierId ";
            }
            else
            {
                query += "AND [SupplierId] IS NOT NULL ";
            }

            if (!string.IsNullOrWhiteSpace(supplierTransactionFilter?.Action))
            {
                query += "AND [Action] = @Action ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)supplierTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)supplierTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SupplierId", ((object)supplierTransactionFilter?.SupplierId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)supplierTransactionFilter?.Action) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            balance = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return balance;
        }

        public decimal GetCashInHand(UserTransactionFilter userTransactionFilter)
        {
            decimal cashInHand = 0.00m;
            string query = @"SELECT " +
                "( " +
                "SELECT " +
                "ISNULL(SUM([ReceivedAmount]), 0) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] IN ('" + Constants.SALES + "', '" + Constants.RECEIPT + "') " +
                "AND [ActionType] = '" + Constants.CASH + "' " +
                "AND [Id] NOT IN " +
                "( " +
                "SELECT [Id] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Income] = '" + Constants.DELIVERY_CHARGE + "' ";
            
            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            query += ") ";

            if(!string.IsNullOrWhiteSpace(userTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            query += ") " +
                "- " +
                "( " +
                "SELECT " +
                "ISNULL(SUM([PaymentAmount]), 0) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] IN ('" + Constants.BANK_TRANSFER + "', '" + Constants.EXPENSE + "', '" + Constants.PAYMENT + "') " +
                "AND [ActionType] = '" + Constants.CASH + "' " +
                "AND [Id] NOT IN " +
                "( " +
                "SELECT [Id] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Expense] = '" + Constants.SALES_DISCOUNT + "' ";

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            query += ") ";

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            query += ") ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)userTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)userTransactionFilter?.DateTo) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            cashInHand = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cashInHand;
        }

        public decimal GetTotalBalance(string endOfDay, string action, string actionType)
        {
            decimal balance = 0.00m;
            var query = string.Empty;
            if (action?.ToLower() == Constants.SALES.ToLower()
                || action?.ToLower() == Constants.RECEIPT.ToLower())
            {
                query = @"SELECT " +
                    "SUM([ReceivedAmount]) " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [Id] NOT IN " +
                    "( " +
                    "SELECT [Id] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE [Expense] = '" + Constants.SALES_DISCOUNT + "' " +
                    ") ";
            }
            else if (action?.ToLower() == Constants.PAYMENT.ToLower()
                || action?.ToLower() == Constants.EXPENSE.ToLower()
                || action?.ToLower() == Constants.BANK_TRANSFER.ToLower())
            {
                query = @"SELECT " +
                    "SUM([PaymentAmount]) " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [Id] NOT IN " +
                    "( " +
                    "SELECT [Id] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE [Income] = '" + Constants.DELIVERY_CHARGE + "' " +
                    ") ";
            }
            else
            {
                query += " ";
            }

            if (!string.IsNullOrWhiteSpace(endOfDay))
            {
                query += "AND [EndOfDay] = @EndOfDay ";
            }

            if (!string.IsNullOrWhiteSpace(action))
            {
                query += "AND [Action] = @Action ";
            }

            if (!string.IsNullOrWhiteSpace(actionType))
            {
                query += "AND [ActionType] = @ActionType ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)endOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ActionType", ((object)actionType) ?? DBNull.Value);
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            balance = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return balance;
        }

        public decimal GetPreviousTotalBalance(string endOfDay, string action, string actionType)
        {
            decimal balance = 0.00m;
            var query = string.Empty;
            if (action?.ToLower() == Constants.SALES.ToLower()
                || action?.ToLower() == Constants.RECEIPT.ToLower())
            {
                query = @"SELECT " +
                    "SUM([ReceivedAmount]) " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [Id] NOT IN " +
                    "( " +
                    "SELECT [Id] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE [Expense] = '" + Constants.SALES_DISCOUNT + "' " +
                    ") ";
            }
            else if(action?.ToLower() == Constants.PAYMENT.ToLower()
                || action?.ToLower() == Constants.EXPENSE.ToLower()
                || action?.ToLower() == Constants.BANK_TRANSFER.ToLower())
            {
                query = @"SELECT " +
                    "SUM([PaymentAmount]) " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [Id] NOT IN " +
                    "( " +
                    "SELECT [Id] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE [Income] = '" + Constants.DELIVERY_CHARGE + "' " +
                    ") ";
            }
            else
            {
                query += " ";
            }

            if(!string.IsNullOrWhiteSpace(endOfDay))
            {
                query += "AND [EndOfDay] < @EndOfDay ";
            }

            if (!string.IsNullOrWhiteSpace(action))
            {
                query += "AND [Action] = @Action ";
            }

            if (!string.IsNullOrWhiteSpace(actionType))
            {
                query += "AND [ActionType] = @ActionType ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)endOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ActionType", ((object)actionType) ?? DBNull.Value);
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            balance = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return balance;
        }

        public decimal GetTotalExpense(ExpenseTransactionFilter expenseTransactionFilter)
        {
            decimal balance = 0.00m;
            string query = @"SELECT " +
                    "SUM([DuePaymentAmount] + [PaymentAmount])" +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [Action] = '" + Constants.EXPENSE + "' ";

            if(!string.IsNullOrWhiteSpace(expenseTransactionFilter?.DateFrom))
            {
                query += " AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.DateTo))
            {
                query += " AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.Expense))
            {
                query += " AND [Expense] = @Expense ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)expenseTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)expenseTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Expense", ((object)expenseTransactionFilter?.Expense) ?? DBNull.Value);
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            balance = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return balance;
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
                throw new Exception(ex.Message);
            }

            return invoices;
        }

        public IEnumerable<string> GetMemberIds()
        {
            var memberIds = new List<string>();
            var query = @"SELECT " +
                "DISTINCT [MemberId] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "ORDER BY [MemberId] ";
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
                                var memberId = reader["MemberId"].ToString();

                                memberIds.Add(memberId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return memberIds;
        }

        public decimal GetUserTransactionBalance(DailyTransactionFilter dailyTransactionFilter)
        {
            decimal total = 0.00m;
            var query = @"SELECT " +
                "SUM(ut.[DueReceivedAmount]) + SUM(ut.[ReceivedAmount]) - SUM(ut.[DuePaymentAmount]) - SUM(ut.[PaymentAmount]) AS [Total] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "LEFT JOIN " + Constants.TABLE_SOLD_ITEM + " si " +
                "ON ut.[InvoiceNo] = si.[InvoiceNo] " +
                "INNNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 ";

            if (dailyTransactionFilter.Date != null)
            {
                query += " AND ut.[EndOfDay] = '" + dailyTransactionFilter.Date + "' ";
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
            else if (dailyTransactionFilter.Expense != null)
            {
                query += " AND ut.[Action] = '" + Constants.EXPENSE + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Expense + "' ";
            }
            else if (dailyTransactionFilter.ItemCode != null)
            {
                query += " AND i.[ItemCode] = '" + dailyTransactionFilter.ItemCode + "' ";
            }
            else if (dailyTransactionFilter.InvoiceNo != null)
            {
                query += " AND ut.[InvoiceNo] = '" + dailyTransactionFilter.InvoiceNo + "' ";
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
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            total = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return total;
        }

        public IEnumerable<TransactionView> GetTransactionViewList(DailyTransactionFilter dailyTransactionFilter)
        {
            var transactionViewList = new List<TransactionView>();
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
                    "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.SHARE_CHEQUE + "' THEN ut.[ReceivedAmount] " +
                    "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DuePaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DuePaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.BANK_TRANSFER + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[PaymentAmount] " +
                    "WHEN ut.[Action]='" + Constants.BANK_TRANSFER + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[PaymentAmount] " +
                    "ELSE ut.[DueReceivedAmount] " +
                "END  AS [Amount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "WHERE 1 = 1 " +
                "AND ISNULL(ut.[Income], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "', '" + Constants.MEMBER_FEE + "', '" + Constants.OTHER_INCOME + "', '" + Constants.SALES_PROFIT + "') ";

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
                query += " AND ut.[InvoiceNo] = '" + dailyTransactionFilter.InvoiceNo + "' ";
            }
            else if (dailyTransactionFilter.Username != null)
            {
                query += " AND ut.[AddedBy] = '" + dailyTransactionFilter.Username + "' ";
            }
            else
            {
                query += " ";
            }

            query += "ORDER BY ut.[Id] DESC";
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
                                var transactionView = new TransactionView
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
                                    Amount = reader.IsDBNull(9) ? 0.00m : Convert.ToDecimal(reader["Amount"].ToString())
                                };

                                transactionViewList.Add(transactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return transactionViewList;
        }

        public IEnumerable<IncomeDetailView> GetIncome(IncomeTransactionFilter incomeTransactionFilter)
        {
            var incomeDetails = new List<IncomeDetailView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Bank], [Income], ([DueReceivedAmount] + [ReceivedAmount]) AS [Amount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Income], '') = '" + Constants.INCOME + "' ";

            if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrEmpty(incomeTransactionFilter?.Income))
            {
                query += "AND [Income] = @Income ";
            }

            query += "ORDER BY [Id] ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)incomeTransactionFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)incomeTransactionFilter.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Income", ((object)incomeTransactionFilter.Income) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var incomeDetail = new IncomeDetailView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    InvoiceNo = reader["Income"].ToString(),
                                    ItemCode = string.Empty,
                                    ItemName = reader["Bank"].ToString(),
                                    ItemBrand = string.Empty,
                                    Quantity = 0.00m,
                                    Profit = 0.00m,
                                    Amount = Convert.ToDecimal(reader["Amount"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return incomeDetails;
        }

        public IEnumerable<IncomeDetailView> GetSalesProfit(IncomeTransactionFilter incomeTransactionFilter)
        {
            var incomeDetails = new List<IncomeDetailView>();
            var query = @"SELECT " +
                "si.[Id] AS [Id], si.[EndOfDay] AS [EndOfDay], si.[InvoiceNo] AS [InvoiceNo], " +
                "i.[Code] AS [ItemCode], i.[Name] AS [ItemName], i.[Brand] AS [ItemBrand], " +
                "si.[Quantity] AS [Quantity], si.[Profit] AS [Profit], " +
                "CAST((si.[Quantity] * si.[Profit]) AS DECIMAL(18, 2)) AS [Amount] " +
                "FROM " + Constants.TABLE_ITEM + " i " +
                "INNER JOIN " + Constants.TABLE_SOLD_ITEM + " si " +
                "ON i.[Id] = si.[ItemId] " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateFrom))
            {
                query += "AND si.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateTo))
            {
                query += "AND si.[EndOfDay] <= @DateTo ";
            }

            query += "ORDER BY si.[AddedDate] DESC ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)incomeTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)incomeTransactionFilter?.DateTo) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var incomeDetail = new IncomeDetailView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["ItemName"].ToString(),
                                    ItemBrand = reader["ItemBrand"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    Profit = Convert.ToDecimal(reader["Profit"].ToString()),
                                    Amount = Convert.ToDecimal(reader["Amount"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return incomeDetails;
        }

        public IEnumerable<IncomeDetailView> GetPurchaseBonus(IncomeTransactionFilter incomeTransactionFilter)
        {
            var incomeDetails = new List<IncomeDetailView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Bank], [Income], ([DueReceivedAmount] + [ReceivedAmount]) AS [Amount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] = '" + Constants.PURCHASE + "' " +
                "AND ISNULL([Income], '') = '" + Constants.PURCHASE_BONUS +"' ";

            if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            query += "ORDER BY [Id] ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)incomeTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)incomeTransactionFilter?.DateTo) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var incomeDetail = new IncomeDetailView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    InvoiceNo = reader["Income"].ToString(),
                                    ItemCode = string.Empty,
                                    ItemName = reader["Bank"].ToString(),
                                    ItemBrand = string.Empty,
                                    Quantity = 0.00m,
                                    Profit = 0.00m,
                                    Amount = Convert.ToDecimal(reader["Amount"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return incomeDetails;
        }

        public IEnumerable<ShareMemberTransactionView> GetShareMemberTransactions(long shareMemberId)
        {
            var shareMemberTransactionViewList = new List<ShareMemberTransactionView>();
            var query = @"SELECT " +
                "bt.[Id], bt.[EndOfDay], bt.[Narration] AS [Description], " +
                "CASE WHEN bt.[Action] = 1 THEN '" + Constants.DEPOSIT + "' ELSE '" + Constants.WITHDRAWL + "' END AS [Type], " +
                "bt.[Debit], bt.[Credit], (bt.[Debit] - bt.[Credit]) AS [Balance] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "INNER JOIN " + 
                Constants.TABLE_BANK_TRANSACTION + " bt " +
                "ON ut.[id] = bt.[TransactionId] " + 
                "WHERE 1 = 1 " +
                "AND ut.[ShareMemberId] = @ShareMemberId ";
                
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ShareMemberId", ((object)shareMemberId) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var shareMemberTransactionView = new ShareMemberTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Type = reader["Type"].ToString(),
                                    Debit = Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = Convert.ToDecimal(reader["Credit"].ToString()),
                                    Balance = Convert.ToDecimal(reader["Balance"].ToString())
                                };

                                shareMemberTransactionViewList.Add(shareMemberTransactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                        command.Parameters.AddWithValue("@DueReceivedAmount", ((object)userTransaction.DueReceivedAmount) ?? 0.00m);
                        command.Parameters.AddWithValue("@DuePaymentAmount", ((object)userTransaction.DuePaymentAmount) ?? 0.00m);
                        command.Parameters.AddWithValue("@ReceivedAmount", ((object)userTransaction.ReceivedAmount) ?? 0.00m);
                        command.Parameters.AddWithValue("@PaymentAmount", ((object)userTransaction.PaymentAmount) ?? 0.00m);
                        command.Parameters.AddWithValue("@AddedBy", userTransaction.AddedBy);
                        command.Parameters.AddWithValue("@AddedDate", userTransaction.AddedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userTransaction;
        }

        public UserTransaction UpdateUserTransaction(long userTransactionId, UserTransaction userTransaction)
        {
            throw new NotImplementedException();
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool DeleteUserTransactionAfterEndOfDay(string endOfDay)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [EndOfDay] > @EndOfDay ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)endOfDay) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
