using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SetPasswordForm : Form
    {
        private readonly IUserService _userService;

        private readonly string _username;

        #region Constructor
        public SetPasswordForm(string username,
            IUserService userService)
        {
            InitializeComponent();

            _userService = userService;

            _username = username;
        }
        #endregion

        #region Form Load Event
        private void SetPasswordForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }
        #endregion

        #region Button Event
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var username = ComboUsername.Text;
                var password = TxtPassword.Text;
                var confirmPassword = TxtConfirmPassword.Text;

                if (string.IsNullOrWhiteSpace(username.Trim()))
                {
                    var errorResult = MessageBox.Show("Username is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (errorResult == DialogResult.OK)
                    {
                        ComboUsername.Select();
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

                    var result = _userService.UpdatePassword(username, Cryptography.Encrypt(password), _username, DateTime.Now);
                    if(result)
                    {
                        var infoResult = MessageBox.Show("Password update successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (infoResult == DialogResult.OK)
                        {
                            ClearFields();
                            ComboUsername.Select();
                        }
                    }
                    else
                    {
                        var errorResult = MessageBox.Show("Error while updating password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            TxtPassword.Select();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Textbox Event
        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                TxtConfirmPassword.Focus();
            }
        }
        #endregion

        #region Combo Box Event
        private void ComboUsername_SelectedValueChanged(object sender, EventArgs e)
        {
            TxtPassword.Focus();
        }
        #endregion

        #region Helper Methods
        private void LoadUsers()
        {
            var users = _userService.GetUsers().ToList();
            if (users.Count > 0)
            {
                ComboUsername.ValueMember = "Id";
                ComboUsername.DisplayMember = "Value";
                users.OrderBy(x => x.Username).ToList().ForEach(x =>
                {
                    ComboUsername.Items.Add(new ComboBoxItem { Id = x.Username, Value = x.Username });
                });
            }
        }

        private void ClearFields()
        {
            ComboUsername.Text = string.Empty;
            TxtPassword.Clear();
            TxtConfirmPassword.Clear();
        }

        #endregion
    }
}
