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

        public IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId)
        {
            return _userTransactionRepository.GetMemberTransactions(memberId);
        }

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(string supplierId)
        {
            return _userTransactionRepository.GetSupplierTransactions(supplierId);
        }

        public IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter filter)
        {
            return _userTransactionRepository.GetExpenseTransactions(filter);
        }

        public UserTransaction GetUserTransaction(long userTransactionId)
        {
            throw new NotImplementedException();
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

        public decimal GetMemberTotalBalance()
        {
            return _userTransactionRepository.GetMemberTotalBalance();
        }

        public decimal GetMemberTotalBalance(string memberId)
        {
            return _userTransactionRepository.GetMemberTotalBalance(memberId);
        }

        public decimal GetSupplierTotalBalance()
        {
            return _userTransactionRepository.GetSupplierTotalBalance();
        }

        public decimal GetSupplierTotalBalance(string supplierId)
        {
            return _userTransactionRepository.GetSupplierTotalBalance(supplierId);
        }

        public decimal GetCashInHand()
        {
            return _userTransactionRepository.GetCashInHand();
        }

        public decimal GetTotalBalance(string action, string actionType)
        {
            return _userTransactionRepository.GetTotalBalance(action, actionType);
        }

        public decimal GetTotalExpense(string expense)
        {
            return _userTransactionRepository.GetTotalExpense(expense);
        }

        public IEnumerable<string> GetInvoices()
        {
            return _userTransactionRepository.GetInvoices();
        }

        public IEnumerable<string> GetMemberIds()
        {
            return _userTransactionRepository.GetMemberIds();
        }

        public decimal GetUserTransactionBalance(TransactionFilter transactionFilter)
        {
            return _userTransactionRepository.GetUserTransactionBalance(transactionFilter);
        }

        public IEnumerable<TransactionView> GetTransactionViewList(TransactionFilter transactionFilter)
        {
            return _userTransactionRepository.GetTransactionViewList(transactionFilter);
        }

        public IEnumerable<IncomeDetailView> GetDeliveryCharge()
        {
            return _userTransactionRepository.GetDeliveryCharge();
        }

        public IEnumerable<IncomeDetailView> GetMemberFee()
        {
            return _userTransactionRepository.GetMemberFee();
        }

        public IEnumerable<IncomeDetailView> GetOtherIncome()
        {
            return _userTransactionRepository.GetOtherIncome();
        }

        public IEnumerable<IncomeDetailView> GetSalesProfit()
        {
            return _userTransactionRepository.GetSalesProfit();
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

        public bool DeleteSupplierInvoice(long userTransactionId)
        {
            throw new NotImplementedException();
        }
    }
}
