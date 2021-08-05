using GrocerySupplyManagementApp.ViewModels;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IReportService
    {
        InvoiceReportView GetInvoiceReport(string invoiceNo);
    }
}
