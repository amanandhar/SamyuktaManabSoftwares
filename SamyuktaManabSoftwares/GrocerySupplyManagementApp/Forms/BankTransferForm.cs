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
        private readonly ISettingService _settingService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly ICapitalService _capitalService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;
        private List<Bank> _banks = new List<Bank>();

        #region Constructor
        public BankTransferForm(string username,
            ISettingService settingService, IBankService bankService, 
            IBankTransactionService bankTransactionService, IUserTransactionService userTransactionService,
            ICapitalService capitalService)
        {
            InitializeComponent();

            _settingService = settingService;
            _bankService = bankService;
            _userTransactionService = userTransactionService;
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
                throw ex;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
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
                        var userTransaction = new UserTransaction
                        {
                            EndOfDay = _endOfDay,
                            Action = Constants.BANK_TRANSFER,
                            ActionType = Constants.CASH,
                            Bank = ComboBank.Text,
                            PaymentAmount = Convert.ToDecimal(RichDepositAmount.Text),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };
                        _userTransactionService.AddUserTransaction(userTransaction);

                        var lastUserTransaction = _userTransactionService.GetLastUserTransaction(string.Empty);

                        ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                        var bankTransaction = new BankTransaction
                        {
                            EndOfDay = _endOfDay,
                            BankId = Convert.ToInt64(selectedItem.Id),
                            TransactionId = lastUserTransaction.Id,
                            Action = '1',
                            Debit = Convert.ToDecimal(RichDepositAmount.Text),
                            Credit = Constants.DEFAULT_DECIMAL_VALUE,
                            Narration = RichNarration.Text,
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };
                        _bankTransactionService.AddBankTransaction(bankTransaction);

                        DialogResult result = MessageBox.Show(RichDepositAmount.Text + " has been added successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                throw ex;
            }
        }
        #endregion

        #region Combo Event
        private void ComboBank_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedBank = ComboBank.Text;
            if(!string.IsNullOrWhiteSpace(selectedBank))
            {
                var accountNo = _banks.Where(x => x.Name == selectedBank).Select(x => x.AccountNo).FirstOrDefault();
                TxtAccountNo.Text = accountNo;
            }
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

                TxtCash.Text = _capitalService.GetCashInHand(new UserTransactionFilter()).ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void ClearAllFields()
        {
            try
            {
                ComboBank.Text = string.Empty;
                TxtCash.Text = _capitalService.GetCashInHand(new UserTransactionFilter()).ToString();
                TxtAccountNo.Clear();
                RichDepositAmount.Clear();
                RichNarration.Clear();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
