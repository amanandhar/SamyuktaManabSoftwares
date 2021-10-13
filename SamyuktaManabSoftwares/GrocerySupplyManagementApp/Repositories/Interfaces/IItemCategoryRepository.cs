﻿using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IItemCategoryRepository
    {
        IEnumerable<ItemCategory> GetItemCategories();
        ItemCategory GetItemCategory(long id);
        ItemCategory GetItemCategory(string name);

        ItemCategory AddItemCategory(ItemCategory itemCategory);

        bool DeleteItemCategory(string itemCode);
    }
}
