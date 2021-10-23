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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlItemRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Item> GetItems()
        {
            var items = new List<Item>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [Code], [Name], [Brand], [Unit], [Threshold], [AddedDate], [UpdatedDate] " +
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
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Code = reader.IsDBNull(2) ? string.Empty : reader["Code"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    Threshold = Convert.ToInt32(reader["Threshold"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = reader.IsDBNull(8) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return items;
        }

        public Item GetItem(string code)
        {
            var item = new Item();
            var query = @"SELECT " +
                "[Id], [Code], [Name], [Brand], [Unit], [Threshold], [AddedDate], [UpdatedDate] " +
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
                                item.Threshold = Convert.ToInt32(reader["Threshold"].ToString());
                                item.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                item.UpdatedDate = reader.IsDBNull(7) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return item;
        }

        public Item GetItem(long itemId)
        {
            var item = new Item();
            var query = @"SELECT " +
                "[Id], [Code], [Name], [Brand], [Unit], [Threshold], [AddedDate], [UpdatedDate] " +
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
                                item.Threshold = Convert.ToInt32(reader["Threshold"].ToString());
                                item.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                item.UpdatedDate = reader.IsDBNull(7) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return item;
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
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return itemNames;
        }

        public Item AddItem(Item item)
        {
            string query = @"INSERT INTO " + Constants.TABLE_ITEM + " " +
                    "( " +
                        "[EndOfDay], [Code], [Name], [Brand], [Unit], [Threshold], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @Code, @Name, @Brand, @Unit, @Threshold, @AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", item.EndOfDay);
                        command.Parameters.AddWithValue("@Code", ((object)item.Code) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Name", item.Name);
                        command.Parameters.AddWithValue("@Brand", item.Brand);
                        command.Parameters.AddWithValue("@Unit", ((object)item.Unit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Threshold", ((object)item.Threshold) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", ((object)item.AddedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)item.AddedDate) ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
                "[Unit] = @Unit, " +
                "[Threshold] = @Threshold, " +
                "[UpdatedBy] = @UpdatedBy, " +
                "[UpdatedDate] = @UpdatedDate " +
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
                        command.Parameters.AddWithValue("@Threshold", ((object)item.Threshold) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedBy", ((object)item.UpdatedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)item.UpdatedDate) ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return result;
        }
    }
}
