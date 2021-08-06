using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IReportRepository
    {
        IEnumerable<InvoiceReportView> GetInvoiceReport(string invoiceNo);
    }
}
