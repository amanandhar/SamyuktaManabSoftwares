﻿using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SalesPurchaseForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;

        #region Constructor
        public SalesPurchaseForm(IFiscalYearService fiscalYearService, IUserTransactionService userTransactionService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _userTransactionService = userTransactionService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }
        #endregion

        #region Form Load Event
        private void SalesPurchaseForm_Load(object sender, System.EventArgs e)
        {
            MaskDtEODFrom.Text = _endOfDay;
            MaskDtEODTo.Text = _endOfDay;

            LoadActions();
        }
        #endregion

        #region Button Event
        private void BtnShow_Click(object sender, System.EventArgs e)
        {
            LoadTransactions();
        }
        #endregion

        #region Radio Button Event
        private void RadioAll_CheckedChanged(object sender, System.EventArgs e)
        {
            MaskDtEODFrom.Clear();
            MaskDtEODTo.Clear();
        }
        #endregion

        #region Mask Date Event
        private void MaskDtEODFrom_KeyDown(object sender, KeyEventArgs e)
        {
            RadioAll.Checked = false;
        }

        private void MaskDtEODTo_KeyDown(object sender, KeyEventArgs e)
        {
            RadioAll.Checked = false;
        }
        #endregion

        #region #region Data Grid Event
        private void DataGridPurchaseSalesTransaction_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridPurchaseSalesTransaction.Columns["EndOfDay"].HeaderText = "Date";
            DataGridPurchaseSalesTransaction.Columns["EndOfDay"].Width = 250;
            DataGridPurchaseSalesTransaction.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridPurchaseSalesTransaction.Columns["Description"].HeaderText = "Description";
            DataGridPurchaseSalesTransaction.Columns["Description"].Width = 250;
            DataGridPurchaseSalesTransaction.Columns["Description"].DisplayIndex = 1;

            DataGridPurchaseSalesTransaction.Columns["BillInvoiceNo"].HeaderText = "Bill/Invoice No";
            DataGridPurchaseSalesTransaction.Columns["BillInvoiceNo"].Width = 250;
            DataGridPurchaseSalesTransaction.Columns["BillInvoiceNo"].DisplayIndex = 2;

            DataGridPurchaseSalesTransaction.Columns["Amount"].HeaderText = "Amount";
            DataGridPurchaseSalesTransaction.Columns["Amount"].DisplayIndex = 3;
            DataGridPurchaseSalesTransaction.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridPurchaseSalesTransaction.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridPurchaseSalesTransaction.Rows)
            {
                DataGridPurchaseSalesTransaction.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridPurchaseSalesTransaction.RowHeadersWidth = 50;
                DataGridPurchaseSalesTransaction.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadActions()
        {
            ComboAction.ValueMember = "Id";
            ComboAction.DisplayMember = "Value";

            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.PURCHASE, Value = Constants.PURCHASE });
            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.SALES, Value = Constants.SALES });
        }

        public void LoadTransactions()
        {
            var userTransactionFilter = new UserTransactionFilter();
            if (!string.IsNullOrWhiteSpace(MaskDtEODFrom.Text.Replace("-", string.Empty).Trim()))
            {
                userTransactionFilter.DateFrom = MaskDtEODFrom.Text.Trim();
            }

            if (!string.IsNullOrWhiteSpace(MaskDtEODTo.Text.Replace("-", string.Empty).Trim()))
            {
                userTransactionFilter.DateTo = MaskDtEODTo.Text.Trim();
            }

            userTransactionFilter.Action = ComboAction.Text;

           
            var userTransactions = _userTransactionService.GetUserTransactions(userTransactionFilter).ToList();
            List<PurchaseSalesTransactionView> purchaseSalesTransactionViewList = userTransactions.OrderBy(x => x.EndOfDay)
                .Select(userTransaction => new PurchaseSalesTransactionView()
                {
                    EndOfDay = userTransaction.EndOfDay,
                    Description = userTransaction.Action,
                    BillInvoiceNo = userTransaction.Action == Constants.PURCHASE ? userTransaction?.BillNo : userTransaction?.InvoiceNo,
                    Amount = userTransaction.DueAmount
                }).ToList();
            TxtAmount.Text = purchaseSalesTransactionViewList.Sum(x => x.Amount).ToString();

            var bindingList = new BindingList<PurchaseSalesTransactionView>(purchaseSalesTransactionViewList);
            var source = new BindingSource(bindingList, null);
            DataGridPurchaseSalesTransaction.DataSource = source;
        }
        #endregion

        private void ComboAction_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if(ComboAction.Text.Trim() == Constants.PURCHASE || ComboAction.Text.Trim() == Constants.SALES)
            {
                BtnShow.Enabled = true;
            }
            else
            {
                BtnShow.Enabled = false;
            }
        }
    }
}
