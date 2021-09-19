using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
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
        private List<ShareMember> _shareMemberList = new List<ShareMember>();
        
        public ShareMemberListForm(IShareMemberService shareMemberService, IShareMemberListForm shareMemberListForm)
        {
            InitializeComponent();
            _shareMemberService = shareMemberService;
            _shareMemberListForm = shareMemberListForm;
        }

        #region Form Load Event
        private void ShareMemberListForm_Load(object sender, EventArgs e)
        {
            var shareMembers = GetShareMembers();
            LoadShareMembers(shareMembers);
            RichSearchMemberName.Focus();
        }
        #endregion

        #region Data Grid Event
        private void DataGridShareMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }

            if (dgv.SelectedRows.Count == 1)
            {
                var selectedRow = dgv.SelectedRows[0];
                long shareMemberId = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                _shareMemberListForm.PopulateShareMember(shareMemberId);
                Close();
            }
        }

        private void DataGridShareMemberList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridShareMemberList.Columns["Id"].Visible = false;
            DataGridShareMemberList.Columns["ImagePath"].Visible = false;
            DataGridShareMemberList.Columns["AddedDate"].Visible = false;
            DataGridShareMemberList.Columns["UpdatedDate"].Visible = false;

            DataGridShareMemberList.Columns["Name"].HeaderText = "Name";
            DataGridShareMemberList.Columns["Name"].Width = 85;
            DataGridShareMemberList.Columns["Name"].DisplayIndex = 0;

            DataGridShareMemberList.Columns["Address"].HeaderText = "Address";
            DataGridShareMemberList.Columns["Address"].Width = 85;
            DataGridShareMemberList.Columns["Address"].DisplayIndex = 1;

            DataGridShareMemberList.Columns["ContactNo"].HeaderText = "ContactNo";
            DataGridShareMemberList.Columns["ContactNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridShareMemberList.Columns["ContactNo"].DisplayIndex = 3;
            DataGridShareMemberList.Columns["ContactNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridShareMemberList.Rows)
            {
                DataGridShareMemberList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridShareMemberList.RowHeadersWidth = 50;
                DataGridShareMemberList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Rich Textbox Event
        private void RichSearchMemberName_KeyUp(object sender, KeyEventArgs e)
        {
            SearchShareMembers();
        }

        private void RichSearchMemberId_KeyUp(object sender, KeyEventArgs e)
        {
            SearchShareMembers();
        }
        #endregion

        #region Helper Methods
        private List<ShareMember> GetShareMembers()
        {
            var _shareMemberList = _shareMemberService.GetShareMembers().ToList();
            return _shareMemberList;
        }

        private void LoadShareMembers(List<ShareMember> shareMembers)
        {
            var bindingList = new BindingList<ShareMember>(shareMembers);
            var source = new BindingSource(bindingList, null);
            DataGridShareMemberList.DataSource = source;
        }

        private void SearchShareMembers()
        {
            var shareMemberName = RichSearchMemberName.Text;

            var shareMembers = _shareMemberList.Where(x => x.Name.ToLower().StartsWith(shareMemberName.ToLower())).ToList();
            LoadShareMembers(shareMembers);
        }
        #endregion
    }
}
