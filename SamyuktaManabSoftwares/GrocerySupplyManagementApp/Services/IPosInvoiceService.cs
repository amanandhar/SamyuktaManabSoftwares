using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IPosInvoiceService
    {
        IEnumerable<PosInvoice> GetPosInvoices();
        IEnumerable<PosInvoice> GetPosInvoices(string memberId);
        IEnumerable<MemberTransactionView> GetMemberTransactions(string memberId);
        PosInvoice GetPosInvoice(long posInvoiceId);
        PosInvoice GetPosInvoice(string invoiceNo);
        PosInvoice AddPosInvoice(PosInvoice posInvoice);
        PosInvoice UpdatePosInvoice(long posInvoiceId, PosInvoice posInvoice);
        bool DeleteSupplierInvoice(long posInvoiceId);
        string GetInvoiceNo();
        decimal GetTotalBalance(string memberId);
        decimal GetCashInHand();
    }
}
