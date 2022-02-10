using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface ISoldItemService
    {
        IEnumerable<SoldItem> GetSoldItems();
        IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo);
        decimal GetSoldItemTotalQuantity(StockFilter StockFilter);
        string GetNewInvoiceNumber();
        string GetLastInvoiceNumber();
        IEnumerable<string> GetInvoiceNumbers();

        SoldItem AddSoldItem(SoldItem soldItem);

        SoldItem UpdateAdjustedAmount(long id, SoldItem soldItem);

        bool DeleteSoldItem(string invoiceNo);
    }
}
