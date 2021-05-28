using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;

namespace GrocerySupplyManagementApp.Services
{
    public class FiscalYearDetailService: IFiscalYearDetailService
    {
        private readonly IFiscalYearDetailRepository _fiscalYearDetailRepository;

        public FiscalYearDetailService(IFiscalYearDetailRepository fiscalYearDetailRepository)
        {
            _fiscalYearDetailRepository = fiscalYearDetailRepository;
        }

        public FiscalYearDetail GetFiscalYearDetail()
        {
            return _fiscalYearDetailRepository.GetFiscalYearDetail();
        }

        public bool AddFiscalYearDetail(FiscalYearDetail fiscalYearDetail, bool truncate = false)
        {
            return _fiscalYearDetailRepository.AddFiscalYearDetail(fiscalYearDetail, truncate);
        }

        public bool UpdateFiscalYearDetail(FiscalYearDetail fiscalYearDetail)
        {
            return _fiscalYearDetailRepository.UpdateFiscalYearDetail(fiscalYearDetail);
        }
    }
}
