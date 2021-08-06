using GrocerySupplyManagementApp.Services.Interfaces;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class InvoiceReportForm : Form
    {
        private readonly IReportService _reportService;

        private string _invoiceNo;

        #region Constructor
        public InvoiceReportForm(IReportService reportService, string invoiceNo)
        {
            InitializeComponent();

            _reportService = reportService;

            _invoiceNo = invoiceNo;
        }
        #endregion

        #region Form Load Event
        private void InvoiceReportForm_Load(object sender, EventArgs e)
        {
            LoadInvoiceReport();
        }
        #endregion

        #region Helper Methods
        private void LoadInvoiceReport()
        {
            var reports = _reportService.GetInvoiceReport(_invoiceNo);

            DataTable invoiceDataTable = new DataTable();

            invoiceDataTable.Columns.Add("MemberId");
            invoiceDataTable.Columns.Add("Name");
            invoiceDataTable.Columns.Add("Address");
            invoiceDataTable.Columns.Add("ContactNo");
            invoiceDataTable.Columns.Add("InvoiceNo");
            invoiceDataTable.Columns.Add("ActionType");
            invoiceDataTable.Columns.Add("EndOfDay");
            invoiceDataTable.Columns.Add("SubTotal");
            invoiceDataTable.Columns.Add("Discount");
            invoiceDataTable.Columns.Add("Vat");
            invoiceDataTable.Columns.Add("DueAmount");
            invoiceDataTable.Columns.Add("ReceivedAmount");
            invoiceDataTable.Columns.Add("Balance");
            invoiceDataTable.Columns.Add("ItemName");
            invoiceDataTable.Columns.Add("Brand");
            invoiceDataTable.Columns.Add("Unit");
            invoiceDataTable.Columns.Add("Quantity");
            invoiceDataTable.Columns.Add("Price");

            foreach (var report in reports)
            {
                var row = invoiceDataTable.NewRow();

                row["MemberId"] = report.MemberId;
                row["Name"] = report.Name;
                row["Address"] = report.Address;
                row["ContactNo"] = report.ContactNo;
                row["InvoiceNo"] = report.InvoiceNo;
                row["ActionType"] = report.ActionType;
                row["EndOfDay"] = report.EndOfDay;
                row["SubTotal"] = report.SubTotal;
                row["Discount"] = report.Discount;
                row["Vat"] = report.Vat;
                row["DueAmount"] = report.DueAmount;
                row["ReceivedAmount"] = report.ReceivedAmount;
                row["Balance"] = report.Balance;
                row["ItemName"] = report.ItemName;
                row["Brand"] = report.Brand;
                row["Unit"] = report.Unit;
                row["Quantity"] = report.Quantity;
                row["Price"] = report.Price;

                invoiceDataTable.Rows.Add(row);
            }

            ReportDataSource reportDataSource = new ReportDataSource("Invoice", invoiceDataTable);

            this.reportViewerInvoice.LocalReport.DataSources.Clear();
            this.reportViewerInvoice.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewerInvoice.RefreshReport();
        }
        #endregion
    }
}
