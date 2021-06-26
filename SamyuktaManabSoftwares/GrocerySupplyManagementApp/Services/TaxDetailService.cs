using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;

namespace GrocerySupplyManagementApp.Services
{
    public class TaxDetailService : ITaxDetailService
    {
        private readonly ITaxDetailRepository _taxDetailRepository;

        public TaxDetailService(ITaxDetailRepository TaxDetailRepository)
        {
            _taxDetailRepository = TaxDetailRepository;
        }

        public TaxDetail GetTaxDetail()
        {
            return _taxDetailRepository.GetTaxDetail();
        }

        public bool AddTaxDetail(TaxDetail TaxDetail, bool truncate = false)
        {
            return _taxDetailRepository.AddTaxDetail(TaxDetail, truncate);
        }

        public bool UpdateTaxDetail(TaxDetail TaxDetail)
        {
            return _taxDetailRepository.UpdateTaxDetail(TaxDetail);
        }
    }
}
