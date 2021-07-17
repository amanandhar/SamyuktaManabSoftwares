﻿using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class BankListForm : Form
    {
        private readonly IBankService _bankService;
        private IBankListForm _bankListForm;

        #region Constructor
        public BankListForm(IBankService bankService, IBankListForm bankListForm)
        {
            InitializeComponent();

            _bankService = bankService;
            _bankListForm = bankListForm;
        }
        #endregion

        #region Form Load Event
        private void BankListForm_Load(object sender, EventArgs e)
        {
            var banks = _bankService.GetBanks();

            var bindingList = new BindingList<Bank>(banks.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridBankList.DataSource = source;
        }
        #endregion

        #region Data Grid Event
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
            DataGridBankList.Columns["Id"].Visible = false;

            //Add Columns
            DataGridBankList.Columns["Name"].HeaderText = "Bank Name";
            DataGridBankList.Columns["Name"].Width = 250;
            DataGridBankList.Columns["Name"].DisplayIndex = 0;

            DataGridBankList.Columns["AccountNo"].HeaderText = "Account No";
            DataGridBankList.Columns["AccountNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridBankList.Columns["AccountNo"].DisplayIndex = 1;

            DataGridBankList.Columns["Date"].Visible = false;

            foreach (DataGridViewRow row in DataGridBankList.Rows)
            {
                DataGridBankList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridBankList.RowHeadersWidth = 50;
                DataGridBankList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion
    }
}
