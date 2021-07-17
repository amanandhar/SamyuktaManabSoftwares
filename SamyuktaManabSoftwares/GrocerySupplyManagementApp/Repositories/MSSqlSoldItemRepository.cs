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
                "[Id], [EndOfDate], [MemberId], [InvoiceNo], " +
                "[ItemId], [Unit], [Quantity], [Price], " +
                "[Date] " +
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
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()),
                                    MemberId = reader["MemberId"].ToString(),
                                    InvoiceNo = reader["ItemId"].ToString(),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Unit = reader["Unit"].ToString(),
                                    Quantity = Convert.ToInt64(reader["Quantity"].ToString()),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString()),
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

        public SoldItem AddSoldItem(SoldItem soldItem)
        {
            string query = @"INSERT INTO " + Constants.TABLE_SOLD_ITEM + " " +
                    "( " +
                        "[EndOfDate], [MemberId], [InvoiceNo], [ItemId], [Unit], [Quantity], [Price], [Date]" +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDate, @MemberId, @InvoiceNo, @ItemId, @Unit, @Quantity, @Price, @Date " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDate", soldItem.EndOfDate);
                        command.Parameters.AddWithValue("@MemberId", soldItem.MemberId);
                        command.Parameters.AddWithValue("@InvoiceNo", soldItem.InvoiceNo);
                        command.Parameters.AddWithValue("@ItemId", soldItem.ItemId);
                        command.Parameters.AddWithValue("@Unit", soldItem.Unit);
                        command.Parameters.AddWithValue("@Quantity", soldItem.Quantity);
                        command.Parameters.AddWithValue("@Price", soldItem.Price);
                        command.Parameters.AddWithValue("@Date", soldItem.Date);

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

        public bool DeleteSoldItem(long soldItemId, SoldItem soldItem)
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

        public IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo)
        {
            var soldItemViewList = new List<SoldItemView>();
            var query = @"SELECT " +
                "a.[Id], c.[Code], c.[Name], c.[Brand], a.[Unit], a.[Quantity], a.[Price] " + 
                "CAST((a.[Quantity] * a.[Price]) AS DECIMAL(18,2)) AS Total, " +
                "b.[Date] " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " a " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " b " +
                "ON a.[InvoiceNo] = b.[InvoiceNo] " +
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
                                    Quantity = Convert.ToInt64(reader["Quantity"].ToString()),
                                    ItemPrice = Convert.ToDecimal(reader["Price"].ToString()),
                                    Total = Convert.ToDecimal(reader["Total"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
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
    }
}
