using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IPosInvoiceRepository
    {
        IEnumerable<PosInvoice> GetPosInvoices();

        IEnumerable<PosInvoice> GetPosInvoicesByMemberId(string memberId);

        PosInvoice GetPosInvoice(long posInvoiceId);

        PosInvoice GetPosInvoice(string invoiceNo);

        PosInvoice AddPosInvoice(PosInvoice posInvoice);

        PosInvoice UpdatePosInvoice(long posInvoiceId, PosInvoice posInvoice);

        bool DeletePosInvoice(long posInvoiceId, PosInvoice posInvoice);

        string GetLastInvoiceNo();

        decimal GetTotalBalance(string memberId);
    }
}
