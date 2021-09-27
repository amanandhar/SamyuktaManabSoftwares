using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IUserTransactionService
    {
        IEnumerable<UserTransaction> GetUserTransactions();
        IEnumerable<UserTransaction> GetUserTransactions(string memberId);
        IEnumerable<UserTransaction> GetUserTransactions(DeliveryPersonFilter filter);
        IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId);
        IEnumerable<MemberTransactionView> GetMemberTransactions(MemberFilter memberFilter);
        IEnumerable<SupplierTransactionView> GetSupplierTransactions(string supplierId);
        IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierFilter);
        IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter expenseTransactionFilter);
        UserTransaction GetUserTransaction(long userTransactionId);
        UserTransaction GetUserTransaction(string invoiceNo);
        UserTransaction GetLastUserTransaction(string option);
        string GetInvoiceNo();
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
        IEnumerable<SalesReturnTransactionView> GetSalesReturnTransactions(SalesReturnTransactionFilter salesReturnTransactionFilter);

        UserTransaction AddUserTransaction(UserTransaction userTransaction);

        UserTransaction UpdateUserTransaction(long userTransactionId, UserTransaction userTransaction);

        bool DeleteUserTransaction(long id);
        bool DeleteUserTransaction(string invoiceNo);
        bool DeleteSupplierInvoice(long userTransactionId);
        bool DeleteUserTransactionAfterEndOfDay(string endOfDay);
    }
}
