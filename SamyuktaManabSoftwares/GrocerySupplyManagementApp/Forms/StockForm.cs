﻿using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class StockForm : Form
    {
        private readonly IItemTransactionService _itemTransactionService;

        #region Constructor
        public StockForm(IItemTransactionService itemTransactionService)
        {
            InitializeComponent();

            _itemTransactionService = itemTransactionService;
        }
        #endregion

        #region Form Load Event
        private void StockForm_Load(object sender, EventArgs e)
        {

            _itemTransactionService.GetAllItemCodes().ToList().ForEach(code =>
            {
                ComboItemCode.Items.Add(code);
            });
        }

        #endregion

        #region Checkbox Events
        private void CheckAllTransactions_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckAllTransactions.Checked)
            {
                MaskDateFrom.Text = string.Empty;
                MaskDateTo.Text = string.Empty;
                ComboItemCode.Text = string.Empty;
            }
        }

        #endregion

        #region Combobox Events
        private void ComboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCheckState(false);
        }
        #endregion

        #region Mask Text Box Events
        private void MaskTextBoxDateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            ChangeCheckState(false);
        }

        private void MaskDateTo_KeyDown(object sender, KeyEventArgs e)
        {
            ChangeCheckState(false);
        }

        #endregion

        #region Button Events
        private void BtnShow_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var name = DataGridStockList.SelectedCells[2].Value.ToString();
                var brand = DataGridStockList.SelectedCells[3].Value.ToString();
                _itemTransactionService.DeleteItem(name, brand);

                DialogResult result = MessageBox.Show("Item with name: " + name + " and brand: " + brand + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    LoadItems();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region DataGrid Events

        private void DataGridStockList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridStockList.Columns["SupplierName"].Visible = false;

            DataGridStockList.Columns["Date"].HeaderText = "Date";
            DataGridStockList.Columns["Date"].Width = 80;
            DataGridStockList.Columns["Date"].DisplayIndex = 0;

            DataGridStockList.Columns["BillInvoiceNo"].HeaderText = "Bill/Invoice No";
            DataGridStockList.Columns["BillInvoiceNo"].Width = 100;
            DataGridStockList.Columns["BillInvoiceNo"].DisplayIndex = 1;

            DataGridStockList.Columns["Description"].HeaderText = "Description";
            DataGridStockList.Columns["Description"].Width = 80;
            DataGridStockList.Columns["Description"].DisplayIndex = 2;

            DataGridStockList.Columns["Code"].HeaderText = "Code";
            DataGridStockList.Columns["Code"].Width = 60;
            DataGridStockList.Columns["Code"].DisplayIndex = 3;

            DataGridStockList.Columns["Name"].HeaderText = "Name";
            DataGridStockList.Columns["Name"].Width = 160;
            DataGridStockList.Columns["Name"].DisplayIndex = 4;

            DataGridStockList.Columns["Brand"].HeaderText = "Brand";
            DataGridStockList.Columns["Brand"].Width = 160;
            DataGridStockList.Columns["Brand"].DisplayIndex = 5;

            DataGridStockList.Columns["Unit"].HeaderText = "Unit";
            DataGridStockList.Columns["Unit"].Width = 50;
            DataGridStockList.Columns["Unit"].DisplayIndex = 6;

            DataGridStockList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridStockList.Columns["Quantity"].Width = 80;
            DataGridStockList.Columns["Quantity"].DisplayIndex = 7;

            DataGridStockList.Columns["Price"].HeaderText = "Price";
            DataGridStockList.Columns["Price"].Width = 80;
            DataGridStockList.Columns["Price"].DisplayIndex = 8;

            DataGridStockList.Columns["Total"].HeaderText = "Total";
            DataGridStockList.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridStockList.Columns["Total"].DisplayIndex = 9;

            DataGridStockList.Columns["SellPrice"].Visible = false;

            foreach (DataGridViewRow row in DataGridStockList.Rows)
            {
                DataGridStockList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridStockList.RowHeadersWidth = 50;
            }
        }

        #endregion

        #region Helper Methods

        private void LoadItems()
        {

            StockFilterView filter = new StockFilterView();

            if (!CheckAllTransactions.Checked)
            {
                filter.ItemCode = ComboItemCode.Text;
                filter.DateFrom = MaskDateFrom.Text;
                filter.DateTo = MaskDateTo.Text;
            }

            TxtPurchase.Text = _itemTransactionService.GetTotalPurchaseItemCount(filter).ToString();
            TxtSales.Text = _itemTransactionService.GetTotalSalesItemCount(filter).ToString();
            TxtTotalStock.Text = (Convert.ToDecimal(TxtPurchase.Text) - Convert.ToDecimal(TxtSales.Text)).ToString();
            TxtTotalValue.Text = (_itemTransactionService.GetTotalPurchaseItemAmount(filter) - _itemTransactionService.GetTotalSalesItemAmount(filter)).ToString();

            List<StockView> items = _itemTransactionService.GetStockView(filter).ToList();

            var bindingList = new BindingList<StockView>(items);
            var source = new BindingSource(bindingList, null);
            DataGridStockList.DataSource = source;
        }

        private void ChangeCheckState(bool option)
        {
            CheckAllTransactions.Checked = option;
        }

        #endregion
    }
}
