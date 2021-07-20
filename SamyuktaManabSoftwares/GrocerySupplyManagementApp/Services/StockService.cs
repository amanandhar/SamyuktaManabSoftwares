using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public IEnumerable<Stock> GetStocks()
        {
            return _stockRepository.GetStocks();
        }

        public Stock GetStock(long id)
        {
            return _stockRepository.GetStock(id);
        }

        public decimal GetTotalSalesPrice(long itemId)
        {
            return _stockRepository.GetTotalSalesPrice(itemId);
        }

        public decimal GetTotalStockQuantity(long itemId)
        {
            return _stockRepository.GetTotalStockQuantity(itemId);
        }

        public decimal GetLatestPerUnitStockAmount(long itemId)
        {
            return _stockRepository.GetLatestPerUnitStockAmount(itemId);
        }

        public Stock AddStock(Stock stock)
        {
            return _stockRepository.AddStock(stock);
        }

        public Stock UpdateStock(long id, Stock stock)
        {
            return _stockRepository.UpdateStock(id, stock);
        }

        public bool DeleteStock(long id)
        {
            return _stockRepository.DeleteStock(id);
        }
    }
}
