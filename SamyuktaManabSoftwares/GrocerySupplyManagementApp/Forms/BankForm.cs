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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;

        private readonly string _username;
        private readonly Setting _setting;
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
            SaveTransaction,
            RemoveTransaction,
            Load,
            None
        }
        #endregion 

        #region Constructor
        public BankForm(string username, ISettingService settingService, IBankService bankService,
            IBankTransactionService bankTransactionService)
        {
            InitializeComponent();

            _settingService = settingService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void BankForm_Load(object sender, EventArgs e)
        {
            MaskEndOfDayFrom.Text = _endOfDay;
            MaskEndOfDayTo.Text = _endOfDay;
            LoadDepositTypes();
            LoadTransaction();
            EnableFields();
            EnableFields(Action.Load);
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
                if (ValidateBankTransaction())
                {
                    var bankTransaction = new BankTransaction
                    {
                        EndOfDay = _endOfDay,
                        BankId = selectedBankId,
                        Type = ComboTransaction.Text.Trim().ToLower() == Constants.DEPOSIT.ToLower() ? '1' : '0',
                        Action = ComboType.Text.Trim(),
                        Debit = ComboTransaction.Text.Trim().ToLower() == Constants.DEPOSIT.ToLower() ? Convert.ToDecimal(RichAmount.Text.Trim()) : Constants.DEFAULT_DECIMAL_VALUE,
                        Credit = ComboTransaction.Text.Trim().ToLower() == Constants.DEPOSIT.ToLower() ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichAmount.Text.Trim()),
                        Narration = ComboType.Text.Trim(),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _bankTransactionService.AddBankTransaction(bankTransaction);
                    DialogResult result = MessageBox.Show(ComboTransaction.Text.Trim() + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        var totalBalance = _bankTransactionService.GetTotalBalance(new BankTransactionFilter() { BankId = selectedBankId });
                        TxtBalance.Text = totalBalance.ToString();
                        ComboTransaction.Text = string.Empty;
                        RichAmount.Clear();
                        ComboType.Text = string.Empty;
                        var bankTransactionViewList = GetBankTransaction();
                        LoadBankTransaction(bankTransactionViewList);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnRemoveTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridBankList.SelectedCells.Count == 1
                    || DataGridBankList.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow;
                    if (DataGridBankList.SelectedCells.Count == 1)
                    {
                        var selectedCell = DataGridBankList.SelectedCells[0];
                        selectedRow = DataGridBankList.Rows[selectedCell.RowIndex];
                    }
                    else
                    {
                        selectedRow = DataGridBankList.SelectedRows[0];
                    }

                    string selectedId = selectedRow?.Cells["Id"]?.Value?.ToString();
                    long selectedTransactionId = Convert.ToInt64(selectedRow?.Cells["TransactionId"]?.Value?.ToString());
                    if (!string.IsNullOrWhiteSpace(selectedId))
                    {
                        if(selectedTransactionId == 0)
                        {
                            DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (deleteResult == DialogResult.Yes)
                            {
                                var id = Convert.ToInt64(selectedId);
                                _bankTransactionService.DeleteBankTransaction(id);

                                var totalBalance = _bankTransactionService.GetTotalBalance(new BankTransactionFilter() { BankId = selectedBankId });
                                TxtBalance.Text = totalBalance.ToString();
                                var bankTransactionViewList = GetBankTransaction();
                                LoadBankTransaction(bankTransactionViewList);
                            }
                        }
                        else
                        {
                            DialogResult deleteResult = MessageBox.Show("Please delete main transaction first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void BtnAddBank_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Add);
            TxtBankName.Focus();
        }

        private void BtnSaveBank_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateBankInfo())
                {
                    var name = TxtBankName.Text.Trim();
                    var accountNo = TxtAccountNo.Text.Trim();
                    var bank = new Bank
                    {
                        EndOfDay = _endOfDay,
                        Name = TxtBankName.Text,
                        AccountNo = TxtAccountNo.Text,
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _bankService.AddBank(bank);

                    DialogResult result = MessageBox.Show(bank.Name + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields();
                        EnableFields(Action.Save);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnEditBank_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Edit);
            TxtBankName.Focus();
        }

        private void BtnUpdateBank_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateBankInfo())
                {
                    var bank = new Bank
                    {
                        Name = TxtBankName.Text.Trim(),
                        AccountNo = TxtAccountNo.Text.Trim(),
                        UpdatedBy = _username,
                        UpdatedDate = DateTime.Now
                    };

                    _bankService.UpdateBank(selectedBankId, bank);
                    MessageBox.Show(TxtBankName.Text.Trim() + " is updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EnableFields();
                    EnableFields(Action.Update);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnDeleteBank_Click(object sender, EventArgs e)
        {
            List<BankTransaction> bankTransactions = _bankTransactionService.GetBankTransactions(selectedBankId).ToList();
            if (bankTransactions.Count > 0)
            {
                MessageBox.Show(TxtBankName.Text.Trim() + " can't be deleted. Please delete its transactions first.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult confirmation = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    _bankService.DeleteBank(selectedBankId);
                    _bankTransactionService.DeleteBankTransaction(selectedBankId);

                    DialogResult result = MessageBox.Show(TxtBankName.Text.Trim() + " is deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields();
                        EnableFields(Action.Delete);
                        var bankTransactionViewList = GetBankTransaction();
                        LoadBankTransaction(bankTransactionViewList);
                    }
                }
            }
        }

        private void BtnShowTransaction_Click(object sender, EventArgs e)
        {
            var transaction = ComboTransactionFilter.Text.Trim();
            var bankTransactionFilter = new BankTransactionFilter();

            if (!string.IsNullOrWhiteSpace(transaction))
            {
                bankTransactionFilter.Type = transaction.Equals(Constants.DEPOSIT) ? '1' : '0';
            }

            bankTransactionFilter.DateFrom = UtilityService.GetDate(MaskEndOfDayFrom.Text.Trim());
            bankTransactionFilter.DateTo = UtilityService.GetDate(MaskEndOfDayTo.Text.Trim());

            var bankTransactionViewList = _bankTransactionService.GetBankTransactionViews(bankTransactionFilter).ToList();
            TxtAmount.Text = bankTransactionViewList.Sum(x => x.Balance).ToString();
            LoadBankTransaction(bankTransactionViewList);
        }
        #endregion

        #region Rich Box Event
        private void RichAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion  

        #region Combo Box Event
        private void ComboTransaction_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboType.Focus();
        }

        private void ComboType_SelectedValueChanged(object sender, EventArgs e)
        {
            RichAmount.Focus();
        }

        private void ComboTransaction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboTransactionFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        #endregion

        #region Data Grid Event
        private void DataGridBankDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridBankList.Columns["Id"].Visible = false;
            DataGridBankList.Columns["TransactionId"].Visible = false;

            DataGridBankList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridBankList.Columns["EndOfDay"].Width = 100;
            DataGridBankList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridBankList.Columns["Description"].HeaderText = "Description";
            DataGridBankList.Columns["Description"].Width = 120;
            DataGridBankList.Columns["Description"].DisplayIndex = 1;

            DataGridBankList.Columns["Narration"].HeaderText = "Narration";
            DataGridBankList.Columns["Narration"].Width = 270;
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

        #region Helper Methods
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
                var bankDetail = _bankService.GetBank(selectedBankId);
                if (bankDetail != null)
                {
                    TxtBankName.Text = bankDetail.Name;
                    TxtAccountNo.Text = bankDetail.AccountNo;
                    var bankBalance = _bankTransactionService.GetTotalBalance(new BankTransactionFilter() { BankId = selectedBankId });
                    TxtBalance.Text = bankBalance.ToString();
                    var bankTransactionViewList = GetBankTransaction();
                    LoadBankTransaction(bankTransactionViewList);
                    EnableFields();
                    EnableFields(Action.Populate);
                    ComboTransaction.Focus();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Add)
            {
                TxtBankName.Enabled = true;
                TxtAccountNo.Enabled = true;

                BtnSaveBank.Enabled = true;
            }
            else if (action == Action.Save)
            {
                BtnAddBank.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                TxtBankName.Enabled = true;
                TxtAccountNo.Enabled = true;

                BtnUpdateBank.Enabled = true;
            }
            else if (action == Action.Update)
            {
                BtnAddBank.Enabled = true;
            }
            else if (action == Action.Delete)
            {
                BtnAddBank.Enabled = true;
                BtnEditBank.Enabled = true;
                BtnDeleteBank.Enabled = true;
            }
            else if (action == Action.Populate)
            {
                ComboTransaction.Enabled = true;
                RichAmount.Enabled = true;
                ComboType.Enabled = true;

                BtnSaveTransaction.Enabled = true;
                BtnRemoveTransaction.Enabled = true;
                BtnAddBank.Enabled = true;
                BtnEditBank.Enabled = true;
                BtnDeleteBank.Enabled = true;
            }
            else if (action == Action.Load)
            {
                BtnAddBank.Enabled = true;
            }
            else
            {
                TxtBankName.Enabled = false;
                TxtAccountNo.Enabled = false;
                ComboTransaction.Enabled = false;
                RichAmount.Enabled = false;
                TxtBalance.Enabled = false;
                ComboType.Enabled = false;

                BtnSaveTransaction.Enabled = false;
                BtnRemoveTransaction.Enabled = false;
                BtnAddBank.Enabled = false;
                BtnSaveBank.Enabled = false;
                BtnEditBank.Enabled = false;
                BtnUpdateBank.Enabled = false;
                BtnDeleteBank.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            TxtBankName.Clear();
            TxtAccountNo.Clear();
            ComboTransaction.Text = string.Empty;
            RichAmount.Clear();
            TxtBalance.Clear();
            ComboType.Text = string.Empty;
        }

        private void LoadDepositTypes()
        {
            ComboType.Items.Clear();
            ComboType.ValueMember = "Id";
            ComboType.DisplayMember = "Value";

            ComboType.Items.Add(new ComboBoxItem { Id = Constants.OWNER_EQUITY, Value = Constants.OWNER_EQUITY });
        }

        private void LoadTransaction()
        {
            ComboTransaction.Items.Clear();
            ComboTransaction.ValueMember = "Id";
            ComboTransaction.DisplayMember = "Value";

            ComboTransaction.Items.Add(new ComboBoxItem { Id = Constants.DEPOSIT, Value = Constants.DEPOSIT });
            ComboTransaction.Items.Add(new ComboBoxItem { Id = Constants.WITHDRAWL, Value = Constants.WITHDRAWL });
        }
        #endregion

        #region Validation
        private bool ValidateBankInfo()
        {
            var isValidated = false;

            var name = TxtBankName.Text.Trim();
            var accountNo = TxtAccountNo.Text.Trim();

            if (string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(accountNo))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Bank Name " +
                    "\n * Account Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }

        private bool ValidateBankTransaction()
        {
            var isValidated = false;

            var depositType = ComboType.Text.Trim();
            var actionType = ComboTransaction.Text.Trim();
            var amount = RichAmount.Text.Trim();

            if (string.IsNullOrWhiteSpace(depositType)
                || string.IsNullOrWhiteSpace(actionType)
                || string.IsNullOrWhiteSpace(amount))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Deposit Type " +
                    "\n * Action Type " +
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
