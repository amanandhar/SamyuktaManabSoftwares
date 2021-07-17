using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IPurchasedItemRepository
    {
        IEnumerable<PurchasedItem> GetPurchasedItems();
        PurchasedItem GetPurchasedItem(long purchasedItemId);
        PurchasedItem AddPurchasedItem(PurchasedItem purchasedItem);
        PurchasedItem UpdatePurchasedItem(long purchasedItemId, PurchasedItem purchasedItem);
        bool DeletePurchasedItem(long purchasedItemId);
        IEnumerable<PurchasedItemListView> GetPurchasedItemViewList();
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
        string GetLastBillNo();
        PurchasedItem AddItem(PurchasedItem item);
        PurchasedItem UpdateItem(PurchasedItem item);
        bool DeleteItem(string name, string brand);
        bool DeleteItemTransaction(string billNo);
    }
}
