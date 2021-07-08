using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
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
                "ItemId, Unit, SUM(Quantity) AS 'Quantity' " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 ";

            if (!showEmptyItemCode)
            {
                query += "AND Code != '' ";
            }

            query += "GROUP BY ItemId, Unit ";

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
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString())
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
            var query = @"SELECT " +
                "it.[Date] AS 'Date', it.[BillNo] AS 'BillInvoiceNo', 'Purchase' AS 'Description', i.[Code] AS 'Code', " +
                "i.[Name] AS 'Name', i.[Brand] AS 'Brand', it.[Unit] AS 'Unit', " +
                "it.[Quantity] AS 'Quantity', it.[Price] AS 'Price', CAST((it.[Quantity] * it.[Price]) AS DECIMAL(18,2)) AS 'Total' " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " it " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON " +
                "it.ItemId = i.Id " +
                "WHERE 1 = 1 " +
                "UNION " +
                "SELECT " +
                "pt.[InvoiceDate] AS 'Date', pt.[InvoiceNo] 'BillInvoiceNo', 'Sales' AS 'Description', psi.[ItemCode] AS 'Code', " +
                "psi.[ItemName] AS 'Name', psi.[ItemBrand] AS 'Brand', psi.[Unit] AS 'Unit', " +
                "psi.[Quantity] AS 'Quantity', psi.[Price] AS 'Price', CAST((psi.[Quantity] * psi.[Price]) AS DECIMAL(18,2)) AS 'Total' " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " psi " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " pt " +
                "ON " +
                "psi.InvoiceNo = pt.InvoiceNo " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += "AND Code = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += "AND Date BETWEEN @DateFrom AND @DateTo ";
            }

            query += "ORDER BY Date DESC ";

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
                                    Date = Convert.ToDateTime(reader["Date"].ToString()).ToString("yyyy-MM-dd"),
                                    BillInvoiceNo = reader["BillInvoiceNo"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Code = reader["Code"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    Total = Convert.ToDecimal(reader["Total"].ToString())
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

        public IEnumerable<PurchasedItem> GetItemsBySupplierAndBill(string supplierName, string billNo)
        {
            var items = new List<PurchasedItem>();
            var query = @"SELECT " +
                "SupplierName, ItemId, Unit, Quantity, Price, Date, BillNo " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND SupplierName = @SupplierName " +
                "AND BillNo = @BillNo " +
                "ORDER BY Date ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", supplierName);
                        command.Parameters.AddWithValue("@BillNo", billNo);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new PurchasedItem()
                                {
                                    SupplierName = reader["SupplierName"].ToString(),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Unit = reader["Unit"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    PurchasePrice = Convert.ToDecimal(reader["Price"].ToString()),
                                    PurchaseDate = Convert.ToDateTime(reader["Date"].ToString()),
                                    BillNo = reader["BillNo"].ToString()
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

        public decimal GetTotalAmountBySupplierAndBill(string supplierName, string billNo)
        {
            decimal totalAmount = 0.0m;
            var query = @"SELECT " +
                "SUM(Quantity * Price) AS 'TotalPrice' " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND SupplierName = @SupplierName " +
                "AND BillNo = @BillNo ";

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
                "SUM(Quantity) AS 'Quantity' " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " it " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON it.ItemId = i.Id " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += "AND Code = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += "AND Date BETWEEN @DateFrom AND @DateTo ";
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
                "SUM(psi.Quantity) AS 'Quantity' " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " psi " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " pt " +
                "ON psi.InvoiceNo = pt.InvoiceNo " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += "AND psi.ItemCode = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += "AND pt.InvoiceDate BETWEEN @DateFrom AND @DateTo ";
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
                "SUM(CAST((Quantity * Price) AS DECIMAL(18,2))) AS 'Total' " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " it " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON it.ItemId = i.Id " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += "AND Code = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += "AND Date BETWEEN @DateFrom AND @DateTo ";
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
                "SUM(CAST((psi.Quantity * psi.Price) AS DECIMAL(18,2))) AS 'Total' " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " psi " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " pt " +
                "ON psi.InvoiceNo = pt.InvoiceNo " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += "AND psi.ItemCode = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += "AND pt.InvoiceDate BETWEEN @DateFrom AND @DateTo ";
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
                "DISTINCT Name " +
                "FROM " + Constants.TABLE_ITEM + " " + 
                "ORDER BY NAME";

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
                "DISTINCT a.Code " +
                "FROM " + Constants.TABLE_ITEM + " a " +
                "INNER JOIN " + Constants.TABLE_PURCHASED_ITEM + " b " +
                "ON a.Id = b.ItemId " +
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
                "SupplierName, ItemId, Unit, Quantity, Price, Date, BillNo " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " + 
                "AND ItemId = @ItemId";
            
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
                                item.SupplierName = reader["SupplierName"].ToString();
                                item.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                item.Unit = reader["Unit"].ToString();
                                item.Quantity = Convert.ToDecimal(reader["Quantity"].ToString());
                                item.PurchasePrice = Convert.ToDecimal(reader["Price"].ToString());
                                item.PurchaseDate = Convert.ToDateTime(reader["Date"].ToString());
                                item.BillNo = reader["BillNo"].ToString();
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
                "ItemId " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND SupplierName = @SupplierName " +
                "AND BillNo = @BillNo ";

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
                        "SupplierName, ItemId, Unit, Quantity, Price, Date, BillNo " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@SupplierName, @ItemId, @Unit, @Quantity, @Price, @Date, @BillNo " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", item.SupplierName);
                        command.Parameters.AddWithValue("@ItemId", item.ItemId);
                        command.Parameters.AddWithValue("@Unit", item.Unit);
                        command.Parameters.AddWithValue("@Quantity", item.Quantity);
                        command.Parameters.AddWithValue("@Price", item.PurchasePrice);
                        command.Parameters.AddWithValue("@Date", item.PurchaseDate);
                        command.Parameters.AddWithValue("@BillNo", item.BillNo);
  
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
                    "Unit = @Unit, " +
                    "Price = @Price " +
                    "WHERE 1 = 1 " +
                    "AND ItemId = @ItemId ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", item.ItemId);
                        command.Parameters.AddWithValue("@Unit", item.Unit);
                        command.Parameters.AddWithValue("@Price", item.PurchasePrice);
                       

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
                "AND Name = @Name " +
                "AND Brand = @Brand ";

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
                    "AND BillNo = @BillNo ";

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
