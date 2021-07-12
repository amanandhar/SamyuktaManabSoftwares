using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
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

        public IEnumerable<UserTransaction> GetPosTransactions()
        {
            var posTransactions = new List<UserTransaction>();
            var query = @"SELECT " +
                "[Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], " +
                "[SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], " + 
                "[Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[TotalAmount], [ReceivedAmount], [Date] " +
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
                                var posTransaction = new UserTransaction
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString()),
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
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
                                };

                                posTransactions.Add(posTransaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posTransactions;
        }

        public IEnumerable<UserTransaction> GetPosTransactions(string memberId)
        {
            var posTransactions = new List<UserTransaction>();
            var query = @"SELECT " +
                "[Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], " +
                "[SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], " + 
                "[Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[TotalAmount], [ReceivedAmount], [Date] " +
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
                                var posTransaction = new UserTransaction
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString()),
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
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
                                };

                                posTransactions.Add(posTransaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posTransactions;
        }

        public IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId)
        {
            var memberTransactionViews = new List<MemberTransactionView>();
            var query = @"SELECT " +
                "[Id], [InvoiceDate], [Action], " +
                "CASE WHEN [ActionType] = 'Cheque' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[InvoiceNo], [TotalAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.TotalAmount,0) - ISNULL(b.ReceivedAmount,0)) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " b " +
                "WHERE b.Date <= a.Date AND MemberId = @MemberId) AS Balance " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " a " +
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
                                var memberTransactionView = new MemberTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString()),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
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
                "[Id], [InvoiceDate], [Action], " +
                "CASE WHEN [ActionType] = 'Cheque' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[BillNo], [TotalAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.TotalAmount,0) - ISNULL(b.ReceivedAmount,0)) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " b " +
                "WHERE b.Date <= a.Date AND SupplierId = @SupplierId) AS Balance " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " a " +
                "WHERE 1 = 1 " +
                "AND SupplierId = @SupplierId " + 
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
                                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString()),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    BillNo = reader["BillNo"].ToString(),
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
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
                "[Id], [InvoiceDate], [Action], " +
                "CASE WHEN [ActionType] = 'Cheque' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[IncomeExpense], [TotalAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.TotalAmount, 0) - ISNULL(b.ReceivedAmount, 0)) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " b " +
                "WHERE b.Date <= a.Date AND [Action] = 'Expense') AS Balance " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " a " +
                "WHERE 1 = 1 " +
                "AND [Action] = 'Expense' ";

            if(filter != null)
            {
                if (filter?.DateFrom != DateTime.MinValue && filter?.DateTo != DateTime.MinValue)
                {
                    query += " AND [InvoiceDate] BETWEEN " + filter.DateFrom + " AND " + filter.DateTo + " ";
                }

                if (filter?.Expense != null)
                {
                    query += " AND [IncomeExpense] = '" + filter.Expense + "' ";
                }
            }

            query += "ORDER BY Id ";

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
                                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString()),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    Expense = reader["IncomeExpense"].ToString(),
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
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

        public UserTransaction GetPosTransaction(long posTransactionId)
        {
            throw new NotImplementedException();
        }

        public UserTransaction GetPosTransaction(string invoiceNo)
        {
            var posTransaction = new UserTransaction();
            var query = @"SELECT " +
                "[Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[TotalAmount], [ReceivedAmount], [Date] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND InvoiceNo = @InvoiceNo ";

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
                                posTransaction.Id = Convert.ToInt64(reader["Id"].ToString());
                                posTransaction.InvoiceNo = reader["InvoiceNo"].ToString();
                                posTransaction.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                                posTransaction.BillNo = reader["BillNo"].ToString();
                                posTransaction.MemberId = reader["MemberId"].ToString();
                                posTransaction.SupplierId = reader["SupplierId"].ToString();
                                posTransaction.Action = reader["Action"].ToString();
                                posTransaction.ActionType = reader["ActionType"].ToString();
                                posTransaction.Bank = reader["Bank"].ToString();
                                posTransaction.SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString());
                                posTransaction.DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString());
                                posTransaction.Discount = Convert.ToDecimal(reader["Discount"].ToString());
                                posTransaction.VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString());
                                posTransaction.Vat = Convert.ToDecimal(reader["Vat"].ToString());
                                posTransaction.DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString());
                                posTransaction.DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString());
                                posTransaction.TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString());
                                posTransaction.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                posTransaction.Date = Convert.ToDateTime(reader["Date"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posTransaction;
        }
        
        public UserTransaction GetLastPosTransaction(string option)
        {
            var posTransaction = new UserTransaction();
            var query = @"SELECT " +
                "TOP 1 " +
                "[Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[TotalAmount], [ReceivedAmount], [Date] " +
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
                                posTransaction.Id = Convert.ToInt64(reader["Id"].ToString());
                                posTransaction.InvoiceNo = reader["InvoiceNo"].ToString();
                                posTransaction.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                                posTransaction.BillNo = reader["BillNo"].ToString();
                                posTransaction.MemberId = reader["MemberId"].ToString();
                                posTransaction.SupplierId = reader["SupplierId"].ToString();
                                posTransaction.Action = reader["Action"].ToString();
                                posTransaction.ActionType = reader["ActionType"].ToString();
                                posTransaction.Bank = reader["Bank"].ToString();
                                posTransaction.SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString());
                                posTransaction.DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString());
                                posTransaction.Discount = Convert.ToDecimal(reader["Discount"].ToString());
                                posTransaction.VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString());
                                posTransaction.Vat = Convert.ToDecimal(reader["Vat"].ToString());
                                posTransaction.DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString());
                                posTransaction.DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString());
                                posTransaction.TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString());
                                posTransaction.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                posTransaction.Date = Convert.ToDateTime(reader["Date"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posTransaction;
        }

        public UserTransaction AddPosTransaction(UserTransaction posTransaction)
        {
            string query = "INSERT INTO " + Constants.TABLE_USER_TRANSACTION + " " +
                    "(" +
                        "[InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], " +
                        "[IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], " +
                        "[DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@InvoiceNo, @InvoiceDate, @BillNo, @MemberId, @SupplierId, @Action, @ActionType, @Bank, " +
                        "@IncomeExpense, @SubTotal, @DiscountPercent, @Discount, @VatPercent, @Vat, @DeliveryChargePercent, " +
                        "@DeliveryCharge, @TotalAmount, @ReceivedAmount, @Date " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)posTransaction.InvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@InvoiceDate", posTransaction.InvoiceDate);
                        command.Parameters.AddWithValue("@BillNo", ((object)posTransaction.BillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MemberId", ((object)posTransaction.MemberId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SupplierId", ((object)posTransaction.SupplierId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", posTransaction.Action);
                        command.Parameters.AddWithValue("@ActionType", posTransaction.ActionType);
                        command.Parameters.AddWithValue("@Bank", ((object)posTransaction.Bank) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IncomeExpense", ((object)posTransaction.IncomeExpense) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SubTotal", posTransaction.SubTotal);
                        command.Parameters.AddWithValue("@DiscountPercent", posTransaction.DiscountPercent);
                        command.Parameters.AddWithValue("@Discount", posTransaction.Discount);
                        command.Parameters.AddWithValue("@VatPercent", posTransaction.VatPercent);
                        command.Parameters.AddWithValue("@Vat", posTransaction.Vat);
                        command.Parameters.AddWithValue("@DeliveryChargePercent", posTransaction.DeliveryChargePercent);
                        command.Parameters.AddWithValue("@DeliveryCharge", posTransaction.DeliveryCharge);
                        command.Parameters.AddWithValue("@TotalAmount", posTransaction.TotalAmount);
                        command.Parameters.AddWithValue("@ReceivedAmount", ((object)posTransaction.ReceivedAmount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Date", posTransaction.Date);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posTransaction;
        }

        public UserTransaction UpdatePosTransaction(long posTransactionId, UserTransaction posTransaction)
        {
            throw new NotImplementedException();
        }

        public bool DeletePosTransaction(long posTransactionId, UserTransaction posTransaction)
        {
            throw new NotImplementedException();
        }

        public string GetLastInvoiceNo()
        {
            string query = @"SELECT " +
                "TOP 1 [InvoiceNo] " + 
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [InvoiceNo] LIKE 'IN%' " +
                "ORDER BY Id DESC ";
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
                "SUM([TotalAmount]) - SUM([ReceivedAmount]) " +
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
                "SUM([TotalAmount]) - SUM([ReceivedAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND MemberId = @MemberId ";
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
                "SUM([ReceivedAmount]) - SUM([TotalAmount]) " +
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
                "SUM([ReceivedAmount]) - SUM([TotalAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND SupplierId = @SupplierId ";
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
                "AND Action IN ('Sales', 'Receipt') " +
                "AND ActionType = 'Cash' " +
                ") " +
                "- " +
                "( " +
                "SELECT " +
                "ISNULL(SUM([TotalAmount]), 0) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND Action IN ('Transfer', 'Expense') " +
                "AND ActionType = 'Cash' " +
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
                    "SUM([TotalAmount])" +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND Action = @Action " +
                    "AND ActionType = @ActionType ";
            }
            else
            {
                query = @"SELECT " +
                    "SUM([ReceivedAmount])" +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND Action = @Action " +
                    "AND ActionType = @ActionType ";
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
                    "SUM([TotalAmount])" +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND Action = 'Expense' " +
                    "AND IncomeExpense = @Expense ";
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
