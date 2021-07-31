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
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;
        private List<Bank> _banks = new List<Bank>();

        #region Constructor
        public BankTransferForm(IFiscalYearService fiscalYearService, IBankService bankService, 
            IBankTransactionService bankTransactionService, IUserTransactionService userTransactionService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankService = bankService;
            _userTransactionService = userTransactionService;
            _bankTransactionService = bankTransactionService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }
        #endregion

        #region Form Load Event
        private void BankTransferForm_Load(object sender, EventArgs e)
        {
            LoadBankDetails();
        }
        #endregion

        #region Button Click Event
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var date = DateTime.Now;
                var userTransaction = new UserTransaction
                {
                    EndOfDay = _endOfDay,
                    Action = Constants.TRANSFER,
                    ActionType = Constants.CASH,
                    Bank = ComboBank.Text,
                    SubTotal = 0.0m,
                    DiscountPercent = 0.0m,
                    Discount = 0.0m,
                    VatPercent = 0.0m,
                    Vat = 0.0m,
                    DeliveryChargePercent = 0.0m,
                    DeliveryCharge = 0.0m,
                    DueAmount = Convert.ToDecimal(RichDepositAmount.Text),
                    ReceivedAmount = 0.0m,
                    AddedDate = date,
                    UpdatedDate = date
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
                    Credit = 0.0m,
                    Narration = RichNarration.Text,
                    AddedDate = date,
                    UpdatedDate = date
                };
                _bankTransactionService.AddBankTransaction(bankTransaction);
                
                DialogResult result = MessageBox.Show(RichDepositAmount.Text + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAllFields();
            }
            catch(Exception ex)
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
                _banks = _bankService.GetBanks().ToList();

                ComboBank.ValueMember = "Id";
                ComboBank.DisplayMember = "Value";

                _banks.OrderBy(x => x.Name).ToList().ForEach(x =>
                {
                    ComboBank.Items.Add(new ComboBoxItem { Id = x.Id.ToString(), Value = x.Name });
                });

                TxtCash.Text = _userTransactionService.GetCashInHand().ToString();
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
                TxtCash.Text = _userTransactionService.GetCashInHand().ToString();
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
