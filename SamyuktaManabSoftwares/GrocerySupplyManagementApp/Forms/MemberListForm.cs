using GrocerySupplyManagementApp.DTOs;
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
    public partial class MemberListForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly IMemberService _memberService;
        private readonly ICapitalService _capitalService;
        private readonly IMemberListForm _memberListForm;
        private List<MemberView> _memberViewList = new List<MemberView>();

        #region Constructor
        public MemberListForm(IMemberService memberService, ICapitalService capitalService,
            IMemberListForm memberListForm)
        {
            InitializeComponent();

            _memberService = memberService;
            _capitalService = capitalService;
            _memberListForm = memberListForm;
        }
        #endregion

        #region Form Load Event
        private void MemberListForm_Load(object sender, EventArgs e)
        {
            var memberViewList = GetMembers();
            LoadMembers(memberViewList);
            RichSearchMemberName.Select();
        }
        #endregion

        #region Data Grid Event
        private void DataGridMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }
            else if (dgv.SelectedRows.Count == 1)
            {
                var selectedRow = dgv.SelectedRows[0];
                string memberId = selectedRow.Cells["MemberId"].Value.ToString();
                _memberListForm.PopulateMember(memberId);
                Close();
            }
            else if (e.RowIndex > -1 && e.ColumnIndex > -1 && DataGridMemberList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var selectedRow = DataGridMemberList.CurrentRow;
                string memberId = selectedRow.Cells["MemberId"].Value.ToString();
                _memberListForm.PopulateMember(memberId);
                Close();
            }
        }

        private void DataGridMemberList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridMemberList.Columns["Id"].Visible = false;
            DataGridMemberList.Columns["Address"].Visible = false;
            DataGridMemberList.Columns["ContactNo"].Visible = false;
            DataGridMemberList.Columns["Email"].Visible = false;
            DataGridMemberList.Columns["AddedDate"].Visible = false;

            DataGridMemberList.Columns["MemberId"].HeaderText = "MemberId";
            DataGridMemberList.Columns["MemberId"].Width = 80;
            DataGridMemberList.Columns["MemberId"].DisplayIndex = 0;

            DataGridMemberList.Columns["AccountNo"].HeaderText = "AccountNo";
            DataGridMemberList.Columns["AccountNo"].Width = 80;
            DataGridMemberList.Columns["AccountNo"].DisplayIndex = 1;

            DataGridMemberList.Columns["Name"].HeaderText = "Name";
            DataGridMemberList.Columns["Name"].Width = 195;
            DataGridMemberList.Columns["Name"].DisplayIndex = 2;

            DataGridMemberList.Columns["Balance"].HeaderText = "Balance";
            DataGridMemberList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridMemberList.Columns["Balance"].DisplayIndex = 3;
            DataGridMemberList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridMemberList.Rows)
            {
                DataGridMemberList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridMemberList.RowHeadersWidth = 50;
                DataGridMemberList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        #endregion

        #region Helper Methods
        private List<MemberView> GetMembers()
        {
            var members = _memberService.GetMembers();
            _memberViewList = members.ToList().Select(x => new MemberView()
            {
                Id = x.Id,
                MemberId = x.MemberId,
                Name = x.Name,
                Address = x.Address,
                ContactNo = x.ContactNo,
                Email = x.Email,
                AccountNo = x.AccountNo,
                AddedDate = x.AddedDate,
                Balance = _capitalService.GetMemberTotalBalance(new UserTransactionFilter() { MemberId = x.MemberId }),
            }).OrderBy(x => x.MemberId).ToList();

            return _memberViewList;
        }

        private void LoadMembers(List<MemberView> memberViewList)
        {
            var bindingList = new BindingList<MemberView>(memberViewList);
            var source = new BindingSource(bindingList, null);
            DataGridMemberList.DataSource = source;
        }

        private void SearchMembers()
        {
            var memberName = RichSearchMemberName.Text;
            var memberId = RichSearchMemberId.Text;

            var members = _memberViewList.Where(x => x.Name.ToLower().StartsWith(memberName.ToLower()) && x.MemberId.ToLower().StartsWith(memberId.ToLower())).ToList();
            LoadMembers(members);
        }
        #endregion

        #region Rich Textbox Event
        private void RichSearchMemberName_KeyUp(object sender, KeyEventArgs e)
        {
            SearchMembers();
        }

        private void RichSearchMemberId_KeyUp(object sender, KeyEventArgs e)
        {
            SearchMembers();
        }
        #endregion
    }
}
