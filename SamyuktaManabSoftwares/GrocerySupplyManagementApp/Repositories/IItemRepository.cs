using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItem(string itemId);
        Item AddItem(Item item);
        Item UpdateItem(string itemId, Item item);
        bool DeleteItem(string itemId);
    }
}
