using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
using System;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class PosInvoiceService : IPosInvoiceService
    {
        private readonly IPosInvoiceRepository _posInvoiceRepository;
        private readonly IFiscalYearDetailRepository _fiscalYearDetailRepository;

        public PosInvoiceService(IPosInvoiceRepository posInvoiceRepository, IFiscalYearDetailRepository fiscalYearDetailRepository)
        {
            _posInvoiceRepository = posInvoiceRepository;
            _fiscalYearDetailRepository = fiscalYearDetailRepository;
        }

        public IEnumerable<PosInvoice> GetPosInvoices()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PosInvoice> GetPosInvoices(string memberId)
        {
            return _posInvoiceRepository.GetPosInvoices(memberId);
        }

        public IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId)
        {
            return _posInvoiceRepository.GetMemberTransactions(memberId);
        }

        public PosInvoice GetPosInvoice(long posInvoiceId)
        {
            throw new NotImplementedException();
        }
        
        public PosInvoice GetPosInvoice(string invoiceNo)
        {
            return _posInvoiceRepository.GetPosInvoice(invoiceNo);
        }

        public PosInvoice AddPosInvoice(PosInvoice posInvoice)
        {
            return _posInvoiceRepository.AddPosInvoice(posInvoice);
        }

        public PosInvoice UpdatePosInvoice(long posInvoiceId, PosInvoice posInvoice)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSupplierInvoice(long posInvoiceId)
        {
            throw new NotImplementedException();
        }

        public string GetInvoiceNo()
        {
            string invoiceNo;
            try
            {
                var lastInvoiceNo = _posInvoiceRepository.GetLastInvoiceNo();
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
        
        public decimal GetTotalBalance(string memberId)
        {
            return _posInvoiceRepository.GetTotalBalance(memberId);
        }

        public decimal GetCashInHand()
        {
            return _posInvoiceRepository.GetCashInHand();
        }
    }
}
