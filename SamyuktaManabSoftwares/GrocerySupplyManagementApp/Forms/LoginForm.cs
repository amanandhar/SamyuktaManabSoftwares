using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        public string Username { get; private set; }

        #region Constructor
        public LoginForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }
        #endregion

        #region Form Load Event
        private void LoginForm_Load(object sender, EventArgs e)
        {
            TxtUsername.Focus();
        }
        #endregion

        #region Radio Button Event
        private void ChkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkBoxShow.Checked == true)
            {
                TxtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = true;
            }
        }

        #endregion

        #region Button Event
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Textbox Event
        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                Login();
            }
        }

        #endregion

        #region Helper Methods
        private void Login()
        {
            try
            {
                var username = TxtUsername.Text;
                var password = TxtPassword.Text;

                if (string.IsNullOrWhiteSpace(username.Trim()) || string.IsNullOrWhiteSpace(password.Trim()))
                {
                    var error = MessageBox.Show("Username or Password is empty.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (error == DialogResult.OK)
                    {
                        return;
                    }
                }

                var encryptedPassword = Cryptography.Encrypt(password);
                var result = _userService.IsUserExist(username, encryptedPassword);
                if (result)
                {
                    Username = username;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    var error = MessageBox.Show("Username or Password is invalid.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (error == DialogResult.OK)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
