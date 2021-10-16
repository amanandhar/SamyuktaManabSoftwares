using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PosForm : Form, IMemberListForm, IPricedItemListForm
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IItemService _itemService;
        private readonly IPricedItemService _pricedItemService;
        private readonly IMemberService _memberService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IReportService _reportService;
        private readonly ICompanyInfoService _companyInfoService;
        private readonly IEmployeeService _employeeService;
        private readonly IStockService _stockService;
        private readonly IUserService _userService;
        private readonly IPOSDetailService _posDetailService;
        private readonly IStockAdjustmentService _stockAdjustmentService;
        private readonly IIncomeExpenseService _incomeExpenseService;
        private readonly ICapitalService _capitalService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;
        private string _selectedInvoiceNo;
        private readonly List<SoldItemView> _soldItemViewList = new List<SoldItemView>();
        private const char separator = '.';
        private readonly bool _isPrintOnly = false;

        #region Enum
        private enum Action
        {
            AddExpense,
            AddReceipt,
            AddSale,
            AddToCart,
            BankTransfer,
            Load,
            LoadToPrintInvoice,
            None,
            RemoveItem,
            SaveAndPrint,
            SaveReceipt,
            SearchMember,
            SearchPricedItem,
            Transaction    
        }
        #endregion 

        #region Constructor
        public PosForm(string username,
            ISettingService settingService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IItemService itemService, IPricedItemService pricedItemService,
            IMemberService memberService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService, 
            IUserTransactionService userTransactionService, IReportService reportService,
            ICompanyInfoService companyInfoService, IEmployeeService employeeService,
            IStockService stockService, IUserService userService,
            IPOSDetailService posDetailService, IStockAdjustmentService stockAdjustmentService,
            IIncomeExpenseService incomeExpenseService, ICapitalService capitalService
            )
        {
            InitializeComponent();

            _settingService = settingService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _itemService = itemService;
            _pricedItemService = pricedItemService;
            _memberService = memberService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _reportService = reportService;
            _companyInfoService = companyInfoService;
            _employeeService = employeeService;
            _stockService = stockService;
            _userService = userService;
            _posDetailService = posDetailService;
            _stockAdjustmentService = stockAdjustmentService;
            _incomeExpenseService = incomeExpenseService;
            _capitalService = capitalService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }

        public PosForm(string memberId, string invoiceNo,
            ICompanyInfoService companyInfoService, IMemberService memberService, 
            IUserTransactionService userTransactionService, ISoldItemService soldItemService, 
            IEmployeeService employeeService, IReportService reportService,
            IPOSDetailService posDetailService
            )
        {
            InitializeComponent();

            _companyInfoService = companyInfoService;
            _memberService = memberService;
            _userTransactionService = userTransactionService;
            _soldItemService = soldItemService;
            _employeeService = employeeService;
            _reportService = reportService;
            _posDetailService = posDetailService;

            _isPrintOnly = true;
            _selectedInvoiceNo = invoiceNo;
            _soldItemViewList = _soldItemService.GetSoldItemViewList(_selectedInvoiceNo).ToList();
            LoadItems(_soldItemViewList);
            LoadMemberDetails(memberId);
            LoadPosDetails(_selectedInvoiceNo);
            EnableFields();
            EnableFields(Action.LoadToPrintInvoice);
        }
        #endregion

        #region Form Load Event
        private void PosForm_Load(object sender, EventArgs e)
        {
            if(!_isPrintOnly)
            {
                LoadItems(_soldItemViewList);
                LoadDeliveryPersons();
                EnableFields();
                EnableFields(Action.Load);
                BtnAddSale.Select();
            }
            else
            {
                BtnSaveInvoice.Text = "Print Receipt";
            }
        }
        #endregion

        #region Button Click Event

        private void BtnSearchMember_Click(object sender, EventArgs e)
        {
            MemberListForm memberListForm = new MemberListForm(_memberService, 
                _capitalService, this);
            memberListForm.ShowDialog();
            EnableFields();
            EnableFields(Action.SearchMember);
            RichItemCode.Focus();
        }

        private void BtnSaveReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToDecimal(RichPayment.Text) > Convert.ToDecimal(TxtBalance.Text))
                {
                    var warningResult = MessageBox.Show("Receipt cannot be greater than balance.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if(warningResult == DialogResult.OK)
                    {
                        RichPayment.Focus();
                    }
                }
                else
                {
                    var userTransaction = new UserTransaction
                    {
                        EndOfDay = TxtInvoiceDate.Text,
                        MemberId = RichMemberId.Text,
                        Action = Constants.RECEIPT,
                        ActionType = Constants.CASH,
                        ReceivedAmount = Convert.ToDecimal(RichPayment.Text),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _userTransactionService.AddUserTransaction(userTransaction);
                    DialogResult informationResult = MessageBox.Show("Payment has been added successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (informationResult == DialogResult.OK)
                    {
                        ClearAllMemberFields();
                        ClearAllItemFields();
                        ClearAllInvoiceFields();
                        _soldItemViewList.Clear();
                        LoadItems(_soldItemViewList);
                        RadioBtnCash.Checked = false;
                        RadioBtnCredit.Checked = true;
                        EnableFields();
                        EnableFields(Action.SaveReceipt);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void BtnSearchItem_Click(object sender, EventArgs e)
        {
            PricedItemListForm pricedItemListForm = new PricedItemListForm(_pricedItemService, this);
            pricedItemListForm.ShowDialog();
            EnableFields();
            EnableFields(Action.SearchPricedItem);
            RichItemQuantity.Focus();
        }

        private void BtnTransaction_Click(object sender, EventArgs e)
        {
            DailyTransactionForm transactionForm = new DailyTransactionForm(_username, 
                _settingService, _bankTransactionService, _purchasedItemService,
               _soldItemService, _userTransactionService, _userService, _stockAdjustmentService, _posDetailService);
            transactionForm.Show();
            EnableFields();
            EnableFields(Action.Transaction);
        }

        private void BtnAddReceipt_Click(object sender, EventArgs e)
        {
            RichPayment.Enabled = true;
            EnableFields();
            EnableFields(Action.AddReceipt);
            RichPayment.Focus();
        }

        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(_username,
                _settingService, _bankService, 
                _bankTransactionService, _userTransactionService,
                _incomeExpenseService, _capitalService);
            expenseForm.Show();
            EnableFields();
            EnableFields(Action.AddExpense);
        }

        private void BtnBankTransfer_Click(object sender, EventArgs e)
        {
            BankTransferForm bankTransferForm = new BankTransferForm(_username,
                _settingService, _bankService, 
                _bankTransactionService, _userTransactionService,
                _capitalService);
            bankTransferForm.Show();
            EnableFields();
            EnableFields(Action.BankTransfer);
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridSoldItemList.SelectedRows.Count == 1)
                {
                    var selectedRow = DataGridSoldItemList.SelectedRows[0];
                    var id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    var itemToRemove = _soldItemViewList.Single(x => x.Id == id);
                    _soldItemViewList.Remove(itemToRemove);
                    LoadItems(_soldItemViewList);
                    LoadPosDetails(itemToRemove);
                    EnableFields();
                    EnableFields(Action.RemoveItem);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                AddItemInCart();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void BtnSaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isPrintOnly)
                {
                    OpenInvoiceReport(_companyInfoService, _reportService, _selectedInvoiceNo);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(ComboDeliveryPerson.Text) && TxtDeliveryChargePercent.Text != "0.00")
                    {
                        DialogResult dialogResult = MessageBox.Show("Please fill the following fields: \n Delivery Person",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.OK)
                        {
                            return;
                        }
                    }

                    var balance = string.IsNullOrWhiteSpace(RichBalanceAmount.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichBalanceAmount.Text.Trim());
                    if (RadioBtnCash.Checked && (balance != Constants.DEFAULT_DECIMAL_VALUE))
                    {
                        DialogResult dialogResult = MessageBox.Show("Balance should be zero",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.OK)
                        {
                            return;
                        }
                    }

                    _soldItemViewList.ForEach(x =>
                    {
                        var soldItem = new SoldItem
                        {
                            EndOfDay = TxtInvoiceDate.Text.Trim(),
                            MemberId = RichMemberId.Text.Trim(),
                            InvoiceNo = TxtInvoiceNo.Text.Trim(),
                            ItemId = _itemService.GetItem(x.ItemCode).Id,
                            Profit = x.Profit,
                            Unit = x.Unit,
                            Volume = x.Volume,
                            Quantity = x.Quantity,
                            Price = x.ItemPrice,
                            AddedBy = x.AddedBy,
                            AddedDate = x.AddedDate
                        };

                        _soldItemService.AddSoldItem(soldItem);
                    });

                    ComboBoxItem selectedDeliveryPerson = (ComboBoxItem)ComboDeliveryPerson.SelectedItem;
                    var userTransaction = new UserTransaction
                    {
                        EndOfDay = TxtInvoiceDate.Text.Trim(),
                        InvoiceNo = TxtInvoiceNo.Text.Trim(),
                        MemberId = RichMemberId.Text.Trim(),
                        DeliveryPersonId = selectedDeliveryPerson?.Id.Trim(),
                        Action = Constants.SALES,
                        ActionType = RadioBtnCredit.Checked ? Constants.CREDIT : Constants.CASH,
                        DueReceivedAmount = string.IsNullOrWhiteSpace(RichBalanceAmount.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichBalanceAmount.Text.Trim()),
                        ReceivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichReceivedAmount.Text.Trim()),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _userTransactionService.AddUserTransaction(userTransaction);

                    var posDetail = new POSDetail
                    {
                        InvoiceNo = TxtInvoiceNo.Text.Trim(),
                        SubTotal = Convert.ToDecimal(TxtSubTotal.Text.Trim()),
                        DiscountPercent = Convert.ToDecimal(TxtDiscountPercent.Text.Trim()),
                        Discount = Convert.ToDecimal(TxtDiscount.Text.Trim()),
                        DeliveryChargePercent = Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim()),
                        DeliveryCharge = Convert.ToDecimal(TxtDeliveryCharge.Text.Trim()),
                    };

                    _posDetailService.AddPOSDetail(posDetail);

                    var lastUserTransaction = _userTransactionService.GetLastUserTransaction(string.Empty);

                    // Add Sales Discount
                    if (Convert.ToDecimal(TxtDiscount.Text) != Constants.DEFAULT_DECIMAL_VALUE)
                    {
                        var userTransactionForSalesDiscount = new UserTransaction
                        {
                            EndOfDay = _endOfDay,
                            InvoiceNo = TxtInvoiceNo.Text.Trim(),
                            MemberId = RichMemberId.Text.Trim(),
                            Action = Constants.EXPENSE,
                            ActionType = RadioBtnCredit.Checked ? Constants.CREDIT : Constants.CASH,
                            Expense = Constants.SALES_DISCOUNT,
                            PaymentAmount = Convert.ToDecimal(TxtDiscount.Text.Trim()),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };

                        _userTransactionService.AddUserTransaction(userTransactionForSalesDiscount);
                    }

                    // Add Delivery Charge
                    if (Convert.ToDecimal(TxtDeliveryCharge.Text) != Constants.DEFAULT_DECIMAL_VALUE)
                    {
                        var userTransactionForDeliveryCharge = new UserTransaction
                        {
                            EndOfDay = _endOfDay,
                            InvoiceNo = TxtInvoiceNo.Text.Trim(),
                            MemberId = RichMemberId.Text.Trim(),
                            DeliveryPersonId = selectedDeliveryPerson?.Id.Trim(),
                            Action = Constants.INCOME,
                            ActionType = RadioBtnCredit.Checked ? Constants.CREDIT : Constants.CASH,
                            Income = Constants.DELIVERY_CHARGE,
                            ReceivedAmount = Convert.ToDecimal(TxtDeliveryCharge.Text.Trim()),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };

                        _userTransactionService.AddUserTransaction(userTransactionForDeliveryCharge);
                    }

                    ClearAllMemberFields();
                    ClearAllItemFields();
                    ClearAllInvoiceFields();
                    _soldItemViewList.Clear();
                    LoadItems(_soldItemViewList);
                    EnableFields();
                    EnableFields(Action.SaveAndPrint);
                    RadioBtnCash.Checked = false;
                    RadioBtnCredit.Checked = true;
                    ComboDeliveryPerson.Text = string.Empty;

                    DialogResult result = MessageBox.Show(userTransaction.InvoiceNo + " has been added successfully. \n Would you like to print the receipt?",
                        "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        OpenInvoiceReport(_companyInfoService, _reportService, _selectedInvoiceNo);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void BtnAddSale_Click(object sender, EventArgs e)
        {
            _selectedInvoiceNo = _userTransactionService.GetInvoiceNo();
            TxtInvoiceNo.Text = _selectedInvoiceNo;
            TxtInvoiceDate.Text = _endOfDay;
            RichMemberId.Enabled = true;
            RichItemCode.Enabled = true;

            EnableFields();
            EnableFields(Action.AddSale);
            RichMemberId.Focus();
        }
        #endregion

        #region RichTextBox Event
        private void RichReceivedAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void RichReceivedAmount_KeyUp(object sender, KeyEventArgs e)
        {
            RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(TxtDeliveryChargeTotal.Text) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text) 
                ? Constants.DEFAULT_DECIMAL_VALUE.ToString() 
                : RichReceivedAmount.Text), 2).ToString();
        }

        private void RichItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void RichItemQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            BtnAddToCart.Enabled = true;
        }

        private void RichItemQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;

                var volumne = string.IsNullOrWhiteSpace(TxtVolume.Text) ? 0 : Convert.ToInt64(TxtVolume.Text);
                var quantity = Convert.ToInt32(RichItemQuantity.Text);
                var stock = string.IsNullOrWhiteSpace(TxtItemStock.Text) ? 0 : Convert.ToDecimal(TxtItemStock.Text);
                
                if ((volumne * quantity) > stock)
                {
                    DialogResult result = MessageBox.Show("No sufficient stock!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        return;
                    }
                }

                AddItemInCart();
            }
        }

        private void RichMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void RichMemberId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                var memberId = RichMemberId.Text;
                PopulateMember(memberId);
            }
        }

        private void RichItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void RichItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                try
                {
                    var codes = RichItemCode.Text.Replace("\n", "").Split(separator);
                    var itemCode = codes[0];
                    var itemSubCode = codes.Length > 1 ? codes[1] : string.Empty;
                    
                    var pricedItem = _pricedItemService.GetPricedItem(itemCode, itemSubCode);
                    if (pricedItem.ItemId == 0)
                    {
                        DialogResult result = MessageBox.Show("Invalid item code : " + RichItemCode.Text,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            return;
                        }
                    }

                    CalculatePricedItem(pricedItem);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        #endregion

        #region Text Box Event
        private void TxtDiscountPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtDeliveryChargePercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtDiscountPercent_KeyUp(object sender, KeyEventArgs e)
        {
            TxtDiscount.Text = Math.Round((Convert.ToDecimal(TxtSubTotal.Text) * (Convert.ToDecimal(TxtDiscountPercent.Text) / 100)), 2).ToString();
            TxtDiscountTotal.Text = Math.Round(Convert.ToDecimal(TxtSubTotal.Text) - (Convert.ToDecimal(TxtSubTotal.Text) * (Convert.ToDecimal(TxtDiscountPercent.Text) / 100)), 2).ToString();
            TxtDeliveryCharge.Text = Math.Round((Convert.ToDecimal(TxtDiscountTotal.Text) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text) / 100)), 2).ToString();
            TxtDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(TxtDiscountTotal.Text) + (Convert.ToDecimal(TxtDiscountTotal.Text) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text) / 100)), 2).ToString();
            TxtGrandTotal.Text = TxtDeliveryChargeTotal.Text;
            RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(TxtDeliveryChargeTotal.Text) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text)
                ? Constants.DEFAULT_DECIMAL_VALUE.ToString()
                : RichReceivedAmount.Text), 2).ToString();
        }

        private void TxtDeliveryChargePercent_KeyUp(object sender, KeyEventArgs e)
        {
            TxtDeliveryCharge.Text = Math.Round((Convert.ToDecimal(TxtDiscountTotal.Text) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text) / 100)), 2).ToString();
            TxtDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(TxtDiscountTotal.Text) + (Convert.ToDecimal(TxtDiscountTotal.Text) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text) / 100)), 2).ToString();
            TxtGrandTotal.Text = TxtDeliveryChargeTotal.Text;
            RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(TxtDeliveryChargeTotal.Text) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text)
                ? Constants.DEFAULT_DECIMAL_VALUE.ToString()
                : RichReceivedAmount.Text), 2).ToString();
        }
        #endregion

        #region Radio Button Event
        private void RadioBtnCredit_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioBtnCredit.Checked)
            {
                RichReceivedAmount.Enabled = false;
            }
        }

        private void RadioBtnCash_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioBtnCash.Checked)
            {
                RichReceivedAmount.Enabled = true;
                RichReceivedAmount.Focus();
            }
        }

        #endregion

        #region Check Box Event
        private void ChkBoxDiscountPercent_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkBoxDiscountPercent.Checked)
            {
                TxtDiscountPercent.ReadOnly = false;
                TxtDiscountPercent.Focus();
            }
            else
            {
                TxtDiscountPercent.ReadOnly = true;
                TxtDiscountPercent.Text = _setting.Discount.ToString();
            }
        }

        private void ChkBoxDeliveryChargePercent_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkBoxDeliveryChargePercent.Checked)
            {
                TxtDeliveryChargePercent.ReadOnly = false;
                TxtDeliveryChargePercent.Focus();
            }
            else
            {
                TxtDeliveryChargePercent.ReadOnly = true;
                TxtDeliveryChargePercent.Text = _setting.DeliveryCharge.ToString();
            }
        }
        #endregion

        #region Combobox Event
        private void ComboPayment_SelectedValueChanged(object sender, EventArgs e)
        {
            RichPayment.Enabled = true;
            BtnSaveReceipt.Enabled = true;
            RichPayment.Focus();
        }

        #endregion

        #region DataGrid Event
        private void DataGridPosSoldItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DataGridSoldItemList.Columns["Id"].Visible = false;
                DataGridSoldItemList.Columns["Profit"].Visible = false;
                DataGridSoldItemList.Columns["AddedBy"].Visible = false;
                DataGridSoldItemList.Columns["AddedDate"].Visible = false;

                DataGridSoldItemList.Columns["ItemCode"].HeaderText = "Code";
                DataGridSoldItemList.Columns["ItemCode"].Width = 80;
                DataGridSoldItemList.Columns["ItemCode"].DisplayIndex = 0;

                DataGridSoldItemList.Columns["ItemName"].HeaderText = "Name";
                DataGridSoldItemList.Columns["ItemName"].Width = 210;
                DataGridSoldItemList.Columns["ItemName"].DisplayIndex = 1;

                DataGridSoldItemList.Columns["ItemBrand"].HeaderText = "Brand";
                DataGridSoldItemList.Columns["ItemBrand"].Width = 155;
                DataGridSoldItemList.Columns["ItemBrand"].DisplayIndex = 2;

                DataGridSoldItemList.Columns["Volume"].HeaderText = "Volume";
                DataGridSoldItemList.Columns["Volume"].Width = 65;
                DataGridSoldItemList.Columns["Volume"].DisplayIndex = 3;
                DataGridSoldItemList.Columns["Volume"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridSoldItemList.Columns["Unit"].HeaderText = "Unit";
                DataGridSoldItemList.Columns["Unit"].Width = 47;
                DataGridSoldItemList.Columns["Unit"].DisplayIndex = 4;
                DataGridSoldItemList.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridSoldItemList.Columns["Quantity"].HeaderText = "Quantity";
                DataGridSoldItemList.Columns["Quantity"].Width = 63;
                DataGridSoldItemList.Columns["Quantity"].DisplayIndex = 5;
                DataGridSoldItemList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridSoldItemList.Columns["ItemPrice"].HeaderText = "Price";
                DataGridSoldItemList.Columns["ItemPrice"].Width = 80;
                DataGridSoldItemList.Columns["ItemPrice"].DisplayIndex = 6;
                DataGridSoldItemList.Columns["ItemPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridSoldItemList.Columns["Total"].HeaderText = "Total";
                DataGridSoldItemList.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DataGridSoldItemList.Columns["Total"].DisplayIndex = 7;
                DataGridSoldItemList.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                foreach (DataGridViewRow row in DataGridSoldItemList.Rows)
                {
                    DataGridSoldItemList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                    DataGridSoldItemList.RowHeadersWidth = 50;
                    DataGridSoldItemList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadItems(List<SoldItemView> soldItemGrids)
        {
            try
            {
                var bindingList = new BindingList<SoldItemView>(soldItemGrids);
                var source = new BindingSource(bindingList, null);
                DataGridSoldItemList.DataSource = source;
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void AddItemInCart()
        {
            try
            {
                _soldItemViewList.Add(new SoldItemView
                {
                    Id = DataGridSoldItemList.RowCount,
                    ItemCode = RichItemCode.Text.Split(separator)[0],
                    ItemName = TxtItemName.Text,
                    ItemBrand = TxtItemBrand.Text,
                    Profit = string.IsNullOrWhiteSpace(TxtItemPrice.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtProfitAmount.Text),
                    Unit = TxtPricedUnit.Text,
                    ItemPrice = string.IsNullOrWhiteSpace(TxtItemPrice.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtItemPrice.Text),
                    Volume = Convert.ToInt64(TxtVolume.Text),
                    Quantity = string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichItemQuantity.Text),
                    Total = Math.Round((string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichItemQuantity.Text)) * (string.IsNullOrWhiteSpace(TxtItemPrice.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtItemPrice.Text)), 2),
                    AddedBy = _username,
                    AddedDate = DateTime.Now
                }); ;


                LoadItems(_soldItemViewList);

                LoadPosDetails();

                ClearAllItemFields();

                EnableFields();
                EnableFields(Action.AddToCart);
                PicBoxItemImage.Image = PicBoxItemImage.InitialImage;
                RichItemCode.Focus();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void ClearAllMemberFields()
        {
            RichMemberId.Clear();
            TxtAccNo.Clear();
            TxtName.Clear();
            TxtAddress.Clear();
            TxtContactNo.Clear();
            RichPayment.Clear();
            TxtBalance.Clear();
        }

        private void ClearAllItemFields()
        {
            RichItemCode.Clear();
            TxtItemName.Clear();
            TxtItemBrand.Clear();
            TxtItemPrice.Clear();
            RichItemQuantity.Clear();
            TxtItemUnit.Clear();
            TxtVolume.Clear();
            TxtProfitAmount.Clear();
            TxtItemStock.Clear();
            TxtPricedUnit.Clear();
            PicBoxItemImage.Image = null;
        }

        private void ClearAllInvoiceFields()
        {
            TxtInvoiceNo.Clear();
            TxtInvoiceDate.Clear();
            TxtSubTotal.Clear();
            TxtDiscountPercent.Clear();
            TxtDiscount.Clear();
            TxtDiscountTotal.Clear();
            TxtDeliveryChargePercent.Clear();
            TxtDeliveryCharge.Clear();
            TxtDeliveryChargeTotal.Clear();
            TxtGrandTotal.Clear();
            RichReceivedAmount.Clear();

            RichBalanceAmount.Clear();
        }

        private void EnableFields(Action action = Action.None)
        {
            if(action == Action.AddExpense)
            {
                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if(action == Action.AddReceipt)
            {
                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnSaveReceipt.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.AddSale)
            {
                BtnTransaction.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
            }
            else if (action == Action.AddToCart)
            {
                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnRemoveItem.Enabled = true;
                BtnAddToCart.Enabled = true;
                BtnSaveInvoice.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.BankTransfer)
            {
                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnRemoveItem.Enabled = true;
                BtnAddToCart.Enabled = true;
                BtnSaveInvoice.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.Load)
            {
                BtnTransaction.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.LoadToPrintInvoice)
            {
                BtnSaveInvoice.Enabled = true;
            }
            else if (action == Action.RemoveItem)
            {
                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnRemoveItem.Enabled = true;
                BtnAddToCart.Enabled = true;
                BtnSaveInvoice.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.SaveAndPrint)
            {
                BtnTransaction.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.SaveReceipt)
            {
                BtnTransaction.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.SearchMember)
            {
                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddReceipt.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.SearchPricedItem)
            {
                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnRemoveItem.Enabled = true;
                BtnAddToCart.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.Transaction)
            {
                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnRemoveItem.Enabled = true;
                BtnAddToCart.Enabled = true;
                BtnSaveInvoice.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else 
            {
                BtnSearchMember.Enabled = false;
                BtnSearchItem.Enabled = false;
                BtnSaveReceipt.Enabled = false;
                BtnTransaction.Enabled = false;
                BtnAddReceipt.Enabled = false;
                BtnAddExpense.Enabled = false;
                BtnBankTransfer.Enabled = false;
                BtnRemoveItem.Enabled = false;
                BtnAddToCart.Enabled = false;
                BtnSaveInvoice.Enabled = false;
                BtnAddSale.Enabled = false;
            }
        }

        public void PopulateMember(string memberId)
        {
            try
            {
                var member = _memberService.GetMember(memberId);
                if(string.IsNullOrWhiteSpace(member?.MemberId))
                {
                    DialogResult result = MessageBox.Show("Invalid member id : " + memberId,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        return;
                    }
                }

                RichMemberId.Text = member.MemberId;
                TxtName.Text = member.Name;
                TxtAddress.Text = member.Address;
                TxtContactNo.Text = member.ContactNo.ToString();
                TxtAccNo.Text = member.AccountNo;

                List<UserTransaction> userTransactions = _userTransactionService.GetUserTransactions(new UserTransactionFilter() { MemberId = memberId }).ToList();
                TxtBalance.Text = _capitalService.GetMemberTotalBalance(new UserTransactionFilter() { MemberId = memberId }).ToString();

                BtnAddReceipt.Enabled = true;
                RichItemCode.Focus();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public void PopulatePricedItem(long pricedId)
        {
            try
            {
                var pricedItem = _pricedItemService.GetPricedItem(pricedId);
                CalculatePricedItem(pricedItem);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public void CalculatePricedItem(PricedItem pricedItem)
        {
            try
            {
                var item = _itemService.GetItem(pricedItem.ItemId);
                StockFilter stockFilter = new StockFilter
                {
                    ItemCode = item.Code
                };

                var stock = _purchasedItemService.GetPurchasedItemTotalQuantity(stockFilter) - _soldItemService.GetSoldItemTotalQuantity(stockFilter);
                if(stock < item.Threshold)
                {
                    DialogResult result = MessageBox.Show("Low stock, add more.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        TxtItemStock.ForeColor = Color.Red;
                    }
                }

                RichItemCode.Text = item.Code + separator + pricedItem.SubCode;
                TxtItemName.Text = item.Name;
                TxtItemBrand.Text = item.Brand;
                TxtItemUnit.Text = item.Unit;
                TxtVolume.Text = pricedItem.Volume.ToString();

                // Start: Calculation Per Unit Value, Custom Per Unit Value, Profit Amount, Sales Price Logic
                var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var perUnitValue = _stockService.GetPerUnitValue(stocks.ToList(), stockFilter);
                var customPerUnitValue = perUnitValue;
                
                customPerUnitValue = (perUnitValue * pricedItem.Volume);

                var profitPercent = pricedItem.ProfitPercent;
                var profitAmount = Math.Round(customPerUnitValue * (profitPercent / 100), 2);
                var salesPrice = customPerUnitValue + profitAmount;
                TxtItemPrice.Text = Math.Round(salesPrice, 2).ToString();
                TxtPricedUnit.Text = item.Unit;
                // End

                TxtItemStock.Text = stock.ToString();
                if (File.Exists(pricedItem.ImagePath))
                {
                    PicBoxItemImage.ImageLocation = pricedItem.ImagePath;
                }

                TxtProfitAmount.Text = profitAmount.ToString();
                RichItemQuantity.Enabled = true;
                RichItemQuantity.Focus();
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void LoadPosDetails(SoldItemView soldItemGrid = null)
        {
            try
            {
                TxtDiscountPercent.Text = _setting.Discount.ToString();
                TxtDeliveryChargePercent.Text = _setting.DeliveryCharge.ToString();

                decimal subTotal;
                if (soldItemGrid == null)
                {
                    subTotal = string.IsNullOrWhiteSpace(TxtSubTotal.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtSubTotal.Text);
                    TxtSubTotal.Text = (subTotal + Math.Round((Convert.ToDecimal(TxtItemPrice.Text) * Convert.ToDecimal(RichItemQuantity.Text)), 2)).ToString();
                }
                else
                {
                    subTotal = Convert.ToDecimal(TxtSubTotal.Text) - soldItemGrid.Total;
                    TxtSubTotal.Text = subTotal.ToString();
                }

                TxtDiscount.Text = Math.Round((Convert.ToDecimal(TxtSubTotal.Text) * (Convert.ToDecimal(TxtDiscountPercent.Text) / 100)), 2).ToString();
                TxtDiscountTotal.Text = Math.Round(Convert.ToDecimal(TxtSubTotal.Text) - (Convert.ToDecimal(TxtSubTotal.Text) * (Convert.ToDecimal(TxtDiscountPercent.Text) / 100)), 2).ToString();
                TxtDeliveryCharge.Text = Math.Round((Convert.ToDecimal(TxtDiscountTotal.Text) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text) / 100)), 2).ToString();
                TxtDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(TxtDiscountTotal.Text) + (Convert.ToDecimal(TxtDiscountTotal.Text) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text) / 100)), 2).ToString();
                TxtGrandTotal.Text = TxtDeliveryChargeTotal.Text;
                RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(TxtDeliveryChargeTotal.Text) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text) 
                    ? Constants.DEFAULT_DECIMAL_VALUE.ToString() 
                    : RichReceivedAmount.Text), 2).ToString();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void LoadMemberDetails(string memberId)
        {
            try
            {
                var member = _memberService.GetMember(memberId);

                RichMemberId.Text = member.MemberId;
                TxtAccNo.Text = member.AccountNo;
                TxtName.Text = member.Name;
                TxtAddress.Text = member.Address;
                TxtContactNo.Text = member.ContactNo.ToString();
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void LoadPosDetails(string invoiceNo)
        {
            try
            {
                var posDetailView = _posDetailService.GetPOSDetailView(invoiceNo);

                if(posDetailView.ActionType == Constants.CASH)
                {
                    RadioBtnCash.Checked = true;
                    RadioBtnCredit.Checked = false;
                }
                else if(posDetailView.ActionType == Constants.CREDIT)
                {
                    RadioBtnCash.Checked = false;
                    RadioBtnCredit.Checked = true;
                }

                TxtInvoiceNo.Text = invoiceNo;
                TxtInvoiceDate.Text = posDetailView.EndOfDay;
                ComboDeliveryPerson.Text = _employeeService.GetEmployee(posDetailView.DeliveryPersonId).Name;
                TxtSubTotal.Text = posDetailView.SubTotal.ToString();
                TxtDiscountPercent.Text = posDetailView.DiscountPercent.ToString();
                TxtDiscount.Text = posDetailView.Discount.ToString();
                TxtDiscountTotal.Text = (posDetailView.SubTotal - posDetailView.Discount).ToString();
                TxtDeliveryChargePercent.Text = posDetailView.DeliveryChargePercent.ToString();
                TxtDeliveryCharge.Text = posDetailView.DeliveryCharge.ToString();
                TxtDeliveryChargeTotal.Text = (posDetailView.SubTotal - posDetailView.Discount + posDetailView.Vat + posDetailView.DeliveryCharge).ToString();
                TxtGrandTotal.Text = posDetailView.DueReceivedAmount.ToString();
                RichReceivedAmount.Text = posDetailView.ReceivedAmount.ToString();
                RichBalanceAmount.Text = (posDetailView.DueReceivedAmount - posDetailView.ReceivedAmount).ToString();
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void LoadDeliveryPersons()
        {
            try
            {
                var deliveryPersons = _employeeService.GetDeliveryPersons().ToList();
                ComboDeliveryPerson.Items.Clear();
                ComboDeliveryPerson.ValueMember = "Id";
                ComboDeliveryPerson.DisplayMember = "Value";

                deliveryPersons.OrderBy(x => x.Name).ToList().ForEach(x =>
                {
                    ComboDeliveryPerson.Items.Add(new ComboBoxItem { Id = x.EmployeeId, Value = x.Name });
                });

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void OpenInvoiceReport(ICompanyInfoService companyInfoService, IReportService reportService, string invoiceNo)
        {
            var invoiceReportForm = new InvoiceReportForm(companyInfoService, reportService, invoiceNo);
            invoiceReportForm.ShowDialog();
        }

        #endregion
    }
}
