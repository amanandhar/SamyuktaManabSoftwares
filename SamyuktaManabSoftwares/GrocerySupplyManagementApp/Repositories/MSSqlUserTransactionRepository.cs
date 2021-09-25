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
                "[Id], [EndOfDay], [InvoiceNo], [BillNo], [MemberId], [ShareMemberId], " +
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
                "[InvoiceNo], [DueAmount], " +
                "CASE WHEN ([DueAmount] <> 0 AND ([ReceivedAmount] - [DueAmount] >= 0)) THEN [DueAmount] ELSE [ReceivedAmount] END AS [ReceivedAmount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
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

        public IEnumerable<MemberTransactionView> GetMemberTransactions(MemberFilter memberFilter)
        {
            var memberTransactionViews = new List<MemberTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Action], " +
                "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[InvoiceNo], [DueAmount], " +
                "CASE WHEN ([DueAmount] <> 0 AND ([ReceivedAmount] - [DueAmount] >= 0)) THEN [DueAmount] ELSE [ReceivedAmount] END AS [ReceivedAmount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') " +
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

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierFilter)
        {
            var supplierTransactionViews = new List<SupplierTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Action], " +
                "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[BillNo], [DueAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.[DueAmount], 0) - ISNULL(b.[ReceivedAmount], 0)) " +
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
                "[IncomeExpense], [Narration], [DueAmount], [ReceivedAmount], " +
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
                                    Narration = reader["Narration"].ToString(),
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

        public decimal GetMemberTotalBalance(UserTransactionFilter userTransactionFilter)
        {
            decimal balance = 0.00m;
            string query = @"SELECT " +
                "SUM(Temp.[Amount]) " +
                "FROM " +
                "( " +
                "SELECT " +
                "CASE WHEN ([DueAmount] <> 0 AND ([ReceivedAmount] - [DueAmount] >= 0)) THEN 0 ELSE ([DueAmount] - [ReceivedAmount]) END AS [Amount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') " +
                "AND [Action] IN ('" + Constants.SALES + "', '" + Constants.RECEIPT + "') ";

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
                "SUM([ReceivedAmount]) - SUM([DueAmount]) " +
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
                "AND [IncomeExpense] = '" + Constants.DELIVERY_CHARGE + "' ";
            
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
                "ISNULL(SUM([DueAmount]), 0) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] IN ('" + Constants.BANK_TRANSFER + "', '" + Constants.EXPENSE + "') " +
                "AND [ActionType] = '" + Constants.CASH + "' " +
                "AND [Id] NOT IN " +
                "( " +
                "SELECT [Id] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [IncomeExpense] = '" + Constants.SALES_DISCOUNT + "' ";

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
            string query;
            if (action?.ToLower() == Constants.SALES.ToLower()
                || action?.ToLower() == Constants.EXPENSE.ToLower()
                || action?.ToLower() == Constants.BANK_TRANSFER.ToLower())
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
                    "WHERE 1 = 1 " +
                    "AND [IncomeExpense] IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.MEMBER_FEE + "', '" + Constants.OTHER_INCOME + "', '" + Constants.SALES_PROFIT + "', '" + Constants.BONUS + "') " +
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
                || action?.ToLower() == Constants.BANK_TRANSFER.ToLower())
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
                    "AND [ActionType] = @ActionType " +
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

        public decimal GetTotalExpense(ExpenseTransactionFilter expenseTransactionFilter)
        {
            decimal balance = 0.00m;
            string query = @"SELECT " +
                    "SUM([DueAmount])" +
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
                query += " AND [IncomeExpense] = @Expense ";
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
                "SUM(ut.[DueAmount]) - SUM(ut.[ReceivedAmount]) AS [Total] " +
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
            else if (dailyTransactionFilter.User != null)
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

        public IEnumerable<TransactionView> GetTransactionViewList(DailyTransactionFilter dailyTransactionFilter)
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
                "WHEN ut.[Action]='" + Constants.SALES + "' THEN si.[Price] " +
                "ELSE 0.00 END AS [SalesPrice], " +
                "CASE " +
                "WHEN ut.[Action]='" + Constants.PURCHASE + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='" + Constants.PURCHASE + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.SALES + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN CAST((si.[Quantity] * si.[Price]) AS DECIMAL(18,2)) " +
                "WHEN ut.[Action]='" + Constants.SALES + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN CAST((si.[Quantity] * si.[Price]) AS DECIMAL(18,2)) " +
                "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.RECEIPT + "' AND ut.[ActionType]='" + Constants.SHARE_CHEQUE + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.PAYMENT + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CREDIT + "' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='" + Constants.EXPENSE + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='" + Constants.BANK_TRANSFER + "' AND ut.[ActionType]='" + Constants.CASH + "' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='" + Constants.BANK_TRANSFER + "' AND ut.[ActionType]='" + Constants.CHEQUE + "' THEN ut.[DueAmount] " +
                "ELSE ut.[DueAmount] END  AS [Amount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut LEFT JOIN " + Constants.TABLE_SOLD_ITEM + " si " +
                "ON ut.[InvoiceNo] = si.[InvoiceNo] " +
                "AND ISNULL(ut.[IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') " +
                "LEFT JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(ut.[IncomeExpense], '') NOT IN ('" + Constants.MEMBER_FEE + "', '" + Constants.OTHER_INCOME + "', '" + Constants.SALES_PROFIT + "') ";

            if (dailyTransactionFilter.Date != null)
            {
                query += "AND ut.[EndOfDay] = '" + dailyTransactionFilter.Date + "' ";
            }

            if (dailyTransactionFilter.Service != null)
            {
                query += " AND ut.[Action] IN ('" + Constants.RECEIPT + "', '" + Constants.EXPENSE + "') AND ut.[IncomeExpense] = '" + dailyTransactionFilter.Service + "' ";
            }
            else if (dailyTransactionFilter.Purchase != null)
            {
                query += " AND ut.[Action] = '" + Constants.PURCHASE + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Purchase + "' ";
            }
            else if (dailyTransactionFilter.Sales != null)
            {
                query += " AND ut.[Action] = '" + Constants.SALES + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Sales + "' ";
            }
            else if (dailyTransactionFilter.Receipt != null)
            {
                query += " AND ut.[Action] = '" + Constants.RECEIPT + "' AND ut.[ActionType] = '" + dailyTransactionFilter.Receipt + "' ";
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
            else if (dailyTransactionFilter.ItemCode != null)
            {
                query += " AND i.[Code] = '" + dailyTransactionFilter.ItemCode + "' ";
            }
            else if (dailyTransactionFilter.InvoiceNo != null)
            {
                query += " AND ut.[InvoiceNo] = '" + dailyTransactionFilter.InvoiceNo + "' ";
            }
            else if (dailyTransactionFilter.User != null)
            {
                query += " AND 1 = 2 ";
            }
            else
            {
                query += " ";
            }

            query += "ORDER BY ut.[AddedDate] DESC";
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
                                    Quantity = reader.IsDBNull(8) ? 0 : Convert.ToDecimal(reader["Quantity"].ToString()),
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
                "AND [Action] = '" + Constants.RECEIPT + "' " +
                "AND [IncomeExpense] IS NOT NULL ";

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
                query += "AND [IncomeExpense] = @IncomeExpense ";
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
                        command.Parameters.AddWithValue("@IncomeExpense", ((object)incomeTransactionFilter.Income) ?? DBNull.Value);

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
                                    Quantity = 0.00m,
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
                "[Id], [EndOfDay], [Bank], [IncomeExpense], [ReceivedAmount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] = '" + Constants.PURCHASE + "' " +
                "AND [IncomeExpense] = '" + Constants.BONUS +"' ";

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
                                    InvoiceNo = reader["IncomeExpense"].ToString(),
                                    ItemCode = string.Empty,
                                    ItemName = reader["Bank"].ToString(),
                                    ItemBrand = string.Empty,
                                    Quantity = 0.00m,
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

        public UserTransaction AddUserTransaction(UserTransaction userTransaction)
        {
            string query = "INSERT INTO " + Constants.TABLE_USER_TRANSACTION + " " +
                    "(" +
                        "[InvoiceNo], [EndOfDay], [BillNo], [MemberId], [ShareMemberId], [SupplierId], [DeliveryPersonId], [Action], [ActionType], [Bank], " +
                        "[IncomeExpense], [Narration], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], " +
                        "[DeliveryCharge], [DueAmount], [ReceivedAmount], [AddedDate], [UpdatedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@InvoiceNo, @EndOfDay, @BillNo, @MemberId, @ShareMemberId, @SupplierId, @DeliveryPersonId, @Action, @ActionType, @Bank, " +
                        "@IncomeExpense, @Narration, @SubTotal, @DiscountPercent, @Discount, @VatPercent, @Vat, @DeliveryChargePercent, " +
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
                        command.Parameters.AddWithValue("@ShareMemberId", ((object)userTransaction.ShareMemberId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SupplierId", ((object)userTransaction.SupplierId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryPersonId", ((object)userTransaction.DeliveryPersonId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", userTransaction.Action);
                        command.Parameters.AddWithValue("@ActionType", userTransaction.ActionType);
                        command.Parameters.AddWithValue("@Bank", ((object)userTransaction.Bank) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IncomeExpense", ((object)userTransaction.IncomeExpense) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Narration", ((object)userTransaction.Narration) ?? DBNull.Value);
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
