using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IStockService
    {
        IEnumerable<Stock> GetStocks(StockFilter stockFilter);
        decimal GetPerUnitValue(List<Stock> stocks, StockFilter stockFilter);
        decimal GetStockValue(List<Stock> stocks, StockFilter stockFilter);
        List<StockView> GetStockViewList(List<Stock> stocks, StockFilter stockFilter);
        decimal GetTotalStock(StockFilter stockFilter);
    }
}
