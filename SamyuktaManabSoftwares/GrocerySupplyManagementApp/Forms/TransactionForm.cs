using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class TransactionForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;

        #region Constructor
        public TransactionForm(IFiscalYearService fiscalYearService, IBankTransactionService bankTransactionService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService, 
            IUserTransactionService userTransactionService
            )
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankTransactionService = bankTransactionService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }
        #endregion

        #region Form Load Event
        private void TransactionForm_Load(object sender, EventArgs e)
        {
            MaskEndOfDay.Text = _endOfDay;
            MaskEndOfDay.Focus();
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
                if (DataGridTransactionList.SelectedRows.Count == 1)
                {
                    var selectedRow = DataGridTransactionList.SelectedRows[0];
                    var id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    var billInvoiceNo = selectedRow.Cells["InvoiceBillNo"].Value.ToString();

                    if (!string.IsNullOrWhiteSpace(billInvoiceNo) && billInvoiceNo.StartsWith("BN"))
                    {
                        var posTransaction = _userTransactionService.GetLastUserTransaction("BN");
                        {
                            if (posTransaction.BillNo.ToLower() == billInvoiceNo.ToLower())
                            {
                                _userTransactionService.DeleteUserTransaction(id);
                                _purchasedItemService.DeletePurchasedItem(billInvoiceNo);
                                _bankTransactionService.DeleteBankTransactionByUserTransaction(id);
                            }
                            else
                            {
                                DialogResult billResult = MessageBox.Show("Please delete latest bill number first.", "Message", MessageBoxButtons.OK);
                                if (billResult == DialogResult.OK)
                                {
                                    LoadTransactions();
                                    return;
                                }
                            }
                        }
                    }

                    else if (!string.IsNullOrWhiteSpace(billInvoiceNo) && billInvoiceNo.StartsWith("IN"))
                    {
                        var posTransaction = _userTransactionService.GetLastUserTransaction("IN");
                        if (posTransaction.InvoiceNo.ToLower() == billInvoiceNo.ToLower())
                        {
                            _userTransactionService.DeleteUserTransaction(billInvoiceNo);
                            _soldItemService.DeleteSoldItem(billInvoiceNo);
                        }
                        else
                        {
                            DialogResult billResult = MessageBox.Show("Please delete latest invoice number first.", "Message", MessageBoxButtons.OK);
                            if (billResult == DialogResult.OK)
                            {
                                LoadTransactions();
                                return;
                            }
                        }
                    }
                    else
                    {
                        _userTransactionService.DeleteUserTransaction(id);
                        _bankTransactionService.DeleteBankTransactionByUserTransaction(id);
                    }

                    DialogResult result = MessageBox.Show("Trasaction has been deleted successfully.", "Message", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        LoadTransactions();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Radio Button Event
        private void RadioService_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioService.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboService.Enabled = true;
            }
            else
            {
                ComboService.Enabled = false;
            }
        }

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

        private void RadioBankTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioBankTransfer.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboBankTransfer.Enabled = true;
            }
            else
            {
                ComboBankTransfer.Enabled = false;
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

        #region Data Grid Event
        private void DataGridTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridTransactionList.Columns["Id"].Visible = false;

            DataGridTransactionList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridTransactionList.Columns["EndOfDay"].Width = 75;
            DataGridTransactionList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridTransactionList.Columns["MemberSupplierId"].HeaderText = "Member/Supplier";
            DataGridTransactionList.Columns["MemberSupplierId"].Width = 90;
            DataGridTransactionList.Columns["MemberSupplierId"].DisplayIndex = 1;

            DataGridTransactionList.Columns["Action"].HeaderText = "Description";
            DataGridTransactionList.Columns["Action"].Width = 80;
            DataGridTransactionList.Columns["Action"].DisplayIndex = 2;

            DataGridTransactionList.Columns["ActionType"].HeaderText = "Type";
            DataGridTransactionList.Columns["ActionType"].Width = 180;
            DataGridTransactionList.Columns["ActionType"].DisplayIndex = 3;

            DataGridTransactionList.Columns["InvoiceBillNo"].HeaderText = "Invoice/Bill";
            DataGridTransactionList.Columns["InvoiceBillNo"].Width = 80;
            DataGridTransactionList.Columns["InvoiceBillNo"].DisplayIndex = 4;

            DataGridTransactionList.Columns["ItemCode"].HeaderText = "Code";
            DataGridTransactionList.Columns["ItemCode"].Width = 70;
            DataGridTransactionList.Columns["ItemCode"].DisplayIndex = 5;

            DataGridTransactionList.Columns["ItemName"].HeaderText = "Name";
            DataGridTransactionList.Columns["ItemName"].Width = 150;
            DataGridTransactionList.Columns["ItemName"].DisplayIndex = 6;

            DataGridTransactionList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridTransactionList.Columns["Quantity"].Width = 65;
            DataGridTransactionList.Columns["Quantity"].DisplayIndex = 7;
            DataGridTransactionList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridTransactionList.Columns["ItemPrice"].HeaderText = "Item Price";
            DataGridTransactionList.Columns["ItemPrice"].Width = 80;
            DataGridTransactionList.Columns["ItemPrice"].DisplayIndex = 8;
            DataGridTransactionList.Columns["ItemPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridTransactionList.Columns["Amount"].HeaderText = "Amount";
            DataGridTransactionList.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridTransactionList.Columns["Amount"].DisplayIndex = 9;
            DataGridTransactionList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridTransactionList.Rows)
            {
                DataGridTransactionList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridTransactionList.RowHeadersWidth = 50;
                DataGridTransactionList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        #endregion

        #region Helper Methods
        private void LoadTransactions()
        {
            MaskEndOfDay.Focus();
            var transactionFilter = new TransactionFilter();

            if (!string.IsNullOrWhiteSpace(MaskEndOfDay.Text.Replace("-", string.Empty).Trim()))
            {
                transactionFilter.Date = MaskEndOfDay.Text.Trim();
            }

            var selectedFilter = GroupFilter.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            if (selectedFilter.Name.Equals("RadioService"))
            {
                transactionFilter.Service = ComboService.Text;
            }
            else if (selectedFilter.Name.Equals("RadioPurchase"))
            {
                transactionFilter.Purchase = ComboPurchase.Text;
            }
            else if (selectedFilter.Name.Equals("RadioSales"))
            {
                transactionFilter.Sales = ComboSales.Text;
            }
            else if (selectedFilter.Name.Equals("RadioReceipt"))
            {
                transactionFilter.Receipt = ComboReceipt.Text;
            }
            else if (selectedFilter.Name.Equals("RadioPayment"))
            {
                transactionFilter.Payment = ComboPayment.Text;
            }
            else if (selectedFilter.Name.Equals("RadioExpense"))
            {
                transactionFilter.Expense = ComboExpense.Text;
            }
            else if (selectedFilter.Name.Equals("RadioBankTransfer"))
            {
                transactionFilter.BankTransfer = ComboBankTransfer.Text;
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
                transactionFilter.IsAll = true;
            }

            List<TransactionView> transactionViewList = _userTransactionService.GetTransactionViewList(transactionFilter).ToList();
            TxtTotal.Text = transactionViewList.Sum(x => x.Amount).ToString();

            var bindingList = new BindingList<TransactionView>(transactionViewList);
            var source = new BindingSource(bindingList, null);
            DataGridTransactionList.DataSource = source;
        }

        private void ClearCombos()
        {
            ComboService.Text = string.Empty;
            ComboPurchase.Text = string.Empty;
            ComboSales.Text = string.Empty;
            ComboPayment.Text = string.Empty;
            ComboReceipt.Text = string.Empty;
            ComboExpense.Text = string.Empty;
            ComboBankTransfer.Text = string.Empty;
            ComboItemCode.Text = string.Empty;
            ComboUser.Text = string.Empty;
            ComboInvoiceNo.Text = string.Empty;
        }

        private void EnableCombos(bool option)
        {
            ComboService.Enabled = option;
            ComboPurchase.Enabled = option;
            ComboSales.Enabled = option;
            ComboPayment.Enabled = option;
            ComboReceipt.Enabled = option;
            ComboExpense.Enabled = option;
            ComboBankTransfer.Enabled = option;
            ComboItemCode.Enabled = option;
            ComboUser.Enabled = option;
            ComboInvoiceNo.Enabled = option;
        }

        private void LoadItemCodes()
        {
            var soldItemCodes = _soldItemService.GetSoldItemCodes();
            foreach (var soldItemCode in soldItemCodes)
            {
                ComboItemCode.Items.Add(soldItemCode);
            }
        }

        private void LoadInvoiceNos()
        {
            var invoices = _userTransactionService.GetInvoices();
            foreach (var invoice in invoices)
            {
                ComboInvoiceNo.Items.Add(invoice);
            }
        }

        #endregion
        
    }
}
