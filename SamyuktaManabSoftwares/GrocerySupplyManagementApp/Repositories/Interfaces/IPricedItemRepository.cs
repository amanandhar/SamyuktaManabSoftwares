﻿using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IPricedItemRepository
    {
        PricedItem GetPricedItem(long id);
        PricedItem GetPricedItem(string itemCode);
        PricedItem GetPricedItemByBarcode(string itemBarcode);
        IEnumerable<PricedItemView> GetPricedItemViewList();
        IEnumerable<UnpricedItemView> GetUnpricedItemViewList();

        PricedItem AddPricedItem(PricedItem pricedItem);

        PricedItem UpdatePricedItem(long id, PricedItem pricedItem);

        bool DeletePricedItem(long id);
    }
}
