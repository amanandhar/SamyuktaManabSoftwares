using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class BankTransferForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly ICapitalService _capitalService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;
        private List<Bank> _banks = new List<Bank>();

        #region Constructor
        public BankTransferForm(string username,
            ISettingService settingService, IBankService bankService,
            IBankTransactionService bankTransactionService, ICapitalService capitalService)
        {
            InitializeComponent();

            _settingService = settingService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _capitalService = capitalService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void BankTransferForm_Load(object sender, EventArgs e)
        {
            LoadBankDetails();
        }
        #endregion

        #region Button Click Event
        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAllFields();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                SaveBankTransfer();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateBankTransfer())
            {
                SaveBankTransfer();
            }
        }
        #endregion

        #region Rich Box Event
        private void RichDepositAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Combo Event
        private void ComboBank_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedBank = ComboBank.Text;
            if (!string.IsNullOrWhiteSpace(selectedBank))
            {
                var accountNo = _banks.Where(x => x.Name == selectedBank).Select(x => x.AccountNo).FirstOrDefault();
                TxtAccountNo.Text = accountNo;
                RichDepositAmount.Focus();
            }
        }

        private void ComboBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Helper Methods
        private void LoadBankDetails()
        {
            try
            {
                ComboBank.Items.Clear();
                _banks = _bankService.GetBanks().ToList();

                ComboBank.ValueMember = "Id";
                ComboBank.DisplayMember = "Value";

                _banks.OrderBy(x => x.Name).ToList().ForEach(x =>
                {
                    ComboBank.Items.Add(new ComboBoxItem { Id = x.Id.ToString(), Value = x.Name });
                });

                TxtCash.Text = _capitalService.GetCashInHand(new CapitalTransactionFilter() { DateTo = _endOfDay, ActionType = Constants.CASH }).ToString();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void ClearAllFields()
        {
            try
            {
                ComboBank.Text = string.Empty;
                TxtCash.Text = _capitalService.GetCashInHand(new CapitalTransactionFilter() { DateTo = _endOfDay, ActionType = Constants.CASH }).ToString();
                TxtAccountNo.Clear();
                RichDepositAmount.Clear();
                RichNarration.Clear();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void SaveBankTransfer()
        {
            try
            {
                if (Convert.ToDecimal(RichDepositAmount.Text) > Convert.ToDecimal(TxtCash.Text))
                {
                    var warningResult = MessageBox.Show("Deposit amount cannot be greater than cash in hand.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (warningResult == DialogResult.OK)
                    {
                        RichDepositAmount.Focus();
                    }
                }
                else
                {
                    var confirmation = MessageBox.Show("Do you want to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmation == DialogResult.Yes)
                    {
                        ComboBoxItem selectedBank = (ComboBoxItem)ComboBank.SelectedItem;

                        var bankTransaction = new BankTransaction
                        {
                            EndOfDay = _endOfDay,
                            BankId = Convert.ToInt64(selectedBank.Id),
                            Type = '1',
                            Action = Constants.BANK_TRANSFER,
                            Debit = Convert.ToDecimal(RichDepositAmount.Text.Trim()),
                            Credit = Constants.DEFAULT_DECIMAL_VALUE,
                            Narration = RichNarration.Text.Trim(),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };
                        _bankTransactionService.AddBankTransaction(bankTransaction);

                        DialogResult result = MessageBox.Show(RichDepositAmount.Text.Trim() + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            ClearAllFields();
                            Close();
                        }
                    }
                    else
                    {
                        return;
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

        #region Validation
        private bool ValidateBankTransfer()
        {
            var isValidated = false;

            var bank = ComboBank.Text.Trim();
            var cashInHand = TxtCash.Text.Trim();
            var accountNo = TxtAccountNo.Text.Trim();
            var depositAmount = RichDepositAmount.Text.Trim();

            if (string.IsNullOrWhiteSpace(bank)
                || string.IsNullOrWhiteSpace(cashInHand)
                || string.IsNullOrWhiteSpace(accountNo)
                || string.IsNullOrWhiteSpace(depositAmount))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Bank " +
                    "\n * Cash In Hand " +
                    "\n * Account Number " +
                    "\n * Deposit Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
