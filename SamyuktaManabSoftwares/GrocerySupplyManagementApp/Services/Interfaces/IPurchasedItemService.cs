using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IPurchasedItemService
    {
        IEnumerable<PurchasedItem> GetPurchasedItems();
        PurchasedItem GetPurchasedItem(long id);
        IEnumerable<PurchasedItemListView> GetPurchasedItemDetails();
        IEnumerable<PurchasedItem> GetPurchasedItemBySupplierAndBill(string supplierId, string billNo);
        decimal GetPurchasedItemTotalAmount(string supplierId, string billNo);
        decimal GetPurchasedItemTotalAmount(StockFilterView filter);
        long GetPurchasedItemTotalQuantity(StockFilterView filter);
        IEnumerable<string> GetPurchasedItemCodes();
        PurchasedItem GetPurchasedItemByItemId(long itemId);
        long GetItemId(string supplierName, string billNo);
        string GetLastBillNo();
        decimal GetLatestPurchasePrice(long itemId);

        PurchasedItem AddPurchasedItem(PurchasedItem purchasedItem);

        PurchasedItem UpdatePurchasedItem(long purchasedItemId, PurchasedItem puchasedItem);

        bool DeletePurchasedItem(long puchasedItemId);
        bool DeletePurchasedItem(string billNo);
        bool DeletePurchasedItemAfterEndOfDay(string endOfDay);
    }
}
