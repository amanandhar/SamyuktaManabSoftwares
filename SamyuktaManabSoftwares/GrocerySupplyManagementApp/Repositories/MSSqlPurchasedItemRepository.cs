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
        private readonly string connectionString;

        public MSSqlPurchasedItemRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<PurchasedItem> GetPurchasedItems()
        {
            var purchasedItems = new List<PurchasedItem>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [SupplierId], [BillNo], " +
                "[ItemId], [Quantity], [Price], " +
                "[AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "ORDER BY Id ";
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
                                var purchasedItem = new PurchasedItem
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    SupplierId = reader["SupplierId"].ToString(),
                                    BillNo = reader["BillNo"].ToString(),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                purchasedItems.Add(purchasedItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchasedItems;
        }

        public PurchasedItem GetPurchasedItem(long id)
        {
            var purchasedItem = new PurchasedItem();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [SupplierId], [BillNo], " +
                "[ItemId], [Quantity], [Price], " +
                "[AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                purchasedItem.Id = Convert.ToInt64(reader["Id"].ToString());
                                purchasedItem.EndOfDay = reader["EndOfDay"].ToString();
                                purchasedItem.SupplierId = reader["SupplierId"].ToString();
                                purchasedItem.BillNo = reader["BillNo"].ToString();
                                purchasedItem.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                purchasedItem.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                                purchasedItem.Price = Convert.ToDecimal(reader["Price"].ToString());
                                purchasedItem.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                purchasedItem.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchasedItem;
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
                throw new Exception(ex.Message);
            }

            return purchasedItemViewList;
        }

        public IEnumerable<PurchasedItem> GetPurchasedItemBySupplierAndBill(string supplierId, string billNo)
        {
            var items = new List<PurchasedItem>();
            var query = @"SELECT " +
                "[EndOfDay], [SupplierId], [BillNo], [ItemId], [Quantity], [Price], [AddedDate] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND [SupplierId] = @SupplierId " +
                "AND [BillNo] = @BillNo " +
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
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
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
                throw new Exception(ex.Message);
            }

            return items;
        }

        public decimal GetPurchasedItemTotalAmount(string supplierId, string billNo)
        {
            decimal totalAmount = 0.0m;
            var query = @"SELECT " +
                "SUM([Quantity] * [Price]) AS 'TotalPrice' " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND [SupplierId] = @SupplierId " +
                "AND [BillNo] = @BillNo ";

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
                throw new Exception(ex.Message);
            }

            return totalAmount;
        }

        public decimal GetPurchasedItemTotalAmount(StockFilterView filter)
        {
            decimal totalAmount = 0.0m;
            var query = @"SELECT " +
                "SUM(CAST((pi.[Quantity] * pi.[Price]) AS DECIMAL(18,2))) AS 'Total' " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON pi.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += "AND i.[Code] = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += "AND pi.[EndOfDay] BETWEEN @DateFrom AND @DateTo ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", ((object)filter.ItemCode) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateFrom", ((object)filter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)filter.DateTo) ?? DBNull.Value);

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
                throw new Exception(ex.Message);
            }

            return totalAmount;
        }

        public long GetPurchasedItemTotalQuantity(StockFilterView filter)
        {
            long totalCount = 0;
            var query = @"SELECT " +
                "SUM([Quantity]) AS 'Quantity' " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON pi.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += "AND i.[Code] = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += "AND pi.[EndOfDay] BETWEEN @DateFrom AND @DateTo ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", ((object)filter.ItemCode) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateFrom", ((object)filter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)filter.DateTo) ?? DBNull.Value);

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
                throw new Exception(ex.Message);
            }

            return totalCount;
        }

        public IEnumerable<string> GetPurchasedItemCodes()
        {
            var itemCodes = new List<string>();
            var query = @"SELECT " +
                "DISTINCT i.[Code] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON pi.[ItemId] = i.[Id] " +
                "ORDER BY 1";

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
                                var itemName = reader["Code"].ToString();
                                itemCodes.Add(itemName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return itemCodes;
        }

        public PurchasedItem GetPurchasedItemByItemId(long itemId)
        {
            var item = new PurchasedItem();
            var query = @"SELECT " +
                "[EndOfDay], [SupplierId], [BillNo], [ItemId], [Quantity], [Price], [AddedDate] " +
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
                                item.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                item.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                                item.Price = Convert.ToDecimal(reader["Price"].ToString());
                                item.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
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

        public long GetItemId(string supplierName, string billNo)
        {
            int itemId = 0;
            var query = @"SELECT " +
                "[ItemId] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND [SupplierName] = @SupplierName " +
                "AND [BillNo] = @BillNo ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", ((object)supplierName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BillNo", ((object)billNo) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            itemId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return itemId;
        }

        public string GetLastBillNo()
        {
            string billNo = string.Empty;
            string query = @"SELECT " + 
                "TOP 1 [BillNo] " + 
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
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
                throw new Exception(ex.Message);
            }

            return billNo;
        }

        public decimal GetLatestPurchasePrice(long itemId)
        {
            decimal price = 0.0m;
            string query = @"SELECT " +
                "TOP 1 [Price] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND [ItemId] = @ItemId " +
                "ORDER BY [Id] DESC ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", ((object)itemId) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            price = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return price;
        }

        public PurchasedItem AddPurchasedItem(PurchasedItem purchasedItem)
        {
            string query = @"INSERT INTO " + Constants.TABLE_PURCHASED_ITEM + " " +
                    "( " +
                        "[EndOfDay], [SupplierId], [BillNo], [ItemId], [Quantity], [Price], [AddedDate], [UpdatedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @SupplierId, @BillNo, @ItemId, @Quantity, @Price, @AddedDate, @UpdatedDate " +
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
                        command.Parameters.AddWithValue("@ItemId", purchasedItem.ItemId);
                        command.Parameters.AddWithValue("@Quantity", purchasedItem.Quantity);
                        command.Parameters.AddWithValue("@Price", purchasedItem.Price);
                        command.Parameters.AddWithValue("@AddedDate", purchasedItem.AddedDate);
                        command.Parameters.AddWithValue("@UpdatedDate", purchasedItem.UpdatedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchasedItem;
        }

        public PurchasedItem UpdatePurchasedItem(long purchasedItemId, PurchasedItem purchasedItem)
        {
            string query = @"UPDATE " + Constants.TABLE_PURCHASED_ITEM + " " +
                        "SET " +
                        "[EndOfDay] = @EndOfDay, " +
                        "[SupplierId] = @SupplierId, " +
                        "[BillNo] = @BillNo, " +
                        "[ItemId] = @ItemId, " +
                        "[Quantity] = @Quantity, " +
                        "[Price] = @Price, " +
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
                        command.Parameters.AddWithValue("@Id", purchasedItemId);
                        command.Parameters.AddWithValue("@EndOfDay", purchasedItem.EndOfDay);
                        command.Parameters.AddWithValue("@SupplierId", purchasedItem.SupplierId);
                        command.Parameters.AddWithValue("@BillNo", purchasedItem.BillNo);
                        command.Parameters.AddWithValue("@ItemId", purchasedItem.ItemId);
                        command.Parameters.AddWithValue("@Quantity", purchasedItem.Quantity);
                        command.Parameters.AddWithValue("@Price", purchasedItem.Price);
                        command.Parameters.AddWithValue("@UpdatedDate", purchasedItem.UpdatedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchasedItem;
        }

        public bool DeletePurchasedItem(long purchasedItemId)
        {
            throw new System.NotImplementedException();
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
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool DeletePurchasedItemAfterEndOfDay(string endOfDay)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                    "WHERE 1 = 1 " +
                    "AND [EndOfDay] > @EndOfDay ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", endOfDay);
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
