using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services
{
    public interface IFiscalYearDetailService
    {
        FiscalYearDetail GetFiscalYearDetail();

        bool AddFiscalYearDetail(FiscalYearDetail fiscalYearDetail, bool truncate);

        bool UpdateFiscalYearDetail(FiscalYearDetail fiscalYearDetail);
    }
}
