using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;

namespace GrocerySupplyManagementApp.Services
{
    public class TaxDetailService : ITaxDetailService
    {
        private readonly ITaxDetailRepository _TaxDetailRepository;

        public TaxDetailService(ITaxDetailRepository TaxDetailRepository)
        {
            _TaxDetailRepository = TaxDetailRepository;
        }

        public TaxDetail GetTaxDetail()
        {
            return _TaxDetailRepository.GetTaxDetail();
        }

        public bool AddTaxDetail(TaxDetail TaxDetail, bool truncate = false)
        {
            return _TaxDetailRepository.AddTaxDetail(TaxDetail, truncate);
        }

        public bool UpdateTaxDetail(TaxDetail TaxDetail)
        {
            return _TaxDetailRepository.UpdateTaxDetail(TaxDetail);
        }
    }
}
