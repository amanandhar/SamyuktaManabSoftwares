﻿using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IPricedItemService
    {
        IEnumerable<PricedItem> GetPricedItems();
        PricedItem GetPricedItem(long id);
        IEnumerable<PricedItemView> GetPricedItemViewList();
        IEnumerable<UnpricedItemView> GetUnpricedItemViewList();

        PricedItem AddPricedItem(PricedItem pricedItem);

        PricedItem UpdatePricedItem(long id, PricedItem pricedItem);

        bool DeletePricedItem(long id);
    }
}