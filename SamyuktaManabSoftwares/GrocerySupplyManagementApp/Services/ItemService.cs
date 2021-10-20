using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
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

        public Item GetItem(string code)
        {
            return _itemRepository.GetItem(code);
        }

        public Item GetItem(long itemId)
        {
            return _itemRepository.GetItem(itemId);
        }

        public Item AddItem(Item item)
        {
            return _itemRepository.AddItem(item);
        }

        public Item UpdateItem(long id, Item item)
        {
            return _itemRepository.UpdateItem(id, item);
        }

        public bool DeleteItem(long id)
        {
            return _itemRepository.DeleteItem(id);
        }
    }
}
