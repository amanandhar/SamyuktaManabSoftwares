using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
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

        public SoldItem AddSoldItem(SoldItem soldItem)
        {
            return _soldItemRepository.AddSoldItem(soldItem);
        }
        public SoldItem UpdateSoldItem(long soldItemId, SoldItem soldItem)
        {
            return _soldItemRepository.UpdateSoldItem(soldItemId, soldItem);
        }

        public bool DeleteSupplierTransaction(long soldItemId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSoldItem(string invoiceNo)
        {
            return _soldItemRepository.DeleteSoldItem(invoiceNo);
        }

        public IEnumerable<SoldItemView> GetSoldItemViewList(string invoiceNo)
        {
            return _soldItemRepository.GetSoldItemViewList(invoiceNo);
        }
    }
}
