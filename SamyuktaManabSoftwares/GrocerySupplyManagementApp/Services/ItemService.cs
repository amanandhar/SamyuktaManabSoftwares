using GrocerySupplyManagementApp.DTOs;
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

        public Item GetItem(string employeeId)
        {
            return _itemRepository.GetItem(employeeId);
        }

        public Item AddItem(Item item)
        {
            return _itemRepository.AddItem(item);
        }

        public Item UpdateItem(string employeeId, Item item)
        {
            return _itemRepository.UpdateItem(employeeId, item);
        }

        public bool DeleteItem(string employeeId)
        {
            return _itemRepository.DeleteItem(employeeId);
        }
    }
}
