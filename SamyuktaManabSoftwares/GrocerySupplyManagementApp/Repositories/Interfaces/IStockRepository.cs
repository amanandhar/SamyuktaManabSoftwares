using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetStocks(StockFilter stockFilter);
    }
}
