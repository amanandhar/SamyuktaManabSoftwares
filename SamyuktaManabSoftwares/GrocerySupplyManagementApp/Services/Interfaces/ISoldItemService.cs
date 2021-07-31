using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface ISoldItemService
    {
        IEnumerable<SoldItem> GetSoldItems();
        SoldItem GetSoldItem(long soldItemId);
        IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo);
        long GetSoldItemTotalQuantity(StockFilterView filter);
        decimal GetSoldItemTotalAmount(StockFilterView filter);
        IEnumerable<string> GetSoldItemCodes();

        SoldItem AddSoldItem(SoldItem soldItem);

        SoldItem UpdateSoldItem(long soldItemId, SoldItem soldItem);

        bool DeleteSoldItem(string invoiceNo);
        bool DeleteSoldItemAfterEndOfDay(string endOfDay);
    }
}
