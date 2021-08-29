using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IPricedItemRepository
    {
        IEnumerable<PricedItem> GetPricedItems();
        PricedItem GetPricedItem(long id);
        PricedItem GetPricedItem(string itemCode, string weightPiece);
        IEnumerable<PricedItemView> GetPricedItemViewList();
        IEnumerable<UnpricedItemView> GetUnpricedItemViewList();

        PricedItem AddPricedItem(PricedItem pricedItem);

        PricedItem UpdatePricedItem(long id, PricedItem pricedItem);

        bool DeletePricedItem(long id);
    }
}
