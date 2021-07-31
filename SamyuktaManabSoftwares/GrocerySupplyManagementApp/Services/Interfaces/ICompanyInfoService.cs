using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface ICompanyInfoService
    {
        CompanyInfo GetCompanyInfo();
        CompanyInfo AddCompanyInfo(CompanyInfo companyInfo);
        bool DeleteCompanyInfo();
    }
}
