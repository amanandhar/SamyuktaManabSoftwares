using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IUserTransactionRepository
    {
        IEnumerable<UserTransaction> GetUserTransactions();
        IEnumerable<UserTransaction> GetUserTransactions(string memberId);
        IEnumerable<UserTransaction> GetUserTransactions(DeliveryPersonFilter deliveryPersonFilter);
        IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId);
        IEnumerable<MemberTransactionView> GetMemberTransactions(MemberFilter memberFilter);
        IEnumerable<SupplierTransactionView> GetSupplierTransactions(string supplierId);
        IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierFilter);
        IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter expenseTransactionFilter);
        UserTransaction GetUserTransaction(long userTransactionId);
        UserTransaction GetUserTransaction(string invoiceNo);
        UserTransaction GetLastUserTransaction(string option);
        string GetLastInvoiceNo();
        decimal GetMemberTotalBalance(UserTransactionFilter userTransactionFilter);
        decimal GetSupplierTotalBalance(SupplierTransactionFilter supplierTransactionFilter);
        decimal GetCashInHand(UserTransactionFilter userTransactionFilter);
        decimal GetTotalBalance(string endOfDay, string action, string actionType);
        decimal GetPreviousTotalBalance(string endOfDay, string action, string actionType);
        decimal GetTotalExpense(ExpenseTransactionFilter expenseTransactionFilter);
        IEnumerable<string> GetInvoices();
        IEnumerable<string> GetMemberIds();
        decimal GetUserTransactionBalance(DailyTransactionFilter dailyTransactionFilter);
        IEnumerable<TransactionView> GetTransactionViewList(DailyTransactionFilter dailyTransactionFilter);
        IEnumerable<IncomeDetailView> GetIncome(IncomeTransactionFilter incomeTransactionFilter);
        IEnumerable<IncomeDetailView> GetSalesProfit(IncomeTransactionFilter incomeTransactionFilter);
        IEnumerable<IncomeDetailView> GetPurchaseBonus(IncomeTransactionFilter incomeTransactionFilter);
        IEnumerable<ShareMemberTransactionView> GetShareMemberTransactions(long shareMemberId);

        UserTransaction AddUserTransaction(UserTransaction userTransaction);

        UserTransaction UpdateUserTransaction(long userTransactionId, UserTransaction userTransaction);

        bool DeleteUserTransaction(long id);
        bool DeleteUserTransaction(string invoiceNo);
        bool DeleteUserTransactionAfterEndOfDay(string endOfDay);
    }
}
