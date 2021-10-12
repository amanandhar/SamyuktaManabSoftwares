using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
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

        public IEnumerable<Stock> GetStocks(StockFilter stockFilter)
        {
            return _stockRepository.GetStocks(stockFilter);
        }

        public decimal GetPerUnitValue(List<Stock> stocks, StockFilter stockFilter)
        {
            return _stockRepository.GetPerUnitValue(stocks, stockFilter);
        }

        public decimal GetStockValue(List<Stock> stocks, StockFilter stockFilter)
        {
            return _stockRepository.GetStockValue(stocks, stockFilter);
        }

        public List<StockView> GetStockViewList(List<Stock> stocks, StockFilter stockFilter)
        {
            return _stockRepository.GetStockViewList(stocks, stockFilter);
        }
    }
}
