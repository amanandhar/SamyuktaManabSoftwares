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
        private readonly IUserTransactionService _userTransactionService;
        private readonly IBankDetailService _bankDetailService;
        private readonly IBankTransactionService _bankTransactionService;

        #region Constructor
        public IncomeDetailForm(IFiscalYearDetailService fiscalYearDetailService, IIncomeDetailService incomeDetailService,
            IUserTransactionService userTransactionService, IBankDetailService bankDetailService,
            IBankTransactionService bankTransactionService)
        {
            InitializeComponent();

            _fiscalYearDetailService = fiscalYearDetailService;
            _incomeDetailService = incomeDetailService;
            _userTransactionService = userTransactionService;
            _bankDetailService = bankDetailService;
            _bankTransactionService = bankTransactionService;
        }
        #endregion

        #region Form Load Event
        private void IncomeDetailForm_Load(object sender, EventArgs e)
        {
            LoadBankDetails();
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
            var userTransaction = new UserTransaction
            {
                InvoiceDate = _fiscalYearDetailService.GetFiscalYearDetail().StartingDate,
                Action = Constants.RECEIPT,
                ActionType = Constants.CHEQUE,
                Bank = ComboBank.Text,
                IncomeExpense = ComboAddIncome.Text,
                SubTotal = 0.0m,
                DiscountPercent = 0.0m,
                Discount = 0.0m,
                VatPercent = 0.0m,
                Vat = 0.0m,
                DeliveryChargePercent = 0.0m,
                DeliveryCharge = 0.0m,
                TotalAmount = 0.0m,
                ReceivedAmount = Convert.ToDecimal(RichAddAmount.Text),
                Date = DateTime.Now
            };

            if(_userTransactionService.AddPosTransaction(userTransaction) != null)
            {
                var lastPosTransaction = _userTransactionService.GetLastPosTransaction(string.Empty);
                ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                var bankTransaction = new BankTransaction
                {
                    BankId = Convert.ToInt64(selectedItem.Id),
                    TransactionId = lastPosTransaction.Id,
                    Action = '1',
                    Debit = Convert.ToDecimal(RichAddAmount.Text),
                    Credit = 0.0m,
                    Narration = ComboAddIncome.Text,
                    Date = DateTime.Now
                };

                _bankTransactionService.AddBankTransaction(bankTransaction);
            }

            DialogResult result = MessageBox.Show(ComboAddIncome.Text + " has been added successfully.", "Message", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                ClearAllFields();
                LoadIncomeDetails();
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridIncomeView.SelectedRows.Count == 1)
                {
                    var id = Convert.ToInt64(DataGridIncomeView.SelectedCells[0].Value.ToString());
                    if(_userTransactionService.DeletePosTransaction(id))
                    {
                        if(_bankTransactionService.DeleteBankTransactionByTransactionId(id))
                        {
                            DialogResult result = MessageBox.Show("Income has been deleted successfully.", "Message", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ClearAllFields();
                                LoadIncomeDetails();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
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
            DataGridIncomeView.Columns["Id"].Visible = false;
            DataGridIncomeView.Columns["Id"].DisplayIndex = 0;

            DataGridIncomeView.Columns["InvoiceDate"].HeaderText = "Date";
            DataGridIncomeView.Columns["InvoiceDate"].Width = 75;
            DataGridIncomeView.Columns["InvoiceDate"].DisplayIndex = 1;

            DataGridIncomeView.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridIncomeView.Columns["InvoiceNo"].Width = 100;
            DataGridIncomeView.Columns["InvoiceNo"].DisplayIndex = 2;

            DataGridIncomeView.Columns["ItemCode"].HeaderText = "Code";
            DataGridIncomeView.Columns["ItemCode"].Width = 80;
            DataGridIncomeView.Columns["ItemCode"].DisplayIndex = 3;

            DataGridIncomeView.Columns["ItemName"].HeaderText = "Name";
            DataGridIncomeView.Columns["ItemName"].Width = 200;
            DataGridIncomeView.Columns["ItemName"].DisplayIndex = 4;

            DataGridIncomeView.Columns["ItemBrand"].HeaderText = "Brand";
            DataGridIncomeView.Columns["ItemBrand"].Width = 200;
            DataGridIncomeView.Columns["ItemBrand"].DisplayIndex = 5;

            DataGridIncomeView.Columns["Quantity"].HeaderText = "Quantity";
            DataGridIncomeView.Columns["Quantity"].Width = 80;
            DataGridIncomeView.Columns["Quantity"].DisplayIndex = 6;

            DataGridIncomeView.Columns["ProfitAmount"].HeaderText = "Profit";
            DataGridIncomeView.Columns["ProfitAmount"].Width = 90;
            DataGridIncomeView.Columns["ProfitAmount"].DisplayIndex = 7;

            DataGridIncomeView.Columns["Total"].HeaderText = "Total";
            DataGridIncomeView.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridIncomeView.Columns["Total"].DisplayIndex = 8;

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
            else
            {
                incomeDetails = _incomeDetailService.GetDeliveryCharge().ToList();
                incomeDetails.AddRange(_incomeDetailService.GetMemberFee().ToList());
                incomeDetails.AddRange(_incomeDetailService.GetOtherIncome().ToList());
                incomeDetails.AddRange(_incomeDetailService.GetSalesProfit().ToList());
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
            ComboBank.Text = string.Empty;
        }

        private void LoadBankDetails()
        {
            var bankDetails = _bankDetailService.GetBankDetails().ToList();
            if (bankDetails.Count > 0)
            {
                ComboBank.ValueMember = "Id";
                ComboBank.DisplayMember = "Value";

                bankDetails.OrderBy(x => x.Name).ToList().ForEach(x =>
                {
                    ComboBank.Items.Add(new ComboBoxItem { Id = x.Id.ToString(), Value = x.Name });
                });
            }
        }
        #endregion
    }
}
