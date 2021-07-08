using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlCodedItemRepository : ICodedItemRepository
    {
        private readonly string connectionString;

        public MSSqlCodedItemRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<CodedItem> GetPreparedItems()
        {
            var preparedItems = new List<CodedItem>();
            var query = @"SELECT " +
                "* " +
                "FROM " + Constants.TABLE_CODED_ITEM + " " +
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
                                var preparedItem = new CodedItem
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    ItemSubCode = reader["ItemSubCode"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    Stock = Convert.ToInt64(reader["Stock"].ToString()),
                                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString()),
                                    CurrentPurchasePrice = Convert.ToDecimal(reader["CurrentPurchasePrice"].ToString()),
                                    Quantity = Convert.ToInt64(reader["Quantity"].ToString()),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    ProfitPercent = Convert.ToDecimal(reader["ProfitPercent"].ToString()),
                                    ProfitAmount = Convert.ToDecimal(reader["ProfitAmount"].ToString()),
                                    SalesPrice = Convert.ToDecimal(reader["SalesPrice"].ToString()),
                                    SalesPricePerUnit = Convert.ToDecimal(reader["SalesPricePerUnit"].ToString())
                                };

                                preparedItems.Add(preparedItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return preparedItems;
        }

        public CodedItem GetPreparedItem(long id)
        {
            var query = @"SELECT " + 
                "* " +
                "FROM " + Constants.TABLE_CODED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id ";
            var preparedItem = new CodedItem();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                preparedItem.Id = Convert.ToInt64(reader["Id"].ToString());
                                preparedItem.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                preparedItem.ItemSubCode = reader["ItemSubCode"].ToString();
                                preparedItem.Unit = reader["Unit"].ToString();
                                preparedItem.Stock = Convert.ToInt64(reader["Stock"].ToString());
                                preparedItem.PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString());
                                preparedItem.CurrentPurchasePrice = reader.IsDBNull(6) ? 0.0m : Convert.ToDecimal(reader["CurrentPurchasePrice"].ToString());
                                preparedItem.Quantity = Convert.ToInt64(reader["Quantity"].ToString());
                                preparedItem.Price = Convert.ToDecimal(reader["Price"].ToString());
                                preparedItem.ProfitPercent = Convert.ToDecimal(reader["ProfitPercent"].ToString());
                                preparedItem.ProfitAmount = Convert.ToDecimal(reader["ProfitAmount"].ToString());
                                preparedItem.SalesPrice = Convert.ToDecimal(reader["SalesPrice"].ToString());
                                preparedItem.SalesPricePerUnit = Convert.ToDecimal(reader["SalesPricePerUnit"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return preparedItem;
        }

        public IEnumerable<ItemCodedView> GetPreparedItemGrid()
        {
            var preparedItemsGrid = new List<ItemCodedView>();
            var query = @"SELECT " +
                "a.Id AS Id, Code, ItemSubCode, Name, Brand " +
                "FROM " + Constants.TABLE_CODED_ITEM + " a " +
                "INNER JOIN " + Constants.TABLE_ITEM + " b " +
                "ON a.ItemId = b.Id " + 
                "ORDER BY Code ";

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
                                var preparedItemGrid = new ItemCodedView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Code = reader["Code"].ToString(),
                                    ItemSubCode = reader["ItemSubCode"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString()
                                };

                                preparedItemsGrid.Add(preparedItemGrid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return preparedItemsGrid;
        }

        public CodedItem AddPreparedItem(CodedItem preparedItem)
        {
            string query = @"INSERT INTO " + Constants.TABLE_CODED_ITEM + " " +
                    "( " +
                        "[ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [CurrentPurchasePrice], " +
                        "[Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@ItemId, @ItemSubCode, @Unit, @Stock, @PurchasePrice, @CurrentPurchasePrice, " +
                        "@Quantity, @Price, @ProfitPercent, @ProfitAmount, @SalesPrice, @SalesPricePerUnit " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", preparedItem.ItemId);
                        command.Parameters.AddWithValue("@ItemSubCode", preparedItem.ItemSubCode);
                        command.Parameters.AddWithValue("@Unit", preparedItem.Unit);
                        command.Parameters.AddWithValue("@Stock", preparedItem.Stock);
                        command.Parameters.AddWithValue("@PurchasePrice", preparedItem.PurchasePrice);
                        command.Parameters.AddWithValue("@CurrentPurchasePrice", ((object)preparedItem?.CurrentPurchasePrice) ?? DBNull.Value );
                        command.Parameters.AddWithValue("@Quantity", preparedItem.Quantity);
                        command.Parameters.AddWithValue("@Price", preparedItem.Price);
                        command.Parameters.AddWithValue("@ProfitPercent", preparedItem.ProfitPercent);
                        command.Parameters.AddWithValue("@ProfitAmount", preparedItem.ProfitAmount);
                        command.Parameters.AddWithValue("@SalesPrice", preparedItem.SalesPrice);
                        command.Parameters.AddWithValue("@SalesPricePerUnit", preparedItem.SalesPricePerUnit);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return preparedItem;
        }

        public CodedItem UpdatePreparedItem(long id, CodedItem preparedItem)
        {
            string query = @"UPDATE " + Constants.TABLE_CODED_ITEM + " " + 
                "SET " +
                "ItemSubCode = @ItemSubCode, " +
                "Unit = @Unit, " +
                "Stock = @Stock, " +
                "PurchasePrice = @PurchasePrice, " +
                "CurrentPurchasePrice = @CurrentPurchasePrice, " +
                "Quantity = @Quantity, " +
                "Price = @Price, " +
                "ProfitPercent = @ProfitPercent, " +
                "ProfitAmount = @ProfitAmount, " +
                "SalesPrice = @SalesPrice, " +
                "SalesPricePerUnit = @SalesPricePerUnit " +
                "WHERE 1 = 1 " +
                "AND Id = @Id ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@ItemId", preparedItem.ItemId);
                        command.Parameters.AddWithValue("@ItemSubCode", preparedItem.ItemSubCode);
                        command.Parameters.AddWithValue("@Unit", preparedItem.Unit);
                        command.Parameters.AddWithValue("@Stock", preparedItem.Stock);
                        command.Parameters.AddWithValue("@PurchasePrice", preparedItem.PurchasePrice);
                        command.Parameters.AddWithValue("@CurrentPurchasePrice", ((object)preparedItem?.CurrentPurchasePrice) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", preparedItem.Quantity);
                        command.Parameters.AddWithValue("@Price", preparedItem.Price);
                        command.Parameters.AddWithValue("@ProfitPercent", preparedItem.ProfitPercent);
                        command.Parameters.AddWithValue("@ProfitAmount", preparedItem.ProfitAmount);
                        command.Parameters.AddWithValue("@SalesPrice", preparedItem.SalesPrice);
                        command.Parameters.AddWithValue("@SalesPricePerUnit", preparedItem.SalesPricePerUnit);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return preparedItem;
        }

        public bool DeletePreparedItem(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_CODED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
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
