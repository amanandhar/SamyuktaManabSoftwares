using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlItemTransactionRepository : IItemTransactionRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";

        public MSSqlItemTransactionRepository()
        {

        }

        /// <summary>
        /// Returns list of items
        /// </summary>
        /// <returns>List of Items</returns>
        public IEnumerable<ItemTransaction> GetItems(bool showEmptyItemCode)
        {
            var items = new List<ItemTransaction>();
            string connectionString = GetConnectionString();
            var query = @"SELECT ItemId, Unit, Sum(Quantity) AS 'Quantity' FROM ItemTransaction";
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
                                var item = new ItemTransaction
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
        public IEnumerable<ItemTransactionGrid> GetItems(DTOs.StockFilterView filter)
        {
            var items = new List<ItemTransactionGrid>();
            string connectionString = GetConnectionString();
            var query = @"SELECT Code, Name, Brand, Unit, Sum(Quantity) AS 'Quantity'" +
                " FROM ItemTransaction it INNER JOIN Item i ON it.ItemId = i.Id" +
                " WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filter?.ItemName))
            {
                query += " AND Name = @Name";
            }

            if (!string.IsNullOrWhiteSpace(filter?.DateFrom) && !string.IsNullOrWhiteSpace(filter?.DateTo))
            {
                query += " AND PurchaseDate BETWEEN @DateFrom AND @DateTo";
            }

            query += " GROUP BY Code, Name, Brand, Unit";
            query += " ORDER BY Name, Brand ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", ((object)filter.ItemName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateFrom", ((object)filter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)filter.DateTo) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var itemTransaction = new ItemTransactionGrid
                                {
                                    Code = reader["Code"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                };

                                items.Add(itemTransaction);
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
        public IEnumerable<ItemTransaction> GetItemsBySupplierAndBill(string supplierName, string billNo)
        {
            var items = new List<ItemTransaction>();
            string connectionString = GetConnectionString();
            var query = @"SELECT SupplierName, ItemId, Unit, Quantity, PurchasePrice, PurchaseDate, BillNo, SellPrice" +
                " FROM ItemTransaction WHERE SupplierName = @SupplierName AND BillNo = @BillNo ORDER BY PurchaseDate";

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
                                var item = new ItemTransaction()
                                {
                                    SupplierName = reader["SupplierName"].ToString(),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Unit = reader["Unit"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString()),
                                    PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"].ToString()),
                                    BillNo = reader["BillNo"].ToString(),
                                    SellPrice = Convert.ToDecimal(reader.IsDBNull(7) ? "0" : reader["SellPrice"].ToString())
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
                " FROM ItemTransaction" +
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


                        totalAmount = Convert.ToDecimal(command.ExecuteScalar());
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
        public int GetTotalItemCount(DTOs.StockFilterView filter)
        {
            int totalCount = 0;
            string connectionString = GetConnectionString();
            var query = @"SELECT Sum(Quantity) AS 'Quantity' " +
                " FROM ItemTransaction it INNER JOIN Item i ON it.ItemId = i.Id" +
                " WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filter?.ItemName))
            {
                query += " AND Name = @Name";
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
                        command.Parameters.AddWithValue("@Name", ((object)filter.ItemName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateFrom", ((object)filter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)filter.DateTo) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            totalCount = Convert.ToInt32(command.ExecuteScalar());
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
        /// Returns a item with matching item name and brand
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>Item</returns>
        public ItemTransaction GetItem(long itemId)
        {
            string connectionString = GetConnectionString();
            var query = @"SELECT SupplierName, ItemId, Unit, Quantity, PurchasePrice, PurchaseDate, BillNo, SellPrice " +
                "FROM ItemTransaction WHERE ItemId = @ItemId";
            var item = new ItemTransaction();
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
                                item.SellPrice = Convert.ToDecimal(reader.IsDBNull(7) ? "0" : reader["SellPrice"].ToString());
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
        /// Add a new item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Item</returns>
        public ItemTransaction AddItem(ItemTransaction item)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO ItemTransaction " +
                            "(" +
                                "SupplierName, ItemId, Unit, Quantity, PurchasePrice, PurchaseDate, BillNo, SellPrice " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@SupplierName, @ItemId, @Unit, @Quantity, @PurchasePrice, @PurchaseDate, @BillNo, @SellPrice " +
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
                        command.Parameters.AddWithValue("@SellPrice", ((object)item.SellPrice) ?? DBNull.Value);
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
        public ItemTransaction UpdateItem(ItemTransaction item)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE ItemTransaction SET " +
                    "Unit = @Unit, " +
                    "PurchasePrice = @PurchasePrice, " +
                    "SellPrice = @SellPrice " +
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
                        command.Parameters.AddWithValue("@SellPrice", item.SellPrice);

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
            string query = "DELETE FROM ItemTransaction" +
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
        /// Delete items with matching supplier name and bill number
        /// </summary>
        /// <param name="billNo"></param>
        /// <returns>bool</returns>
        public bool DeleteItemBySupplierAndBill(string supplierName, string billNo)
        {
            string connectionString = GetConnectionString();
            string query = "DELETE FROM ItemTransaction" +
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
