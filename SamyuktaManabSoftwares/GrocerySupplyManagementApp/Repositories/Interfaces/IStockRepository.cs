using GrocerySupplyManagementApp.DTOs;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetStocks(StockFilter stockFilter);
    }
}
