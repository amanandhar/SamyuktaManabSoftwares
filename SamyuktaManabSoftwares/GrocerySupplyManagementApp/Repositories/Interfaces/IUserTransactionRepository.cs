using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IUserTransactionRepository
    {
        IEnumerable<UserTransaction> GetPosTransactions();
        IEnumerable<UserTransaction> GetPosTransactions(string memberId);
        IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId);
        IEnumerable<SupplierTransactionView> GetSupplierTransactions(string supplierId);
        IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter filter);
        UserTransaction GetPosTransaction(long posTransactionId);
        UserTransaction GetPosTransaction(string invoiceNo);
        UserTransaction GetLastPosTransaction(string option);
        UserTransaction AddPosTransaction(UserTransaction posTransaction);
        UserTransaction UpdatePosTransaction(long posTransactionId, UserTransaction posTransaction);
        bool DeletePosTransaction(long id);
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
