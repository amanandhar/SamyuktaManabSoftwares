using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IBankTransactionService
    {
        IEnumerable<BankTransaction> GetBankTransactions();
        IEnumerable<BankTransaction> GetBankTransactions(long bankId);
        IEnumerable<BankTransactionView> GetBankTransactionViews(long bankId);
        BankTransaction GetBankTransaction(long id);
        decimal GetBankBalance(long bankId);
        BankTransaction AddBankTransaction(BankTransaction bankTransaction);
        BankTransaction UpdateBankTransaction(long id, BankTransaction bankTransaction);
        bool DeleteBankTransaction(long id);
        bool DeleteBankTransactionByTransactionId(long transactionId);
    }
}
