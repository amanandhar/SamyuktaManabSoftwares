using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlItemRepository : IItemRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";

        public MSSqlItemRepository()
        {

        }

        /// <summary>
        /// Returns list of items
        /// </summary>
        /// <returns>List of Items</returns>
        public IEnumerable<Item> GetItems()
        {
            var items = new List<Item>();
            string connectionString = GetConnectionString();
            var query = @"SELECT SupplierName, Code, Name, Brand, Unit, Quantity, PurchasePrice, PurchaseDate, BillNo, SellPrice FROM Item";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Item
                            {
                                SupplierName = reader["SupplierName"].ToString(),
                                Code = reader.IsDBNull(1) ? string.Empty : reader["Code"].ToString(),
                                Name = reader["Name"].ToString(),
                                Brand = reader["Brand"].ToString(),
                                Unit = reader["Unit"].ToString(),
                                Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString()),
                                PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"].ToString()),
                                BillNo = reader["BillNo"].ToString(),
                                SellPrice = Convert.ToDecimal(reader.IsDBNull(9) ? "0" : reader["SellPrice"].ToString())
                            };

                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return items;
        }

        /// <summary>
        /// Get items with matching filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Items</returns>
        public IEnumerable<Item> GetItems(DTOs.StockFilter filter)
        {
            var items = new List<Item>();
            string connectionString = GetConnectionString();
            var query = @"SELECT SupplierName, Code, Name, Brand, Unit, Sum(Quantity) AS 'Quantity', " +
                " PurchaseDate, PurchasePrice, BillNo, Sum(ISNULL(SellPrice,0)) AS 'SellPrice'" +
                " FROM Item" +
                " WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filter?.ItemName))
            {
                query += " AND Name = @Name";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += " AND PurchaseDate BETWEEN @DateFrom AND @DateTo";
            }

            query += " GROUP BY SupplierName, Code, Name, Brand, Unit, PurchaseDate, PurchasePrice, BillNo";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", ((object)filter.ItemName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateFrom", ((object)filter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)filter.DateTo) ?? DBNull.Value );

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new Item
                                {
                                    SupplierName = reader["SupplierName"].ToString(),
                                    Code = reader["Code"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString()),
                                    PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"].ToString()),
                                    BillNo = reader["BillNo"].ToString(),
                                    SellPrice = reader.IsDBNull(9) ? 0.0m : Convert.ToDecimal(reader["SellPrice"].ToString())
                                };

                                items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return items;
        }

        /// <summary>
        /// Get total count of matching filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Total Count</returns>
        public int GetTotalItemCount(DTOs.StockFilter filter)
        {
            int totalCount = 0;
            string connectionString = GetConnectionString();
            var query = @"SELECT Sum(Quantity) AS 'Quantity' " +
                " FROM Item" +
                " WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filter?.ItemName))
            {
                query += " AND Name = @Name";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += " AND PurchaseDate BETWEEN @DateFrom AND @DateTo";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", ((object)filter.ItemName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateFrom", ((object)filter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)filter.DateTo) ?? DBNull.Value);

                        totalCount = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return totalCount;
        }

        /// <summary>
        /// Get list of available item names
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllItemNames()
        {
            var itemNames = new List<string>();
            string connectionString = GetConnectionString();
            var query = @"SELECT DISTINCT Name FROM Item ORDER BY NAME ASC";

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
                                var itemName = reader["Name"].ToString();
                                itemNames.Add(itemName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return itemNames;
        }

        /// <summary>
        /// Returns a item with matching item name
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>Item</returns>
        public Item GetItem(string itemName)
        {
            string connectionString = GetConnectionString();
            var query = @"SELECT SupplierName, Code, Name, Brand, Unit, Quantity, PurchasePrice, PurchaseDate, BillNo, SellPrice FROM Item WHERE Name = @Name";
            var item = new Item();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", itemName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.SupplierName = reader["SupplierName"].ToString();
                                item.Code = reader.IsDBNull(1) ? string.Empty : reader["Code"].ToString();
                                item.Name = reader["Name"].ToString();
                                item.Brand = reader["Brand"].ToString();
                                item.Unit = reader["Unit"].ToString();
                                item.Quantity = Convert.ToDecimal(reader["Quantity"].ToString());
                                item.PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString());
                                item.PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"].ToString());
                                item.BillNo = reader["BillNo"].ToString();
                                item.SellPrice = Convert.ToDecimal(reader.IsDBNull(9) ? "0" : reader["SellPrice"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return item;
        }

        /// <summary>
        /// Add a new item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Item</returns>
        public Item AddItem(Item item)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO Item " +
                            "(" +
                                "SupplierName, Code, Name, Brand, Unit, Quantity, PurchasePrice, PurchaseDate, BillNo, SellPrice " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@SupplierName, @Code, @Name, @Brand, @Unit, @Quantity, @PurchasePrice, @PurchaseDate, @BillNo, @SellPrice " +
                            ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", item.SupplierName);
                        command.Parameters.AddWithValue("@Code", ((object)item.Code) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Name", item.Name);
                        command.Parameters.AddWithValue("@Brand", item.Brand);
                        command.Parameters.AddWithValue("@Unit", item.Unit);
                        command.Parameters.AddWithValue("@Quantity", item.Quantity);
                        command.Parameters.AddWithValue("@PurchasePrice", item.PurchasePrice);
                        command.Parameters.AddWithValue("@PurchaseDate", item.PurchaseDate);
                        command.Parameters.AddWithValue("@BillNo", item.BillNo);
                        command.Parameters.AddWithValue("@SellPrice", ((object)item.SellPrice) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return item;
        }

        /// <summary>
        /// Update item with item code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns>Item</returns>
        public Item UpdateItem(string name, Item item)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE Item SET " +
                    "Code = @Code, " +
                    "Name = @Name, " +
                    "Brand = @Brand, " +
                    "Unit = @Unit, " +
                    "PurchasePrice = @PurchasePrice, " +
                    "SellPrice = @SellPrice " +
                    "WHERE " +
                    "Name = @Name";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", item.Code);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Brand", item.Brand);
                        command.Parameters.AddWithValue("@Unit", item.Unit);
                        command.Parameters.AddWithValue("@PurchasePrice", item.PurchasePrice);
                        command.Parameters.AddWithValue("@SellPrice", item.SellPrice);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return item;
        }

        /// <summary>
        /// Delete item with item code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>bool</returns>
        public bool DeleteItem(string code)
        {
            string connectionString = GetConnectionString();
            string query = "DELETE FROM Item " +
                    "WHERE " +
                    "Code = @Code";
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", code);
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
