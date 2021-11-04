using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class InvoiceReportForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ICompanyInfoService _companyInfoService;
        private readonly IReportService _reportService;

        private readonly string _invoiceNo;
        private int _pageMarginLeft;
        private int _pageMarginRight;
        private int _pageMarginTop;
        private int _pageMarginBottom;

        private string _baseImageFolder;
        private string _companyImageFolder;

        #region Constructor
        public InvoiceReportForm(ICompanyInfoService companyInfoService, IReportService reportService,
            string invoiceNo)
        {
            InitializeComponent();

            _companyInfoService = companyInfoService;
            _reportService = reportService;

            _invoiceNo = invoiceNo;
        }
        #endregion

        #region Form Load Event
        private void InvoiceReportForm_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
            _companyImageFolder = ConfigurationManager.AppSettings[Constants.COMPANY_IMAGE_FOLDER].ToString();

            LoadInvoiceReport();
        }
        #endregion

        #region Helper Methods
        private void LoadInvoiceReport()
        {
            var companyInfo = _companyInfoService.GetCompanyInfo();
            var reports = _reportService.GetInvoiceReport(_invoiceNo);

            DataTable companyInfoDataTable = new DataTable();
            companyInfoDataTable.Columns.Add("Name");
            companyInfoDataTable.Columns.Add("Address");
            companyInfoDataTable.Columns.Add("ContactNo");
            companyInfoDataTable.Columns.Add("LogoPath");

            var companyInfoRow = companyInfoDataTable.NewRow();

            companyInfoRow["Name"] = companyInfo.Name;
            companyInfoRow["Address"] = companyInfo.Address;
            companyInfoRow["ContactNo"] = companyInfo.ContactNo;
            companyInfoRow["LogoPath"] = companyInfo.LogoPath;

            companyInfoDataTable.Rows.Add(companyInfoRow);

            DataTable invoiceDataTable = new DataTable();

            invoiceDataTable.Columns.Add("MemberId");
            invoiceDataTable.Columns.Add("Name");
            invoiceDataTable.Columns.Add("Address");
            invoiceDataTable.Columns.Add("ContactNo");
            invoiceDataTable.Columns.Add("AccountNo");
            invoiceDataTable.Columns.Add("InvoiceNo");
            invoiceDataTable.Columns.Add("ActionType");
            invoiceDataTable.Columns.Add("EndOfDay");
            invoiceDataTable.Columns.Add("SubTotal");
            invoiceDataTable.Columns.Add("Discount");
            invoiceDataTable.Columns.Add("DeliveryCharge");
            invoiceDataTable.Columns.Add("TotalAmount");
            invoiceDataTable.Columns.Add("ReceivedAmount");
            invoiceDataTable.Columns.Add("DueReceivedAmount");
            invoiceDataTable.Columns.Add("AmountInWords");
            invoiceDataTable.Columns.Add("ItemName");
            invoiceDataTable.Columns.Add("Volume");
            invoiceDataTable.Columns.Add("Unit");
            invoiceDataTable.Columns.Add("Quantity");
            invoiceDataTable.Columns.Add("Price");
            invoiceDataTable.Columns.Add("Amount");
            invoiceDataTable.Columns.Add("ItemNo");

            foreach (var report in reports)
            {
                var invoiceRow = invoiceDataTable.NewRow();

                invoiceRow["MemberId"] = report.MemberId;
                invoiceRow["Name"] = report.Name;
                invoiceRow["Address"] = report.Address;
                invoiceRow["ContactNo"] = report.ContactNo;
                invoiceRow["AccountNo"] = report.AccountNo;
                invoiceRow["InvoiceNo"] = report.InvoiceNo;
                invoiceRow["ActionType"] = report.ActionType;
                invoiceRow["EndOfDay"] = report.EndOfDay;
                invoiceRow["SubTotal"] = report.SubTotal;
                invoiceRow["Discount"] = report.Discount;
                invoiceRow["DeliveryCharge"] = report.DeliveryCharge;
                invoiceRow["TotalAmount"] = report.TotalAmount;
                invoiceRow["ReceivedAmount"] = report.ReceivedAmount;
                invoiceRow["DueReceivedAmount"] = report.DueReceivedAmount;
                invoiceRow["AmountInWords"] = UtilityService.ConvertAmount(report.TotalAmount);
                invoiceRow["ItemName"] = report.ItemName;
                invoiceRow["Volume"] = report.Volume;
                invoiceRow["Unit"] = report.Unit;
                invoiceRow["Quantity"] = report.Quantity;
                invoiceRow["Price"] = report.Price;
                invoiceRow["Amount"] = report.Amount;
                invoiceRow["ItemNo"] = report.ItemNo;

                invoiceDataTable.Rows.Add(invoiceRow);
            }

            ReportDataSource companyInfoDataSource = new ReportDataSource("Company", companyInfoDataTable);
            ReportDataSource reportDataSource = new ReportDataSource("Invoice", invoiceDataTable);

            this.reportViewerInvoice.LocalReport.EnableExternalImages = true;
            var logoPath = string.Empty;
            var absoluteImagePath = Path.Combine(_baseImageFolder, _companyImageFolder, companyInfo.LogoPath);
            if (File.Exists(absoluteImagePath))
            {
                logoPath = new Uri(absoluteImagePath).AbsoluteUri;
            }

            ReportParameter parameter = new ReportParameter
            {
                Name = "LogoPath"
            };
            parameter.Values.Add(logoPath);
            this.reportViewerInvoice.LocalReport.SetParameters(parameter);

            _pageMarginLeft = Convert.ToInt32(ConfigurationManager.AppSettings[Constants.PAGE_MARGIN_LEFT].ToString());
            _pageMarginRight = Convert.ToInt32(ConfigurationManager.AppSettings[Constants.PAGE_MARGIN_RIGHT].ToString());
            _pageMarginTop = Convert.ToInt32(ConfigurationManager.AppSettings[Constants.PAGE_MARGIN_TOP].ToString());
            _pageMarginBottom = Convert.ToInt32(ConfigurationManager.AppSettings[Constants.PAGE_MARGIN_BOTTOM].ToString());
            var setup = this.reportViewerInvoice.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(_pageMarginLeft, _pageMarginRight, _pageMarginTop, _pageMarginBottom);
            this.reportViewerInvoice.SetPageSettings(setup);

            this.reportViewerInvoice.LocalReport.DataSources.Clear();
            this.reportViewerInvoice.LocalReport.DataSources.Add(companyInfoDataSource);
            this.reportViewerInvoice.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewerInvoice.RefreshReport();
        }
        #endregion
    }
}
