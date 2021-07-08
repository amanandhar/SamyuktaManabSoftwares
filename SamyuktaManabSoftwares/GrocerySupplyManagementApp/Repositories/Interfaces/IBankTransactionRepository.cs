using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IBankTransactionRepository
    {
        IEnumerable<BankTransaction> GetBankTransactions();
        IEnumerable<BankTransaction> GetBankTransactions(long bankId);
        IEnumerable<BankTransactionView> GetBankTransactionViews(long bankId);
        BankTransaction GetBankTransaction(long bankTransactionId);
        decimal GetBankBalance(long bankId);
        BankTransaction AddBankTransaction(BankTransaction bankTransaction);
        BankTransaction UpdateBankTransaction(long bankTransactionId, BankTransaction bankTransaction);
        bool DeleteBankTransaction(long id);
        bool DeleteBankTransactionByTransactionId(long transactionId);
    }
}
