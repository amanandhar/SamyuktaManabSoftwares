﻿using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.Shared.Enums;
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
        private string _selectedShareMemberId;

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
            IShareMemberService shareMemberService,
            IUserTransactionService userTransactionService,
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
            LoadNarration();
        }
        #endregion

        #region Button Click Event

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ShareMemberListForm shareMemberListForm = new ShareMemberListForm(_userTransactionService, this);
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

        private void BtnShow_Click(object sender, EventArgs e)
        {
            LoadShareMemberTransactions(GetShareMemberTransactions(_selectedShareMemberId));
        }

        private void BtnSaveAmount_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateShareMemberTransaction())
                {
                    ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                    var userTransaction = new UserTransaction
                    {
                        EndOfDay = _endOfDay,
                        PartyId = _selectedShareMemberId,
                        Action = Constants.RECEIPT,
                        ActionType = Constants.SHARE_CAPITAL,
                        BankName = selectedItem?.Value,
                        ReceivedAmount = Convert.ToDecimal(RichAmount.Text.Trim()),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };
                    _userTransactionService.AddUserTransaction(userTransaction);

                    var lastUserTransaction = _userTransactionService.GetLastUserTransaction(PartyNumberType.None, _username);

                    var bankTransaction = new BankTransaction
                    {
                        EndOfDay = _endOfDay,
                        BankId = Convert.ToInt64(selectedItem?.Id),
                        UserTransactionId = lastUserTransaction.Id,
                        Action = '1',
                        Debit = Convert.ToDecimal(RichAmount.Text.Trim()),
                        Credit = Constants.DEFAULT_DECIMAL_VALUE,
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields();
            EnableFields(Action.Add);
            RichName.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateShareMemberInfo())
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
                DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteResult == DialogResult.Yes)
                {
                    var shareMemberId = _selectedShareMemberId;
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
                            ClearAllFields();
                            EnableFields();
                            EnableFields(Action.Delete);
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
        private void RichAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
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
            DataGridShareMemberList.Columns["ShareMemberId"].Visible = false;
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

        private void LoadNarration()
        {
            ComboNarration.Items.Clear();
            ComboNarration.ValueMember = "Id";
            ComboNarration.DisplayMember = "Value";

            ComboNarration.Items.Add(new ComboBoxItem { Id = Constants.SHARE_CAPITAL, Value = Constants.SHARE_CAPITAL });
        }

        private List<ShareMemberTransactionView> GetShareMemberTransactions(string shareMemberId)
        {
            var shareMemberTransactionFilter = new ShareMemberTransactionFilter()
            {
                ShareMemberId = shareMemberId
            };

            var shareMemberTransactionViewList = _userTransactionService.GetShareMemberTransactions(shareMemberTransactionFilter).ToList();
            return shareMemberTransactionViewList;
        }

        private void LoadShareMemberTransactions(List<ShareMemberTransactionView> shareMemberTransactionViewList)
        {
            TxtShareAmount.Text = shareMemberTransactionViewList.Sum(x => x.Balance).ToString();

            var bindingList = new BindingList<ShareMemberTransactionView>(shareMemberTransactionViewList);
            var source = new BindingSource(bindingList, null);
            DataGridShareMemberList.DataSource = source;
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Add)
            {
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
                ComboNarration.Enabled = true;
                RichAmount.Enabled = true;

                BtnShow.Enabled = true;
                BtnSaveAmount.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else
            {
                RichName.Enabled = false;
                RichAddress.Enabled = false;
                RichContactNumber.Enabled = false;
                TxtShareAmount.Enabled = false;

                ComboBank.Enabled = false;
                ComboNarration.Enabled = false;
                RichAmount.Enabled = false;
                PicBoxShareMember.Enabled = false;

                BtnAddImage.Enabled = false;
                BtnDeleteImage.Enabled = false;
                BtnShow.Enabled = false;
                BtnSaveAmount.Enabled = false;
                BtnAdd.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            RichName.Clear();
            RichAddress.Clear();
            RichContactNumber.Clear();
            TxtShareAmount.Clear();
            ComboNarration.Text = string.Empty;
            ComboBank.Text = string.Empty;
            RichAmount.Clear();
            PicBoxShareMember.Image = PicBoxShareMember.InitialImage;
        }

        private void ClearAmountFields()
        {
            ComboNarration.Text = string.Empty;
            ComboBank.Text = string.Empty;
            RichAmount.Clear();
        }

        public void PopulateShareMember(string shareMemberId)
        {
            _selectedShareMemberId = shareMemberId;
            var shareMember = _shareMemberService.GetShareMember(Convert.ToInt64(_selectedShareMemberId));

            RichName.Text = shareMember.Name;
            RichAddress.Text = shareMember.Address;
            RichContactNumber.Text = shareMember.ContactNo.ToString();

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
            LoadShareMemberTransactions(GetShareMemberTransactions(_selectedShareMemberId.ToString()));
        }

        #endregion

        #region Validation
        private bool ValidateShareMemberInfo()
        {
            var isValidated = false;

            var name = RichName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter following fields: " +
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
            var amount = RichAmount.Text.Trim();

            if (string.IsNullOrWhiteSpace(bank)
                || string.IsNullOrWhiteSpace(amount))
            {
                MessageBox.Show("Please enter following fields: " +
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
