using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlItemCategoryRepository: IItemCategoryRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlItemCategoryRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public ItemCategory GetItemCategory(string name)
        {
            var itemCategory = new ItemCategory();
            var query = @"SELECT " +
                "[Id], [Counter], [Name], [ItemCode] " +
                "FROM " + Constants.TABLE_ITEM_CATEGORY + " " +
                "WHERE 1 = 1 " +
                "AND Name = @Name";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", ((object)name) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    itemCategory.Id = Convert.ToInt64(reader["Id"].ToString());
                                    itemCategory.Counter = Convert.ToInt64(reader["Counter"].ToString());
                                    itemCategory.Name = reader["Name"].ToString();
                                    itemCategory.ItemCode = reader["ItemCode"].ToString();
                                }
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

            return itemCategory;
        }

        public ItemCategory AddItemCategory(ItemCategory category)
        {
            string query = @"INSERT INTO " +
                    " " + Constants.TABLE_ITEM_CATEGORY + " " +
                    "( " +
                        "[EndOfDay], [Counter], [Name], [ItemCode], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @Counter, @Name, @ItemCode, @AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)category.EndOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Counter", ((object)category.Counter) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Name", ((object)category.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ItemCode", ((object)category.ItemCode) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", ((object)category.AddedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)category.AddedDate) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return category;
        }

        public bool DeleteItemCategory(string itemCode)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_ITEM_CATEGORY + " " +
                    "WHERE 1 = 1 " +
                    "AND [ItemCode] = @ItemCode";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemCode", ((object)itemCode) ?? DBNull.Value);
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
