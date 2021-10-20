using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IStockAdjustmentRepository
    {
        IEnumerable<StockAdjustmentView> GetStockAdjustmentViewList();
        decimal GetAddedStockTotalQuantity(StockFilter stockFilter);
        decimal GetDeductedStockTotalQuantity(StockFilter stockFilter);

        StockAdjustment AddStockAdjustment(StockAdjustment stockAdjustment);

        bool DeleteStockAdjustmentByUserTransaction(long userTrasactionId);
    }
}
