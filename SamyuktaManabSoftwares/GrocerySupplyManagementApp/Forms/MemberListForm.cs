using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class MemberListForm : Form
    {
        private readonly IMemberService _memberService;
        private readonly IPosTransactionService _posTransactionService;
        public IMemberListForm _memberListForm;

        public MemberListForm(IMemberService memberService, IPosTransactionService posTransactionService, IMemberListForm memberListForm)
        {
            InitializeComponent();

            _memberService = memberService;
            _posTransactionService = posTransactionService;
            _memberListForm = memberListForm;
        }

        private void MemberListForm_Load(object sender, EventArgs e)
        {
            var members = _memberService.GetMembers();

            members.ToList().ForEach(x => x.Balance = _posTransactionService.GetMemberTotalBalance(x.MemberId));

            var bindingList = new BindingList<Member>(members.ToList());
            var source = new BindingSource(bindingList, null);

            DataGridMemberList.AutoGenerateColumns = false;

            //Set Columns Count
            DataGridMemberList.ColumnCount = 4;

            //Add Columns
            DataGridMemberList.Columns[0].Name = "MemberId";
            DataGridMemberList.Columns[0].HeaderText = "Member Id";
            DataGridMemberList.Columns[0].DataPropertyName = "MemberId";
            DataGridMemberList.Columns[0].Width = 90;

            DataGridMemberList.Columns[1].Name = "AccountNumber";
            DataGridMemberList.Columns[1].HeaderText = "Account No";
            DataGridMemberList.Columns[1].DataPropertyName = "AccountNumber";
            DataGridMemberList.Columns[1].Width = 90;

            DataGridMemberList.Columns[2].Name = "Name";
            DataGridMemberList.Columns[2].HeaderText = "Name";
            DataGridMemberList.Columns[2].DataPropertyName = "Name";
            DataGridMemberList.Columns[2].Width = 180;

            DataGridMemberList.Columns[3].Name = "Balance";
            DataGridMemberList.Columns[3].HeaderText = "Balance";
            DataGridMemberList.Columns[3].DataPropertyName = "Balance";
            DataGridMemberList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridMemberList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridMemberList.DataSource = source;
        }

        private void DataGridMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                string memberId = dgv.CurrentRow.Cells[0].Value.ToString();
                _memberListForm.PopulateMember(memberId);
                this.Close();
            }
        }
    }
}
