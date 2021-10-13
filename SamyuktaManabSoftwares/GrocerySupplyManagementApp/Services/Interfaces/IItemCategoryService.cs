﻿using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IItemCategoryService
    {
        IEnumerable<ItemCategory> GetItemCategories();
        ItemCategory GetItemCategory(long id);
        ItemCategory GetItemCategory(string name);

        ItemCategory AddItemCategory(ItemCategory itemCategory);

        bool DeleteItemCategory(string itemCode);
    }
}
