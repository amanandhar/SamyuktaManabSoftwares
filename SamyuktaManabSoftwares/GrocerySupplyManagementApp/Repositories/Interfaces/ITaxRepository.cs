using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ITaxRepository
    {
        Tax GetTax();
        bool AddTax(Tax tax, bool truncate);
        bool UpdateTax(Tax tax);
    }
}
