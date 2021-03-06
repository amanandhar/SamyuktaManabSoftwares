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

        public StockAdjustment AddStockAdjustment(StockAdjustment stockAdjustment, IncomeExpense incomeExpense, string incomeExpenseType, string username)
        {
            return _stockAdjustmentRepository.AddStockAdjustment(stockAdjustment, incomeExpense, incomeExpenseType, username);
        }

        public bool DeleteStockAdjustment(long id, long incomeExpenseId)
        {
            return _stockAdjustmentRepository.DeleteStockAdjustment(id, incomeExpenseId);
        }
    }
}
