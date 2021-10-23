using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class UserForm : Form, IUserListForm
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly IUserService _userService;
        private bool _isPasswordChanged;
        private readonly string _username;

        #region Enum
        private enum Action
        {
            Add,
            Save,
            Edit,
            Update,
            Delete,
            Load,
            PopulateUser,
            None
        }
        #endregion 

        #region Constructor 
        public UserForm(string username, IUserService userService)
        {
            InitializeComponent();

            _username = username;
            _userService = userService;
        }
        #endregion

        #region Form Load Event
        private void UserForm_Load(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Load);
            LoadUserTypes();
        }
        #endregion

        #region Button Click Event
        private void BtnSearchUser_Click(object sender, EventArgs e)
        {
            UserListForm userListForm = new UserListForm(_username, _userService, this);
            userListForm.ShowDialog();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields();
            EnableFields(Action.Add);
            TxtUsername.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidateUserInfo())
                {
                    var username = TxtUsername.Text.Trim();
                    var password = TxtPassword.Text.Trim();
                    var confirmPassword = TxtConfirmPassword.Text.Trim();

                    if (string.IsNullOrWhiteSpace(username))
                    {
                        var errorResult = MessageBox.Show("Username is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            TxtUsername.Focus();
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(password))
                    {
                        var errorResult = MessageBox.Show("Password is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            TxtPassword.Focus();
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(confirmPassword) || (password != confirmPassword))
                    {
                        var errorResult = MessageBox.Show("Password does not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            TxtPassword.Focus();
                        }
                    }
                    else if (_userService.IsUserExist(username))
                    {
                        var errorResult = MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            TxtUsername.Focus();
                        }
                    }
                    else
                    {
                        var user = new User
                        {
                            Username = TxtUsername.Text,
                            Password = Cryptography.Encrypt(TxtPassword.Text),
                            Type = ComboUserType.Text,
                            Bank = ChkBank.Checked,
                            DailySummary = ChkDailySummary.Checked,
                            DailyTransaction = ChkDailyTransaction.Checked,
                            Employee = ChkEmployee.Checked,
                            EOD = ChkEOD.Checked,
                            ItemPricing = ChkItemPricing.Checked,
                            Member = ChkMember.Checked,
                            POS = ChkPOS.Checked,
                            IsReadOnly = ChkReadOnly.Checked,
                            Reports = ChkReports.Checked,
                            Settings = ChkSettings.Checked,
                            StockSummary = ChkStockSummary.Checked,
                            Supplier = ChkSupplier.Checked,
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };

                        _userService.AddUser(user);

                        DialogResult result = MessageBox.Show(user.Username + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            ClearAllFields();
                            EnableFields();
                            EnableFields(Action.Save);
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Edit);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidateUserInfo())
                {
                    var username = TxtUsername.Text;
                    var password = TxtPassword.Text;
                    var confirmPassword = TxtConfirmPassword.Text;

                    if (string.IsNullOrWhiteSpace(username.Trim()))
                    {
                        var errorResult = MessageBox.Show("Username is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            TxtUsername.Focus();
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(password.Trim()))
                    {
                        var errorResult = MessageBox.Show("Password is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            TxtPassword.Focus();
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(confirmPassword.Trim()) || (password.Trim() != confirmPassword.Trim()))
                    {
                        var errorResult = MessageBox.Show("Password does not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            TxtPassword.Focus();
                        }
                    }
                    else
                    {
                        var user = new User
                        {
                            Username = TxtUsername.Text,
                            Password = _isPasswordChanged ? Cryptography.Encrypt(TxtPassword.Text) : TxtPassword.Text,
                            Type = ComboUserType.Text,
                            Bank = ChkBank.Checked,
                            DailySummary = ChkDailySummary.Checked,
                            DailyTransaction = ChkDailyTransaction.Checked,
                            Employee = ChkEmployee.Checked,
                            EOD = ChkEOD.Checked,
                            ItemPricing = ChkItemPricing.Checked,
                            Member = ChkMember.Checked,
                            POS = ChkPOS.Checked,
                            IsReadOnly = ChkReadOnly.Checked,
                            Reports = ChkReports.Checked,
                            Settings = ChkSettings.Checked,
                            StockSummary = ChkStockSummary.Checked,
                            Supplier = ChkSupplier.Checked,
                            UpdatedBy = _username,
                            UpdatedDate = DateTime.Now
                        };

                        _userService.UpdateUser(username, user);
                        DialogResult result = MessageBox.Show(username + " has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            ClearAllFields();
                            EnableFields();
                            EnableFields(Action.Update);
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteResult == DialogResult.Yes)
                {
                    var username = TxtUsername.Text;
                    if (_userService.DeleteUser(username))
                    {
                        DialogResult result = MessageBox.Show(username + " has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region TextBox Event
        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            _isPasswordChanged = true;
        }

        private void TxtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            _isPasswordChanged = true;
        }
        #endregion

        #region Checkbox Event
        private void ChkPOS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkDailySummary_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkMember_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkSupplier_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkItemPricing_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkStock_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkDailyExpense_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkBank_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkSetting_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkReport_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkEmployee_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkEOD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkReadOnly_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Helper Methods
        private void ClearAllFields()
        {
            TxtUsername.Clear();
            TxtPassword.Clear();
            TxtConfirmPassword.Clear();
            ComboUserType.Text = string.Empty;
            ChkReadOnly.Checked = false;
            ChkBank.Checked = false;
            ChkPOS.Checked = false;
            ChkDailyTransaction.Checked = false;
            ChkDailySummary.Checked = false;
            ChkMember.Checked = false;
            ChkSupplier.Checked = false;
            ChkItemPricing.Checked = false;
            ChkStockSummary.Checked = false;
            ChkSettings.Checked = false;
            ChkReports.Checked = false;
            ChkEOD.Checked = false;
            ChkEmployee.Checked = false;
            ChkEOD.Checked = false;
        }

        public void PopulateUser(long id)
        {
            var user = _userService.GetUser(id);

            TxtUsername.Text = user.Username;
            ComboUserType.Text = user.Type;
            TxtPassword.Text = user.Password;
            TxtConfirmPassword.Text = user.Password;

            ChkBank.Checked = user.Bank;
            ChkDailyTransaction.Checked = user.DailyTransaction;
            ChkDailySummary.Checked = user.DailySummary;
            ChkEmployee.Checked = user.Employee;
            ChkEOD.Checked = user.EOD;
            ChkItemPricing.Checked = user.ItemPricing;
            ChkMember.Checked = user.Member;
            ChkPOS.Checked = user.POS;
            ChkReadOnly.Checked = user.IsReadOnly;
            ChkReports.Checked = user.Reports;
            ChkSettings.Checked = user.Settings;
            ChkStockSummary.Checked = user.StockSummary;
            ChkSupplier.Checked = user.Supplier;

            EnableFields();
            EnableFields(Action.PopulateUser);
            _isPasswordChanged = false;
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Load)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Add)
            {
                BtnSave.Enabled = true;

                TxtUsername.Enabled = true;
                TxtPassword.Enabled = true;
                TxtConfirmPassword.Enabled = true;
                ComboUserType.Enabled = true;

                ChkBank.Enabled = true;
                ChkDailyTransaction.Enabled = true;
                ChkDailySummary.Enabled = true;
                ChkEmployee.Enabled = true;
                ChkEOD.Enabled = true;
                ChkItemPricing.Enabled = true;
                ChkMember.Enabled = true;
                ChkPOS.Enabled = true;
                ChkReadOnly.Enabled = true;
                ChkReports.Enabled = true;
                ChkSettings.Enabled = true;
                ChkStockSummary.Enabled = true;
                ChkSupplier.Enabled = true;
            }
            else if (action == Action.Save)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                TxtUsername.Enabled = true;
                TxtPassword.Enabled = true;
                TxtConfirmPassword.Enabled = true;
                ComboUserType.Enabled = true;

                ChkBank.Enabled = true;
                ChkDailyTransaction.Enabled = true;
                ChkDailySummary.Enabled = true;
                ChkEmployee.Enabled = true;
                ChkEOD.Enabled = true;
                ChkItemPricing.Enabled = true;
                ChkMember.Enabled = true;
                ChkPOS.Enabled = true;
                ChkReadOnly.Enabled = true;
                ChkReports.Enabled = true;
                ChkSettings.Enabled = true;
                ChkStockSummary.Enabled = true;
                ChkSupplier.Enabled = true;

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
            else if (action == Action.PopulateUser)
            {
                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else
            {
                TxtUsername.Enabled = false;
                TxtPassword.Enabled = false;
                TxtConfirmPassword.Enabled = false;
                ComboUserType.Enabled = false;

                ChkBank.Enabled = false;
                ChkDailyTransaction.Enabled = false;
                ChkDailySummary.Enabled = false;
                ChkEmployee.Enabled = false;
                ChkEOD.Enabled = false;
                ChkItemPricing.Enabled = false;
                ChkMember.Enabled = false;
                ChkPOS.Enabled = false;
                ChkReadOnly.Enabled = false;
                ChkReports.Enabled = false;
                ChkSettings.Enabled = false;
                ChkStockSummary.Enabled = false;
                ChkSupplier.Enabled = false;

                BtnAdd.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }

        private void LoadUserTypes()
        {
            ComboUserType.Items.Clear();
            ComboUserType.ValueMember = "Id";
            ComboUserType.DisplayMember = "Value";

            ComboUserType.Items.Add(new ComboBoxItem { Id = Constants.ADMIN, Value = Constants.ADMIN });
            ComboUserType.Items.Add(new ComboBoxItem { Id = Constants.STAFF, Value = Constants.STAFF });
            ComboUserType.Items.Add(new ComboBoxItem { Id = Constants.GUEST, Value = Constants.GUEST });
        }
        #endregion

        #region Validation
        private bool ValidateUserInfo()
        {
            var isValidated = false;

            var username = TxtUsername.Text.Trim();
            var userType = ComboUserType.Text.Trim();
            var password = TxtPassword.Text.Trim();
            var confirmPassword = TxtConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username)
                || string.IsNullOrWhiteSpace(userType)
                || string.IsNullOrWhiteSpace(password)
                || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Username " +
                    "\n * User Type " +
                    "\n * Password " +
                    "\n * Confirm Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
