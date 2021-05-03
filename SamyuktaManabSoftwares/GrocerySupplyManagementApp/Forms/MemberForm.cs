using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class MemberForm : Form
    {
        private readonly IMemberService _memberService;
        public DashboardForm _dashboard;

        public MemberForm(IMemberService memberService, DashboardForm dashboardForm)
        {
            InitializeComponent();

            _memberService = memberService;
            _dashboard = dashboardForm;
        }

        #region Load Event
        private void MemberForm_Load(object sender, System.EventArgs e)
        {
            ClearAllFields();
            EnableFields(false);
            LoadMembers();
        }
        #endregion

        #region Button Events
        private void BtnShowMember_Click(object sender, EventArgs e)
        {
            MemberListForm memberListForm = new MemberListForm(_memberService, this);
            memberListForm.Show();
        }

        private void BtnAddMember_Click(object sender, System.EventArgs e)
        {
            ClearAllFields();
            EnableFields(true);
            var memberId = _memberService.GetNewMemberId();
            RichMemberId.Text = memberId;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = _memberService.AddMember(new Member
                {
                    MemberId = RichMemberId.Text,
                    Name = RichName.Text,
                    Address = RichAddress.Text,
                    ContactNumber = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text,
                    AccountNumber = RichAccountNumber.Text
                }); ;

                DialogResult result = MessageBox.Show(member.MemberId + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    LoadMembers();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields(true);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var memberId = RichMemberId.Text;
            try
            {
                var member = _memberService.UpdateMember(memberId, new Member
                {
                    MemberId = RichMemberId.Text,
                    Name = RichName.Text,
                    Address = RichAddress.Text,
                    ContactNumber = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text,
                    AccountNumber = RichAccountNumber.Text
                }); ;

                DialogResult result = MessageBox.Show(memberId + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    LoadMembers();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var memberId = RichMemberId.Text;
            _memberService.DeleteMember(memberId);

            DialogResult result = MessageBox.Show(memberId + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                ClearAllFields();
                LoadMembers();
            }
        }

        private void BtnClearAll_Click(object sender, System.EventArgs e)
        {
            ClearAllFields();
        }

        #endregion

        #region Helper Methods
        private void EnableFields(bool option = true)
        {
            RichMemberId.Enabled = option;
            RichName.Enabled = option;
            RichAddress.Enabled = option;
            RichContactNumber.Enabled = option;
            RichEmail.Enabled = option;
            RichAccountNumber.Enabled = option;
        }

        private void ClearAllFields()
        {
            RichMemberId.Clear();
            RichAccountNumber.Clear();
            RichName.Clear();
            RichAddress.Clear();
            ComboRepayType.SelectedIndex = 0;
            //ComboBank.SelectedIndex = 0;
            RichContactNumber.Clear();
            RichEmail.Clear();
            RichBalance.Clear();
            RichInvoiceNumber.Clear();
            RichAmount.Clear();
        }

        private void LoadMembers()
        {
            return;
            /*
            try
            {
                DataGridMemberList.DataSource = _memberService.GetMembers();
                DataGridMemberList.Columns[0].Visible = false;
                DataGridMemberList.Columns[1].HeaderText = "Member Id";
                DataGridMemberList.Columns[1].Width = 80;
                DataGridMemberList.Columns[2].HeaderText = "Name";
                DataGridMemberList.Columns[2].Width = 150;
                DataGridMemberList.Columns[3].HeaderText = "Address";
                DataGridMemberList.Columns[3].Width = 150;
                DataGridMemberList.Columns[4].HeaderText = "Contact Number";
                DataGridMemberList.Columns[4].Width = 125;
                DataGridMemberList.Columns[5].HeaderText = "Email";
                DataGridMemberList.Columns[5].Width = 150;
                DataGridMemberList.Columns[6].HeaderText = "Account Number";
                DataGridMemberList.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            */
        }

        public void PopulateMember(string memberId)
        {
            var member = _memberService.GetMember(memberId);

            RichMemberId.Text = member.MemberId;
            RichName.Text = member.Name;
            RichAddress.Text = member.Address;
            RichContactNumber.Text = member.ContactNumber.ToString();
            RichEmail.Text = member.Email;
            RichAccountNumber.Text = member.AccountNumber;

            EnableFields(false);
        }
        #endregion
    }
}
