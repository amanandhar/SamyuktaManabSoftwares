using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlStockRepository : IStockRepository
    {
        private readonly string connectionString;

        public MSSqlStockRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Stock> GetStocks()
        {
            var stocks = new List<Stock>();
            var query = @"SELECT " +
                "[Id], [ItemId], [Type], [TypeNo], " +
                "[PurchaseQuantity], [PurchasePrice], [PurchaseTotalPrice], [PurchaseGrandPrice], " +
                "[SalesQuantity], [SalesPrice], [SalesTotalPrice], [SalesGrandPrice], " +
                "[StockQuantity], [StockAmount], [PerUnitStockAmount], [Date]" +
                "FROM " + Constants.TABLE_STOCK;

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
                                var stock = new Stock
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Type = reader["Type"].ToString(),
                                    TypeNo = reader["TypeNo"].ToString(),
                                    PurchaseQuantity = Convert.ToInt32(reader["PurchaseQuantity"].ToString()),
                                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString()),
                                    PurchaseTotalPrice = Convert.ToDecimal(reader["PurchaseTotalPrice"].ToString()),
                                    PurchaseGrandPrice = Convert.ToDecimal(reader["PurchaseGrandPrice"].ToString()),
                                    SalesQuantity = Convert.ToInt32(reader["SalesQuantity"].ToString()),
                                    SalesPrice = Convert.ToDecimal(reader["SalesPrice"].ToString()),
                                    SalesTotalPrice = Convert.ToDecimal(reader["SalesTotalPrice"].ToString()),
                                    SalesGrandPrice = Convert.ToDecimal(reader["SalesGrandPrice"].ToString()),
                                    StockQuantity = Convert.ToDecimal(reader["StockQuantity"].ToString()),
                                    StockAmount = Convert.ToDecimal(reader["StockAmount"].ToString()),
                                    PerUnitStockAmount = Convert.ToDecimal(reader["PerUnitStockAmount"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
                                };

                                stocks.Add(stock);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return stocks;
        }

        public Stock GetStock(long id)
        {
            var stock = new Stock();
            var query = @"SELECT " +
                "[Id], [ItemId], [Type], [TypeNo], " +
                "[PurchaseQuantity], [PurchasePrice], [PurchaseTotalPrice], [PurchaseGrandPrice], " +
                "[SalesQuantity], [SalesPrice], [SalesTotalPrice], [SalesGrandPrice], " +
                "[StockQuantity], [StockAmount], [PerUnitStockAmount], [Date]" +
                "FROM " + Constants.TABLE_STOCK + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id";

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
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    stock.Id = Convert.ToInt64(reader["Id"].ToString());
                                    stock.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                    stock.Type = reader["Type"].ToString();
                                    stock.TypeNo = reader["TypeNo"].ToString();
                                    stock.PurchaseQuantity = Convert.ToInt32(reader["PurchaseQuantity"].ToString());
                                    stock.PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString());
                                    stock.PurchaseTotalPrice = Convert.ToDecimal(reader["PurchaseTotalPrice"].ToString());
                                    stock.PurchaseGrandPrice = Convert.ToDecimal(reader["PurchaseGrandPrice"].ToString());
                                    stock.SalesQuantity = Convert.ToInt32(reader["SalesQuantity"].ToString());
                                    stock.SalesPrice = Convert.ToDecimal(reader["SalesPrice"].ToString());
                                    stock.SalesTotalPrice = Convert.ToDecimal(reader["SalesTotalPrice"].ToString());
                                    stock.SalesGrandPrice = Convert.ToDecimal(reader["SalesGrandPrice"].ToString());
                                    stock.StockQuantity = Convert.ToDecimal(reader["StockQuantity"].ToString());
                                    stock.StockAmount = Convert.ToDecimal(reader["StockAmount"].ToString());
                                    stock.PerUnitStockAmount = Convert.ToDecimal(reader["PerUnitStockAmount"].ToString());
                                    stock.Date = Convert.ToDateTime(reader["Date"].ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return stock;
        }

        public decimal GetTotalSalesPrice(long itemId)
        {
            decimal total = 0.0m;
            string query = @"SELECT " +
                "ISNULL(SUM([SalesPrice], 0) " +
                "FROM " + Constants.TABLE_STOCK + " " +
                "WHERE 1 = 1 " +
                "AND [ItemId] = @ItemId ";

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
                            total = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return total;
        }

        public decimal GetTotalStockQuantity(long itemId)
        {
            decimal total = 0.0m;
            string query = @"SELECT " +
                "ISNULL(SUM([StockQuantity], 0) " +
                "FROM " + Constants.TABLE_STOCK + " " +
                "WHERE 1 = 1 " +
                "AND [ItemId] = @ItemId ";

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
                            total = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return total;
        }

        public decimal GetLatestPerUnitStockAmount(long itemId)
        {
            decimal total = 0.0m;
            string query = @"SELECT " +
                "TOP 1 [PerUnitStockAmount] " +
                "FROM " + Constants.TABLE_STOCK + " " +
                "WHERE 1 = 1 " +
                "AND [ItemId] = @ItemId " +
                "ORDER BY [Id] DESC";

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
                            total = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return total;
        }

        public Stock AddStock(Stock stock)
        {
            string query = @"INSERT INTO " +
                    " " + Constants.TABLE_STOCK + " " +
                    "( " +
                        "[ItemId], [Type], [TypeNo], " +
                        "[PurchaseQuantity], [PurchasePrice], [PurchaseTotalPrice], [PurchaseGrandPrice], " +
                        "[SalesQuantity], [SalesPrice], [SalesTotalPrice], [SalesGrandPrice], " +
                        "[StockQuantity], [StockAmount], [PerUnitStockAmount], [Date] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@ItemId, @Type, @TypeNo, " +
                        "@PurchaseQuantity, @PurchasePrice, @PurchaseTotalPrice, @PurchaseGrandPrice, " +
                        "@SalesQuantity, @SalesPrice, @SalesTotalPrice, @SalesGrandPrice, " +
                        "@StockQuantity, @StockAmount, @PerUnitStockAmount, @Date " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", stock.ItemId);
                        command.Parameters.AddWithValue("@Type", stock.Type);
                        command.Parameters.AddWithValue("@TypeNo", stock.TypeNo);
                        command.Parameters.AddWithValue("@PurchaseQuantity", stock.PurchaseQuantity);
                        command.Parameters.AddWithValue("@PurchasePrice", stock.PurchasePrice);
                        command.Parameters.AddWithValue("@PurchaseTotalPrice", stock.PurchaseTotalPrice);
                        command.Parameters.AddWithValue("@PurchaseGrandPrice", stock.PurchaseGrandPrice);
                        command.Parameters.AddWithValue("@SalesQuantity", stock.SalesQuantity);
                        command.Parameters.AddWithValue("@SalesPrice", stock.SalesPrice);
                        command.Parameters.AddWithValue("@SalesTotalPrice", stock.SalesTotalPrice);
                        command.Parameters.AddWithValue("@SalesGrandPrice", stock.SalesGrandPrice);
                        command.Parameters.AddWithValue("@StockQuantity", stock.StockQuantity);
                        command.Parameters.AddWithValue("@StockAmount", stock.StockAmount);
                        command.Parameters.AddWithValue("@PerUnitStockAmount", stock.PerUnitStockAmount);
                        command.Parameters.AddWithValue("@Date", stock.Date);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return stock;
        }

        public Stock UpdateStock(long id, Stock stock)
        {
            string query = @"UPDATE " + Constants.TABLE_STOCK + " " +
                    "SET " +
                    "[ItemId] = @ItemId, " +
                    "[Type] = @Type, " + 
                    "[TypeNo] = @TypeNo, " +
                    "[PurchaseQuantity] = @PurchaseQuantity, " +
                    "[PurchasePrice] = @PurchasePrice, " +
                    "[PurchaseTotalPrice] = @PurchaseTotalPrice, " +
                    "[PurchaseGrandPrice] = @PurchaseGrandPrice, " +
                    "[SalesQuantity] = @SalesQuantity, " +
                    "[SalesPrice] = @SalesPrice, " +
                    "[SalesTotalPrice] = @SalesTotalPrice, " +
                    "[SalesGrandPrice] = @SalesGrandPrice, " +
                    "[StockQuantity] = @StockQuantity, " +
                    "[StockAmount] = @StockAmount, " +
                    "[PerUnitStockAmount] = @PerUnitStockAmount " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@ItemId", stock.ItemId);
                        command.Parameters.AddWithValue("@Type", stock.Type);
                        command.Parameters.AddWithValue("@TypeNo", stock.TypeNo);
                        command.Parameters.AddWithValue("@PurchaseQuantity", stock.PurchaseQuantity);
                        command.Parameters.AddWithValue("@PurchasePrice", stock.PurchasePrice);
                        command.Parameters.AddWithValue("@PurchaseTotalPrice", stock.PurchaseTotalPrice);
                        command.Parameters.AddWithValue("@PurchaseGrandPrice", stock.PurchaseGrandPrice);
                        command.Parameters.AddWithValue("@SalesQuantity", stock.SalesQuantity);
                        command.Parameters.AddWithValue("@SalesPrice", stock.SalesPrice);
                        command.Parameters.AddWithValue("@SalesTotalPrice", stock.SalesTotalPrice);
                        command.Parameters.AddWithValue("@SalesGrandPrice", stock.SalesGrandPrice);
                        command.Parameters.AddWithValue("@StockQuantity", stock.StockQuantity);
                        command.Parameters.AddWithValue("@StockAmount", stock.StockAmount);
                        command.Parameters.AddWithValue("@PerUnitStockAmount", stock.PerUnitStockAmount);
                        command.Parameters.AddWithValue("@Date", stock.Date);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return stock;
        }

        public bool DeleteStock(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_STOCK + " " +
                    "WHERE 1 = 1 " +
                    "[Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
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
