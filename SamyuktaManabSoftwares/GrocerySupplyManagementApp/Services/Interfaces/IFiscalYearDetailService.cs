using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IFiscalYearDetailService
    {
        FiscalYear GetFiscalYearDetail();
        bool AddFiscalYearDetail(FiscalYear fiscalYearDetail, bool truncate);
        bool UpdateFiscalYearDetail(FiscalYear fiscalYearDetail);
    }
}
