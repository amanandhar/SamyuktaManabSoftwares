using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ICompanyInfoRepository
    {
        CompanyInfo GetCompanyInfo();
        CompanyInfo AddCompanyInfo(CompanyInfo companyInfo);
        bool DeleteCompanyInfo();
    }
}
