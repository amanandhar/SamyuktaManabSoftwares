using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;

namespace GrocerySupplyManagementApp.Services
{
    public class FiscalYearDetailService: IFiscalYearDetailService
    {
        private readonly IFiscalYearDetailRepository _fiscalYearDetailRepository;

        public FiscalYearDetailService(IFiscalYearDetailRepository fiscalYearDetailRepository)
        {
            _fiscalYearDetailRepository = fiscalYearDetailRepository;
        }

        public FiscalYear GetFiscalYearDetail()
        {
            return _fiscalYearDetailRepository.GetFiscalYearDetail();
        }

        public bool AddFiscalYearDetail(FiscalYear fiscalYearDetail, bool truncate = false)
        {
            return _fiscalYearDetailRepository.AddFiscalYearDetail(fiscalYearDetail, truncate);
        }

        public bool UpdateFiscalYearDetail(FiscalYear fiscalYearDetail)
        {
            return _fiscalYearDetailRepository.UpdateFiscalYearDetail(fiscalYearDetail);
        }
    }
}
