using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IFiscalYearDetailService
    {
        FiscalYearDetail GetFiscalYearDetail();
        bool AddFiscalYearDetail(FiscalYearDetail fiscalYearDetail, bool truncate);
        bool UpdateFiscalYearDetail(FiscalYearDetail fiscalYearDetail);
    }
}
