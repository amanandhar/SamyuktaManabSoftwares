using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IItemCategoryService
    {
        IEnumerable<ItemCategory> GetItemCategories();
        ItemCategory GetItemCategory(long id);
        ItemCategory GetItemCategory(string name);

        ItemCategory AddItemCategory(ItemCategory itemCategory);

        ItemCategory UpdateItemCategory(long id, ItemCategory itemCategory);

        bool DeleteItemCategory(long id);
        bool DeleteItemCategory(string itemCode);
    }
}
