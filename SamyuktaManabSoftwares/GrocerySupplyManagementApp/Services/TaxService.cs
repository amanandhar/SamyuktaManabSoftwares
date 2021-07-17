using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;

namespace GrocerySupplyManagementApp.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _taxRepository;

        public TaxService(ITaxRepository TaxRepository)
        {
            _taxRepository = TaxRepository;
        }

        public Tax GetTax()
        {
            return _taxRepository.GetTax();
        }

        public bool AddTax(Tax Tax, bool truncate = false)
        {
            return _taxRepository.AddTax(Tax, truncate);
        }

        public bool UpdateTax(Tax Tax)
        {
            return _taxRepository.UpdateTax(Tax);
        }
    }
}
