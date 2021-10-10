using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class IncomeForm : Form
    {
        private readonly ISettingService _settingService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Constructor
        public IncomeForm(string username,
            ISettingService settingService, 
            IBankService bankService, IBankTransactionService bankTransactionService,
            IUserTransactionService userTransactionService)
        {
            InitializeComponent();

            _settingService = settingService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _userTransactionService = userTransactionService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void IncomeDetailForm_Load(object sender, EventArgs e)
        {
            MaskEndOfDayFrom.Text = _endOfDay;
            MaskEndOfDayTo.Text = _endOfDay;
            LoadIncomes();
            LoadFilterIncomes();
            LoadBanks();
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            LoadIncomeDetails();
        }

        private void BtnSaveIncome_Click(object sender, EventArgs e)
        {
            var userTransaction = new UserTransaction
            {
                EndOfDay = _endOfDay,
                Action = Constants.RECEIPT,
                ActionType = Constants.CHEQUE,
                Bank = ComboBank.Text,
                Income = ComboIncome.Text,
                ReceivedAmount = Convert.ToDecimal(RichAddAmount.Text),
                AddedBy = _username,
                AddedDate = DateTime.Now
            };

            if (_userTransactionService.AddUserTransaction(userTransaction) != null)
            {
                var lastUserTransaction = _userTransactionService.GetLastUserTransaction(string.Empty);
                ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                var bankTransaction = new BankTransaction
                {
                    EndOfDay = _endOfDay,
                    BankId = Convert.ToInt64(selectedItem.Id),
                    TransactionId = lastUserTransaction.Id,
                    Action = '1',
                    Debit = Convert.ToDecimal(RichAddAmount.Text),
                    Credit = 0.00m,
                    Narration = ComboIncome.Text,
                    AddedBy = _username,
                    AddedDate = DateTime.Now
                };

                _bankTransactionService.AddBankTransaction(bankTransaction);
            }

            DialogResult result = MessageBox.Show(ComboIncome.Text + " has been added successfully.", "Message", MessageBoxButtons.OK);
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
                if (DataGridIncomeList.SelectedRows.Count == 1)
                {
                    var selectedRow = DataGridIncomeList.SelectedRows[0];
                    var id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    if (_userTransactionService.DeleteUserTransaction(id))
                    {
                        if (_bankTransactionService.DeleteBankTransactionByUserTransaction(id))
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Combo Box Event
        private void ComboFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ComboFilteredBy.Text))
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
            DataGridIncomeList.Columns["Id"].Visible = false;

            DataGridIncomeList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridIncomeList.Columns["EndOfDay"].Width = 85;
            DataGridIncomeList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridIncomeList.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridIncomeList.Columns["InvoiceNo"].Width = 125;
            DataGridIncomeList.Columns["InvoiceNo"].DisplayIndex = 1;

            DataGridIncomeList.Columns["ItemCode"].HeaderText = "ItemCode";
            DataGridIncomeList.Columns["ItemCode"].Width = 90;
            DataGridIncomeList.Columns["ItemCode"].DisplayIndex = 2;

            DataGridIncomeList.Columns["ItemName"].HeaderText = "Name";
            DataGridIncomeList.Columns["ItemName"].Width = 200;
            DataGridIncomeList.Columns["ItemName"].DisplayIndex = 3;

            DataGridIncomeList.Columns["ItemBrand"].HeaderText = "Brand";
            DataGridIncomeList.Columns["ItemBrand"].Width = 175;
            DataGridIncomeList.Columns["ItemBrand"].DisplayIndex = 4;

            DataGridIncomeList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridIncomeList.Columns["Quantity"].Width = 80;
            DataGridIncomeList.Columns["Quantity"].DisplayIndex = 5;
            DataGridIncomeList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridIncomeList.Columns["Profit"].HeaderText = "Profit";
            DataGridIncomeList.Columns["Profit"].Width = 90;
            DataGridIncomeList.Columns["Profit"].DisplayIndex = 6;
            DataGridIncomeList.Columns["Profit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridIncomeList.Columns["Amount"].HeaderText = "Amount";
            DataGridIncomeList.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridIncomeList.Columns["Amount"].DisplayIndex = 7;
            DataGridIncomeList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridIncomeList.Rows)
            {
                DataGridIncomeList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridIncomeList.RowHeadersWidth = 50;
                DataGridIncomeList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadIncomeDetails()
        {
            var incomeTransactionFilter = new IncomeTransactionFilter();
            var income = string.IsNullOrWhiteSpace(ComboFilteredBy.Text) ? null : ComboFilteredBy.Text;
            incomeTransactionFilter.DateFrom = UtilityService.GetDate(MaskEndOfDayFrom.Text);
            incomeTransactionFilter.DateTo = UtilityService.GetDate(MaskEndOfDayTo.Text);
            incomeTransactionFilter.Income = income;

            List<IncomeDetailView> incomeDetails;

            if (!string.IsNullOrWhiteSpace(income) && income.ToLower().Equals(Constants.PURCHASE_BONUS.ToLower()))
            {
                incomeDetails = _userTransactionService.GetPurchaseBonus(incomeTransactionFilter).ToList();
            }
            if (!string.IsNullOrWhiteSpace(income) && income.ToLower().Equals(Constants.DELIVERY_CHARGE.ToLower()))
            {
                incomeDetails = _userTransactionService.GetIncome(incomeTransactionFilter).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(income) && income.ToLower().Equals(Constants.MEMBER_FEE.ToLower()))
            {
                incomeDetails = _userTransactionService.GetIncome(incomeTransactionFilter).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(income) && income.ToLower().Equals(Constants.OTHER_INCOME.ToLower()))
            {
                incomeDetails = _userTransactionService.GetIncome(incomeTransactionFilter).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(income) && income.ToLower().Equals(Constants.SALES_PROFIT.ToLower()))
            {
                incomeDetails = _userTransactionService.GetSalesProfit(incomeTransactionFilter).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(income) && income.ToLower().Equals(Constants.STOCK_ADJUSTMENT.ToLower()))
            {
                incomeDetails = _userTransactionService.GetIncome(incomeTransactionFilter).ToList();
            }
            else
            {
                incomeDetails = _userTransactionService.GetIncome(incomeTransactionFilter).ToList();
                incomeDetails.AddRange(_userTransactionService.GetSalesProfit(incomeTransactionFilter).ToList());
                incomeDetails.AddRange(_userTransactionService.GetPurchaseBonus(incomeTransactionFilter).ToList());
            }

            TxtTotalAmount.Text = (incomeDetails.Sum(x => x.Amount)).ToString();

            var bindingList = new BindingList<IncomeDetailView>(incomeDetails);
            var source = new BindingSource(bindingList, null);
            DataGridIncomeList.DataSource = source;
        }

        private void ClearAllFields()
        {
            ComboIncome.Text = string.Empty;
            RichAddAmount.Clear();
            ComboBank.Text = string.Empty;
        }

        private void LoadIncomes()
        {
            ComboIncome.Items.Clear();
            ComboIncome.ValueMember = "Id";
            ComboIncome.DisplayMember = "Value";

            ComboIncome.Items.Add(new ComboBoxItem { Id = Constants.PURCHASE_BONUS, Value = Constants.PURCHASE_BONUS });
            ComboIncome.Items.Add(new ComboBoxItem { Id = Constants.MEMBER_FEE, Value = Constants.MEMBER_FEE });
            ComboIncome.Items.Add(new ComboBoxItem { Id = Constants.OTHER_INCOME, Value = Constants.OTHER_INCOME });
            ComboIncome.Items.Add(new ComboBoxItem { Id = Constants.SALES_PROFIT, Value = Constants.SALES_PROFIT });
        }

        private void LoadFilterIncomes()
        {
            ComboFilteredBy.Items.Clear();
            ComboFilteredBy.ValueMember = "Id";
            ComboFilteredBy.DisplayMember = "Value";

            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.PURCHASE_BONUS, Value = Constants.PURCHASE_BONUS });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.DELIVERY_CHARGE, Value = Constants.DELIVERY_CHARGE });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.MEMBER_FEE, Value = Constants.MEMBER_FEE });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.OTHER_INCOME, Value = Constants.OTHER_INCOME });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.SALES_PROFIT, Value = Constants.SALES_PROFIT });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.STOCK_ADJUSTMENT, Value = Constants.STOCK_ADJUSTMENT });
        }

        private void LoadBanks()
        {
            ComboBank.Items.Clear();
            var banks = _bankService.GetBanks().ToList();
            if (banks.Count > 0)
            {
                ComboBank.ValueMember = "Id";
                ComboBank.DisplayMember = "Value";

                banks.OrderBy(x => x.Name).ToList().ForEach(x =>
                {
                    ComboBank.Items.Add(new ComboBoxItem { Id = x.Id.ToString(), Value = x.Name });
                });
            }
        }
        #endregion
    }
}
