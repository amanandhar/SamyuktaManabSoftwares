using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface ITransactionService
    {
        IEnumerable<TransactionGrid> GetTransactionGrids(TransactionFilter transactionFilter);
        decimal GetSumTransactionGrids(TransactionFilter transactionFilter);
        IEnumerable<string> GetMemberIds();
        IEnumerable<string> GetSalesItems();
        IEnumerable<string> GetInvoices();
        bool DeleteTransactionGrids(long id);
    }
}
