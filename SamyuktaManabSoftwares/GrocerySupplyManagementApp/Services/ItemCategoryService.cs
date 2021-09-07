using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class ItemCategoryService: IItemCategoryService
    {
        private readonly IItemCategoryRepository _itemCategoryRepository;

        public ItemCategoryService(IItemCategoryRepository itemCategoryRepository)
        {
            _itemCategoryRepository = itemCategoryRepository;
        }

        public IEnumerable<ItemCategory> GetItemCategories()
        {
            return _itemCategoryRepository.GetItemCategories();
        }

        public ItemCategory GetItemCategory(long id)
        {
            return _itemCategoryRepository.GetItemCategory(id);
        }

        public ItemCategory GetItemCategory(string name)
        {
            return _itemCategoryRepository.GetItemCategory(name);
        }

        public ItemCategory AddItemCategory(ItemCategory itemCategory)
        {
            return _itemCategoryRepository.AddItemCategory(itemCategory);
        }

        public ItemCategory UpdateItemCategory(long id, ItemCategory itemCategory)
        {
            return _itemCategoryRepository.UpdateItemCategory(id, itemCategory);
        }

        public bool DeleteItemCategory(long id)
        {
            return _itemCategoryRepository.DeleteItemCategory(id);
        }

        public bool DeleteItemCategory(string itemCode)
        {
            return _itemCategoryRepository.DeleteItemCategory(itemCode);
        }
    }
}
