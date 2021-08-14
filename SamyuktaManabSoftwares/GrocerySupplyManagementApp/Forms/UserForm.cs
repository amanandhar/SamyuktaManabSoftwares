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
        private readonly IUserService _userService;

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
        public UserForm(IUserService userService)
        {
            InitializeComponent();

            _userService = userService;
        }
        #endregion

        #region Form Load Event
        private void UserForm_Load(object sender, System.EventArgs e)
        {
            EnableFields(Action.Load);
            LoadUserTypes();
        }
        #endregion

        #region Button Click Event
        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            ClearAllFields();
            EnableFields();
            EnableFields(Action.Add);
            RichUsername.Focus();
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                var date = DateTime.Now;
                var user = new User
                {
                    Username = RichUsername.Text,
                    Password = TxtPassword.Text,
                    Type = ComboUserType.Text,
                    Bank = ChkBank.Checked,
                    DailyExpense = ChkDailyExpense.Checked,
                    DailySummary = ChkDailySummary.Checked,
                    Employee = ChkEmployee.Checked,
                    EOD = ChkEOD.Checked,
                    ItemPricing = ChkItemPricing.Checked,
                    Member = ChkMember.Checked,
                    POS = ChkPOS.Checked,
                    IsReadOnly = ChkReadOnly.Checked,
                    Report = ChkReport.Checked,
                    Setting = ChkSetting.Checked,
                    Stock = ChkStock.Checked,
                    Supplier = ChkSupplier.Checked,
                    AddedDate = date,
                    UpdatedDate = date
                };

                _userService.AddUser(user);

                DialogResult result = MessageBox.Show(user.Username + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields();
                    EnableFields(Action.Save);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnEdit_Click(object sender, System.EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Edit);
        }

        private void BtnUpdate_Click(object sender, System.EventArgs e)
        {
            var username = RichUsername.Text;
            try
            {
                var date = DateTime.Now;
                var user = new User
                {
                    Username = RichUsername.Text,
                    Password = TxtPassword.Text,
                    Type = ComboUserType.Text,
                    Bank = ChkBank.Checked,
                    DailyExpense = ChkDailyExpense.Checked,
                    DailySummary = ChkDailySummary.Checked,
                    Employee = ChkEmployee.Checked,
                    EOD = ChkEOD.Checked,
                    ItemPricing = ChkItemPricing.Checked,
                    Member = ChkMember.Checked,
                    POS = ChkPOS.Checked,
                    IsReadOnly = ChkReadOnly.Checked,
                    Report = ChkReport.Checked,
                    Setting = ChkSetting.Checked,
                    Stock = ChkStock.Checked,
                    Supplier = ChkSupplier.Checked,
                    UpdatedDate = date
                };

                _userService.UpdateUser(username, user);
                DialogResult result = MessageBox.Show(username + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields();
                    EnableFields(Action.Update);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                DialogResult deleteResult = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (deleteResult == DialogResult.Yes)
                {
                    var username = RichUsername.Text;
                    if (_userService.DeleteUser(username))
                    {
                        DialogResult result = MessageBox.Show(username + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
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
                throw ex;
            }
        }

        private void BtnShow_Click(object sender, System.EventArgs e)
        {
            UserListForm userListForm = new UserListForm(_userService, this);
            userListForm.ShowDialog();
        }
        #endregion

        #region Checkbox Event
        private void ChkPOS_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void ChkDailySummary_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void ChkMember_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void ChkSupplier_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void ChkItemPricing_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void ChkStock_CheckedChanged(object sender, System.EventArgs e)
        {
            
        }

        private void ChkDailyExpense_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void ChkBank_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void ChkSetting_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void ChkReport_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void ChkEmployee_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void ChkEOD_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void ChkReadOnly_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        #endregion

        #region Helper Methods
        private void ClearAllFields()
        {
            RichUsername.Clear();
            TxtPassword.Clear();
            TxtConfirmPassword.Clear();
            ComboUserType.Text = string.Empty;
            ChkBank.Checked = false;
            ChkPOS.Checked = false;
            ChkDailyExpense.Checked = false;
            ChkDailySummary.Checked = false;
            ChkMember.Checked = false;
            ChkSupplier.Checked = false;
            ChkItemPricing.Checked = false;
            ChkStock.Checked = false;
            ChkSetting.Checked = false;
            ChkReport.Checked = false;
            ChkEOD.Checked = false;
            ChkEmployee.Checked = false;
            ChkEOD.Checked = false;
        }

        public void PopulateUser(long id)
        {
            var user = _userService.GetUser(id);

            RichUsername.Text = user.Username;
            ComboUserType.Text = user.Type;
            TxtPassword.Text = user.Password;
            TxtConfirmPassword.Text = user.Password;

            ChkBank.Checked = user.Bank;
            ChkDailyExpense.Checked = user.DailyExpense;
            ChkDailySummary.Checked = user.DailySummary;
            ChkEmployee.Checked = user.Employee;
            ChkEOD.Checked = user.EOD;
            ChkItemPricing.Checked = user.ItemPricing;
            ChkMember.Checked = user.Member;
            ChkPOS.Checked = user.POS;
            ChkReadOnly.Checked = user.IsReadOnly;
            ChkReport.Checked = user.Report;
            ChkSetting.Checked = user.Setting;
            ChkStock.Checked = user.Stock;
            ChkSupplier.Checked = user.Supplier;

            EnableFields();
            EnableFields(Action.PopulateUser);
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
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;

                RichUsername.Enabled = true;
                TxtPassword.Enabled = true;
                TxtConfirmPassword.Enabled = true;
                ComboUserType.Enabled = true;

                ChkBank.Enabled = true;
                ChkDailyExpense.Enabled = true;
                ChkDailySummary.Enabled = true;
                ChkEmployee.Enabled = true;
                ChkEOD.Enabled = true;
                ChkItemPricing.Enabled = true;
                ChkMember.Enabled = true;
                ChkPOS.Enabled = true;
                ChkReadOnly.Enabled = true;
                ChkReport.Enabled = true;
                ChkSetting.Enabled = true;
                ChkStock.Enabled = true;
                ChkSupplier.Enabled = true;
            }
            else if (action == Action.Save)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                BtnAdd.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;

                RichUsername.Enabled = true;
                TxtPassword.Enabled = true;
                TxtConfirmPassword.Enabled = true;
                ComboUserType.Enabled = true;

                ChkBank.Enabled = true;
                ChkDailyExpense.Enabled = true;
                ChkDailySummary.Enabled = true;
                ChkEmployee.Enabled = true;
                ChkEOD.Enabled = true;
                ChkItemPricing.Enabled = true;
                ChkMember.Enabled = true;
                ChkPOS.Enabled = true;
                ChkReadOnly.Enabled = true;
                ChkReport.Enabled = true;
                ChkSetting.Enabled = true;
                ChkStock.Enabled = true;
                ChkSupplier.Enabled = true;
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
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else
            {
                BtnAdd.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;

                RichUsername.Enabled = false;
                TxtPassword.Enabled = false;
                TxtConfirmPassword.Enabled = false;
                ComboUserType.Enabled = false;

                ChkBank.Enabled = false;
                ChkDailyExpense.Enabled = false;
                ChkDailySummary.Enabled = false;
                ChkEmployee.Enabled = false;
                ChkEOD.Enabled = false;
                ChkItemPricing.Enabled = false;
                ChkMember.Enabled = false;
                ChkPOS.Enabled = false;
                ChkReadOnly.Enabled = false;
                ChkReport.Enabled = false;
                ChkSetting.Enabled = false;
                ChkStock.Enabled = false;
                ChkSupplier.Enabled = false;
            }
        }

        private void LoadUserTypes()
        {
            ComboUserType.ValueMember = "Id";
            ComboUserType.DisplayMember = "Value";

            ComboUserType.Items.Add(new ComboBoxItem { Id = Constants.ADMIN, Value = Constants.ADMIN });
            ComboUserType.Items.Add(new ComboBoxItem { Id = Constants.GENERAL, Value = Constants.GENERAL });
            ComboUserType.Items.Add(new ComboBoxItem { Id = Constants.GUEST, Value = Constants.GUEST });
        }
        #endregion
    }
}
