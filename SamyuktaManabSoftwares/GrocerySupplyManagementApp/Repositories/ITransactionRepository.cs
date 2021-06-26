using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<TransactionGrid> GetTransactionGrids(TransactionFilter transactionFilter);
        decimal GetSumTransactionGrids(TransactionFilter transactionFilter);
        IEnumerable<string> GetMemberIds();
        IEnumerable<string> GetSalesItems();
        IEnumerable<string> GetInvoices();
        bool DeleteTransactionGrids(string invoiceNo);
    }
}
