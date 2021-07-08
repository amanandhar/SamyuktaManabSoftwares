using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface ITaxDetailService
    {
        TaxDetail GetTaxDetail();
        bool AddTaxDetail(TaxDetail TaxDetail, bool truncate);
        bool UpdateTaxDetail(TaxDetail TaxDetail);
    }
}
