using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlPricedItemRepository : IPricedItemRepository
    {
        private readonly string connectionString;

        public MSSqlPricedItemRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<PricedItem> GetPricedItems()
        {
            var pricedItems = new List<PricedItem>();
            var query = @"SELECT " +
                "[Id], [ItemId], [ItemSubCode], [Unit], " +
                "[Price], [Quantity], [TotalPrice], " +
                "[ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit], [Date]  " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " " +
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
                                var pricedItem = new PricedItem
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    ItemSubCode = reader["ItemSubCode"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    Quantity = Convert.ToInt64(reader["Quantity"].ToString()),
                                    TotalPrice = Convert.ToDecimal(reader["TotalPrice"].ToString()),
                                    ProfitPercent = Convert.ToDecimal(reader["ProfitPercent"].ToString()),
                                    ProfitAmount = Convert.ToDecimal(reader["ProfitAmount"].ToString()),
                                    SalesPrice = Convert.ToDecimal(reader["SalesPrice"].ToString()),
                                    SalesPricePerUnit = Convert.ToDecimal(reader["SalesPricePerUnit"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
                                };

                                pricedItems.Add(pricedItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return pricedItems;
        }

        public PricedItem GetPricedItem(long id)
        {
            var query = @"SELECT " +
                "[Id], [ItemId], [ItemSubCode], [Unit], " +
                "[Price], [Quantity], [TotalPrice], " +
                "[ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit], [Date] " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id ";
            var pricedItem = new PricedItem();
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
                                pricedItem.Id = Convert.ToInt64(reader["Id"].ToString());
                                pricedItem.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                pricedItem.ItemSubCode = reader["ItemSubCode"].ToString();
                                pricedItem.Unit = reader["Unit"].ToString();
                                pricedItem.Price = Convert.ToDecimal(reader["Price"].ToString());
                                pricedItem.Quantity = Convert.ToInt64(reader["Quantity"].ToString());
                                pricedItem.TotalPrice = Convert.ToDecimal(reader["TotalPrice"].ToString());
                                pricedItem.ProfitPercent = Convert.ToDecimal(reader["ProfitPercent"].ToString());
                                pricedItem.ProfitAmount = Convert.ToDecimal(reader["ProfitAmount"].ToString());
                                pricedItem.SalesPrice = Convert.ToDecimal(reader["SalesPrice"].ToString());
                                pricedItem.SalesPricePerUnit = Convert.ToDecimal(reader["SalesPricePerUnit"].ToString());
                                pricedItem.Date = Convert.ToDateTime(reader["Date"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return pricedItem;
        }

        public IEnumerable<PricedItemView> GetPricedItemViewList()
        {
            var pricedItemViewList = new List<PricedItemView>();
            var query = @"SELECT " +
                "DISTINCT ci.[Id], i.[Code], ci.[ItemSubCode], i.[Name], i.[Brand] " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " ci " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON ci.[ItemId] = i.[Id] " +
                "ORDER BY i.[Code] ";

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
                                var pricedItemView = new PricedItemView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Code = reader["Code"].ToString(),
                                    SubCode = reader["ItemSubCode"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString()
                                };

                                pricedItemViewList.Add(pricedItemView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return pricedItemViewList;
        }

        public IEnumerable<UnpricedItemView> GetUnpricedItemViewList()
        {
            var unpricedItemViewList = new List<UnpricedItemView>();
            var query = @"SELECT " +
                "DISTINCT i.[Id], i.[Code], i.[Name], i.[Brand] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " pi " + 
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON pi.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND NOT EXISTS (SELECT 1 FROM PricedItem WHERE [ItemId] = pi.[ItemId]) " +
                "ORDER BY i.[Code] ";

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
                                var unpricedItemView = new UnpricedItemView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Code = reader["Code"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString()
                                };

                                unpricedItemViewList.Add(unpricedItemView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return unpricedItemViewList;
        }

        public PricedItem AddPricedItem(PricedItem pricedItem)
        {
            string query = @"INSERT INTO " + Constants.TABLE_PRICED_ITEM + " " +
                    "( " +
                        "[ItemId], [ItemSubCode], [Unit], [Price], [Quantity], [TotalPrice], " +
                        "[ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit], [Date] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@ItemId, @ItemSubCode, @Unit, @Price, @Quantity, @TotalPrice,  " +
                        "@ProfitPercent, @ProfitAmount, @SalesPrice, @SalesPricePerUnit, @Date " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", pricedItem.ItemId);
                        command.Parameters.AddWithValue("@ItemSubCode", pricedItem.ItemSubCode);
                        command.Parameters.AddWithValue("@Unit", pricedItem.Unit);
                        command.Parameters.AddWithValue("@Price", pricedItem.Price);
                        command.Parameters.AddWithValue("@Quantity", pricedItem.Quantity);
                        command.Parameters.AddWithValue("@TotalPrice", pricedItem.TotalPrice);
                        command.Parameters.AddWithValue("@ProfitPercent", pricedItem.ProfitPercent);
                        command.Parameters.AddWithValue("@ProfitAmount", pricedItem.ProfitAmount);
                        command.Parameters.AddWithValue("@SalesPrice", pricedItem.SalesPrice);
                        command.Parameters.AddWithValue("@SalesPricePerUnit", pricedItem.SalesPricePerUnit);
                        command.Parameters.AddWithValue("@Date", pricedItem.Date);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return pricedItem;
        }

        public PricedItem UpdatePricedItem(long id, PricedItem pricedItem)
        {
            string query = @"UPDATE " + Constants.TABLE_PRICED_ITEM + " " + 
                "SET " +
                "[ItemSubCode] = @ItemSubCode, " +
                "[Unit] = @Unit, " +
                "[Price] = @Price, " +
                "[Quantity] = @Quantity, " +
                "[TotalPrice] = @TotalPrice, " +
                "[ProfitPercent] = @ProfitPercent, " +
                "[ProfitAmount] = @ProfitAmount, " +
                "[SalesPrice] = @SalesPrice, " +
                "[SalesPricePerUnit] = @SalesPricePerUnit " +
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
                        command.Parameters.AddWithValue("@ItemId", pricedItem.ItemId);
                        command.Parameters.AddWithValue("@ItemSubCode", pricedItem.ItemSubCode);
                        command.Parameters.AddWithValue("@Unit", pricedItem.Unit);
                        command.Parameters.AddWithValue("@Price", pricedItem.Price);
                        command.Parameters.AddWithValue("@Quantity", pricedItem.Quantity);
                        command.Parameters.AddWithValue("@TotalPrice", pricedItem.TotalPrice);
                        command.Parameters.AddWithValue("@ProfitPercent", pricedItem.ProfitPercent);
                        command.Parameters.AddWithValue("@ProfitAmount", pricedItem.ProfitAmount);
                        command.Parameters.AddWithValue("@SalesPrice", pricedItem.SalesPrice);
                        command.Parameters.AddWithValue("@SalesPricePerUnit", pricedItem.SalesPricePerUnit);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return pricedItem;
        }

        public bool DeletePricedItem(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_PRICED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id ";

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
