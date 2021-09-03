using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
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

        public IEnumerable<Stock> GetStocks(StockFilter stockFilter)
        {
            var stocks = new List<Stock>();
            var query = @"IF OBJECT_ID('tempdb..#Temp') IS NOT NULL
                        DROP TABLE #Temp

                        SELECT UnionTable.* 
                        INTO #Temp
                        FROM 
                        (
                        SELECT pi.[EndOfDay], 'Purchase' AS [Description], 
                        i.[Code] AS [ItemCode], i.[Name] AS [ItemName],
                        i.[Unit] AS [Unit],
                        pi.[Quantity] AS [PurchaseQuantity], 
                        0 AS [SalesQuantity],
                        pi.[Price] AS [PurchasePrice], 0.0 AS [SalesPrice],
                        pi.[AddedDate] FROM [PurchasedItem] pi
                        INNER JOIN 
                        [Item] i
                        ON pi.[ItemId] = i.[Id]
                        UNION
                        SELECT si.[EndOfDay], 'Sales' AS [Description], 
                        i.[Code] AS [ItemCode], i.[Name] AS [ItemName],
                        si.[Unit] AS [Unit],
                        0 AS [PurchaseQuantity], 
                        (si.[Volume] * si.[Quantity]) AS [SalesQuantity],
                        0.0 AS [PurchasePrice], si.[Price] AS [SalesPrice],
                        si.[AddedDate] FROM [SoldItem] si
                        INNER JOIN 
                        [Item] i
                        ON si.[ItemId] = i.[Id]
                        ) UnionTable
                        ORDER BY UnionTable.[ItemCode], UnionTable.[AddedDate]

                        SELECT t.*, 
                        (
	                        SELECT SUM(u.[PurchaseQuantity] - u.[SalesQuantity])
	                        FROM #Temp u
	                        WHERE 1 = 1 
	                        AND u.[AddedDate] <= t.[AddedDate]
	                        AND u.[ItemCode] = t.[ItemCode]
                        ) AS [StockQuantity],
                        CAST((t.[PurchasePrice] * t.[PurchaseQuantity]) AS DECIMAL(18,2)) AS [TotalPurchasePrice]
                        FROM #Temp t WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.ItemCode))
            {
                query += "AND t.[ItemCode] = @Code ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateFrom))
            {
                query += "AND t.[EndOfDay] >= @DateFrom ";
            }

            if(!string.IsNullOrWhiteSpace(stockFilter?.DateTo))
            {
                query += "AND t.[EndOfDay] <= @DateTo ";
            }

            query += "ORDER BY t.[ItemCode], t.[AddedDate]";

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

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var stock = new Stock
                                {
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["ItemName"].ToString(),
                                    ItemUnit = reader["Unit"].ToString(),
                                    PurchaseQuantity = Convert.ToDecimal(reader["PurchaseQuantity"].ToString()),
                                    SalesQuantity = Convert.ToDecimal(reader["SalesQuantity"].ToString()),
                                    StockQuantity = Convert.ToDecimal(reader["StockQuantity"].ToString()),
                                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"].ToString()),
                                    TotalPurchasePrice = Convert.ToDecimal(reader["TotalPurchasePrice"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString())
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
    }
}
