using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface ITaxService
    {
        Tax GetTax();
        bool AddTax(Tax Tax, bool truncate);
        bool UpdateTax(Tax Tax);
    }
}
