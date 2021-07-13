using GrocerySupplyManagementApp.DTOs;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IIncomeDetailService
    {
        IEnumerable<IncomeDetailView> GetDeliveryCharge();
        IEnumerable<IncomeDetailView> GetMemberFee();
        IEnumerable<IncomeDetailView> GetOtherIncome();
        IEnumerable<IncomeDetailView> GetSalesProfit();
    }
}
