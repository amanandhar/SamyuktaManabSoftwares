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
        IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId);
        IEnumerable<SupplierTransactionView> GetSupplierTransactions(string supplierId);
        IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter filter);
        UserTransaction GetUserTransaction(long userTransactionId);
        UserTransaction GetUserTransaction(string invoiceNo);
        UserTransaction GetLastUserTransaction(string option);
        UserTransaction AddUserTransaction(UserTransaction userTransaction);
        UserTransaction UpdateUserTransaction(long userTransactionId, UserTransaction userTransaction);
        bool DeleteUserTransaction(long id);
        string GetLastInvoiceNo();
        decimal GetMemberTotalBalance();
        decimal GetMemberTotalBalance(string memberId);
        decimal GetSupplierTotalBalance();
        decimal GetSupplierTotalBalance(string supplierId);
        decimal GetCashInHand();
        decimal GetTotalBalance(string action, string actionType);
        decimal GetTotalExpense(string expense);
    }
}
