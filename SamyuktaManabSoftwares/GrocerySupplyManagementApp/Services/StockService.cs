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
        private readonly IPurchasedItemRepository _purchasedItemRepository;
        private readonly ISoldItemRepository _soldItemRepository;
        private readonly IStockAdjustmentRepository _stockAdjustmentRepository;

        public StockService(IStockRepository stockRepository, IPurchasedItemRepository purchasedItemRepository,
            ISoldItemRepository soldItemRepository, IStockAdjustmentRepository stockAdjustmentRepository)
        {
            _stockRepository = stockRepository;
            _purchasedItemRepository = purchasedItemRepository;
            _soldItemRepository = soldItemRepository;
            _stockAdjustmentRepository = stockAdjustmentRepository;
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

        public decimal GetTotalStock(StockFilter stockFilter)
        {
            var totalPurchasedItem = _purchasedItemRepository.GetPurchasedItemTotalQuantity(stockFilter);
            var totalSoldItem = _soldItemRepository.GetSoldItemTotalQuantity(stockFilter);
            var totalAddedItem = _stockAdjustmentRepository.GetAddedStockTotalQuantity(stockFilter);
            var totalDeductedItem = _stockAdjustmentRepository.GetDeductedStockTotalQuantity(stockFilter);
            var totalStock = (totalPurchasedItem + totalAddedItem) - (totalSoldItem + totalDeductedItem);
            return totalStock;
        }
    }
}
