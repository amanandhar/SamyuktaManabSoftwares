using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySupplyManagementApp.Services
{
    public class PurchasedItemService : IPurchasedItemService
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly IPurchasedItemRepository _purchasedItemRepository;
        private readonly ISettingRepository _settingRepository;

        public PurchasedItemService(IPurchasedItemRepository purchasedItemRepository,
            ISettingRepository settingRepository)
        {
            _purchasedItemRepository = purchasedItemRepository;
            _settingRepository = settingRepository;
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

        public IEnumerable<PurchasedItem> GetPurchasedItemBySupplierAndBill(string supplierId, string billNo)
        {
            return _purchasedItemRepository.GetPurchasedItemBySupplierAndBill(supplierId, billNo);
        }

        public decimal GetPurchasedItemTotalAmount(string supplierId, string billNo)
        {
            return _purchasedItemRepository.GetPurchasedItemTotalAmount(supplierId, billNo);
        }

        public decimal GetPurchasedItemTotalAmount(StockFilter stockFilter)
        {
            if (stockFilter?.DateFrom == "    -  -" || stockFilter?.DateTo == "    -  -")
            {
                stockFilter.DateFrom = null;
                stockFilter.DateTo = null;
            }
            else if (!string.IsNullOrWhiteSpace(stockFilter.DateTo) && !stockFilter.DateTo.Contains("23:59:59.999"))
            {
                stockFilter.DateTo += " 23:59:59.999";
            }

            return _purchasedItemRepository.GetPurchasedItemTotalAmount(stockFilter);
        }

        public long GetPurchasedItemTotalQuantity(StockFilter stockFilter)
        {
            return _purchasedItemRepository.GetPurchasedItemTotalQuantity(stockFilter);
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
                    var setting = _settingRepository.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
                    billNo = setting.StartingBillNo;
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
                logger.Error(ex);
                throw ex;
            }

            return billNo;
        }

        public string GetLastBonusNo()
        {
            string bonusNo;
            try
            {
                var lastBonusNo = _purchasedItemRepository.GetLastBonusNo();
                if (string.IsNullOrWhiteSpace(lastBonusNo))
                {
                    var setting = _settingRepository.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
                    var formats = setting.StartingBillNo.Split('-');
                    bonusNo =  Constants.BONUS_PREFIX + "-" + formats[1] + "-" + formats[2];
                }
                else
                {
                    var formats = lastBonusNo.Split('-');
                    var prefix = Constants.BONUS_PREFIX;
                    var year = formats[1];
                    var value = formats[2];
                    var trimmedValue = (Convert.ToInt64(value.TrimStart(new char[] { '0' })) + 1).ToString();

                    while (trimmedValue.Length < value.Length)
                    {
                        trimmedValue = "0" + trimmedValue;
                    }

                    bonusNo = prefix + "-" + year + "-" + trimmedValue;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return bonusNo;
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

        public bool DeletePurchasedItem(string billNo)
        {
            return _purchasedItemRepository.DeletePurchasedItem(billNo);
        }

        public bool DeletePurchasedItemAfterEndOfDay(string endOfDay)
        {
            return _purchasedItemRepository.DeletePurchasedItemAfterEndOfDay(endOfDay);
        }
    }
}
