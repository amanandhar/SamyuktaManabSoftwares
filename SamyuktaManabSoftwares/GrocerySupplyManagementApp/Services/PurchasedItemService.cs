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

        public long GetPurchasedItemTotalQuantity(StockFilter stockFilter)
        {
            return _purchasedItemRepository.GetPurchasedItemTotalQuantity(stockFilter);
        }

        public PurchasedItem GetPurchasedItemByItemId(long itemId)
        {
            return _purchasedItemRepository.GetPurchasedItemByItemId(itemId);
        }

        public string GetLastBillNo()
        {
            string billNo = string.Empty;
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
                UtilityService.ShowExceptionMessageBox();
            }

            return billNo;
        }

        public PurchasedItem AddPurchasedItem(PurchasedItem purchasedItem)
        {
            return _purchasedItemRepository.AddPurchasedItem(purchasedItem);
        }

        public bool DeletePurchasedItem(string billNo)
        {
            return _purchasedItemRepository.DeletePurchasedItem(billNo);
        }
    }
}
