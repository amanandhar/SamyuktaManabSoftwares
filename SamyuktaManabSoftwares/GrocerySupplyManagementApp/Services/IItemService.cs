using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetItems();
        IEnumerable<Item> GetItems(DTOs.StockFilter filter);
        int GetTotalItemCount(DTOs.StockFilter filter);
        IEnumerable<string> GetAllItemNames();
        Item GetItem(string itemName);
        Item AddItem(Item item);
        Item UpdateItem(string itemId, Item item);
        bool DeleteItem(string itemId);
    }
}
