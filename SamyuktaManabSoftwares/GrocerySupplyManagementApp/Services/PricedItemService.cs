using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class PricedItemService : IPricedItemService
    {
        private readonly IPricedItemRepository _pricedItemRepository;

        public PricedItemService(IPricedItemRepository pricedItemRepository)
        {
            _pricedItemRepository = pricedItemRepository;
        }

        public PricedItem GetPricedItem(long id)
        {
            return _pricedItemRepository.GetPricedItem(id);
        }

        public PricedItem GetPricedItem(string itemCode)
        {
            return _pricedItemRepository.GetPricedItem(itemCode);
        }

        public PricedItem GetPricedItem(string itemCode, string itemSubCode)
        {
            return _pricedItemRepository.GetPricedItem(itemCode, itemSubCode);
        }

        public PricedItem GetPricedItemByBarcode(string itemBarcode)
        {
            return _pricedItemRepository.GetPricedItemByBarcode(itemBarcode);
        }

        public IEnumerable<PricedItemView> GetPricedItemViewList()
        {
            return _pricedItemRepository.GetPricedItemViewList();
        }

        public IEnumerable<UnpricedItemView> GetUnpricedItemViewList()
        {
            return _pricedItemRepository.GetUnpricedItemViewList();
        }

        public PricedItem AddPricedItem(PricedItem pricedItem)
        {
            return _pricedItemRepository.AddPricedItem(pricedItem);
        }

        public PricedItem UpdatePricedItem(long id, PricedItem pricedItem)
        {
            return _pricedItemRepository.UpdatePricedItem(id, pricedItem);
        }

        public bool DeletePricedItem(long id)
        {
            return _pricedItemRepository.DeletePricedItem(id);
        } 
    }
}
