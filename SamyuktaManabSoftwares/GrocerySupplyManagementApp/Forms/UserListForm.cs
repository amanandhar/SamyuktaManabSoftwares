using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class UserListForm : Form
    {
        private readonly IUserService _userService;
        public IUserListForm _userListForm; 

        #region Constructor 
        public UserListForm(IUserService userService, IUserListForm userListForm)
        {
            InitializeComponent();

            _userService = userService;
            _userListForm = userListForm;
        }
        #endregion

        #region Form Load Event
        private void UserListForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }
        #endregion

        #region Data Grid Event
        private void DataGridUserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }

            if (dgv.SelectedRows.Count == 1)
            {
                var selectedRow = dgv.SelectedRows[0];
                long id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                _userListForm.PopulateUser(id);
                Close();
            }
        }

        private void DataGridUserList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridUserList.Columns["Id"].Visible = false;
            DataGridUserList.Columns["Password"].Visible = false;
            DataGridUserList.Columns["IsReadOnly"].Visible = false;
            DataGridUserList.Columns["Bank"].Visible = false;
            DataGridUserList.Columns["DailySummary"].Visible = false;
            DataGridUserList.Columns["DailyTransaction"].Visible = false;
            DataGridUserList.Columns["Employee"].Visible = false;
            DataGridUserList.Columns["EOD"].Visible = false;
            DataGridUserList.Columns["ItemPricing"].Visible = false;
            DataGridUserList.Columns["Member"].Visible = false;
            DataGridUserList.Columns["POS"].Visible = false;
            DataGridUserList.Columns["Reports"].Visible = false;
            DataGridUserList.Columns["Settings"].Visible = false;
            DataGridUserList.Columns["StockSummary"].Visible = false;
            DataGridUserList.Columns["Supplier"].Visible = false;
            DataGridUserList.Columns["AddedDate"].Visible = false;
            DataGridUserList.Columns["UpdatedDate"].Visible = false;

            DataGridUserList.Columns["Username"].HeaderText = "Username";
            DataGridUserList.Columns["Username"].Width = 180;
            DataGridUserList.Columns["Username"].DisplayIndex = 0;

            DataGridUserList.Columns["Type"].HeaderText = "Type";
            DataGridUserList.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridUserList.Columns["Type"].DisplayIndex = 1;

            foreach (DataGridViewRow row in DataGridUserList.Rows)
            {
                DataGridUserList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridUserList.RowHeadersWidth = 50;
                DataGridUserList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadUsers()
        {
            var users = _userService.GetUsers().ToList();
            
            var bindingList = new BindingList<User>(users);
            var source = new BindingSource(bindingList, null);
            DataGridUserList.DataSource = source;
        }
        #endregion

    }
}
