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
        IEnumerable<UserTransaction> GetUserTransactions(DeliveryPersonFilter filter);
        IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId);
        IEnumerable<SupplierTransactionView> GetSupplierTransactions(string supplierId);
        IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter filter);
        UserTransaction GetUserTransaction(long userTransactionId);
        UserTransaction GetUserTransaction(string invoiceNo);
        UserTransaction GetLastUserTransaction(string option);
        string GetLastInvoiceNo();
        decimal GetMemberTotalBalance();
        decimal GetMemberTotalBalance(string memberId);
        decimal GetSupplierTotalBalance();
        decimal GetSupplierTotalBalance(string supplierId);
        decimal GetCashInHand();
        decimal GetTotalBalance(string endOfDay, string action, string actionType);
        decimal GetPreviousTotalBalance(string endOfDay, string action, string actionType);
        decimal GetTotalExpense(string expense);
        IEnumerable<string> GetInvoices();
        IEnumerable<string> GetMemberIds();
        decimal GetUserTransactionBalance(TransactionFilter transactionFilter);
        IEnumerable<TransactionView> GetTransactionViewList(TransactionFilter transactionFilter);
        IEnumerable<IncomeDetailView> GetDeliveryCharge();
        IEnumerable<IncomeDetailView> GetMemberFee();
        IEnumerable<IncomeDetailView> GetOtherIncome();
        IEnumerable<IncomeDetailView> GetSalesProfit();

        UserTransaction AddUserTransaction(UserTransaction userTransaction);

        UserTransaction UpdateUserTransaction(long userTransactionId, UserTransaction userTransaction);

        bool DeleteUserTransaction(long id);
        bool DeleteUserTransaction(string invoiceNo);
        bool DeleteUserTransactionAfterEndOfDay(string endOfDay);
    }
}
