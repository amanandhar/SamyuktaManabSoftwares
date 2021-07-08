using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class SoldItemService : ISoldItemService
    {
        private readonly ISoldItemRepository _posSoldItemRepository;

        public SoldItemService(ISoldItemRepository posSoldItemRepository)
        {
            _posSoldItemRepository = posSoldItemRepository;
        }

        public IEnumerable<SoldItem> GetPosSoldItems()
        {
            return _posSoldItemRepository.GetPosSoldItems();
        }

        public SoldItem GetPosSoldItem(long posSoldItemId)
        {
            return _posSoldItemRepository.GetPosSoldItem(posSoldItemId);
        }

        public SoldItem AddPosSoldItem(SoldItem posSoldItem)
        {
            return _posSoldItemRepository.AddPosSoldItem(posSoldItem);
        }
        public SoldItem UpdatePosSoldItem(long posSoldItemId, SoldItem posSoldItem)
        {
            return _posSoldItemRepository.UpdatePosSoldItem(posSoldItemId, posSoldItem);
        }

        public bool DeleteSupplierTransaction(long posSoldItemId)
        {
            throw new NotImplementedException();
        }

        public bool DeletePosSoldItem(string invoiceNo)
        {
            return _posSoldItemRepository.DeletePosSoldItem(invoiceNo);
        }

        public IEnumerable<SoldItemView> GetPosSoldItemGrid(string invoiceNo)
        {
            return _posSoldItemRepository.GetPosSoldItemGrid(invoiceNo);
        }
    }
}
