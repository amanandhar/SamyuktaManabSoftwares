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

        #region Constructor
        public TransactionForm(ITransactionService transactionService, IFiscalYearDetailService fiscalYearDetailService)
        {
            InitializeComponent();

            _transactionService = transactionService;
            _fiscalYearDetailService = fiscalYearDetailService;
        }
        #endregion

        #region Form Load Event
        private void TransactionForm_Load(object sender, EventArgs e)
        {
            var fiscalYearDetail = _fiscalYearDetailService.GetFiscalYearDetail();
            MaskDate.Text = fiscalYearDetail.StartingDate.ToString("yyyy/MM/dd");
            MaskDate.Focus();
            EnableCombos(false);
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

        private void RadioPurchase_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioPurchase.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboPurchase.Enabled = true;
            }
            else
            {
                ComboPurchase.Enabled = false;
            }
        }

        private void RadioSales_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSales.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboSales.Enabled = true;
            }
            else
            {
                ComboSales.Enabled = false;
            }
        }

        private void RadioPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioPayment.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboPayment.Enabled = true;
            }
            else
            {
                ComboPayment.Enabled = false;
            }
        }

        private void RadioReceipt_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioReceipt.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboReceipt.Enabled = true;
            }
            else
            {
                ComboReceipt.Enabled = false;
            }
        }

        private void RadioExpense_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioExpense.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboExpense.Enabled = true;
            }
            else
            { 
                ComboExpense.Enabled = false;
            }
        }

        private void RadioItemCode_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioItemCode.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboItemCode.Enabled = true;
                LoadItemCodes();
            }
            else
            {
                ComboItemCode.Enabled = false;
            }
        }

        private void RadioInvoiceNo_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioInvoiceNo.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboInvoiceNo.Enabled = true;
                LoadInvoiceNos();
            }
            else
            {
                ComboInvoiceNo.Enabled = false;
            }
        }

        private void RadioUser_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioUser.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboUser.Enabled = true;
            }
            else
            {
                ComboUser.Enabled = false;
            }
        }
        #endregion

        #region Data Grid Events
        private void DataGridTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridTransactionList.Columns["InvoiceDate"].HeaderText = "Date";
            DataGridTransactionList.Columns["InvoiceDate"].Width = 75;
            DataGridTransactionList.Columns["InvoiceDate"].DisplayIndex = 0;

            DataGridTransactionList.Columns["MemberSupplierId"].HeaderText = "Member/Supplier";
            DataGridTransactionList.Columns["MemberSupplierId"].Width = 90;
            DataGridTransactionList.Columns["MemberSupplierId"].DisplayIndex = 1;

            DataGridTransactionList.Columns["Action"].HeaderText = "Particulars";
            DataGridTransactionList.Columns["Action"].Width = 80;
            DataGridTransactionList.Columns["Action"].DisplayIndex = 2;

            DataGridTransactionList.Columns["ActionType"].HeaderText = "Type";
            DataGridTransactionList.Columns["ActionType"].Width = 120;
            DataGridTransactionList.Columns["ActionType"].DisplayIndex = 3;

            DataGridTransactionList.Columns["InvoiceBillNo"].HeaderText = "Invoice/Bill";
            DataGridTransactionList.Columns["InvoiceBillNo"].Width = 80;
            DataGridTransactionList.Columns["InvoiceBillNo"].DisplayIndex = 4;

            DataGridTransactionList.Columns["ItemCode"].HeaderText = "Code";
            DataGridTransactionList.Columns["ItemCode"].Width = 70;
            DataGridTransactionList.Columns["ItemCode"].DisplayIndex = 5;

            DataGridTransactionList.Columns["ItemName"].HeaderText = "Name";
            DataGridTransactionList.Columns["ItemName"].Width = 100;
            DataGridTransactionList.Columns["ItemName"].DisplayIndex = 6;

            DataGridTransactionList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridTransactionList.Columns["Quantity"].Width = 65;
            DataGridTransactionList.Columns["Quantity"].DisplayIndex = 7;

            DataGridTransactionList.Columns["ItemPrice"].HeaderText = "Item Price";
            DataGridTransactionList.Columns["ItemPrice"].Width = 80;
            DataGridTransactionList.Columns["ItemPrice"].DisplayIndex = 8;

            DataGridTransactionList.Columns["Amount"].HeaderText = "Amount";
            DataGridTransactionList.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridTransactionList.Columns["Amount"].DisplayIndex = 9;

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
            ComboPurchase.Text = string.Empty;
            ComboSales.Text = string.Empty;
            ComboPayment.Text = string.Empty;
            ComboReceipt.Text = string.Empty;
            ComboExpense.Text = string.Empty;
            ComboItemCode.Text = string.Empty;
            ComboUser.Text = string.Empty;
            ComboInvoiceNo.Text = string.Empty;
        }

        private void EnableCombos(bool option)
        {
            ComboPurchase.Enabled = option;
            ComboSales.Enabled = option;
            ComboPayment.Enabled = option;
            ComboReceipt.Enabled = option;
            ComboExpense.Enabled = option;
            ComboItemCode.Enabled = option;
            ComboUser.Enabled = option;
            ComboInvoiceNo.Enabled = option;
        }

        private void LoadItemCodes()
        {
            var salesItems = _transactionService.GetSalesItems();
            foreach (var salesItem in salesItems)
            {
                ComboItemCode.Items.Add(salesItem);
            }
        }

        private void LoadInvoiceNos()
        {
            var invoices = _transactionService.GetInvoices();
            foreach (var invoice in invoices)
            {
                ComboInvoiceNo.Items.Add(invoice);
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

            var selectedFilter = GroupFilter.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            if (selectedFilter.Name.Equals("RadioPurchase"))
            {
                transactionFilter.Purchase = ComboPurchase.Text;
            }
            else if (selectedFilter.Name.Equals("RadioSales"))
            {
                transactionFilter.Sales = ComboSales.Text;
            }
            else if (selectedFilter.Name.Equals("RadioPayment"))
            {
                transactionFilter.Payment = ComboPayment.Text;
            }
            else if (selectedFilter.Name.Equals("RadioReceipt"))
            {
                transactionFilter.Receipt = ComboReceipt.Text;
            }
            else if (selectedFilter.Name.Equals("RadioItemCode"))
            {
                transactionFilter.ItemCode = ComboItemCode.Text;
            }
            else if (selectedFilter.Name.Equals("RadioUser"))
            {
                transactionFilter.User = ComboUser.Text;
            }
            else if (selectedFilter.Name.Equals("RadioInvoiceNo"))
            {
                transactionFilter.InvoiceNo = ComboInvoiceNo.Text;
            }
            else
            {
                transactionFilter.isAll = true;
            }

            List<TransactionGrid> transactions = (List<TransactionGrid>)_transactionService.GetTransactionGrids(transactionFilter);
            TxtTotal.Text = transactions.Sum(x => x.Amount).ToString();
            
            var bindingList = new BindingList<TransactionGrid>(transactions);
            var source = new BindingSource(bindingList, null);
            DataGridTransactionList.DataSource = source;
        }
        #endregion

        
    }
}
