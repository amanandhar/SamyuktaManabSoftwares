using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Shared.Enums;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IUserTransactionRepository
    {
        IEnumerable<UserTransaction> GetUserTransactions(UserTransactionFilter userTransactionFilter);
        IEnumerable<MemberTransactionView> GetMemberTransactions(MemberTransactionFilter memberTransactionFilter);
        IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierTransactionFilter);
        UserTransaction GetLastUserTransaction(PartyNumberType transactionNumberType, string addedBy);
        IEnumerable<DailyTransactionView> GetDailyTransactions(DailyTransactionFilter dailyTransactionFilter);
        IEnumerable<SalesReturnTransactionView> GetSalesReturnTransactions(SalesReturnTransactionFilter salesReturnTransactionFilter);
        decimal GetTotalMemberSaleAmount(string shareMemberId);

        UserTransaction AddUserTransaction(UserTransaction userTransaction);

        bool DeleteUserTransaction(long id);
        bool DeleteUserTransaction(string invoiceNo);

        #region Daily Transaction Methods
        bool DeleteBill(long id, string billNo);
        bool DeleteInvoice(string invoiceNo);
        #endregion

        #region POS Methods
        bool SaveSalesDetail(List<SoldItem> soldItems, UserTransaction userTransaction, POSDetail posDetail, string username);
        #endregion
    }
}
