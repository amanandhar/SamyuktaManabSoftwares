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
            var report = _reportService.GetInvoiceReport(_invoiceNo);
            /* Previous
            // TODO: This line of code loads data into the 'sampleSalesDBDataSet.tbl_FullSales' table. You can move, or remove it, as needed.
            this.tbl_FullSalesTableAdapter.Fill(this.sampleSalesDBDataSet.tbl_FullSales);
            //this.Controls.Add(this.reportViewer1);
            this.reportViewer1.RefreshReport();
            */

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

            invoiceDataTable.Rows.Add(row);
   
            ReportDataSource reportDataSource = new ReportDataSource("Invoice", invoiceDataTable);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();

        }
        #endregion
    }
}
