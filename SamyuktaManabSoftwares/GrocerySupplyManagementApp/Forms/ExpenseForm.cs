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
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;

        #region Constructor
        public ExpenseForm(IFiscalYearService fiscalYearService,
            IBankService bankService, IBankTransactionService bankTransactionService, 
            IUserTransactionService userTransactionService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _userTransactionService = userTransactionService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }
        #endregion

        #region Form Load Event
        private void ExpenseForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            var expenseTransactionFilter = new ExpenseTransactionFilter
            {
                //DateFrom = string.IsNullOrWhiteSpace(MaskDateFrom.Text) ? DateTime.MinValue : Convert.ToDateTime(MaskDateFrom.Text),
                //DateTo = string.IsNullOrWhiteSpace(MaskDateTo.Text) ? DateTime.MinValue : Convert.ToDateTime(MaskDateTo.Text),
                Expense = string.IsNullOrWhiteSpace(ComboFilteredBy.Text) ? null : ComboFilteredBy.Text
            };

            LoadExpenseTransaction(expenseTransactionFilter);
        }

        private void BtnSaveExpense_Click(object sender, EventArgs e)
        {
            try
            {
                var date = DateTime.Now;
                var posTransaction = new UserTransaction
                {
                    EndOfDay = _endOfDay,
                    Action = Constants.EXPENSE,
                    ActionType = ComboPayment.Text,
                    Bank = ComboPayment.Text.ToLower() == Constants.CHEQUE.ToLower() ? ComboBank.Text : null,
                    IncomeExpense = ComboExpense.Text,
                    SubTotal = 0.0m,
                    DiscountPercent = 0.0m,
                    Discount = 0.0m,
                    VatPercent = 0.0m,
                    Vat = 0.0m,
                    DeliveryChargePercent = 0.0m,
                    DeliveryCharge = 0.0m,
                    DueAmount = Convert.ToDecimal(RichAmount.Text),
                    ReceivedAmount = 0.0m,
                    AddedDate = date,
                    UpdatedDate = date
                };
                _userTransactionService.AddUserTransaction(posTransaction);

                if (ComboPayment.Text.ToLower() == Constants.CHEQUE.ToLower())
                {
                    var lastUserTransaction = _userTransactionService.GetLastUserTransaction(string.Empty);

                    ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                    var bankTransaction = new BankTransaction
                    {
                        EndOfDay = _endOfDay,
                        BankId = Convert.ToInt64(selectedItem.Id),
                        TransactionId = lastUserTransaction.Id,
                        Action = '0',
                        Debit = 0.0m,
                        Credit = Convert.ToDecimal(RichAmount.Text),
                        Narration = ComboExpense.Text,
                        AddedDate = date,
                        UpdatedDate = date
                    };

                    _bankTransactionService.AddBankTransaction(bankTransaction);
                }

                DialogResult result = MessageBox.Show(ComboPayment.Text + " has been saved successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    LoadExpenseTransaction();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridExpenseList.SelectedRows.Count == 1)
                {
                    var selectedRow = DataGridExpenseList.SelectedRows[0];
                    var id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    if (_userTransactionService.DeleteUserTransaction(id))
                    {
                        if (_bankTransactionService.DeleteBankTransactionByUserTransaction(id))
                        {
                            DialogResult result = MessageBox.Show("Expense has been deleted successfully.", "Message", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ClearAllFields();
                                LoadExpenseTransaction();
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
        private void ComboPayment_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedPayment = ComboPayment.Text;
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
        #endregion

        #region Radio Button Event
        private void RadioAll_CheckedChanged(object sender, EventArgs e)
        {
            MaskEndOfDayFrom.Clear();
            MaskEndOfDayTo.Clear();
            ComboFilteredBy.Text = string.Empty;
        }
        #endregion

        #region Data Grid Event
        private void DataGridExpenseList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridExpenseList.Columns["Id"].Visible = false;

            DataGridExpenseList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridExpenseList.Columns["EndOfDay"].Width = 100;
            DataGridExpenseList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridExpenseList.Columns["Action"].HeaderText = "Description";
            DataGridExpenseList.Columns["Action"].Width = 100;
            DataGridExpenseList.Columns["Action"].DisplayIndex = 1;

            DataGridExpenseList.Columns["ActionType"].HeaderText = "Type";
            DataGridExpenseList.Columns["ActionType"].Width = 200;
            DataGridExpenseList.Columns["ActionType"].DisplayIndex = 2;

            DataGridExpenseList.Columns["Expense"].HeaderText = "Expense";
            DataGridExpenseList.Columns["Expense"].Width = 100;
            DataGridExpenseList.Columns["Expense"].DisplayIndex = 3;

            DataGridExpenseList.Columns["DueAmount"].HeaderText = "Debit";
            DataGridExpenseList.Columns["DueAmount"].Width = 100;
            DataGridExpenseList.Columns["DueAmount"].DisplayIndex = 4;
            DataGridExpenseList.Columns["DueAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridExpenseList.Columns["ReceivedAmount"].HeaderText = "Credit";
            DataGridExpenseList.Columns["ReceivedAmount"].Width = 100;
            DataGridExpenseList.Columns["ReceivedAmount"].DisplayIndex = 5;
            DataGridExpenseList.Columns["ReceivedAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridExpenseList.Columns["Balance"].HeaderText = "Balance";
            DataGridExpenseList.Columns["Balance"].DisplayIndex = 6;
            DataGridExpenseList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridExpenseList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridExpenseList.Rows)
            {
                DataGridExpenseList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridExpenseList.RowHeadersWidth = 50;
                DataGridExpenseList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        #endregion

        #region Helper Methods
        private void LoadExpenseTransaction(ExpenseTransactionFilter expenseTransaction = null)
        {
            try
            {
                List<ExpenseTransactionView> expenseTransactionViews = _userTransactionService.GetExpenseTransactions(expenseTransaction).ToList();

                TxtTotalAmount.Text = expenseTransactionViews.Sum(x => x.DueAmount).ToString();

                var bindingList = new BindingList<ExpenseTransactionView>(expenseTransactionViews);
                var source = new BindingSource(bindingList, null);
                DataGridExpenseList.DataSource = source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearAllFields()
        {
            ComboExpense.Text = string.Empty;
            ComboPayment.Text = string.Empty;
            RichAmount.Clear();
            ComboBank.Text = string.Empty;
        }

        #endregion
    }
}
