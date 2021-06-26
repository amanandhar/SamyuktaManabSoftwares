using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class BankForm : Form, IBankListForm
    {
        private readonly IBankDetailService _bankDetailService;
        private readonly IBankTransactionService _bankTransactionService;
        private long selectedBankId = 0;

        private enum Action {
            Add,
            Save,
            Edit,
            Update,
            Delete,
            Populate,
            None
        }

        public BankForm(IBankDetailService bankDetailService, IBankTransactionService bankTransactionService)
        {
            InitializeComponent();

            _bankDetailService = bankDetailService;
            _bankTransactionService = bankTransactionService;
        }

        private void BankForm_Load(object sender, EventArgs e)
        {

        }

        #region Button Click Events
        private void BtnAddBank_Click(object sender, EventArgs e)
        {
            EnableFields(Action.Add, true);
            RichBankName.Focus();
        }

        private void BtnSaveBank_Click(object sender, EventArgs e)
        { 
            try 
            {
                var bankDetail = new BankDetail
                {
                    Name = RichBankName.Text,
                    AccountNo = RichAccountNo.Text,
                    Date = DateTime.Now
                };

                _bankDetailService.AddBankDetail(bankDetail);

                DialogResult result = MessageBox.Show(bankDetail.Name + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields(Action.None, false);
                }
            }
            catch(Exception ex)
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
            var bankDetail = new BankDetail
            {
                Name = RichBankName.Text,
                AccountNo = RichAccountNo.Text
            };

            _bankDetailService.UpdateBankDetail(selectedBankId, bankDetail);

            MessageBox.Show(RichBankName.Text + " is updated successfully.", "Message", MessageBoxButtons.OK);
        }

        private void BtnDeleteTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridBankDetails.SelectedRows.Count == 1)
                {
                    var bankTransactionId = Convert.ToInt64(DataGridBankDetails.SelectedCells[0].Value.ToString());

                    _bankTransactionService.DeleteBankTransaction(bankTransactionId);

                    var bankBalance = _bankTransactionService.GetBankBalance(selectedBankId);
                    TxtBalance.Text = bankBalance.ToString();

                    LoadBankTransaction();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnShowBank_Click(object sender, EventArgs e)
        {
            BankListForm bankListForm = new BankListForm(_bankDetailService, this);
            bankListForm.Show();
        }
        #endregion

        #region Helper Methods
        public void PopulateBank(long bankId)
        {
            try
            {
                selectedBankId = bankId;
                var bankDetail = _bankDetailService.GetBankDetail(bankId);
                RichBankName.Text = bankDetail.Name;
                RichAccountNo.Text = bankDetail.AccountNo;

                var bankBalance = _bankTransactionService.GetBankBalance(bankId);
                TxtBalance.Text = bankBalance.ToString();

                EnableFields(Action.Populate, true);
                ComboAction.Focus();

                LoadBankTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EnableFields(Action action, bool option = true)
        {
            if(action == Action.Add)
            {
                RichBankName.Enabled = option;
                RichAccountNo.Enabled = option;
            }
            else if (action == Action.Edit)
            {
                RichBankName.Enabled = option;
                RichAccountNo.Enabled = option;
                ComboAction.Enabled = option;
                RichAmount.Enabled = option;
                TxtBalance.Enabled = option;
                RichNarration.Enabled = option;
            }
            else if (action == Action.Save)
            {
                ComboAction.Enabled = option;
                RichAmount.Enabled = option;
                RichNarration.Enabled = option;
            }
            else if(action == Action.Populate)
            {
                ComboAction.Enabled = option;
                RichAmount.Enabled = option;
                RichNarration.Enabled = option;
            }
            else
            {
                RichBankName.Enabled = option;
                RichAccountNo.Enabled = option;
                ComboAction.Enabled = option;
                RichAmount.Enabled = option;
                TxtBalance.Enabled = option;
                RichNarration.Enabled = option;
            }
        }

        private void ClearAllFields()
        {
            RichBankName.Text = string.Empty;
            RichAccountNo.Text = string.Empty;
            ComboAction.Text = string.Empty;
            RichAmount.Text = string.Empty;
            TxtBalance.Text = string.Empty;
            RichNarration.Text = string.Empty;
        }

        private void LoadBankTransaction()
        {
            List<BankTransactionView> bankTransactionViews = _bankTransactionService.GetBankTransactionViews(selectedBankId).ToList();

            var bindingList = new BindingList<BankTransactionView>(bankTransactionViews);
            var source = new BindingSource(bindingList, null);
            DataGridBankDetails.DataSource = source;
        }

        #endregion

        #region Data Grid Events 
        private void DataGridBankDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridBankDetails.Columns["Id"].Visible = false;

            DataGridBankDetails.Columns["Date"].HeaderText = "Date";
            DataGridBankDetails.Columns["Date"].Width = 100;
            DataGridBankDetails.Columns["Date"].DisplayIndex = 0;
            DataGridBankDetails.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";

            DataGridBankDetails.Columns["Description"].HeaderText = "Descriptions";
            DataGridBankDetails.Columns["Description"].Width = 100;
            DataGridBankDetails.Columns["Description"].DisplayIndex = 1;

            DataGridBankDetails.Columns["Narration"].HeaderText = "Narration";
            DataGridBankDetails.Columns["Narration"].Width = 200;
            DataGridBankDetails.Columns["Narration"].DisplayIndex = 2;

            DataGridBankDetails.Columns["Debit"].HeaderText = "Debit";
            DataGridBankDetails.Columns["Debit"].Width = 100;
            DataGridBankDetails.Columns["Debit"].DisplayIndex = 3;

            DataGridBankDetails.Columns["Credit"].HeaderText = "Credit";
            DataGridBankDetails.Columns["Credit"].Width = 100;
            DataGridBankDetails.Columns["Credit"].DisplayIndex = 4;

            DataGridBankDetails.Columns["Balance"].HeaderText = "Balance";
            DataGridBankDetails.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridBankDetails.Columns["Balance"].DisplayIndex = 5;

            foreach (DataGridViewRow row in DataGridBankDetails.Rows)
            {
                DataGridBankDetails.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridBankDetails.RowHeadersWidth = 50;
            }
        }

        #endregion

        private void BtnSaveTransaction_Click(object sender, EventArgs e)
        {
            var bankTransaction = new BankTransaction
            {
                BankId = selectedBankId,
                Action = ComboAction.Text.ToLower() == "deposit" ? '1' : '0',
                Debit = ComboAction.Text.ToLower() == "deposit" ? Convert.ToDecimal(RichAmount.Text) : 0.0m,
                Credit = ComboAction.Text.ToLower() == "deposit" ? 0.0m : Convert.ToDecimal(RichAmount.Text),
                Narration = RichNarration.Text,
                Date = DateTime.Now
            };

            _bankTransactionService.AddBankTransaction(bankTransaction);

            DialogResult result = MessageBox.Show(ComboAction.Text + " has been added successfully.", "Message", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                var bankBalance = _bankTransactionService.GetBankBalance(selectedBankId);
                TxtBalance.Text = bankBalance.ToString();

                ComboAction.Text = string.Empty;
                RichAmount.Clear();
                RichNarration.Clear();

                EnableFields(Action.Save, true);
                LoadBankTransaction();
            }
        }

        private void BtnDeleteBank_Click(object sender, EventArgs e)
        {
            List<BankTransaction> bankTransactions = _bankTransactionService.GetBankTransactions(selectedBankId).ToList();
            if(bankTransactions.Count > 0)
            {
                MessageBox.Show(RichBankName.Text + " can't be deleted. Please delete its transactions first.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                _bankDetailService.DeleteBankDetail(selectedBankId);
                _bankTransactionService.DeleteBankTransaction(selectedBankId);

                DialogResult result = MessageBox.Show(RichBankName.Text + " is deleted successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields(Action.None, false);
                    LoadBankTransaction();
                }
            }
        }
    }
}
