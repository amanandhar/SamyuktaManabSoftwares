using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
using System;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class PosSoldItemService : IPosSoldItemService
    {
        private readonly IPosSoldItemRepository _posSoldItemRepository;

        public PosSoldItemService(IPosSoldItemRepository posSoldItemRepository)
        {
            _posSoldItemRepository = posSoldItemRepository;
        }

        public IEnumerable<PosSoldItem> GetPosSoldItems()
        {
            return _posSoldItemRepository.GetPosSoldItems();
        }

        public PosSoldItem GetPosSoldItem(long posSoldItemId)
        {
            return _posSoldItemRepository.GetPosSoldItem(posSoldItemId);
        }

        public PosSoldItem AddPosSoldItem(PosSoldItem posSoldItem)
        {
            return _posSoldItemRepository.AddPosSoldItem(posSoldItem);
        }
        public PosSoldItem UpdatePosSoldItem(long posSoldItemId, PosSoldItem posSoldItem)
        {
            return _posSoldItemRepository.UpdatePosSoldItem(posSoldItemId, posSoldItem);
        }

        public bool DeleteSupplierTransaction(long posSoldItemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PosSoldItemGrid> GetPosSoldItemGrid(string invoiceNo)
        {
            return _posSoldItemRepository.GetPosSoldItemGrid(invoiceNo);
        }
    }
}
