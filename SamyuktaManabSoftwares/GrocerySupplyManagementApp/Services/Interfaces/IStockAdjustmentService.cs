using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IStockAdjustmentService
    {
        IEnumerable<StockAdjustment> GetStockAdjustments();
        StockAdjustment GetStockAdjustment(long id);
        IEnumerable<StockAdjustmentView> GetStockAdjustmentViewList();
        decimal GetAddedStockTotalQuantity(StockFilter stockFilter);
        decimal GetDeductedStockTotalQuantity(StockFilter stockFilter);

        StockAdjustment AddStockAdjustment(StockAdjustment stockAdjustment);

        StockAdjustment UpdateStockAdjustment(long id, StockAdjustment stockAdjustment);

        bool DeleteStockAdjustment(long id);
        bool DeleteStockAdjustmentByUserTransaction(long userTrasactionId);
    }
}
