using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlPurchasedItemRepository : IPurchasedItemRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlPurchasedItemRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<PurchasedItemListView> GetPurchasedItemDetails()
        {
            var purchasedItemViewList = new List<PurchasedItemListView>();
            string query = @"SELECT " +
                "DISTINCT " +
                "i.[Id] AS [ItemId], i.[Code] AS [ItemCode], i.[Name] AS [ItemName], i.[Brand] AS [ItemBrand] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " pi " +
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
                                var purchasedItemView = new PurchasedItemListView
                                {
                                    Id = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Code = reader["ItemCode"].ToString(),
                                    Name = reader["ItemName"].ToString(),
                                    Brand = reader["ItemBrand"].ToString()
                                };

                                purchasedItemViewList.Add(purchasedItemView);
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

            return purchasedItemViewList;
        }

        public IEnumerable<PurchasedItem> GetPurchasedItemBySupplierAndBill(string supplierId, string billNo)
        {
            var items = new List<PurchasedItem>();
            var query = @"SELECT " +
                "[EndOfDay], [SupplierId], [BillNo], [IsBonus], [ItemId], [Quantity], [Price], [AddedDate] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([SupplierId], '') = @SupplierId " +
                "AND ISNLL([BillNo], '') = @BillNo " +
                "ORDER BY AddedDate ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", supplierId);
                        command.Parameters.AddWithValue("@BillNo", billNo);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new PurchasedItem()
                                {
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    SupplierId = reader["SupplierId"].ToString(),
                                    BillNo = reader["BillNo"].ToString(),
                                    IsBonus = Convert.ToBoolean(reader["IsBonus"].ToString()),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
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
                throw ex;
            }

            return items;
        }

        public decimal GetPurchasedItemTotalAmount(string supplierId, string billNo)
        {
            decimal totalAmount = Constants.DEFAULT_DECIMAL_VALUE;
            var query = @"SELECT " +
                "CAST(SUM([Quantity] * [Price]) AS DECIMAL(18, 2)) AS [TotalPrice] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([SupplierId], '') = @SupplierId " +
                "AND ISNULL([BillNo], '') = @BillNo ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", ((object)supplierId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BillNo", ((object)billNo) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            totalAmount = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return totalAmount;
        }

        public long GetPurchasedItemTotalQuantity(StockFilter stockFilter)
        {
            long totalCount = 0;
            var query = @"SELECT " +
                "SUM([Quantity]) AS 'Quantity' " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON pi.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.ItemCode))
            {
                query += "AND ISNULL(i.[Code], '') = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateFrom))
            {
                query += "AND pi.[EndOfDay] >= @DateFrom ";
            }

            if(!string.IsNullOrWhiteSpace(stockFilter?.DateTo))
            {
                query += "AND pi.[EndOfDay] <= @DateTo ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", ((object)stockFilter.ItemCode) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateFrom", ((object)stockFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)stockFilter.DateTo) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            totalCount = Convert.ToInt64(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return totalCount;
        }

        public PurchasedItem GetPurchasedItemByItemId(long itemId)
        {
            var item = new PurchasedItem();
            var query = @"SELECT " +
                "[EndOfDay], [SupplierId], [BillNo], [IsBonus], [ItemId], [Quantity], [Price], [AddedDate] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " + 
                "AND [ItemId] = @ItemId";
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", itemId);
         
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.EndOfDay = reader["EndOfDay"].ToString();
                                item.SupplierId = reader["SupplierId"].ToString();
                                item.BillNo = reader["BillNo"].ToString();
                                item.IsBonus = Convert.ToBoolean(reader["BillNo"].ToString());
                                item.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                item.Quantity = Convert.ToDecimal(reader["Quantity"].ToString());
                                item.Price = Convert.ToDecimal(reader["Price"].ToString());
                                item.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
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

            return item;
        }

        public string GetLastBillNo()
        {
            string billNo = string.Empty;
            string query = @"SELECT " + 
                "TOP 1 [BillNo] " + 
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE [BillNo] LIKE '" + Constants.BILL_NO_PREFIX + "%' " +
                "ORDER BY Id DESC";
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            billNo = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return billNo;
        }

        public string GetLastBonusNo()
        {
            string bonusNo = string.Empty;
            string query = @"SELECT " +
                "TOP 1 [BillNo] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE [BillNo] LIKE '" + Constants.BONUS_PREFIX + "%' " +
                "ORDER BY Id DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            bonusNo = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return bonusNo;
        }

        public PurchasedItem AddPurchasedItem(PurchasedItem purchasedItem)
        {
            string query = @"INSERT INTO " + Constants.TABLE_PURCHASED_ITEM + " " +
                    "( " +
                        "[EndOfDay], [SupplierId], [BillNo], [IsBonus], [ItemId], [Quantity], [Price], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @SupplierId, @BillNo, @IsBonus, @ItemId, @Quantity, @Price, @AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", purchasedItem.EndOfDay);
                        command.Parameters.AddWithValue("@SupplierId", purchasedItem.SupplierId);
                        command.Parameters.AddWithValue("@BillNo", purchasedItem.BillNo);
                        command.Parameters.AddWithValue("@IsBonus", purchasedItem.IsBonus);
                        command.Parameters.AddWithValue("@ItemId", purchasedItem.ItemId);
                        command.Parameters.AddWithValue("@Quantity", purchasedItem.Quantity);
                        command.Parameters.AddWithValue("@Price", purchasedItem.Price);
                        command.Parameters.AddWithValue("@AddedBy", purchasedItem.AddedBy);
                        command.Parameters.AddWithValue("@AddedDate", purchasedItem.AddedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return purchasedItem;
        }

        public bool DeletePurchasedItem(string billNo)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                    "WHERE 1 = 1 " +
                    "AND [BillNo] = @BillNo ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BillNo", billNo);
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
