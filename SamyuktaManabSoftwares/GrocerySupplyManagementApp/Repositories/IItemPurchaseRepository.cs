using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IItemPurchaseRepository
    {
        IEnumerable<ItemPurchase> GetItems(bool showEmptyItemCode);
        IEnumerable<ItemPurchaseGrid> GetItems(DTOs.StockFilterView filter);
        IEnumerable<ItemPurchase> GetItemsBySupplierAndBill(string supplierName, string billNo);
        decimal GetTotalAmountBySupplierAndBill(string supplierName, string billNo);
        decimal GetTotalPurchaseItemCount(DTOs.StockFilterView filter);
        decimal GetTotalSalesItemCount(DTOs.StockFilterView filter);
        decimal GetTotalItemCount(string code);
        decimal GetTotalItemAmount(DTOs.StockFilterView filter);
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
