using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ISoldItemRepository
    {
        IEnumerable<SoldItem> GetSoldItems();
        SoldItem GetSoldItem(long soldItemId);
        SoldItem AddSoldItem(SoldItem soldItem);
        SoldItem UpdateSoldItem(long posITransactionId, SoldItem soldItem);
        bool DeleteSoldItem(long soldItemId, SoldItem soldItem);
        bool DeleteSoldItem(string invoiceNo);
        IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo);
    }
}
