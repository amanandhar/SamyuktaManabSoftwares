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
            LoadActionTypes();
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
                var bankTransaction = new BankTransaction
                {
                    EndOfDay = _endOfDay,
                    BankId = selectedBankId,
                    Action = ComboActionType.Text.ToLower() == Constants.DEPOSIT.ToLower() ? '1' : '0',
                    Debit = ComboActionType.Text.ToLower() == Constants.DEPOSIT.ToLower() ? Convert.ToDecimal(RichAmount.Text) : Constants.DEFAULT_DECIMAL_VALUE,
                    Credit = ComboActionType.Text.ToLower() == Constants.DEPOSIT.ToLower() ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichAmount.Text),
                    Narration = ComboDepositType.Text,
                    AddedBy = _username,
                    AddedDate = DateTime.Now
                };

                _bankTransactionService.AddBankTransaction(bankTransaction);
                DialogResult result = MessageBox.Show(ComboActionType.Text + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    var totalBalance = _bankTransactionService.GetTotalBalance(new BankTransactionFilter() { BankId = selectedBankId });
                    TxtBalance.Text = totalBalance.ToString();
                    ComboActionType.Text = string.Empty;
                    RichAmount.Clear();
                    ComboDepositType.Text = string.Empty;
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
                    var totalBalance = _bankTransactionService.GetTotalBalance(new BankTransactionFilter() { BankId = selectedBankId });
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
            TxtBankName.Focus();
        }

        private void BtnSaveBank_Click(object sender, EventArgs e)
        {
            try
            {
                var name = TxtBankName.Text;
                var accountNo = TxtAccountNo.Text;
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
                    var bank = new Bank
                    {
                        Name = TxtBankName.Text,
                        AccountNo = TxtAccountNo.Text,
                        AddedBy = _username,
                        AddedDate = DateTime.Now
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
                Name = TxtBankName.Text,
                AccountNo = TxtAccountNo.Text,
                UpdatedBy = _username,
                UpdatedDate = DateTime.Now
            };

            _bankService.UpdateBank(selectedBankId, bank);
            MessageBox.Show(TxtBankName.Text + " is updated successfully.", "Message", MessageBoxButtons.OK);
        }

        private void BtnDeleteBank_Click(object sender, EventArgs e)
        {
            List<BankTransaction> bankTransactions = _bankTransactionService.GetBankTransactions(selectedBankId).ToList();
            if (bankTransactions.Count > 0)
            {
                MessageBox.Show(TxtBankName.Text + " can't be deleted. Please delete its transactions first.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                _bankService.DeleteBank(selectedBankId);
                _bankTransactionService.DeleteBankTransaction(selectedBankId);

                DialogResult result = MessageBox.Show(TxtBankName.Text + " is deleted successfully.", "Message", MessageBoxButtons.OK);
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
            var bankTransactionFilter = new BankTransactionFilter();

            if (!string.IsNullOrWhiteSpace(action))
            {
                bankTransactionFilter.Action = action.Equals(Constants.DEPOSIT) ? '1' : '0';
            }

            bankTransactionFilter.DateFrom = UtilityService.GetDate(MaskEndOfDayFrom.Text);
            bankTransactionFilter.DateTo = UtilityService.GetDate(MaskEndOfDayTo.Text);

            var bankTransactionViewList = _bankTransactionService.GetBankTransactionViews(bankTransactionFilter).ToList();
            TxtAmount.Text = bankTransactionViewList.Sum(x => x.Balance).ToString();
            LoadBankTransaction(bankTransactionViewList);
        }
        #endregion

        #region Combo Box Event
        private void ComboDepositType_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboActionType.Focus();
        }

        private void ComboActionType_SelectedValueChanged(object sender, EventArgs e)
        {
            RichAmount.Focus();
        }
        #endregion

        #region Data Grid Event
        private void DataGridBankDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridBankList.Columns["Id"].Visible = false;

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
                TxtBankName.Text = bankDetail.Name;
                TxtAccountNo.Text = bankDetail.AccountNo;
                var bankBalance = _bankTransactionService.GetTotalBalance(new BankTransactionFilter() { BankId = selectedBankId });
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
                TxtBankName.Enabled = option;
                TxtAccountNo.Enabled = option;
            }
            else if (action == Action.Edit)
            {
                TxtBankName.Enabled = option;
                TxtAccountNo.Enabled = option;
                ComboActionType.Enabled = option;
                RichAmount.Enabled = option;
                TxtBalance.Enabled = option;
                ComboDepositType.Enabled = option;
            }
            else if (action == Action.Save)
            {
                ComboActionType.Enabled = option;
                RichAmount.Enabled = option;
                ComboDepositType.Enabled = option;
            }
            else if (action == Action.Populate)
            {
                ComboActionType.Enabled = option;
                RichAmount.Enabled = option;
                ComboDepositType.Enabled = option;
            }
            else
            {
                TxtBankName.Enabled = option;
                TxtAccountNo.Enabled = option;
                ComboActionType.Enabled = option;
                RichAmount.Enabled = option;
                TxtBalance.Enabled = option;
                ComboDepositType.Enabled = option;
            }
        }

        private void ClearAllFields()
        {
            TxtBankName.Clear();
            TxtAccountNo.Clear();
            ComboActionType.Text = string.Empty;
            RichAmount.Clear();
            TxtBalance.Clear();
            ComboDepositType.Text = string.Empty;
        }

        private void LoadDepositTypes()
        {
            ComboDepositType.Items.Clear();
            ComboDepositType.ValueMember = "Id";
            ComboDepositType.DisplayMember = "Value";

            ComboDepositType.Items.Add(new ComboBoxItem { Id = Constants.OWNER_EQUITY, Value = Constants.OWNER_EQUITY });
        }

        private void LoadActionTypes()
        {
            ComboActionType.Items.Clear();
            ComboActionType.ValueMember = "Id";
            ComboActionType.DisplayMember = "Value";

            ComboActionType.Items.Add(new ComboBoxItem { Id = Constants.DEPOSIT, Value = Constants.DEPOSIT });
            ComboActionType.Items.Add(new ComboBoxItem { Id = Constants.WITHDRAWL, Value = Constants.WITHDRAWL });
        }
        #endregion
    }
}
