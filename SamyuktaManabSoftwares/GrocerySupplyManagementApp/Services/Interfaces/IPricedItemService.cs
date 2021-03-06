using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IPricedItemService
    {
        PricedItem GetPricedItem(long id);
        PricedItem GetPricedItem(string itemCode);
        PricedItem GetPricedItem(string itemCode, string itemSubCode);
        PricedItem GetPricedItemByBarcode(string itemBarcode);
        IEnumerable<PricedItemView> GetPricedItemViewList();
        IEnumerable<UnpricedItemView> GetUnpricedItemViewList();

        PricedItem AddPricedItem(PricedItem pricedItem);

        PricedItem UpdatePricedItem(long id, PricedItem pricedItem);

        bool DeletePricedItem(long id);
    }
}
