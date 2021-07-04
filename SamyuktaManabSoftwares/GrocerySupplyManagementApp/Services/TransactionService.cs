using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<TransactionGrid> GetTransactionGrids(TransactionFilter transactionFilter)
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
