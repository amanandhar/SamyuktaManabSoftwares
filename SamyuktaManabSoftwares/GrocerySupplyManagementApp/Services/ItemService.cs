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

        public Item GetItem(string itemId)
        {
            return _itemRepository.GetItem(itemId);
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
