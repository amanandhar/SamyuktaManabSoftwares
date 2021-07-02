using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IPosTransactionRepository
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
        bool DeletePosTransaction(long posTransactionId, PosTransaction posTransaction);
        string GetLastInvoiceNo();
        decimal GetMemberTotalBalance(string memberId);
        decimal GetSupplierTotalBalance(string supplierId);
        decimal GetCashInHand();
    }
}
