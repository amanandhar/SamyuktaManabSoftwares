using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IBankTransactionRepository
    {
        IEnumerable<BankTransaction> GetBankTransactions();
        BankTransaction GetBankTransaction(long id);
        IEnumerable<BankTransaction> GetBankTransactions(long bankId);
        IEnumerable<BankTransactionView> GetBankTransactionViews(long bankId);
        decimal GetTotalBalance();
        decimal GetTotalBalance(long bankId);
        decimal GetTotalDeposit(string incomeType);

        BankTransaction AddBankTransaction(BankTransaction bankTransaction);

        BankTransaction UpdateBankTransaction(long id, BankTransaction bankTransaction);

        bool DeleteBankTransaction(long id);
        bool DeleteBankTransactionByUserTransaction(long userTransactionId);
        bool DeleteBankTransactionAfterEndOfDay(string endOfDay);
    }
}
