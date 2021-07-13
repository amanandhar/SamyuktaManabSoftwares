using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class IncomeDetailService : IIncomeDetailService
    {
        private readonly IIncomeDetailRepository _incomeDetailRepository;

        public IncomeDetailService(IIncomeDetailRepository incomeDetailRepository)
        {
            _incomeDetailRepository = incomeDetailRepository;
        }

        public IEnumerable<IncomeDetailView> GetDeliveryCharge()
        {
            return _incomeDetailRepository.GetDeliveryCharge();
        }

        public IEnumerable<IncomeDetailView> GetMemberFee()
        {
            return _incomeDetailRepository.GetMemberFee();
        }

        public IEnumerable<IncomeDetailView> GetOtherIncome()
        {
            return _incomeDetailRepository.GetOtherIncome();
        }

        public IEnumerable<IncomeDetailView> GetSalesProfit()
        {
            return _incomeDetailRepository.GetSalesProfit();
        }
    }
}
