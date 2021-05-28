using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface ITaxDetailRepository
    {
        TaxDetail GetTaxDetail();

        bool AddTaxDetail(TaxDetail taxDetail, bool truncate);

        bool UpdateTaxDetail(TaxDetail taxDetail);
    }
}
