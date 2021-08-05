using GrocerySupplyManagementApp.ViewModels;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IReportRepository
    {
        InvoiceReportView GetInvoiceReport(string invoiceNo);
    }
}
