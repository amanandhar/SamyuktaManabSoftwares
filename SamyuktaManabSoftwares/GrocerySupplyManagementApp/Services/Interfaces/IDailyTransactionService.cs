using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IDailyTransactionService
    {
        IEnumerable<TransactionView> GetTransactionViewList(TransactionFilter transactionFilter);
        decimal GetUserTransactionBalance(TransactionFilter transactionFilter);
        IEnumerable<string> GetMemberIds();
        IEnumerable<string> GetSalesItems();
        IEnumerable<string> GetInvoices();
        bool DeleteUserTransaction(long id);
    }
}
