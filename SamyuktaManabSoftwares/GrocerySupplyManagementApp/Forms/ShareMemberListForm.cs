using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ShareMemberListForm : Form
    {
        private readonly IShareMemberService _shareMemberService;
        private readonly IShareMemberListForm _shareMemberListForm;
        private List<ShareMemberView> _shareMemberViewList = new List<ShareMemberView>();

        public ShareMemberListForm(IShareMemberService shareMemberService,
            IShareMemberListForm shareMemberListForm)
        {
            InitializeComponent();
            _shareMemberService = shareMemberService;
            _shareMemberListForm = shareMemberListForm;
        }

        #region Form Load Event
        private void ShareMemberListForm_Load(object sender, EventArgs e)
        {
            var shareMemberViewList = GetShareMembers();
            LoadShareViewList(shareMemberViewList);
            RichSearchMemberName.Select();
        }
        #endregion

        #region Rich Textbox Event
        private void RichSearchMemberName_KeyUp(object sender, KeyEventArgs e)
        {
            SearchShareMemberTransactionViewList();
        }
        #endregion

        #region Data Grid Event
        private void DataGridShareMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }
            else if (dgv.SelectedRows.Count == 1)
            {
                var selectedRow = dgv.SelectedRows[0];
                long shareMemberId = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                _shareMemberListForm.PopulateShareMember(shareMemberId);
                Close();
            }
            else if (e.RowIndex > -1 && e.ColumnIndex > -1 && DataGridShareMemberList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var selectedRow = DataGridShareMemberList.CurrentRow;
                long shareMemberId = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                _shareMemberListForm.PopulateShareMember(shareMemberId);
                Close();
            }
        }

        private void DataGridShareMemberList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridShareMemberList.Columns["Id"].Visible = false;

            DataGridShareMemberList.Columns["Name"].HeaderText = "Name";
            DataGridShareMemberList.Columns["Name"].Width = 150;
            DataGridShareMemberList.Columns["Name"].DisplayIndex = 0;

            DataGridShareMemberList.Columns["ContactNo"].HeaderText = "Contact No";
            DataGridShareMemberList.Columns["ContactNo"].Width = 150;
            DataGridShareMemberList.Columns["ContactNo"].DisplayIndex = 1;
            DataGridShareMemberList.Columns["ContactNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridShareMemberList.Columns["Balance"].HeaderText = "Balance";
            DataGridShareMemberList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridShareMemberList.Columns["Balance"].DisplayIndex = 2;
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
        private List<ShareMemberView> GetShareMembers()
        {
            _shareMemberViewList = _shareMemberService.GetShareMembers().ToList();
            return _shareMemberViewList;
        }

        private void LoadShareViewList(List<ShareMemberView> shareMemberViewList)
        {
            var bindingList = new BindingList<ShareMemberView>(shareMemberViewList);
            var source = new BindingSource(bindingList, null);
            DataGridShareMemberList.DataSource = source;
        }

        private void SearchShareMemberTransactionViewList()
        {
            var shareMemberName = RichSearchMemberName.Text.Trim();

            var shareMemberViewList = _shareMemberViewList.Where(x => x.Name.ToLower().StartsWith(shareMemberName.ToLower())).ToList();
            LoadShareViewList(shareMemberViewList);
        }

        #endregion
    }
}
