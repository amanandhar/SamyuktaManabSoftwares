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

        public IEnumerable<Item> GetItems(bool showEmptyItemCode)
        {
            var items = new List<Item>();
            string connectionString = GetConnectionString();
            var query = @"SELECT Id, Name, Brand, Code FROM Item";
            if (!showEmptyItemCode)
            {
                query += " WHERE Code != ''";
            }
            query += " ORDER BY Id";

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
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Code = reader.IsDBNull(3) ? string.Empty : reader["Code"].ToString()
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
            string connectionString = GetConnectionString();
            var query = @"SELECT Id, Name, Brand, Code FROM Item ORDER BY Id";

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
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Code = reader.IsDBNull(3) ? string.Empty : reader["Code"].ToString()
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
            string connectionString = GetConnectionString();
            var query = @"SELECT Id, Name, Brand, Code" +
                " FROM Item" +
                " WHERE 1=1" +
                " AND Code=@Code";
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
                                item.Name = reader["Name"].ToString();
                                item.Brand = reader["Brand"].ToString();
                                item.Code = reader.IsDBNull(3) ? string.Empty : reader["Code"].ToString();
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
            string connectionString = GetConnectionString();
            var query = @"SELECT Id, Name, Brand, Code" +
                " FROM Item" +
                " WHERE 1=1" +
                " AND Id=@Id ORDER BY Code";
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
                                item.Name = reader["Name"].ToString();
                                item.Brand = reader["Brand"].ToString();
                                item.Code = reader.IsDBNull(3) ? string.Empty : reader["Code"].ToString();
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
            string connectionString = GetConnectionString();
            var query = @"SELECT Id" +
                " FROM Item" +
                " WHERE 1=1" +
                " AND Name=@Name" + 
                " AND Brand=@Brand";
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

        public Item AddItem(Item item)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO Item" +
                            " (" +
                                " Name, Brand, Code" +
                            " ) " +
                            " VALUES" +
                            " (" +
                                " @Name, @Brand, @Code" +
                            " )";
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
            string connectionString = GetConnectionString();
            string query = "UPDATE Item SET " +
                    "Name = @Name, " +
                    "Brand = @Brand " +
                    "WHERE " +
                    "Code = @Code";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", item.Name);
                        command.Parameters.AddWithValue("@Brand", item.Brand);
                        command.Parameters.AddWithValue("@Code", code);
                        
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
            string connectionString = GetConnectionString();
            string query = "UPDATE Item SET " +
                    "Name = @Name, " +
                    "Brand = @Brand, " +
                    "Code = @Code " +
                    "WHERE " +
                    "Id = @Id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", item.Name);
                        command.Parameters.AddWithValue("@Brand", item.Brand);
                        command.Parameters.AddWithValue("@Code", item.Code);
                        command.Parameters.AddWithValue("@Id", id);

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
            string connectionString = GetConnectionString();
            string query = "DELETE FROM Item " +
                    "WHERE " +
                    "Id = @Id";

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

        private string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }
    }
}
