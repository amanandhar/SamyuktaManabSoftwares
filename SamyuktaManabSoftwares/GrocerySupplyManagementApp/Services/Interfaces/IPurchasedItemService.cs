using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IPurchasedItemService
    {
        IEnumerable<PurchasedItemListView> GetPurchasedItemDetails();
        IEnumerable<PurchasedItem> GetPurchasedItemBySupplierAndBill(string supplierId, string billNo);
        decimal GetPurchasedItemTotalAmount(string supplierId, string billNo);
        decimal GetPurchasedItemTotalQuantity(StockFilter stockFilter);
        PurchasedItem GetPurchasedItemByItemId(long itemId);
        string GetNewBillNumber();
        string GetLastBillNumber();
        IEnumerable<string> GetBillNumbers();

        PurchasedItem AddPurchasedItem(PurchasedItem purchasedItem);

        bool DeletePurchasedItem(string billNo);
    }
}
