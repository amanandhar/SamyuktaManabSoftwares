using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class PurchasedItemService : IPurchasedItemService
    {
        private readonly IPurchasedItemRepository _purchasedItemRepository;
        private readonly IFiscalYearRepository _fiscalYearRepository;

        public PurchasedItemService(IPurchasedItemRepository purchasedItemRepository,
            IFiscalYearRepository fiscalYearRepository)
        {
            _purchasedItemRepository = purchasedItemRepository;
            _fiscalYearRepository = fiscalYearRepository;
        }

        public IEnumerable<PurchasedItem> GetPurchasedItems()
        {
            return _purchasedItemRepository.GetPurchasedItems();
        }

        public PurchasedItem GetPurchasedItem(long id)
        {
            return _purchasedItemRepository.GetPurchasedItem(id);
        }

        public IEnumerable<PurchasedItemListView> GetPurchasedItemDetails()
        {
            return _purchasedItemRepository.GetPurchasedItemDetails();
        }

        public IEnumerable<PurchasedItem> GetPurchasedItemTotalQuantity()
        {
            return _purchasedItemRepository.GetPurchasedItemTotalQuantity();
        }

        public IEnumerable<StockView> GetStockView(StockFilterView filter)
        {
            return _purchasedItemRepository.GetStockView(filter);
        }

        public IEnumerable<PurchasedItem> GetPurchasedItemBySupplierAndBill(string supplierId, string billNo)
        {
            return _purchasedItemRepository.GetPurchasedItemBySupplierAndBill(supplierId, billNo);
        }

        public decimal GetPurchasedItemTotalAmount(string supplierId, string billNo)
        {
            return _purchasedItemRepository.GetPurchasedItemTotalAmount(supplierId, billNo);
        }

        public decimal GetPurchasedItemTotalAmount(StockFilterView filter)
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

            return _purchasedItemRepository.GetPurchasedItemTotalAmount(filter);
        }

        public long GetPurchasedItemTotalQuantity(StockFilterView filter)
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

            return _purchasedItemRepository.GetPurchasedItemTotalQuantity(filter);
        }

        public IEnumerable<string> GetPurchasedItemCodes()
        {
            return _purchasedItemRepository.GetPurchasedItemCodes();
        }

        public PurchasedItem GetPurchasedItemByItemId(long itemId)
        {
            return _purchasedItemRepository.GetPurchasedItemByItemId(itemId);
        }

        public long GetItemId(string supplierName, string billNo)
        {
            return _purchasedItemRepository.GetItemId(supplierName, billNo);
        }

        public string GetLastBillNo()
        {
            string billNo;
            try
            {
                var lastBillNo = _purchasedItemRepository.GetLastBillNo();
                if (string.IsNullOrWhiteSpace(lastBillNo))
                {
                    var fiscalYear = _fiscalYearRepository.GetFiscalYear();
                    billNo = fiscalYear.BillNo;
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

        public decimal GetLatestPurchasePrice(long itemId)
        {
            return _purchasedItemRepository.GetLatestPurchasePrice(itemId);
        }

        public PurchasedItem AddPurchasedItem(PurchasedItem purchasedItem)
        {
            return _purchasedItemRepository.AddPurchasedItem(purchasedItem);
        }

        public PurchasedItem UpdatePurchasedItem(long purchasedItemId, PurchasedItem puchasedItem)
        {
            return _purchasedItemRepository.UpdatePurchasedItem(purchasedItemId, puchasedItem);
        }

        public bool DeletePurchasedItem(long puchasedItemId)
        {
            return _purchasedItemRepository.DeletePurchasedItem(puchasedItemId);
        }

        public bool DeletePurchasedItem(string billNo)
        {
            return _purchasedItemRepository.DeletePurchasedItem(billNo);
        }

        public bool DeletePurchasedItem(string name, string brand)
        {
            return _purchasedItemRepository.DeletePurchasedItem(name, brand);
        }
    }
}
