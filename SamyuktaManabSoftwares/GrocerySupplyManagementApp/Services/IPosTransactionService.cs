using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IPosTransactionService
    {
        IEnumerable<PosTransaction> GetPosTransactions();
        IEnumerable<PosTransaction> GetPosTransactions(string memberId);
        IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId);
        IEnumerable<SupplierTransactionView> GetSupplierTransactions(string supplierId);
        IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter filter);
        PosTransaction GetPosTransaction(long posTransactionId);
        PosTransaction GetPosTransaction(string invoiceNo);
        PosTransaction AddPosTransaction(PosTransaction posTransaction);
        PosTransaction UpdatePosTransaction(long posTransactionId, PosTransaction posTransaction);
        bool DeleteSupplierInvoice(long posTransactionId);
        string GetInvoiceNo();
        decimal GetMemberTotalBalance(string memberId);
        decimal GetSupplierTotalBalance(string supplierId);
        decimal GetCashInHand();
    }
}
