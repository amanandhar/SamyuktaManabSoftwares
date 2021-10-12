using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;

namespace GrocerySupplyManagementApp.Services
{
    public class CapitalService : ICapitalService
    {
        private readonly ICapitalRepository _capitalRepository;

        public CapitalService(ICapitalRepository capitalRepository)
        {
            _capitalRepository = capitalRepository;
        }

        public decimal GetMemberTotalBalance(UserTransactionFilter userTransactionFilter)
        {
            return _capitalRepository.GetMemberTotalBalance(userTransactionFilter);
        }

        public decimal GetSupplierTotalBalance(SupplierTransactionFilter supplierTransactionFilter)
        {
            return _capitalRepository.GetSupplierTotalBalance(supplierTransactionFilter);
        }

        public decimal GetUserTransactionBalance(DailyTransactionFilter dailyTransactionFilter)
        {
            return _capitalRepository.GetUserTransactionBalance(dailyTransactionFilter);
        }

        public decimal GetCashInHand(UserTransactionFilter userTransactionFilter)
        {
            return _capitalRepository.GetCashInHand(userTransactionFilter);
        }

        public decimal GetOpeningCashBalance(string endOfDay)
        {
            return _capitalRepository.GetOpeningCashBalance(endOfDay);
        }

        public decimal GetOpeningCreditBalance(string endOfDay)
        {
            return _capitalRepository.GetOpeningCreditBalance(endOfDay);
        }

        public decimal GetCashBalance(string endOfDay)
        {
            return _capitalRepository.GetCashBalance(endOfDay);
        }

        public decimal GetCreditBalance(string endOfDay)
        {
            return _capitalRepository.GetCreditBalance(endOfDay);
        }

        public decimal GetTotalCashPayment(string endOfDay)
        {
            return _capitalRepository.GetTotalCashPayment(endOfDay);
        }
        
        public decimal GetTotalChequePayment(string endOfDay)
        {
            return _capitalRepository.GetTotalChequePayment(endOfDay);
        }

        public decimal GetTotalBalance(string endOfDay, string action, string actionType)
        {
            return _capitalRepository.GetTotalBalance(endOfDay, action, actionType);
        }

        public decimal GetPreviousTotalBalance(string endOfDay, string action, string actionType)
        {
            return _capitalRepository.GetPreviousTotalBalance(endOfDay, action, actionType);
        }
    }
}
