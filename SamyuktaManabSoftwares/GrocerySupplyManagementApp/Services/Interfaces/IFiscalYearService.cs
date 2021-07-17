using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IFiscalYearService
    {
        FiscalYear GetFiscalYear();
        bool AddFiscalYear(FiscalYear fiscalYear, bool truncate);
        bool UpdateFiscalYear(FiscalYear fiscalYear);
    }
}
