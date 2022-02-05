using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public StockItem GetStockItem(PricedItem pricedItem, StockFilter stockFilter)
        {
            // Start: Calculation Per Unit Value, Custom Per Unit Value, Profit Amount, Sales Price Logic
            var stocks = GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
            var perUnitValue = GetPerUnitValue(stocks.ToList(), stockFilter);
            var volume = pricedItem.Volume == Constants.DEFAULT_DECIMAL_VALUE ? 1 : pricedItem.Volume;
            var customPerUnitValue = Math.Round(perUnitValue * volume, 2);
            var profitPercent = pricedItem.ProfitPercent;
            var profitAmount = Math.Round(customPerUnitValue * (profitPercent / 100), 2);
            var salesPrice = customPerUnitValue + profitAmount;
            // End

            return new StockItem
            {
                PerUnitValue = perUnitValue,
                CustomPerUnitValue = customPerUnitValue,
                ProfitAmount = profitAmount,
                SalesPrice = salesPrice
            };
        }
    }
}
