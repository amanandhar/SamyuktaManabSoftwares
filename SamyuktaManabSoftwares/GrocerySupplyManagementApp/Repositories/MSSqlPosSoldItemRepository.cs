using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlPosSoldItemRepository : IPosSoldItemRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";
        private const string TABLE_NAME = "PosSoldItem";
        
        public IEnumerable<PosSoldItem> GetPosSoldItems()
        {
            var posSoldItems = new List<PosSoldItem>();
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
                                var posSoldItem = new PosSoldItem
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

                                posSoldItems.Add(posSoldItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posSoldItems;
        }

        public PosSoldItem GetPosSoldItem(long posSoldItemId)
        {
            throw new System.NotImplementedException();
        }

        public PosSoldItem AddPosSoldItem(PosSoldItem posSoldItem)
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
                        command.Parameters.AddWithValue("@InvoiceNo", posSoldItem.InvoiceNo);
                        command.Parameters.AddWithValue("@ItemCode", posSoldItem.ItemCode);
                        command.Parameters.AddWithValue("@ItemName", posSoldItem.ItemName);
                        command.Parameters.AddWithValue("@ItemBrand", posSoldItem.ItemBrand);
                        command.Parameters.AddWithValue("@Unit", posSoldItem.Unit);
                        command.Parameters.AddWithValue("@Price", posSoldItem.Price);
                        command.Parameters.AddWithValue("@Quantity", posSoldItem.Quantity);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posSoldItem;
        }

        public PosSoldItem UpdatePosSoldItem(long posSoldItemId, PosSoldItem posSoldItem)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePosSoldItem(long posSoldItemId, PosSoldItem posSoldItem)
        {
            throw new System.NotImplementedException();
        }
        
        public IEnumerable<PosSoldItemGrid> GetPosSoldItemGrid(string invoiceNo)
        {
            var posSoldItemGrids = new List<PosSoldItemGrid>();
            string connectionString = GetConnectionString();
            var query = @"SELECT a.Id, a.ItemCode, a.ItemName, a.ItemBrand, a.Unit, a.Price, a.Quantity, CAST((a.Price * a.Quantity) AS DECIMAL(18,2)) AS Total, b.Date" +
                " FROM PosSoldItem a INNER JOIN PosTransaction b ON a.InvoiceNo = b.InvoiceNo" +
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
                                var posSoldItemGrid = new PosSoldItemGrid
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

                                posSoldItemGrids.Add(posSoldItemGrid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posSoldItemGrids;
        }

        private string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }
    }
}
