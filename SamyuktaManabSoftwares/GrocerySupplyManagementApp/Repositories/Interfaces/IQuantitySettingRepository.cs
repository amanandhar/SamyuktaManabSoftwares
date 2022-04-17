using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IQuantitySettingRepository
    {
        QuantitySetting GetQuantitySetting(long itemId);
        QuantitySetting AddQuantitySetting(QuantitySetting quantitySetting);
        QuantitySetting UpdateQuantitySetting(long id, QuantitySetting quantitySetting);
    }
}
