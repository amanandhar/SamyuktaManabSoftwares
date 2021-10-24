using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.Shared.Enums;
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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IUserService _userService;
        private readonly IAtomicTransactionService _atomicTransactionService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Constructor
        public DailyTransactionForm(string username,
            ISettingService settingService, IBankTransactionService bankTransactionService,
            IUserTransactionService userTransactionService, IUserService userService,
            IAtomicTransactionService atomicTransactionService
            )
        {
            InitializeComponent();

            _settingService = settingService;
            _bankTransactionService = bankTransactionService;
            _userTransactionService = userTransactionService;
            _userService = userService;
            _atomicTransactionService = atomicTransactionService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void TransactionForm_Load(object sender, EventArgs e)
        {
            MaskDtEOD.Text = _endOfDay;
            EnableCombos(false);
            LoadUsers();
            MaskDtEOD.Focus();
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            LoadDailyTransactions();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridTransactionList.SelectedCells.Count == 1
                    || DataGridTransactionList.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow;
                    if (DataGridTransactionList.SelectedCells.Count == 1)
                    {
                        var selectedCell = DataGridTransactionList.SelectedCells[0];
                        selectedRow = DataGridTransactionList.Rows[selectedCell.RowIndex];
                    }
                    else
                    {
                        selectedRow = DataGridTransactionList.SelectedRows[0];
                    }

                    string selectedId = selectedRow?.Cells["Id"]?.Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(selectedId))
                    {
                        DialogResult confirmation = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmation == DialogResult.Yes)
                        {
                            var id = Convert.ToInt64(selectedId);

                            var billInvoiceNo = selectedRow?.Cells["InvoiceBillNo"]?.Value?.ToString();
                            var income = selectedRow?.Cells["Income"]?.Value?.ToString();
                            var expense = selectedRow?.Cells["Expense"]?.Value?.ToString();
                            var actionType = selectedRow?.Cells["ActionType"]?.Value?.ToString();

                            if (!string.IsNullOrWhiteSpace(billInvoiceNo)
                                && billInvoiceNo.StartsWith(Constants.BILL_NO_PREFIX))
                            {
                                // Get the latest bill number
                                var posTransaction = _userTransactionService.GetLastUserTransaction(TransactionNumberType.Bill, string.Empty);
                                if (posTransaction.BillNo.ToLower() == billInvoiceNo.ToLower())
                                {
                                    _atomicTransactionService.DeleteBill(id, billInvoiceNo);
                                }
                                else
                                {
                                    DialogResult billResult = MessageBox.Show("Please delete latest bill number first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    if (billResult == DialogResult.OK)
                                    {
                                        LoadDailyTransactions();
                                        return;
                                    }
                                }
                            }
                            else if (!string.IsNullOrWhiteSpace(billInvoiceNo) && billInvoiceNo.StartsWith(Constants.INVOICE_NO_PREFIX))
                            {
                                // Get the latest invoice number
                                var posTransaction = _userTransactionService.GetLastUserTransaction(TransactionNumberType.Invoice, string.Empty);
                                if (posTransaction.InvoiceNo.ToLower() == billInvoiceNo.ToLower())
                                {
                                    _atomicTransactionService.DeleteInvoice(billInvoiceNo);
                                }
                                else
                                {
                                    DialogResult billResult = MessageBox.Show("Please delete latest invoice number first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    if (billResult == DialogResult.OK)
                                    {
                                        LoadDailyTransactions();
                                        return;
                                    }
                                }
                            }
                            else if (income.Equals(Constants.STOCK_ADJUSTMENT) || expense.Equals(Constants.STOCK_ADJUSTMENT))
                            {
                                _atomicTransactionService.DeleteStockAdjustment(id);
                            }
                            else if (actionType.Equals(Constants.OWNER_EQUITY))
                            {
                                _bankTransactionService.DeleteBankTransaction(id);
                            }
                            else
                            {
                                _atomicTransactionService.DeleteBankTransaction(id);
                            }

                            DialogResult result = MessageBox.Show("Trasaction has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (result == DialogResult.OK)
                            {
                                LoadDailyTransactions();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }
        #endregion

        #region Radio Button Event
        private void RadioAll_CheckedChanged(object sender, EventArgs e)
        {
            MaskDtEOD.Clear();
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

        #endregion

        #region Mask Date Event
        private void MaskDtEOD_KeyDown(object sender, KeyEventArgs e)
        {
            RadioAll.Checked = false;
        }
        #endregion

        #region Data Grid Event
        private void DataGridTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridTransactionList.Columns["Id"].Visible = false;
            DataGridTransactionList.Columns["Income"].Visible = false;
            DataGridTransactionList.Columns["Expense"].Visible = false;
            DataGridTransactionList.Columns["AddedDate"].Visible = false;

            DataGridTransactionList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridTransactionList.Columns["EndOfDay"].Width = 100;
            DataGridTransactionList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridTransactionList.Columns["MemberSupplierId"].HeaderText = "Mem/Supp";
            DataGridTransactionList.Columns["MemberSupplierId"].Width = 100;
            DataGridTransactionList.Columns["MemberSupplierId"].DisplayIndex = 1;

            DataGridTransactionList.Columns["Action"].HeaderText = "Description";
            DataGridTransactionList.Columns["Action"].Width = 125;
            DataGridTransactionList.Columns["Action"].DisplayIndex = 2;

            DataGridTransactionList.Columns["ActionType"].HeaderText = "Type";
            DataGridTransactionList.Columns["ActionType"].Width = 150;
            DataGridTransactionList.Columns["ActionType"].DisplayIndex = 3;

            DataGridTransactionList.Columns["Bank"].HeaderText = "Bank";
            DataGridTransactionList.Columns["Bank"].Width = 250;
            DataGridTransactionList.Columns["Bank"].DisplayIndex = 4;

            DataGridTransactionList.Columns["InvoiceBillNo"].HeaderText = "Invoice/Bill";
            DataGridTransactionList.Columns["InvoiceBillNo"].Width = 125;
            DataGridTransactionList.Columns["InvoiceBillNo"].DisplayIndex = 5;

            DataGridTransactionList.Columns["Amount"].HeaderText = "Amount";
            DataGridTransactionList.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridTransactionList.Columns["Amount"].DisplayIndex = 6;
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
        private void LoadDailyTransactions()
        {
            MaskDtEOD.Focus();

            var dailyTransactionFilter = new DailyTransactionFilter
            {
                Date = UtilityService.GetDate(MaskDtEOD.Text.Trim())
            };

            var selectedFilter = GroupFilter.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            if (selectedFilter != null)
            {
                if (selectedFilter.Name.Equals("RadioPurchase"))
                {
                    dailyTransactionFilter.Purchase = ComboPurchase.Text.Trim();
                }
                else if (selectedFilter.Name.Equals("RadioSales"))
                {
                    dailyTransactionFilter.Sales = ComboSales.Text.Trim();
                }
                else if (selectedFilter.Name.Equals("RadioPurchasePayment"))
                {
                    dailyTransactionFilter.Payment = ComboPurchasePayment.Text.Trim();
                }
                else if (selectedFilter.Name.Equals("RadioExpensePayment"))
                {
                    dailyTransactionFilter.Expense = ComboExpensePayment.Text.Trim();
                }
                else if (selectedFilter.Name.Equals("RadioBankTransfer"))
                {
                    dailyTransactionFilter.BankTransfer = ComboBankTransfer.Text.Trim();
                }
                else if (selectedFilter.Name.Equals("RadioReceipt"))
                {
                    dailyTransactionFilter.Receipt = ComboReceipt.Text.Trim();
                }
                else if (selectedFilter.Name.Equals("RadioInvoiceNo"))
                {
                    dailyTransactionFilter.InvoiceNo = ComboInvoiceNo.Text.Trim();
                }
                else if (selectedFilter.Name.Equals("RadioAll"))
                {
                    dailyTransactionFilter.IsAll = true;
                }
            }

            dailyTransactionFilter.Username = ComboUser.Text.Trim();

            List<DailyTransactionView> dailyTransactions = _userTransactionService.GetDailyTransactions(dailyTransactionFilter)
                .OrderByDescending(x => x.AddedDate)
                .ToList();
            TxtTotal.Text = dailyTransactions.Sum(x => x.Amount).ToString();

            var bindingList = new BindingList<DailyTransactionView>(dailyTransactions);
            var source = new BindingSource(bindingList, null);
            DataGridTransactionList.DataSource = source;
        }

        private void ClearCombos()
        {
            ComboPurchase.Text = string.Empty;
            ComboSales.Text = string.Empty;
            ComboPurchasePayment.Text = string.Empty;
            ComboExpensePayment.Text = string.Empty;
            ComboBankTransfer.Text = string.Empty;
            ComboReceipt.Text = string.Empty;
            ComboInvoiceNo.Text = string.Empty;
        }

        private void EnableCombos(bool option)
        {
            ComboPurchase.Enabled = option;
            ComboSales.Enabled = option;
            ComboPurchasePayment.Enabled = option;
            ComboReceipt.Enabled = option;
            ComboExpensePayment.Enabled = option;
            ComboBankTransfer.Enabled = option;
            ComboUser.Enabled = option;
            ComboInvoiceNo.Enabled = option;
        }

        private void LoadPurchases()
        {
            ComboPurchase.Items.Clear();
            ComboPurchase.ValueMember = "Id";
            ComboPurchase.DisplayMember = "Value";

            ComboPurchase.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboPurchase.Items.Add(new ComboBoxItem { Id = Constants.CREDIT, Value = Constants.CREDIT });
        }

        private void LoadSales()
        {
            ComboSales.Items.Clear();
            ComboSales.ValueMember = "Id";
            ComboSales.DisplayMember = "Value";

            ComboSales.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboSales.Items.Add(new ComboBoxItem { Id = Constants.CREDIT, Value = Constants.CREDIT });
        }

        private void LoadPurchasePayments()
        {
            ComboPurchasePayment.Items.Clear();
            ComboPurchasePayment.ValueMember = "Id";
            ComboPurchasePayment.DisplayMember = "Value";

            ComboPurchasePayment.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboPurchasePayment.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
        }

        private void LoadExpensePayments()
        {
            ComboExpensePayment.Items.Clear();
            ComboExpensePayment.ValueMember = "Id";
            ComboExpensePayment.DisplayMember = "Value";

            ComboExpensePayment.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboExpensePayment.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
        }

        private void LoadBankTransfers()
        {
            ComboBankTransfer.Items.Clear();
            ComboBankTransfer.ValueMember = "Id";
            ComboBankTransfer.DisplayMember = "Value";

            ComboBankTransfer.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
        }

        private void LoadReceipts()
        {
            ComboReceipt.Items.Clear();
            ComboReceipt.ValueMember = "Id";
            ComboReceipt.DisplayMember = "Value";

            ComboReceipt.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboReceipt.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
            ComboReceipt.Items.Add(new ComboBoxItem { Id = Constants.OWNER_EQUITY, Value = Constants.OWNER_EQUITY });
            ComboReceipt.Items.Add(new ComboBoxItem { Id = Constants.SHARE_CAPITAL, Value = Constants.SHARE_CAPITAL });
        }

        private void LoadInvoiceNos()
        {
            ComboInvoiceNo.Items.Clear();
            var invoices = _userTransactionService.GetInvoices();
            foreach (var invoice in invoices)
            {
                ComboInvoiceNo.Items.Add(invoice);
            }
        }

        private void LoadUsers()
        {
            ComboUser.Items.Clear();
            var user = _userService.GetUser(_username);
            var users = _userService.GetUsers(_username, user.Type);
            if (users.ToList().Count > 1)
            {
                ComboUser.Enabled = true;
            }

            users.OrderBy(x => x.Username).ToList().ForEach(x =>
            {
                ComboUser.Items.Add(x.Username);
            });

            ComboUser.SelectedText = _username;
        }

        #endregion
    }
}
