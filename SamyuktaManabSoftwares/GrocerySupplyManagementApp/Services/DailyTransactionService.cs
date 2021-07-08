using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
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

        public IEnumerable<TransactionView> GetTransactionGrids(TransactionFilter transactionFilter)
        {
            return _transactionRepository.GetTransactionGrids(transactionFilter);
        }

        public decimal GetSumTransactionGrids(TransactionFilter transactionFilter)
        {
            return _transactionRepository.GetSumTransactionGrids(transactionFilter);
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

        public bool DeleteTransactionGrids(long id)
        {
            return _transactionRepository.DeleteTransactionGrids(id);
        }
    }
}
