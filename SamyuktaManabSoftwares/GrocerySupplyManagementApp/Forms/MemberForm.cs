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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly ICompanyInfoService _companyInfoService;
        private readonly IBankService _bankService;
        private readonly IMemberService _memberService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IEmployeeService _employeeService;
        private readonly IReportService _reportService;
        private readonly IPOSDetailService _posDetailService;
        private readonly ICapitalService _capitalService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;
        public DashboardForm _dashboard;
        private string _baseImageFolder;
        private string _memberImageFolder;
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
            IBankService bankService, IMemberService memberService, ISoldItemService soldItemService,
            IUserTransactionService userTransactionService, IEmployeeService employeeService,
            IReportService reportService, IPOSDetailService posDetailService,
            ICapitalService capitalService, DashboardForm dashboardForm)
        {
            InitializeComponent();

            _settingService = settingService;
            _companyInfoService = companyInfoService;
            _bankService = bankService;
            _memberService = memberService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _employeeService = employeeService;
            _reportService = reportService;
            _posDetailService = posDetailService;
            _capitalService = capitalService;
            _dashboard = dashboardForm;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Load Event
        private void MemberForm_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
            _memberImageFolder = ConfigurationManager.AppSettings[Constants.MEMBER_IMAGE_FOLDER].ToString();

            MaskEndOfDayFrom.Text = _endOfDay;
            MaskEndOfDayTo.Text = _endOfDay;
            LoadReceiptTypes();
            LoadTrasactionActions();
            EnableFields();
            EnableFields(Action.Load);
        }
        #endregion

        #region Button Event
        private void BtnSearchMember_Click(object sender, EventArgs e)
        {
            MemberListForm memberListForm = new MemberListForm(_memberService, _capitalService, this);
            memberListForm.ShowDialog();
        }

        private void BtnShowSales_Click(object sender, EventArgs e)
        {
            if (DataGridMemberList.SelectedCells.Count == 1
                || DataGridMemberList.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow;
                if (DataGridMemberList.SelectedCells.Count == 1)
                {
                    var selectedCell = DataGridMemberList.SelectedCells[0];
                    selectedRow = DataGridMemberList.Rows[selectedCell.RowIndex];
                }
                else
                {
                    selectedRow = DataGridMemberList.SelectedRows[0];
                }

                var invoiceNo = selectedRow?.Cells["InvoiceNo"]?.Value?.ToString();
                var memberId = TxtMemberId.Text;
                if (!string.IsNullOrWhiteSpace(invoiceNo) && !string.IsNullOrWhiteSpace(memberId))
                {
                    PosForm posForm = new PosForm(memberId, invoiceNo,
                        _companyInfoService, _memberService,
                        _userTransactionService, _soldItemService,
                        _employeeService, _reportService,
                        _posDetailService, _capitalService);
                    posForm.ShowDialog();
                }
            }
        }

        private void BtnSaveReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateMemberTransaction())
                {
                    if (Convert.ToDecimal(RichAmount.Text.Trim()) > Convert.ToDecimal(TxtBalance.Text.Trim()))
                    {
                        var warningResult = MessageBox.Show("Receipt cannot be greater than balance.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (warningResult == DialogResult.OK)
                        {
                            RichAmount.Focus();
                        }
                    }
                    else
                    {
                        ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                        var userTransaction = new UserTransaction
                        {
                            EndOfDay = _endOfDay,
                            Action = Constants.RECEIPT,
                            ActionType = ComboReceipt.Text.Trim(),
                            PartyId = TxtMemberId.Text.Trim(),
                            BankName = selectedItem?.Value,
                            ReceivedAmount = Convert.ToDecimal(RichAmount.Text.Trim()),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };

                        if (ComboReceipt.Text.Trim().ToLower() == Constants.CHEQUE.ToLower())
                        {
                            var bankTransaction = new BankTransaction
                            {
                                EndOfDay = _endOfDay,
                                BankId = Convert.ToInt64(selectedItem?.Id),
                                Type = '1',
                                Action = Constants.RECEIPT,
                                Debit = Convert.ToDecimal(RichAmount.Text.Trim()),
                                Credit = Constants.DEFAULT_DECIMAL_VALUE,
                                Narration = TxtMemberId.Text.Trim() + " - " + TxtName.Text.Trim(),
                                AddedBy = _username,
                                AddedDate = DateTime.Now
                            };

                            _memberService.AddMemberReceipt(userTransaction, bankTransaction, _username);
                        }
                        else
                        {
                            _userTransactionService.AddUserTransaction(userTransaction);
                        }


                        DialogResult result = MessageBox.Show(RichAmount.Text.Trim() + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            ClearTransactionFields();
                            var memberTransactionViewList = GetMemberTransactions(TxtMemberId.Text.Trim());
                            LoadMemberTransactions(memberTransactionViewList);
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

        private void BtnEditReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridMemberList.SelectedCells.Count == 1
                    || DataGridMemberList.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow;
                    if (DataGridMemberList.SelectedCells.Count == 1)
                    {
                        var selectedCell = DataGridMemberList.SelectedCells[0];
                        selectedRow = DataGridMemberList.Rows[selectedCell.RowIndex];
                    }
                    else
                    {
                        selectedRow = DataGridMemberList.SelectedRows[0];
                    }

                    var invoiceNo = selectedRow?.Cells["InvoiceNo"]?.Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(invoiceNo))
                    {
                        var soldItemListForm = new SoldItemListForm(_username, invoiceNo, _soldItemService);
                        soldItemListForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnRemoveReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridMemberList.SelectedCells.Count == 1
                    || DataGridMemberList.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow;
                    if (DataGridMemberList.SelectedCells.Count == 1)
                    {
                        var selectedCell = DataGridMemberList.SelectedCells[0];
                        selectedRow = DataGridMemberList.Rows[selectedCell.RowIndex];
                    }
                    else
                    {
                        selectedRow = DataGridMemberList.SelectedRows[0];
                    }

                    var selectedId = selectedRow?.Cells["Id"]?.Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(selectedId))
                    {
                        DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (deleteResult == DialogResult.Yes)
                        {
                            var id = Convert.ToInt64(selectedId);
                            if (_memberService.DeleteMemberReceipt(id))
                            {
                                DialogResult result = MessageBox.Show("Receipt has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (result == DialogResult.OK)
                                {
                                    ClearTransactionFields();
                                    var memberTransactionViewList = GetMemberTransactions(TxtMemberId.Text.Trim());
                                    LoadMemberTransactions(memberTransactionViewList);
                                }
                            }
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

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            OpenMemberImageDialog.InitialDirectory = _baseImageFolder;
            OpenMemberImageDialog.Filter = "All files |*.*";
            OpenMemberImageDialog.ShowDialog();
        }

        private void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            PicBoxMemberImage.Image = PicBoxMemberImage.InitialImage;
            _uploadedImagePath = string.Empty;
        }

        private void BtnAddMember_Click(object sender, EventArgs e)
        {
            ClearMemberFields();
            ClearTransactionFields();
            EnableFields();
            EnableFields(Action.Add);
            TxtMemberId.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateMemberInfo())
                {
                    if (_memberService.IsMemberExist(TxtMemberId.Text.Trim()))
                    {
                        MessageBox.Show("MemberId already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string relativeImagePath = null;
                    string destinationFilePath = null;
                    if (!string.IsNullOrWhiteSpace(_uploadedImagePath))
                    {
                        if (!Directory.Exists(_baseImageFolder))
                        {
                            MessageBox.Show("Base image folder is set correctly. Please check.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (!Directory.Exists(Path.Combine(_baseImageFolder, _memberImageFolder)))
                            {
                                UtilityService.CreateFolder(_baseImageFolder, _memberImageFolder);
                            }

                            relativeImagePath = TxtMemberId.Text + ".jpg";
                            destinationFilePath = Path.Combine(_baseImageFolder, _memberImageFolder, relativeImagePath);
                            File.Copy(_uploadedImagePath, destinationFilePath, true);
                        }
                    }

                    var member = new Member
                    {
                        EndOfDay = _endOfDay,
                        MemberId = TxtMemberId.Text.Trim(),
                        ShareMemberId = TxtShareMemberId.Text.Trim(),
                        Name = TxtName.Text.Trim(),
                        Address = TxtAddress.Text.Trim(),
                        ContactNo = string.IsNullOrEmpty(TxtContactNumber.Text.Trim()) ? 0 : Convert.ToInt64(TxtContactNumber.Text.Trim()),
                        Email = TxtEmail.Text.Trim(),
                        AccountNo = TxtAccountNumber.Text.Trim(),
                        ImagePath = relativeImagePath,
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _memberService.AddMember(member);

                    DialogResult result = MessageBox.Show(member.MemberId + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearMemberFields();
                        ClearTransactionFields();
                        var memberTransactionViewList = GetMemberTransactions(member.MemberId);
                        LoadMemberTransactions(memberTransactionViewList);
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Edit);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var memberId = TxtMemberId.Text;
            try
            {
                if (ValidateMemberInfo())
                {
                    string relativeImagePath = null;
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
                            if (!Directory.Exists(Path.Combine(_baseImageFolder, _memberImageFolder)))
                            {
                                UtilityService.CreateFolder(_baseImageFolder, _memberImageFolder);
                            }

                            relativeImagePath = TxtMemberId.Text + ".jpg";
                            destinationFilePath = Path.Combine(_baseImageFolder, _memberImageFolder, relativeImagePath);
                            File.Copy(_uploadedImagePath, destinationFilePath, true);
                        }
                    }

                    var member = new Member
                    {
                        MemberId = TxtMemberId.Text.Trim(),
                        ShareMemberId = TxtShareMemberId.Text.Trim(),
                        Name = TxtName.Text.Trim(),
                        Address = TxtAddress.Text.Trim(),
                        ContactNo = string.IsNullOrEmpty(TxtContactNumber.Text.Trim()) ? 0 : Convert.ToInt64(TxtContactNumber.Text.Trim()),
                        Email = TxtEmail.Text.Trim(),
                        AccountNo = TxtAccountNumber.Text.Trim(),
                        ImagePath = relativeImagePath,
                        UpdatedBy = _username,
                        UpdatedDate = DateTime.Now
                    };

                    _memberService.UpdateMember(memberId, member);
                    DialogResult result = MessageBox.Show(memberId + " has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearMemberFields();
                        ClearTransactionFields();
                        var memberTransactionViewList = GetMemberTransactions(memberId);
                        LoadMemberTransactions(memberTransactionViewList);
                        EnableFields();
                        EnableFields(Action.Update);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var memberId = TxtMemberId.Text.Trim();
                if(!string.IsNullOrWhiteSpace(memberId))
                {
                    var memberTransactions = _userTransactionService
                    .GetMemberTransactions(new MemberTransactionFilter() { MemberId = memberId })
                    .ToList();

                    if(memberTransactions.Count > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Please delete transactions first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if(dialogResult == DialogResult.OK)
                        {
                            return;
                        }
                    }
                    else
                    {
                        DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (deleteResult == DialogResult.Yes)
                        {

                            var member = _memberService.GetMember(memberId);
                            var relativeImagePath = member.ImagePath;
                            var absoluteImagePath = Path.Combine(_baseImageFolder, _memberImageFolder, relativeImagePath);
                            if (!string.IsNullOrWhiteSpace(absoluteImagePath) && File.Exists(absoluteImagePath))
                            {
                                UtilityService.DeleteImage(absoluteImagePath);
                            }

                            if (_memberService.DeleteMember(memberId))
                            {
                                DialogResult result = MessageBox.Show(memberId + " has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (result == DialogResult.OK)
                                {
                                    ClearMemberFields();
                                    ClearTransactionFields();
                                    EnableFields();
                                    EnableFields(Action.Delete);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select the memeber first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnShowTransaction_Click(object sender, EventArgs e)
        {
            var dateFrom = UtilityService.GetDate(MaskEndOfDayFrom.Text.Trim());
            var dateTo = UtilityService.GetDate(MaskEndOfDayTo.Text.Trim());
            var memberId = TxtMemberId.Text.Trim();
            var action = ComboAction.Text.Trim();

            var memberTransactionFilter = new MemberTransactionFilter()
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                MemberId = memberId,
                Action = action
            };

            var memberTransactionViewList = GetMemberTransactions(memberTransactionFilter);
            TxtAmount.Text = (action == Constants.DEBIT)
                ? memberTransactionViewList.Sum(x => x.DueReceivedAmount).ToString()
                : memberTransactionViewList.Sum(x => x.ReceivedAmount).ToString();
            LoadMemberTransactions(memberTransactionViewList, Convert.ToDecimal(TxtAmount.Text));
        }
        #endregion

        #region Text Box Event
        private void TxtMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void TxtAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void TxtShareMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        #endregion  

        #region Rich Box Event
        private void RichMemberId_KeyUp(object sender, KeyEventArgs e)
        {
            var member = _memberService.GetMember(TxtMemberId.Text.Trim());
            if (member?.MemberId?.ToLower() == TxtMemberId.Text.Trim().ToLower())
            {
                DialogResult result = MessageBox.Show(TxtMemberId.Text.Trim() + " already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    TxtMemberId.Clear();
                    return;
                }
            }
        }

        private void RichAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Combobox Event
        private void ComboPayment_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedPayment = ComboReceipt.Text.Trim();
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

        private void ComboReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboAction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboAction_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ComboAction.Text))
            {
                BtnShowTransaction.Enabled = true;
            }
            else
            {
                BtnShowTransaction.Enabled = false;
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
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
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
            DataGridMemberList.Columns["ActionType"].Width = 220;
            DataGridMemberList.Columns["ActionType"].DisplayIndex = 2;

            DataGridMemberList.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridMemberList.Columns["InvoiceNo"].Width = 100;
            DataGridMemberList.Columns["InvoiceNo"].DisplayIndex = 3;

            DataGridMemberList.Columns["DueReceivedAmount"].HeaderText = "Debit";
            DataGridMemberList.Columns["DueReceivedAmount"].Width = 100;
            DataGridMemberList.Columns["DueReceivedAmount"].DisplayIndex = 4;
            DataGridMemberList.Columns["DueReceivedAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
            var memberTransactions = _userTransactionService
                .GetMemberTransactions(new MemberTransactionFilter() { MemberId = memberId })
                .ToList();

            decimal balance = Constants.DEFAULT_DECIMAL_VALUE;
            var memberTransactionViews = memberTransactions
                           .OrderBy(x => x.Id)
                           .Select(x =>
                           {
                               balance += (x.Action == Constants.SALES && x.ActionType == Constants.CASH) ? Constants.DEFAULT_DECIMAL_VALUE : (x.DueReceivedAmount - x.ReceivedAmount);
                               return new MemberTransactionView
                               {
                                   Id = x.Id,
                                   EndOfDay = x.EndOfDay,
                                   Action = x.Action,
                                   ActionType = x.ActionType,
                                   InvoiceNo = x.InvoiceNo,
                                   DueReceivedAmount = (x.Action == Constants.SALES && x.ActionType == Constants.CASH) ? x.ReceivedAmount : x.DueReceivedAmount,
                                   ReceivedAmount = x.ReceivedAmount,
                                   Balance = balance
                               };
                           }
             ).ToList();

            return memberTransactionViews;
        }

        private List<MemberTransactionView> GetMemberTransactions(MemberTransactionFilter memberTransactionFilter)
        {
            var memberTransactions = _userTransactionService.GetMemberTransactions(memberTransactionFilter).ToList();

            decimal balance = Constants.DEFAULT_DECIMAL_VALUE;
            var memberTransactionViews = memberTransactions
                           .OrderBy(x => x.Id)
                           .Select(x =>
                           {
                               var temp = memberTransactionFilter.Action == Constants.DEBIT
                                    ? ((x.Action == Constants.SALES && x.ActionType == Constants.CASH) ? x.ReceivedAmount : x.DueReceivedAmount)
                                    : x.ReceivedAmount;

                               balance += temp;

                               return new MemberTransactionView
                               {
                                   Id = x.Id,
                                   EndOfDay = x.EndOfDay,
                                   Action = x.Action,
                                   ActionType = x.ActionType,
                                   InvoiceNo = x.InvoiceNo,
                                   DueReceivedAmount = memberTransactionFilter.Action == Constants.DEBIT
                                        ? ((x.Action == Constants.SALES && x.ActionType == Constants.CASH) ? x.ReceivedAmount : x.DueReceivedAmount)
                                        : Constants.DEFAULT_DECIMAL_VALUE,
                                   ReceivedAmount = memberTransactionFilter.Action == Constants.DEBIT
                                        ? Constants.DEFAULT_DECIMAL_VALUE
                                        : x.ReceivedAmount,
                                   Balance = balance
                               };
                           }
             ).ToList();

            return memberTransactionViews;
        }

        private void LoadMemberTransactions(List<MemberTransactionView> memberTransactionViewList, decimal balance = Constants.DEFAULT_DECIMAL_VALUE)
        {
            TxtBalance.Text = balance == Constants.DEFAULT_DECIMAL_VALUE
                ? memberTransactionViewList.Sum(x => (x.DueReceivedAmount - x.ReceivedAmount)).ToString()
                : balance.ToString();

            TxtBalanceStatus.Text = Convert.ToDecimal(TxtBalance.Text) > Constants.DEFAULT_DECIMAL_VALUE 
                ? Constants.DUE 
                : (Convert.ToDecimal(TxtBalance.Text) == Constants.DEFAULT_DECIMAL_VALUE ? Constants.CLEAR : Constants.OWNED);

            var bindingList = new BindingList<MemberTransactionView>(memberTransactionViewList);
            var source = new BindingSource(bindingList, null);
            DataGridMemberList.DataSource = source;
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Add)
            {
                TxtMemberId.Enabled = true;
                TxtAccountNumber.Enabled = true;
                TxtName.Enabled = true;
                TxtAddress.Enabled = true;
                TxtShareMemberId.Enabled = true;
                TxtEmail.Enabled = true;
                TxtContactNumber.Enabled = true;

                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
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
                TxtShareMemberId.Enabled = true;
                TxtEmail.Enabled = true;
                TxtContactNumber.Enabled = true;

                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
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
            else if (action == Action.PopulateMember)
            {
                BtnAddMember.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;

                MaskEndOfDayFrom.Enabled = true;
                MaskEndOfDayTo.Enabled = true;
                ComboAction.Enabled = true;

                ComboAction.Text = string.Empty;
                TxtAmount.Clear();
            }
            else
            {
                TxtMemberId.Enabled = false;
                TxtAccountNumber.Enabled = false;
                TxtName.Enabled = false;
                TxtAddress.Enabled = false;
                TxtShareMemberId.Enabled = false;
                TxtEmail.Enabled = false;
                TxtContactNumber.Enabled = false;

                BtnAddImage.Enabled = false;
                BtnDeleteImage.Enabled = false;
                BtnAddMember.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;

                MaskEndOfDayFrom.Enabled = false;
                MaskEndOfDayTo.Enabled = false;
                ComboAction.Enabled = false;
                BtnShowTransaction.Enabled = false;
            }
        }

        private void ClearMemberFields()
        {
            TxtMemberId.Clear();
            TxtAccountNumber.Clear();
            TxtName.Clear();
            TxtAddress.Clear();
            TxtShareMemberId.Clear();
            TxtEmail.Clear();
            TxtContactNumber.Clear();
            TxtBalance.Clear();
            PicBoxMemberImage.Image = PicBoxMemberImage.InitialImage;
        }

        private void ClearTransactionFields()
        {
            ComboReceipt.Text = string.Empty;
            ComboBank.Text = string.Empty;
            RichAmount.Clear();
        }

        public void PopulateMember(string memberId)
        {
            var member = _memberService.GetMember(memberId);

            TxtMemberId.Text = member.MemberId;
            TxtName.Text = member.Name;
            TxtAddress.Text = member.Address;
            TxtShareMemberId.Text = member.ShareMemberId;
            TxtContactNumber.Text = member.ContactNo.ToString();
            TxtEmail.Text = member.Email;
            TxtAccountNumber.Text = member.AccountNo;

            var absoluteImagePath = Path.Combine(_baseImageFolder, _memberImageFolder, member.ImagePath);
            if (File.Exists(absoluteImagePath))
            {
                PicBoxMemberImage.ImageLocation = absoluteImagePath;
            }
            else
            {
                PicBoxMemberImage.Image = PicBoxMemberImage.InitialImage;
            }

            ComboReceipt.Enabled = true;

            EnableFields();
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

        private void LoadTrasactionActions()
        {
            ComboAction.Items.Clear();
            ComboAction.ValueMember = "Id";
            ComboAction.DisplayMember = "Value";

            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.DEBIT, Value = Constants.DEBIT });
            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.CREDIT, Value = Constants.CREDIT });
        }

        #endregion

        #region Validation
        private bool ValidateMemberInfo()
        {
            var isValidated = false;

            var memberId = TxtMemberId.Text.Trim();
            var memberName = TxtName.Text.Trim();
            var shareMemberId = TxtShareMemberId.Text.Trim();

            if (string.IsNullOrWhiteSpace(memberId)
                || string.IsNullOrWhiteSpace(memberName)
                || string.IsNullOrWhiteSpace(shareMemberId))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Member Id " +
                    "\n * Member Name" +
                    "\n * Share Member Id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }

        private bool ValidateMemberTransaction()
        {
            var isValidated = false;

            var receipt = ComboReceipt.Text.Trim();
            var bank = ComboBank.Text.Trim();
            var amount = RichAmount.Text.Trim();

            if (string.IsNullOrWhiteSpace(receipt)
                || (receipt == Constants.CASH && string.IsNullOrWhiteSpace(amount)))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Receipt " +
                    "\n * Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(receipt)
                || (receipt == Constants.CHEQUE && string.IsNullOrWhiteSpace(bank))
                || string.IsNullOrWhiteSpace(amount))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Receipt " +
                    "\n * Bank " +
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
