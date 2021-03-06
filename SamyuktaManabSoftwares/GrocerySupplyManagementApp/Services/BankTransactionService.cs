using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class BankTransactionService : IBankTransactionService
    {
        private readonly IBankTransactionRepository _bankTransactionRepository;

        public BankTransactionService(IBankTransactionRepository bankTransactionRepository)
        {
            _bankTransactionRepository = bankTransactionRepository;
        }

        public IEnumerable<BankTransaction> GetBankTransactions(long bankId)
        {
            return _bankTransactionRepository.GetBankTransactions(bankId);
        }

        public IEnumerable<BankTransactionView> GetBankTransactionViews(long bankId)
        {
            return _bankTransactionRepository.GetBankTransactionViews(bankId);
        }

        public IEnumerable<BankTransactionView> GetBankTransactionViews(BankTransactionFilter bankTransactionFilter)
        {
            return _bankTransactionRepository.GetBankTransactionViews(bankTransactionFilter);
        }

        public decimal GetTotalBalance(BankTransactionFilter bankTransactionFilter)
        {
            return _bankTransactionRepository.GetTotalBalance(bankTransactionFilter);
        }

        public BankTransaction AddBankTransaction(BankTransaction bankTransaction)
        {
            return _bankTransactionRepository.AddBankTransaction(bankTransaction);
        }

        public bool DeleteBankTransaction(long id)
        {
            return _bankTransactionRepository.DeleteBankTransaction(id);
        }

        public bool DeleteBankTransactionByTransactionId(long transactionId)
        {
            return _bankTransactionRepository.DeleteBankTransactionByTransactionId(transactionId);
        }

        public bool DeleteShareMemberTransaction(long id)
        {
            return _bankTransactionRepository.DeleteShareMemberTransaction(id);
        }
    }
}
