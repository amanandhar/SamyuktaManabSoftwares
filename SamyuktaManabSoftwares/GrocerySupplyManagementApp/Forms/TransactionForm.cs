using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class TransactionForm : Form
    {
        private readonly ITransactionService _transactionService;
        private readonly IFiscalYearDetailService _fiscalYearDetailService;

        public TransactionForm(ITransactionService transactionService, IFiscalYearDetailService fiscalYearDetailService)
        {
            InitializeComponent();

            _transactionService = transactionService;
            _fiscalYearDetailService = fiscalYearDetailService;
        }

        #region Form Load Event
        private void TransactionForm_Load(object sender, EventArgs e)
        {
            var fiscalYearDetail = _fiscalYearDetailService.GetFiscalYearDetail();
            MaskDate.Text = fiscalYearDetail.StartingDate.ToString("yyyy/MM/dd");
            MaskDate.Focus();
        }
        #endregion

        #region Button Click Event
        private void BtnShowTransaction_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void BtnDeleteTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                var invoiceNo = DataGridTransactionList.SelectedCells[3].Value.ToString();

                _transactionService.DeleteTransactionGrids(invoiceNo);

                DialogResult result = MessageBox.Show(invoiceNo + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Radio Button Event

        private void RadioSalesItem_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSalesItem.Checked)
            {
                ClearCombos();
                LoadSalesItems();
            }
            else
            {
                ComboSalesItem.Items.Clear();
            }
        }

        private void RadioInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioInvoice.Checked)
            {
                ClearCombos();
                LoadInvoices();
            }
            else
            {
                ComboInvoice.Items.Clear();
            }
        }

        #endregion

        #region Data Grid Events
        private void DataGridTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridTransactionList.Columns["InvoiceDate"].HeaderText = "Date";
            DataGridTransactionList.Columns["InvoiceDate"].Width = 75;
            DataGridTransactionList.Columns["InvoiceDate"].DisplayIndex = 0;

            DataGridTransactionList.Columns["MemberId"].HeaderText = "Member Id";
            DataGridTransactionList.Columns["MemberId"].Width = 100;
            DataGridTransactionList.Columns["MemberId"].DisplayIndex = 1;

            DataGridTransactionList.Columns["Descriptions"].HeaderText = "Descriptions";
            DataGridTransactionList.Columns["Descriptions"].Width = 80;
            DataGridTransactionList.Columns["Descriptions"].DisplayIndex = 2;

            DataGridTransactionList.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridTransactionList.Columns["InvoiceNo"].Width = 90;
            DataGridTransactionList.Columns["InvoiceNo"].DisplayIndex = 3;

            DataGridTransactionList.Columns["ItemCode"].HeaderText = "Item Code";
            DataGridTransactionList.Columns["ItemCode"].Width = 80;
            DataGridTransactionList.Columns["ItemCode"].DisplayIndex = 4;

            DataGridTransactionList.Columns["ItemName"].HeaderText = "Item Name";
            DataGridTransactionList.Columns["ItemName"].Width = 100;
            DataGridTransactionList.Columns["ItemName"].DisplayIndex = 5;

            DataGridTransactionList.Columns["ItemBrand"].HeaderText = "Item Brand";
            DataGridTransactionList.Columns["ItemBrand"].Width = 100;
            DataGridTransactionList.Columns["ItemBrand"].DisplayIndex = 6;

            DataGridTransactionList.Columns["Unit"].HeaderText = "Unit";
            DataGridTransactionList.Columns["Unit"].Width = 50;
            DataGridTransactionList.Columns["Unit"].DisplayIndex = 7;

            DataGridTransactionList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridTransactionList.Columns["Quantity"].Width = 75;
            DataGridTransactionList.Columns["Quantity"].DisplayIndex = 8;

            DataGridTransactionList.Columns["ItemPrice"].HeaderText = "Item Price";
            DataGridTransactionList.Columns["ItemPrice"].Width = 80;
            DataGridTransactionList.Columns["ItemPrice"].DisplayIndex = 9;

            DataGridTransactionList.Columns["Amount"].HeaderText = "Amount";
            DataGridTransactionList.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridTransactionList.Columns["Amount"].DisplayIndex = 10;

            foreach (DataGridViewRow row in DataGridTransactionList.Rows)
            {
                DataGridTransactionList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridTransactionList.RowHeadersWidth = 50;
            }
        }

        #endregion

        #region Helper Methods

        private void ClearCombos()
        {
            ComboPaymentIn.Text = string.Empty;
            ComboPaymentOut.Text = string.Empty;
            ComboSalesItem.Text = string.Empty;
            ComboUsers.Text = string.Empty;
            ComboInvoice.Text = string.Empty;
        }

        private void LoadSalesItems()
        {
            var salesItems = _transactionService.GetSalesItems();
            foreach (var salesItem in salesItems)
            {
                ComboSalesItem.Items.Add(salesItem);
            }
        }

        private void LoadInvoices()
        {
            var invoices = _transactionService.GetInvoices();
            foreach (var invoice in invoices)
            {
                ComboInvoice.Items.Add(invoice);
            }
        }

        private  void LoadTransactions()
        {
            MaskDate.Focus();
            var transactionFilter = new TransactionFilter();

            if (!string.IsNullOrWhiteSpace(MaskDate.Text))
            {
                transactionFilter.Date = Convert.ToDateTime(MaskDate.Text).ToString("yyyy-MM-dd");
            }

            var selectedSale = GroupSale.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            if (selectedSale.Name.Equals("RadioCashSale"))
            {
                transactionFilter.Sale = "Cash";
            }
            else if (selectedSale.Name.Equals("RadioCreditSale"))
            {
                transactionFilter.Sale = "Credit";
            }

            var selectedFilter = GroupFilter.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            
            if(selectedFilter != null && selectedFilter.Checked)
            {
                if(selectedFilter.Name.Equals("RadioSalesItem"))
                {
                    transactionFilter.ItemCode = ComboSalesItem.Text;
                }
                else if (selectedFilter.Name.Equals("RadioInvoice"))
                {
                    transactionFilter.InvoiceNo = ComboInvoice.Text;
                }
            }

            TxtTotal.Text = _transactionService.GetSumTransactionGrids(transactionFilter).ToString();

            List<TransactionGrid> transactions = (List<TransactionGrid>)_transactionService.GetTransactionGrids(transactionFilter);
            var bindingList = new BindingList<TransactionGrid>(transactions);
            var source = new BindingSource(bindingList, null);
            DataGridTransactionList.DataSource = source;
        }
        #endregion
    }
}
