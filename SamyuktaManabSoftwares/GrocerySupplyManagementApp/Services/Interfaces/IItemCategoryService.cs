using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IItemCategoryService
    {
        ItemCategory GetItemCategory(string name);

        ItemCategory AddItemCategory(ItemCategory itemCategory);

        bool DeleteItemCategory(string itemCode);
    }
}
