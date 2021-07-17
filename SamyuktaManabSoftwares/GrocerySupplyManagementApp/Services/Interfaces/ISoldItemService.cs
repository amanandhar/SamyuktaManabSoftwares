using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface ISoldItemService
    {
        IEnumerable<SoldItem> GetSoldItems();
        SoldItem GetSoldItem(long soldItemId);
        SoldItem AddSoldItem(SoldItem soldItem);
        SoldItem UpdateSoldItem(long soldItemId, SoldItem soldItem);
        bool DeleteSupplierTransaction(long soldItemId);
        bool DeleteSoldItem(string invoiceNo);
        IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo);
    }
}
