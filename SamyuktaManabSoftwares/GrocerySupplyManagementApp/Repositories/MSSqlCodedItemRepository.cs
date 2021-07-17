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
                "[PurchasePrice], [CurrentPurchasePrice], [Quantity], [Price], " +
                "[ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit] " +
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
                                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString()),
                                    CurrentPurchasePrice = Convert.ToDecimal(reader["CurrentPurchasePrice"].ToString()),
                                    Quantity = Convert.ToInt64(reader["Quantity"].ToString()),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    ProfitPercent = Convert.ToDecimal(reader["ProfitPercent"].ToString()),
                                    ProfitAmount = Convert.ToDecimal(reader["ProfitAmount"].ToString()),
                                    SalesPrice = Convert.ToDecimal(reader["SalesPrice"].ToString()),
                                    SalesPricePerUnit = Convert.ToDecimal(reader["SalesPricePerUnit"].ToString())
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
                "[PurchasePrice], [CurrentPurchasePrice], [Quantity], [Price], " +
                "[ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit] " +
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
                                codedItem.PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString());
                                codedItem.CurrentPurchasePrice = reader.IsDBNull(6) ? 0.0m : Convert.ToDecimal(reader["CurrentPurchasePrice"].ToString());
                                codedItem.Quantity = Convert.ToInt64(reader["Quantity"].ToString());
                                codedItem.Price = Convert.ToDecimal(reader["Price"].ToString());
                                codedItem.ProfitPercent = Convert.ToDecimal(reader["ProfitPercent"].ToString());
                                codedItem.ProfitAmount = Convert.ToDecimal(reader["ProfitAmount"].ToString());
                                codedItem.SalesPrice = Convert.ToDecimal(reader["SalesPrice"].ToString());
                                codedItem.SalesPricePerUnit = Convert.ToDecimal(reader["SalesPricePerUnit"].ToString());
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
        
        public CodedItem AddCodedItem(CodedItem codedItem)
        {
            string query = @"INSERT INTO " + Constants.TABLE_CODED_ITEM + " " +
                    "( " +
                        "[ItemId], [ItemSubCode], [Unit], [PurchasePrice], [CurrentPurchasePrice], " +
                        "[Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@ItemId, @ItemSubCode, @Unit, @PurchasePrice, @CurrentPurchasePrice, " +
                        "@Quantity, @Price, @ProfitPercent, @ProfitAmount, @SalesPrice, @SalesPricePerUnit " +
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
                        command.Parameters.AddWithValue("@PurchasePrice", codedItem.PurchasePrice);
                        command.Parameters.AddWithValue("@CurrentPurchasePrice", ((object)codedItem?.CurrentPurchasePrice) ?? DBNull.Value );
                        command.Parameters.AddWithValue("@Quantity", codedItem.Quantity);
                        command.Parameters.AddWithValue("@Price", codedItem.Price);
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

        public CodedItem UpdateCodedItem(long id, CodedItem codedItem)
        {
            string query = @"UPDATE " + Constants.TABLE_CODED_ITEM + " " + 
                "SET " +
                "[ItemSubCode] = @ItemSubCode, " +
                "[Unit] = @Unit, " +
                "[PurchasePrice] = @PurchasePrice, " +
                "[CurrentPurchasePrice] = @CurrentPurchasePrice, " +
                "[Quantity] = @Quantity, " +
                "[Price] = @Price, " +
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
                        command.Parameters.AddWithValue("@PurchasePrice", codedItem.PurchasePrice);
                        command.Parameters.AddWithValue("@CurrentPurchasePrice", ((object)codedItem?.CurrentPurchasePrice) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", codedItem.Quantity);
                        command.Parameters.AddWithValue("@Price", codedItem.Price);
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

        public IEnumerable<CodedItemView> GetCodedItemViewList()
        {
            var codedItemViewList = new List<CodedItemView>();
            var query = @"SELECT " +
                "a.[Id] AS Id, [Code], [ItemSubCode], [Name], [Brand] " +
                "FROM " + Constants.TABLE_CODED_ITEM + " a " +
                "INNER JOIN " + Constants.TABLE_ITEM + " b " +
                "ON a.[ItemId] = b.Id " +
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
                                var codedItemView = new CodedItemView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Code = reader["Code"].ToString(),
                                    ItemSubCode = reader["ItemSubCode"].ToString(),
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
    }
}
