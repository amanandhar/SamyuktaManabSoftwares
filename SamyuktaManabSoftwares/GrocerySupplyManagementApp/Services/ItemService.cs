using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class ItemService: IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetItems();
        }

        public IEnumerable<Item> GetItems(DTOs.StockFilter filter)
        {
            if (filter?.DateFrom == "    -  -" || filter?.DateTo == "    -  -")
            {
                filter.DateFrom = null;
                filter.DateTo = null;
            }

            return _itemRepository.GetItems(filter);
        }

        public int GetTotalItemCount(DTOs.StockFilter filter)
        {
            if(filter?.DateFrom == "    -  -" || filter?.DateTo == "    -  -")
            {
                filter.DateFrom = null;
                filter.DateTo = null;
            }
            else
            {
                filter.DateTo += " 23:59:59.999";
            }
            return _itemRepository.GetTotalItemCount(filter);
        }

        public IEnumerable<string> GetAllItemNames()
        {
            return _itemRepository.GetAllItemNames();
        }

        public Item GetItem(string itemName)
        {
            return _itemRepository.GetItem(itemName);
        }

        public Item AddItem(Item item)
        {
            return _itemRepository.AddItem(item);
        }

        public Item UpdateItem(string itemId, Item item)
        {
            return _itemRepository.UpdateItem(itemId, item);
        }

        public bool DeleteItem(string itemId)
        {
            return _itemRepository.DeleteItem(itemId);
        }
    }
}
