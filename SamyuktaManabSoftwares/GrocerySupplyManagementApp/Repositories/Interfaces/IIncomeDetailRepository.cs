using GrocerySupplyManagementApp.DTOs;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IIncomeDetailRepository
    {
        IEnumerable<IncomeDetailView> GetDeliveryCharge();
        IEnumerable<IncomeDetailView> GetMemberFee();
        IEnumerable<IncomeDetailView> GetOtherIncome();
        IEnumerable<IncomeDetailView> GetSalesProfit();
        IEnumerable<IncomeDetailView> GetSupplilersCommission();
    }
}
