using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IStockRepository
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
