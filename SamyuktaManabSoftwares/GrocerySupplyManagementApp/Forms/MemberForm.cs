using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class MemberForm : Form, IMemberListForm
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IMemberService _memberService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;
        public DashboardForm _dashboard;
        private string _baseImageFolder;
        private const string MEMBER_IMAGE_FOLDER = "Members";
        private string _uploadedImagePath = string.Empty;

        #region Enum
        private enum Action
        {
            Add,
            Save,
            Edit,
            Update,
            Delete,
            PopulateMember,
            None
        }
        #endregion 

        #region Constructor
        public MemberForm(IFiscalYearService fiscalYearService,
            IBankService bankService, IBankTransactionService bankTransactionService, 
            IMemberService memberService,  
            ISoldItemService soldItemService, IUserTransactionService userTransactionService,
            DashboardForm dashboardForm)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _memberService = memberService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _dashboard = dashboardForm;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }
        #endregion

        #region Load Event
        private void MemberForm_Load(object sender, System.EventArgs e)
        {
            ClearAllFields();
            EnableFields(false);
            LoadMemberTransactions();
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
        }
        #endregion

        #region Button Event
        private void BtnShowMember_Click(object sender, EventArgs e)
        {
            MemberListForm memberListForm = new MemberListForm(_memberService, _userTransactionService, this);
            memberListForm.Show();
        }

        private void BtnAddMember_Click(object sender, System.EventArgs e)
        {
            ClearAllFields();
            EnableFields(true);
            RichMemberId.Text = _memberService.GetNewMemberId();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string destinationFilePath = null;
                if (!string.IsNullOrWhiteSpace(_uploadedImagePath))
                {
                    if (!Directory.Exists(_baseImageFolder))
                    {
                        DialogResult errorResult = MessageBox.Show("Base image folder is set correctly. Please check.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            return;
                        }

                        return;
                    }
                    else
                    {
                        if (!Directory.Exists(Path.Combine(_baseImageFolder, MEMBER_IMAGE_FOLDER)))
                        {
                            UtilityService.CreateFolder(_baseImageFolder, MEMBER_IMAGE_FOLDER);
                        }

                        var fileName = RichMemberId.Text + ".jpg";
                        destinationFilePath = Path.Combine(_baseImageFolder, MEMBER_IMAGE_FOLDER, fileName);
                        File.Copy(_uploadedImagePath, destinationFilePath, true);
                    }
                }

                var date = DateTime.Now;
                var member = new Member
                {
                    MemberId = RichMemberId.Text,
                    Name = RichName.Text,
                    Address = RichAddress.Text,
                    ContactNo = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text,
                    AccountNo = RichAccountNumber.Text,
                    ImagePath = destinationFilePath,
                    AddedDate = date,
                    UpdatedDate = date
                };

                _memberService.AddMember(member);

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
                string destinationFilePath = null;
                if (!string.IsNullOrWhiteSpace(_uploadedImagePath))
                {
                    if (!Directory.Exists(_baseImageFolder))
                    {
                        DialogResult errorResult = MessageBox.Show("Base image folder is set correctly. Please check.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            return;
                        }

                        return;
                    }
                    else
                    {
                        if (!Directory.Exists(Path.Combine(_baseImageFolder, MEMBER_IMAGE_FOLDER)))
                        {
                            UtilityService.CreateFolder(_baseImageFolder, MEMBER_IMAGE_FOLDER);
                        }

                        var fileName = RichMemberId.Text + ".jpg";
                        destinationFilePath = Path.Combine(_baseImageFolder, MEMBER_IMAGE_FOLDER, fileName);
                        File.Copy(_uploadedImagePath, destinationFilePath, true);
                    }
                }

                var member = new Member
                {
                    MemberId = RichMemberId.Text,
                    Name = RichName.Text,
                    Address = RichAddress.Text,
                    ContactNo = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text,
                    AccountNo = RichAccountNumber.Text,
                    ImagePath = destinationFilePath,
                    UpdatedDate = DateTime.Now
                };

                _memberService.UpdateMember(memberId, member);
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
            try
            {
                DialogResult deleteResult = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (deleteResult == DialogResult.Yes)
                {
                    var memberId = RichMemberId.Text;
                    var fileName = memberId + ".jpg";
                    var filePath = Path.Combine(_baseImageFolder, MEMBER_IMAGE_FOLDER, fileName);
                    if (UtilityService.DeleteImage(filePath))
                    {
                        if(_memberService.DeleteMember(memberId))
                        {
                            DialogResult result = MessageBox.Show(memberId + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ClearAllFields();
                                LoadMemberTransactions();
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

        private void BtnClearAll_Click(object sender, System.EventArgs e)
        {
            ClearAllFields();
        }

        private void BtnShowSales_Click(object sender, EventArgs e)
        {
            if (DataGridMemberList.SelectedRows.Count == 1)
            {
                var selectedRow = DataGridMemberList.SelectedRows[0];
                var invoiceNo = selectedRow.Cells["InvoiceNo"].Value.ToString();
                if(!string.IsNullOrWhiteSpace(invoiceNo))
                {
                    PosForm posForm = new PosForm(_memberService, _userTransactionService, _soldItemService, invoiceNo);
                    posForm.Show();
                }
            }
        }

        private void BtnPaymentSave_Click(object sender, EventArgs e)
        {
            try
            {
                var date = DateTime.Now;
                var userTransaction = new UserTransaction
                {
                    EndOfDay = _endOfDay,
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
                    DueAmount = 0.0m,
                    ReceivedAmount = Convert.ToDecimal(RichAmount.Text),
                    AddedDate = date,
                    UpdatedDate = date
                };
                _userTransactionService.AddUserTransaction(userTransaction);

                if (ComboReceipt.Text.ToLower() == Constants.CHEQUE.ToLower())
                {
                    var lastPosTransaction = _userTransactionService.GetLastUserTransaction(string.Empty);
                    ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                    var bankTransaction = new BankTransaction
                    {
                        EndOfDay = _endOfDay,
                        BankId = Convert.ToInt64(selectedItem.Id),
                        TransactionId = lastPosTransaction.Id,
                        Action = '1',
                        Debit = Convert.ToDecimal(RichAmount.Text),
                        Credit = 0.0m,
                        Narration = RichMemberId.Text + " - " + RichName.Text,
                        AddedDate = date,
                        UpdatedDate = date
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

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            OpenMemberImageDialog.InitialDirectory = _baseImageFolder;
            OpenMemberImageDialog.Filter = "All files |*.*";
            OpenMemberImageDialog.ShowDialog();
        }

        private void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            PicBoxMemberImage.Image = null;
        }

        #endregion

        #region OpenFileDialog Event
        private void OpenMemberImageDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                Activate();
                string[] files = OpenMemberImageDialog.FileNames;
                _uploadedImagePath = files[0];
                PicBoxMemberImage.Image = Image.FromFile(_uploadedImagePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Combobox Event
        private void ComboPayment_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedPayment = ComboReceipt.Text;
            if (!string.IsNullOrWhiteSpace(selectedPayment))
            {
                if (selectedPayment.ToLower() == Constants.CHEQUE.ToLower())
                {
                    ComboBank.Enabled = true;
                    ComboBank.Focus();
                    RichAmount.Enabled = true;

                    var banks = _bankService.GetBanks().ToList();
                    if (banks.Count > 0)
                    {
                        ComboBank.ValueMember = "Id";
                        ComboBank.DisplayMember = "Value";

                        banks.OrderBy(x => x.Name).ToList().ForEach(x =>
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

        #region Data Grid Event
        private void DataGridMemberTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridMemberList.Columns["Id"].Visible = false;

            DataGridMemberList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridMemberList.Columns["EndOfDay"].Width = 100;
            DataGridMemberList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridMemberList.Columns["Action"].HeaderText = "Description";
            DataGridMemberList.Columns["Action"].Width = 100;
            DataGridMemberList.Columns["Action"].DisplayIndex = 1;

            DataGridMemberList.Columns["ActionType"].HeaderText = "Type";
            DataGridMemberList.Columns["ActionType"].Width = 200;
            DataGridMemberList.Columns["ActionType"].DisplayIndex = 2;

            DataGridMemberList.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridMemberList.Columns["InvoiceNo"].Width = 100;
            DataGridMemberList.Columns["InvoiceNo"].DisplayIndex = 3;

            DataGridMemberList.Columns["DueAmount"].HeaderText = "Credit";
            DataGridMemberList.Columns["DueAmount"].Width = 100;
            DataGridMemberList.Columns["DueAmount"].DisplayIndex = 4;
            DataGridMemberList.Columns["DueAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridMemberList.Columns["ReceivedAmount"].HeaderText = "Debit";
            DataGridMemberList.Columns["ReceivedAmount"].Width = 100;
            DataGridMemberList.Columns["ReceivedAmount"].DisplayIndex = 5;
            DataGridMemberList.Columns["ReceivedAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridMemberList.Columns["Balance"].HeaderText = "Balance";
            DataGridMemberList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridMemberList.Columns["Balance"].DisplayIndex = 6;
            DataGridMemberList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridMemberList.Rows)
            {
                DataGridMemberList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridMemberList.RowHeadersWidth = 50;
                DataGridMemberList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadMemberTransactions()
        {
            var memberId = RichMemberId.Text;

            List<MemberTransactionView> memberTransactionViews = _userTransactionService.GetMemberTransactions(memberId).ToList();

            RichBalance.Text = _userTransactionService.GetMemberTotalBalance(memberId).ToString();
            TxtBalanceStatus.Text = Convert.ToDecimal(RichBalance.Text) <= 0.0m ? Constants.CLEAR : Constants.DUE;

            var bindingList = new BindingList<MemberTransactionView>(memberTransactionViews);
            var source = new BindingSource(bindingList, null);
            DataGridMemberList.DataSource = source;
        }

        private void EnableFields(bool option = true)
        {
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
            PicBoxMemberImage.Image = null;
        }

        public void PopulateMember(string memberId)
        {
            var member = _memberService.GetMember(memberId);

            RichMemberId.Text = member.MemberId;
            RichName.Text = member.Name;
            RichAddress.Text = member.Address;
            RichContactNumber.Text = member.ContactNo.ToString();
            RichEmail.Text = member.Email;
            RichAccountNumber.Text = member.AccountNo;

            if (File.Exists(member.ImagePath))
            {
                PicBoxMemberImage.ImageLocation = member.ImagePath;
            }

            ComboReceipt.Enabled = true;

            EnableFields(false);

            LoadMemberTransactions();
        }

        #endregion
    }
}
