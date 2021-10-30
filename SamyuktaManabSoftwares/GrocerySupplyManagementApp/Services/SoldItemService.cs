using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySupplyManagementApp.Services
{
    public class SoldItemService : ISoldItemService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly ISoldItemRepository _soldItemRepository;

        public SoldItemService(ISettingRepository settingRepository, ISoldItemRepository soldItemRepository)
        {
            _settingRepository = settingRepository;
            _soldItemRepository = soldItemRepository;
        }

        public IEnumerable<SoldItem> GetSoldItems()
        {
            return _soldItemRepository.GetSoldItems();
        }

        public IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo)
        {
            return _soldItemRepository.GetSoldItemViewList(invoiceNo);
        }

        public decimal GetSoldItemTotalQuantity(StockFilter stockFilter)
        {
            return _soldItemRepository.GetSoldItemTotalQuantity(stockFilter);
        }

        public string GetNewInvoiceNumber()
        {
            string invoiceNumber = string.Empty;
            var lastInvoiceNumber = _soldItemRepository.GetLastInvoiceNumber();
            if (string.IsNullOrWhiteSpace(lastInvoiceNumber))
            {
                var setting = _settingRepository.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
                invoiceNumber = setting.StartingInvoiceNo;
            }
            else
            {
                var formats = lastInvoiceNumber.Split('-');
                var prefix = formats[0];
                var year = formats[1];
                var value = formats[2];
                var trimmedValue = (Convert.ToInt64(value.TrimStart(new char[] { '0' })) + 1).ToString();

                while (trimmedValue.Length < value.Length)
                {
                    trimmedValue = "0" + trimmedValue;
                }

                invoiceNumber = prefix + "-" + year + "-" + trimmedValue;
            }
            
            return invoiceNumber;
        }

        public string GetLastInvoiceNumber()
        {
            return _soldItemRepository.GetLastInvoiceNumber();
        }

        public IEnumerable<string> GetInvoiceNumbers()
        {
            return _soldItemRepository.GetInvoiceNumbers();
        }

        public SoldItem AddSoldItem(SoldItem soldItem)
        {
            return _soldItemRepository.AddSoldItem(soldItem);
        }

        public bool DeleteSoldItem(string invoiceNo)
        {
            return _soldItemRepository.DeleteSoldItem(invoiceNo);
        }
    }
}
