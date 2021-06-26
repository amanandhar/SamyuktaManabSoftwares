using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class BankTransferForm : Form
    {
        private readonly IBankDetailService _bankDetailService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IPosInvoiceService _posInvoiceService;
        private List<BankDetail> _bankDetails = new List<BankDetail>();

        #region Constructor
        public BankTransferForm(IBankDetailService bankDetailService, IBankTransactionService bankTransactionService, IPosInvoiceService posInvoiceService)
        {
            InitializeComponent();

            _bankDetailService = bankDetailService;
            _posInvoiceService = posInvoiceService;
            _bankTransactionService = bankTransactionService;
        }
        #endregion

        #region Load Event
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
                ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                var bankTransaction = new BankTransaction
                {
                    BankId = Convert.ToInt64(selectedItem.Id),
                    Action = '0',
                    Debit = 0.0m,
                    Credit = Convert.ToDecimal(RichDepositAmount.Text),
                    Narration = RichNarration.Text,
                    Date = DateTime.Now
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
                var accountNo = _bankDetails.Where(x => x.Name == selectedBank).Select(x => x.AccountNo).FirstOrDefault();
                TxtAccountNo.Text = accountNo;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadBankDetails()
        {
            try
            {
                _bankDetails = _bankDetailService.GetBankDetails().ToList();

                ComboBank.ValueMember = "Id";
                ComboBank.DisplayMember = "Value";

                _bankDetails.OrderBy(x => x.Name).ToList().ForEach(x =>
                {
                    ComboBank.Items.Add(new ComboBoxItem { Id = x.Id.ToString(), Value = x.Name });
                });

                TxtCash.Text = _posInvoiceService.GetCashInHand().ToString();
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
                TxtCash.Text = _posInvoiceService.GetCashInHand().ToString();
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
