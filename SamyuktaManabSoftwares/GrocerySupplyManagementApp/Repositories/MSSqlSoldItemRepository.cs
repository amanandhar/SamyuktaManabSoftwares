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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
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
                "[ItemId], [Profit], [Unit], [Volume], [Quantity], [Price], " +
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
                                    Volume = Convert.ToDecimal(reader["Volume"].ToString()),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = reader.IsDBNull(11) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                soldItems.Add(soldItem);
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

            return soldItems;
        }

        public IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo)
        {
            var soldItemViewList = new List<SoldItemView>();
            var query = @"SELECT " +
                "a.[Id], b.[Code], b.[Name], b.[Unit], a.[Volume], a.[Quantity], a.[Price], " +
                "CAST((a.[Quantity] * a.[Price]) AS DECIMAL(18,2)) AS Total, " +
                "a.[AddedDate] " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " a " +
                "INNER JOIN " + Constants.TABLE_ITEM + " b " +
                "ON a.[ItemId] = b.[Id] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(a.[InvoiceNo], '') = @InvoiceNo " +
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
                                    Unit = reader["Unit"].ToString(),
                                    Volume = Convert.ToDecimal(reader["Volume"].ToString()),
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
                logger.Error(ex);
                throw ex;
            }

            return soldItemViewList;
        }

        public decimal GetSoldItemTotalQuantity(StockFilter stockFilter)
        {
            decimal totalCount = Constants.DEFAULT_DECIMAL_VALUE;
            var query = @"SELECT " +
                "CAST(SUM(si.[Volume] * si.[Quantity]) AS DECIMAL(18,3)) " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " si " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON ISNULL(si.[ItemId], '') = i.[Id] " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.ItemCode))
            {
                query += "AND ISNULL(i.[Code], '') = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateFrom))
            {
                query += "AND si.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateTo))
            {
                query += "AND si.[EndOfDay] <= @DateTo ";
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
                logger.Error(ex);
                throw ex;
            }

            return totalCount;
        }

        public string GetLastInvoiceNumber()
        {
            string invoiceNumber = string.Empty;
            string query = @"SELECT " +
                "TOP 1 " +
                "[InvoiceNo] " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND [InvoiceNo] IS NOT NULL " +
                "ORDER BY [Id] DESC ";
            
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
                            invoiceNumber = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return invoiceNumber;
        }

        public IEnumerable<string> GetInvoiceNumbers()
        {
            var invoiceNumbers = new List<string>();
            var query = @"SELECT " +
                "DISTINCT [InvoiceNo] " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND [InvoiceNo] IS NOT NULL " +
                "ORDER BY [InvoiceNo] ";
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
                                var invoiceNo = reader["InvoiceNo"].ToString();
                                invoiceNumbers.Add(invoiceNo);
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

            return invoiceNumbers;
        }

        public SoldItem AddSoldItem(SoldItem soldItem)
        {
            string query = @"INSERT INTO " + Constants.TABLE_SOLD_ITEM + " " +
                    "( " +
                        "[EndOfDay], [MemberId], [InvoiceNo], [ItemId], [Profit], [Unit], [Volume], [Quantity], [Price], [AddedBy], [AddedDate]  " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @MemberId, @InvoiceNo, @ItemId, @Profit, @Unit, @Volume, @Quantity, @Price, @AddedBy, @AddedDate " +
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
                        command.Parameters.AddWithValue("@AddedBy", soldItem.AddedBy);
                        command.Parameters.AddWithValue("@AddedDate", soldItem.AddedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return soldItem;
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
                logger.Error(ex);
                throw ex;
            }

            return result;
        }
    }
}
