using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ISoldItemRepository
    {
        IEnumerable<SoldItem> GetSoldItems();
        IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo);
        decimal GetSoldItemTotalQuantity(StockFilter stockFilter);

        SoldItem AddSoldItem(SoldItem soldItem);

        bool DeleteSoldItem(string invoiceNo);
    }
}
