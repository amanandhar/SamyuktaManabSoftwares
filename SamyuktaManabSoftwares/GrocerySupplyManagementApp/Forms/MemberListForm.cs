using GrocerySupplyManagementApp.DTOs;
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
        public MemberForm _memberForm;

        public MemberListForm(IMemberService memberService, MemberForm memberForm)
        {
            InitializeComponent();

            _memberService = memberService;
            _memberForm = memberForm;
        }

        private void MemberListForm_Load(object sender, EventArgs e)
        {
            var members = _memberService.GetMembers();

            var bindingList = new BindingList<Member>(members.ToList());
            var source = new BindingSource(bindingList, null);

            DataGridMemberList.AutoGenerateColumns = false;

            //Set Columns Count
            DataGridMemberList.ColumnCount = 2;

            //Add Columns
            DataGridMemberList.Columns[0].Name = "MemberId";
            DataGridMemberList.Columns[0].HeaderText = "Member Id";
            DataGridMemberList.Columns[0].DataPropertyName = "MemberId";
            DataGridMemberList.Columns[0].Width = 100;

            DataGridMemberList.Columns[1].Name = "Name";
            DataGridMemberList.Columns[1].HeaderText = "Name";
            DataGridMemberList.Columns[1].DataPropertyName = "Name";
            DataGridMemberList.Columns[1].Width = 250;

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
                _memberForm.PopulateMember(memberId);
                this.Close();
            }
        }
    }
}
