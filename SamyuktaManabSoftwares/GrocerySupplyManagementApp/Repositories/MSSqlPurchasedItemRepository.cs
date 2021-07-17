﻿using GrocerySupplyManagementApp.Entities;
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

        public IEnumerable<PurchasedItem> GetItems(bool showEmptyItemCode)
        {
            var items = new List<PurchasedItem>();
            var query = @"SELECT " +
                "[ItemId], [Unit], SUM([Quantity]) AS 'Quantity' " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 ";

            if (!showEmptyItemCode)
            {
                query += "AND [Code] != '' ";
            }

            query += "GROUP BY [ItemId], [Unit] ";

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
                                var item = new PurchasedItem
                                {
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Unit = reader["Unit"].ToString(),
                                    Quantity = Convert.ToInt64(reader["Quantity"].ToString())
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

        public IEnumerable<StockView> GetStockView(StockFilterView filter)
        {
            var items = new List<StockView>();
            var query = @"IF OBJECT_ID('tempdb..#MergedTable') IS NOT NULL
                        DROP TABLE #MergedTable
                
                        SELECT m.[EndOfDate], m.[BillInvoiceNo], m.[Description], m.[ItemCode], m.[ItemName], m.[ItemBrand],
                        m.[PurchaseQuantity], m.[PurchasePrice], m.[PurchaseTotal],
                        m.[SalesQuantity], m.[SalesPrice], m.[SalesTotal], m.[Date]
                        INTO #MergedTable
                        FROM
                        (
	                        SELECT pi.[EndOfDate] AS [EndOfDate], pi.[BillNo] AS [BillInvoiceNo], 'Purchase' AS [Description], 
	                        i.[Code] AS [ItemCode], i.[Name] AS [ItemName], i.[Brand] AS [ItemBrand], 
	                        pi.[Quantity] AS [PurchaseQuantity], pi.[Price] AS [PurchasePrice], (pi.[Quantity] * pi.[Price]) AS [PurchaseTotal], 
	                        0 AS [SalesQuantity], 0 AS [SalesPrice], 0 AS [SalesTotal], 
	                        pi.[Date] AS [Date]
	                        FROM PurchasedItem pi
	                        INNER JOIN Item i
	                        ON pi.[ItemId] = i.[Id]
	                        UNION
	                        SELECT si.[EndOfDate] AS [EndOfDate], si.[InvoiceNo] AS [BillInvoiceNo], 'Sales' AS [Description], 
	                        i.[Code] AS [ItemCode], i.[Name] AS [ItemName], i.[Brand] AS [ItemBrand], 
	                        0 AS [PurchaseQuantity], 0 AS [PurchasePrice], 0 AS [PurchaseTotal], 
	                        si.[Quantity] AS [SalesQuantity], si.[Price] AS [SalesPrice], (si.[Quantity] * si.[Price]) AS [SalesTotal],
	                        si.[Date] AS [Date]
	                        FROM SoldItem si
	                        INNER JOIN Item i
	                        ON si.[ItemId] = i.[Id]
                        ) m
                        ORDER BY m.[Date]

                        SELECT 
                        final.[EndOfDate], final.[BillInvoiceNo], final.[Description], final.[ItemCode], final.[ItemName], final.[ItemBrand],
                        final.[PurchaseQuantity], final.[PurchasePrice], final.[PurchaseTotal], final.[PurchaseGrandTotal],
                        final.[SalesQuantity], final.[SalesPrice], final.[SalesTotal], final.[SalesGrandTotal], 
                        final.[BalanceQuantity],
                        (final.[PurchaseGrandTotal] - final.[SalesGrandTotal]) AS [TotalStockValue],
                        (final.[PurchaseGrandTotal] - final.[SalesGrandTotal])/final.[BalanceQuantity] AS [PerUnitValue],
                        final.[Date]
                        FROM
                        (
	                        SELECT m.[EndOfDate], m.[BillInvoiceNo], m.[Description], m.[ItemCode], m.[ItemName], m.[ItemBrand],
	                        m.[PurchaseQuantity], m.[PurchasePrice], m.[PurchaseTotal],
	                        (
	                        SELECT ISNULL(SUM(ISNULL(t.[PurchaseTotal], 0)), 0)
	                        FROM #MergedTable t
	                        WHERE 1 = 1
	                        AND t.[Date] <= m.[Date] 
	                        AND t.[ItemCode] = m.[ItemCode]
	                        ) AS [PurchaseGrandTotal],
	                        m.[SalesQuantity], m.[SalesPrice], m.[SalesTotal],
	                        (
	                        SELECT ISNULL(SUM(ISNULL(t.[SalesTotal], 0)), 0)
	                        FROM #MergedTable t
	                        WHERE 1 = 1
	                        AND t.[Date] <= m.[Date] 
	                        AND t.[ItemCode] = m.[ItemCode]
	                        ) AS [SalesGrandTotal],
	                        (
	                        SELECT SUM(ISNULL(t.[PurchaseQuantity], 0) - ISNULL(t.[SalesQuantity], 0)) 
	                        FROM #MergedTable t
	                        WHERE 1 = 1 
	                        AND t.[Date] <= m.[Date]
	                        AND t.[ItemCode] = m.[ItemCode]
	                        ) AS [BalanceQuantity],
	                        m.[Date]
	                        FROM #MergedTable m
                        ) final
                        WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += "AND final.[ItemCode] = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += "AND final.[EndOfDate] BETWEEN @DateFrom AND @DateTo ";
            }

            query += "ORDER BY final.[ItemCode], final.[Date]";

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

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new StockView
                                {
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()),
                                    BillInvoiceNo = reader["BillInvoiceNo"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["ItemName"].ToString(),
                                    ItemBrand = reader["ItemBrand"].ToString(),
                                    PurchaseQuantity = Convert.ToInt64(reader["PurchaseQuantity"].ToString()),
                                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString()),
                                    PurchaseTotal = Convert.ToDecimal(reader["PurchaseTotal"].ToString()),
                                    PurchaseGrandTotal = Convert.ToDecimal(reader["PurchaseGrandTotal"].ToString()),
                                    SalesQuantity = Convert.ToInt64(reader["SalesQuantity"].ToString()),
                                    SalesPrice = Convert.ToDecimal(reader["SalesPrice"].ToString()),
                                    SalesTotal = Convert.ToDecimal(reader["SalesTotal"].ToString()),
                                    SalesGrandTotal = Convert.ToDecimal(reader["SalesGrandTotal"].ToString()),
                                    BalanceQuantity = Convert.ToInt64(reader["BalanceQuantity"].ToString()),
                                    TotalStockValue = Convert.ToDecimal(reader["TotalStockValue"].ToString()),
                                    PerUnitValue = Convert.ToDecimal(reader["PerUnitValue"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
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

        public IEnumerable<PurchasedItem> GetItemsBySupplierAndBill(string supplierId, string billNo)
        {
            var items = new List<PurchasedItem>();
            var query = @"SELECT " +
                "[EndOfDate], [SupplierId], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND [SupplierId] = @SupplierId " +
                "AND [BillNo] = @BillNo " +
                "ORDER BY Date ";

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
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()),
                                    SupplierId = reader["SupplierId"].ToString(),
                                    BillNo = reader["BillNo"].ToString(),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Unit = reader["Unit"].ToString(),
                                    Quantity = Convert.ToInt64(reader["Quantity"].ToString()),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString()),
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

        public decimal GetTotalAmountBySupplierAndBill(string supplierId, string billNo)
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

        public long GetTotalPurchaseItemCount(StockFilterView filter)
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
                query += "AND pi.[EndOfDate] BETWEEN @DateFrom AND @DateTo ";
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

        public long GetTotalSalesItemCount(StockFilterView filter)
        {
            long totalCount = 0;
            var query = @"SELECT " +
                "SUM(si.[Quantity]) AS 'Quantity' " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " si " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "ON si.[InvoiceNo] = ut.[InvoiceNo] " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += "AND i.[Code] = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += "AND ut.[EndOfDate] BETWEEN @DateFrom AND @DateTo ";
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

        public decimal GetTotalPurchaseItemAmount(StockFilterView filter)
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
                query += "AND pi.[EndOfDate] BETWEEN @DateFrom AND @DateTo ";
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

        public decimal GetTotalSalesItemAmount(StockFilterView filter)
        {
            decimal totalAmount = 0.0m;
            var query = @"SELECT " + 
                "SUM(CAST((si.[Quantity] * si.[Price]) AS DECIMAL(18,2))) AS 'Total' " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " si " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += "AND i.[Code] = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += "AND si.[EndOfDate] BETWEEN @DateFrom AND @DateTo ";
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

        public IEnumerable<string> GetAllItemNames()
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

        public IEnumerable<string> GetAllItemCodes()
        {
            var itemCodes = new List<string>();
            var query = @"SELECT " +
                "DISTINCT a.[Code] " +
                "FROM " + Constants.TABLE_ITEM + " a " +
                "INNER JOIN " + Constants.TABLE_PURCHASED_ITEM + " b " +
                "ON a.[Id] = b.[ItemId] " +
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

        public PurchasedItem GetItem(long itemId)
        {
            var item = new PurchasedItem();
            var query = @"SELECT " +
                "[SupplierId], [ItemId], [Unit], [Quantity], [Price], [Date], [BillNo] " +
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
                                item.SupplierId = reader["SupplierId"].ToString();
                                item.BillNo = reader["BillNo"].ToString();
                                item.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                item.Unit = reader["Unit"].ToString();
                                item.Quantity = Convert.ToInt64(reader["Quantity"].ToString());
                                item.Price = Convert.ToDecimal(reader["Price"].ToString());
                                item.Date = Convert.ToDateTime(reader["Date"].ToString());
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

        public PurchasedItem AddItem(PurchasedItem item)
        {
            string query = @"INSERT INTO " + Constants.TABLE_PURCHASED_ITEM + " " +
                    "( " +
                        "[EndOfDate], [SupplierId], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDate, @SupplierId, @BillNo, @ItemId, @Unit, @Quantity, @Price, @Date " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDate", item.EndOfDate);
                        command.Parameters.AddWithValue("@SupplierId", item.SupplierId);
                        command.Parameters.AddWithValue("@BillNo", item.BillNo);
                        command.Parameters.AddWithValue("@ItemId", item.ItemId);
                        command.Parameters.AddWithValue("@Unit", item.Unit);
                        command.Parameters.AddWithValue("@Quantity", item.Quantity);
                        command.Parameters.AddWithValue("@Price", item.Price);
                        command.Parameters.AddWithValue("@Date", item.Date);
  
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

        public PurchasedItem UpdateItem(PurchasedItem item)
        {
            string query = @"UPDATE " + Constants.TABLE_PURCHASED_ITEM + " " +
                    "SET " +
                    "[Unit] = @Unit, " +
                    "[Price] = @Price " +
                    "WHERE 1 = 1 " +
                    "AND [ItemId] = @ItemId ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", item.ItemId);
                        command.Parameters.AddWithValue("@Unit", item.Unit);
                        command.Parameters.AddWithValue("@Price", item.Price);

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

        public bool DeleteItem(string name, string brand)
        {
            bool result = false;
            string query = @"DELETE " + 
                "FROM " +  Constants.TABLE_PURCHASED_ITEM + " " +
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

        public bool DeleteItemTransaction(string billNo)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " +  Constants.TABLE_PURCHASED_ITEM + " " + 
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
    }
}
