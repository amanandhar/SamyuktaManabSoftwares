using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class DailyTransactionService : IDailyTransactionService
    {
        private readonly IDailyTransactionRepository _transactionRepository;

        public DailyTransactionService(IDailyTransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<TransactionView> GetTransactionViewList(TransactionFilter transactionFilter)
        {
            return _transactionRepository.GetTransactionViewList(transactionFilter);
        }

        public decimal GetUserTransactionBalance(TransactionFilter transactionFilter)
        {
            return _transactionRepository.GetUserTransactionBalance(transactionFilter);
        }

        public IEnumerable<string> GetMemberIds()
        {
            return _transactionRepository.GetMemberIds();
        }

        public IEnumerable<string> GetSalesItems()
        {
            return _transactionRepository.GetSalesItems();
        }

        public IEnumerable<string> GetInvoices()
        {
            return _transactionRepository.GetInvoices();
        }

        public bool DeleteUserTransaction(long id)
        {
            return _transactionRepository.DeleteUserTransaction(id);
        }
    }
}
