using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;

namespace GrocerySupplyManagementApp.Services
{
    public class TaxDetailService : ITaxDetailService
    {
        private readonly ITaxDetailRepository _taxDetailRepository;

        public TaxDetailService(ITaxDetailRepository TaxDetailRepository)
        {
            _taxDetailRepository = TaxDetailRepository;
        }

        public Tax GetTaxDetail()
        {
            return _taxDetailRepository.GetTaxDetail();
        }

        public bool AddTaxDetail(Tax TaxDetail, bool truncate = false)
        {
            return _taxDetailRepository.AddTaxDetail(TaxDetail, truncate);
        }

        public bool UpdateTaxDetail(Tax TaxDetail)
        {
            return _taxDetailRepository.UpdateTaxDetail(TaxDetail);
        }
    }
}
