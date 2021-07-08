using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class TaxSetupForm : Form
    {
        private readonly ITaxDetailService _taxDetailService;

        #region Constructor
        public TaxSetupForm(ITaxDetailService taxDetailService)
        {
            InitializeComponent();

            _taxDetailService = taxDetailService;
        }
        #endregion

        #region Form Load Event
        private void TaxSetupForm_Load(object sender, EventArgs e)
        {
            var taxDetail = _taxDetailService.GetTaxDetail();
            if (taxDetail != null)
            {
                TextBoxDiscount.Text = taxDetail.Discount.ToString();
                TextBoxVat.Text = taxDetail.Vat.ToString();
                TextBoxDeliveryCharge.Text = taxDetail.DeliveryCharge.ToString();
            }
        }
        #endregion

        #region Button Click Event
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields(true);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var taxDetail = new TaxDetail
                {
                    Discount = Convert.ToDecimal(TextBoxDiscount.Text),
                    Vat = Convert.ToDecimal(TextBoxVat.Text),
                    DeliveryCharge = Convert.ToDecimal(TextBoxDeliveryCharge.Text)
                };

                var truncate = true;
                _taxDetailService.AddTaxDetail(taxDetail, truncate);

                DialogResult result = MessageBox.Show("Tax detail has been saved successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    EnableFields(false);
                }
            }
            catch(Exception ex)
            { 
                throw ex;
            }
        }
        #endregion

        #region Helper Methods
        private void EnableFields(bool option)
        {
            TextBoxDiscount.Enabled = option;
            TextBoxVat.Enabled = option;
            TextBoxDeliveryCharge.Enabled = option;
        }
        #endregion
    }
}
