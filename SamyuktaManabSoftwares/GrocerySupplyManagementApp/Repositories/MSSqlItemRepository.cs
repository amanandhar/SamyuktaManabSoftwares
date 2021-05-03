using GrocerySupplyManagementApp.DTOs;
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
            var query = @"SELECT * FROM Item";
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
                                Name = reader["Name"].ToString(),
                                Brand = reader["Address"].ToString(),
                                BillNo = reader["BillNo"].ToString(),
                                PurchasePrice = Convert.ToDouble(reader["PurchasePrice"].ToString()),
                                Unit = reader["Unit"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"].ToString())
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
            var query = @"SELECT * FROM Item WHERE ItemId = @ItemId";
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
                            item.Name = reader["Name"].ToString();
                            item.Brand = reader["Brand"].ToString();
                            item.BillNo = reader["BillNo"].ToString();
                            item.PurchasePrice = Convert.ToDouble(reader["PurchasePrice"].ToString());
                            item.Unit = reader["Unit"].ToString();
                            item.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
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
                                "ItemId, Code, Name, Brand, Unit, CostPrice, SellPrice " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@ItemId, @Code, @Name, @Brand, @Unit, @CostPrice, @SellPrice " +
                            ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Name", item.Name);
                        command.Parameters.AddWithValue("@Brand", item.Brand);
                        command.Parameters.AddWithValue("@Unit", item.Unit);


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
        /// Update item with item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="item"></param>
        /// <returns>Item</returns>
        public Item UpdateItem(string itemId, Item item)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE Item SET " +
                    "ItemId = @ItemId, " +
                    "Code = @Code, " +
                    "Name = @Name, " +
                    "Brand = @Brand, " +
                    "Unit = @Unit, " +
                    "CostPrice = @CostPrice, " +
                    "SellPrice = @SellPrice " +
                    "WHERE " +
                    "ItemId = @ItemId";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Name", item.Name);
                        command.Parameters.AddWithValue("@Brand", item.Brand);
                        command.Parameters.AddWithValue("@Unit", item.Unit);


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
        /// Delete item with item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>bool</returns>
        public bool DeleteItem(string itemId)
        {
            string connectionString = GetConnectionString();
            string query = "DELETE FROM Item " +
                    "WHERE " +
                    "ItemId = @ItemId";
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", itemId);
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
