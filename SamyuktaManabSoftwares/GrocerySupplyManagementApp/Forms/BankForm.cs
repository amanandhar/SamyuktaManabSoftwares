using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
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
    public partial class BankForm : Form, IBankListForm
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;

        private readonly string _endOfDay;
        private long selectedBankId = 0;

        #region Enum
        private enum Action
        {
            Add,
            Save,
            Edit,
            Update,
            Delete,
            Populate,
            None
        }
        #endregion 

        #region Constructor
        public BankForm(IFiscalYearService fiscalYearService, IBankService bankService,
            IBankTransactionService bankTransactionService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }
        #endregion

        #region Form Load Event
        private void BankForm_Load(object sender, EventArgs e)
        {
            MaskEndOfDayFrom.Text = _endOfDay;
            MaskEndOfDayTo.Text = _endOfDay;
        }
        #endregion 

        #region Button Click Event
        private void BtnSearchBank_Click(object sender, EventArgs e)
        {
            BankListForm bankListForm = new BankListForm(_bankService, this);
            bankListForm.ShowDialog();
        }

        private void BtnSaveTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                var date = DateTime.Now;
                var bankTransaction = new BankTransaction
                {
                    EndOfDay = _endOfDay,
                    BankId = selectedBankId,
                    Action = ComboActionType.Text.ToLower() == Constants.DEPOSIT.ToLower() ? '1' : '0',
                    Debit = ComboActionType.Text.ToLower() == Constants.DEPOSIT.ToLower() ? Convert.ToDecimal(RichAmount.Text) : 0.0m,
                    Credit = ComboActionType.Text.ToLower() == Constants.DEPOSIT.ToLower() ? 0.0m : Convert.ToDecimal(RichAmount.Text),
                    Narration = ComboType.Text,
                    AddedDate = date,
                    UpdatedDate = date
                };

                _bankTransactionService.AddBankTransaction(bankTransaction);
                DialogResult result = MessageBox.Show(ComboActionType.Text + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    var totalBalance = _bankTransactionService.GetTotalBalance(selectedBankId);
                    TxtBalance.Text = totalBalance.ToString();
                    ComboActionType.Text = string.Empty;
                    RichAmount.Clear();
                    ComboType.Text = string.Empty;
                    EnableFields(Action.Save, true);
                    var bankTransactionViewList = GetBankTransaction();
                    LoadBankTransaction(bankTransactionViewList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnRemoveTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridBankList.SelectedRows.Count == 1)
                {
                    var selectedRow = DataGridBankList.SelectedRows[0];
                    var id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    _bankTransactionService.DeleteBankTransaction(id);
                    var totalBalance = _bankTransactionService.GetTotalBalance(selectedBankId);
                    TxtBalance.Text = totalBalance.ToString();
                    var bankTransactionViewList = GetBankTransaction();
                    LoadBankTransaction(bankTransactionViewList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnAddBank_Click(object sender, EventArgs e)
        {
            //EnableFields(Action.Add, true);
            RichBankName.Focus();
        }

        private void BtnSaveBank_Click(object sender, EventArgs e)
        {
            try
            {
                var name = RichBankName.Text;
                var accountNo = RichAccountNo.Text;
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(accountNo))
                {
                    DialogResult result = MessageBox.Show("Bank name and account number are required.", "Warning", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        return;
                    }
                }
                else
                {
                    var date = DateTime.Now;
                    var bank = new Bank
                    {
                        Name = RichBankName.Text,
                        AccountNo = RichAccountNo.Text,
                        AddedDate = date,
                        UpdatedDate = date
                    };

                    _bankService.AddBank(bank);

                    DialogResult result = MessageBox.Show(bank.Name + " has been added successfully.", "Message", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields(Action.None, false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnEditBank_Click(object sender, EventArgs e)
        {
            EnableFields(Action.Edit, true);
        }

        private void BtnUpdateBank_Click(object sender, EventArgs e)
        {
            var bank = new Bank
            {
                Name = RichBankName.Text,
                AccountNo = RichAccountNo.Text,
                UpdatedDate = DateTime.Now
            };

            _bankService.UpdateBank(selectedBankId, bank);
            MessageBox.Show(RichBankName.Text + " is updated successfully.", "Message", MessageBoxButtons.OK);
        }

        private void BtnDeleteBank_Click(object sender, EventArgs e)
        {
            List<BankTransaction> bankTransactions = _bankTransactionService.GetBankTransactions(selectedBankId).ToList();
            if (bankTransactions.Count > 0)
            {
                MessageBox.Show(RichBankName.Text + " can't be deleted. Please delete its transactions first.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                _bankService.DeleteBank(selectedBankId);
                _bankTransactionService.DeleteBankTransaction(selectedBankId);

                DialogResult result = MessageBox.Show(RichBankName.Text + " is deleted successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields(Action.None, false);
                    var bankTransactionViewList = GetBankTransaction();
                    LoadBankTransaction(bankTransactionViewList);
                }
            }
        }

        private void BtnShowTransaction_Click(object sender, EventArgs e)
        {
            var action = ComboAction.Text;
            var dateFrom = MaskEndOfDayFrom.Text;
            var dateTo = MaskEndOfDayTo.Text;
            var bankTransactionFilter = new BankTransactionFilter();

            if (!string.IsNullOrWhiteSpace(action))
            {
                bankTransactionFilter.Action = action.Equals(Constants.DEPOSIT) ? '1' : '0';
            }

            if (!string.IsNullOrWhiteSpace(dateFrom.Replace("-", string.Empty).Trim()))
            {
                bankTransactionFilter.DateFrom = dateFrom.Trim();
            }

            if (!string.IsNullOrWhiteSpace(dateFrom.Replace("-", string.Empty).Trim()))
            {
                bankTransactionFilter.DateTo = dateTo.Trim();
            }

            var bankTransactionViewList = _bankTransactionService.GetBankTransactionViews(bankTransactionFilter).ToList();
            TxtAmount.Text = bankTransactionViewList.Sum(x => x.Balance).ToString();
            LoadBankTransaction(bankTransactionViewList);
        }
        #endregion

        #region Data Grid Event
        private void DataGridBankDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridBankList.Columns["Id"].Visible = false;

            DataGridBankList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridBankList.Columns["EndOfDay"].Width = 100;
            DataGridBankList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridBankList.Columns["Description"].HeaderText = "Descriptions";
            DataGridBankList.Columns["Description"].Width = 100;
            DataGridBankList.Columns["Description"].DisplayIndex = 1;

            DataGridBankList.Columns["Narration"].HeaderText = "Narration";
            DataGridBankList.Columns["Narration"].Width = 260;
            DataGridBankList.Columns["Narration"].DisplayIndex = 2;

            DataGridBankList.Columns["Debit"].HeaderText = "Debit";
            DataGridBankList.Columns["Debit"].Width = 100;
            DataGridBankList.Columns["Debit"].DisplayIndex = 3;
            DataGridBankList.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridBankList.Columns["Credit"].HeaderText = "Credit";
            DataGridBankList.Columns["Credit"].Width = 100;
            DataGridBankList.Columns["Credit"].DisplayIndex = 4;
            DataGridBankList.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridBankList.Columns["Balance"].HeaderText = "Balance";
            DataGridBankList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridBankList.Columns["Balance"].DisplayIndex = 5;
            DataGridBankList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridBankList.Rows)
            {
                DataGridBankList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridBankList.RowHeadersWidth = 50;
                DataGridBankList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        #endregion

        #region Helper Method
        private List<BankTransactionView> GetBankTransaction()
        {
            var bankTransactionViewList = _bankTransactionService.GetBankTransactionViews(selectedBankId).ToList();
            return bankTransactionViewList;
        }

        private void LoadBankTransaction(List<BankTransactionView> bankTransactionViewList)
        {
            var bindingList = new BindingList<BankTransactionView>(bankTransactionViewList);
            var source = new BindingSource(bindingList, null);
            DataGridBankList.DataSource = source;
        }

        public void PopulateBank(long bankId)
        {
            try
            {
                selectedBankId = bankId;
                var bankDetail = _bankService.GetBank(bankId);
                RichBankName.Text = bankDetail.Name;
                RichAccountNo.Text = bankDetail.AccountNo;
                var bankBalance = _bankTransactionService.GetTotalBalance(bankId);
                TxtBalance.Text = bankBalance.ToString();
                EnableFields(Action.Populate, true);
                ComboActionType.Focus();
                var bankTransactionViewList = GetBankTransaction();
                LoadBankTransaction(bankTransactionViewList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EnableFields(Action action, bool option = true)
        {
            if (action == Action.Add)
            {
                RichBankName.Enabled = option;
                RichAccountNo.Enabled = option;
            }
            else if (action == Action.Edit)
            {
                RichBankName.Enabled = option;
                RichAccountNo.Enabled = option;
                ComboActionType.Enabled = option;
                RichAmount.Enabled = option;
                TxtBalance.Enabled = option;
                ComboType.Enabled = option;
            }
            else if (action == Action.Save)
            {
                ComboActionType.Enabled = option;
                RichAmount.Enabled = option;
                ComboType.Enabled = option;
            }
            else if (action == Action.Populate)
            {
                ComboActionType.Enabled = option;
                RichAmount.Enabled = option;
                ComboType.Enabled = option;
            }
            else
            {
                RichBankName.Enabled = option;
                RichAccountNo.Enabled = option;
                ComboActionType.Enabled = option;
                RichAmount.Enabled = option;
                TxtBalance.Enabled = option;
                ComboType.Enabled = option;
            }
        }

        private void ClearAllFields()
        {
            RichBankName.Clear();
            RichAccountNo.Clear();
            ComboActionType.Text = string.Empty;
            RichAmount.Clear();
            TxtBalance.Clear();
            ComboType.Text = string.Empty;
        }
        #endregion
    }
}
