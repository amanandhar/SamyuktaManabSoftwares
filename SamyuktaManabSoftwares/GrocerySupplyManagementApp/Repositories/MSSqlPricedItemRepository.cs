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
                "[Id], [ItemId], " +
                "[SubCode], [CustomizedQuantity], [CustomizedUnit], " +
                "[Barcode], [ProfitPercent], [Profit], [SalesPricePerUnit], " +
                "[Barcode1], [ProfitPercent1], [Profit1], [SalesPricePerUnit1], " +
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
                                pricedItem.CustomizedQuantity = reader.IsDBNull(3) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["CustomizedQuantity"].ToString());
                                pricedItem.CustomizedUnit = reader["CustomizedUnit"].ToString();
                                pricedItem.Barcode = reader.IsDBNull(5) ? null : reader["Barcode"].ToString();
                                pricedItem.ProfitPercent = reader.IsDBNull(6) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["ProfitPercent"].ToString());
                                pricedItem.Profit = reader.IsDBNull(7) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Profit"].ToString());
                                pricedItem.SalesPricePerUnit = reader.IsDBNull(8) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["SalesPricePerUnit"].ToString());
                                pricedItem.Barcode1 = reader.IsDBNull(9) ? null : reader["Barcode1"].ToString();
                                pricedItem.ProfitPercent1 = reader.IsDBNull(10) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["ProfitPercent1"].ToString());
                                pricedItem.Profit1 = reader.IsDBNull(11) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Profit1"].ToString());
                                pricedItem.SalesPricePerUnit1 = reader.IsDBNull(12) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["SalesPricePerUnit1"].ToString());
                                pricedItem.ImagePath = reader["ImagePath"].ToString();
                                pricedItem.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                pricedItem.UpdatedDate = reader.IsDBNull(15) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
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

        public PricedItem GetPricedItem(string itemCode)
        {
            var query = @"SELECT " +
                "pi.[Id], pi.[ItemId], " +
                "pi.[ProfitPercent], pi.[Profit], pi.[SalesPricePerUnit], " +
                "pi.[ImagePath], pi.[AddedDate], pi.[UpdatedDate] " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON ISNULL(pi.[ItemId], '') = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(pi.[SubCode], '') = '' ";

            if (!string.IsNullOrWhiteSpace(itemCode))
            {
                query += "AND ISNULL(i.[Code], '') = @Code ";
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

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pricedItem.Id = Convert.ToInt64(reader["Id"].ToString());
                                pricedItem.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                pricedItem.ProfitPercent = Convert.ToDecimal(reader["ProfitPercent"].ToString());
                                pricedItem.Profit = Convert.ToDecimal(reader["Profit"].ToString());
                                pricedItem.SalesPricePerUnit = Convert.ToDecimal(reader["SalesPricePerUnit"].ToString());
                                pricedItem.ImagePath = reader["ImagePath"].ToString();
                                pricedItem.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                pricedItem.UpdatedDate = reader.IsDBNull(7) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
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
                "pi.[Id], pi.[ItemId], " +
                "pi.[SubCode], pi.[CustomizedQuantity], pi.[CustomizedUnit], " +
                "pi.[ProfitPercent], pi.[Profit], pi.[SalesPricePerUnit], " +
                "pi.[ImagePath], pi.[AddedDate], pi.[UpdatedDate] " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON ISNULL(pi.[ItemId], '') = i.[Id] " +
                "WHERE 1 = 1 " + 
                "AND ISNULL(i.[Code], '') = @Code " +
                "AND ISNULL(pi.[SubCode], '') = @SubCode ";

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
                                pricedItem.CustomizedQuantity = Convert.ToDecimal(reader["CustomizedQuantity"].ToString());
                                pricedItem.CustomizedUnit = reader["CustomizedUnit"].ToString();
                                pricedItem.ProfitPercent = Convert.ToDecimal(reader["ProfitPercent"].ToString());
                                pricedItem.Profit = Convert.ToDecimal(reader["Profit"].ToString());
                                pricedItem.SalesPricePerUnit = Convert.ToDecimal(reader["SalesPricePerUnit"].ToString());
                                pricedItem.ImagePath = reader["ImagePath"].ToString();
                                pricedItem.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                pricedItem.UpdatedDate = reader.IsDBNull(10) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
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

        public PricedItem GetPricedItemByBarcode(string itemBarcode)
        {
            var query = @"IF EXISTS (SELECT TOP 1 1 FROM " + Constants.TABLE_PRICED_ITEM + " " +
                "WHERE ISNULL([Barcode], '') = @ItemBarcode ) " +
                "BEGIN " +
                "SELECT " +
                "pi.[Id], pi.[ItemId], " +
                "pi.[Barcode], pi.[ProfitPercent], pi.[Profit], pi.[SalesPricePerUnit], " +
                "pi.[ImagePath], pi.[AddedDate], pi.[UpdatedDate] " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON ISNULL(pi.[ItemId], '') = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(pi.[Barcode], '') = @ItemBarcode " +
                "END " +
                "ELSE " +
                "BEGIN " +
                "SELECT " +
                "pi.[Id], pi.[ItemId], " +
                "pi.[Barcode1] AS [Barcode], pi.[ProfitPercent1] AS [ProfitPercent], " +
                "pi.[Profit1] AS [Profit], pi.[SalesPricePerUnit1] AS [SalesPricePerUnit], " +
                "pi.[ImagePath], pi.[AddedDate], pi.[UpdatedDate] " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON ISNULL(pi.[ItemId], '') = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(pi.[Barcode1], '') = @ItemBarcode " +
                "END ";

        var pricedItem = new PricedItem();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemBarcode", itemBarcode);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pricedItem.Id = Convert.ToInt64(reader["Id"].ToString());
                                pricedItem.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                pricedItem.Barcode = reader.IsDBNull(2) ? null : reader["Barcode"].ToString();
                                pricedItem.ProfitPercent = reader.IsDBNull(3) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["ProfitPercent"].ToString());
                                pricedItem.Profit = reader.IsDBNull(4) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Profit"].ToString());
                                pricedItem.SalesPricePerUnit = reader.IsDBNull(5) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["SalesPricePerUnit"].ToString());
                                pricedItem.ImagePath = reader["ImagePath"].ToString();
                                pricedItem.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                pricedItem.UpdatedDate = reader.IsDBNull(8) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
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
                "DISTINCT pi.[Id], i.[Code], pi.[SubCode], i.[Name], pi.[CustomizedQuantity], SUM(ISNULL(ut.[Quantity], 0.00)) AS [Stock] " +
                "FROM " + Constants.TABLE_ITEM + " i " +
                "INNER JOIN " + Constants.TABLE_PRICED_ITEM + " pi " +
                "ON i.[Id] = pi.[ItemId] " +
                "INNER JOIN " + 
                "( " +
                "SELECT [ItemId], [Quantity] FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "UNION ALL " +
                "SELECT [ItemId], -[Quantity] FROM " + Constants.TABLE_SOLD_ITEM + " " +
                "UNION ALL " +
                "SELECT [ItemId], [Quantity] FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " WHERE ISNULL([Action], '') = '" + Constants.ADD + "' " +
                "UNION ALL " +
                "SELECT [ItemId], -[Quantity] FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " WHERE ISNULL([Action], '') = '" + Constants.DEDUCT + "' " +
                ") ut " +
                "ON i.[Id] = ut.[ItemId] " +
                "GROUP BY pi.[Id], i.[Code], pi.[SubCode], i.[Name], pi.[CustomizedQuantity] " +
                "ORDER BY i.[Code], pi.[SubCode] ";

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
                                    CustomizedQuantity = Convert.ToDecimal(reader["CustomizedQuantity"].ToString()),
                                    Stock = Convert.ToDecimal(reader["Stock"].ToString())
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
                "DISTINCT i.[Id], i.[Code], i.[Name] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON pi.[ItemId] = i.[Id] " +
                "WHERE " +
                "1 = 1 " +
                "AND NOT EXISTS (SELECT 1 FROM " + Constants.TABLE_PRICED_ITEM + " WHERE [ItemId] = pi.[ItemId]) " +
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
                        "[EndOfDay], [ItemId], " +
                        "[SubCode], [CustomizedQuantity], [CustomizedUnit], " +
                        "[Barcode], [ProfitPercent], [Profit], [SalesPricePerUnit], " +
                        "[Barcode1], [ProfitPercent1], [Profit1], [SalesPricePerUnit1], " +
                        "[ImagePath], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @ItemId, " +
                        "@SubCode, @CustomizedQuantity, @CustomizedUnit, " +
                        "@Barcode, @ProfitPercent, @Profit, @SalesPricePerUnit, " +
                        "@Barcode1, @ProfitPercent1, @Profit1, @SalesPricePerUnit1, " +
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
                        command.Parameters.AddWithValue("@CustomizedQuantity", pricedItem.CustomizedQuantity);
                        command.Parameters.AddWithValue("@CustomizedUnit", pricedItem.CustomizedUnit);
                        command.Parameters.AddWithValue("@Barcode", pricedItem.Barcode);
                        command.Parameters.AddWithValue("@ProfitPercent", pricedItem.ProfitPercent);
                        command.Parameters.AddWithValue("@Profit", pricedItem.Profit);
                        command.Parameters.AddWithValue("@SalesPricePerUnit", pricedItem.SalesPricePerUnit);
                        command.Parameters.AddWithValue("@Barcode1", pricedItem.Barcode1);
                        command.Parameters.AddWithValue("@ProfitPercent1", pricedItem.ProfitPercent1);
                        command.Parameters.AddWithValue("@Profit1", pricedItem.Profit1);
                        command.Parameters.AddWithValue("@SalesPricePerUnit1", pricedItem.SalesPricePerUnit1);
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
                "[CustomizedQuantity] = @CustomizedQuantity, " +
                "[CustomizedUnit] = @CustomizedUnit, " +
                "[Barcode] = @Barcode, " +
                "[ProfitPercent] = @ProfitPercent, " +
                "[Profit] = @Profit, " +
                "[SalesPricePerUnit] = @SalesPricePerUnit, " +
                "[Barcode1] = @Barcode1, " +
                "[ProfitPercent1] = @ProfitPercent1, " +
                "[Profit1] = @Profit1, " +
                "[SalesPricePerUnit1] = @SalesPricePerUnit1, " +
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
                        command.Parameters.AddWithValue("@CustomizedQuantity", pricedItem.CustomizedQuantity);
                        command.Parameters.AddWithValue("@CustomizedUnit", pricedItem.CustomizedUnit);
                        command.Parameters.AddWithValue("@Barcode", pricedItem.Barcode);
                        command.Parameters.AddWithValue("@ProfitPercent", pricedItem.ProfitPercent);
                        command.Parameters.AddWithValue("@Profit", pricedItem.Profit);
                        command.Parameters.AddWithValue("@SalesPricePerUnit", pricedItem.SalesPricePerUnit);
                        command.Parameters.AddWithValue("@Barcode1", pricedItem.Barcode1);
                        command.Parameters.AddWithValue("@ProfitPercent1", pricedItem.ProfitPercent1);
                        command.Parameters.AddWithValue("@Profit1", pricedItem.Profit1);
                        command.Parameters.AddWithValue("@SalesPricePerUnit1", pricedItem.SalesPricePerUnit1);
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
