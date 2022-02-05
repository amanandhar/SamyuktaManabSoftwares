using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
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
        private readonly IIncomeExpenseService _incomeExpenseService;
        private readonly ICapitalService _capitalService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;
        private string _selectedInvoiceNo;
        private readonly List<SoldItemView> _soldItemViewList = new List<SoldItemView>();
        private readonly bool _isPrintOnly = false;
        private bool _isAddReceipt = false;
        private string _baseImageFolder;
        private string _itemImageFolder;

        private decimal _itemDiscountPercent;
        private decimal _itemDiscountThreshold;
        private const char SEPARATOR = '.';

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
            SalesReturn,
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
            IPOSDetailService posDetailService, IIncomeExpenseService incomeExpenseService,
            ICapitalService capitalService
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
            IPOSDetailService posDetailService, ICapitalService capitalService
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
            _capitalService = capitalService;

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
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
            _itemImageFolder = ConfigurationManager.AppSettings[Constants.ITEM_IMAGE_FOLDER].ToString();

            if (!_isPrintOnly)
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
            if (_isAddReceipt)
            {
                RichPayment.Focus();
            }
            else
            {
                RichItemCode.Focus();
            }
        }

        private void BtnSalesReturn_Click(object sender, EventArgs e)
        {

        }

        private void BtnSaveReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePosTransaction())
                {
                    if (Convert.ToDecimal(RichPayment.Text) > Convert.ToDecimal(TxtBalance.Text))
                    {
                        var warningResult = MessageBox.Show("Receipt cannot be greater than balance.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (warningResult == DialogResult.OK)
                        {
                            RichPayment.Focus();
                        }
                    }
                    else
                    {
                        var userTransaction = new UserTransaction
                        {
                            EndOfDay = TxtInvoiceDate.Text.Trim(),
                            Action = Constants.RECEIPT,
                            ActionType = Constants.CASH,
                            PartyId = RichMemberId.Text.Trim(),
                            ReceivedAmount = Convert.ToDecimal(RichPayment.Text.Trim()),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };

                        _userTransactionService.AddUserTransaction(userTransaction);
                        DialogResult informationResult = MessageBox.Show("Payment has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
                _settingService, _purchasedItemService, 
                _soldItemService,_userTransactionService, 
                _userService);
            transactionForm.ShowDialog();
        }

        private void BtnAddReceipt_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.AddReceipt);
            _isAddReceipt = true;
            RichMemberId.Focus();
        }

        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(_username,
                _settingService, _bankService,
                _bankTransactionService, _incomeExpenseService,
                _capitalService);
            expenseForm.ShowDialog();
        }

        private void BtnBankTransfer_Click(object sender, EventArgs e)
        {
            BankTransferForm bankTransferForm = new BankTransferForm(_username,
                _settingService, _bankService,
                _bankTransactionService, _capitalService);
            bankTransferForm.ShowDialog();
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
                    RichItemCode.Focus();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePosItem())
                {
                    AddItemInCart();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnSaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePosInfo())
                {
                    if (_isPrintOnly)
                    {
                        OpenInvoiceReport(_companyInfoService, _reportService, _selectedInvoiceNo);
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(ComboDeliveryPerson.Text.Trim()) && TxtDeliveryChargePercent.Text.Trim() != "0.00")
                        {
                            DialogResult dialogResult = MessageBox.Show("Please choose delivery person.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.OK)
                            {
                                ComboDeliveryPerson.Focus();
                                return;
                            }
                        }

                        var balance = string.IsNullOrWhiteSpace(RichBalanceAmount.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichBalanceAmount.Text.Trim());
                        if (RadioBtnCash.Checked && (balance != Constants.DEFAULT_DECIMAL_VALUE))
                        {
                            DialogResult dialogResult = MessageBox.Show("Balance should be zero",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.OK)
                            {
                                return;
                            }
                        }

                        // Prepare Inputs
                        var soldItems = new List<SoldItem>();
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
                                Discount = x.ItemDiscount,
                                AddedBy = x.AddedBy,
                                AddedDate = x.AddedDate
                            };

                            soldItems.Add(soldItem);
                        });

                        ComboBoxItem selectedDeliveryPerson = (ComboBoxItem)ComboDeliveryPerson.SelectedItem;
                        var userTransaction = new UserTransaction
                        {
                            EndOfDay = TxtInvoiceDate.Text.Trim(),
                            Action = Constants.SALES,
                            ActionType = RadioBtnCredit.Checked ? Constants.CREDIT : Constants.CASH,
                            PartyId = RichMemberId.Text.Trim(),
                            PartyNumber = TxtInvoiceNo.Text.Trim(),
                            DueReceivedAmount = string.IsNullOrWhiteSpace(RichBalanceAmount.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichBalanceAmount.Text.Trim()),
                            ReceivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichReceivedAmount.Text.Trim()),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };

                        var posDetail = new POSDetail
                        {
                            EndOfDay = _endOfDay,
                            InvoiceNo = TxtInvoiceNo.Text.Trim(),
                            SubTotal = Convert.ToDecimal(TxtSubTotal.Text.Trim()),
                            DiscountPercent = Convert.ToDecimal(TxtDiscountPercent.Text.Trim()),
                            Discount = Convert.ToDecimal(TxtDiscount.Text.Trim()),
                            DeliveryChargePercent = Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim()),
                            DeliveryCharge = Convert.ToDecimal(TxtDeliveryCharge.Text.Trim()),
                            DeliveryPersonId = selectedDeliveryPerson?.Id.Trim()
                        };

                        _userTransactionService.SaveSalesDetail(soldItems, userTransaction, posDetail, _username);

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

                        DialogResult result = MessageBox.Show(userTransaction.PartyNumber + " has been added successfully. \n Would you like to print the receipt?",
                            "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnAddSale_Click(object sender, EventArgs e)
        {
            _selectedInvoiceNo = _soldItemService.GetNewInvoiceNumber();
            TxtInvoiceNo.Text = _selectedInvoiceNo;
            TxtInvoiceDate.Text = _endOfDay;
            RichMemberId.Enabled = true;
            RichItemCode.Enabled = true;

            _isAddReceipt = false;

            EnableFields();
            EnableFields(Action.AddSale);
            RichMemberId.Focus();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            PrintDocThermal.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("76mm x 152mm", 299, 598);
            printPreviewDialogThermal.Document = PrintDocThermal;

            ((Form)printPreviewDialogThermal).WindowState = FormWindowState.Maximized;
            ((Form)printPreviewDialogThermal).StartPosition = FormStartPosition.CenterScreen;

            printPreviewDialogThermal.ShowDialog();
        }
        #endregion

        #region Rich Box Event

        private void RichPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void RichReceivedAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void RichReceivedAmount_KeyUp(object sender, KeyEventArgs e)
        {
            RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(TxtDeliveryChargeTotal.Text.Trim()) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim())
                ? Constants.DEFAULT_DECIMAL_VALUE.ToString()
                : RichReceivedAmount.Text.Trim()), 2).ToString();
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
            if(!string.IsNullOrWhiteSpace(RichItemQuantity.Text.Trim()) 
                && Convert.ToDecimal(RichItemQuantity.Text.Trim()) >= _itemDiscountThreshold)
            {
                TxtItemDiscount.Text = Math.Round((Convert.ToDecimal(TxtItemPrice.Text.Trim()) * _itemDiscountPercent) / 100, 2).ToString();
            }
            else
            {
                TxtItemDiscount.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
            }
            
            BtnAddToCart.Enabled = true;
        }

        private void RichItemQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;

                var volume = string.IsNullOrWhiteSpace(TxtItemVolume.Text.Trim()) 
                    ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtItemVolume.Text.Trim());
                var quantity = Convert.ToDecimal(RichItemQuantity.Text);
                var stock = string.IsNullOrWhiteSpace(TxtItemStock.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtItemStock.Text.Trim());
                var orderedQuantity = volume == Constants.DEFAULT_DECIMAL_VALUE ? quantity : (volume * quantity);
                
                if (orderedQuantity > stock)
                {
                    DialogResult result = MessageBox.Show("No sufficient stock!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        return;
                    }
                }

                if (ValidatePosItem())
                {
                    AddItemInCart();
                }
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
                    var itemCode = RichItemCode.Text.Trim();
                    var codes = itemCode.Split(SEPARATOR);
                    var itemSubCode = string.Empty;

                    if (codes.Length == 3)
                    {
                        itemCode = codes[0] + SEPARATOR + codes[1];
                        itemSubCode = codes[2];
                    }

                    var pricedItem = _pricedItemService.GetPricedItem(itemCode, itemSubCode);
                    if (pricedItem.ItemId == 0)
                    {
                        DialogResult result = MessageBox.Show("Invalid item code : " + RichItemCode.Text.Trim(),
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
                    UtilityService.ShowExceptionMessageBox();
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
            if(string.IsNullOrWhiteSpace(TxtDiscountPercent.Text.Trim()))
            {
                TxtDiscountPercent.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
            }

            TxtDiscount.Text = Math.Round((Convert.ToDecimal(TxtSubTotal.Text.Trim()) * (Convert.ToDecimal(TxtDiscountPercent.Text.Trim()) / 100)), 2).ToString();
            TxtDiscountTotal.Text = Math.Round(Convert.ToDecimal(TxtSubTotal.Text.Trim()) - (Convert.ToDecimal(TxtSubTotal.Text.Trim()) * (Convert.ToDecimal(TxtDiscountPercent.Text.Trim()) / 100)), 2).ToString();
            TxtDeliveryCharge.Text = Math.Round((Convert.ToDecimal(TxtDiscountTotal.Text.Trim()) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim()) / 100)), 2).ToString();
            TxtDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(TxtDiscountTotal.Text.Trim()) + (Convert.ToDecimal(TxtDiscountTotal.Text.Trim()) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim()) / 100)), 2).ToString();
            TxtTotal.Text = TxtDeliveryChargeTotal.Text.Trim();
            RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(TxtDeliveryChargeTotal.Text.Trim()) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim())
                ? Constants.DEFAULT_DECIMAL_VALUE.ToString()
                : RichReceivedAmount.Text.Trim()), 2).ToString();
        }

        private void TxtDeliveryChargePercent_KeyUp(object sender, KeyEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TxtDeliveryChargePercent.Text.Trim()))
            {
                TxtDeliveryChargePercent.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
            }

            TxtDeliveryCharge.Text = Math.Round((Convert.ToDecimal(TxtDiscountTotal.Text.Trim()) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim()) / 100)), 2).ToString();
            TxtDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(TxtDiscountTotal.Text.Trim()) + (Convert.ToDecimal(TxtDiscountTotal.Text.Trim()) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim()) / 100)), 2).ToString();
            TxtTotal.Text = TxtDeliveryChargeTotal.Text.Trim();
            RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(TxtDeliveryChargeTotal.Text.Trim()) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim())
                ? Constants.DEFAULT_DECIMAL_VALUE.ToString()
                : RichReceivedAmount.Text.Trim()), 2).ToString();
        }
        #endregion

        #region Combobox Event
        private void ComboPayment_SelectedValueChanged(object sender, EventArgs e)
        {
            RichPayment.Enabled = true;
            BtnSaveReceipt.Enabled = true;
            RichPayment.Focus();
        }

        private void ComboDeliveryPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Radio Button Event
        private void RadioBtnCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioBtnCredit.Checked)
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
            if (ChkBoxDiscountPercent.Checked)
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
            if (ChkBoxDeliveryChargePercent.Checked)
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

        #region Print Document Event
        private void PrintDocThermal_PrintPage(object sender, PrintPageEventArgs e)
        {
            Invoice.PrintThermalInvoice(e);
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
                DataGridSoldItemList.Columns["ItemName"].Width = 290;
                DataGridSoldItemList.Columns["ItemName"].DisplayIndex = 1;

                DataGridSoldItemList.Columns["Unit"].HeaderText = "Unit";
                DataGridSoldItemList.Columns["Unit"].Width = 55;
                DataGridSoldItemList.Columns["Unit"].DisplayIndex = 2;
                DataGridSoldItemList.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridSoldItemList.Columns["Volume"].HeaderText = "Volume";
                DataGridSoldItemList.Columns["Volume"].Width = 65;
                DataGridSoldItemList.Columns["Volume"].DisplayIndex = 3;
                DataGridSoldItemList.Columns["Volume"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridSoldItemList.Columns["Quantity"].HeaderText = "Quantity";
                DataGridSoldItemList.Columns["Quantity"].Width = 65;
                DataGridSoldItemList.Columns["Quantity"].DisplayIndex = 4;
                DataGridSoldItemList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridSoldItemList.Columns["ItemPrice"].HeaderText = "Price";
                DataGridSoldItemList.Columns["ItemPrice"].Width = 80;
                DataGridSoldItemList.Columns["ItemPrice"].DisplayIndex = 5;
                DataGridSoldItemList.Columns["ItemPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridSoldItemList.Columns["ItemDiscount"].HeaderText = "Discount";
                DataGridSoldItemList.Columns["ItemDiscount"].Width = 80;
                DataGridSoldItemList.Columns["ItemDiscount"].DisplayIndex = 6;
                DataGridSoldItemList.Columns["ItemDiscount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void AddItemInCart()
        {
            try
            {
                var itemCode = RichItemCode.Text.Trim();
                var codes = itemCode.Split(SEPARATOR);
                
                if(codes.Length == 3)
                {
                    itemCode = codes[0] + SEPARATOR + codes[1];
                }

                var itemName = TxtItemName.Text.Trim();
                var itemPrice = TxtItemPrice.Text.Trim();
                var itemDiscount = TxtItemDiscount.Text.Trim();
                var profitAmount = TxtProfitAmount.Text.Trim();
                var itemQuantity = RichItemQuantity.Text.Trim();
                var volume = TxtItemVolume.Text.Trim();

                _soldItemViewList.Add(new SoldItemView
                {
                    Id = DataGridSoldItemList.RowCount,
                    ItemCode = itemCode,
                    ItemName = itemName,
                    Profit = string.IsNullOrWhiteSpace(itemPrice)
                        ? Constants.DEFAULT_DECIMAL_VALUE
                        : Convert.ToDecimal(profitAmount),
                    Unit = TxtPricedUnit.Text.Trim(),
                    ItemPrice = string.IsNullOrWhiteSpace(itemPrice)
                        ? Constants.DEFAULT_DECIMAL_VALUE
                        : (Convert.ToDecimal(itemPrice) - Convert.ToDecimal(itemDiscount)),
                    ItemDiscount = string.IsNullOrWhiteSpace(itemDiscount)
                        ? Constants.DEFAULT_DECIMAL_VALUE
                        : Convert.ToDecimal(itemDiscount),
                    Volume = string.IsNullOrWhiteSpace(volume)
                        ? Constants.DEFAULT_DECIMAL_VALUE
                        : Convert.ToDecimal(volume),
                    Quantity = string.IsNullOrWhiteSpace(itemQuantity)
                        ? Constants.DEFAULT_DECIMAL_VALUE
                        : Convert.ToDecimal(itemQuantity),
                    Total = Math.Round((string.IsNullOrWhiteSpace(itemQuantity)
                        ? Constants.DEFAULT_DECIMAL_VALUE
                        : Convert.ToDecimal(itemQuantity)) 
                        * (string.IsNullOrWhiteSpace(itemPrice)
                            ? Constants.DEFAULT_DECIMAL_VALUE
                            : (Convert.ToDecimal(itemPrice) - Convert.ToDecimal(itemDiscount))), 2),
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
                UtilityService.ShowExceptionMessageBox();
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
            TxtItemPrice.Clear();
            TxtItemDiscount.Clear();
            RichItemQuantity.Clear();
            TxtItemVolume.Clear();
            TxtPricedUnitSecondary.Clear();
            TxtProfitAmount.Clear();
            TxtItemStock.Clear();
            TxtPricedUnit.Clear();
            PicBoxItemImage.Image = PicBoxItemImage.InitialImage;
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
            TxtTotal.Clear();
            RichReceivedAmount.Clear();
            RichBalanceAmount.Clear();
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.SalesReturn 
                || action == Action.Transaction
                || action == Action.AddExpense
                || action == Action.BankTransfer
                )
            {
                return;
            }
            else if (action == Action.AddReceipt)
            {
                RichMemberId.Enabled = true;
                RichPayment.Enabled = true;

                BtnSearchMember.Enabled = true;
                BtnSaveReceipt.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddReceipt.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.AddSale)
            {
                RichMemberId.Enabled = true;
                RichItemCode.Enabled = true;

                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddReceipt.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.AddToCart)
            {
                RichItemCode.Enabled = true;

                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddReceipt.Enabled = true;
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
                BtnAddReceipt.Enabled = true;
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
                RichItemCode.Enabled = true;

                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddReceipt.Enabled = true;
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
                BtnAddReceipt.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.SaveReceipt)
            {
                BtnTransaction.Enabled = true;
                BtnAddReceipt.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.SearchMember)
            {
                RichMemberId.Enabled = true;

                if (_isAddReceipt)
                {
                    RichPayment.Enabled = true;
                }
                else
                {
                    RichItemCode.Enabled = true;
                    BtnSearchItem.Enabled = true;
                }

                BtnSearchMember.Enabled = true;
                BtnSaveReceipt.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddReceipt.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.SearchPricedItem)
            {
                RichMemberId.Enabled = true;
                RichItemCode.Enabled = true;

                BtnSearchMember.Enabled = true;
                BtnSearchItem.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddReceipt.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnRemoveItem.Enabled = true;
                BtnAddToCart.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else
            {
                RichMemberId.Enabled = false;
                RichItemCode.Enabled = false;
                RichPayment.Enabled = false;

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
                if (string.IsNullOrWhiteSpace(member?.MemberId))
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
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        public void PopulatePricedItem(long pricedId)
        {
            try
            {
                RichItemQuantity.Clear();
                TxtItemDiscount.Clear();

                var pricedItem = _pricedItemService.GetPricedItem(pricedId);
                CalculatePricedItem(pricedItem);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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

                var stockFromCart = _soldItemViewList.Where(itemFromCart => itemFromCart.ItemCode == item.Code).Sum(x => x.Quantity);
                var stock = _stockService.GetTotalStock(stockFilter) - stockFromCart;
                if (stock < item.Threshold)
                {
                    DialogResult result = MessageBox.Show("Low stock, add more.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        TxtItemStock.ForeColor = Color.Red;
                    }
                }
                else
                {
                    TxtItemStock.ForeColor = Color.Black;
                }

                RichItemCode.Text = item.Code + 
                    (string.IsNullOrWhiteSpace(pricedItem.SubCode) 
                    ? string.Empty 
                    : SEPARATOR + pricedItem.SubCode);
                TxtItemName.Text = item.Name;

                // Start: Calculation Per Unit Value, Custom Per Unit Value, Profit Amount, Sales Price Logic
                var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var perUnitValue = _stockService.GetPerUnitValue(stocks.ToList(), stockFilter);
                var volume = pricedItem.Volume == Constants.DEFAULT_DECIMAL_VALUE ? 1 : pricedItem.Volume;
                var customPerUnitValue = Math.Round(perUnitValue * volume, 2);
                var profitPercent = pricedItem.ProfitPercent;
                var profitAmount = Math.Round(customPerUnitValue * (profitPercent / 100), 2);
                var salesPrice = customPerUnitValue + profitAmount;
                // End

                TxtItemPrice.Text = Math.Round(salesPrice, 2).ToString();
                TxtPricedUnit.Text = item.Unit;
                TxtItemStock.Text = stock.ToString();
                TxtItemVolume.Text = pricedItem.Volume.ToString();
                TxtPricedUnitSecondary.Text = item.Unit;

                _itemDiscountPercent = item.DiscountPercent;
                _itemDiscountThreshold = item.DiscountThreshold;

                var absoluteImagePath = Path.Combine(_baseImageFolder, _itemImageFolder, pricedItem.ImagePath);
                if (File.Exists(absoluteImagePath))
                {
                    PicBoxItemImage.ImageLocation = absoluteImagePath;
                }
                else
                {
                    PicBoxItemImage.Image = PicBoxItemImage.InitialImage;
                }

                TxtProfitAmount.Text = profitAmount.ToString();
                RichItemQuantity.Enabled = true;
                RichItemQuantity.Focus();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
                    subTotal = string.IsNullOrWhiteSpace(TxtSubTotal.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtSubTotal.Text.Trim());
                    TxtSubTotal.Text = (
                        subTotal + Math.Round(
                            (
                                Convert.ToDecimal(TxtItemPrice.Text.Trim()) - Convert.ToDecimal(TxtItemDiscount.Text.Trim())
                            ) 
                            * Convert.ToDecimal(RichItemQuantity.Text.Trim()), 2)
                        ).ToString();
                }
                else
                {
                    subTotal = Convert.ToDecimal(TxtSubTotal.Text.Trim()) - soldItemGrid.Total;
                    TxtSubTotal.Text = subTotal.ToString();
                }

                TxtDiscount.Text = Math.Round((Convert.ToDecimal(TxtSubTotal.Text.Trim()) * (Convert.ToDecimal(TxtDiscountPercent.Text.Trim()) / 100)), 2).ToString();
                TxtDiscountTotal.Text = Math.Round(Convert.ToDecimal(TxtSubTotal.Text.Trim()) - (Convert.ToDecimal(TxtSubTotal.Text.Trim()) * (Convert.ToDecimal(TxtDiscountPercent.Text.Trim()) / 100)), 2).ToString();
                TxtDeliveryCharge.Text = Math.Round((Convert.ToDecimal(TxtDiscountTotal.Text.Trim()) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim()) / 100)), 2).ToString();
                TxtDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(TxtDiscountTotal.Text.Trim()) + (Convert.ToDecimal(TxtDiscountTotal.Text.Trim()) * (Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim()) / 100)), 2).ToString();
                TxtTotal.Text = TxtDeliveryChargeTotal.Text.Trim();
                RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(TxtDeliveryChargeTotal.Text.Trim()) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE.ToString()
                    : RichReceivedAmount.Text.Trim()), 2).ToString();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
                TxtBalance.Text = _capitalService.GetMemberTotalBalance(new UserTransactionFilter() { MemberId = memberId }).ToString();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void LoadPosDetails(string invoiceNo)
        {
            try
            {
                var posDetailView = _posDetailService.GetPOSDetailView(invoiceNo);

                if (posDetailView.ActionType == Constants.CASH)
                {
                    RadioBtnCash.Checked = true;
                    RadioBtnCredit.Checked = false;
                }
                else if (posDetailView.ActionType == Constants.CREDIT)
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
                TxtDiscountTotal.Text = (posDetailView.SubTotal - (posDetailView.SubTotal * (posDetailView.DiscountPercent) / 100)).ToString();
                TxtDeliveryChargePercent.Text = posDetailView.DeliveryChargePercent.ToString();
                TxtDeliveryCharge.Text = posDetailView.DeliveryCharge.ToString();
                TxtDeliveryChargeTotal.Text = (posDetailView.SubTotal - posDetailView.Discount + posDetailView.Vat + posDetailView.DeliveryCharge).ToString();
                TxtTotal.Text = (posDetailView.SubTotal - posDetailView.Discount + posDetailView.Vat + posDetailView.DeliveryCharge).ToString();
                RichReceivedAmount.Text = posDetailView.ReceivedAmount.ToString();
                RichBalanceAmount.Text = (Convert.ToDecimal(TxtTotal.Text.Trim()) - Convert.ToDecimal(RichReceivedAmount.Text.Trim())).ToString();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void OpenInvoiceReport(ICompanyInfoService companyInfoService, IReportService reportService, string invoiceNo)
        {
            var invoiceReportForm = new InvoiceReportForm(companyInfoService, reportService, invoiceNo);
            invoiceReportForm.ShowDialog();
        }

        #endregion

        #region Validation
        private bool ValidatePosItem()
        {
            var isValidated = false;

            var itemCode = RichItemCode.Text.Trim();
            var itemQuantity = RichItemQuantity.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemCode)
                || string.IsNullOrWhiteSpace(itemQuantity))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Item Code " +
                    "\n * Item Quantity ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }

        private bool ValidatePosInfo()
        {
            var isValidated = false;

            var memberId = RichMemberId.Text.Trim();
            var invoiceNo = TxtInvoiceNo.Text.Trim();
            var totalAmount = TxtTotal.Text.Trim();

            if (string.IsNullOrWhiteSpace(memberId)
                || string.IsNullOrWhiteSpace(invoiceNo)
                || string.IsNullOrWhiteSpace(totalAmount))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Member Id " +
                    "\n * Invoice Number " +
                    "\n * Total Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }

        private bool ValidatePosTransaction()
        {
            var isValidated = false;

            var memberId = RichMemberId.Text.Trim();
            var payment = RichPayment.Text.Trim();

            if (string.IsNullOrWhiteSpace(memberId)
                || string.IsNullOrWhiteSpace(payment))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Member Id " +
                    "\n * Payment ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }
        #endregion
    }
}
