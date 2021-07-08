using GrocerySupplyManagementApp.DTOs;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IDailyTransactionRepository
    {
        IEnumerable<TransactionView> GetTransactionGrids(TransactionFilter transactionFilter);
        decimal GetSumTransactionGrids(TransactionFilter transactionFilter);
        IEnumerable<string> GetMemberIds();
        IEnumerable<string> GetSalesItems();
        IEnumerable<string> GetInvoices();
        bool DeleteTransactionGrids(long id);
    }
}
