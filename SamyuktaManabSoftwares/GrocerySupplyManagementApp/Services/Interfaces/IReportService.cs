using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IReportService
    {
        IEnumerable<InvoiceReportView> GetInvoiceReport(string invoiceNo);
    }
}
