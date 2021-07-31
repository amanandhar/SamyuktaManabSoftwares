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

        public IEnumerable<BankTransaction> GetBankTransactions()
        {
            return _bankTransactionRepository.GetBankTransactions();
        }

        public BankTransaction GetBankTransaction(long id)
        {
            return _bankTransactionRepository.GetBankTransaction(id);
        }

        public IEnumerable<BankTransaction> GetBankTransactions(long bankId)
        {
            return _bankTransactionRepository.GetBankTransactions(bankId);
        }

        public IEnumerable<BankTransactionView> GetBankTransactionViews(long bankId)
        {
            return _bankTransactionRepository.GetBankTransactionViews(bankId);
        }

        public decimal GetTotalBalance()
        {
            return _bankTransactionRepository.GetTotalBalance();
        }

        public decimal GetTotalBalance(long bankId)
        {
            return _bankTransactionRepository.GetTotalBalance(bankId);
        }

        public decimal GetTotalDeposit(string incomeType)
        {
            return _bankTransactionRepository.GetTotalDeposit(incomeType);
        }

        public BankTransaction AddBankTransaction(BankTransaction bankTransaction)
        {
            return _bankTransactionRepository.AddBankTransaction(bankTransaction);
        }

        public BankTransaction UpdateBankTransaction(long id, BankTransaction bankTransaction)
        {
            return _bankTransactionRepository.UpdateBankTransaction(id, bankTransaction);
        }

        public bool DeleteBankTransaction(long id)
        {
            return _bankTransactionRepository.DeleteBankTransaction(id);
        }

        public bool DeleteBankTransactionByUserTransaction(long userTransactionId)
        {
            return _bankTransactionRepository.DeleteBankTransactionByUserTransaction(userTransactionId);
        }

        public bool DeleteBankTransactionAfterEndOfDay(string endOfDay)
        {
            return _bankTransactionRepository.DeleteBankTransactionAfterEndOfDay(endOfDay);
        }
    }
}
