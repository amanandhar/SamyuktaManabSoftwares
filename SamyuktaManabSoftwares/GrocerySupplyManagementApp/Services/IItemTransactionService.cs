using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IItemTransactionService
    {
        IEnumerable<ItemTransaction> GetItems(bool showEmptyItemCode);
        IEnumerable<ItemTransactionGrid> GetItems(DTOs.StockFilterView filter);
        IEnumerable<ItemTransaction> GetItemsBySupplierAndBill(string supplierName, string billNo);
        decimal GetTotalAmountBySupplierAndBill(string supplierName, string billNo);
        int GetTotalItemCount(DTOs.StockFilterView filter);
        IEnumerable<string> GetAllItemNames();
        ItemTransaction GetItem(long itemId);
        ItemTransaction AddItem(ItemTransaction item);
        ItemTransaction UpdateItem(ItemTransaction item);
        bool DeleteItem(string name, string brand);
        bool DeleteItemBySupplierAndBill(string supplierName, string billNo);
    }
}
