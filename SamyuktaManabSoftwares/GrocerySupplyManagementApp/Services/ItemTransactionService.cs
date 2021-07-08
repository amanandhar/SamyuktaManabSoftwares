using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class ItemTransactionService : IItemTransactionService
    {
        private readonly IPurchasedItemRepository _itemTransactionRepository;
        private readonly IFiscalYearDetailRepository _fiscalYearDetailRepository;

        public ItemTransactionService(IPurchasedItemRepository itemTransactionRepository,
            IFiscalYearDetailRepository fiscalYearDetailRepository)
        {
            _itemTransactionRepository = itemTransactionRepository;
            _fiscalYearDetailRepository = fiscalYearDetailRepository;
        }

        public IEnumerable<PurchasedItem> GetItems(bool showEmptyItemCode)
        {
            return _itemTransactionRepository.GetItems(showEmptyItemCode);
        }

        public IEnumerable<StockView> GetStockView(StockFilterView filter)
        {
            if (filter?.DateFrom == "    -  -" || filter?.DateTo == "    -  -")
            {
                filter.DateFrom = null;
                filter.DateTo = null;
            }

            return _itemTransactionRepository.GetStockView(filter);
        }

        public IEnumerable<PurchasedItem> GetItemsBySupplierAndBill(string supplierName, string billNo)
        {
            return _itemTransactionRepository.GetItemsBySupplierAndBill(supplierName, billNo);
        }

        public decimal GetTotalAmountBySupplierAndBill(string supplierName, string billNo)
        {
            return _itemTransactionRepository.GetTotalAmountBySupplierAndBill(supplierName, billNo);
        }

        public long GetTotalPurchaseItemCount(DTOs.StockFilterView filter)
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

            return _itemTransactionRepository.GetTotalPurchaseItemCount(filter);
        }

        public long GetTotalSalesItemCount(DTOs.StockFilterView filter)
        {
            if (filter?.DateFrom == "    -  -" || filter?.DateTo == "    -  -")
            {
                filter.DateFrom = null;
                filter.DateTo = null;
            }
            else if (!string.IsNullOrWhiteSpace(filter.DateTo))
            {
                filter.DateTo += " 23:59:59.999";
            }

            return _itemTransactionRepository.GetTotalSalesItemCount(filter);
        }

        public decimal GetTotalPurchaseItemAmount(DTOs.StockFilterView filter)
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

            return _itemTransactionRepository.GetTotalPurchaseItemAmount(filter);
        }

        public decimal GetTotalSalesItemAmount(DTOs.StockFilterView filter)
        {
            if (filter?.DateFrom == "    -  -" || filter?.DateTo == "    -  -")
            {
                filter.DateFrom = null;
                filter.DateTo = null;
            }
            else if (!string.IsNullOrWhiteSpace(filter.DateTo) && !filter.DateTo.Contains("23:59:59.999"))
            {
                filter.DateTo += " 23:59:59.999";
            }

            return _itemTransactionRepository.GetTotalSalesItemAmount(filter);
        }

        public IEnumerable<string> GetAllItemNames()
        {
            return _itemTransactionRepository.GetAllItemNames();
        }

        public IEnumerable<string> GetAllItemCodes()
        {
            return _itemTransactionRepository.GetAllItemCodes();
        }

        public PurchasedItem GetItem(long itemId)
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

        public PurchasedItem AddItem(PurchasedItem item)
        {
            return _itemTransactionRepository.AddItem(item);
        }

        public PurchasedItem UpdateItem(PurchasedItem item)
        {
            return _itemTransactionRepository.UpdateItem(item);
        }

        public bool DeleteItem(string name, string brand)
        {
            return _itemTransactionRepository.DeleteItem(name, brand);
        }

        public bool DeleteItemTransaction(string billNo)
        {
            return _itemTransactionRepository.DeleteItemTransaction(billNo);
        }
    }
}
