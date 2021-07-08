using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ITaxDetailRepository
    {
        Tax GetTaxDetail();
        bool AddTaxDetail(Tax taxDetail, bool truncate);
        bool UpdateTaxDetail(Tax taxDetail);
    }
}
