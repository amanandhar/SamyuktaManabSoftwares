using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class IncomeDetailForm : Form
    {
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        private readonly IIncomeDetailService _incomeDetailService;
        private readonly IIncomeService _incomeService;

        #region Constructor
        public IncomeDetailForm(IFiscalYearDetailService fiscalYearDetailService, IIncomeDetailService incomeDetailService,
            IIncomeService incomeService)
        {
            InitializeComponent();

            _fiscalYearDetailService = fiscalYearDetailService;
            _incomeDetailService = incomeDetailService;
            _incomeService = incomeService;
        }
        #endregion

        #region Form Load Event
        private void IncomeDetailForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            var filter = ComboFilter.Text;
            if(string.IsNullOrWhiteSpace(filter))
            {
                LoadIncomeDetails();
            }
            else
            {
                LoadIncomeDetails(filter);
            }
        }

        private void BtnAddIncome_Click(object sender, EventArgs e)
        {
            var income = new Income
            {
                EndOfDate = _fiscalYearDetailService.GetFiscalYearDetail().StartingDate,
                Type = ComboAddIncome.Text,
                Amount = Convert.ToDecimal(RichAddAmount.Text),
                Date = DateTime.Now
            };

            _incomeService.AddIncome(income);

            DialogResult result = MessageBox.Show(ComboAddIncome.Text + " has been added successfully.", "Message", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                ClearAllFields();
                LoadIncomeDetails();
            }
        }

        #endregion

        #region Combo Box Event
        private void ComboFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ComboFilter.Text))
            {
                RadioAll.Checked = false;
            }
            else
            {
                RadioAll.Checked = true;
            }
        }
        #endregion

        #region Mask Textbox Event
        private void MaskDateFrom_KeyUp(object sender, KeyEventArgs e)
        {

        }

        #endregion

        #region DataGrid Event 
        private void DataGridIncomeView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridIncomeView.Columns["InvoiceDate"].HeaderText = "Date";
            DataGridIncomeView.Columns["InvoiceDate"].Width = 75;
            DataGridIncomeView.Columns["InvoiceDate"].DisplayIndex = 0;

            DataGridIncomeView.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridIncomeView.Columns["InvoiceNo"].Width = 90;
            DataGridIncomeView.Columns["InvoiceNo"].DisplayIndex = 1;

            DataGridIncomeView.Columns["ItemCode"].HeaderText = "Code";
            DataGridIncomeView.Columns["ItemCode"].Width = 80;
            DataGridIncomeView.Columns["ItemCode"].DisplayIndex = 2;

            DataGridIncomeView.Columns["ItemName"].HeaderText = "Name";
            DataGridIncomeView.Columns["ItemName"].Width = 200;
            DataGridIncomeView.Columns["ItemName"].DisplayIndex = 3;

            DataGridIncomeView.Columns["ItemBrand"].HeaderText = "Brand";
            DataGridIncomeView.Columns["ItemBrand"].Width = 200;
            DataGridIncomeView.Columns["ItemBrand"].DisplayIndex = 4;

            DataGridIncomeView.Columns["Quantity"].HeaderText = "Quantity";
            DataGridIncomeView.Columns["Quantity"].Width = 80;
            DataGridIncomeView.Columns["Quantity"].DisplayIndex = 5;

            DataGridIncomeView.Columns["ProfitAmount"].HeaderText = "Profit";
            DataGridIncomeView.Columns["ProfitAmount"].Width = 100;
            DataGridIncomeView.Columns["ProfitAmount"].DisplayIndex = 6;

            DataGridIncomeView.Columns["Total"].HeaderText = "Total";
            DataGridIncomeView.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridIncomeView.Columns["Total"].DisplayIndex = 7;

            foreach (DataGridViewRow row in DataGridIncomeView.Rows)
            {
                DataGridIncomeView.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridIncomeView.RowHeadersWidth = 50;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadIncomeDetails(string type = null)
        {
            List<IncomeDetailView> incomeDetails;

            if (!string.IsNullOrWhiteSpace(type) && type.ToLower().Equals(Constants.DELIVERY_CHARGE.ToLower()))
            {
                incomeDetails = _incomeDetailService.GetDeliveryCharge().ToList();
            }
            else if (!string.IsNullOrWhiteSpace(type) && type.ToLower().Equals(Constants.MEMBER_FEE.ToLower()))
            {
                incomeDetails = _incomeDetailService.GetMemberFee().ToList();
            }
            else if (!string.IsNullOrWhiteSpace(type) && type.ToLower().Equals(Constants.OTHER_INCOME.ToLower()))
            {
                incomeDetails = _incomeDetailService.GetOtherIncome().ToList();
            }
            else if (!string.IsNullOrWhiteSpace(type) && type.ToLower().Equals(Constants.SALES_PROFIT.ToLower()))
            {
                incomeDetails = _incomeDetailService.GetSalesProfit().ToList();
            }
            else if(!string.IsNullOrWhiteSpace(type) && type.ToLower().Equals(Constants.SUPPLIERS_COMMISSION.ToLower()))
            {
                incomeDetails = _incomeDetailService.GetSupplilersCommission().ToList();
            }
            else
            {
                incomeDetails = _incomeDetailService.GetDeliveryCharge().ToList();
                incomeDetails.AddRange(_incomeDetailService.GetMemberFee().ToList());
                incomeDetails.AddRange(_incomeDetailService.GetOtherIncome().ToList());
                incomeDetails.AddRange(_incomeDetailService.GetSalesProfit().ToList());
                incomeDetails.AddRange(_incomeDetailService.GetSupplilersCommission().ToList());
            }

            TxtAmount.Text = (incomeDetails.Sum(x => x.Total)).ToString();

            var bindingList = new BindingList<IncomeDetailView>(incomeDetails);
            var source = new BindingSource(bindingList, null);
            DataGridIncomeView.DataSource = source;
        }

        private void ClearAllFields()
        {
            ComboAddIncome.Text = string.Empty;
            RichAddAmount.Clear();
        }
        #endregion
    }
}
