using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlIncomeDetailRepository : IIncomeDetailRepository
    {
        private readonly string connectionString;

        public MSSqlIncomeDetailRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<IncomeDetailView> GetDeliveryCharge()
        {
            var incomeDetails = new List<IncomeDetailView>();
            var query = @"SELECT " +
                "[Id], [EndOfDate], [Bank], [IncomeExpense], [ReceivedAmount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] = '" + Constants.RECEIPT + "' " +
                "AND [IncomeExpense] = '" + Constants.DELIVERY_CHARGE + "' ";

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
                                var incomeDetail = new IncomeDetailView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()).ToString("yyyy-MM-dd"),
                                    InvoiceNo = reader["IncomeExpense"].ToString(),
                                    ItemCode = string.Empty,
                                    ItemName = reader["Bank"].ToString(),
                                    ItemBrand = string.Empty,
                                    Quantity = 0,
                                    ProfitAmount = 0.0m,
                                    Total = Convert.ToDecimal(reader["ReceivedAmount"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return incomeDetails;
        }

        public IEnumerable<IncomeDetailView> GetMemberFee()
        {
            var incomeDetails = new List<IncomeDetailView>();
            var query = @"SELECT " +
                "[Id], [EndOfDate], [Bank], [IncomeExpense], [ReceivedAmount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] = '" + Constants.RECEIPT + "' " +
                "AND [IncomeExpense] = '" + Constants.MEMBER_FEE + "' ";

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
                                var incomeDetail = new IncomeDetailView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()).ToString("yyyy-MM-dd"),
                                    InvoiceNo = reader["IncomeExpense"].ToString(),
                                    ItemCode = string.Empty,
                                    ItemName = reader["Bank"].ToString(),
                                    ItemBrand = string.Empty,
                                    Quantity = 0,
                                    ProfitAmount = 0.0m,
                                    Total = Convert.ToDecimal(reader["ReceivedAmount"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return incomeDetails;
        }

        public IEnumerable<IncomeDetailView> GetOtherIncome()
        {
            var incomeDetails = new List<IncomeDetailView>();
            var query = @"SELECT " +
                "[Id], [EndOfDate], [Bank], [IncomeExpense], [ReceivedAmount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] = '" + Constants.RECEIPT + "' " +
                "AND [IncomeExpense] = '" + Constants.OTHER_INCOME + "' ";

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
                                var incomeDetail = new IncomeDetailView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()).ToString("yyyy-MM-dd"),
                                    InvoiceNo = reader["IncomeExpense"].ToString(),
                                    ItemCode = string.Empty,
                                    ItemName = reader["Bank"].ToString(),
                                    ItemBrand = string.Empty,
                                    Quantity = 0,
                                    ProfitAmount = 0.0m,
                                    Total = Convert.ToDecimal(reader["ReceivedAmount"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return incomeDetails;
        }

        public IEnumerable<IncomeDetailView> GetSalesProfit()
        {
            var incomeDetails = new List<IncomeDetailView>();
            var query = @"SELECT " +
                "ut.[Id] AS 'Id', ut.[EndOfDate] AS 'EndOfDate', si.[InvoiceNo] AS 'InvoiceNo', " +
                "i.[Code] AS 'ItemCode', i.[Name] AS 'ItemName', i.[Brand] AS 'ItemBrand', " +
                "si.[Quantity] AS 'Quantity', ci.[ProfitAmount] AS 'ProfitAmount', " +
                "CAST((si.[Quantity] * ci.[ProfitAmount]) AS DECIMAL(18, 2)) AS 'Total' " +
                "FROM " + Constants.TABLE_ITEM + " i " +
                "INNER JOIN " + Constants.TABLE_CODED_ITEM + " ci " +
                "ON i.[Id] = ci.[ItemId] " +
                "INNER JOIN " + Constants.TABLE_SOLD_ITEM + " si " +
                "ON i.[Id] = si.[ItemId] " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "ON si.[InvoiceNo] = ut.[InvoiceNo] " +
                "WHERE 1 = 1 ";

            query += "ORDER BY ut.[Date] DESC ";

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
                                var incomeDetail = new IncomeDetailView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()).ToString("yyyy-MM-dd"),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["ItemName"].ToString(),
                                    ItemBrand = reader["ItemBrand"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                                    ProfitAmount = Convert.ToDecimal(reader["ProfitAmount"].ToString()),
                                    Total = Convert.ToDecimal(reader["Total"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return incomeDetails;
        }
    }
}
