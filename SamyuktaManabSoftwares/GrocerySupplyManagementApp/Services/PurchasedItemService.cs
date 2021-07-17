using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class PurchasedItemService : IPurchasedItemService
    {
        private readonly IPurchasedItemRepository _purchasedItemRepository;

        public PurchasedItemService(IPurchasedItemRepository purchasedItemRepository)
        {
            _purchasedItemRepository = purchasedItemRepository;
        }

        public IEnumerable<PurchasedItem> GetPurchasedItems()
        {
            return _purchasedItemRepository.GetPurchasedItems();
        }
        public PurchasedItem GetPurchasedItem(long purchasedItemId)
        {
            return _purchasedItemRepository.GetPurchasedItem(purchasedItemId);
        }

        public PurchasedItem AddPurchasedItem(PurchasedItem purchasedItem)
        {
            return _purchasedItemRepository.AddPurchasedItem(purchasedItem);
        }

        public bool DeletePurchasedItem(long purchasedItemId)
        {
            return _purchasedItemRepository.DeletePurchasedItem(purchasedItemId);
        }

        public PurchasedItem UpdatePurchasedItem(long purchasedItemId, PurchasedItem purchasedItem)
        {
            return _purchasedItemRepository.UpdatePurchasedItem(purchasedItemId, purchasedItem);
        }

        public IEnumerable<PurchasedItemListView> GetPurchasedItemViewList()
        {
            return _purchasedItemRepository.GetPurchasedItemViewList();
        }
    }
}
