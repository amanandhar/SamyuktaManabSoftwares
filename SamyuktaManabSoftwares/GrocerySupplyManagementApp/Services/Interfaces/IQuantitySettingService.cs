using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IQuantitySettingService
    {
        QuantitySetting GetQuantitySetting(long itemId);
        QuantitySetting AddQuantitySetting(QuantitySetting quantitySetting);
        QuantitySetting UpdateQuantitySetting(long id, QuantitySetting quantitySetting);
    }
}
