using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
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
        
        public IEnumerable<SoldItem> GetPosSoldItems()
        {
            var posSoldItems = new List<SoldItem>();
            var query = @"SELECT " +
                "* " +
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
                                var posSoldItem = new SoldItem
                                {
                                    Id = Convert.ToInt64(reader["InvoiceDate"].ToString()),
                                    InvoiceNo = reader["ItemId"].ToString(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["Unit"].ToString(),
                                    ItemBrand = reader["ItemBrand"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString())
                                };

                                posSoldItems.Add(posSoldItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posSoldItems;
        }

        public SoldItem GetPosSoldItem(long posSoldItemId)
        {
            throw new System.NotImplementedException();
        }

        public SoldItem AddPosSoldItem(SoldItem posSoldItem)
        {
            string query = @"INSERT INTO " + Constants.TABLE_SOLD_ITEM + " " +
                    "( " +
                        "[InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@InvoiceNo, @ItemCode, @ItemName, @ItemBrand, @Unit, @Price, @Quantity " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", posSoldItem.InvoiceNo);
                        command.Parameters.AddWithValue("@ItemCode", posSoldItem.ItemCode);
                        command.Parameters.AddWithValue("@ItemName", posSoldItem.ItemName);
                        command.Parameters.AddWithValue("@ItemBrand", posSoldItem.ItemBrand);
                        command.Parameters.AddWithValue("@Unit", posSoldItem.Unit);
                        command.Parameters.AddWithValue("@Price", posSoldItem.Price);
                        command.Parameters.AddWithValue("@Quantity", posSoldItem.Quantity);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posSoldItem;
        }

        public SoldItem UpdatePosSoldItem(long posSoldItemId, SoldItem posSoldItem)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePosSoldItem(long posSoldItemId, SoldItem posSoldItem)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePosSoldItem(string invoiceNo)
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

        public IEnumerable<SoldItemView> GetPosSoldItemGrid(string invoiceNo)
        {
            var posSoldItemGrids = new List<SoldItemView>();
            var query = @"SELECT " +
                "a.Id, a.ItemCode, a.ItemName, a.ItemBrand, a.Unit, a.Price, a.Quantity, " + 
                "CAST((a.Price * a.Quantity) AS DECIMAL(18,2)) AS Total, " +
                "b.Date " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " a " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " b " +
                "ON a.InvoiceNo = b.InvoiceNo " +
                "WHERE 1 = 1 " +
                "AND a.InvoiceNo = @InvoiceNo " +
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
                                var posSoldItemGrid = new SoldItemView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["ItemName"].ToString(),
                                    ItemBrand = reader["ItemBrand"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    ItemPrice = Convert.ToDecimal(reader["Price"].ToString()),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    Total = Convert.ToDecimal(reader["Total"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
                                };

                                posSoldItemGrids.Add(posSoldItemGrid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posSoldItemGrids;
        }
    }
}
