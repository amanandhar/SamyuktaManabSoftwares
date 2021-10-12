using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetStocks(StockFilter stockFilter);
        decimal GetPerUnitValue(List<Stock> stocks, StockFilter stockFilter);
        decimal GetStockValue(List<Stock> stocks, StockFilter stockFilter);
        List<StockView> GetStockViewList(List<Stock> stocks, StockFilter stockFilter);
    }
}
