﻿using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class UserTransactionService : IUserTransactionService
    {
        private readonly IUserTransactionRepository _posTransactionRepository;
        private readonly IFiscalYearDetailRepository _fiscalYearDetailRepository;

        public UserTransactionService(IUserTransactionRepository posTransactionRepository, IFiscalYearDetailRepository fiscalYearDetailRepository)
        {
            _posTransactionRepository = posTransactionRepository;
            _fiscalYearDetailRepository = fiscalYearDetailRepository;
        }

        public IEnumerable<UserTransaction> GetPosTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTransaction> GetPosTransactions(string memberId)
        {
            return _posTransactionRepository.GetPosTransactions(memberId);
        }

        public IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId)
        {
            return _posTransactionRepository.GetMemberTransactions(memberId);
        }

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(string supplierId)
        {
            return _posTransactionRepository.GetSupplierTransactions(supplierId);
        }

        public IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter filter)
        {
            return _posTransactionRepository.GetExpenseTransactions(filter);
        }

        public UserTransaction GetPosTransaction(long posTransactionId)
        {
            throw new NotImplementedException();
        }
        
        public UserTransaction GetPosTransaction(string invoiceNo)
        {
            return _posTransactionRepository.GetPosTransaction(invoiceNo);
        }

        public UserTransaction GetLastPosTransaction(string option)
        {
            return _posTransactionRepository.GetLastPosTransaction(option);
        }

        public UserTransaction AddPosTransaction(UserTransaction posTransaction)
        {
            return _posTransactionRepository.AddPosTransaction(posTransaction);
        }

        public UserTransaction UpdatePosTransaction(long posTransactionId, UserTransaction posTransaction)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSupplierInvoice(long posTransactionId)
        {
            throw new NotImplementedException();
        }

        public string GetInvoiceNo()
        {
            string invoiceNo;
            try
            {
                var lastInvoiceNo = _posTransactionRepository.GetLastInvoiceNo();
                if (string.IsNullOrWhiteSpace(lastInvoiceNo))
                {
                    var fiscalYearDetail = _fiscalYearDetailRepository.GetFiscalYearDetail();
                    invoiceNo = fiscalYearDetail.InvoiceNo;
                }
                else
                {
                    var formats = lastInvoiceNo.Split('-');
                    var prefix = formats[0];
                    var year = formats[1];
                    var value = formats[2];
                    var trimmedValue = (Convert.ToInt64(value.TrimStart(new char[] { '0' })) + 1).ToString();

                    while(trimmedValue.Length < value.Length)
                    {
                        trimmedValue = "0" + trimmedValue;
                    }

                    invoiceNo = prefix + "-" + year + "-" + trimmedValue;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return invoiceNo; 
        }
        
        public decimal GetMemberTotalBalance()
        {
            return _posTransactionRepository.GetMemberTotalBalance();
        }

        public decimal GetMemberTotalBalance(string memberId)
        {
            return _posTransactionRepository.GetMemberTotalBalance(memberId);
        }

        public decimal GetSupplierTotalBalance()
        {
            return _posTransactionRepository.GetSupplierTotalBalance();
        }

        public decimal GetSupplierTotalBalance(string supplierId)
        {
            return _posTransactionRepository.GetSupplierTotalBalance(supplierId);
        }

        public decimal GetCashInHand()
        {
            return _posTransactionRepository.GetCashInHand();
        }

        public decimal GetTotalBalance(string action, string actionType)
        {
            return _posTransactionRepository.GetTotalBalance(action, actionType);
        }

        public decimal GetTotalExpense(string expense)
        {
            return _posTransactionRepository.GetTotalExpense(expense);
        }
    }
}
