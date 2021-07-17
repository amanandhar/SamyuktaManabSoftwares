﻿using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class FiscalYearForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;

        #region Constructor
        public FiscalYearForm(IFiscalYearService fiscalYearService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
        }
        #endregion

        #region Form Load Event
        private void FiscalYearForm_Load(object sender, EventArgs e)
        {
            var fiscalYear = _fiscalYearService.GetFiscalYear();
            if(fiscalYear != null)
            {
                RichInvoiceNo.Text = fiscalYear.InvoiceNo;
                RichBillNo.Text = fiscalYear.BillNo;
                RichCompanyStartingDate.Text = fiscalYear.StartingDate.ToString();
                RichFiscalYear.Text = fiscalYear.Year;
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
                var fiscalYear = new FiscalYear
                {
                    InvoiceNo = RichInvoiceNo.Text,
                    BillNo = RichBillNo.Text,
                    StartingDate = Convert.ToDateTime(RichCompanyStartingDate.Text),
                    Year = RichFiscalYear.Text
                };

                var truncate = true;
                _fiscalYearService.AddFiscalYear(fiscalYear, truncate);

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
