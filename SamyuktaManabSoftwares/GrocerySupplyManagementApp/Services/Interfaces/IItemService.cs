using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IItemService
    {
        IEnumerable<Item> GetItems(bool showEmptyItemCode);
        IEnumerable<Item> GetItems();
        Item GetItem(long itemId);
        Item GetItem(string code);
        long GetItemId(string name, string brand);
        Item AddItem(Item item);
        Item UpdateItem(string code, Item item);
        Item UpdateItem(long id, Item item);
        bool DeleteItem(long id);
    }
}
