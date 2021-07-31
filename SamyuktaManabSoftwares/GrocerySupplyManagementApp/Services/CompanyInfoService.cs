using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;

namespace GrocerySupplyManagementApp.Services
{
    public class CompanyInfoService : ICompanyInfoService
    {
        private readonly ICompanyInfoRepository _companyInfoRepository;

        public CompanyInfoService(ICompanyInfoRepository companyInfoRepository)
        {
            _companyInfoRepository = companyInfoRepository;
        }

        public CompanyInfo GetCompanyInfo()
        {
            return _companyInfoRepository.GetCompanyInfo();
        }

        public CompanyInfo AddCompanyInfo(CompanyInfo companyInfo)
        {
            return _companyInfoRepository.AddCompanyInfo(companyInfo);
        }

        public bool DeleteCompanyInfo()
        {
            return _companyInfoRepository.DeleteCompanyInfo();
        }
    }
}
