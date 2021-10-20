using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;

namespace GrocerySupplyManagementApp.Services
{
    public class ItemCategoryService: IItemCategoryService
    {
        private readonly IItemCategoryRepository _itemCategoryRepository;

        public ItemCategoryService(IItemCategoryRepository itemCategoryRepository)
        {
            _itemCategoryRepository = itemCategoryRepository;
        }

        public ItemCategory GetItemCategory(string name)
        {
            return _itemCategoryRepository.GetItemCategory(name);
        }

        public ItemCategory AddItemCategory(ItemCategory itemCategory)
        {
            return _itemCategoryRepository.AddItemCategory(itemCategory);
        }

        public bool DeleteItemCategory(string itemCode)
        {
            return _itemCategoryRepository.DeleteItemCategory(itemCode);
        }
    }
}
