using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.Shared.Enums;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySupplyManagementApp.Services
{
    public class UserTransactionService : IUserTransactionService
    {
        private readonly IUserTransactionRepository _userTransactionRepository;

        public UserTransactionService(IUserTransactionRepository userTransactionRepository)
        {
            _userTransactionRepository = userTransactionRepository;
        }

        public IEnumerable<UserTransaction> GetUserTransactions(UserTransactionFilter userTransactionFilter)
        {
            return _userTransactionRepository.GetUserTransactions(userTransactionFilter);
        }

        public IEnumerable<MemberTransactionView> GetMemberTransactions(MemberTransactionFilter memberTransactionFilter)
        {
            return _userTransactionRepository.GetMemberTransactions(memberTransactionFilter);
        }

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierTransactionFilter)
        {
            return _userTransactionRepository.GetSupplierTransactions(supplierTransactionFilter);
        }

        public UserTransaction GetLastUserTransaction(PartyNumberType transactionNumberType, string addedBy)
        {
            return _userTransactionRepository.GetLastUserTransaction(transactionNumberType, addedBy);
        }

        public IEnumerable<DailyTransactionView> GetDailyTransactions(DailyTransactionFilter dailyTransactionFilter)
        {
            return _userTransactionRepository.GetDailyTransactions(dailyTransactionFilter);
        }

        public IEnumerable<SalesReturnTransactionView> GetSalesReturnTransactions(SalesReturnTransactionFilter salesReturnTransactionFilter)
        {
            return _userTransactionRepository.GetSalesReturnTransactions(salesReturnTransactionFilter);
        }

        public UserTransaction AddUserTransaction(UserTransaction userTransaction)
        {
            return _userTransactionRepository.AddUserTransaction(userTransaction);
        }

        public bool DeleteUserTransaction(long id)
        {
            return _userTransactionRepository.DeleteUserTransaction(id);
        }

        public bool DeleteUserTransaction(string invoiceNo)
        {
            return _userTransactionRepository.DeleteUserTransaction(invoiceNo);
        }

        #region Daily Transaction Methods
        public bool DeleteBill(long id, string billNo)
        {
            return _userTransactionRepository.DeleteBill(id, billNo);
        }

        public bool DeleteInvoice(string invoiceNo)
        {
            return _userTransactionRepository.DeleteInvoice(invoiceNo);
        }

        #endregion

        #region POS Methods
        public bool SaveSalesDetail(List<SoldItem> soldItems, UserTransaction userTransaction, POSDetail posDetail, string username)
        {
            return _userTransactionRepository.SaveSalesDetail(soldItems, userTransaction, posDetail, username);
        }
        #endregion
    }
}
