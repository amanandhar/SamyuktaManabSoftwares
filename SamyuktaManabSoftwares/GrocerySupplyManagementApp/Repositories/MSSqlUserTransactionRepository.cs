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
                "[Id], [EndOfDate], [InvoiceNo], [BillNo], [MemberId], " +
                "[SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], " + 
                "[Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[DueAmount], [ReceivedAmount], [Date] " +
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
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    BillNo = reader["BillNo"].ToString(),
                                    MemberId = reader["MemberId"].ToString(),
                                    SupplierId = reader["SupplierId"].ToString(),
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
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
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
                "[Id], [EndOfDate], [InvoiceNo], [BillNo], [MemberId], " +
                "[SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], " + 
                "[Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[DueAmount], [ReceivedAmount], [Date] " +
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
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    BillNo = reader["BillNo"].ToString(),
                                    MemberId = reader["MemberId"].ToString(),
                                    SupplierId = reader["SupplierId"].ToString(),
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
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
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
                "[Id], [EndOfDate], [Action], " +
                "CASE WHEN [ActionType] = 'Cheque' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[InvoiceNo], [DueAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.[DueAmount],0) - ISNULL(b.[ReceivedAmount],0)) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " b " +
                "WHERE b.[Date] <= a.[Date] AND [MemberId] = @MemberId) AS Balance " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " a " +
                "WHERE 1 = 1 " +
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
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()),
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
                "[Id], [EndOfDate], [Action], " +
                "CASE WHEN [ActionType] = 'Cheque' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[BillNo], [DueAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.[DueAmount], 0) - ISNULL(b.[ReceivedAmount], 0)) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " b " +
                "WHERE b.[Date] <= a.[Date] AND [SupplierId] = @SupplierId) AS Balance " +
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
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()),
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

        public IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter filter)
        {
            var expenseTransactionViews = new List<ExpenseTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDate], [Action], " +
                "CASE WHEN [ActionType] = 'Cheque' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[IncomeExpense], [DueAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.[DueAmount], 0) - ISNULL(b.[ReceivedAmount], 0)) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " b " +
                "WHERE b.[Date] <= a.[Date] AND [Action] = 'Expense') AS Balance " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " a " +
                "WHERE 1 = 1 " +
                "AND [Action] = 'Expense' ";

            if(filter != null)
            {
                if (filter?.DateFrom != DateTime.MinValue && filter?.DateTo != DateTime.MinValue)
                {
                    query += " AND [EndOfDate] BETWEEN " + filter.DateFrom + " AND " + filter.DateTo + " ";
                }

                if (filter?.Expense != null)
                {
                    query += " AND [IncomeExpense] = '" + filter.Expense + "' ";
                }
            }

            query += "ORDER BY [Id] ";

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
                                var expenseTransactionView = new ExpenseTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    Expense = reader["IncomeExpense"].ToString(),
                                    DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    Balance = Convert.ToDecimal(reader["Balance"].ToString())
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
            throw new NotImplementedException();
        }

        public UserTransaction GetUserTransaction(string invoiceNo)
        {
            var userTransaction = new UserTransaction();
            var query = @"SELECT " +
                "[Id], [InvoiceNo], [EndOfDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[DueAmount], [ReceivedAmount], [Date] " +
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

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                userTransaction.Id = Convert.ToInt64(reader["Id"].ToString());
                                userTransaction.EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString());
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
                                userTransaction.Date = Convert.ToDateTime(reader["Date"].ToString());
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
                "[Id], [EndOfDate], [InvoiceNo], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[DueAmount], [ReceivedAmount], [Date] " +
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
                                userTransaction.EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString());
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
                                userTransaction.Date = Convert.ToDateTime(reader["Date"].ToString());
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

        public UserTransaction AddUserTransaction(UserTransaction userTransaction)
        {
            string query = "INSERT INTO " + Constants.TABLE_USER_TRANSACTION + " " +
                    "(" +
                        "[InvoiceNo], [EndOfDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], " +
                        "[IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], " +
                        "[DeliveryCharge], [DueAmount], [ReceivedAmount], [Date] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@InvoiceNo, @EndOfDate, @BillNo, @MemberId, @SupplierId, @Action, @ActionType, @Bank, " +
                        "@IncomeExpense, @SubTotal, @DiscountPercent, @Discount, @VatPercent, @Vat, @DeliveryChargePercent, " +
                        "@DeliveryCharge, @DueAmount, @ReceivedAmount, @Date " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDate", userTransaction.EndOfDate);
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)userTransaction.InvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BillNo", ((object)userTransaction.BillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MemberId", ((object)userTransaction.MemberId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SupplierId", ((object)userTransaction.SupplierId) ?? DBNull.Value);
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
                        command.Parameters.AddWithValue("@Date", userTransaction.Date);

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

        public string GetLastInvoiceNo()
        {
            string query = @"SELECT " +
                "TOP 1 [InvoiceNo] " + 
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [InvoiceNo] LIKE 'IN%' " +
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
            decimal balance = 0.0m;
            string query = @"SELECT " +
                "SUM([DueAmount]) - SUM([ReceivedAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [MemberId] IS NOT NULL ";
           
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
            string query = @"SELECT " +
                "SUM([DueAmount]) - SUM([ReceivedAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [MemberId] = @MemberId ";
            decimal balance = 0.0m;
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
            decimal balance = 0.0m;
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
            string query = @"SELECT " +
                "SUM([ReceivedAmount]) - SUM([DueAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [SupplierId] = @SupplierId ";
            decimal balance = 0.0m;
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
            string query = @"SELECT " +
                "( " +
                "SELECT " +
                "ISNULL(SUM([ReceivedAmount]), 0) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] IN ('" + Constants.SALES + "', '" + Constants.RECEIPT + "') " +
                "AND [ActionType] = '" + Constants.CASH + "' " +
                ") " +
                "- " +
                "( " +
                "SELECT " +
                "ISNULL(SUM([DueAmount]), 0) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] IN ('" + Constants.TRANSFER + "', '" + Constants.EXPENSE + "') " +
                "AND [ActionType] = '" + Constants.CASH + "' " +
                ") ";

            decimal cashInHand = 0.0m;

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

        public decimal GetTotalBalance(string action, string actionType)
        {
            string query;
            if (action?.ToLower() == Constants.SALES.ToLower() 
                || action?.ToLower() == Constants.EXPENSE.ToLower()
                || action?.ToLower() == Constants.TRANSFER.ToLower())
            {
                query = @"SELECT " +
                    "SUM([DueAmount])" +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [Action] = @Action " +
                    "AND [ActionType] = @ActionType ";
            }
            else
            {
                query = @"SELECT " +
                    "SUM([ReceivedAmount])" +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [Action] = @Action " +
                    "AND [ActionType] = @ActionType ";
            }

            decimal balance = 0.0m;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
            decimal total = 0.0m;
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
                            total = Convert.ToDecimal(result.ToString());
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
    }
}
