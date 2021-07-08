using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IFiscalYearDetailRepository
    {
        FiscalYearDetail GetFiscalYearDetail();
        bool AddFiscalYearDetail(FiscalYearDetail fiscalYearDetail, bool truncate);
        bool UpdateFiscalYearDetail(FiscalYearDetail fiscalYearDetail);
    }
}
