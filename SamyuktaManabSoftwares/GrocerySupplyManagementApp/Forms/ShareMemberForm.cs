using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ShareMemberForm : Form, IShareMemberListForm
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IShareMemberService _shareMemberService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;
        public DashboardForm _dashboard;
        private string _baseImageFolder;
        private const string MEMBER_IMAGE_FOLDER = "ShareMembers";
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
        public ShareMemberForm(IFiscalYearService fiscalYearService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IShareMemberService shareMemberService,
            IUserTransactionService userTransactionService,
            DashboardForm dashboardForm)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _shareMemberService = shareMemberService;
            _userTransactionService = userTransactionService;
            _dashboard = dashboardForm;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
            
        }
        #endregion

        #region Form Load Event
        private void ShareMemberForm_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
            EnableFields(Action.None);
            EnableFields(Action.Load);
            LoadBanks();
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
            PicBoxShareMember.Image = null;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            //LoadShareMemberTransactions();
        }

        private void BtnSaveAmount_Click(object sender, EventArgs e)
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
                    DueAmount = Convert.ToDecimal(RichAmount.Text),
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
                    Action = '1',
                    Debit = Convert.ToDecimal(RichAmount.Text),
                    Credit =  0.0m,
                    Narration = RichNarration.Text,
                    AddedDate = date,
                    UpdatedDate = date
                };

                _bankTransactionService.AddBankTransaction(bankTransaction);
                DialogResult result = MessageBox.Show("Amount has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    //LoadShareMemberTransactions();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields(Action.None);
            EnableFields(Action.Add);
            RichName.Focus();
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

                        var fileName = RichName.Text + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".jpg";
                        destinationFilePath = Path.Combine(_baseImageFolder, MEMBER_IMAGE_FOLDER, fileName);
                        File.Copy(_uploadedImagePath, destinationFilePath, true);
                    }
                }

                var date = DateTime.Now;
                var shareMember = new ShareMember
                {
                    Name = RichName.Text,
                    Address = RichAddress.Text,
                    ContactNo = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    ImagePath = destinationFilePath,
                    AddedDate = date,
                    UpdatedDate = date
                };

                _shareMemberService.AddShareMember(shareMember);

                DialogResult result = MessageBox.Show(shareMember.Name + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    //LoadShareMemberTransactions(shareMemberTransactionViewList);
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
            var shareMemberId = _selectedShareMemberId;
            try
            {
                var selectedShareMember = _shareMemberService.GetShareMember(shareMemberId);
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

                        if(selectedShareMember.ImagePath != _uploadedImagePath)
                        {
                            if(UtilityService.DeleteImage(selectedShareMember.ImagePath))
                            {
                                var fileName = RichName.Text + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".jpg";
                                destinationFilePath = Path.Combine(_baseImageFolder, MEMBER_IMAGE_FOLDER, fileName);
                                File.Copy(_uploadedImagePath, destinationFilePath, true);
                            }
                        }
                        else
                        {
                            destinationFilePath = selectedShareMember.ImagePath;
                        }
                    }
                }

                var shareMember = new ShareMember
                {
                    Name = RichName.Text,
                    Address = RichAddress.Text,
                    ContactNo = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    ImagePath = destinationFilePath,
                    UpdatedDate = DateTime.Now
                };

                _shareMemberService.UpdateShareMember(shareMemberId, shareMember);
                DialogResult result = MessageBox.Show(shareMember.Name + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    //var memberTransactionViewList = GetShareMemberTransactions(shareMemberId);
                    //LoadShareMemberTransactions(memberTransactionViewList);
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
                    var shareMemberId = _selectedShareMemberId;
                    var shareMember = _shareMemberService.GetShareMember(shareMemberId); 
                    if (!string.IsNullOrWhiteSpace(shareMember.ImagePath) && File.Exists(shareMember.ImagePath) && UtilityService.DeleteImage(shareMember.ImagePath))
                    {
                        if (_shareMemberService.DeleteShareMember(shareMemberId))
                        {
                            DialogResult result = MessageBox.Show(RichName.Text + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ClearAllFields();
                                //var memberTransactionViewList = GetMemberTransactions(shareMemberId);
                                //LoadMemberTransactions(memberTransactionViewList);
                                EnableFields(Action.None);
                                EnableFields(Action.Delete);
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

        #endregion

        #region OpenFileDialog Event
        private void OpenShareMemberImageDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
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
                throw ex;
            }
        }
        #endregion

        #region Helper Methods

        private void LoadBanks()
        {
            try
            {
                var _banks = _bankService.GetBanks().ToList();

                ComboBank.ValueMember = "Id";
                ComboBank.DisplayMember = "Value";

                _banks.OrderBy(x => x.Name).ToList().ForEach(x =>
                {
                    ComboBank.Items.Add(new ComboBoxItem { Id = x.Id.ToString(), Value = x.Name });
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
        private List<ShareMember> GetMemberTransactions(long shareMemberId)
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

        private List<ShareMember> GetShareMemberTransactions()
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

        private void LoadShareMemberTransactions(List<ShareMember> memberTransactionViewList)
        {
            TxtShareAmount.Text = memberTransactionViewList.Sum(x => (x.DueAmount - x.ReceivedAmount)).ToString();

            var bindingList = new BindingList<ShareMember>(memberTransactionViewList);
            var source = new BindingSource(bindingList, null);
            DataGridMemberList.DataSource = source;
        }
        */

        private void EnableFields(Action action)
        {
            if (action == Action.Add)
            {
                RichName.Enabled = true;
                RichAddress.Enabled = true;
                RichContactNumber.Enabled = true;
                ComboBank.Enabled = true;
                RichNarration.Enabled = true;
                RichAmount.Enabled = true;

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
                ComboBank.Enabled = true;
                RichNarration.Enabled = true;
                RichAmount.Enabled = true;

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
                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else
            {
                RichName.Enabled = false;
                RichAddress.Enabled = false;
                RichContactNumber.Enabled = false;
                TxtShareAmount.Enabled = false;
                RichNarration.Enabled = false;
                ComboBank.Enabled = false;
                RichAmount.Enabled = false;
                PicBoxShareMember.Enabled = false;

                BtnAddImage.Enabled = false;
                BtnDeleteImage.Enabled = false;
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
            RichNarration.Clear();
            ComboBank.Text = string.Empty;
            RichAmount.Clear();
            PicBoxShareMember.Image = PicBoxShareMember.InitialImage;
        }

        public void PopulateShareMember(long shareMemberId)
        {
            _selectedShareMemberId = shareMemberId;
            var shareMember = _shareMemberService.GetShareMember(shareMemberId);

            RichName.Text = shareMember.Name;
            RichAddress.Text = shareMember.Address;
            RichContactNumber.Text = shareMember.ContactNo.ToString();

            if (File.Exists(shareMember.ImagePath))
            {
                PicBoxShareMember.ImageLocation = shareMember.ImagePath;
            }
            else
            {
                PicBoxShareMember.Image = null;
            }

            EnableFields(Action.None);
            EnableFields(Action.PopulateShareMember);
            //var shareMemberTransactionViewList = GetShareMemberTransactions(shareMemberId);
            //LoadShareMemberTransactions(shareMemberTransactionViewList);
        }

        #endregion
    }
}
