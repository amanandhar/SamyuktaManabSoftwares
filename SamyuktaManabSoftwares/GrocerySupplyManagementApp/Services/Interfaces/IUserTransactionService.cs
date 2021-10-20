using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IUserTransactionService
    {
        IEnumerable<UserTransaction> GetUserTransactions(UserTransactionFilter userTransactionFilter);
        IEnumerable<UserTransaction> GetDeliveryPersonTransactions(DeliveryPersonTransactionFilter deliveryPersonTransactionFilter);
        IEnumerable<MemberTransactionView> GetMemberTransactions(MemberTransactionFilter memberTransactionFilter);
        IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierFilter);
        UserTransaction GetLastUserTransaction(string addedBy, string option);
        string GetInvoiceNo();
        IEnumerable<string> GetInvoices();
        IEnumerable<DailyTransactionView> GetDailyTransactions(DailyTransactionFilter dailyTransactionFilter);
        IEnumerable<ShareMemberTransactionView> GetShareMemberTransactions(ShareMemberTransactionFilter shareMemberTransactionFilter);
        IEnumerable<SalesReturnTransactionView> GetSalesReturnTransactions(SalesReturnTransactionFilter salesReturnTransactionFilter);

        UserTransaction AddUserTransaction(UserTransaction userTransaction);

        bool DeleteUserTransaction(long id);
        bool DeleteUserTransaction(string invoiceNo);
    }
}
