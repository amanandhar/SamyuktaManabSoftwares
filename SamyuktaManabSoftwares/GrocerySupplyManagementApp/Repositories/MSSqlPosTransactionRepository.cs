using GrocerySupplyManagementApp.Entities;
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

        public MSSqlPosTransactionRepository()
        {

        }
        
        public IEnumerable<PosTransaction> GetPosTransactions()
        {
            var posTransactions = new List<PosTransaction>();
            string connectionString = GetConnectionString();
            var query = @"SELECT * FROM " + TABLE_NAME + " ORDER BY Id";
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
                                    Id = Convert.ToInt64(reader["InvoiceDate"].ToString()),
                                    InvoiceNo = reader["ItemId"].ToString(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["Unit"].ToString(),
                                    ItemBrand = reader["ItemBrand"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString())
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

        public PosTransaction GetPosTransaction(long posTransactionId)
        {
            throw new System.NotImplementedException();
        }

        public PosTransaction AddPosTransaction(PosTransaction posTransaction)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO " + TABLE_NAME +
                            " (" +
                                " [InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity] " +
                            " ) " +
                            " VALUES" +
                            " (" +
                                " @InvoiceNo, @ItemCode, @ItemName, @ItemBrand, @Unit, @Price, @Quantity " +
                            " )";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", posTransaction.InvoiceNo);
                        command.Parameters.AddWithValue("@ItemCode", posTransaction.ItemCode);
                        command.Parameters.AddWithValue("@ItemName", posTransaction.ItemName);
                        command.Parameters.AddWithValue("@ItemBrand", posTransaction.ItemBrand);
                        command.Parameters.AddWithValue("@Unit", posTransaction.Unit);
                        command.Parameters.AddWithValue("@Price", posTransaction.Price);
                        command.Parameters.AddWithValue("@Quantity", posTransaction.Quantity);

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

        public PosTransaction UpdatePosTransaction(long posITransactionId, PosTransaction posTransaction)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePosTransaction(long posTransactionId, PosTransaction posTransaction)
        {
            throw new System.NotImplementedException();
        }
        
        public IEnumerable<PosTransactionGrid> GetPosTransactionGrid(string invoiceNo)
        {
            var posTransactionGrids = new List<PosTransactionGrid>();
            string connectionString = GetConnectionString();
            var query = @"SELECT a.Id, a.ItemCode, a.ItemName, a.ItemBrand, a.Unit, a.Price, a.Quantity, CAST((a.Price * a.Quantity) AS DECIMAL(18,2)) AS Total, b.Date" +
                " FROM PosTransaction a INNER JOIN PosInvoice b ON a.InvoiceNo = b.InvoiceNo" +
                " WHERE 1=1" +
                " AND a.InvoiceNo = @InvoiceNo" +
                " ORDER BY 1";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", invoiceNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var posTransactionGrid = new PosTransactionGrid
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["ItemName"].ToString(),
                                    ItemBrand = reader["ItemBrand"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    ItemPrice = Convert.ToDecimal(reader["Price"].ToString()),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    Total = Convert.ToDecimal(reader["Total"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
                                };

                                posTransactionGrids.Add(posTransactionGrid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posTransactionGrids;
        }

        private string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }
    }
}
