using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IDailyTransactionRepository
    {
        IEnumerable<TransactionView> GetTransactionViewList(TransactionFilter transactionFilter);
        decimal GetUserTransactionBalance(TransactionFilter transactionFilter);
        IEnumerable<string> GetMemberIds();
        IEnumerable<string> GetSalesItems();
        IEnumerable<string> GetInvoices();
        bool DeleteUserTransaction(long id);
    }
}
