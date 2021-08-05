using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;

namespace GrocerySupplyManagementApp.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public InvoiceReportView GetInvoiceReport(string invoiceNo)
        {
            return _reportRepository.GetInvoiceReport(invoiceNo);
        }
    }
}
