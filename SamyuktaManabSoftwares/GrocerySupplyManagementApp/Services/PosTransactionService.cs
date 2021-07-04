using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
using System;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class PosTransactionService : IPosTransactionService
    {
        private readonly IPosTransactionRepository _posTransactionRepository;
        private readonly IFiscalYearDetailRepository _fiscalYearDetailRepository;

        public PosTransactionService(IPosTransactionRepository posTransactionRepository, IFiscalYearDetailRepository fiscalYearDetailRepository)
        {
            _posTransactionRepository = posTransactionRepository;
            _fiscalYearDetailRepository = fiscalYearDetailRepository;
        }

        public IEnumerable<PosTransaction> GetPosTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PosTransaction> GetPosTransactions(string memberId)
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

        public PosTransaction GetPosTransaction(long posTransactionId)
        {
            throw new NotImplementedException();
        }
        
        public PosTransaction GetPosTransaction(string invoiceNo)
        {
            return _posTransactionRepository.GetPosTransaction(invoiceNo);
        }

        public PosTransaction GetLastPosTransaction(string option)
        {
            return _posTransactionRepository.GetLastPosTransaction(option);
        }

        public PosTransaction AddPosTransaction(PosTransaction posTransaction)
        {
            return _posTransactionRepository.AddPosTransaction(posTransaction);
        }

        public PosTransaction UpdatePosTransaction(long posTransactionId, PosTransaction posTransaction)
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
        
        public decimal GetMemberTotalBalance(string memberId)
        {
            return _posTransactionRepository.GetMemberTotalBalance(memberId);
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
    }
}
