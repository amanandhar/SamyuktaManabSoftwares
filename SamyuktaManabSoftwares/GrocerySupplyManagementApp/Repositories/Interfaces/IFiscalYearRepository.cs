using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IFiscalYearRepository
    {
        FiscalYear GetFiscalYear();

        bool AddFiscalYear(FiscalYear fiscalYear, bool truncate);

        bool UpdateFiscalYear(FiscalYear fiscalYear);
    }
}
