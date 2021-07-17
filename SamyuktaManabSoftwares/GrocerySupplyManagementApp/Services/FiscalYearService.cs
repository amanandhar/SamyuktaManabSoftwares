using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;

namespace GrocerySupplyManagementApp.Services
{
    public class FiscalYearService: IFiscalYearService
    {
        private readonly IFiscalYearRepository _fiscalYearRepository;

        public FiscalYearService(IFiscalYearRepository fiscalYearRepository)
        {
            _fiscalYearRepository = fiscalYearRepository;
        }

        public FiscalYear GetFiscalYear()
        {
            return _fiscalYearRepository.GetFiscalYear();
        }

        public bool AddFiscalYear(FiscalYear fiscalYear, bool truncate = false)
        {
            return _fiscalYearRepository.AddFiscalYear(fiscalYear, truncate);
        }

        public bool UpdateFiscalYear(FiscalYear fiscalYear)
        {
            return _fiscalYearRepository.UpdateFiscalYear(fiscalYear);
        }
    }
}
