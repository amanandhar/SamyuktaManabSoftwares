using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlItemRepository : IItemRepository
    {
        private readonly string connectionString;

        public MSSqlItemRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Item> GetItems(bool showEmptyItemCode)
        {
            var items = new List<Item>();
            var query = @"SELECT " +
                "[Id], [Code], [Name], [Brand], [Unit] " +
                "FROM " + Constants.TABLE_ITEM + " ";

            if (!showEmptyItemCode)
            {
                query += "WHERE [Code] != '' ";
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
                                var item = new Item
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Code = reader.IsDBNull(1) ? string.Empty : reader["Code"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Unit = reader["Unit"].ToString()
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

        public IEnumerable<Item> GetItems()
        {
            var items = new List<Item>();
            var query = @"SELECT " +
                "[Id], [Code], [Name], [Brand], [Unit] " +
                "FROM " + Constants.TABLE_ITEM + " " +
                "ORDER BY [Code] ";

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
                                var item = new Item
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Code = reader.IsDBNull(1) ? string.Empty : reader["Code"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Unit = reader["Unit"].ToString()
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

        public Item GetItem(string code)
        {
            var item = new Item();
            var query = @"SELECT " +
                "[Id], [Code], [Name], [Brand], [Unit] " +
                "FROM " + Constants.TABLE_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND [Code] = @Code ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", code);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.Id = Convert.ToInt64(reader["Id"].ToString());
                                item.Code = reader.IsDBNull(1) ? string.Empty : reader["Code"].ToString();
                                item.Name = reader["Name"].ToString();
                                item.Brand = reader["Brand"].ToString();
                                item.Unit = reader["Unit"].ToString();
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

        public Item GetItem(long itemId)
        {
            var item = new Item();
            var query = @"SELECT " +
                "[Id], [Code], [Name], [Brand], [Unit] " +
                "FROM " + Constants.TABLE_ITEM + " " + 
                "WHERE 1 = 1 " +
                "AND [Id] = @Id " +
                "ORDER BY [Code] ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", itemId);
       
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.Id = Convert.ToInt64(reader["Id"].ToString());
                                item.Code = reader.IsDBNull(1) ? string.Empty : reader["Code"].ToString();
                                item.Name = reader["Name"].ToString();
                                item.Brand = reader["Brand"].ToString();
                                item.Unit = reader["Unit"].ToString();
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

        public long GetItemId(string name, string brand)
        {
            long id = 0;
            var query = @"SELECT " + 
                "[Id] " +
                "FROM " + Constants.TABLE_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND [Name] = @Name " + 
                "AND [Brand] = @Brand ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Brand", brand);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            id = Convert.ToInt64(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }

        public IEnumerable<string> GetItemNames()
        {
            var itemNames = new List<string>();
            var query = @"SELECT " +
                "DISTINCT [Name] " +
                "FROM " + Constants.TABLE_ITEM + " " +
                "ORDER BY [Name]";

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

        public Item AddItem(Item item)
        {
            string query = @"INSERT INTO " + Constants.TABLE_ITEM + " " +
                    "( " +
                        "[Name], [Brand], [Code], [Unit] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@Name, @Brand, @Code, @Unit " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", item.Name);
                        command.Parameters.AddWithValue("@Brand", item.Brand);
                        command.Parameters.AddWithValue("@Code", ((object)item.Code) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Unit", ((object)item.Unit) ?? DBNull.Value);

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

        public Item UpdateItem(string code, Item item)
        {
            string query = @"UPDATE " + Constants.TABLE_ITEM + " " +
                "SET " +
                "[Name] = @Name, " +
                "[Brand] = @Brand, " +
                "[Unit] = @Unit " +
                "WHERE 1 = 1 " +
                "AND [Code] = @Code ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", code);
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

        public Item UpdateItem(long id, Item item)
        {
            string query = @"UPDATE " + Constants.TABLE_ITEM + " " +
                "SET " +
                "[Name] = @Name, " +
                "[Brand] = @Brand, " +
                "[Code] = @Code, " +
                "[Unit] = @Unit " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Code", item.Code);
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

        public bool DeleteItem(long id)
        {
            var result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_ITEM + " " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

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
