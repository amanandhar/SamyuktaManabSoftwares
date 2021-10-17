using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlPricedItemRepository : IPricedItemRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlPricedItemRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public PricedItem GetPricedItem(long id)
        {
            var pricedItem = new PricedItem();
            var query = @"SELECT " +
                "[Id], [ItemId], [SubCode], [Volume], " +
                "[ProfitPercent], [Profit], [SalesPricePerUnit], " +
                "[ImagePath], [AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id ";
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pricedItem.Id = Convert.ToInt64(reader["Id"].ToString());
                                pricedItem.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                pricedItem.SubCode = reader["SubCode"].ToString();
                                pricedItem.Volume = Convert.ToInt64(reader["Volume"].ToString());
                                pricedItem.ProfitPercent = Convert.ToDecimal(reader["ProfitPercent"].ToString());
                                pricedItem.Profit = Convert.ToDecimal(reader["Profit"].ToString());
                                pricedItem.SalesPricePerUnit = Convert.ToDecimal(reader["SalesPricePerUnit"].ToString());
                                pricedItem.ImagePath = reader["ImagePath"].ToString();
                                pricedItem.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                pricedItem.UpdatedDate = reader.IsDBNull(9) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return pricedItem;
        }
        
        public PricedItem GetPricedItem(string itemCode, string itemSubCode)
        {
            var query = @"SELECT " +
                "pi.[Id], pi.[ItemId], pi.[SubCode], pi.[Volume], " +
                "pi.[ProfitPercent], pi.[Profit], pi.[SalesPricePerUnit], " +
                "pi.[ImagePath], pi.[AddedDate], pi.[UpdatedDate] " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON ISNULL(pi.[ItemId], '') = i.[Id] " +
                "WHERE 1 = 1 ";

            if(!string.IsNullOrWhiteSpace(itemCode))
            {
                query += "AND ISNULL(i.[Code], '') = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(itemSubCode))
            {
                query += "AND ISNULL(pi.[SubCode], '') = @SubCode ";
            }

            var pricedItem = new PricedItem();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", itemCode);
                        command.Parameters.AddWithValue("@SubCode", itemSubCode);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pricedItem.Id = Convert.ToInt64(reader["Id"].ToString());
                                pricedItem.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                pricedItem.SubCode = reader["SubCode"].ToString();
                                pricedItem.Volume = Convert.ToInt64(reader["Volume"].ToString());
                                pricedItem.ProfitPercent = Convert.ToDecimal(reader["ProfitPercent"].ToString());
                                pricedItem.Profit = Convert.ToDecimal(reader["Profit"].ToString());
                                pricedItem.SalesPricePerUnit = Convert.ToDecimal(reader["SalesPricePerUnit"].ToString());
                                pricedItem.ImagePath = reader["ImagePath"].ToString();
                                pricedItem.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                pricedItem.UpdatedDate = reader.IsDBNull(9) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return pricedItem;
        }

        public IEnumerable<PricedItemView> GetPricedItemViewList()
        {
            var pricedItemViewList = new List<PricedItemView>();
            var query = @"SELECT " +
                "DISTINCT pi.[Id], i.[Code], pi.[SubCode], i.[Name], i.[Brand] " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON pi.[ItemId] = i.[Id] " +
                "ORDER BY i.[Code] ";

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
                                var pricedItemView = new PricedItemView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Code = reader["Code"].ToString(),
                                    SubCode = reader["SubCode"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString()
                                };

                                pricedItemViewList.Add(pricedItemView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return pricedItemViewList;
        }

        public IEnumerable<UnpricedItemView> GetUnpricedItemViewList()
        {
            var unpricedItemViewList = new List<UnpricedItemView>();
            var query = @"SELECT " +
                "DISTINCT i.[Id], i.[Code], i.[Name], i.[Brand] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " pi " + 
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON pi.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND NOT EXISTS (SELECT 1 FROM PricedItem WHERE [ItemId] = pi.[ItemId]) " +
                "ORDER BY i.[Code] ";

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
                                var unpricedItemView = new UnpricedItemView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Code = reader["Code"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString()
                                };

                                unpricedItemViewList.Add(unpricedItemView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return unpricedItemViewList;
        }

        public PricedItem AddPricedItem(PricedItem pricedItem)
        {
            string query = @"INSERT INTO " + Constants.TABLE_PRICED_ITEM + " " +
                    "( " +
                        "[EndOfDay], [ItemId], [SubCode], [Volume], " +
                        "[ProfitPercent], [Profit], [SalesPricePerUnit], " +
                        "[ImagePath], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @ItemId, @SubCode, @Volume, " +
                        "@ProfitPercent, @Profit, @SalesPricePerUnit, " +
                        "@ImagePath, @AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", pricedItem.EndOfDay);
                        command.Parameters.AddWithValue("@ItemId", pricedItem.ItemId);
                        command.Parameters.AddWithValue("@SubCode", pricedItem.SubCode);
                        command.Parameters.AddWithValue("@Volume", pricedItem.Volume);
                        command.Parameters.AddWithValue("@ProfitPercent", pricedItem.ProfitPercent);
                        command.Parameters.AddWithValue("@Profit", pricedItem.Profit);
                        command.Parameters.AddWithValue("@SalesPricePerUnit", pricedItem.SalesPricePerUnit);
                        command.Parameters.AddWithValue("@ImagePath", ((object)pricedItem.ImagePath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", pricedItem.AddedBy);
                        command.Parameters.AddWithValue("@AddedDate", pricedItem.AddedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return pricedItem;
        }

        public PricedItem UpdatePricedItem(long id, PricedItem pricedItem)
        {
            string query = @"UPDATE " + Constants.TABLE_PRICED_ITEM + " " + 
                "SET " +
                "[ItemId] = @ItemId, " +
                "[SubCode] = @SubCode, " +
                "[Volume] = @Volume, " +
                "[ProfitPercent] = @ProfitPercent, " +
                "[Profit] = @Profit, " +
                "[SalesPricePerUnit] = @SalesPricePerUnit, " +
                "[ImagePath] = @ImagePath, " +
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
                        command.Parameters.AddWithValue("@ItemId", pricedItem.ItemId);
                        command.Parameters.AddWithValue("@SubCode", pricedItem.SubCode);
                        command.Parameters.AddWithValue("@Volume", pricedItem.Volume);
                        command.Parameters.AddWithValue("@ProfitPercent", pricedItem.ProfitPercent);
                        command.Parameters.AddWithValue("@Profit", pricedItem.Profit);
                        command.Parameters.AddWithValue("@SalesPricePerUnit", pricedItem.SalesPricePerUnit);
                        command.Parameters.AddWithValue("@ImagePath", ((object)pricedItem.ImagePath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedBy", pricedItem.UpdatedBy);
                        command.Parameters.AddWithValue("@UpdatedDate", pricedItem.UpdatedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return pricedItem;
        }

        public bool DeletePricedItem(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " " +
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
                throw ex;
            }

            return result;
        }
    }
}
