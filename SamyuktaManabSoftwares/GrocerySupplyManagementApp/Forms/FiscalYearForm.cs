using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class FiscalYearForm : Form
    {
        private readonly IFiscalYearDetailService _fiscalYearDetailService;

        public FiscalYearForm(IFiscalYearDetailService fiscalYearDetailService)
        {
            InitializeComponent();

            _fiscalYearDetailService = fiscalYearDetailService;
        }

        #region Form Load Event
        private void FiscalYearForm_Load(object sender, EventArgs e)
        {
            var fiscalYearDetail = _fiscalYearDetailService.GetFiscalYearDetail();
            if(fiscalYearDetail != null)
            {
                RichInvoiceNo.Text = fiscalYearDetail.InvoiceNo;
                RichBillNo.Text = fiscalYearDetail.BillNo;
                RichCompanyStartingDate.Text = fiscalYearDetail.StartingDate.ToString();
                RichFiscalYear.Text = fiscalYearDetail.FiscalYear;
            }           
        }
        #endregion

        #region Button Click Event
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields(true);
            RichInvoiceNo.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var fiscalYearDetail = new FiscalYearDetail
                {
                    InvoiceNo = RichInvoiceNo.Text,
                    BillNo = RichBillNo.Text,
                    StartingDate = Convert.ToDateTime(RichCompanyStartingDate.Text),
                    FiscalYear = RichFiscalYear.Text
                };

                var truncate = true;
                _fiscalYearDetailService.AddFiscalYearDetail(fiscalYearDetail, truncate);

                DialogResult result = MessageBox.Show("Fiscal year detail has been saved successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    EnableFields(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Helper Methods
        private void EnableFields(bool option)
        {
            RichInvoiceNo.Enabled = option;
            RichBillNo.Enabled = option;
            RichCompanyStartingDate.Enabled = option;
            RichFiscalYear.Enabled = option;
        }
        #endregion
    }
}
