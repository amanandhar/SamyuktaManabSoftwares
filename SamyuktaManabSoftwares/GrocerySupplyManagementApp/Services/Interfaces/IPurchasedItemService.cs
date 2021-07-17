using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IPurchasedItemService
    {
        IEnumerable<PurchasedItem> GetPurchasedItems();
        PurchasedItem GetPurchasedItem(long purchasedItemId);
        PurchasedItem AddPurchasedItem(PurchasedItem purchasedItem);
        PurchasedItem UpdatePurchasedItem(long purchasedItemId, PurchasedItem purchasedItem);
        bool DeletePurchasedItem(long purchasedItemId);
        IEnumerable<PurchasedItemListView> GetPurchasedItemViewList();
    }
}
