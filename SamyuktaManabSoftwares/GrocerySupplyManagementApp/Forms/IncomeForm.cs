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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IIncomeExpenseService _incomeExpenseService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Constructor
        public IncomeForm(string username,
            ISettingService settingService, IBankService bankService, 
            IBankTransactionService bankTransactionService, IIncomeExpenseService incomeExpenseService)
        {
            InitializeComponent();

            _settingService = settingService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _incomeExpenseService = incomeExpenseService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void IncomeDetailForm_Load(object sender, EventArgs e)
        {
            LoadIncomes();
            LoadFilterIncomes();
            LoadBanks();
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            LoadIncomeTransactions();
        }

        private void BtnSaveIncome_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateIncomeInfo())
                {
                    ComboBoxItem selectedBank = (ComboBoxItem)ComboBank.SelectedItem;
                    var incomeExpense = new IncomeExpense
                    {
                        EndOfDay = _endOfDay,
                        Action = Constants.INCOME,
                        ActionType = Constants.CHEQUE,
                        BankName = selectedBank?.Value,
                        Type = ComboIncome.Text.Trim(),
                        Narration = TxtBoxNarration.Text.Trim(),
                        ReceivedAmount = Convert.ToDecimal(RichAmount.Text.Trim()),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    var bankTransaction = new BankTransaction
                    {
                        EndOfDay = _endOfDay,
                        BankId = Convert.ToInt64(selectedBank?.Id),
                        Type = '1',
                        Action = Constants.INCOME,
                        Debit = Convert.ToDecimal(RichAmount.Text.Trim()),
                        Narration = ComboIncome.Text.Trim(),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _incomeExpenseService.AddIncome(incomeExpense, bankTransaction, _username);

                    DialogResult result = MessageBox.Show(ComboIncome.Text.Trim() + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        LoadIncomeTransactions();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridIncomeList.SelectedCells.Count == 1
                    || DataGridIncomeList.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow;
                    if (DataGridIncomeList.SelectedCells.Count == 1)
                    {
                        var selectedCell = DataGridIncomeList.SelectedCells[0];
                        selectedRow = DataGridIncomeList.Rows[selectedCell.RowIndex];
                    }
                    else
                    {
                        selectedRow = DataGridIncomeList.SelectedRows[0];
                    }

                    string description = selectedRow?.Cells["Description"]?.Value?.ToString();
                    if(!string.IsNullOrWhiteSpace(description) 
                        && (description == Constants.DELIVERY_CHARGE || description == Constants.SALES_PROFIT || description == Constants.STOCK_ADJUSTMENT))
                    {
                        MessageBox.Show("Please delete the main transaction first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string selectedId = selectedRow?.Cells["Id"]?.Value?.ToString();
                        DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (deleteResult == DialogResult.Yes)
                        {
                            var id = Convert.ToInt64(selectedId);
                            if (_incomeExpenseService.DeleteIncomeExpense(id, Constants.INCOME))
                            {
                                DialogResult result = MessageBox.Show("Income has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (result == DialogResult.OK)
                                {
                                    ClearAllFields();
                                    LoadIncomeTransactions();
                                }
                            }
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }
        #endregion

        #region Text Box Event
        private void RichAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Combo Box Event
        private void ComboFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ComboFilteredBy.Text.Trim()))
            {
                RadioAll.Checked = false;
            }
            else
            {
                RadioAll.Checked = true;
            }
        }

        private void ComboIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Radio Button Event
        private void RadioAll_CheckedChanged(object sender, EventArgs e)
        {
            MaskDtEODFrom.Clear();
            MaskDtEODTo.Clear();
        }
        #endregion

        #region Mask Date Event
        private void MaskDtEODFrom_KeyDown(object sender, KeyEventArgs e)
        {
            RadioAll.Checked = false;
        }

        private void MaskDtEODTo_KeyDown(object sender, KeyEventArgs e)
        {
            RadioAll.Checked = false;
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
            DataGridIncomeList.Columns["AddedDate"].Visible = false;

            DataGridIncomeList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridIncomeList.Columns["EndOfDay"].Width = 85;
            DataGridIncomeList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridIncomeList.Columns["Description"].HeaderText = "Description";
            DataGridIncomeList.Columns["Description"].Width = 150;
            DataGridIncomeList.Columns["Description"].DisplayIndex = 1;

            DataGridIncomeList.Columns["Narration"].HeaderText = "Narration";
            DataGridIncomeList.Columns["Narration"].Width = 150;
            DataGridIncomeList.Columns["Narration"].DisplayIndex = 2;

            DataGridIncomeList.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridIncomeList.Columns["InvoiceNo"].Width = 100;
            DataGridIncomeList.Columns["InvoiceNo"].DisplayIndex = 3;

            DataGridIncomeList.Columns["BankName"].HeaderText = "Bank";
            DataGridIncomeList.Columns["BankName"].Width = 100;
            DataGridIncomeList.Columns["BankName"].DisplayIndex = 4;

            DataGridIncomeList.Columns["ItemCode"].HeaderText = "Item Code";
            DataGridIncomeList.Columns["ItemCode"].Width = 100;
            DataGridIncomeList.Columns["ItemCode"].DisplayIndex = 5;

            DataGridIncomeList.Columns["ItemName"].HeaderText = "Name";
            DataGridIncomeList.Columns["ItemName"].Width = 200;
            DataGridIncomeList.Columns["ItemName"].DisplayIndex = 6;

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
        private void LoadIncomeTransactions()
        {
            try
            {
                var incomeTransactionFilter = new IncomeTransactionFilter();
                var incomeType = string.IsNullOrWhiteSpace(ComboFilteredBy.Text.Trim()) ? null : ComboFilteredBy.Text.Trim();
                incomeTransactionFilter.DateFrom = UtilityService.GetDate(MaskDtEODFrom.Text.Trim());
                incomeTransactionFilter.DateTo = UtilityService.GetDate(MaskDtEODTo.Text.Trim());
                incomeTransactionFilter.IncomeType = incomeType;

                List<IncomeTransactionView> incomeTransactionViewList;

                if (!string.IsNullOrWhiteSpace(incomeType) && incomeType.ToLower().Equals(Constants.DELIVERY_CHARGE.ToLower()))
                {
                    incomeTransactionViewList = _incomeExpenseService.GetDeliveryChargeTransactions(incomeTransactionFilter).ToList();
                }
                else if (!string.IsNullOrWhiteSpace(incomeType)
                    && (
                        incomeType.ToLower().Equals(Constants.BANK_INTEREST.ToLower())
                        || incomeType.ToLower().Equals(Constants.OTHER_INCOME.ToLower())
                        || incomeType.ToLower().Equals(Constants.STOCK_ADJUSTMENT.ToLower())
                        )
                    )
                {
                    incomeTransactionViewList = _incomeExpenseService.GetIncomeTransactions(incomeTransactionFilter).ToList();
                }
                else if (!string.IsNullOrWhiteSpace(incomeType) && incomeType.ToLower().Equals(Constants.SALES_PROFIT.ToLower()))
                {
                    incomeTransactionViewList = _incomeExpenseService.GetSalesProfit(incomeTransactionFilter).ToList();
                }
                else
                {
                    incomeTransactionViewList = _incomeExpenseService.GetDeliveryChargeTransactions(incomeTransactionFilter).ToList();
                    incomeTransactionViewList.AddRange(_incomeExpenseService.GetIncomeTransactions(incomeTransactionFilter).ToList());
                    incomeTransactionViewList.AddRange(_incomeExpenseService.GetSalesProfit(incomeTransactionFilter).ToList());
                }

                TxtTotalAmount.Text = (incomeTransactionViewList.Sum(x => x.Amount)).ToString();

                var bindingList = new BindingList<IncomeTransactionView>(incomeTransactionViewList.OrderByDescending(x => x.AddedDate).ToList());
                var source = new BindingSource(bindingList, null);
                DataGridIncomeList.DataSource = source;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void ClearAllFields()
        {
            ComboIncome.Text = string.Empty;
            RichAmount.Clear();
            ComboBank.Text = string.Empty;
            TxtBoxNarration.Clear();
        }

        private void LoadIncomes()
        {
            ComboIncome.Items.Clear();
            ComboIncome.ValueMember = "Id";
            ComboIncome.DisplayMember = "Value";

            ComboIncome.Items.Add(new ComboBoxItem { Id = Constants.BANK_INTEREST, Value = Constants.BANK_INTEREST });
            ComboIncome.Items.Add(new ComboBoxItem { Id = Constants.OTHER_INCOME, Value = Constants.OTHER_INCOME });
        }

        private void LoadFilterIncomes()
        {
            ComboFilteredBy.Items.Clear();
            ComboFilteredBy.ValueMember = "Id";
            ComboFilteredBy.DisplayMember = "Value";

            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.BANK_INTEREST, Value = Constants.BANK_INTEREST });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.DELIVERY_CHARGE, Value = Constants.DELIVERY_CHARGE });
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

        #region Validation
        private bool ValidateIncomeInfo()
        {
            var isValidated = false;

            var income = ComboIncome.Text.Trim();
            var bank = ComboBank.Text.Trim();
            var amount = RichAmount.Text.Trim();

            if (string.IsNullOrWhiteSpace(income)
                || string.IsNullOrWhiteSpace(bank)
                || string.IsNullOrWhiteSpace(amount))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Income " +
                    "\n * Bank " +
                    "\n * Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }
        #endregion

    }
}
