using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class UserTransactionService : IUserTransactionService
    {
        private readonly IUserTransactionRepository _userTransactionRepository;
        private readonly IFiscalYearRepository _fiscalYearRepository;

        public UserTransactionService(IUserTransactionRepository userTransactionRepository, IFiscalYearRepository fiscalYearRepository)
        {
            _userTransactionRepository = userTransactionRepository;
            _fiscalYearRepository = fiscalYearRepository;
        }

        public IEnumerable<UserTransaction> GetUserTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTransaction> GetUserTransactions(string memberId)
        {
            return _userTransactionRepository.GetUserTransactions(memberId);
        }

        public IEnumerable<UserTransaction> GetUserTransactions(DeliveryPersonFilter deliveryPersonFilter)
        {
            return _userTransactionRepository.GetUserTransactions(deliveryPersonFilter);
        }

        public IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId)
        {
            return _userTransactionRepository.GetMemberTransactions(memberId);
        }

        public IEnumerable<MemberTransactionView> GetMemberTransactions(MemberFilter memberFilter)
        {
            return _userTransactionRepository.GetMemberTransactions(memberFilter);
        }

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(string supplierId)
        {
            return _userTransactionRepository.GetSupplierTransactions(supplierId);
        }

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierFilter)
        {
            return _userTransactionRepository.GetSupplierTransactions(supplierFilter);
        }

        public IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter expenseTransactionFilter)
        {
            return _userTransactionRepository.GetExpenseTransactions(expenseTransactionFilter);
        }

        public UserTransaction GetUserTransaction(long userTransactionId)
        {
            return _userTransactionRepository.GetUserTransaction(userTransactionId);
        }
        
        public UserTransaction GetUserTransaction(string invoiceNo)
        {
            return _userTransactionRepository.GetUserTransaction(invoiceNo);
        }

        public UserTransaction GetLastUserTransaction(string option)
        {
            return _userTransactionRepository.GetLastUserTransaction(option);
        }

        public string GetInvoiceNo()
        {
            string invoiceNo;
            try
            {
                var lastInvoiceNo = _userTransactionRepository.GetLastInvoiceNo();
                if (string.IsNullOrWhiteSpace(lastInvoiceNo))
                {
                    var fiscalYear = _fiscalYearRepository.GetFiscalYear();
                    invoiceNo = fiscalYear.StartingInvoiceNo;
                }
                else
                {
                    var formats = lastInvoiceNo.Split('-');
                    var prefix = formats[0];
                    var year = formats[1];
                    var value = formats[2];
                    var trimmedValue = (Convert.ToInt64(value.TrimStart(new char[] { '0' })) + 1).ToString();

                    while (trimmedValue.Length < value.Length)
                    {
                        trimmedValue = "0" + trimmedValue;
                    }

                    invoiceNo = prefix + "-" + year + "-" + trimmedValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return invoiceNo;
        }

        public decimal GetMemberTotalBalance(UserTransactionFilter userTransactionFilter)
        {
            return _userTransactionRepository.GetMemberTotalBalance(userTransactionFilter);
        }

        public decimal GetSupplierTotalBalance(SupplierTransactionFilter supplierTransactionFilter)
        {
            return _userTransactionRepository.GetSupplierTotalBalance(supplierTransactionFilter);
        }

        public decimal GetCashInHand(UserTransactionFilter userTransactionFilter)
        {
            return _userTransactionRepository.GetCashInHand(userTransactionFilter);
        }

        public decimal GetTotalBalance(string endOfDay, string action, string actionType)
        {
            return _userTransactionRepository.GetTotalBalance(endOfDay, action, actionType);
        }

        public decimal GetPreviousTotalBalance(string endOfDay, string action, string actionType)
        {
            return _userTransactionRepository.GetPreviousTotalBalance(endOfDay, action, actionType);
        }

        public decimal GetTotalExpense(ExpenseTransactionFilter expenseTransactionFilter)
        {
            return _userTransactionRepository.GetTotalExpense(expenseTransactionFilter);
        }

        public IEnumerable<string> GetInvoices()
        {
            return _userTransactionRepository.GetInvoices();
        }

        public IEnumerable<string> GetMemberIds()
        {
            return _userTransactionRepository.GetMemberIds();
        }

        public decimal GetUserTransactionBalance(DailyTransactionFilter dailyTransactionFilter)
        {
            return _userTransactionRepository.GetUserTransactionBalance(dailyTransactionFilter);
        }

        public IEnumerable<TransactionView> GetTransactionViewList(DailyTransactionFilter dailyTransactionFilter)
        {
            return _userTransactionRepository.GetTransactionViewList(dailyTransactionFilter);
        }

        public IEnumerable<IncomeDetailView> GetIncome(IncomeTransactionFilter filter)
        {
            return _userTransactionRepository.GetIncome(filter);
        }

        public IEnumerable<IncomeDetailView> GetSalesProfit(IncomeTransactionFilter filter)
        {
            return _userTransactionRepository.GetSalesProfit(filter);
        }

        public IEnumerable<IncomeDetailView> GetPurchaseBonus(IncomeTransactionFilter filter)
        {
            return _userTransactionRepository.GetPurchaseBonus(filter);
        }

        public IEnumerable<ShareMemberTransactionView> GetShareMemberTransactions(long shareMemberId)
        {
            return _userTransactionRepository.GetShareMemberTransactions(shareMemberId);
        }

        public UserTransaction AddUserTransaction(UserTransaction userTransaction)
        {
            return _userTransactionRepository.AddUserTransaction(userTransaction);
        }

        public UserTransaction UpdateUserTransaction(long userTransactionId, UserTransaction userTransaction)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserTransaction(long id)
        {
            return _userTransactionRepository.DeleteUserTransaction(id);
        }

        public bool DeleteUserTransaction(string invoiceNo)
        {
            return _userTransactionRepository.DeleteUserTransaction(invoiceNo);
        }

        public bool DeleteSupplierInvoice(long userTransactionId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserTransactionAfterEndOfDay(string endOfDay)
        {
            return _userTransactionRepository.DeleteUserTransactionAfterEndOfDay(endOfDay);
        }
    }
}
