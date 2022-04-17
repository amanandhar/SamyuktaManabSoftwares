using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;

namespace GrocerySupplyManagementApp.Services
{
    public class QuantitySettingService : IQuantitySettingService
    {
        private readonly IQuantitySettingRepository _quantitySettingRepository;

        public QuantitySettingService(IQuantitySettingRepository quantitySettingRepository)
        {
            _quantitySettingRepository = quantitySettingRepository;
        }

        public QuantitySetting GetQuantitySetting(long itemId)
        {
            return _quantitySettingRepository.GetQuantitySetting(itemId);
        }

        public QuantitySetting AddQuantitySetting(QuantitySetting quantitySetting)
        {
            return _quantitySettingRepository.AddQuantitySetting(quantitySetting);
        }

        public QuantitySetting UpdateQuantitySetting(long id, QuantitySetting quantitySetting)
        {
            return _quantitySettingRepository.UpdateQuantitySetting(id, quantitySetting);
        }
    }
}
