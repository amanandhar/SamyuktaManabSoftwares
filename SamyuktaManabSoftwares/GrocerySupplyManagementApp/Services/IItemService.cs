using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetItems(bool showEmptyItemCode);
        Item GetItem(long id);
        long GetItemId(string name, string brand);
        Item AddItem(Item item);
        Item UpdateItem(long id, Item item);
        bool DeleteItem(long id);
    }
}
