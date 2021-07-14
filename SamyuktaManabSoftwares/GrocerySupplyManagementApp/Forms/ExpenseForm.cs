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
    public partial class ExpenseForm : Form
    {
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IBankDetailService _bankDetailService;
        private readonly IBankTransactionService _bankTransactionService;

        #region Constructor
        public ExpenseForm(IFiscalYearDetailService fiscalYearDetailService, IUserTransactionService posTransactionService,
            IBankDetailService bankDetailService, IBankTransactionService bankTransactionService)
        {
            InitializeComponent();

            _fiscalYearDetailService = fiscalYearDetailService;
            _userTransactionService = posTransactionService;
            _bankDetailService = bankDetailService;
            _bankTransactionService = bankTransactionService;
        }
        #endregion

        #region Form Load Event
        private void ExpenseForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button Click
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
                var fiscalYearDetail = _fiscalYearDetailService.GetFiscalYearDetail();
                var posTransaction = new UserTransaction
                {
                    InvoiceDate = fiscalYearDetail.StartingDate,
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
                    TotalAmount = Convert.ToDecimal(RichAmount.Text),
                    ReceivedAmount = 0.0m,
                    Date = DateTime.Now
                };
                _userTransactionService.AddPosTransaction(posTransaction);

                if (ComboPayment.Text.ToLower() == Constants.CHEQUE.ToLower())
                {
                    var lastPosTransaction = _userTransactionService.GetLastPosTransaction(string.Empty);

                    ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                    var bankTransaction = new BankTransaction
                    {
                        BankId = Convert.ToInt64(selectedItem.Id),
                        TransactionId = lastPosTransaction.Id,
                        Action = '0',
                        Debit = 0.0m,
                        Credit = Convert.ToDecimal(RichAmount.Text),
                        Narration = ComboExpense.Text,
                        Date = DateTime.Now
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
                    var id = Convert.ToInt64(DataGridExpenseList.SelectedCells[0].Value.ToString());
                    if (_userTransactionService.DeletePosTransaction(id))
                    {
                        if (_bankTransactionService.DeleteBankTransactionByTransactionId(id))
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

        #region Helper Methods
        private void ClearAllFields()
        {
            ComboExpense.Text = string.Empty;
            ComboPayment.Text = string.Empty;
            RichAmount.Clear();
            ComboBank.Text = string.Empty;
        }

        private void LoadExpenseTransaction(ExpenseTransactionFilter expenseTransaction = null)
        {
            try
            {
                List<ExpenseTransactionView> expenseTransactionViews = _userTransactionService.GetExpenseTransactions(expenseTransaction).ToList();

                TxtTotalAmount.Text = expenseTransactionViews.Sum(x => x.Balance).ToString();

                var bindingList = new BindingList<ExpenseTransactionView>(expenseTransactionViews);
                var source = new BindingSource(bindingList, null);
                DataGridExpenseList.DataSource = source;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Data Grid Events
        private void DataGridExpenseList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridExpenseList.Columns["Id"].Visible = false;

            DataGridExpenseList.Columns["InvoiceDate"].HeaderText = "Date";
            DataGridExpenseList.Columns["InvoiceDate"].Width = 100;
            DataGridExpenseList.Columns["InvoiceDate"].DisplayIndex = 1;
            DataGridExpenseList.Columns["InvoiceDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

            DataGridExpenseList.Columns["Action"].HeaderText = "Particulars";
            DataGridExpenseList.Columns["Action"].Width = 100;
            DataGridExpenseList.Columns["Action"].DisplayIndex = 2;

            DataGridExpenseList.Columns["ActionType"].HeaderText = "Type";
            DataGridExpenseList.Columns["ActionType"].Width = 200;
            DataGridExpenseList.Columns["ActionType"].DisplayIndex = 3;

            DataGridExpenseList.Columns["Expense"].HeaderText = "Expense";
            DataGridExpenseList.Columns["Expense"].Width = 100;
            DataGridExpenseList.Columns["Expense"].DisplayIndex = 4;

            DataGridExpenseList.Columns["TotalAmount"].HeaderText = "Debit";
            DataGridExpenseList.Columns["TotalAmount"].Width = 100;
            DataGridExpenseList.Columns["TotalAmount"].DisplayIndex = 5;

            DataGridExpenseList.Columns["ReceivedAmount"].HeaderText = "Credit";
            DataGridExpenseList.Columns["ReceivedAmount"].Width = 100;
            DataGridExpenseList.Columns["ReceivedAmount"].DisplayIndex = 6;

            DataGridExpenseList.Columns["Balance"].HeaderText = "Balance";
            DataGridExpenseList.Columns["Balance"].DisplayIndex = 7;
            DataGridExpenseList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewRow row in DataGridExpenseList.Rows)
            {
                DataGridExpenseList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridExpenseList.RowHeadersWidth = 50;
            }
        }

        #endregion

        #region Combo Box Events
        private void ComboPayment_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedPayment = ComboPayment.Text;
            if (!string.IsNullOrWhiteSpace(selectedPayment))
            {
                if (selectedPayment.ToLower() == Constants.CHEQUE.ToLower())
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

        #region Radio Button Events
        private void RadioAll_CheckedChanged(object sender, EventArgs e)
        {
            MaskDateFrom.Clear();
            MaskDateTo.Clear();
            ComboFilteredBy.Text = string.Empty;
        }
        #endregion

    }
}
