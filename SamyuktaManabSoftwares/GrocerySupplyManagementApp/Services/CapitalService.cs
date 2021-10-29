using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;

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

        public decimal GetTotalSalesAndReceipt(CapitalTransactionFilter capitalTransactionFilter)
        {
            return _capitalRepository.GetTotalSalesAndReceipt(capitalTransactionFilter);
        }

        public decimal GetTotalPurchaseAndPayment(CapitalTransactionFilter capitalTransactionFilter)
        {
            return _capitalRepository.GetTotalPurchaseAndPayment(capitalTransactionFilter);
        }

        public decimal GetTotalBankTransfer(CapitalTransactionFilter capitalTransactionFilter)
        {
            return _capitalRepository.GetTotalBankTransfer(capitalTransactionFilter);
        }

        public decimal GetTotalExpense(CapitalTransactionFilter capitalTransactionFilter)
        {
            return _capitalRepository.GetTotalExpense(capitalTransactionFilter);
        }

        public decimal GetCashInHand(CapitalTransactionFilter capitalTransactionFilter)
        {
            var totalSalesAndReceiptInCash = GetTotalSalesAndReceipt(capitalTransactionFilter);
            var totalPurchaseAndPaymentInCash = GetTotalPurchaseAndPayment(capitalTransactionFilter);
            var totalBankTransferInCash = GetTotalBankTransfer(capitalTransactionFilter);
            var totalExpenseInCash = GetTotalExpense(capitalTransactionFilter);
            var cashInHand = Math.Abs(totalSalesAndReceiptInCash - (totalPurchaseAndPaymentInCash + totalBankTransferInCash + totalExpenseInCash));
            return cashInHand;
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
    }
}
