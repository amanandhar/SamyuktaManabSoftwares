using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IItemTransactionService
    {
        IEnumerable<ItemPurchase> GetItems(bool showEmptyItemCode);
        IEnumerable<ItemPurchaseGrid> GetItems(DTOs.StockFilterView filter);
        IEnumerable<ItemPurchase> GetItemsBySupplierAndBill(string supplierName, string billNo);
        decimal GetTotalAmountBySupplierAndBill(string supplierName, string billNo);
        decimal GetTotalItemCount(DTOs.StockFilterView filter);
        decimal GetTotalItemCount(string code);
        decimal GetTotalItemAmount(DTOs.StockFilterView filter);
        IEnumerable<string> GetAllItemNames();
        IEnumerable<string> GetAllItemCodes();
        ItemPurchase GetItem(long itemId);
        long GetItemId(string supplierName, string billNo);
        string GetBillNo();
        ItemPurchase AddItem(ItemPurchase item);
        ItemPurchase UpdateItem(ItemPurchase item);
        bool DeleteItem(string name, string brand);
        bool DeleteItemTransactionBySupplierAndBill(string supplierName, string billNo);
    }
}
