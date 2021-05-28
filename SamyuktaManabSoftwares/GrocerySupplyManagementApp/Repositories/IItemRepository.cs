using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems(bool showEmptyItemCode);
        Item GetItem(long Id);
        long GetItemId(string name, string brand);
        Item AddItem(Item item);
        Item UpdateItem(long id, Item item);
        bool DeleteItem(long id);
    }
}
