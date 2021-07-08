using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IFiscalYearDetailRepository
    {
        FiscalYear GetFiscalYearDetail();
        bool AddFiscalYearDetail(FiscalYear fiscalYearDetail, bool truncate);
        bool UpdateFiscalYearDetail(FiscalYear fiscalYearDetail);
    }
}
