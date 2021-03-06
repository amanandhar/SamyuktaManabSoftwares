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
    public partial class ExpenseForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IIncomeExpenseService _incomeExpenseService;
        private readonly ICapitalService _capitalService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Constructor
        public ExpenseForm(string username,
            ISettingService settingService, IBankService bankService,
            IBankTransactionService bankTransactionService, IIncomeExpenseService incomeExpenseService, 
            ICapitalService capitalService)
        {
            InitializeComponent();

            _settingService = settingService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _incomeExpenseService = incomeExpenseService;
            _capitalService = capitalService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void ExpenseForm_Load(object sender, EventArgs e)
        {
            LoadExpenses();
            LoadFilterExpenses();
            LoadPayments();
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            LoadExpenseTransactions();
        }

        private void BtnSaveExpense_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateExpenseInfo())
                {
                    ComboBoxItem selectedBank = (ComboBoxItem)ComboBank.SelectedItem;
                    var paymentAmount = Convert.ToDecimal(RichAmount.Text.Trim());
                    var actionType = ComboPayment.Text.Trim();
                    if (actionType.ToLower() == Constants.CASH.ToLower())
                    {
                        var cashBalance = _capitalService.GetCashBalance(_endOfDay);
                        if (paymentAmount > cashBalance)
                        {
                            var warningResult = MessageBox.Show("No sufficient cash available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (warningResult == DialogResult.OK)
                            {
                                RichAmount.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        var bankBalance = _bankTransactionService.GetTotalBalance(new BankTransactionFilter { BankId = Convert.ToInt64(selectedBank?.Id) });
                        if (paymentAmount > bankBalance)
                        {
                            var warningResult = MessageBox.Show("No sufficient amount in bank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (warningResult == DialogResult.OK)
                            {
                                RichAmount.Focus();
                                return;
                            }
                        }
                    }

                    var incomeExpense = new IncomeExpense
                    {
                        EndOfDay = _endOfDay,
                        Action = Constants.EXPENSE,
                        ActionType = ComboPayment.Text.Trim(),
                        BankName = selectedBank?.Value,
                        Type = ComboExpense.Text.Trim(),
                        Narration = TxtNarration.Text.Trim(),
                        PaymentAmount = Convert.ToDecimal(RichAmount.Text.Trim()),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    if (ComboPayment.Text.Trim().ToLower() == Constants.CHEQUE.ToLower())
                    {
                        var bankTransaction = new BankTransaction
                        {
                            EndOfDay = _endOfDay,
                            BankId = Convert.ToInt64(selectedBank?.Id),
                            Type = '0',
                            Action = Constants.EXPENSE,
                            Credit = Convert.ToDecimal(RichAmount.Text.Trim()),
                            Narration = ComboExpense.Text.Trim(),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };

                        _incomeExpenseService.AddExpense(incomeExpense, bankTransaction, _username);
                    }
                    else
                    {
                        _incomeExpenseService.AddIncomeExpense(incomeExpense);
                    }

                    DialogResult result = MessageBox.Show(ComboPayment.Text.Trim() + " has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        LoadExpenseTransactions();
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
                if (DataGridExpenseList.SelectedCells.Count == 1
                    || DataGridExpenseList.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow;
                    if (DataGridExpenseList.SelectedCells.Count == 1)
                    {
                        var selectedCell = DataGridExpenseList.SelectedCells[0];
                        selectedRow = DataGridExpenseList.Rows[selectedCell.RowIndex];
                    }
                    else
                    {
                        selectedRow = DataGridExpenseList.SelectedRows[0];
                    }

                    string description = selectedRow?.Cells["Description"]?.Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(description)
                        && (description == Constants.SALES_DISCOUNT || description == Constants.STOCK_ADJUSTMENT))
                    {
                        MessageBox.Show("Please delete the main transaction first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string selectedId = selectedRow?.Cells["Id"]?.Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(selectedId))
                        {
                            DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (deleteResult == DialogResult.Yes)
                            {
                                var id = Convert.ToInt64(selectedId);
                                if (_incomeExpenseService.DeleteIncomeExpense(id, Constants.EXPENSE))
                                {
                                    DialogResult result = MessageBox.Show("Expense has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (result == DialogResult.OK)
                                    {
                                        ClearAllFields();
                                        LoadExpenseTransactions();
                                    }
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

        #region Rich Text Box Event
        private void RichAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Combo Box Event
        private void ComboPayment_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedPayment = ComboPayment.Text.Trim();
            if (!string.IsNullOrWhiteSpace(selectedPayment))
            {
                if (selectedPayment.ToLower() == Constants.CHEQUE.ToLower())
                {
                    var banks = _bankService.GetBanks().ToList();
                    if (banks.Count > 0)
                    {
                        ComboBank.ValueMember = "Id";
                        ComboBank.DisplayMember = "Value";
                        banks.OrderBy(x => x.Name).ToList().ForEach(x =>
                        {
                            ComboBank.Items.Add(new ComboBoxItem { Id = x.Id.ToString(), Value = x.Name });
                        });

                        ComboBank.Enabled = true;
                        RichAmount.Enabled = true;
                        ComboBank.Focus();
                    }
                }
                else
                {
                    ComboBank.Enabled = false;
                    RichAmount.Enabled = true;
                    RichAmount.Focus();
                }
            }
        }

        private void ComboBank_SelectedValueChanged(object sender, EventArgs e)
        {
            RichAmount.Focus();
        }

        private void ComboExpense_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboPayment_KeyPress(object sender, KeyPressEventArgs e)
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
            ComboFilteredBy.Text = string.Empty;
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

        #region Data Grid Event
        private void DataGridExpenseList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridExpenseList.Columns["Id"].Visible = false;
            DataGridExpenseList.Columns["AddedDate"].Visible = false;

            DataGridExpenseList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridExpenseList.Columns["EndOfDay"].Width = 100;
            DataGridExpenseList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridExpenseList.Columns["Description"].HeaderText = "Description";
            DataGridExpenseList.Columns["Description"].Width = 200;
            DataGridExpenseList.Columns["Description"].DisplayIndex = 1;

            DataGridExpenseList.Columns["Narration"].HeaderText = "Narration";
            DataGridExpenseList.Columns["Narration"].Width = 450;
            DataGridExpenseList.Columns["Narration"].DisplayIndex = 2;

            DataGridExpenseList.Columns["ActionType"].HeaderText = "Type";
            DataGridExpenseList.Columns["ActionType"].Width = 100;
            DataGridExpenseList.Columns["ActionType"].DisplayIndex = 3;

            DataGridExpenseList.Columns["Amount"].HeaderText = "Amount";
            DataGridExpenseList.Columns["Amount"].DisplayIndex = 4;
            DataGridExpenseList.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridExpenseList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridExpenseList.Rows)
            {
                DataGridExpenseList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridExpenseList.RowHeadersWidth = 50;
                DataGridExpenseList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        #endregion

        #region Helper Methods
        private void LoadExpenseTransactions()
        {
            try
            {
                var expenseTransactionFilter = new ExpenseTransactionFilter();
                var expenseType = string.IsNullOrWhiteSpace(ComboFilteredBy.Text.Trim()) ? null : ComboFilteredBy.Text.Trim();
                expenseTransactionFilter.DateFrom = UtilityService.GetDate(MaskDtEODFrom.Text.Trim());
                expenseTransactionFilter.DateTo = UtilityService.GetDate(MaskDtEODTo.Text.Trim());
                expenseTransactionFilter.ExpenseType = expenseType;

                List<ExpenseTransactionView> expenseTransactionViewList;

                if (!string.IsNullOrWhiteSpace(expenseType) && expenseType.ToLower().Equals(Constants.SALES_DISCOUNT.ToLower()))
                {
                    expenseTransactionViewList = _incomeExpenseService.GetSalesDiscountTransactions(expenseTransactionFilter).ToList();
                }
                else if(!string.IsNullOrWhiteSpace(expenseType) && !expenseType.ToLower().Equals(Constants.SALES_DISCOUNT.ToLower()))
                {
                    expenseTransactionViewList = _incomeExpenseService.GetExpenseTransactions(expenseTransactionFilter).ToList();
                }
                else
                {
                    expenseTransactionViewList = _incomeExpenseService.GetSalesDiscountTransactions(expenseTransactionFilter).ToList();
                    expenseTransactionViewList.AddRange(_incomeExpenseService.GetExpenseTransactions(expenseTransactionFilter).ToList());
                }

                TxtTotalAmount.Text = expenseTransactionViewList.Sum(x => x.Amount).ToString();

                var bindingList = new BindingList<ExpenseTransactionView>(expenseTransactionViewList.OrderBy(x => x.AddedDate).ToList());
                var source = new BindingSource(bindingList, null);
                DataGridExpenseList.DataSource = source;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void ClearAllFields()
        {
            ComboExpense.Text = string.Empty;
            TxtNarration.Clear();
            ComboPayment.Text = string.Empty;
            RichAmount.Clear();
            ComboBank.Text = string.Empty;
        }

        private void LoadExpenses()
        {
            ComboExpense.Items.Clear();
            ComboExpense.ValueMember = "Id";
            ComboExpense.DisplayMember = "Value";

            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.ASSET, Value = Constants.ASSET });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.COMMISSION, Value = Constants.COMMISSION });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.ELECTRICITY, Value = Constants.ELECTRICITY });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.FUEL_TRANSPORTATION, Value = Constants.FUEL_TRANSPORTATION });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.GUEST_HOSPITALITY, Value = Constants.GUEST_HOSPITALITY });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.LOAN_INTEREST, Value = Constants.LOAN_INTEREST });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.MISCELLANEOUS, Value = Constants.MISCELLANEOUS });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.OFFICE_RENT, Value = Constants.OFFICE_RENT });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.REPAIR_MAINTENANCE, Value = Constants.REPAIR_MAINTENANCE });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.SALES_RETURN, Value = Constants.SALES_RETURN });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.STAFF_ALLOWANCE, Value = Constants.STAFF_ALLOWANCE });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.STAFF_SALARY, Value = Constants.STAFF_SALARY });
            ComboExpense.Items.Add(new ComboBoxItem { Id = Constants.TELEPHONE_INTERNET, Value = Constants.TELEPHONE_INTERNET });
        }

        private void LoadFilterExpenses()
        {
            ComboFilteredBy.Items.Clear();
            ComboFilteredBy.ValueMember = "Id";
            ComboFilteredBy.DisplayMember = "Value";

            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.ASSET, Value = Constants.ASSET });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.COMMISSION, Value = Constants.COMMISSION });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.ELECTRICITY, Value = Constants.ELECTRICITY });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.FUEL_TRANSPORTATION, Value = Constants.FUEL_TRANSPORTATION });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.GUEST_HOSPITALITY, Value = Constants.GUEST_HOSPITALITY });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.LOAN_INTEREST, Value = Constants.LOAN_INTEREST });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.MISCELLANEOUS, Value = Constants.MISCELLANEOUS });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.OFFICE_RENT, Value = Constants.OFFICE_RENT });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.REPAIR_MAINTENANCE, Value = Constants.REPAIR_MAINTENANCE });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.SALES_DISCOUNT, Value = Constants.SALES_DISCOUNT });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.SALES_RETURN, Value = Constants.SALES_RETURN });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.STAFF_ALLOWANCE, Value = Constants.STAFF_ALLOWANCE });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.STAFF_SALARY, Value = Constants.STAFF_SALARY });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.STOCK_ADJUSTMENT, Value = Constants.STOCK_ADJUSTMENT });
            ComboFilteredBy.Items.Add(new ComboBoxItem { Id = Constants.TELEPHONE_INTERNET, Value = Constants.TELEPHONE_INTERNET });
        }

        private void LoadPayments()
        {
            ComboPayment.Items.Clear();
            ComboPayment.ValueMember = "Id";
            ComboPayment.DisplayMember = "Value";

            ComboPayment.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboPayment.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
        }

        #endregion

        #region Validation
        private bool ValidateExpenseInfo()
        {
            var isValidated = false;

            var expense = ComboExpense.Text.Trim();
            var paymentType = ComboPayment.Text.Trim();
            var bank = ComboBank.Text.Trim();
            var amount = RichAmount.Text.Trim();

            if (string.IsNullOrWhiteSpace(expense)
                || string.IsNullOrWhiteSpace(paymentType)
                || (paymentType == Constants.CASH && string.IsNullOrWhiteSpace(amount)))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Expense " +
                    "\n * Payment " +
                    "\n * Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(expense)
                || string.IsNullOrWhiteSpace(paymentType)
                || (paymentType == Constants.CHEQUE && string.IsNullOrWhiteSpace(bank))
                || string.IsNullOrWhiteSpace(amount))
            {
                MessageBox.Show("Please enter following fields: " +
                   "\n * Expense " +
                   "\n * Payment " +
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
