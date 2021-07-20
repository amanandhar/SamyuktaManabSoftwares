using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItem(string code);
        Item GetItem(long itemId);
        IEnumerable<string> GetItemNames();

        Item AddItem(Item item);

        Item UpdateItem(string code, Item item);
        Item UpdateItem(long id, Item item);

        bool DeleteItem(long id);
    }
}
