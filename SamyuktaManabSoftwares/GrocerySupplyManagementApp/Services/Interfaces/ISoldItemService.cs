using GrocerySupplyManagementApp.DTOs;
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
        decimal GetSoldItemTotalQuantity(StockFilter StockFilter);
        decimal GetSoldItemTotalAmount(StockFilter StockFilter);
        IEnumerable<string> GetSoldItemCodes();

        SoldItem AddSoldItem(SoldItem soldItem);

        SoldItem UpdateSoldItem(long soldItemId, SoldItem soldItem);

        bool DeleteSoldItem(string invoiceNo);
        bool DeleteSoldItemAfterEndOfDay(string endOfDay);
    }
}
