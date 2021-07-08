using GrocerySupplyManagementApp.DTOs;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IDailyTransactionService
    {
        IEnumerable<TransactionView> GetTransactionGrids(TransactionFilter transactionFilter);
        decimal GetSumTransactionGrids(TransactionFilter transactionFilter);
        IEnumerable<string> GetMemberIds();
        IEnumerable<string> GetSalesItems();
        IEnumerable<string> GetInvoices();
        bool DeleteTransactionGrids(long id);
    }
}
