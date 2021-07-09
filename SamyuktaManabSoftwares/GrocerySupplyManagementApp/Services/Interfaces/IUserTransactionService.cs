using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IUserTransactionService
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
        bool DeleteSupplierInvoice(long posTransactionId);
        string GetInvoiceNo();
        decimal GetMemberTotalBalance(string memberId);
        decimal GetSupplierTotalBalance(string supplierId);
        decimal GetCashInHand();
        decimal GetTotalBalance(string action, string actionType);
        decimal GetTotalExpense(string expense);
    }
}
