﻿using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IUserTransactionRepository
    {
        IEnumerable<UserTransaction> GetUserTransactions(UserTransactionFilter userTransactionFilter);
        IEnumerable<UserTransaction> GetDeliveryPersonTransactions(DeliveryPersonTransactionFilter deliveryPersonTransactionFilter);
        IEnumerable<MemberTransactionView> GetMemberTransactions(MemberTransactionFilter memberTransactionFilter);
        IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierFilter);
        UserTransaction GetUserTransaction(long userTransactionId);
        UserTransaction GetUserTransaction(string invoiceNo);
        UserTransaction GetLastUserTransaction(string option);
        string GetLastInvoiceNo();
        IEnumerable<string> GetInvoices();
        IEnumerable<string> GetMemberIds();
        IEnumerable<TransactionView> GetTransactionViewList(DailyTransactionFilter dailyTransactionFilter);
        IEnumerable<ShareMemberTransactionView> GetShareMemberTransactions(long shareMemberId);
        IEnumerable<SalesReturnTransactionView> GetSalesReturnTransactions(SalesReturnTransactionFilter salesReturnTransactionFilter);

        UserTransaction AddUserTransaction(UserTransaction userTransaction);

        UserTransaction UpdateUserTransaction(long userTransactionId, UserTransaction userTransaction);

        bool DeleteUserTransaction(long id);
        bool DeleteUserTransaction(string invoiceNo);
        bool DeleteUserTransactionAfterEndOfDay(string endOfDay);
    }
}
