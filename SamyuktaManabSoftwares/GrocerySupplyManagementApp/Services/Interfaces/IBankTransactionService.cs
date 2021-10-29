using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IBankTransactionService
    {
        IEnumerable<BankTransaction> GetBankTransactions(long bankId);
        IEnumerable<BankTransactionView> GetBankTransactionViews(long bankId);
        IEnumerable<BankTransactionView> GetBankTransactionViews(BankTransactionFilter bankTransactionFilter);
        decimal GetTotalBalance(BankTransactionFilter bankTransactionFilter);
        decimal GetTotalDeposit(BankTransactionFilter bankTransactionFilter);

        BankTransaction AddBankTransaction(BankTransaction bankTransaction);

        bool DeleteBankTransaction(long id);
        bool DeleteBankTransactionByTransactionId(long transactionId);
    }
}
