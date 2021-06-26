using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
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

        public IEnumerable<BankTransaction> GetBankTransactions()
        {
            return _bankTransactionRepository.GetBankTransactions();
        }

        public IEnumerable<BankTransaction> GetBankTransactions(long bankId)
        {
            return _bankTransactionRepository.GetBankTransactions(bankId);
        }

        public IEnumerable<BankTransactionView> GetBankTransactionViews(long bankId)
        {
            return _bankTransactionRepository.GetBankTransactionViews(bankId);
        }

        public BankTransaction GetBankTransaction(long bankId)
        {
            return _bankTransactionRepository.GetBankTransaction(bankId);
        }

        public decimal GetBankBalance(long bankId)
        {
            return _bankTransactionRepository.GetBankBalance(bankId);
        }

        public BankTransaction AddBankTransaction(BankTransaction bankTransaction)
        {
            return _bankTransactionRepository.AddBankTransaction(bankTransaction);
        }

        public BankTransaction UpdateBankTransaction(long bankId, BankTransaction bankTransaction)
        {
            return _bankTransactionRepository.UpdateBankTransaction(bankId, bankTransaction);
        }

        public bool DeleteBankTransaction(long bankId)
        {
            return _bankTransactionRepository.DeleteBankTransaction(bankId);
        }
    }
}
