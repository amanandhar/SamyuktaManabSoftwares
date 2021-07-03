using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class BankListForm : Form
    {
        private readonly IBankDetailService _bankDetailService;
        private IBankListForm _bankListForm;
        public BankListForm(IBankDetailService bankDetailService, IBankListForm bankListForm)
        {
            InitializeComponent();

            _bankDetailService = bankDetailService;
            _bankListForm = bankListForm;
        }

        private void BankListForm_Load(object sender, EventArgs e)
        {
            var bankDetails = _bankDetailService.GetBankDetails();

            var bindingList = new BindingList<BankDetail>(bankDetails.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridBankDetails.DataSource = source;
        }

        private void DataGridBankDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }

            if (dgv.CurrentRow.Selected)
            {
                long bankId = Convert.ToInt64(dgv.CurrentRow.Cells["Id"].Value.ToString());
                _bankListForm.PopulateBank(bankId);
                this.Close();
            }
        }

        private void DataGridBankDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridBankDetails.Columns["Id"].Visible = false;

            //Add Columns
            DataGridBankDetails.Columns["Name"].HeaderText = "Bank Name";
            DataGridBankDetails.Columns["Name"].Width = 250;
            DataGridBankDetails.Columns["Name"].DisplayIndex = 0;

            DataGridBankDetails.Columns["AccountNo"].HeaderText = "Account No";
            DataGridBankDetails.Columns["AccountNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridBankDetails.Columns["AccountNo"].DisplayIndex = 1;

            DataGridBankDetails.Columns["Date"].Visible = false;

            foreach (DataGridViewRow row in DataGridBankDetails.Rows)
            {
                DataGridBankDetails.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridBankDetails.RowHeadersWidth = 50;
            }
        }
    }
}
