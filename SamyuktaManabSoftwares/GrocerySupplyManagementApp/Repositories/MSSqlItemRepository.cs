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
                                Code = reader["Code"].ToString(),
                                Name = reader["Name"].ToString(),
                                Brand = reader["Brand"].ToString(),
                                Unit = reader["Unit"].ToString(),
                                Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString()),
                                PurchaseDate = Convert.ToDateTime(reader["PurchasePrice"].ToString()),
                                BillNo = reader["BillNo"].ToString(),
                                SellPrice = Convert.ToDecimal(reader["SellPrice"].ToString())
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
        /// Returns a item with matching item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>Item</returns>
        public Item GetItem(string itemId)
        {
            string connectionString = GetConnectionString();
            var query = @"SELECT SupplierName, Code, Name, Brand, Unit, Quantity, PurchasePrice, PurchaseDate, BillNo, SellPrice FROM Item WHERE ItemId = @ItemId";
            var item = new Item();
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
                            item.SupplierName = reader["SupplierName"].ToString();
                            item.Code = reader["Code"].ToString();
                            item.Name = reader["Name"].ToString();
                            item.Brand = reader["Brand"].ToString();
                            item.Unit = reader["Unit"].ToString();
                            item.Quantity = Convert.ToDecimal(reader["Quantity"].ToString());
                            item.PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString());
                            item.PurchaseDate = Convert.ToDateTime(reader["PurchasePrice"].ToString());
                            item.BillNo = reader["BillNo"].ToString();
                            item.SellPrice = Convert.ToDecimal(reader["SellPrice"].ToString());
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
        /// <param name="item"></param>
        /// <returns>Item</returns>
        public Item UpdateItem(string code, Item item)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE Item SET " +
                    "SupplierName = @SupplierName," +
                    "Code = @Code, " +
                    "Name = @Name, " +
                    "Brand = @Brand, " +
                    "Unit = @Unit, " +
                    "Quantity = @Quantity, " +
                    "PurchasePrice = @PurchasePrice, " +
                    "PurchaseDate = @PurchaseDate, " +
                    "BillNo = @BillNo, " +
                    "SellPrice = @SellPrice, " +
                    "WHERE " +
                    "Code = @Code";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", item.SupplierName);
                        command.Parameters.AddWithValue("@Code", code);
                        command.Parameters.AddWithValue("@Name", item.Name);
                        command.Parameters.AddWithValue("@Brand", item.Brand);
                        command.Parameters.AddWithValue("@Unit", item.Unit);
                        command.Parameters.AddWithValue("@Quantity", item.Quantity);
                        command.Parameters.AddWithValue("@PurchasePrice", item.PurchasePrice);
                        command.Parameters.AddWithValue("@PurchaseDate", item.PurchaseDate);
                        command.Parameters.AddWithValue("@BillNo", item.BillNo);
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
