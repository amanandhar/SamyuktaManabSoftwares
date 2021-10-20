using GrocerySupplyManagementApp.DTOs;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ICapitalRepository
    {
        decimal GetMemberTotalBalance(UserTransactionFilter userTransactionFilter);
        decimal GetSupplierTotalBalance(SupplierTransactionFilter supplierTransactionFilter);
        decimal GetCashInHand(UserTransactionFilter userTransactionFilter);
        decimal GetOpeningCashBalance(string endOfDay);
        decimal GetOpeningCreditBalance(string endOfDay);
        decimal GetCashBalance(string endOfDay);
        decimal GetCreditBalance(string endOfDay);
        decimal GetTotalCashPayment(string endOfDay);
        decimal GetTotalChequePayment(string endOfDay);
        decimal GetTotalBalance(string endOfDay, string action, string actionType);
    }
}
