using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class MemberForm : Form, IMemberListForm
    {
        private readonly IMemberService _memberService;
        private readonly IPosTransactionService _posTransactionService;
        private readonly IPosSoldItemService _posSoldItemService;
        private readonly IBankDetailService _bankDetailService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        public DashboardForm _dashboard;

        public MemberForm(IMemberService memberService, IPosTransactionService posTransactionService, 
            IPosSoldItemService posSoldItemService, IBankDetailService bankDetailService, 
            IBankTransactionService bankTransactionService, IFiscalYearDetailService fiscalYearDetailService,
            DashboardForm dashboardForm)
        {
            InitializeComponent();

            _memberService = memberService;
            _posTransactionService = posTransactionService;
            _posSoldItemService = posSoldItemService;
            _bankDetailService = bankDetailService;
            _bankTransactionService = bankTransactionService;
            _fiscalYearDetailService = fiscalYearDetailService;
            _dashboard = dashboardForm;
        }

        #region Load Event
        private void MemberForm_Load(object sender, System.EventArgs e)
        {
            ClearAllFields();
            EnableFields(false);
            LoadMemberTransactions();
        }
        #endregion

        #region Button Events
        private void BtnShowMember_Click(object sender, EventArgs e)
        {
            MemberListForm memberListForm = new MemberListForm(_memberService, _posTransactionService, this);
            memberListForm.Show();
        }

        private void BtnAddMember_Click(object sender, System.EventArgs e)
        {
            ClearAllFields();
            EnableFields(true);
            var memberId = _memberService.GetNewMemberId();
            RichMemberId.Text = memberId;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = _memberService.AddMember(new Member
                {
                    MemberId = RichMemberId.Text,
                    Name = RichName.Text,
                    Address = RichAddress.Text,
                    ContactNumber = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text,
                    AccountNumber = RichAccountNumber.Text
                }); ;

                DialogResult result = MessageBox.Show(member.MemberId + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    LoadMemberTransactions();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields(true);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var memberId = RichMemberId.Text;
            try
            {
                var member = _memberService.UpdateMember(memberId, new Member
                {
                    MemberId = RichMemberId.Text,
                    Name = RichName.Text,
                    Address = RichAddress.Text,
                    ContactNumber = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text,
                    AccountNumber = RichAccountNumber.Text
                }); ;

                DialogResult result = MessageBox.Show(memberId + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    LoadMemberTransactions();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var memberId = RichMemberId.Text;
            _memberService.DeleteMember(memberId);

            DialogResult result = MessageBox.Show(memberId + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                ClearAllFields();
                LoadMemberTransactions();
            }
        }

        private void BtnClearAll_Click(object sender, System.EventArgs e)
        {
            ClearAllFields();
        }

        private void BtnShowSales_Click(object sender, EventArgs e)
        {

            if (DataGridMemberTransactionList.SelectedRows.Count == 1)
            {
                var invoiceNo = DataGridMemberTransactionList.SelectedCells[4].Value.ToString();
                PosForm posForm = new PosForm(_memberService, _posTransactionService, _posSoldItemService, invoiceNo);
                posForm.Show();
            }
        }

        private void BtnPaymentSave_Click(object sender, EventArgs e)
        {
            try
            {
                var fiscalYearDetail = _fiscalYearDetailService.GetFiscalYearDetail();
                var posTransaction = new PosTransaction
                {
                    InvoiceDate = fiscalYearDetail.StartingDate,
                    MemberId = RichMemberId.Text,
                    Action = Constants.RECEIPT,
                    ActionType = ComboReceipt.Text,
                    Bank = ComboBank.Text,
                    SubTotal = 0.0m,
                    DiscountPercent = 0.0m,
                    Discount = 0.0m,
                    VatPercent = 0.0m,
                    Vat = 0.0m,
                    DeliveryChargePercent = 0.0m,
                    DeliveryCharge = 0.0m,
                    TotalAmount = 0.0m,
                    ReceivedAmount = Convert.ToDecimal(RichAmount.Text),
                    Date = DateTime.Now
                };
                _posTransactionService.AddPosTransaction(posTransaction);

                if (ComboReceipt.Text.ToLower() == Constants.CHEQUE.ToLower())
                {
                    var lastPosTransaction = _posTransactionService.GetLastPosTransaction(string.Empty);

                    ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                    var bankTransaction = new BankTransaction
                    {
                        BankId = Convert.ToInt64(selectedItem.Id),
                        TransactionId = lastPosTransaction.Id,
                        Action = '1',
                        Debit = Convert.ToDecimal(RichAmount.Text),
                        Credit = 0.0m,
                        Narration = RichMemberId.Text + " - " + RichName.Text,
                        Date = DateTime.Now
                    };

                    _bankTransactionService.AddBankTransaction(bankTransaction);
                }
                    
                DialogResult result = MessageBox.Show(RichAmount.Text + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    LoadMemberTransactions();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Data Grid Event
        private void DataGridMemberTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridMemberTransactionList.Columns["Id"].Visible = false;

            DataGridMemberTransactionList.Columns["InvoiceDate"].HeaderText = "Date";
            DataGridMemberTransactionList.Columns["InvoiceDate"].Width = 100;
            DataGridMemberTransactionList.Columns["InvoiceDate"].DisplayIndex = 1;

            DataGridMemberTransactionList.Columns["Action"].HeaderText = "Particulars";
            DataGridMemberTransactionList.Columns["Action"].Width = 100;
            DataGridMemberTransactionList.Columns["Action"].DisplayIndex = 2;

            DataGridMemberTransactionList.Columns["ActionType"].HeaderText = "Type";
            DataGridMemberTransactionList.Columns["ActionType"].Width = 200;
            DataGridMemberTransactionList.Columns["ActionType"].DisplayIndex = 3;

            DataGridMemberTransactionList.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridMemberTransactionList.Columns["InvoiceNo"].Width = 100;
            DataGridMemberTransactionList.Columns["InvoiceNo"].DisplayIndex = 4;

            DataGridMemberTransactionList.Columns["TotalAmount"].HeaderText = "Credit";
            DataGridMemberTransactionList.Columns["TotalAmount"].Width = 100;
            DataGridMemberTransactionList.Columns["TotalAmount"].DisplayIndex = 5;

            DataGridMemberTransactionList.Columns["ReceivedAmount"].HeaderText = "Debit";
            DataGridMemberTransactionList.Columns["ReceivedAmount"].Width = 100;
            DataGridMemberTransactionList.Columns["ReceivedAmount"].DisplayIndex = 6;

            DataGridMemberTransactionList.Columns["Balance"].HeaderText = "Balance";
            DataGridMemberTransactionList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridMemberTransactionList.Columns["Balance"].DisplayIndex = 7;

            foreach (DataGridViewRow row in DataGridMemberTransactionList.Rows)
            {
                DataGridMemberTransactionList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridMemberTransactionList.RowHeadersWidth = 50;
            }
        }
        #endregion

        #region Helper Methods
        private void EnableFields(bool option = true)
        {
            RichMemberId.Enabled = option;
            RichName.Enabled = option;
            RichAddress.Enabled = option;
            RichContactNumber.Enabled = option;
            RichEmail.Enabled = option;
            RichAccountNumber.Enabled = option;
        }

        private void ClearAllFields()
        {
            RichMemberId.Clear();
            RichAccountNumber.Clear();
            RichName.Clear();
            RichAddress.Clear();
            RichContactNumber.Clear();
            RichEmail.Clear();
            RichBalance.Clear();
            ComboReceipt.Text = string.Empty;
            ComboBank.Text = string.Empty;
            RichAmount.Clear();
        }

        private void LoadMemberTransactions()
        {
            var memberId = RichMemberId.Text;

            List<MemberTransactionView> memberTransactionViews = _posTransactionService.GetMemberTransactions(memberId).ToList();

            RichBalance.Text = _posTransactionService.GetMemberTotalBalance(memberId).ToString();
            TxtBalanceStatus.Text = Convert.ToDecimal(RichBalance.Text) <= 0.0m ? Constants.CLEAR : Constants.DUE;

            var bindingList = new BindingList<MemberTransactionView>(memberTransactionViews);
            var source = new BindingSource(bindingList, null);
            DataGridMemberTransactionList.DataSource = source;
        }

        public void PopulateMember(string memberId)
        {
            var member = _memberService.GetMember(memberId);

            RichMemberId.Text = member.MemberId;
            RichName.Text = member.Name;
            RichAddress.Text = member.Address;
            RichContactNumber.Text = member.ContactNumber.ToString();
            RichEmail.Text = member.Email;
            RichAccountNumber.Text = member.AccountNumber;

            ComboReceipt.Enabled = true;

            EnableFields(false);

            LoadMemberTransactions();
        }

        #endregion

        #region Combobox Event
        private void ComboPayment_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedPayment = ComboReceipt.Text;
            if(!string.IsNullOrWhiteSpace(selectedPayment))
            {
                if(selectedPayment.ToLower() == Constants.CHEQUE.ToLower())
                {
                    ComboBank.Enabled = true;
                    ComboBank.Focus();
                    RichAmount.Enabled = true;

                    var bankDetails = _bankDetailService.GetBankDetails().ToList();
                    if(bankDetails.Count > 0)
                    {
                        ComboBank.ValueMember = "Id";
                        ComboBank.DisplayMember = "Value";

                        bankDetails.OrderBy(x => x.Name).ToList().ForEach(x =>
                        {
                            ComboBank.Items.Add(new ComboBoxItem { Id = x.Id.ToString(), Value = x.Name });
                        });
                    }
                }
                else
                {
                    ComboBank.Text = string.Empty;
                    ComboBank.Enabled = false;
                    RichAmount.Enabled = true;
                    RichAmount.Focus();
                }
            }
        }
        #endregion
    }
}
