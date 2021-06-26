using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems(bool showEmptyItemCode);
        IEnumerable<Item> GetItems();
        Item GetItem(string code);
        Item GetItem(long itemId);
        long GetItemId(string name, string brand);
        Item AddItem(Item item);
        Item UpdateItem(string code, Item item);
        Item UpdateItem(long id, Item item);
        bool DeleteItem(long id);
    }
}
