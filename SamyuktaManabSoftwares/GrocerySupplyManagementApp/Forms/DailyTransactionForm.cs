using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class DailyTransactionForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IUserService _userService;

        private readonly string _username;
        private readonly string _endOfDay;

        #region Constructor
        public DailyTransactionForm(string username,
            IFiscalYearService fiscalYearService, IBankTransactionService bankTransactionService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService, 
            IUserTransactionService userTransactionService, IUserService userService
            )
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankTransactionService = bankTransactionService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _userService = userService;

            _username = username;
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
        private void BtnShow_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridTransactionList.SelectedRows.Count == 1)
                {
                    var selectedRow = DataGridTransactionList.SelectedRows[0];
                    var id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    var billInvoiceNo = selectedRow.Cells["InvoiceBillNo"].Value.ToString();

                    if (!string.IsNullOrWhiteSpace(billInvoiceNo) && (billInvoiceNo.StartsWith(Constants.BILL_NO_PREFIX) || billInvoiceNo.StartsWith(Constants.BONUS_PREFIX)))
                    {
                        var posTransaction = _userTransactionService.GetLastUserTransaction(billInvoiceNo);
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
                    else if (!string.IsNullOrWhiteSpace(billInvoiceNo) && billInvoiceNo.StartsWith(Constants.INVOICE_NO_PREFIX))
                    {
                        var posTransaction = _userTransactionService.GetLastUserTransaction(billInvoiceNo);
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
                LoadServices();
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
                LoadPurchases();
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
                LoadSales();
            }
            else
            {
                ComboSales.Enabled = false;
            }
        }

        private void RadioPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioPurchasePayment.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboPurchasePayment.Enabled = true;
                LoadPurchasePayments();
            }
            else
            {
                ComboPurchasePayment.Enabled = false;
            }
        }

        private void RadioExpense_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioExpensePayment.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboExpensePayment.Enabled = true;
                LoadExpensePayments();
            }
            else
            { 
                ComboExpensePayment.Enabled = false;
            }
        }

        private void RadioBankTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioBankTransfer.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboBankTransfer.Enabled = true;
                LoadBankTransfers();
            }
            else
            {
                ComboBankTransfer.Enabled = false;
            }
        }

        private void RadioReceipt_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioReceipt.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboReceipt.Enabled = true;
                LoadReceipts();
            }
            else
            {
                ComboReceipt.Enabled = false;
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
                LoadUsers();
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
            DataGridTransactionList.Columns["EndOfDay"].Width = 80;
            DataGridTransactionList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridTransactionList.Columns["MemberSupplierId"].HeaderText = "Mem/Supp";
            DataGridTransactionList.Columns["MemberSupplierId"].Width = 75;
            DataGridTransactionList.Columns["MemberSupplierId"].DisplayIndex = 1;

            DataGridTransactionList.Columns["Action"].HeaderText = "Description";
            DataGridTransactionList.Columns["Action"].Width = 100;
            DataGridTransactionList.Columns["Action"].DisplayIndex = 2;

            DataGridTransactionList.Columns["ActionType"].HeaderText = "Type";
            DataGridTransactionList.Columns["ActionType"].Width = 220;
            DataGridTransactionList.Columns["ActionType"].DisplayIndex = 3;

            DataGridTransactionList.Columns["InvoiceBillNo"].HeaderText = "Invoice/Bill";
            DataGridTransactionList.Columns["InvoiceBillNo"].Width = 85;
            DataGridTransactionList.Columns["InvoiceBillNo"].DisplayIndex = 4;

            DataGridTransactionList.Columns["ItemCode"].HeaderText = "ItemCode";
            DataGridTransactionList.Columns["ItemCode"].Width = 85;
            DataGridTransactionList.Columns["ItemCode"].DisplayIndex = 5;

            DataGridTransactionList.Columns["ItemName"].HeaderText = "ItemName";
            DataGridTransactionList.Columns["ItemName"].Width = 150;
            DataGridTransactionList.Columns["ItemName"].DisplayIndex = 6;

            DataGridTransactionList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridTransactionList.Columns["Quantity"].Width = 60;
            DataGridTransactionList.Columns["Quantity"].DisplayIndex = 7;
            DataGridTransactionList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridTransactionList.Columns["SalesPrice"].HeaderText = "Price";
            DataGridTransactionList.Columns["SalesPrice"].Width = 70;
            DataGridTransactionList.Columns["SalesPrice"].DisplayIndex = 8;
            DataGridTransactionList.Columns["SalesPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
            var dailyTransactionFilter = new DailyTransactionFilter();

            if (!string.IsNullOrWhiteSpace(MaskEndOfDay.Text.Replace("-", string.Empty).Trim()))
            {
                dailyTransactionFilter.Date = MaskEndOfDay.Text.Trim();
            }

            var selectedFilter = GroupFilter.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            if (selectedFilter.Name.Equals("RadioService"))
            {
                dailyTransactionFilter.Service = ComboService.Text;
            }
            else if (selectedFilter.Name.Equals("RadioPurchase"))
            {
                dailyTransactionFilter.Purchase = ComboPurchase.Text;
            }
            else if (selectedFilter.Name.Equals("RadioSales"))
            {
                dailyTransactionFilter.Sales = ComboSales.Text;
            }
            else if (selectedFilter.Name.Equals("RadioReceipt"))
            {
                dailyTransactionFilter.Receipt = ComboReceipt.Text;
            }
            else if (selectedFilter.Name.Equals("RadioPayment"))
            {
                dailyTransactionFilter.Payment = ComboPurchasePayment.Text;
            }
            else if (selectedFilter.Name.Equals("RadioExpense"))
            {
                dailyTransactionFilter.Expense = ComboExpensePayment.Text;
            }
            else if (selectedFilter.Name.Equals("RadioBankTransfer"))
            {
                dailyTransactionFilter.BankTransfer = ComboBankTransfer.Text;
            }
            else if (selectedFilter.Name.Equals("RadioItemCode"))
            {
                dailyTransactionFilter.ItemCode = ComboItemCode.Text;
            }
            else if (selectedFilter.Name.Equals("RadioUser"))
            {
                dailyTransactionFilter.Username = ComboUser.Text;
            }
            else if (selectedFilter.Name.Equals("RadioInvoiceNo"))
            {
                dailyTransactionFilter.InvoiceNo = ComboInvoiceNo.Text;
            }
            else
            {
                dailyTransactionFilter.IsAll = true;
            }

            List<TransactionView> transactionViewList = _userTransactionService.GetTransactionViewList(dailyTransactionFilter).ToList();
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
            ComboPurchasePayment.Text = string.Empty;
            ComboReceipt.Text = string.Empty;
            ComboExpensePayment.Text = string.Empty;
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
            ComboPurchasePayment.Enabled = option;
            ComboReceipt.Enabled = option;
            ComboExpensePayment.Enabled = option;
            ComboBankTransfer.Enabled = option;
            ComboItemCode.Enabled = option;
            ComboUser.Enabled = option;
            ComboInvoiceNo.Enabled = option;
        }

        private void LoadServices()
        {
            ComboService.ValueMember = "Id";
            ComboService.DisplayMember = "Value";

            ComboService.Items.Add(new ComboBoxItem { Id = Constants.DELIVERY_CHARGE, Value = Constants.DELIVERY_CHARGE });
            ComboService.Items.Add(new ComboBoxItem { Id = Constants.SALES_DISCOUNT, Value = Constants.SALES_DISCOUNT });
        }

        private void LoadPurchases()
        {
            ComboPurchase.ValueMember = "Id";
            ComboPurchase.DisplayMember = "Value";

            ComboPurchase.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboPurchase.Items.Add(new ComboBoxItem { Id = Constants.CREDIT, Value = Constants.CREDIT });
        }

        private void LoadSales()
        {
            ComboSales.ValueMember = "Id";
            ComboSales.DisplayMember = "Value";

            ComboSales.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboSales.Items.Add(new ComboBoxItem { Id = Constants.CREDIT, Value = Constants.CREDIT });
        }

        private void LoadPurchasePayments()
        {
            ComboPurchasePayment.ValueMember = "Id";
            ComboPurchasePayment.DisplayMember = "Value";

            ComboPurchasePayment.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboPurchasePayment.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
        }

        private void LoadExpensePayments()
        {
            ComboExpensePayment.ValueMember = "Id";
            ComboExpensePayment.DisplayMember = "Value";

            ComboExpensePayment.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboExpensePayment.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
        }

        private void LoadBankTransfers()
        {
            ComboBankTransfer.ValueMember = "Id";
            ComboBankTransfer.DisplayMember = "Value";

            ComboBankTransfer.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboBankTransfer.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
        }

        private void LoadReceipts()
        {
            ComboReceipt.ValueMember = "Id";
            ComboReceipt.DisplayMember = "Value";

            ComboReceipt.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboReceipt.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
            ComboReceipt.Items.Add(new ComboBoxItem { Id = Constants.SHARE_CHEQUE, Value = Constants.SHARE_CHEQUE });
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

        private void LoadUsers()
        {
            var user = _userService.GetUser(_username);
            var users = _userService.GetUsers(_username, user.Type);
            users.OrderBy(x => x.Username).ToList().ForEach(x =>
            {
                ComboUser.Items.Add(x);
            });
        }

        #endregion
    }
}
