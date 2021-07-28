using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace GrocerySupplyManagementApp.Shared
{
    public static class UtilityService
    {
        public static bool CreateFolder(string rootPath, string folderName)
        {
            bool result = false;
            string folderPath = Path.Combine(rootPath, folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                result = true;
            }

            return result;
        }

        public static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[Constants.DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }

        public static List<StockView> CalculateStock(List<Stock> stocks)
        {
            var stockViewList = new List<StockView>();
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
                    ItemCode = stock.ItemCode,
                    ItemName = stock.ItemName,
                    PurchaseQuantity = stock.PurchaseQuantity,
                    SalesQuantity = stock.SalesQuantity,
                    PurchasePrice = stock.PurchasePrice,
                    StockQuantity = stock.StockQuantity,
                    TotalPurchasePrice = stock.TotalPurchasePrice,
                    AddedDate = stock.AddedDate
                };

                if (index == 0 || itemCode != stock.ItemCode)
                {
                    itemCode = stock.ItemCode;

                    stockView.SalesPrice = 0.00m;
                    stockView.StockValue = stock.TotalPurchasePrice;
                    stockView.PerUnitValue = Math.Round((stock.TotalPurchasePrice / stock.PurchaseQuantity), 2);
                }
                else
                {
                    stockView.SalesPrice = stockViewList[index - 1].PerUnitValue;
                    stockView.StockValue = stock.Description.ToLower().Equals(Constants.PURCHASE.ToLower()) 
                        ? (stock.TotalPurchasePrice + stockViewList[index - 1].StockValue) 
                        : stockViewList[index - 1].StockValue - Math.Round((stock.SalesQuantity * stockViewList[index - 1].PerUnitValue), 2);
                    stockView.PerUnitValue = stock.Description.ToLower().Equals(Constants.PURCHASE.ToLower()) 
                        ? Math.Round(((stock.TotalPurchasePrice + stockViewList[index - 1].StockValue) / stock.StockQuantity), 2)
                        : stockViewList[index - 1].PerUnitValue;
                }

                stockViewList.Add(stockView);
                index++;
            }

            return stockViewList;
        }
    }
}
