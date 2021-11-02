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
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IUserService _userService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Constructor
        public DailyTransactionForm(string username,
            ISettingService settingService, IPurchasedItemService purchasedItemService,
            ISoldItemService soldItemService, IUserTransactionService userTransactionService,
            IUserService userService
            )
        {
            InitializeComponent();

            _settingService = settingService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _userService = userService;

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
            LoadUsernames();
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
                    var partyNumber = selectedRow?.Cells["PartyNumber"]?.Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(partyNumber))
                    {
                        string selectedId = selectedRow?.Cells["Id"]?.Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(selectedId))
                        {
                            DialogResult confirmation = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (confirmation == DialogResult.Yes)
                            {
                                var id = Convert.ToInt64(selectedId);
                                if (partyNumber.StartsWith(Constants.BILL_NO_PREFIX))
                                {
                                    // Get the latest bill number
                                    var lastUserTransaction = _userTransactionService.GetLastUserTransaction(PartyNumberType.Bill, string.Empty);
                                    if (lastUserTransaction.PartyNumber.ToLower() == partyNumber.ToLower())
                                    {
                                        _userTransactionService.DeleteBill(id, partyNumber);
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
                                else if (partyNumber.StartsWith(Constants.INVOICE_NO_PREFIX))
                                {
                                    // Get the latest invoice number
                                    var lastUserTransaction = _userTransactionService.GetLastUserTransaction(PartyNumberType.Invoice, string.Empty);
                                    if (lastUserTransaction.PartyNumber.ToLower() == partyNumber.ToLower())
                                    {
                                        _userTransactionService.DeleteInvoice(partyNumber);
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

                                DialogResult result = MessageBox.Show("Trasaction has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (result == DialogResult.OK)
                                {
                                    LoadDailyTransactions();
                                }
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
            if (RadioPayment.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboPayment.Enabled = true;
                LoadPayments();
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
                LoadReceipts();
            }
            else
            {
                ComboReceipt.Enabled = false;
            }
        }

        private void RadioInvoiceNo_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioPartyNo.Checked)
            {
                ClearCombos();
                EnableCombos(false);
                ComboPartyNo.Enabled = true;
                LoadPartyNos();
            }
            else
            {
                ComboPartyNo.Enabled = false;
            }
        }

        #endregion

        #region Combo Box Event
        private void ComboPurchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboPurchasePayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboExpensePayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboBankTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
            DataGridTransactionList.Columns["AddedDate"].Visible = false;

            DataGridTransactionList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridTransactionList.Columns["EndOfDay"].Width = 100;
            DataGridTransactionList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridTransactionList.Columns["Action"].HeaderText = "Description";
            DataGridTransactionList.Columns["Action"].Width = 125;
            DataGridTransactionList.Columns["Action"].DisplayIndex = 1;

            DataGridTransactionList.Columns["PartyId"].HeaderText = "Mem/Supp Id";
            DataGridTransactionList.Columns["PartyId"].Width = 150;
            DataGridTransactionList.Columns["PartyId"].DisplayIndex = 2;

            DataGridTransactionList.Columns["PartyNumber"].HeaderText = "Invoice/Bill No";
            DataGridTransactionList.Columns["PartyNumber"].Width = 125;
            DataGridTransactionList.Columns["PartyNumber"].DisplayIndex = 3;

            DataGridTransactionList.Columns["ActionType"].HeaderText = "Type";
            DataGridTransactionList.Columns["ActionType"].Width = 150;
            DataGridTransactionList.Columns["ActionType"].DisplayIndex = 4;

            DataGridTransactionList.Columns["BankName"].HeaderText = "Bank";
            DataGridTransactionList.Columns["BankName"].Width = 250;
            DataGridTransactionList.Columns["BankName"].DisplayIndex = 5;

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
                else if (selectedFilter.Name.Equals("RadioPayment"))
                {
                    dailyTransactionFilter.Payment = ComboPayment.Text.Trim();
                }
                else if (selectedFilter.Name.Equals("RadioReceipt"))
                {
                    dailyTransactionFilter.Receipt = ComboReceipt.Text.Trim();
                }
                else if (selectedFilter.Name.Equals("RadioPartyNo"))
                {
                    dailyTransactionFilter.PartyNumber = ComboPartyNo.Text.Trim();
                }
                else if (selectedFilter.Name.Equals("RadioAll"))
                {
                    dailyTransactionFilter.IsAll = true;
                }
            }

            dailyTransactionFilter.Username = ComboUsername.Text.Trim();

            List<DailyTransactionView> dailyTransactions = _userTransactionService.GetDailyTransactions(dailyTransactionFilter).ToList();
            TxtTotal.Text = dailyTransactions.Sum(x => x.Amount).ToString();

            var bindingList = new BindingList<DailyTransactionView>(dailyTransactions);
            var source = new BindingSource(bindingList, null);
            DataGridTransactionList.DataSource = source;
        }

        private void ClearCombos()
        {
            ComboPurchase.Text = string.Empty;
            ComboSales.Text = string.Empty;
            ComboPayment.Text = string.Empty;
            ComboReceipt.Text = string.Empty;
            ComboPartyNo.Text = string.Empty;
        }

        private void EnableCombos(bool option)
        {
            ComboPurchase.Enabled = option;
            ComboSales.Enabled = option;
            ComboPayment.Enabled = option;
            ComboReceipt.Enabled = option;
            ComboPartyNo.Enabled = option;
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

        private void LoadPayments()
        {
            ComboPayment.Items.Clear();
            ComboPayment.ValueMember = "Id";
            ComboPayment.DisplayMember = "Value";

            ComboPayment.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboPayment.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
        }

        private void LoadReceipts()
        {
            ComboReceipt.Items.Clear();
            ComboReceipt.ValueMember = "Id";
            ComboReceipt.DisplayMember = "Value";

            ComboReceipt.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboReceipt.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
        }

        private void LoadPartyNos()
        {
            ComboPartyNo.Items.Clear();
            var partyNumbers = _soldItemService.GetInvoiceNumbers().ToList();
            partyNumbers.AddRange(_purchasedItemService.GetBillNumbers().ToList());
            partyNumbers = partyNumbers.OrderBy(x => x).ToList();

            foreach (var partyNumber in partyNumbers)
            {
                ComboPartyNo.Items.Add(partyNumber);
            }
        }

        private void LoadUsernames()
        {
            ComboUsername.Items.Clear();
            var user = _userService.GetUser(_username);
            var users = _userService.GetUsers(_username, user.Type);
            if (users.ToList().Count > 1)
            {
                ComboUsername.Enabled = true;
            }

            users.OrderBy(x => x.Username).ToList().ForEach(x =>
            {
                ComboUsername.Items.Add(x.Username);
            });

            ComboUsername.SelectedText = _username;
        }

        #endregion
    }
}
