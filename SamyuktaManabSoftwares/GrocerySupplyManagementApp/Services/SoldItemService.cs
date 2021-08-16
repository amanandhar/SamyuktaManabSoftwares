﻿using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class SoldItemService : ISoldItemService
    {
        private readonly ISoldItemRepository _soldItemRepository;

        public SoldItemService(ISoldItemRepository soldItemRepository)
        {
            _soldItemRepository = soldItemRepository;
        }

        public IEnumerable<SoldItem> GetSoldItems()
        {
            return _soldItemRepository.GetSoldItems();
        }

        public SoldItem GetSoldItem(long soldItemId)
        {
            return _soldItemRepository.GetSoldItem(soldItemId);
        }

        public IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo)
        {
            return _soldItemRepository.GetSoldItemViewList(invoiceNo);
        }

        public long GetSoldItemTotalQuantity(StockFilter stockFilter)
        {
            if (stockFilter?.DateFrom == "    -  -" || stockFilter?.DateTo == "    -  -")
            {
                stockFilter.DateFrom = null;
                stockFilter.DateTo = null;
            }
            else if (!string.IsNullOrWhiteSpace(stockFilter.DateTo))
            {
                stockFilter.DateTo += " 23:59:59.999";
            }

            return _soldItemRepository.GetSoldItemTotalQuantity(stockFilter);
        }

        public decimal GetSoldItemTotalAmount(StockFilter stockFilter)
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

            return _soldItemRepository.GetSoldItemTotalAmount(stockFilter);
        }

        public IEnumerable<string> GetSoldItemCodes()
        {
            return _soldItemRepository.GetSoldItemCodes();
        }

        public SoldItem AddSoldItem(SoldItem soldItem)
        {
            return _soldItemRepository.AddSoldItem(soldItem);
        }

        public SoldItem UpdateSoldItem(long soldItemId, SoldItem soldItem)
        {
            return _soldItemRepository.UpdateSoldItem(soldItemId, soldItem);
        }

        public bool DeleteSoldItem(string invoiceNo)
        {
            return _soldItemRepository.DeleteSoldItem(invoiceNo);
        }

        public bool DeleteSoldItemAfterEndOfDay(string endOfDay)
        {
            return _soldItemRepository.DeleteSoldItemAfterEndOfDay(endOfDay);
        }
    }
}
