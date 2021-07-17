using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IBankTransactionService
    {
        IEnumerable<BankTransaction> GetBankTransactions();
        BankTransaction GetBankTransaction(long id);
        BankTransaction AddBankTransaction(BankTransaction bankTransaction);
        BankTransaction UpdateBankTransaction(long id, BankTransaction bankTransaction);
        bool DeleteBankTransaction(long id);
        IEnumerable<BankTransaction> GetBankTransactions(long bankId);
        IEnumerable<BankTransactionView> GetBankTransactionViews(long bankId);
        decimal GetTotalBalance();
        decimal GetTotalBalance(long bankId);
        decimal GetTotalDeposit(string incomeType);
        bool DeleteBankTransactionByUserTransaction(long userTransactionId);
    }
}
