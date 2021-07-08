using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ITaxDetailRepository
    {
        TaxDetail GetTaxDetail();
        bool AddTaxDetail(TaxDetail taxDetail, bool truncate);
        bool UpdateTaxDetail(TaxDetail taxDetail);
    }
}
