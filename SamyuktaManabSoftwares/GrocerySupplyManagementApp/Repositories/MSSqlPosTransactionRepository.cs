using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlPosTransactionRepository : IPosTransactionRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";
        private const string TABLE_NAME = "PosTransaction";
        
        public IEnumerable<PosTransaction> GetPosTransactions()
        {
            var posTransactions = new List<PosTransaction>();
            string connectionString = GetConnectionString();
            var query = @"SELECT " +
                "[Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [Expense], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[TotalAmount], [ReceivedAmount], [Date] " +
                "FROM " + TABLE_NAME + " ORDER BY Id";
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
                                var posTransaction = new PosTransaction
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
                                    Expense = reader["Expense"].ToString(),
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

        public IEnumerable<PosTransaction> GetPosTransactions(string memberId)
        {
            var posTransactions = new List<PosTransaction>();
            string connectionString = GetConnectionString();
            var query = @"SELECT " +
                "[Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [Expense], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], " +
                "[DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date] " +
                "FROM " + TABLE_NAME + " " + 
                "WHERE MemberId = @MemberId " +
                "ORDER BY Id";
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
                                var posTransaction = new PosTransaction
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
                                    Expense = reader["Expense"].ToString(),
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
            string connectionString = GetConnectionString();
            var query = @"SELECT " +
                "[Id], [InvoiceDate], [Action], " +
                "CASE WHEN [ActionType] = 'Cheque' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[InvoiceNo], [TotalAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.TotalAmount,0) - ISNULL(b.ReceivedAmount,0)) " +
                "FROM [dbo].[PosTransaction] b " +
                "WHERE b.Date <= a.Date AND MemberId = @MemberId) AS Balance " +
                "FROM " + TABLE_NAME + " a " +
                "WHERE MemberId = @MemberId ORDER BY Id";
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
            string connectionString = GetConnectionString();
            var query = @"SELECT " +
                "[Id], [InvoiceDate], [Action], " +
                "CASE WHEN [ActionType] = 'Cheque' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[BillNo], [TotalAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.TotalAmount,0) - ISNULL(b.ReceivedAmount,0)) " +
                "FROM [dbo].[PosTransaction] b " +
                "WHERE b.Date <= a.Date AND SupplierId = @SupplierId) AS Balance " +
                "FROM " + TABLE_NAME + " a " +
                "WHERE SupplierId = @SupplierId ORDER BY Id";
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
            string connectionString = GetConnectionString();
            var query = @"SELECT " +
                "[Id], [InvoiceDate], [Action], " +
                "CASE WHEN [ActionType] = 'Cheque' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                "[Expense], [TotalAmount], [ReceivedAmount], " +
                "(SELECT SUM(ISNULL(b.TotalAmount,0) - ISNULL(b.ReceivedAmount,0)) " +
                "FROM [dbo].[PosTransaction] b " +
                "WHERE b.Date <= a.Date AND [Action] = 'Expense') AS Balance " +
                "FROM " + TABLE_NAME + " a " +
                "WHERE 1=1 " +
                "AND [Action] = 'Expense' ";

            if(filter != null)
            {
                if (filter?.DateFrom != DateTime.MinValue && filter?.DateTo != DateTime.MinValue)
                {
                    query += " AND [InvoiceDate] BETWEEN " + filter.DateFrom + " AND " + filter.DateTo + " ";
                }

                if (filter?.Expense != null)
                {
                    query += " AND [Expense] = '" + filter.Expense + "' ";
                }
            }

            query += "ORDER BY Id";

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
                                    Expense = reader["Expense"].ToString(),
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

        public PosTransaction GetPosTransaction(long posTransactionId)
        {
            throw new NotImplementedException();
        }

        public PosTransaction GetPosTransaction(string invoiceNo)
        {
            var posTransaction = new PosTransaction();
            string connectionString = GetConnectionString();
            var query = @"SELECT " +
                "[Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[TotalAmount], [ReceivedAmount], [Date] " +
                "FROM " + TABLE_NAME + " " + 
                "WHERE InvoiceNo = @InvoiceNo";
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
        
        public PosTransaction GetLastPosTransaction(string option)
        {
            var posTransaction = new PosTransaction();
            string connectionString = GetConnectionString();
            var query = @"SELECT " +
                "TOP 1 " +
                "[Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], " +
                "[SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], " +
                "[TotalAmount], [ReceivedAmount], [Date] " +
                "FROM " + TABLE_NAME + " ";
            if(!string.IsNullOrWhiteSpace(option))
            {
                if(option.StartsWith("IN"))
                {
                    query += "WHERE ([InvoiceNo] IS NOT NULL AND DATALENGTH([InvoiceNo]) > 0) ";
                }
                else if(option.StartsWith("BN"))
                {
                    query += "WHERE ([BillNo] IS NOT NULL AND DATALENGTH([BillNo]) > 0) ";
                }
            }
            
            query += "ORDER BY [Id] DESC";
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

        public PosTransaction AddPosTransaction(PosTransaction posTransaction)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO " + TABLE_NAME + " " +
                            "(" +
                                "[InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], " +
                                "[Expense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], " +
                                "[DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@InvoiceNo, @InvoiceDate, @BillNo, @MemberId, @SupplierId, @Action, @ActionType, @Bank, " +
                                "@Expense, @SubTotal, @DiscountPercent, @Discount, @VatPercent, @Vat, @DeliveryChargePercent, " +
                                "@DeliveryCharge, @TotalAmount, @ReceivedAmount, @Date " +
                            ")";
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
                        command.Parameters.AddWithValue("@Expense", ((object)posTransaction.Expense) ?? DBNull.Value);
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

        public PosTransaction UpdatePosTransaction(long posTransactionId, PosTransaction posTransaction)
        {
            throw new NotImplementedException();
        }

        public bool DeletePosTransaction(long posTransactionId, PosTransaction posTransaction)
        {
            throw new NotImplementedException();
        }

        public string GetLastInvoiceNo()
        {
            string connectionString = GetConnectionString();
            string query = "SELECT " +
                "TOP 1 [InvoiceNo] " + 
                "FROM " + TABLE_NAME + " " +
                "WHERE [InvoiceNo] LIKE 'IN%' " +
                "ORDER BY Id DESC";
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

        public decimal GetMemberTotalBalance(string memberId)
        {
            string connectionString = GetConnectionString();
            string query = "SELECT " +
                "SUM([TotalAmount]) - SUM([ReceivedAmount]) " +
                "FROM " + TABLE_NAME + " " +
                "WHERE MemberId = @MemberId ";
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

        public decimal GetSupplierTotalBalance(string supplierId)
        {
            string connectionString = GetConnectionString();
            string query = "SELECT " +
                "SUM([ReceivedAmount]) - SUM([TotalAmount]) " +
                "FROM " + TABLE_NAME + " " +
                "WHERE SupplierId = @SupplierId ";
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
            string connectionString = GetConnectionString();
            string query = "SELECT " +
                "( " +
                "SELECT " +
                "ISNULL(SUM([ReceivedAmount]),0) " +
                "FROM " + TABLE_NAME + " " +
                "WHERE 1=1 " +
                "AND Action IN ('Sales', 'Receipt') " +
                "AND ActionType = 'Cash' " +
                ") " +
                "- " +
                "( " +
                "SELECT " +
                "ISNULL(SUM([TotalAmount]),0) " +
                "FROM " + TABLE_NAME + " " +
                "WHERE 1=1 " +
                "AND Action IN ('Transfer') " +
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
            string connectionString = GetConnectionString();
            string query;
            if (action?.ToLower() == Constants.SALES.ToLower())
            {
                query = "SELECT " +
                "SUM([TotalAmount])" +
                "FROM " + TABLE_NAME + " " +
                "WHERE 1=1 " +
                "AND Action = @Action " +
                "AND ActionType = @ActionType ";
            }
            else
            {
                query = "SELECT " +
                    "SUM([ReceivedAmount])" +
                    "FROM " + TABLE_NAME + " " +
                    "WHERE 1=1 " +
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

        private string GetConnectionString()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ConnectionString;
                return connectionString;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
