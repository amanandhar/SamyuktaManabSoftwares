using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface ISoldItemService
    {
        IEnumerable<SoldItem> GetPosSoldItems();
        SoldItem GetPosSoldItem(long posSoldItemId);
        SoldItem AddPosSoldItem(SoldItem posSoldItem);
        SoldItem UpdatePosSoldItem(long posSoldItemId, SoldItem posSoldItem);
        bool DeleteSupplierTransaction(long posSoldItemId);
        bool DeletePosSoldItem(string invoiceNo);
        IEnumerable<SoldItemView> GetPosSoldItemGrid(string invoiceNo);
    }
}
