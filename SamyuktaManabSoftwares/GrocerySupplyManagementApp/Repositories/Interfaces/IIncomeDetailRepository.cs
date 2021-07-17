using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IIncomeDetailRepository
    {
        IEnumerable<IncomeDetailView> GetDeliveryCharge();
        IEnumerable<IncomeDetailView> GetMemberFee();
        IEnumerable<IncomeDetailView> GetOtherIncome();
        IEnumerable<IncomeDetailView> GetSalesProfit();
    }
}
