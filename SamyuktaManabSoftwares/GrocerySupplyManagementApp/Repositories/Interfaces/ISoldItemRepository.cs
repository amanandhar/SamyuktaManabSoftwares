using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ISoldItemRepository
    {
        IEnumerable<SoldItem> GetSoldItems();
        SoldItem GetSoldItem(long soldItemId);
        IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo);
        decimal GetSoldItemTotalQuantity(StockFilter stockFilter);
        decimal GetSoldItemTotalAmount(StockFilter stockFilter);
        IEnumerable<string> GetSoldItemCodes();

        SoldItem AddSoldItem(SoldItem soldItem);

        SoldItem UpdateSoldItem(long soldItemId, SoldItem soldItem);

        bool DeleteSoldItem(string invoiceNo);
        bool DeleteSoldItemAfterEndOfDay(string endOfDay);
    }
}
