using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IStockService
    {
        IEnumerable<Stock> GetStocks();
        Stock GetStock(long id);
        decimal GetTotalSalesPrice(long itemId);
        decimal GetTotalStockQuantity(long itemId);
        decimal GetLatestPerUnitStockAmount(long itemId);

        Stock AddStock(Stock stock);

        Stock UpdateStock(long id, Stock stock);

        bool DeleteStock(long id);
    }
}
