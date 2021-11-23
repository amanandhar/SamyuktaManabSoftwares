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
    public partial class ShareMemberForm : Form, IShareMemberListForm
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IShareMemberService _shareMemberService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;
        public DashboardForm _dashboard;
        private string _baseImageFolder;
        private string _shareMemberImageFolder;
        private string _uploadedImagePath = string.Empty;
        private long _selectedShareMemberId;

        #region Enum
        private enum Action
        {
            Add,
            Save,
            Edit,
            Update,
            Delete,
            Load,
            PopulateShareMember,
            None
        }
        #endregion 

        #region Constructor
        public ShareMemberForm(string username,
            ISettingService settingService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IShareMemberService shareMemberService, IUserTransactionService userTransactionService,
            DashboardForm dashboardForm)
        {
            InitializeComponent();

            _settingService = settingService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _shareMemberService = shareMemberService;
            _userTransactionService = userTransactionService;
            _dashboard = dashboardForm;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;

        }
        #endregion

        #region Form Load Event
        private void ShareMemberForm_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
            _shareMemberImageFolder = ConfigurationManager.AppSettings[Constants.SHARE_MEMBER_IMAGE_FOLDER].ToString();
            EnableFields();
            EnableFields(Action.Load);
            LoadBanks();
            LoadTrasactions();
            LoadNarrations();
        }
        #endregion

        #region Button Click Event

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ShareMemberListForm shareMemberListForm = new ShareMemberListForm(_shareMemberService, this);
            shareMemberListForm.ShowDialog();
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            OpenShareMemberImageDialog.InitialDirectory = _baseImageFolder;
            OpenShareMemberImageDialog.Filter = "All files |*.*";
            OpenShareMemberImageDialog.ShowDialog();
        }

        private void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            PicBoxShareMember.Image = PicBoxShareMember.InitialImage;
            _uploadedImagePath = string.Empty;
        }

        private void BtnShowTransaction_Click(object sender, EventArgs e)
        {
            LoadShareMemberTransactions(GetShareMemberTransactions(_selectedShareMemberId));
        }

        private void BtnSaveTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateShareMemberTransaction())
                {
                    ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                    var bankTransaction = new BankTransaction
                    {
                        EndOfDay = _endOfDay,
                        BankId = Convert.ToInt64(selectedItem?.Id),
                        Type = ComboTransaction.Text.Trim().ToLower() == Constants.DEPOSIT.ToLower() ? '1' : '0',
                        Action = Constants.SHARE_CAPITAL,
                        TransactionId = _selectedShareMemberId,
                        Debit = ComboTransaction.Text.Trim().ToLower() == Constants.DEPOSIT.ToLower()
                            ? Convert.ToDecimal(RichAmount.Text.Trim())
                            : Constants.DEFAULT_DECIMAL_VALUE,
                        Credit = ComboTransaction.Text.Trim().ToLower() == Constants.DEPOSIT.ToLower()
                            ? Constants.DEFAULT_DECIMAL_VALUE
                            : Convert.ToDecimal(RichAmount.Text.Trim()),
                        Narration = ComboNarration.Text.Trim(),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _bankTransactionService.AddBankTransaction(bankTransaction);
                    DialogResult result = MessageBox.Show("Amount has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAmountFields();
                        EnableFields();
                        EnableFields(Action.PopulateShareMember);
                        LoadShareMemberTransactions(GetShareMemberTransactions(_selectedShareMemberId));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnRemoveTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridShareMemberList.SelectedCells.Count == 1
                    || DataGridShareMemberList.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow;
                    if (DataGridShareMemberList.SelectedCells.Count == 1)
                    {
                        var selectedCell = DataGridShareMemberList.SelectedCells[0];
                        selectedRow = DataGridShareMemberList.Rows[selectedCell.RowIndex];
                    }
                    else
                    {
                        selectedRow = DataGridShareMemberList.SelectedRows[0];
                    }

                    string bankTransactionId = selectedRow?.Cells["BankTransactionId"]?.Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(bankTransactionId))
                    {
                        DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (deleteResult == DialogResult.Yes)
                        {
                            var id = Convert.ToInt64(bankTransactionId);
                            if(_bankTransactionService.DeleteShareMemberTransaction(id))
                            {
                                DialogResult result = MessageBox.Show("Trasaction has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (result == DialogResult.OK)
                                {
                                    LoadShareMemberTransactions(GetShareMemberTransactions(_selectedShareMemberId));
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields();
            EnableFields(Action.Add);
            RichShareMemberId.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateShareMemberInfo())
                {
                    if (_shareMemberService.IsShareMemberExist(RichShareMemberId.Text.Trim()))
                    {
                        MessageBox.Show("Share Member Id already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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
                            if (!Directory.Exists(Path.Combine(_baseImageFolder, _shareMemberImageFolder)))
                            {
                                UtilityService.CreateFolder(_baseImageFolder, _shareMemberImageFolder);
                            }

                            relativeImagePath = RichName.Text + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".jpg";
                            destinationFilePath = Path.Combine(_baseImageFolder, _shareMemberImageFolder, relativeImagePath);
                            File.Copy(_uploadedImagePath, destinationFilePath, true);
                        }
                    }

                    var shareMember = new ShareMember
                    {
                        EndOfDay = _endOfDay,
                        ShareMemberId = RichShareMemberId.Text.Trim(),
                        Name = RichName.Text.Trim(),
                        Address = RichAddress.Text.Trim(),
                        ContactNo = string.IsNullOrEmpty(RichContactNumber.Text.Trim()) ? 0 : Convert.ToInt64(RichContactNumber.Text.Trim()),
                        ImagePath = relativeImagePath,
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _shareMemberService.AddShareMember(shareMember);

                    DialogResult result = MessageBox.Show(shareMember.Name + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
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
            var shareMemberId = _selectedShareMemberId;
            try
            {
                if (ValidateShareMemberInfo())
                {
                    var selectedShareMember = _shareMemberService.GetShareMember(Convert.ToInt64(shareMemberId));
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
                            if (!Directory.Exists(Path.Combine(_baseImageFolder, _shareMemberImageFolder)))
                            {
                                UtilityService.CreateFolder(_baseImageFolder, _shareMemberImageFolder);
                            }

                            if (selectedShareMember.ImagePath != _uploadedImagePath)
                            {
                                if (!string.IsNullOrWhiteSpace(selectedShareMember.ImagePath) && File.Exists(selectedShareMember.ImagePath))
                                {
                                    UtilityService.DeleteImage(selectedShareMember.ImagePath);
                                }

                                relativeImagePath = RichName.Text.Trim() + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".jpg";
                                destinationFilePath = Path.Combine(_baseImageFolder, _shareMemberImageFolder, relativeImagePath);
                                File.Copy(_uploadedImagePath, destinationFilePath, true);
                            }
                            else
                            {
                                destinationFilePath = selectedShareMember.ImagePath;
                            }
                        }
                    }

                    var shareMember = new ShareMember
                    {
                        ShareMemberId = RichShareMemberId.Text.Trim(),
                        Name = RichName.Text.Trim(),
                        Address = RichAddress.Text.Trim(),
                        ContactNo = string.IsNullOrEmpty(RichContactNumber.Text.Trim()) ? 0 : Convert.ToInt64(RichContactNumber.Text.Trim()),
                        ImagePath = relativeImagePath,
                        UpdatedBy = _username,
                        UpdatedDate = DateTime.Now
                    };

                    _shareMemberService.UpdateShareMember(Convert.ToInt64(shareMemberId), shareMember);
                    DialogResult result = MessageBox.Show(shareMember.Name + " has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
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
                var shareMemberId = _selectedShareMemberId;
                var shareMemeberTransactions = _shareMemberService.GetShareMemberTransactions(new ShareMemberTransactionFilter() { ShareMemberId = shareMemberId }).ToList();
                if(shareMemeberTransactions.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Please delete transactions first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        return;
                    }
                }
                else
                {
                    DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteResult == DialogResult.Yes)
                    {

                        var shareMember = _shareMemberService.GetShareMember(Convert.ToInt64(shareMemberId));
                        var relativeImagePath = shareMember.ImagePath;
                        var absoluteImagePath = Path.Combine(_baseImageFolder, _shareMemberImageFolder, relativeImagePath);
                        if (!string.IsNullOrWhiteSpace(absoluteImagePath) && File.Exists(absoluteImagePath))
                        {
                            UtilityService.DeleteImage(absoluteImagePath);
                        }

                        if (_shareMemberService.DeleteShareMember(Convert.ToInt64(shareMemberId)))
                        {
                            DialogResult result = MessageBox.Show(RichName.Text.Trim() + " has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (result == DialogResult.OK)
                            {
                                DataGridShareMemberList.Rows.Clear();
                                ClearAllFields();
                                EnableFields();
                                EnableFields(Action.Delete);
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

        #endregion

        #region Rich Box Event
        private void RichShareMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void RichAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Combo Box Event
        private void ComboBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboTransaction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboBank_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboTransaction.Focus();
        }

        private void ComboTransaction_SelectedValueChanged(object sender, EventArgs e)
        {
            RichAmount.Focus();
        }
        #endregion

        #region OpenFileDialog Event
        private void OpenShareMemberImageDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                Activate();
                string[] files = OpenShareMemberImageDialog.FileNames;
                _uploadedImagePath = files[0];
                PicBoxShareMember.Image = Image.FromFile(_uploadedImagePath);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }
        #endregion

        #region Data Grid Event
        private void DataGridShareMemberList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridShareMemberList.Columns["Id"].Visible = false;
            DataGridShareMemberList.Columns["BankTransactionId"].Visible = false;
            DataGridShareMemberList.Columns["Name"].Visible = false;
            DataGridShareMemberList.Columns["ContactNo"].Visible = false;

            DataGridShareMemberList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridShareMemberList.Columns["EndOfDay"].Width = 100;
            DataGridShareMemberList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridShareMemberList.Columns["Description"].HeaderText = "Description";
            DataGridShareMemberList.Columns["Description"].Width = 200;
            DataGridShareMemberList.Columns["Description"].DisplayIndex = 1;

            DataGridShareMemberList.Columns["Type"].HeaderText = "Type";
            DataGridShareMemberList.Columns["Type"].Width = 200;
            DataGridShareMemberList.Columns["Type"].DisplayIndex = 2;

            DataGridShareMemberList.Columns["Debit"].HeaderText = "Debit";
            DataGridShareMemberList.Columns["Debit"].Width = 100;
            DataGridShareMemberList.Columns["Debit"].DisplayIndex = 4;
            DataGridShareMemberList.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridShareMemberList.Columns["Credit"].HeaderText = "Credit";
            DataGridShareMemberList.Columns["Credit"].Width = 100;
            DataGridShareMemberList.Columns["Credit"].DisplayIndex = 5;
            DataGridShareMemberList.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridShareMemberList.Columns["Balance"].HeaderText = "Balance";
            DataGridShareMemberList.Columns["Balance"].DisplayIndex = 6;
            DataGridShareMemberList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridShareMemberList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridShareMemberList.Rows)
            {
                DataGridShareMemberList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridShareMemberList.RowHeadersWidth = 50;
                DataGridShareMemberList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods

        private void LoadBanks()
        {
            try
            {
                var _banks = _bankService.GetBanks().ToList();
                ComboBank.Items.Clear();
                ComboBank.ValueMember = "Id";
                ComboBank.DisplayMember = "Value";

                _banks.OrderBy(x => x.Name).ToList().ForEach(x =>
                {
                    ComboBank.Items.Add(new ComboBoxItem { Id = x.Id.ToString(), Value = x.Name });
                });

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void LoadTrasactions()
        {
            ComboTransaction.Items.Clear();
            ComboTransaction.ValueMember = "Id";
            ComboTransaction.DisplayMember = "Value";

            ComboTransaction.Items.Add(new ComboBoxItem { Id = Constants.DEPOSIT, Value = Constants.DEPOSIT });
            ComboTransaction.Items.Add(new ComboBoxItem { Id = Constants.WITHDRAWL, Value = Constants.WITHDRAWL });
        }

        private void LoadNarrations()
        {
            ComboNarration.Items.Clear();
            ComboNarration.ValueMember = "Id";
            ComboNarration.DisplayMember = "Value";

            ComboNarration.Items.Add(new ComboBoxItem { Id = Constants.SHARE_CAPITAL, Value = Constants.SHARE_CAPITAL });
        }

        private List<ShareMemberTransactionView> GetShareMemberTransactions(long shareMemberId)
        {
            var shareMemberTransactionFilter = new ShareMemberTransactionFilter()
            {
                ShareMemberId = shareMemberId
            };

            var shareMemberTransactionViewList = _shareMemberService.GetShareMemberTransactions(shareMemberTransactionFilter).ToList();
            return shareMemberTransactionViewList;
        }

        private void LoadShareMemberTransactions(List<ShareMemberTransactionView> shareMemberTransactionViewList)
        {
            decimal currentTotal = 0.00m;
            var shareMemberTransactionViewListWithBalance = shareMemberTransactionViewList.OrderBy(x => x.Id)
                .Select(x =>
                {
                    currentTotal += (x.Debit - x.Credit);
                    return new ShareMemberTransactionView()
                    {
                        Id = x.Id,
                        BankTransactionId = x.BankTransactionId,
                        EndOfDay = x.EndOfDay,
                        Name = x.Name,
                        ContactNo = x.ContactNo,
                        Description = x.Description,
                        Type = x.Type,
                        Credit = x.Credit,
                        Debit = x.Debit,
                        Balance = currentTotal
                    };
                }).ToList();

            TxtShareAmount.Text = shareMemberTransactionViewListWithBalance.Sum(x => (x.Debit - x.Credit)).ToString();
            var bindingList = new BindingList<ShareMemberTransactionView>(shareMemberTransactionViewListWithBalance);
            var source = new BindingSource(bindingList, null);
            DataGridShareMemberList.DataSource = source;
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Add)
            {
                RichShareMemberId.Enabled = true;
                RichName.Enabled = true;
                RichAddress.Enabled = true;
                RichContactNumber.Enabled = true;

                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
                BtnSave.Enabled = true;
            }
            else if (action == Action.Save)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                RichShareMemberId.Enabled = true;
                RichName.Enabled = true;
                RichAddress.Enabled = true;
                RichContactNumber.Enabled = true;

                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == Action.Update)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Delete)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Load)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.PopulateShareMember)
            {
                ComboBank.Enabled = true;
                ComboTransaction.Enabled = true;
                ComboNarration.Enabled = true;
                RichAmount.Enabled = true;

                BtnShowTransaction.Enabled = true;
                BtnSaveTransaction.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else
            {
                RichShareMemberId.Enabled = false;
                RichName.Enabled = false;
                RichAddress.Enabled = false;
                RichContactNumber.Enabled = false;
                TxtMemberSales.Enabled = false;
                TxtShareAmount.Enabled = false;

                ComboBank.Enabled = false;
                ComboTransaction.Enabled = false;
                ComboNarration.Enabled = false;
                RichAmount.Enabled = false;
                PicBoxShareMember.Enabled = false;

                BtnAddImage.Enabled = false;
                BtnDeleteImage.Enabled = false;
                BtnShowTransaction.Enabled = false;
                BtnSaveTransaction.Enabled = false;
                BtnAdd.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            RichShareMemberId.Clear();
            RichName.Clear();
            RichAddress.Clear();
            RichContactNumber.Clear();
            TxtMemberSales.Clear();
            TxtShareAmount.Clear();
            
            ComboBank.Text = string.Empty;
            ComboTransaction.Text = string.Empty;
            RichAmount.Clear();
            ComboNarration.Text = string.Empty;
            
            PicBoxShareMember.Image = PicBoxShareMember.InitialImage;
        }

        private void ClearAmountFields()
        {
            ComboBank.Text = string.Empty;
            ComboTransaction.Text = string.Empty;
            RichAmount.Clear();
            ComboNarration.Text = string.Empty;
        }

        public void PopulateShareMember(long shareMemberId)
        {
            _selectedShareMemberId = shareMemberId;
            var shareMember = _shareMemberService.GetShareMember(_selectedShareMemberId);

            RichShareMemberId.Text = shareMember.ShareMemberId;
            RichName.Text = shareMember.Name;
            RichAddress.Text = shareMember.Address;
            RichContactNumber.Text = shareMember.ContactNo.ToString();
            TxtMemberSales.Text = _userTransactionService.GetTotalMemberSaleAmount(shareMember.ShareMemberId).ToString();

            var absoluteImagePath = Path.Combine(_baseImageFolder, _shareMemberImageFolder, shareMember.ImagePath);
            if (File.Exists(absoluteImagePath))
            {
                PicBoxShareMember.ImageLocation = absoluteImagePath;
            }
            else
            {
                PicBoxShareMember.Image = PicBoxShareMember.InitialImage;
            }

            EnableFields();
            EnableFields(Action.PopulateShareMember);
            LoadShareMemberTransactions(GetShareMemberTransactions(_selectedShareMemberId));
        }

        #endregion

        #region Validation
        private bool ValidateShareMemberInfo()
        {
            var isValidated = false;
            var shareMemberId = RichShareMemberId.Text.Trim();
            var name = RichName.Text.Trim();

            if (string.IsNullOrWhiteSpace(shareMemberId)
                || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Share Member Id " + 
                    "\n * Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }

        private bool ValidateShareMemberTransaction()
        {
            var isValidated = false;

            var bank = ComboBank.Text.Trim();
            var transaction = ComboTransaction.Text.Trim();
            var amount = RichAmount.Text.Trim();
            var narration = ComboNarration.Text.Trim();

            if (string.IsNullOrWhiteSpace(bank)
                || string.IsNullOrWhiteSpace(transaction)
                || string.IsNullOrWhiteSpace(amount)
                || string.IsNullOrWhiteSpace(narration))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Bank " +
                    "\n * Transaction " +
                    "\n * Amount " +
                    "\n * Narration", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
