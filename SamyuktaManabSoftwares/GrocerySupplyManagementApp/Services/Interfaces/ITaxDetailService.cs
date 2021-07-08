using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface ITaxDetailService
    {
        Tax GetTaxDetail();
        bool AddTaxDetail(Tax TaxDetail, bool truncate);
        bool UpdateTaxDetail(Tax TaxDetail);
    }
}
