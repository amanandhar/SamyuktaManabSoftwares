using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IPurchasedItemRepository
    {
        IEnumerable<PurchasedItemListView> GetPurchasedItemDetails();
        IEnumerable<PurchasedItem> GetPurchasedItemBySupplierAndBill(string supplierId, string billNo);
        decimal GetPurchasedItemTotalAmount(string supplierId, string billNo);
        long GetPurchasedItemTotalQuantity(StockFilter stockFilter);
        PurchasedItem GetPurchasedItemByItemId(long itemId);
        string GetLastBillNo();
        string GetLastBonusNo();

        PurchasedItem AddPurchasedItem(PurchasedItem purchasedItem);

        bool DeletePurchasedItem(string billNo);
    }
}
