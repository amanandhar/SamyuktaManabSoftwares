using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
using System;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class ItemTransactionService : IItemTransactionService
    {
        private readonly IItemPurchaseRepository _itemTransactionRepository;
        private readonly IFiscalYearDetailRepository _fiscalYearDetailRepository;

        public ItemTransactionService(IItemPurchaseRepository itemTransactionRepository,
            IFiscalYearDetailRepository fiscalYearDetailRepository)
        {
            _itemTransactionRepository = itemTransactionRepository;
            _fiscalYearDetailRepository = fiscalYearDetailRepository;
        }

        public IEnumerable<ItemPurchase> GetItems(bool showEmptyItemCode)
        {
            return _itemTransactionRepository.GetItems(showEmptyItemCode);
        }

        public IEnumerable<ItemPurchaseGrid> GetItems(DTOs.StockFilterView filter)
        {
            if (filter?.DateFrom == "    -  -" || filter?.DateTo == "    -  -")
            {
                filter.DateFrom = null;
                filter.DateTo = null;
            }

            return _itemTransactionRepository.GetItems(filter);
        }

        public IEnumerable<ItemPurchase> GetItemsBySupplierAndBill(string supplierName, string billNo)
        {
            return _itemTransactionRepository.GetItemsBySupplierAndBill(supplierName, billNo);
        }

        public decimal GetTotalAmountBySupplierAndBill(string supplierName, string billNo)
        {
            return _itemTransactionRepository.GetTotalAmountBySupplierAndBill(supplierName, billNo);
        }

        public decimal GetTotalItemCount(DTOs.StockFilterView filter)
        {
            if (filter?.DateFrom == "    -  -" || filter?.DateTo == "    -  -")
            {
                filter.DateFrom = null;
                filter.DateTo = null;
            }
            else if(!string.IsNullOrWhiteSpace(filter.DateTo))
            {
                filter.DateTo += " 23:59:59.999";
            }

            return _itemTransactionRepository.GetTotalItemCount(filter);
        }

        public decimal GetTotalItemCount(string code)
        {

            return _itemTransactionRepository.GetTotalItemCount(code);
        }

        public decimal GetTotalItemAmount(DTOs.StockFilterView filter)
        {
            if (filter?.DateFrom == "    -  -" || filter?.DateTo == "    -  -")
            {
                filter.DateFrom = null;
                filter.DateTo = null;
            }
            else if(!string.IsNullOrWhiteSpace(filter.DateTo) && !filter.DateTo.Contains("23:59:59.999"))
            {
                filter.DateTo += " 23:59:59.999";
            }

            return _itemTransactionRepository.GetTotalItemAmount(filter);
        }

        public IEnumerable<string> GetAllItemNames()
        {
            return _itemTransactionRepository.GetAllItemNames();
        }

        public IEnumerable<string> GetAllItemCodes()
        {
            return _itemTransactionRepository.GetAllItemCodes();
        }

        public ItemPurchase GetItem(long itemId)
        {
            return _itemTransactionRepository.GetItem(itemId);
        }

        public long GetItemId(string supplierName, string billNo)
        {
            return _itemTransactionRepository.GetItemId(supplierName, billNo);
        }

        public string GetBillNo()
        {
            string billNo;
            try
            {
                var lastBillNo = _itemTransactionRepository.GetLastBillNo();
                if (string.IsNullOrWhiteSpace(lastBillNo))
                {
                    var fiscalYearDetail = _fiscalYearDetailRepository.GetFiscalYearDetail();
                    billNo = fiscalYearDetail.BillNo;
                }
                else
                {
                    var formats = lastBillNo.Split('-');
                    var prefix = formats[0];
                    var year = formats[1];
                    var value = formats[2];
                    var trimmedValue = (Convert.ToInt64(value.TrimStart(new char[] { '0' })) + 1).ToString();

                    while (trimmedValue.Length < value.Length)
                    {
                        trimmedValue = "0" + trimmedValue;
                    }

                    billNo = prefix + "-" + year + "-" + trimmedValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return billNo;
        }

        public ItemPurchase AddItem(ItemPurchase item)
        {
            return _itemTransactionRepository.AddItem(item);
        }

        public ItemPurchase UpdateItem(ItemPurchase item)
        {
            return _itemTransactionRepository.UpdateItem(item);
        }

        public bool DeleteItem(string name, string brand)
        {
            return _itemTransactionRepository.DeleteItem(name, brand);
        }

        public bool DeleteItemTransactionBySupplierAndBill(string supplierName, string billNo)
        {
            return _itemTransactionRepository.DeleteItemTransactionBySupplierAndBill(supplierName, billNo);
        }
    }
}
