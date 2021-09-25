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
    public class MSSqlSoldItemRepository : ISoldItemRepository
    {
        private readonly string connectionString;

        public MSSqlSoldItemRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }
        
        public IEnumerable<SoldItem> GetSoldItems()
        {
            var soldItems = new List<SoldItem>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [MemberId], [InvoiceNo], " +
                "[ItemId], [ItemSubCode], [Profit], [Unit], [Quantity], [Price], " +
                "[AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " " +
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
                                var soldItem = new SoldItem
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    MemberId = reader["MemberId"].ToString(),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Profit = Convert.ToDecimal(reader["Profit"].ToString()),
                                    Unit = reader["Unit"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                soldItems.Add(soldItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return soldItems;
        }

        public SoldItem GetSoldItem(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo)
        {
            var soldItemViewList = new List<SoldItemView>();
            var query = @"SELECT " +
                "a.[Id], c.[Code], c.[Name], c.[Brand], c.[Unit], a.[Volume], a.[Quantity], a.[Price], " +
                "CAST((a.[Quantity] * a.[Price]) AS DECIMAL(18,2)) AS Total, " +
                "b.[AddedDate] " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " a " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " b " +
                "ON a.[InvoiceNo] = b.[InvoiceNo] " +
                "AND ISNULL(b.[IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') " +
                "INNER JOIN " + Constants.TABLE_ITEM + " c " +
                "ON a.[ItemId] = c.[Id] " +
                "WHERE 1 = 1 " +
                "AND a.[InvoiceNo] = @InvoiceNo " +
                "ORDER BY 1 ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", invoiceNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var soldItemView = new SoldItemView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    ItemCode = reader["Code"].ToString(),
                                    ItemName = reader["Name"].ToString(),
                                    ItemBrand = reader["Brand"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    Volume = Convert.ToInt64(reader["Volume"].ToString()),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    ItemPrice = Convert.ToDecimal(reader["Price"].ToString()),
                                    Total = Convert.ToDecimal(reader["Total"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString())
                                };

                                soldItemViewList.Add(soldItemView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return soldItemViewList;
        }

        public decimal GetSoldItemTotalQuantity(StockFilter stockFilter)
        {
            decimal totalCount = 0.00m;
            var query = @"SELECT " +
                "CAST(SUM(si.[Volume] * si.[Quantity]) AS DECIMAL(18,2)) " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " si " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "ON si.[InvoiceNo] = ut.[InvoiceNo] " +
                "AND ISNULL(ut.[IncomeExpense], '') NOT IN ('" + Constants.DELIVERY_CHARGE + "', '" + Constants.SALES_DISCOUNT + "') " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.ItemCode))
            {
                query += "AND i.[Code] = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateFrom) && !string.IsNullOrWhiteSpace(stockFilter?.DateTo))
            {
                query += "AND ut.[EndOfDay] >= @DateFrom AND ut.[EndOfDay] <= @DateTo ";
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

        public decimal GetSoldItemTotalAmount(StockFilter stockFilter)
        {
            decimal totalAmount = 0.0m;
            var query = @"SELECT " +
                "CAST(SUM(si.[Quantity] * si.[Price]) AS DECIMAL(18,2)) AS 'Total' " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " si " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.ItemCode))
            {
                query += "AND i.[Code] = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateFrom) && !string.IsNullOrWhiteSpace(stockFilter?.DateTo))
            {
                query += "AND si.[EndOfDay] BETWEEN @DateFrom AND @DateTo ";
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

        public IEnumerable<string> GetSoldItemCodes()
        {
            var itemCodes = new List<string>();
            var query = @"SELECT " +
                "DISTINCT [Code] " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " si " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "ORDER BY [Code] ";
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
                                var itemCode = reader["Code"].ToString();
                                itemCodes.Add(itemCode);
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

        public SoldItem AddSoldItem(SoldItem soldItem)
        {
            string query = @"INSERT INTO " + Constants.TABLE_SOLD_ITEM + " " +
                    "( " +
                        "[EndOfDay], [MemberId], [InvoiceNo], [ItemId], [Profit], [Unit], [Volume], [Quantity], [Price], [AddedDate], [UpdatedDate]  " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @MemberId, @InvoiceNo, @ItemId, @Profit, @Unit, @Volume, @Quantity, @Price, @AddedDate, @UpdatedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", soldItem.EndOfDay);
                        command.Parameters.AddWithValue("@MemberId", soldItem.MemberId);
                        command.Parameters.AddWithValue("@InvoiceNo", soldItem.InvoiceNo);
                        command.Parameters.AddWithValue("@ItemId", soldItem.ItemId);
                        command.Parameters.AddWithValue("@Profit", soldItem.Profit);
                        command.Parameters.AddWithValue("@Unit", soldItem.Unit);
                        command.Parameters.AddWithValue("@Volume", soldItem.Volume);
                        command.Parameters.AddWithValue("@Quantity", soldItem.Quantity);
                        command.Parameters.AddWithValue("@Price", soldItem.Price);
                        command.Parameters.AddWithValue("@AddedDate", soldItem.AddedDate);
                        command.Parameters.AddWithValue("@UpdatedDate", soldItem.UpdatedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return soldItem;
        }

        public SoldItem UpdateSoldItem(long soldItemId, SoldItem soldItem)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteSoldItem(string invoiceNo)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND InvoiceNo = @InvoiceNo ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
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

        public bool DeleteSoldItemAfterEndOfDay(string endOfDay)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " " +
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
