using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
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

        public IEnumerable<CodedItem> GetCodedItems()
        {
            var codedItems = new List<CodedItem>();
            var query = @"SELECT " +
                "[Id], [ItemId], [ItemSubCode], [Unit], " +
                "[Price], [Quantity], [TotalPrice], " +
                "[ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit], [Date]  " +
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
                                var codedItem = new CodedItem
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

                                codedItems.Add(codedItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return codedItems;
        }

        public CodedItem GetCodedItem(long id)
        {
            var query = @"SELECT " +
                "[Id], [ItemId], [ItemSubCode], [Unit], " +
                "[Price], [Quantity], [TotalPrice], " +
                "[ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit], [Date] " +
                "FROM " + Constants.TABLE_CODED_ITEM + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id ";
            var codedItem = new CodedItem();
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
                                codedItem.Id = Convert.ToInt64(reader["Id"].ToString());
                                codedItem.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                codedItem.ItemSubCode = reader["ItemSubCode"].ToString();
                                codedItem.Unit = reader["Unit"].ToString();
                                codedItem.Price = Convert.ToDecimal(reader["Price"].ToString());
                                codedItem.Quantity = Convert.ToInt64(reader["Quantity"].ToString());
                                codedItem.TotalPrice = Convert.ToDecimal(reader["TotalPrice"].ToString());
                                codedItem.ProfitPercent = Convert.ToDecimal(reader["ProfitPercent"].ToString());
                                codedItem.ProfitAmount = Convert.ToDecimal(reader["ProfitAmount"].ToString());
                                codedItem.SalesPrice = Convert.ToDecimal(reader["SalesPrice"].ToString());
                                codedItem.SalesPricePerUnit = Convert.ToDecimal(reader["SalesPricePerUnit"].ToString());
                                codedItem.Date = Convert.ToDateTime(reader["Date"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return codedItem;
        }

        public IEnumerable<CodedItemView> GetCodedItemViewList()
        {
            var codedItemViewList = new List<CodedItemView>();
            var query = @"SELECT " +
                "DISTINCT ci.[Id], i.[Code], ci.[ItemSubCode], i.[Name], i.[Brand] " +
                "FROM " + Constants.TABLE_CODED_ITEM + " ci " +
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
                                var codedItemView = new CodedItemView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Code = reader["Code"].ToString(),
                                    SubCode = reader["ItemSubCode"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString()
                                };

                                codedItemViewList.Add(codedItemView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return codedItemViewList;
        }

        public IEnumerable<CodedItemView> GetCodedUnCodedItemViewList()
        {
            var codedItemViewList = new List<CodedItemView>();
            var query = @"SELECT " +
                "DISTINCT pi.[Id], i.[Code], ISNULL(ci.[ItemSubCode], '') AS [ItemSubCode], i.[Name], i.[Brand] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " pi " + 
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON pi.[ItemId] = i.[Id] " +
                "LEFT JOIN " + Constants.TABLE_CODED_ITEM + " ci " +
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
                                var codedItemView = new CodedItemView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Code = reader["Code"].ToString(),
                                    SubCode = reader["ItemSubCode"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString()
                                };

                                codedItemViewList.Add(codedItemView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return codedItemViewList;
        }

        public CodedItem AddCodedItem(CodedItem codedItem)
        {
            string query = @"INSERT INTO " + Constants.TABLE_CODED_ITEM + " " +
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
                        command.Parameters.AddWithValue("@ItemId", codedItem.ItemId);
                        command.Parameters.AddWithValue("@ItemSubCode", codedItem.ItemSubCode);
                        command.Parameters.AddWithValue("@Unit", codedItem.Unit);
                        command.Parameters.AddWithValue("@Price", codedItem.Price);
                        command.Parameters.AddWithValue("@Quantity", codedItem.Quantity);
                        command.Parameters.AddWithValue("@TotalPrice", codedItem.TotalPrice);
                        command.Parameters.AddWithValue("@ProfitPercent", codedItem.ProfitPercent);
                        command.Parameters.AddWithValue("@ProfitAmount", codedItem.ProfitAmount);
                        command.Parameters.AddWithValue("@SalesPrice", codedItem.SalesPrice);
                        command.Parameters.AddWithValue("@SalesPricePerUnit", codedItem.SalesPricePerUnit);
                        command.Parameters.AddWithValue("@Date", codedItem.Date);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return codedItem;
        }

        public CodedItem UpdateCodedItem(long id, CodedItem codedItem)
        {
            string query = @"UPDATE " + Constants.TABLE_CODED_ITEM + " " + 
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
                        command.Parameters.AddWithValue("@ItemId", codedItem.ItemId);
                        command.Parameters.AddWithValue("@ItemSubCode", codedItem.ItemSubCode);
                        command.Parameters.AddWithValue("@Unit", codedItem.Unit);
                        command.Parameters.AddWithValue("@Price", codedItem.Price);
                        command.Parameters.AddWithValue("@Quantity", codedItem.Quantity);
                        command.Parameters.AddWithValue("@TotalPrice", codedItem.TotalPrice);
                        command.Parameters.AddWithValue("@ProfitPercent", codedItem.ProfitPercent);
                        command.Parameters.AddWithValue("@ProfitAmount", codedItem.ProfitAmount);
                        command.Parameters.AddWithValue("@SalesPrice", codedItem.SalesPrice);
                        command.Parameters.AddWithValue("@SalesPricePerUnit", codedItem.SalesPricePerUnit);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return codedItem;
        }

        public bool DeleteCodedItem(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_CODED_ITEM + " " +
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
