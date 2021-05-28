using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class ItemTransactionService : IItemTransactionService
    {
        private readonly IItemTransactionRepository _itemTransactionRepository;

        public ItemTransactionService(IItemTransactionRepository itemTransactionRepository)
        {
            _itemTransactionRepository = itemTransactionRepository;
        }

        public IEnumerable<ItemTransaction> GetItems(bool showEmptyItemCode)
        {
            return _itemTransactionRepository.GetItems(showEmptyItemCode);
        }

        public IEnumerable<ItemTransactionGrid> GetItems(DTOs.StockFilterView filter)
        {
            if (filter?.DateFrom == "    -  -" || filter?.DateTo == "    -  -")
            {
                filter.DateFrom = null;
                filter.DateTo = null;
            }

            return _itemTransactionRepository.GetItems(filter);
        }

        public IEnumerable<ItemTransaction> GetItemsBySupplierAndBill(string supplierName, string billNo)
        {
            return _itemTransactionRepository.GetItemsBySupplierAndBill(supplierName, billNo);
        }

        public decimal GetTotalAmountBySupplierAndBill(string supplierName, string billNo)
        {
            return _itemTransactionRepository.GetTotalAmountBySupplierAndBill(supplierName, billNo);
        }

        public int GetTotalItemCount(DTOs.StockFilterView filter)
        {
            if (filter?.DateFrom == "    -  -" || filter?.DateTo == "    -  -")
            {
                filter.DateFrom = null;
                filter.DateTo = null;
            }
            else
            {
                filter.DateTo += " 23:59:59.999";
            }

            return _itemTransactionRepository.GetTotalItemCount(filter);
        }

        public IEnumerable<string> GetAllItemNames()
        {
            return _itemTransactionRepository.GetAllItemNames();
        }

        public ItemTransaction GetItem(long itemId)
        {
            return _itemTransactionRepository.GetItem(itemId);
        }

        public ItemTransaction AddItem(ItemTransaction item)
        {
            return _itemTransactionRepository.AddItem(item);
        }

        public ItemTransaction UpdateItem(ItemTransaction item)
        {
            return _itemTransactionRepository.UpdateItem(item);
        }

        public bool DeleteItem(string name, string brand)
        {
            return _itemTransactionRepository.DeleteItem(name, brand);
        }

        public bool DeleteItemBySupplierAndBill(string supplierName, string billNo)
        {
            return _itemTransactionRepository.DeleteItemBySupplierAndBill(supplierName, billNo);
        }
    }
}
