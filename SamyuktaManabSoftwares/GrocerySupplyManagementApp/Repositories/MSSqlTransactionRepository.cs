using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlTransactionRepository : ITransactionRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";
        public IEnumerable<TransactionGrid> GetTransactionGrids(TransactionFilter transactionFilter)
        {
            var transactionGrids = new List<TransactionGrid>();
            string connectionString = GetConnectionString();
            var query = @"SELECT [InvoiceDate], [MemberId], [PaymentType], pi.[InvoiceNo], [ItemCode], [ItemName], " +
                " [ItemBrand], [Unit], [Quantity], [Price] AS [ItemPrice], CASE WHEN (pi.[InvoiceNo] LIKE 'IN%') " + 
                " THEN CAST(([Quantity] * [Price]) AS DECIMAL(18,2))" +
                " ELSE pi.[ReceivedAmount] END  AS [Amount] " + 
                " FROM [PosInvoice] pi LEFT JOIN [PosTransaction] pt " +
                " ON pi.InvoiceNo = pt.InvoiceNo WHERE 1=1";
            if (transactionFilter.Date != null)
            {
                query += " AND pi.[InvoiceDate] = '" + transactionFilter.Date + "' " ;
            }

            if (transactionFilter.Sale != null)
            {
                query += " AND pi.[PaymentType] = '" + transactionFilter.Sale + "' ";
            }

            if (transactionFilter.ItemCode != null)
            {
                query += " AND [ItemCode] = '" + transactionFilter.ItemCode + "' ";
            }
            else if (transactionFilter.InvoiceNo != null)
            {
                query += " AND pi.[InvoiceNo] = '" + transactionFilter.InvoiceNo + "' ";
            }

            query += " ORDER BY [DATE]";
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
                                var transactionGrid = new TransactionGrid
                                {
                                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString()),
                                    MemberId = reader.IsDBNull(1) ? string.Empty : reader["MemberId"].ToString(),
                                    Descriptions = reader.IsDBNull(2) ? string.Empty : reader["PaymentType"].ToString(),
                                    InvoiceNo = reader.IsDBNull(3) ? string.Empty : reader["InvoiceNo"].ToString(),
                                    ItemCode = reader.IsDBNull(4) ? string.Empty : reader["ItemCode"].ToString(),
                                    ItemName = reader.IsDBNull(5) ? string.Empty : reader["ItemName"].ToString(),
                                    ItemBrand = reader.IsDBNull(6) ? string.Empty : reader["ItemBrand"].ToString(),
                                    Unit = reader.IsDBNull(7) ? string.Empty : reader["Unit"].ToString(),
                                    Quantity = reader.IsDBNull(8) ? 0.0m : Convert.ToDecimal(reader["Quantity"].ToString()),
                                    ItemPrice = reader.IsDBNull(9) ? 0.0m : Convert.ToDecimal(reader["ItemPrice"].ToString()),
                                    Amount = reader.IsDBNull(10) ? 0.0m : Convert.ToDecimal(reader["Amount"].ToString())
                                };

                                transactionGrids.Add(transactionGrid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return transactionGrids;
        }

        public decimal GetSumTransactionGrids(TransactionFilter transactionFilter)
        {
            decimal total = 0.0m;
            string connectionString = GetConnectionString();
            var query = @"SELECT SUM(CAST(([Quantity] * [Price]) AS DECIMAL(18,2))) AS [TOTAL] " +
                " FROM [PosInvoice] pi INNER JOIN [PosTransaction] pt " +
                " ON pi.InvoiceNo = pt.InvoiceNo WHERE 1=1";
            if (transactionFilter.Date != null)
            {
                query += " AND pi.[InvoiceDate] = '" + transactionFilter.Date + "' ";
            }

            if (transactionFilter.Sale != null)
            {
                query += " AND pi.[PaymentType] = '" + transactionFilter.Sale + "' ";
            }

            if (transactionFilter.ItemCode != null)
            {
                query += " AND [ItemCode] = '" + transactionFilter.ItemCode + "' ";
            }
            else if (transactionFilter.InvoiceNo != null)
            {
                query += " AND pi.[InvoiceNo] = '" + transactionFilter.InvoiceNo + "' ";
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

        public IEnumerable<string> GetMemberIds()
        {
            var memberIds = new List<string>();
            string connectionString = GetConnectionString();
            var query = @"SELECT DISTINCT [MemberId] " +
                " FROM [PosInvoice] " +
                " WHERE 1=1 " + 
                " ORDER BY [MemberId]";
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
        public IEnumerable<string> GetSalesItems()
        {
            var itemCodes = new List<string>();
            string connectionString = GetConnectionString();
            var query = @"SELECT DISTINCT [ItemCode] " +
                " FROM [PosTransaction] " +
                " WHERE 1=1 " +
                " ORDER BY [ItemCode]";
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
                                var itemCode = reader["ItemCode"].ToString();

                                itemCodes.Add(itemCode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return itemCodes;
        }

        public IEnumerable<string> GetInvoices()
        {
            var invoices = new List<string>();
            string connectionString = GetConnectionString();
            var query = @"SELECT DISTINCT [InvoiceNo] " +
                " FROM [PosInvoice] " +
                " WHERE 1=1 " +
                " ORDER BY [InvoiceNo]";
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

        public bool DeleteTransactionGrids(string invoiceNo)
        {
            string connectionString = GetConnectionString();
            bool result = false;
            string query = "" +
                "DELETE FROM PosInvoice WHERE InvoiceNo = @InvoiceNo; " +
                " " +
                "DELETE FROM PosTransaction WHERE InvoiceNo = @InvoiceNo; ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
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


        private string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }
    }
}
