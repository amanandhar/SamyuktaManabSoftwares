using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IItemTransactionService
    {
        IEnumerable<PurchasedItem> GetItems(bool showEmptyItemCode);
        IEnumerable<StockView> GetStockView(StockFilterView filter);
        IEnumerable<PurchasedItem> GetItemsBySupplierAndBill(string supplierName, string billNo);
        decimal GetTotalAmountBySupplierAndBill(string supplierName, string billNo);
        long GetTotalPurchaseItemCount(StockFilterView filter);
        long GetTotalSalesItemCount(StockFilterView filter);
        decimal GetTotalPurchaseItemAmount(StockFilterView filter);
        decimal GetTotalSalesItemAmount(StockFilterView filter);
        IEnumerable<string> GetAllItemNames();
        IEnumerable<string> GetAllItemCodes();
        PurchasedItem GetItem(long itemId);
        long GetItemId(string supplierName, string billNo);
        string GetBillNo();
        PurchasedItem AddItem(PurchasedItem item);
        PurchasedItem UpdateItem(PurchasedItem item);
        bool DeleteItem(string name, string brand);
        bool DeleteItemTransaction(string billNo);
    }
}
