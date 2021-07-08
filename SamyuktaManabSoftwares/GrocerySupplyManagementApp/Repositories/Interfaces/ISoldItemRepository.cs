using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ISoldItemRepository
    {
        IEnumerable<SoldItem> GetPosSoldItems();
        SoldItem GetPosSoldItem(long posSoldItemId);
        SoldItem AddPosSoldItem(SoldItem posSoldItem);
        SoldItem UpdatePosSoldItem(long posITransactionId, SoldItem posSoldItem);
        bool DeletePosSoldItem(long posSoldItemId, SoldItem posSoldItem);
        bool DeletePosSoldItem(string invoiceNo);
        IEnumerable<SoldItemView> GetPosSoldItemGrid(string invoiceNo);
    }
}
