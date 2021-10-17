using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class StockAdjustmentService : IStockAdjustmentService
    {
        private readonly IStockAdjustmentRepository _stockAdjustmentRepository;

        public StockAdjustmentService(IStockAdjustmentRepository stockAdjustmentRepository)
        {
            _stockAdjustmentRepository = stockAdjustmentRepository;
        }

        public IEnumerable<StockAdjustment> GetStockAdjustments()
        {
            return _stockAdjustmentRepository.GetStockAdjustments();
        }

        public StockAdjustment GetStockAdjustment(long id)
        {
            return _stockAdjustmentRepository.GetStockAdjustment(id);
        }

        public IEnumerable<StockAdjustmentView> GetStockAdjustmentViewList()
        {
            return _stockAdjustmentRepository.GetStockAdjustmentViewList();
        }

        public decimal GetAddedStockTotalQuantity(StockFilter stockFilter)
        {
            return _stockAdjustmentRepository.GetAddedStockTotalQuantity(stockFilter);
        }

        public decimal GetDeductedStockTotalQuantity(StockFilter stockFilter)
        {
            return _stockAdjustmentRepository.GetDeductedStockTotalQuantity(stockFilter);
        }

        public StockAdjustment AddStockAdjustment(StockAdjustment stockAdjustment)
        {
            return _stockAdjustmentRepository.AddStockAdjustment(stockAdjustment);
        }

        public StockAdjustment UpdateStockAdjustment(long id, StockAdjustment stockAdjustment)
        {
            return _stockAdjustmentRepository.UpdateStockAdjustment(id, stockAdjustment);
        }

        public bool DeleteStockAdjustment(long id)
        {
            return _stockAdjustmentRepository.DeleteStockAdjustment(id);
        }

        public bool DeleteStockAdjustmentByUserTransaction(long userTrasactionId)
        {
            return _stockAdjustmentRepository.DeleteStockAdjustmentByUserTransaction(userTrasactionId);
        }
    }
}
