using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IStockAdjustmentRepository
    {
        IEnumerable<StockAdjustment> GetStockAdjustments();
        StockAdjustment GetStockAdjustment(long id);
        long GetAddedStockTotalQuantity(StockFilter stockFilter);
        long GetDeductedStockTotalQuantity(StockFilter stockFilter);

        StockAdjustment AddStockAdjustment(StockAdjustment stockAdjustment);

        StockAdjustment UpdateStockAdjustment(long id, StockAdjustment stockAdjustment);

        bool DeleteStockAdjustment(long id);
    }
}
