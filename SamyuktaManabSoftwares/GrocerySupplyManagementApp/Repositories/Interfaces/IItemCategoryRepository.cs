using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IItemCategoryRepository
    {
        ItemCategory GetItemCategory(string name);

        ItemCategory AddItemCategory(ItemCategory itemCategory);

        bool DeleteItemCategory(string itemCode);
    }
}
