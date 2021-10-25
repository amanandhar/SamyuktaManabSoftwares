using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlStockRepository : IStockRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlStockRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Stock> GetStocks(StockFilter stockFilter)
        {
            var stocks = new List<Stock>();
            var query = @"IF OBJECT_ID('tempdb..#Temp') IS NOT NULL " +
                "DROP TABLE #Temp " +
                "SELECT UnionTable.* " +
                "INTO #Temp " +
                "FROM " +
                "( " +

                "SELECT pi.[EndOfDay], " +
                "'" + Constants.PURCHASE + "' AS [Description], " +
                "ut.[ActionType] AS [Type], " +
                "i.[Code] AS [ItemCode], i.[Name] AS [ItemName], " +
                "i.[Unit] AS [Unit], " +
                "pi.[Quantity] AS [PurchaseQuantity], 0 AS [SalesQuantity], " +
                "pi.[Price] AS [PurchasePrice], 0.00 AS [SalesPrice], " +
                "pi.[AddedDate] " +
                "FROM " + Constants.TABLE_PURCHASED_ITEM + " pi " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "ON pi.[BillNo] = ut.[BillNo] " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON pi.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND ut.[Action] = '" + Constants.PURCHASE + "' ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateFrom))
            {
                query += "AND pi.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateTo))
            {
                query += "AND pi.[EndOfDay] <= @DateTo ";
            }

            query += "UNION " +
                "SELECT sa.[EndOfDay], " +
                "'" + Constants.ADD + "' AS [Description], " +
                "'' AS [Type], " +
                "i.[Code] AS [ItemCode], i.[Name] AS [ItemName], " +
                "i.[Unit] AS [Unit], " +
                "sa.[Quantity] AS [PurchaseQuantity], 0 AS [SalesQuantity], " +
                "sa.[Price] AS [PurchasePrice], 0.00 AS [SalesPrice], " +
                "sa.[AddedDate] " +
                "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " sa " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON " +
                "sa.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(sa.[Action], '') = '" + Constants.ADD + "' ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateFrom))
            {
                query += "AND sa.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateTo))
            {
                query += "AND sa.[EndOfDay] <= @DateTo ";
            }

            query += "UNION " +
                "SELECT si.[EndOfDay], " + 
                "'" + Constants.SALES + "' AS [Description], " +
                "ut.[ActionType] AS [Type], " +
                "i.[Code] AS [ItemCode], i.[Name] AS [ItemName], " +
                "si.[Unit] AS [Unit], " +
                "0 AS [PurchaseQuantity], (si.[Volume] * si.[Quantity]) AS [SalesQuantity], " +
                "0.00 AS [PurchasePrice], si.[Price] AS [SalesPrice], " +
                "si.[AddedDate] " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " si " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "ON si.[InvoiceNo] = ut.[InvoiceNo] " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND ut.[Action] = '" + Constants.SALES + "' ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateFrom))
            {
                query += "AND si.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateTo))
            {
                query += "AND si.[EndOfDay] <= @DateTo ";
            }

            query += "UNION " +
                "SELECT sa.[EndOfDay], " +
                "'" + Constants.DEDUCT + "' AS [Description], " +
                "'' AS [Type], " +
                "i.[Code] AS [ItemCode], i.[Name] AS [ItemName], " +
                "i.[Unit] AS [Unit], " +
                "0 AS [PurchaseQuantity], sa.[Quantity] AS [SalesQuantity], " +
                "0.00 AS [PurchasePrice], sa.[Price] AS [SalesPrice], " +
                "sa.[AddedDate] " +
                "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " sa " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON " +
                "sa.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(sa.[Action], '') = '" + Constants.DEDUCT + "' ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateFrom))
            {
                query += "AND sa.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateTo))
            {
                query += "AND sa.[EndOfDay] <= @DateTo ";
            }

            query += ") " + 
                "UnionTable " +
                "ORDER BY UnionTable.[ItemCode], UnionTable.[AddedDate] " +
                "SELECT t.*, " +
                "( " +
                "SELECT SUM(u.[PurchaseQuantity] - u.[SalesQuantity]) " +
                "FROM #Temp u " +
                "WHERE 1 = 1 " +
                "AND u.[AddedDate] <= t.[AddedDate] " +
                "AND u.[ItemCode] = t.[ItemCode] " +
                ") AS [StockQuantity], " +
                "CAST((t.[PurchasePrice] * t.[PurchaseQuantity]) AS DECIMAL(18,2)) AS [TotalPurchasePrice] " +
                "FROM #Temp t " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.ItemCode))
            {
                query += "AND t.[ItemCode] = @Code ";
            }

            query += "ORDER BY t.[ItemCode], t.[AddedDate]";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)stockFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)stockFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Code", ((object)stockFilter?.ItemCode) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var stock = new Stock
                                {
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Type = reader["Type"].ToString(),
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
                logger.Error(ex);
                throw ex;
            }

            return stocks;
        }

        public decimal GetPerUnitValue(List<Stock> stocks, StockFilter stockFilter)
        {
            var stockViewList = GetStockViewList(stocks, stockFilter);
            var latestStockView = stockViewList.GroupBy(x => x.ItemCode)
                .Select(x => x.OrderByDescending(y => y.AddedDate).FirstOrDefault())
                .ToList();

            var perUnitValue = latestStockView.Count > 0 ? latestStockView.Sum(x => Math.Round(x.PerUnitValue, 2)) : Constants.DEFAULT_DECIMAL_VALUE;

            return perUnitValue;
        }

        public decimal GetStockValue(List<Stock> stocks, StockFilter stockFilter)
        {
            var stockViewList = GetStockViewList(stocks, stockFilter);
            var latestStockView = stockViewList.GroupBy(x => x.ItemCode)
                .Select(x => x.OrderByDescending(y => y.AddedDate).FirstOrDefault())
                .ToList();
            var perUnitValue = latestStockView.Count > 0 ? latestStockView.Sum(x => Math.Round(x.StockValue, 2)) : Constants.DEFAULT_DECIMAL_VALUE;

            return perUnitValue;
        }

        public List<StockView> GetStockViewList(List<Stock> stocks, StockFilter stockFilter)
        {
            var stockViewList = new List<StockView>();
            if (!string.IsNullOrWhiteSpace(stockFilter.DateFrom) && !string.IsNullOrWhiteSpace(stockFilter.DateTo))
            {
                stockViewList = CalculateStock(stocks)
                    .Where(x => x.EndOfDay.CompareTo(stockFilter.DateFrom) >= 0 && x.EndOfDay.CompareTo(stockFilter.DateTo) <= 0)
                    .ToList();
            }
            else if (!string.IsNullOrEmpty(stockFilter.DateFrom) && string.IsNullOrEmpty(stockFilter.DateTo))
            {
                stockViewList = CalculateStock(stocks)
                    .Where(x => x.EndOfDay.CompareTo(stockFilter.DateFrom) >= 0)
                    .ToList();
            }
            else if (string.IsNullOrEmpty(stockFilter.DateTo) && !string.IsNullOrEmpty(stockFilter.DateTo))
            {
                stockViewList = CalculateStock(stocks)
                    .Where(x => x.EndOfDay.CompareTo(stockFilter.DateTo) <= 0)
                    .ToList();
            }
            else
            {
                stockViewList = CalculateStock(stocks);
            }

            return stockViewList;
        }

        private List<StockView> CalculateStock(List<Stock> stocks)
        {
            List<StockView> stockViewList = null;
            
            try
            {
                stockViewList = new List<StockView>();
                int index = 0;
                var itemCode = string.Empty;
                foreach (var stock in stocks)
                {
                    if (string.IsNullOrEmpty(itemCode))
                    {
                        itemCode = stock.ItemCode;
                    }

                    var stockView = new StockView
                    {
                        EndOfDay = stock.EndOfDay,
                        Description = stock.Description,
                        Type = stock.Type,
                        ItemCode = stock.ItemCode,
                        ItemName = stock.ItemName,
                        PurchaseQuantity = stock.PurchaseQuantity,
                        SalesQuantity = stock.SalesQuantity,
                        Unit = stock.ItemUnit,
                        PurchasePrice = stock.PurchasePrice,
                        StockQuantity = stock.StockQuantity,
                        TotalPurchasePrice = stock.TotalPurchasePrice,
                        AddedDate = stock.AddedDate
                    };

                    if (index == 0 || itemCode != stock.ItemCode)
                    {
                        itemCode = stock.ItemCode;

                        stockView.SalesPrice = Constants.DEFAULT_DECIMAL_VALUE;
                        stockView.StockValue = stock.TotalPurchasePrice;
                        stockView.PerUnitValue = stock.TotalPurchasePrice == Constants.DEFAULT_DECIMAL_VALUE ? Constants.DEFAULT_DECIMAL_VALUE : Math.Round((stock.TotalPurchasePrice / stock.PurchaseQuantity), 2);
                    }
                    else
                    {
                        stockView.SalesPrice = stockViewList[index - 1].PerUnitValue;
                        stockView.StockValue = (stock.Description.ToLower().Equals(Constants.PURCHASE.ToLower())
                            || stock.Description.ToLower().Equals(Constants.ADD.ToLower()))
                            ? (stock.TotalPurchasePrice + stockViewList[index - 1].StockValue)
                            : stockViewList[index - 1].StockValue - Math.Round((stock.SalesQuantity * stockViewList[index - 1].PerUnitValue), 2);
                        stockView.PerUnitValue = (stock.Description.ToLower().Equals(Constants.PURCHASE.ToLower())
                            || stock.Description.ToLower().Equals(Constants.ADD.ToLower()))
                            ? stock.StockQuantity == Constants.DEFAULT_DECIMAL_VALUE ? Constants.DEFAULT_DECIMAL_VALUE : Math.Round(((stock.TotalPurchasePrice + stockViewList[index - 1].StockValue) / stock.StockQuantity), 2)
                            : stockViewList[index - 1].PerUnitValue;
                    }

                    stockViewList.Add(stockView);
                    index++;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return stockViewList;
        }
    }
}
