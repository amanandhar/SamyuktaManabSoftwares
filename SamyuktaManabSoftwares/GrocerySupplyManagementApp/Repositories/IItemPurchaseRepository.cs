using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IItemPurchaseRepository
    {
        IEnumerable<ItemPurchase> GetItems(bool showEmptyItemCode);
        IEnumerable<StockView> GetStockView(StockFilterView filter);
        IEnumerable<ItemPurchase> GetItemsBySupplierAndBill(string supplierName, string billNo);
        decimal GetTotalAmountBySupplierAndBill(string supplierName, string billNo);
        decimal GetTotalPurchaseItemCount(StockFilterView filter);
        decimal GetTotalSalesItemCount(StockFilterView filter);
        decimal GetTotalItemCount(string code);
        decimal GetTotalPurchaseItemAmount(StockFilterView filter);
        decimal GetTotalSalesItemAmount(StockFilterView filter);
        IEnumerable<string> GetAllItemNames();
        IEnumerable<string> GetAllItemCodes();
        ItemPurchase GetItem(long itemId);
        long GetItemId(string supplierName, string billNo);
        string GetLastBillNo();
        ItemPurchase AddItem(ItemPurchase item);
        ItemPurchase UpdateItem(ItemPurchase item);
        bool DeleteItem(string name, string brand);
        bool DeleteItemTransaction(string billNo);
    }
}
