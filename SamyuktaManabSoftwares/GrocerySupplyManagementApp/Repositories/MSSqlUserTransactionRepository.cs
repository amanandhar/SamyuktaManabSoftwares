using GrocerySupplyManagementApp.ViewModels;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GrocerySupplyManagementApp.DTOs;

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
                "[Id], [EndOfDay], [InvoiceNo], [BillNo], [MemberId], " +
                "[SupplierId], [DeliveryPersonId], [Action], [ActionType], [Bank], [IncomeExpense], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], " + 
                "[Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[DueAmount], [ReceivedAmount], [AddedDate], [UpdatedDate] " +
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
                                    SupplierId = reader["SupplierId"].ToString(),
                                    DeliveryPersonId = reader["DeliveryPersonId"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    Bank = reader["Bank"].ToString(),
                                    IncomeExpense = reader["IncomeExpense"].ToString(),
                                    SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString()),
                                    DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString()),
                                    Discount = Convert.ToDecimal(reader["Discount"].ToString()),
                                    VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString()),
                                    Vat = Convert.ToDecimal(reader["Vat"].ToString()),
                                    DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString()),
                                    DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString()),
                                    DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString())
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
                "[Id], [EndOfDay], [InvoiceNo], [BillNo], [MemberId], " +
                "[SupplierId], [DeliveryPersonId], [Action], [ActionType], [Bank], [IncomeExpense], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], " + 
                "[Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[DueAmount], [ReceivedAmount], [AddedDate], [UpdatedDate] " +
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
                                    SupplierId = reader["SupplierId"].ToString(),
                                    DeliveryPersonId = reader["DeliveryPersonId"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    Bank = reader["Bank"].ToString(),
                                    IncomeExpense = reader["IncomeExpense"].ToString(),
                                    SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString()),
                                    DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString()),
                                    Discount = Convert.ToDecimal(reader["Discount"].ToString()),
                                    VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString()),
                                    Vat = Convert.ToDecimal(reader["Vat"].ToString()),
                                    DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString()),
                                    DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString()),
                                    DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()), 
                                    UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString())
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
                "[Id], [EndOfDay], [InvoiceNo], [BillNo], [MemberId], " +
                "[SupplierId], [DeliveryPersonId], [Action], [ActionType], [Bank], [IncomeExpense], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], " +
                "[Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[DueAmount], [ReceivedAmount], [AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1=1 " +
                "AND [IncomeExpense] = '" + Constants.DELIVERY_CHARGE + "' ";

            if (!string.IsNullOrWhiteSpace(deliveryPersonFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(deliveryPersonFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (deliveryPersonFilter?.EmployeeId != null)
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
                                    SupplierId = reader["SupplierId"].ToString(),
                                    DeliveryPersonId = reader["DeliveryPersonId"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    Bank = reader["Bank"].ToString(),
                                    IncomeExpense = reader["IncomeExpense"].ToString(),
                                    SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString()),
                                    DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString()),
                                    Discount = Convert.ToDecimal(reader["Discount"].ToString()),
                                    VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString()),
                                    Vat = Convert.ToDecimal(reader["Vat"].ToString()),
                                    DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString()),
                                    DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString()),
                                    DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString())
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
                "[InvoiceNo], [DueAmount], [ReceivedAmount], " +
                "( " +
                "SELECT SUM(ISNULL(b.[DueAmount], 0) - ISNULL(b.[ReceivedAmount], 0)) FROM UserTransaction b " +
                "WHERE 1 = 1 " +
                "AND b.[AddedDate] <= a.[AddedDate] " +
                "AND ISNULL([IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') " +
                "AND [MemberId] = @MemberId " +
                ")  AS Balance " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " a " +
                "WHERE 1 = 1 " +
                "AND ISNULL([IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') " +
                "AND [MemberId] = @MemberId " +
                "ORDER BY [Id] ";

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
                                    DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    Balance = Convert.ToDecimal(reader["Balance"].ToString())
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
                "[InvoiceNo], [DueAmount], [ReceivedAmount], " +
                "( " +
                "SELECT SUM(ISNULL(b.[DueAmount], 0) - ISNULL(b.[ReceivedAmount], 0)) FROM UserTransaction b " +
                "WHERE 1 = 1 " +
                "AND b.[AddedDate] <= a.[AddedDate] " +
                "AND ISNULL(b.[IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') " +
                "AND b.[MemberId] IS NOT NULL " +
                ")  AS Balance " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " a " +
                "WHERE 1 = 1 " +
                "AND ISNULL([IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') " +
                "AND [MemberId] IS NOT NULL ";

            if (!string.IsNullOrEmpty(memberFilter?.Action))
            {
                query += "AND [Action] = @Action ";
            }
                
            if(!string.IsNullOrEmpty(memberFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrEmpty(memberFilter?.DateTo))
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
                        command.Parameters.AddWithValue("@Action", ((object)memberFilter?.Action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateFrom", ((object)memberFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)memberFilter?.DateTo) ?? DBNull.Value);

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
                                    DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    Balance = Convert.ToDecimal(reader["Balance"].ToString())
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
                "[BillNo], [DueAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.[DueAmount], 0) - ISNULL(b.[ReceivedAmount], 0)) " +
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
                                    DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
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

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierFilter supplierFilter)
        {
            var supplierTransactionViews = new List<SupplierTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Action], " +
                "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[BillNo], [DueAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.[DueAmount], 0) - ISNULL(b.[ReceivedAmount], 0)) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " b " +
                "WHERE b.[AddedDate] <= a.[AddedDate]) AS Balance " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " a " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(supplierFilter?.Action))
            {
                query += "AND [Action] = @Action ";
            }

            if (!string.IsNullOrEmpty(supplierFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrEmpty(supplierFilter?.DateTo))
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
                        command.Parameters.AddWithValue("@DateFrom", ((object)supplierFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)supplierFilter.DateTo) ?? DBNull.Value);
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
                                    DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
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
                "[IncomeExpense], [DueAmount], [ReceivedAmount], " +
                "(ISNULL([DueAmount], 0) - ISNULL([ReceivedAmount], 0)) AS Amount " +
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
                query += " AND [IncomeExpense] = @IncomeExpense ";
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
                        command.Parameters.AddWithValue("@IncomeExpense", ((object)expenseTransactionFilter?.Expense) ?? DBNull.Value);

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
                                    Expense = reader["IncomeExpense"].ToString(),
                                    DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
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
                "[Id], [InvoiceNo], [EndOfDay], [BillNo], [MemberId], [SupplierId], [DeliveryPersonId], [Action], [ActionType], [Bank], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[DueAmount], [ReceivedAmount], [AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id " +
                "AND ISNULL([IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') ";

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
                                userTransaction.SupplierId = reader["SupplierId"].ToString();
                                userTransaction.DeliveryPersonId = reader["DeliveryPersonId"].ToString();
                                userTransaction.Action = reader["Action"].ToString();
                                userTransaction.ActionType = reader["ActionType"].ToString();
                                userTransaction.Bank = reader["Bank"].ToString();
                                userTransaction.SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString());
                                userTransaction.DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString());
                                userTransaction.Discount = Convert.ToDecimal(reader["Discount"].ToString());
                                userTransaction.VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString());
                                userTransaction.Vat = Convert.ToDecimal(reader["Vat"].ToString());
                                userTransaction.DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString());
                                userTransaction.DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString());
                                userTransaction.DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString());
                                userTransaction.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                userTransaction.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                userTransaction.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
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
                "[Id], [InvoiceNo], [EndOfDay], [BillNo], [MemberId], [SupplierId], [DeliveryPersonId], [Action], [ActionType], [Bank], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[DueAmount], [ReceivedAmount], [AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [InvoiceNo] = @InvoiceNo " +
                "AND ISNULL([IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') ";

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
                                userTransaction.SupplierId = reader["SupplierId"].ToString();
                                userTransaction.DeliveryPersonId = reader["DeliveryPersonId"].ToString();
                                userTransaction.Action = reader["Action"].ToString();
                                userTransaction.ActionType = reader["ActionType"].ToString();
                                userTransaction.Bank = reader["Bank"].ToString();
                                userTransaction.SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString());
                                userTransaction.DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString());
                                userTransaction.Discount = Convert.ToDecimal(reader["Discount"].ToString());
                                userTransaction.VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString());
                                userTransaction.Vat = Convert.ToDecimal(reader["Vat"].ToString());
                                userTransaction.DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString());
                                userTransaction.DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString());
                                userTransaction.DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString());
                                userTransaction.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                userTransaction.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                userTransaction.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
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
                "[Id], [EndOfDay], [InvoiceNo], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[DueAmount], [ReceivedAmount], [AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ";

            if(!string.IsNullOrWhiteSpace(option))
            {
                if(option.StartsWith("IN"))
                {
                    query += "WHERE 1 = 1 AND ([InvoiceNo] IS NOT NULL AND DATALENGTH([InvoiceNo]) > 0) ";
                }
                else if(option.StartsWith("BN"))
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
                                userTransaction.SupplierId = reader["SupplierId"].ToString();
                                userTransaction.Action = reader["Action"].ToString();
                                userTransaction.ActionType = reader["ActionType"].ToString();
                                userTransaction.Bank = reader["Bank"].ToString();
                                userTransaction.SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString());
                                userTransaction.DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString());
                                userTransaction.Discount = Convert.ToDecimal(reader["Discount"].ToString());
                                userTransaction.VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString());
                                userTransaction.Vat = Convert.ToDecimal(reader["Vat"].ToString());
                                userTransaction.DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString());
                                userTransaction.DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString());
                                userTransaction.DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString());
                                userTransaction.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                userTransaction.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                userTransaction.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
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

        public decimal GetMemberTotalBalance()
        {
            decimal balance = 0.00m;
            string query = @"SELECT " +
                "SUM([DueAmount]) - SUM([ReceivedAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [MemberId] IS NOT NULL " +
                "AND [InvoiceNo] IS NOT NULL " +
                "AND ISNULL([IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') ";

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

        public decimal GetMemberTotalBalance(string memberId)
        {
            decimal balance = 0.00m;
            string query = @"SELECT " +
                "SUM([DueAmount]) - SUM([ReceivedAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [MemberId] = @MemberId " +
                "AND ISNULL([IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberId", ((object)memberId) ?? DBNull.Value);
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

        public decimal GetSupplierTotalBalance()
        {
            decimal balance = 0.00m;
            string query = @"SELECT " +
                "SUM([ReceivedAmount]) - SUM([DueAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [SupplierId] IS NOT NULL ";

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

        public decimal GetSupplierTotalBalance(string supplierId)
        {
            decimal balance = 0.00m;
            string query = @"SELECT " +
                "SUM([ReceivedAmount]) - SUM([DueAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [SupplierId] = @SupplierId ";
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", ((object)supplierId) ?? DBNull.Value);
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

        public decimal GetCashInHand()
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
                "WHERE [IncomeExpense] = '" + Constants.DELIVERY_CHARGE + "' " +
                ") " +
                ") " +
                "- " +
                "( " +
                "SELECT " +
                "ISNULL(SUM([DueAmount]), 0) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] IN ('" + Constants.TRANSFER + "', '" + Constants.EXPENSE + "') " +
                "AND [ActionType] = '" + Constants.CASH + "' " +
                "AND [Id] NOT IN " +
                "( " +
                "SELECT [Id] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE [IncomeExpense] = '" + Constants.SALES_DISCOUNT + "' " +
                ") " +
                ") ";

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
            string query;
            if (action?.ToLower() == Constants.SALES.ToLower()
                || action?.ToLower() == Constants.EXPENSE.ToLower()
                || action?.ToLower() == Constants.TRANSFER.ToLower())
            {
                query = @"SELECT " +
                    "SUM([DueAmount])" +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [EndOfDay] = @endOfDay " +
                    "AND [Action] = @Action " +
                    "AND [ActionType] = @ActionType " +
                    "AND [Id] NOT IN " +
                    "( " +
                    "SELECT [Id] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE [IncomeExpense] = '" + Constants.SALES_DISCOUNT + "' " +
                    ") ";
            }
            else
            {
                query = @"SELECT " +
                    "SUM([ReceivedAmount])" +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [EndOfDay] = @endOfDay " +
                    "AND [Action] = @Action " +
                    "AND [ActionType] = @ActionType " +
                    "AND [Id] NOT IN " +
                    "( " +
                    "SELECT [Id] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE [IncomeExpense] = '" + Constants.DELIVERY_CHARGE + "' " +
                    ") " ;
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
            string query;
            if (action?.ToLower() == Constants.SALES.ToLower()
                || action?.ToLower() == Constants.EXPENSE.ToLower()
                || action?.ToLower() == Constants.TRANSFER.ToLower())
            {
                query = @"SELECT " +
                    "SUM([DueAmount])" +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [EndOfDay] < @endOfDay " +
                    "AND [Action] = @Action " +
                    "AND [ActionType] = @ActionType " +
                    "AND [Id] NOT IN " +
                    "( " +
                    "SELECT [Id] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE [IncomeExpense] = '" + Constants.SALES_DISCOUNT + "' " +
                    ") ";
            }
            else
            {
                query = @"SELECT " +
                    "SUM([ReceivedAmount])" +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [EndOfDay] < @endOfDay " +
                    "AND [Action] = @Action " +
                    "AND [Id] NOT IN " +
                    "( " +
                    "SELECT [Id] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE [IncomeExpense] = '" + Constants.DELIVERY_CHARGE + "' " +
                    ") ";
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

        public decimal GetTotalExpense(string expense)
        {
            decimal balance = 0.00m;
            string query = @"SELECT " +
                    "SUM([DueAmount])" +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [Action] = '" + Constants.EXPENSE + "' " +
                    "AND [IncomeExpense] = @Expense ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Expense", ((object)expense) ?? DBNull.Value);
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

        public decimal GetUserTransactionBalance(TransactionFilter transactionFilter)
        {
            decimal total = 0.00m;
            var query = @"SELECT " +
                "SUM(ut.[DueAmount]) - SUM(ut.[ReceivedAmount]) AS [Total] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "LEFT JOIN " + Constants.TABLE_SOLD_ITEM + " si " +
                "ON ut.[InvoiceNo] = si.[InvoiceNo] " +
                "INNNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 ";

            if (transactionFilter.Date != null)
            {
                query += " AND ut.[EndOfDay] = '" + transactionFilter.Date + "' ";
            }

            if (transactionFilter.Purchase != null)
            {
                query += " AND ut.[Action] = '" + Constants.PURCHASE + "' AND ut.[ActionType] = '" + transactionFilter.Purchase + "' ";
            }
            else if (transactionFilter.Sales != null)
            {
                query += " AND ut.[Action] = '" + Constants.SALES + "' AND ut.[ActionType] = '" + transactionFilter.Sales + "' ";
            }
            else if (transactionFilter.Payment != null)
            {
                query += " AND ut.[Action] = '" + Constants.PAYMENT + "' AND ut.[ActionType] = '" + transactionFilter.Payment + "' ";
            }
            else if (transactionFilter.Receipt != null)
            {
                query += " AND ut.[Action] = '" + Constants.RECEIPT + "' AND ut.[ActionType] = '" + transactionFilter.Receipt + "' ";
            }
            else if (transactionFilter.Expense != null)
            {
                query += " AND ut.[Action] = '" + Constants.EXPENSE + "' AND ut.[ActionType] = '" + transactionFilter.Expense + "' ";
            }
            else if (transactionFilter.ItemCode != null)
            {
                query += " AND i.[ItemCode] = '" + transactionFilter.ItemCode + "' ";
            }
            else if (transactionFilter.InvoiceNo != null)
            {
                query += " AND ut.[InvoiceNo] = '" + transactionFilter.InvoiceNo + "' ";
            }
            else if (transactionFilter.User != null)
            {
                query += " AND 1 = 2 ";
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

        public IEnumerable<TransactionView> GetTransactionViewList(TransactionFilter transactionFilter)
        {
            var transactionViewList = new List<TransactionView>();
            var query = @"SELECT " +
                "ut.[Id], ut.[EndOfDay], " +
                "CASE " +
                "WHEN ut.[MemberId] IS NULL THEN ut.[SupplierId] ELSE ut.[MemberId] END AS [MemberSupplierId], " +
                "[Action], " +
                "CASE " +
                "WHEN ut.[ActionType]='" + Constants.CHEQUE + "' THEN (ut.[ActionType] + ' - ' + ut.[Bank]) " +
                "WHEN ut.[Action] IN ('" + Constants.RECEIPT + "', '" + Constants.EXPENSE + "') AND ut.[IncomeExpense] IS NOT NULL THEN (ut.[ActionType] + ' - ' + ut.[IncomeExpense]) " +
                "WHEN ut.[Action] IN ('" + Constants.RECEIPT + "', '" + Constants.EXPENSE + "') AND ut.[IncomeExpense] IS NULL THEN ut.[ActionType] " +
                "ELSE ut.[ActionType] END AS [ActionType], " +
                "CASE WHEN ut.[MemberId] IS NULL THEN ut.[BillNo] ELSE ut.[InvoiceNo] END AS [InvoiceBillNo], " +
                "i.[Code], i.[Name], si.[Quantity], " +
                "CASE " +
                "WHEN ut.[Action]='" + Constants.SALES + "' THEN ut.[DueAmount] " +
                "ELSE 0.00 END AS [SalesPrice], " +
                "CASE " +
                "WHEN ut.[Action]='" + Constants.PURCHASE + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='" + Constants.PURCHASE + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.SALES + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='" + Constants.SALES + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='" + Constants.TRANSFER + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='" + Constants.TRANSFER + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[DueAmount] " +
                "ELSE ut.[DueAmount] END  AS [Amount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut LEFT JOIN " + Constants.TABLE_SOLD_ITEM + " si " +
                "ON ut.[InvoiceNo] = si.[InvoiceNo] " +
                "AND ISNULL(ut.[IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') " +
                "LEFT JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 ";

            if (transactionFilter.Date != null)
            {
                query += "AND ut.[EndOfDay] = '" + transactionFilter.Date + "' ";
            }

            if (transactionFilter.Service != null)
            {
                query += " AND ut.[Action] IN ('" + Constants.RECEIPT + "', '" + Constants.EXPENSE + "') AND ut.[IncomeExpense] = '" + transactionFilter.Service + "' ";
            }
            else if (transactionFilter.Purchase != null)
            {
                query += " AND ut.[Action] = '" + Constants.PURCHASE + "' AND ut.[ActionType] = '" + transactionFilter.Purchase + "' ";
            }
            else if (transactionFilter.Sales != null)
            {
                query += " AND ut.[Action] = '" + Constants.SALES + "' AND ut.[ActionType] = '" + transactionFilter.Sales + "' ";
            }
            else if (transactionFilter.Receipt != null)
            {
                query += " AND ut.[Action] = '" + Constants.RECEIPT + "' AND ut.[ActionType] = '" + transactionFilter.Receipt + "' ";
            }
            else if (transactionFilter.Payment != null)
            {
                query += " AND ut.[Action] = '" + Constants.PAYMENT + "' AND ut.[ActionType] = '" + transactionFilter.Payment + "' ";
            }
            else if (transactionFilter.Expense != null)
            {
                query += " AND ut.[Action] = '" + Constants.EXPENSE + "' AND ut.[ActionType] = '" + transactionFilter.Expense + "' ";
            }
            else if (transactionFilter.BankTransfer != null)
            {
                query += " AND ut.[Action] = '" + Constants.TRANSFER + "' AND ut.[ActionType] = '" + transactionFilter.BankTransfer + "' ";
            }
            else if (transactionFilter.ItemCode != null)
            {
                query += " AND i.[Code] = '" + transactionFilter.ItemCode + "' ";
            }
            else if (transactionFilter.InvoiceNo != null)
            {
                query += " AND ut.[InvoiceNo] = '" + transactionFilter.InvoiceNo + "' ";
            }
            else if (transactionFilter.User != null)
            {
                query += " AND 1 = 2 ";
            }
            else
            {
                query += " ";
            }

            query += "ORDER BY ut.[EndOfDay] ";
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
                                    InvoiceBillNo = reader.IsDBNull(5) ? string.Empty : reader["InvoiceBillNo"].ToString(),
                                    ItemCode = reader.IsDBNull(6) ? string.Empty : reader["Code"].ToString(),
                                    ItemName = reader.IsDBNull(7) ? string.Empty : reader["Name"].ToString(),
                                    Quantity = reader.IsDBNull(8) ? 0 : Convert.ToInt32(reader["Quantity"].ToString()),
                                    SalesPrice = reader.IsDBNull(9) ? 0.00m : Convert.ToDecimal(reader["SalesPrice"].ToString()),
                                    Amount = reader.IsDBNull(10) ? 0.00m : Convert.ToDecimal(reader["Amount"].ToString())
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
                "[Id], [EndOfDay], [Bank], [IncomeExpense], [ReceivedAmount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] = '" + Constants.RECEIPT + "' ";

            if (!string.IsNullOrEmpty(incomeTransactionFilter?.Income))
            {
                query += "AND [IncomeExpense] = @IncomeExpense ";
            }

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
                        command.Parameters.AddWithValue("@IncomeExpense", ((object)incomeTransactionFilter.Income) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateFrom", ((object)incomeTransactionFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)incomeTransactionFilter.DateTo) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var incomeDetail = new IncomeDetailView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    InvoiceNo = reader["IncomeExpense"].ToString(),
                                    ItemCode = string.Empty,
                                    ItemName = reader["Bank"].ToString(),
                                    ItemBrand = string.Empty,
                                    Quantity = 0,
                                    Profit = 0.00m,
                                    Amount = Convert.ToDecimal(reader["ReceivedAmount"].ToString())
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

        public IEnumerable<IncomeDetailView> GetSalesProfit()
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

            query += "ORDER BY si.[AddedDate] DESC ";

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
                                var incomeDetail = new IncomeDetailView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["ItemName"].ToString(),
                                    ItemBrand = reader["ItemBrand"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
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

        public UserTransaction AddUserTransaction(UserTransaction userTransaction)
        {
            string query = "INSERT INTO " + Constants.TABLE_USER_TRANSACTION + " " +
                    "(" +
                        "[InvoiceNo], [EndOfDay], [BillNo], [MemberId], [SupplierId], [DeliveryPersonId], [Action], [ActionType], [Bank], " +
                        "[IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], " +
                        "[DeliveryCharge], [DueAmount], [ReceivedAmount], [AddedDate], [UpdatedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@InvoiceNo, @EndOfDay, @BillNo, @MemberId, @SupplierId, @DeliveryPersonId, @Action, @ActionType, @Bank, " +
                        "@IncomeExpense, @SubTotal, @DiscountPercent, @Discount, @VatPercent, @Vat, @DeliveryChargePercent, " +
                        "@DeliveryCharge, @DueAmount, @ReceivedAmount, @AddedDate, @UpdatedDate " +
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
                        command.Parameters.AddWithValue("@SupplierId", ((object)userTransaction.SupplierId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryPersonId", ((object)userTransaction.DeliveryPersonId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", userTransaction.Action);
                        command.Parameters.AddWithValue("@ActionType", userTransaction.ActionType);
                        command.Parameters.AddWithValue("@Bank", ((object)userTransaction.Bank) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IncomeExpense", ((object)userTransaction.IncomeExpense) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SubTotal", userTransaction.SubTotal);
                        command.Parameters.AddWithValue("@DiscountPercent", userTransaction.DiscountPercent);
                        command.Parameters.AddWithValue("@Discount", userTransaction.Discount);
                        command.Parameters.AddWithValue("@VatPercent", userTransaction.VatPercent);
                        command.Parameters.AddWithValue("@Vat", userTransaction.Vat);
                        command.Parameters.AddWithValue("@DeliveryChargePercent", userTransaction.DeliveryChargePercent);
                        command.Parameters.AddWithValue("@DeliveryCharge", userTransaction.DeliveryCharge);
                        command.Parameters.AddWithValue("@DueAmount", userTransaction.DueAmount);
                        command.Parameters.AddWithValue("@ReceivedAmount", ((object)userTransaction.ReceivedAmount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", userTransaction.AddedDate);
                        command.Parameters.AddWithValue("@UpdatedDate", userTransaction.UpdatedDate);

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
