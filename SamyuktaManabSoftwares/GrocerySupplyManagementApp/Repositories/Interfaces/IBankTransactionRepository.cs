using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IBankTransactionRepository
    {
        IEnumerable<BankTransaction> GetBankTransactions(long bankId);
        IEnumerable<BankTransactionView> GetBankTransactionViews(long bankId);
        IEnumerable<BankTransactionView> GetBankTransactionViews(BankTransactionFilter bankTransactionFilter);
        decimal GetTotalBalance(BankTransactionFilter bankTransactionFilter);

        BankTransaction AddBankTransaction(BankTransaction bankTransaction);

        bool DeleteBankTransaction(long id);
        bool DeleteBankTransactionByTransactionId(long transactionId);
        bool DeleteShareMemberTransaction(long id);
    }
}
