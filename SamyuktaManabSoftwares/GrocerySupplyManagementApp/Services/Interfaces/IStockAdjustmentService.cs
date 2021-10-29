using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IStockAdjustmentService
    {
        IEnumerable<StockAdjustmentView> GetStockAdjustmentViewList();
        decimal GetAddedStockTotalQuantity(StockFilter stockFilter);
        decimal GetDeductedStockTotalQuantity(StockFilter stockFilter);

        StockAdjustment AddStockAdjustment(StockAdjustment stockAdjustment, IncomeExpense incomeExpense, string incomeExpenseType, string username);
    }
}
