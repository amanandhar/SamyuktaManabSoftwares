using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly IUserTransactionService _userTransactionService;
        private readonly IShareMemberListForm _shareMemberListForm;
        private List<ShareMemberTransactionView> _shareMemberTransactionViewList = new List<ShareMemberTransactionView>();
        
        public ShareMemberListForm(IUserTransactionService userTransactionService, 
            IShareMemberListForm shareMemberListForm)
        {
            InitializeComponent();
            _userTransactionService = userTransactionService;
            _shareMemberListForm = shareMemberListForm;
        }

        #region Form Load Event
        private void ShareMemberListForm_Load(object sender, EventArgs e)
        {
            var shareMemberTransactionViewList = GetShareMemberTransactionViewList();
            LoadShareTransactionViewList(shareMemberTransactionViewList);
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
            else if (dgv.SelectedRows.Count == 1)
            {
                var selectedRow = dgv.SelectedRows[0];
                string shareMemberId = selectedRow.Cells["ShareMemberId"].Value.ToString();
                _shareMemberListForm.PopulateShareMember(shareMemberId);
                Close();
            }
            else if (e.RowIndex > -1 && e.ColumnIndex > -1 && DataGridShareMemberList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var selectedRow = DataGridShareMemberList.CurrentRow;
                string shareMemberId = selectedRow.Cells["ShareMemberId"].Value.ToString();
                _shareMemberListForm.PopulateShareMember(shareMemberId);
                Close();
            }
        }

        private void DataGridShareMemberList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridShareMemberList.Columns["Id"].Visible = false;
            DataGridShareMemberList.Columns["EndOfDay"].Visible = false;
            DataGridShareMemberList.Columns["ShareMemberId"].Visible = false;
            DataGridShareMemberList.Columns["Description"].Visible = false;
            DataGridShareMemberList.Columns["Type"].Visible = false;
            DataGridShareMemberList.Columns["Debit"].Visible = false;
            DataGridShareMemberList.Columns["Credit"].Visible = false;

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

        #region Rich Textbox Event
        private void RichSearchMemberName_KeyUp(object sender, KeyEventArgs e)
        {
            SearchShareMemberTransactionViewList();
        }
        #endregion

        #region Helper Methods
        private List<ShareMemberTransactionView> GetShareMemberTransactionViewList()
        {
            _shareMemberTransactionViewList = _userTransactionService.GetShareMemberTransactions(new ShareMemberTransactionFilter()).ToList();
            return _shareMemberTransactionViewList;
        }

        private void LoadShareTransactionViewList(List<ShareMemberTransactionView> shareMemberTransactionViewList)
        {
            var bindingList = new BindingList<ShareMemberTransactionView>(shareMemberTransactionViewList);
            var source = new BindingSource(bindingList, null);
            DataGridShareMemberList.DataSource = source;
        }

        private void SearchShareMemberTransactionViewList()
        {
            var shareMemberName = RichSearchMemberName.Text;

            var shareMemberTransactionViewList = _shareMemberTransactionViewList.Where(x => x.Name.ToLower().StartsWith(shareMemberName.ToLower())).ToList();
            LoadShareTransactionViewList(shareMemberTransactionViewList);
        }

        #endregion
    }
}
