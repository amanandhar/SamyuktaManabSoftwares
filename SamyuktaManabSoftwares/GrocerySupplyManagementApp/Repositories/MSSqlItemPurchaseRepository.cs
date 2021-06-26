using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlItemPurchaseRepository : IItemPurchaseRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";
        private const string TABLE_NAME = "ItemPurchase";
        public MSSqlItemPurchaseRepository()
        {

        }

        /// <summary>
        /// Returns list of items
        /// </summary>
        /// <returns>List of Items</returns>
        public IEnumerable<ItemPurchase> GetItems(bool showEmptyItemCode)
        {
            var items = new List<ItemPurchase>();
            string connectionString = GetConnectionString();
            var query = @"SELECT ItemId, Unit, Sum(Quantity) AS 'Quantity' FROM " + TABLE_NAME;
            if (!showEmptyItemCode)
            {
                query += " WHERE Code != ''";
            }

            query += " GROUP BY ItemId, Unit";

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
                                var item = new ItemPurchase
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

        /// <summary>
        /// Get items with matching filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Items</returns>
        public IEnumerable<ItemPurchaseGrid> GetItems(DTOs.StockFilterView filter)
        {
            var items = new List<ItemPurchaseGrid>();
            string connectionString = GetConnectionString();
            var query = @"SELECT PurchaseDate, BillNo, Code, Name, Brand, Unit, Quantity, PurchasePrice, CAST((Quantity * PurchasePrice) AS DECIMAL(18,2)) AS 'Total'" +
                " FROM ItemPurchase it INNER JOIN Item i ON it.ItemId = i.Id" +
                " WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += " AND Code = @Code";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += " AND PurchaseDate BETWEEN @DateFrom AND @DateTo";
            }

            query += " ORDER BY PurchaseDate DESC ";

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
                                var itemPurchase = new ItemPurchaseGrid
                                {
                                    PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"].ToString()).ToString("yyyy-MM-dd"),
                                    BillNo = reader["BillNo"].ToString(),
                                    Description = "Purchase",
                                    Code = reader["Code"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString()),
                                    Total = Convert.ToDecimal(reader["Total"].ToString())
                                };

                                items.Add(itemPurchase);
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

        /// <summary>
        /// Returns items with matching supplier name and bill no
        /// </summary>
        /// <param name="supplierName"></param>
        /// <param name="billNo"></param>
        /// <returns>Items</returns>
        public IEnumerable<ItemPurchase> GetItemsBySupplierAndBill(string supplierName, string billNo)
        {
            var items = new List<ItemPurchase>();
            string connectionString = GetConnectionString();
            var query = @"SELECT SupplierName, ItemId, Unit, Quantity, PurchasePrice, PurchaseDate, BillNo" +
                " FROM ItemPurchase WHERE SupplierName = @SupplierName AND BillNo = @BillNo ORDER BY PurchaseDate";

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
                                var item = new ItemPurchase()
                                {
                                    SupplierName = reader["SupplierName"].ToString(),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Unit = reader["Unit"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString()),
                                    PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"].ToString()),
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

        /// <summary>
        /// Returns total amount by supplier name and bill number
        /// </summary>
        /// <param name="supplierName"></param>
        /// <param name="billNo"></param>
        /// <returns>decimal</returns>
        public decimal GetTotalAmountBySupplierAndBill(string supplierName, string billNo)
        {
            decimal totalAmount = 0.0m;
            string connectionString = GetConnectionString();
            var query = @"SELECT Sum(Quantity * PurchasePrice) AS 'TotalPurchasePrice' " +
                " FROM " + TABLE_NAME + 
                " WHERE 1=1" +
                " AND SupplierName = @SupplierName" +
                " AND BillNo = @BillNo";

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

        /// <summary>
        /// Get total count of matching filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Total Count</returns>
        public decimal GetTotalItemCount(DTOs.StockFilterView filter)
        {
            decimal totalCount = 0.0m;
            string connectionString = GetConnectionString();
            var query = @"SELECT Sum(Quantity) AS 'Quantity' " +
                " FROM " + TABLE_NAME + " it INNER JOIN Item i ON it.ItemId = i.Id" +
                " WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += " AND Code = @Code";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += " AND PurchaseDate BETWEEN @DateFrom AND @DateTo";
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
                            totalCount = Convert.ToDecimal(result);
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

        public decimal GetTotalItemCount(string code)
        {
            decimal totalCount = 0.0m;
            string connectionString = GetConnectionString();
            var query = @"SELECT Sum(Quantity) AS 'Quantity' " +
                " FROM " + TABLE_NAME + " it INNER JOIN Item i ON it.ItemId = i.Id" +
                " WHERE 1=1 AND Code = @Code";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", ((object)code) ?? DBNull.Value);
                        
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            totalCount = Convert.ToDecimal(result);
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

        /// <summary>
        /// Get total amount of matching filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Total Amount</returns>
        public decimal GetTotalItemAmount(DTOs.StockFilterView filter)
        {
            decimal totalAmount = 0.0m;
            string connectionString = GetConnectionString();
            var query = @"SELECT Sum(CAST((Quantity * PurchasePrice) AS DECIMAL(18,2))) AS 'Total' " +
                " FROM " + TABLE_NAME + " it INNER JOIN Item i ON it.ItemId = i.Id" +
                " WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filter?.ItemCode))
            {
                query += " AND Code = @Code";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += " AND PurchaseDate BETWEEN @DateFrom AND @DateTo";
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

        /// <summary>
        /// Get list of available item names
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllItemNames()
        {
            var itemNames = new List<string>();
            string connectionString = GetConnectionString();
            var query = @"SELECT DISTINCT Name FROM Item ORDER BY NAME ASC";

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

        /// <summary>
        /// Get list of available item codes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllItemCodes()
        {
            var itemCodes = new List<string>();
            string connectionString = GetConnectionString();
            var query = @"SELECT DISTINCT a.Code FROM Item a INNER JOIN " + TABLE_NAME + " b ON a.Id = b.ItemId ORDER BY 1 ASC";

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

        /// <summary>
        /// Returns a item with matching item name and brand
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>Item</returns>
        public ItemPurchase GetItem(long itemId)
        {
            string connectionString = GetConnectionString();
            var query = @"SELECT SupplierName, ItemId, Unit, Quantity, PurchasePrice, PurchaseDate, BillNo " +
                "FROM " + TABLE_NAME + " WHERE ItemId = @ItemId";
            var item = new ItemPurchase();
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
                                item.PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString());
                                item.PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"].ToString());
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

        /// <summary>
        ///  Returns item id with matching supplier name and bill no
        /// </summary>
        /// <param name="supplierName"></param>
        /// <param name="billNo"></param>
        /// <returns>itemId</returns>
        public long GetItemId(string supplierName, string billNo)
        {
            int itemId = 0;
            string connectionString = GetConnectionString();
            var query = @"SELECT ItemId" +
                " FROM " + TABLE_NAME + 
                " WHERE 1=1" +
                " AND SupplierName = @SupplierName" +
                " AND BillNo = @BillNo";

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
            string connectionString = GetConnectionString();
            string query = "SELECT TOP 1 [BillNo] FROM " + TABLE_NAME + " ORDER BY Id DESC";
            string billNo = string.Empty;
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

        /// <summary>
        /// Add a new item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Item</returns>
        public ItemPurchase AddItem(ItemPurchase item)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO " + TABLE_NAME +
                            "(" +
                                "SupplierName, ItemId, Unit, Quantity, PurchasePrice, PurchaseDate, BillNo " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@SupplierName, @ItemId, @Unit, @Quantity, @PurchasePrice, @PurchaseDate, @BillNo " +
                            ")";
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
                        command.Parameters.AddWithValue("@PurchasePrice", item.PurchasePrice);
                        command.Parameters.AddWithValue("@PurchaseDate", item.PurchaseDate);
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

        /// <summary>
        /// Update item with item code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns>Item</returns>
        public ItemPurchase UpdateItem(ItemPurchase item)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE " + TABLE_NAME + " SET " +
                    "Unit = @Unit, " +
                    "PurchasePrice = @PurchasePrice " +
                    "WHERE " +
                    "ItemId = @ItemId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", item.ItemId);
                        command.Parameters.AddWithValue("@Unit", item.Unit);
                        command.Parameters.AddWithValue("@PurchasePrice", item.PurchasePrice);
                       

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

        /// <summary>
        /// Delete item with matching name and brand
        /// </summary>
        /// <param name="name"></param>
        /// <param name="brand"></param>
        /// <returns>bool</returns>
        public bool DeleteItem(string name, string brand)
        {
            string connectionString = GetConnectionString();
            string query = "DELETE FROM " + TABLE_NAME +
                    " WHERE" +
                    " Name = @Name AND Brand=@Brand";
            bool result = false;

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

        /// <summary>
        /// Delete item transaction with matching supplier name and bill number
        /// </summary>
        /// <param name="supplierName"></param>
        /// <param name="billNo"></param>
        /// <returns>bool</returns>
        public bool DeleteItemTransactionBySupplierAndBill(string supplierName, string billNo)
        {
            string connectionString = GetConnectionString();
            string query = "DELETE FROM " + TABLE_NAME + 
                    " WHERE 1=1" +
                    " AND SupplierName = @SupplierName" +
                    " AND BillNo = @BillNo";
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", supplierName);
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

        private string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }
    }
}
