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
        private readonly ISettingService _settingService;
        private readonly ICompanyInfoService _companyInfoService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IMemberService _memberService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IEmployeeService _employeeService;
        private readonly IReportService _reportService;

        private readonly string _username;
        private readonly Setting _setting;
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
            Load,
            PopulateMember,
            None
        }
        #endregion 

        #region Constructor
        public MemberForm(string username,
            ISettingService settingService, ICompanyInfoService companyInfoService,
            IBankService bankService, IBankTransactionService bankTransactionService, 
            IMemberService memberService, ISoldItemService soldItemService, 
            IUserTransactionService userTransactionService, IEmployeeService employeeService,
            IReportService reportService, DashboardForm dashboardForm)
        {
            InitializeComponent();

            _settingService = settingService;
            _companyInfoService = companyInfoService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _memberService = memberService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _employeeService = employeeService;
            _reportService = reportService;
            _dashboard = dashboardForm;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Load Event
        private void MemberForm_Load(object sender, System.EventArgs e)
        {
            MaskEndOfDayFrom.Text = _endOfDay;
            MaskEndOfDayTo.Text = _endOfDay;
            ClearAllFields();
            LoadReceiptTypes();
            EnableFields(Action.None);
            EnableFields(Action.Load);
            var memberId = TxtMemberId.Text;
            var memberTransactionViewList = GetMemberTransactions(memberId);
            LoadMemberTransactions(memberTransactionViewList);
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
        }
        #endregion

        #region Button Event
        private void BtnSearchMember_Click(object sender, EventArgs e)
        {
            MemberListForm memberListForm = new MemberListForm(_memberService, _userTransactionService, this);
            memberListForm.ShowDialog();
        }

        private void BtnShowSales_Click(object sender, EventArgs e)
        {
            if (DataGridMemberList.SelectedRows.Count == 1)
            {
                var selectedRow = DataGridMemberList.SelectedRows[0];
                var invoiceNo = selectedRow.Cells["InvoiceNo"].Value.ToString();
                var memberId = TxtMemberId.Text;
                if (!string.IsNullOrWhiteSpace(invoiceNo) && !string.IsNullOrWhiteSpace(memberId))
                {
                    PosForm posForm = new PosForm(_companyInfoService, _memberService, 
                        _userTransactionService, _soldItemService, 
                        _employeeService, _reportService, memberId, invoiceNo);
                    posForm.Show();
                }
            }
        }

        private void BtnSaveReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(RichAmount.Text) > Convert.ToDecimal(TxtBalance.Text))
                {
                    var warningResult = MessageBox.Show("Receipt cannot be greater than balance.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (warningResult == DialogResult.OK)
                    {
                        RichAmount.Focus();
                    }
                }
                else
                {
                    var date = DateTime.Now;
                    var userTransaction = new UserTransaction
                    {
                        EndOfDay = _endOfDay,
                        MemberId = TxtMemberId.Text,
                        Action = Constants.RECEIPT,
                        ActionType = ComboReceipt.Text,
                        Bank = ComboBank.Text,
                        DueAmount = 0.00m,
                        ReceivedAmount = Convert.ToDecimal(RichAmount.Text),
                        AddedBy = _username,
                        AddedDate = date
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
                            Credit = 0.00m,
                            Narration = TxtMemberId.Text + " - " + TxtName.Text,
                            AddedBy = _username,
                            AddedDate = date
                        };

                        _bankTransactionService.AddBankTransaction(bankTransaction);
                    }

                    DialogResult result = MessageBox.Show(RichAmount.Text + " has been added successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        var memberTransactionViewList = GetMemberTransactions(TxtMemberId.Text);
                        LoadMemberTransactions(memberTransactionViewList);
                    }
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

        private void BtnAddMember_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields(Action.None);
            EnableFields(Action.Add);
            TxtMemberId.Focus();
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

                        var fileName = TxtMemberId.Text + ".jpg";
                        destinationFilePath = Path.Combine(_baseImageFolder, MEMBER_IMAGE_FOLDER, fileName);
                        File.Copy(_uploadedImagePath, destinationFilePath, true);
                    }
                }

                var date = DateTime.Now;
                var member = new Member
                {
                    MemberId = TxtMemberId.Text,
                    Name = TxtName.Text,
                    Address = TxtAddress.Text,
                    ContactNo = string.IsNullOrEmpty(TxtContactNumber.Text) ? 0 : Convert.ToInt64(TxtContactNumber.Text),
                    Email = TxtEmail.Text,
                    AccountNo = TxtAccountNumber.Text,
                    ImagePath = destinationFilePath,
                    AddedBy = _username,
                    AddedDate = date
                };

                _memberService.AddMember(member);

                DialogResult result = MessageBox.Show(member.MemberId + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    var memberTransactionViewList = GetMemberTransactions(member.MemberId);
                    LoadMemberTransactions(memberTransactionViewList);
                    EnableFields(Action.None);
                    EnableFields(Action.Save);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields(Action.None);
            EnableFields(Action.Edit);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var memberId = TxtMemberId.Text;
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

                        var fileName = TxtMemberId.Text + ".jpg";
                        destinationFilePath = Path.Combine(_baseImageFolder, MEMBER_IMAGE_FOLDER, fileName);
                        File.Copy(_uploadedImagePath, destinationFilePath, true);
                    }
                }

                var member = new Member
                {
                    MemberId = TxtMemberId.Text,
                    Name = TxtName.Text,
                    Address = TxtAddress.Text,
                    ContactNo = string.IsNullOrEmpty(TxtContactNumber.Text) ? 0 : Convert.ToInt64(TxtContactNumber.Text),
                    Email = TxtEmail.Text,
                    AccountNo = TxtAccountNumber.Text,
                    ImagePath = destinationFilePath,
                    UpdatedBy = _username,
                    UpdatedDate = DateTime.Now
                };

                _memberService.UpdateMember(memberId, member);
                DialogResult result = MessageBox.Show(memberId + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    var memberTransactionViewList = GetMemberTransactions(memberId);
                    LoadMemberTransactions(memberTransactionViewList);
                    EnableFields(Action.None);
                    EnableFields(Action.Update);
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
                    var memberId = TxtMemberId.Text;
                    var member = _memberService.GetMember(memberId);

                    if (!string.IsNullOrWhiteSpace(member.ImagePath) && File.Exists(member.ImagePath))
                    {
                        UtilityService.DeleteImage(member.ImagePath);
                    }

                    if (_memberService.DeleteMember(memberId))
                    {
                        DialogResult result = MessageBox.Show(memberId + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ClearAllFields();
                            var memberTransactionViewList = GetMemberTransactions(memberId);
                            LoadMemberTransactions(memberTransactionViewList);
                            EnableFields(Action.None);
                            EnableFields(Action.Delete);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnShowTransaction_Click(object sender, EventArgs e)
        {
            var filter = new MemberFilter();
            var dateFrom = UtilityService.GetDate(MaskEndOfDayFrom.Text);
            var dateTo = UtilityService.GetDate(MaskEndOfDayTo.Text);
            var action = ComboAction.Text;

            filter.Action = action;
            var memberTransactionViewList = GetMemberTransactions(filter);
            TxtAmount.Text = memberTransactionViewList.Sum(x => (x.DueAmount - x.ReceivedAmount)).ToString();
            LoadMemberTransactions(memberTransactionViewList);
        }
        #endregion

        #region RichTextBox Events
        private void RichMemberId_KeyUp(object sender, KeyEventArgs e)
        {
            var member = _memberService.GetMember(TxtMemberId.Text);
            if (member?.MemberId?.ToLower() == TxtMemberId.Text.ToLower())
            {
                DialogResult result = MessageBox.Show(TxtMemberId.Text + " already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    TxtMemberId.Clear();
                    return;
                }
            }
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
                        ComboBank.Items.Clear();
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

        private void ComboBank_SelectedValueChanged(object sender, EventArgs e)
        {
            RichAmount.Focus();
        }
        #endregion

        #region Data Grid Event
        private void DataGridMemberTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridMemberList.Columns["Id"].Visible = false;

            DataGridMemberList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridMemberList.Columns["EndOfDay"].Width = 90;
            DataGridMemberList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridMemberList.Columns["Action"].HeaderText = "Description";
            DataGridMemberList.Columns["Action"].Width = 120;
            DataGridMemberList.Columns["Action"].DisplayIndex = 1;

            DataGridMemberList.Columns["ActionType"].HeaderText = "Type";
            DataGridMemberList.Columns["ActionType"].Width = 200;
            DataGridMemberList.Columns["ActionType"].DisplayIndex = 2;

            DataGridMemberList.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridMemberList.Columns["InvoiceNo"].Width = 100;
            DataGridMemberList.Columns["InvoiceNo"].DisplayIndex = 3;

            DataGridMemberList.Columns["DueAmount"].HeaderText = "Debit";
            DataGridMemberList.Columns["DueAmount"].Width = 100;
            DataGridMemberList.Columns["DueAmount"].DisplayIndex = 4;
            DataGridMemberList.Columns["DueAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridMemberList.Columns["ReceivedAmount"].HeaderText = "Credit";
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
        private List<MemberTransactionView> GetMemberTransactions(string memberId)
        {
            var memberTransactions = _userTransactionService.GetMemberTransactions(memberId).ToList();

            decimal balance = 0.00M;
            var memberTransactionViews = memberTransactions
                           .OrderBy(x => x.Id)
                           .Select(x =>
                           {
                               balance += (x.DueAmount - x.ReceivedAmount);
                               return new MemberTransactionView
                               {
                                   Id = x.Id,
                                   EndOfDay = x.EndOfDay,
                                   Action = x.Action,
                                   ActionType = x.ActionType,
                                   InvoiceNo = x.InvoiceNo,
                                   DueAmount = x.DueAmount,
                                   ReceivedAmount = x.ReceivedAmount,
                                   Balance = balance
                               };
                           }
             ).ToList();

            return memberTransactionViews;
        }

        private List<MemberTransactionView> GetMemberTransactions(MemberFilter memberFilter)
        {
            var memberTransactions = _userTransactionService.GetMemberTransactions(memberFilter).ToList();

            decimal balance = 0.00M;
            var memberTransactionViews = memberTransactions
                           .OrderBy(x => x.Id)
                           .Select(x =>
                           {
                               balance += (x.DueAmount - x.ReceivedAmount);
                               return new MemberTransactionView
                               {
                                   Id = x.Id,
                                   EndOfDay = x.EndOfDay,
                                   Action = x.Action,
                                   ActionType = x.ActionType,
                                   InvoiceNo = x.InvoiceNo,
                                   DueAmount = x.DueAmount,
                                   ReceivedAmount = x.ReceivedAmount,
                                   Balance = balance
                               };
                           }
             ).ToList();

            return memberTransactionViews;
        }

        private void LoadMemberTransactions(List<MemberTransactionView> memberTransactionViewList)
        {
            TxtBalance.Text = memberTransactionViewList.Sum(x => (x.DueAmount - x.ReceivedAmount)).ToString();
            TxtBalanceStatus.Text = Convert.ToDecimal(TxtBalance.Text) <= 0.00m ? Constants.CLEAR : Constants.DUE;

            var bindingList = new BindingList<MemberTransactionView>(memberTransactionViewList);
            var source = new BindingSource(bindingList, null);
            DataGridMemberList.DataSource = source;
        }

        private void EnableFields(Action action)
        {
            if(action == Action.Add)
            {
                TxtMemberId.Enabled = true;
                TxtAccountNumber.Enabled = true;
                TxtName.Enabled = true;
                TxtAddress.Enabled = true;
                TxtEmail.Enabled = true;
                TxtContactNumber.Enabled = true;

                BtnSave.Enabled = true;
            }
            else if (action == Action.Save)
            {
                BtnAddMember.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                TxtAccountNumber.Enabled = true;
                TxtName.Enabled = true;
                TxtAddress.Enabled = true;
                TxtEmail.Enabled = true;
                TxtContactNumber.Enabled = true;

                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == Action.Update)
            {
                BtnAddMember.Enabled = true;
            }
            else if (action == Action.Delete)
            {
                BtnAddMember.Enabled = true;
            }
            else if (action == Action.Load)
            {
                BtnAddMember.Enabled = true;
            }
            else if(action == Action.PopulateMember)
            {
                BtnAddMember.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else
            {
                TxtMemberId.Enabled = false;
                TxtAccountNumber.Enabled = false;
                TxtName.Enabled = false;
                TxtAddress.Enabled = false;
                TxtEmail.Enabled = false;
                TxtContactNumber.Enabled = false;

                BtnAddMember.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            TxtMemberId.Clear();
            TxtAccountNumber.Clear();
            TxtName.Clear();
            TxtAddress.Clear();
            TxtContactNumber.Clear();
            TxtEmail.Clear();
            TxtBalance.Clear();
            ComboReceipt.Text = string.Empty;
            ComboBank.Text = string.Empty;
            RichAmount.Clear();
            PicBoxMemberImage.Image = null;
        }

        public void PopulateMember(string memberId)
        {
            var member = _memberService.GetMember(memberId);

            TxtMemberId.Text = member.MemberId;
            TxtName.Text = member.Name;
            TxtAddress.Text = member.Address;
            TxtContactNumber.Text = member.ContactNo.ToString();
            TxtEmail.Text = member.Email;
            TxtAccountNumber.Text = member.AccountNo;

            if (File.Exists(member.ImagePath))
            {
                PicBoxMemberImage.ImageLocation = member.ImagePath;
            }
            else
            {
                PicBoxMemberImage.Image = null;
            }

            ComboReceipt.Enabled = true;

            EnableFields(Action.None);
            EnableFields(Action.PopulateMember);
            var memberTransactionViewList = GetMemberTransactions(memberId);
            LoadMemberTransactions(memberTransactionViewList);
        }

        private void LoadReceiptTypes()
        {
            ComboReceipt.Items.Clear();
            ComboReceipt.ValueMember = "Id";
            ComboReceipt.DisplayMember = "Value";

            ComboReceipt.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboReceipt.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
        }

        #endregion
    }
}
