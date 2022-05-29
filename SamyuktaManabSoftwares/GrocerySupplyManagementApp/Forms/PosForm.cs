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
        private const char SPLITTER_CHAR = '.';

        private decimal _itemDiscountPercent;
        private decimal _itemDiscountPercent1;
        private decimal _itemDiscountPercent2;

        private decimal _itemDiscountThreshold;
        private decimal _itemDiscountThreshold1;
        private decimal _itemDiscountThreshold2;

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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAllMemberFields();
            ClearAllItemFields();
            ClearAllAmountFields();
            _soldItemViewList.Clear();
            LoadItems(_soldItemViewList);
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
                            ClearAllAmountFields();
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
            CalculateItemDiscount();
            BtnAddToCart.Enabled = true;
            RichItemQuantity.Text = "1";
            RichItemQuantity.Focus();
            RichItemQuantity.SelectAll();
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
                    LoadPosDetails(_soldItemViewList);
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
                        if (RadioBtnCash.Checked && 
                                (balance != Constants.DEFAULT_DECIMAL_VALUE) 
                                && (Convert.ToDecimal(TxtTotal.Text) != Convert.ToDecimal(RichReceivedAmount.Text) - Convert.ToDecimal(TxtChangeMoney.Text)))
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
                                Quantity = CalculateItemQuantity(x.Unit, x.CustomizedUnit, x.Quantity, x.Volume),
                                CustomizedUnit = x.CustomizedUnit,
                                CustomizedQuantity = x.Volume,
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
                            ReceivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim()) 
                            ? Constants.DEFAULT_DECIMAL_VALUE 
                            : Convert.ToDecimal(RichReceivedAmount.Text.Trim()) > Convert.ToDecimal(TxtTotal.Text.Trim()) 
                                ? Convert.ToDecimal(TxtTotal.Text.Trim()) 
                                : Convert.ToDecimal(RichReceivedAmount.Text.Trim()),
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

                        RadioBtnCash.Checked = false;
                        RadioBtnCredit.Checked = true;
                        ComboDeliveryPerson.Text = string.Empty;
                        ChkBoxDiscountPercent.Checked = false;
                        ChkBoxDeliveryChargePercent.Checked = false;

                        ClearAllMemberFields();
                        ClearAllItemFields();
                        ClearAllInvoiceFields();
                        ClearAllAmountFields();
                        _soldItemViewList.Clear();
                        LoadItems(_soldItemViewList);
                        EnableFields();
                        EnableFields(Action.SaveAndPrint);

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
            printDocThermal.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("76mm x 152mm", 299, 598);
            printPreviewDialogThermal.Document = printDocThermal;

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
            var deliveryChargeTotal = Convert.ToDecimal(TxtDeliveryChargeTotal.Text.Trim());
            var totalAmount = string.IsNullOrWhiteSpace(TxtTotal.Text.Trim())
                ? Constants.DEFAULT_DECIMAL_VALUE
                : Convert.ToDecimal(TxtTotal.Text.Trim());
            var receivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim()) 
                ? Constants.DEFAULT_DECIMAL_VALUE 
                : Convert.ToDecimal(RichReceivedAmount.Text.Trim());

            if(receivedAmount > totalAmount)
            {
                RichBalanceAmount.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
                TxtChangeMoney.Text = Math.Round(receivedAmount - totalAmount, 2).ToString();
            }
            else
            {
                RichBalanceAmount.Text = Math.Round(deliveryChargeTotal - receivedAmount, 2).ToString();
                TxtChangeMoney.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
            }
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
            CalculateItemDiscount();            
            BtnAddToCart.Enabled = true;
        }

        private void RichItemQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;

                var volume = string.IsNullOrWhiteSpace(TxtCustomizedQuantity.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE
                    : Convert.ToDecimal(TxtCustomizedQuantity.Text.Trim());
                var quantity = Convert.ToDecimal(RichItemQuantity.Text);
                var stock = string.IsNullOrWhiteSpace(TxtItemStock.Text.Trim()) 
                    ? Constants.DEFAULT_DECIMAL_VALUE 
                    : Convert.ToDecimal(TxtItemStock.Text.Trim());

                if(volume > Constants.DEFAULT_DECIMAL_VALUE)
                {
                    quantity *= volume;
                }

                if (quantity > stock)
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
                var itemCode = RichItemCode.Text.Trim();
                // Without SubCode
                if (itemCode.Length == 8 && itemCode.Contains("."))
                {
                    try
                    {
                        var pricedItem = _pricedItemService.GetPricedItem(itemCode);
                        if (pricedItem.ItemId == 0)
                        {
                            DialogResult result = MessageBox.Show("Invalid item code : " + itemCode,
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
                // With SubCode
                else if ((itemCode.Length == 10 || itemCode.Length == 11) && itemCode.Contains("."))
                {
                    try
                    {
                        var codes = itemCode.Split(SPLITTER_CHAR);
                        itemCode = codes.Length == 3
                            ? codes[0] + SPLITTER_CHAR + codes[1]
                            : itemCode;
                        var itemSubCode = codes.Length == 3 ? codes[2] : string.Empty;

                        var pricedItem = _pricedItemService.GetPricedItem(itemCode, itemSubCode);
                        if (pricedItem.ItemId == 0)
                        {
                            DialogResult result = MessageBox.Show("Invalid item code : " + itemCode + " and subcode : " + itemSubCode,
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
                // Barcode
                else if (itemCode.Length > 8)
                {
                    try
                    {
                        var pricedItem = _pricedItemService.GetPricedItemByBarcode(itemCode);
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

        private void TxtDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtDeliveryCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtDiscountPercent_KeyUp(object sender, KeyEventArgs e)
        {
            CalculatePOSDetailByDiscountPercent();
        }

        private void TxtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtSubTotal.Text.Trim())
                && decimal.TryParse(TxtSubTotal.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtDiscountPercent.Text.Trim())
                && decimal.TryParse(TxtDiscountPercent.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtDiscount.Text.Trim())
                && decimal.TryParse(TxtDiscount.Text.Trim(), out _))
            {
                var subTotal = Convert.ToDecimal(TxtSubTotal.Text.Trim());
                var discount = Convert.ToDecimal(TxtDiscount.Text.Trim());
                var discountPercent = Math.Round((discount * 100) / subTotal, 2);
                var discountTotal = subTotal - discount;
                var deliveryChargePercent = Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim());
                var deliveryCharge = Math.Round((discountTotal * (deliveryChargePercent / 100)), 2);
                var deliveryChargeTotal = discountTotal + deliveryCharge;
                var receivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE
                    : Convert.ToDecimal(RichReceivedAmount.Text.Trim());

                TxtDiscountPercent.Text = discountPercent.ToString();
                TxtDiscountTotal.Text = discountTotal.ToString();
                TxtDeliveryCharge.Text = deliveryCharge.ToString();
                TxtDeliveryChargeTotal.Text = deliveryChargeTotal.ToString();
                TxtTotal.Text = deliveryChargeTotal.ToString();
                RichBalanceAmount.Text = Math.Round(deliveryChargeTotal - receivedAmount, 2).ToString();
            }
        }

        private void TxtDeliveryChargePercent_KeyUp(object sender, KeyEventArgs e)
        {
            CalculatePOSDetailByDeliveryChargePercent();
        }

        private void TxtDeliveryCharge_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtDiscountTotal.Text.Trim())
                && decimal.TryParse(TxtDiscountTotal.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtDeliveryChargePercent.Text.Trim())
                && decimal.TryParse(TxtDeliveryChargePercent.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtDeliveryCharge.Text.Trim())
                && decimal.TryParse(TxtDeliveryCharge.Text.Trim(), out _))
            {
                var discountTotal = Convert.ToDecimal(TxtDiscountTotal.Text.Trim());
                var deliveryCharge = Convert.ToDecimal(TxtDeliveryCharge.Text.Trim());
                var deliveryChargePercent = Math.Round(((deliveryCharge * 100) / discountTotal), 2);
                var deliveryChargeTotal = discountTotal + deliveryCharge;
                var receivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE
                    : Convert.ToDecimal(RichReceivedAmount.Text.Trim());

                TxtDeliveryChargePercent.Text = deliveryChargePercent.ToString();
                TxtDeliveryChargeTotal.Text = deliveryChargeTotal.ToString();
                TxtTotal.Text = deliveryChargeTotal.ToString();
                RichBalanceAmount.Text = Math.Round(deliveryChargeTotal - receivedAmount, 2).ToString();
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
                RichReceivedAmount.Clear();
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
                TxtDiscount.ReadOnly = false;
                TxtDiscountPercent.Focus();
            }
            else
            {
                TxtDiscountPercent.ReadOnly = true;
                TxtDiscount.ReadOnly = true;
                TxtDiscountPercent.Text = _setting.Discount.ToString();

                CalculatePOSDetailByDiscountPercent();
            }
        }

        private void ChkBoxDeliveryChargePercent_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBoxDeliveryChargePercent.Checked)
            {
                TxtDeliveryChargePercent.ReadOnly = false;
                TxtDeliveryCharge.ReadOnly = false;
                TxtDeliveryChargePercent.Focus();
            }
            else
            {
                TxtDeliveryChargePercent.ReadOnly = true;
                TxtDeliveryCharge.ReadOnly = true;
                TxtDeliveryChargePercent.Text = _setting.DeliveryCharge.ToString();

                CalculatePOSDetailByDeliveryChargePercent();
            }
        }
        #endregion

        #region Print Document Event
        private void printDocThermal_PrintPage(object sender, PrintPageEventArgs e)
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
                DataGridSoldItemList.Columns["ItemSubCode"].Visible = false;
                DataGridSoldItemList.Columns["Profit"].Visible = false;
                DataGridSoldItemList.Columns["Unit"].Visible = false;
                DataGridSoldItemList.Columns["CustomizedUnit"].Visible = false;
                DataGridSoldItemList.Columns["AdjustedType"].Visible = false;
                DataGridSoldItemList.Columns["AdjustedAmount"].Visible = false;
                DataGridSoldItemList.Columns["AddedBy"].Visible = false;
                DataGridSoldItemList.Columns["AddedDate"].Visible = false;

                DataGridSoldItemList.Columns["ItemCode"].HeaderText = "Code";
                DataGridSoldItemList.Columns["ItemCode"].Width = 80;
                DataGridSoldItemList.Columns["ItemCode"].DisplayIndex = 0;

                DataGridSoldItemList.Columns["ItemName"].HeaderText = "Name";
                DataGridSoldItemList.Columns["ItemName"].Width = 300;
                DataGridSoldItemList.Columns["ItemName"].DisplayIndex = 1;

                DataGridSoldItemList.Columns["Volume"].HeaderText = "Vol";
                DataGridSoldItemList.Columns["Volume"].Width = 63;
                DataGridSoldItemList.Columns["Volume"].DisplayIndex = 2;
                DataGridSoldItemList.Columns["Volume"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridSoldItemList.Columns["DisplayUnit"].HeaderText = "Unit";
                DataGridSoldItemList.Columns["DisplayUnit"].Width = 63;
                DataGridSoldItemList.Columns["DisplayUnit"].DisplayIndex = 3;
                DataGridSoldItemList.Columns["DisplayUnit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridSoldItemList.Columns["Quantity"].HeaderText = "Qty";
                DataGridSoldItemList.Columns["Quantity"].Width = 63;
                DataGridSoldItemList.Columns["Quantity"].DisplayIndex = 4;
                DataGridSoldItemList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridSoldItemList.Columns["ItemPrice"].HeaderText = "Price";
                DataGridSoldItemList.Columns["ItemPrice"].Width = 89;
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
                var codes = itemCode.Split(SPLITTER_CHAR);
                itemCode = codes.Length == 3
                    ? codes[0] + SPLITTER_CHAR + codes[1]
                    : itemCode;
                var itemSubCode = codes.Length == 3 ? codes[2] : string.Empty;
                var itemName = TxtItemName.Text.Trim();
                var itemUnit = TxtPricedUnit.Text.Trim();
                var itemCustomizedUnit = TxtCustomizedUnit.Text.Trim();
                var itemPrice = string.IsNullOrWhiteSpace(TxtItemPrice.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE
                    : Convert.ToDecimal(TxtItemPrice.Text.Trim());
                var itemDiscount = string.IsNullOrWhiteSpace(TxtItemDiscount.Text.Trim()) 
                    ? Constants.DEFAULT_DECIMAL_VALUE 
                    : Convert.ToDecimal(TxtItemDiscount.Text.Trim());
                var profitAmount = string.IsNullOrWhiteSpace(TxtProfitAmount.Text.Trim()) 
                    ? Constants.DEFAULT_DECIMAL_VALUE 
                    : Convert.ToDecimal(TxtProfitAmount.Text.Trim());
                var itemQuantity = string.IsNullOrWhiteSpace(RichItemQuantity.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE
                    : Convert.ToDecimal(RichItemQuantity.Text.Trim());
                var volume = string.IsNullOrWhiteSpace(TxtCustomizedQuantity.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE
                    : Convert.ToDecimal(TxtCustomizedQuantity.Text.Trim());

                if (_soldItemViewList.Any(soldItem => soldItem.ItemCode == itemCode && soldItem.ItemSubCode == itemSubCode))
                {
                    var soldItem = _soldItemViewList.FirstOrDefault(_soldItem => _soldItem.ItemCode == itemCode && _soldItem.ItemSubCode == itemSubCode);
                    if(soldItem != null)
                    {
                        soldItem.ItemDiscount = itemDiscount != Constants.DEFAULT_DECIMAL_VALUE ? itemDiscount : soldItem.ItemDiscount;
                        soldItem.Quantity += itemQuantity;
                        soldItem.Total = Math.Round(soldItem.Quantity * (itemPrice - soldItem.ItemDiscount), 2);
                    }
                }
                else
                {
                    _soldItemViewList.Add(new SoldItemView
                    {
                        Id = DataGridSoldItemList.RowCount,
                        ItemCode = itemCode,
                        ItemSubCode = itemSubCode,
                        ItemName = itemName,
                        Profit = profitAmount,
                        Unit = itemUnit,
                        CustomizedUnit = itemCustomizedUnit,
                        DisplayUnit = string.IsNullOrWhiteSpace(itemCustomizedUnit) ? itemUnit : itemCustomizedUnit,
                        ItemPrice = itemPrice - itemDiscount,
                        ItemDiscount = itemDiscount,
                        Quantity = itemQuantity,
                        Volume = volume,
                        Total = Math.Round(itemQuantity * (itemPrice - itemDiscount), 2),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    });
                }
                
                LoadItems(_soldItemViewList);

                LoadPosDetails(_soldItemViewList);

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
            TxtProfitAmount.Clear();
            TxtItemStock.Clear();
            TxtPricedUnit.Clear();
            TxtBarcode.Clear();
            TxtCustomizedQuantity.Clear();
            TxtCustomizedUnit.Clear();
            PicBoxItemImage.Image = PicBoxItemImage.InitialImage;
        }

        private void ClearAllInvoiceFields()
        {
            TxtInvoiceNo.Clear();
            TxtInvoiceDate.Clear();
        }

        private void ClearAllAmountFields()
        {
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
            TxtChangeMoney.Clear();
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
                BtnClear.Enabled = true;
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
                BtnClear.Enabled = true;
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
                BtnClear.Enabled = true;
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
                BtnClear.Enabled = true;
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
                BtnClear.Enabled = true;
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
                BtnClear.Enabled = true;
                BtnTransaction.Enabled = true;
                BtnAddReceipt.Enabled = true;
                BtnAddExpense.Enabled = true;
                BtnBankTransfer.Enabled = true;
                BtnAddSale.Enabled = true;
            }
            else if (action == Action.SaveReceipt)
            {
                BtnClear.Enabled = true;
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
                BtnClear.Enabled = true;
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
                BtnClear.Enabled = true;
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
                BtnClear.Enabled = false;
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

        private decimal CalculateItemQuantity(string unit, string customizedUnit, decimal quantity, decimal volume)
        {
            if(!string.IsNullOrWhiteSpace(customizedUnit))
            {
                if(unit == Constants.PIECES && customizedUnit == Constants.PACKET)
                {
                    return Math.Round(quantity * volume, 3);
                }
                else if(unit == Constants.LITER && customizedUnit == Constants.BOX)
                {
                    return Math.Round(quantity * volume, 3);
                }
                else if(unit == Constants.KILOGRAM && customizedUnit == Constants.GRAM)
                {
                    return Math.Round(quantity * volume, 3);
                }
                else
                {
                    return Math.Round(quantity * volume, 3);
                }
            }
            else if(volume != Constants.DEFAULT_DECIMAL_VALUE)
            {
                return Math.Round(quantity * volume, 3);
            }
            else
            {
                return quantity;
            }    
        }

        private void CalculatePricedItem(PricedItem pricedItem)
        {
            try
            {
                var item = _itemService.GetItem(pricedItem.ItemId);
                StockFilter stockFilter = new StockFilter
                {
                    ItemCode = item.Code
                };

                var stockFromCart = Constants.DEFAULT_DECIMAL_VALUE;

                stockFromCart = _soldItemViewList
                    .Where(itemFromCart => itemFromCart.ItemCode == item.Code)
                    .Sum(x => Math.Round(x.Quantity * (x.Volume == Constants.DEFAULT_DECIMAL_VALUE ? 1 : x.Volume), 3));
                
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

                if(string.IsNullOrWhiteSpace(pricedItem.SubCode))
                {
                    RichItemCode.Text = item.Code;
                }
                else
                {
                    RichItemCode.Text = item.Code + SPLITTER_CHAR + pricedItem.SubCode;
                }
                
                TxtItemName.Text = item.Name;

                var stockItem  = _stockService.GetStockItem(pricedItem, stockFilter);
                TxtItemPrice.Text = (pricedItem.CustomizedQuantity == null || pricedItem.CustomizedQuantity == Constants.DEFAULT_DECIMAL_VALUE)
                    ? Math.Round(stockItem.SalesPrice, 2).ToString()
                    : Math.Round(stockItem.SalesPrice * Convert.ToDecimal(pricedItem.CustomizedQuantity), 2).ToString();
                TxtPricedUnit.Text = item.Unit;
                TxtItemStock.Text = stock.ToString();
                TxtBarcode.Text = pricedItem.Barcode;
                TxtCustomizedQuantity.Text = (pricedItem.CustomizedQuantity == null || pricedItem.CustomizedQuantity == Constants.DEFAULT_DECIMAL_VALUE) 
                    ? string.Empty 
                    : pricedItem.CustomizedQuantity.ToString();
                TxtCustomizedUnit.Text = string.IsNullOrWhiteSpace(pricedItem.CustomizedUnit) 
                    ? string.Empty 
                    : pricedItem.CustomizedUnit;

                _itemDiscountPercent = item.DiscountPercent;
                _itemDiscountPercent1 = item.DiscountPercent1;
                _itemDiscountPercent2 = item.DiscountPercent2;

                _itemDiscountThreshold = item.DiscountThreshold;
                _itemDiscountThreshold1 = item.DiscountThreshold1;
                _itemDiscountThreshold2 = item.DiscountThreshold2;

                var absoluteImagePath = Path.Combine(_baseImageFolder, _itemImageFolder, pricedItem.ImagePath);
                if (File.Exists(absoluteImagePath))
                {
                    PicBoxItemImage.ImageLocation = absoluteImagePath;
                }
                else
                {
                    PicBoxItemImage.Image = PicBoxItemImage.InitialImage;
                }

                TxtProfitAmount.Text = stockItem.ProfitAmount.ToString();
                CalculateItemDiscount();
                RichItemQuantity.Enabled = true;
                RichItemQuantity.Text = "1";
                RichItemQuantity.Focus();
                RichItemQuantity.SelectAll();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void CalculateItemDiscount()
        {
            var itemQuantity = string.IsNullOrWhiteSpace(RichItemQuantity.Text.Trim())
                ? Constants.DEFAULT_DECIMAL_VALUE
                : Convert.ToDecimal(RichItemQuantity.Text.Trim());
            var itemPrice = string.IsNullOrWhiteSpace(TxtItemPrice.Text.Trim())
                ? Constants.DEFAULT_DECIMAL_VALUE
                : Convert.ToDecimal(TxtItemPrice.Text.Trim());

            var itemDiscountPercent = Constants.DEFAULT_DECIMAL_VALUE;

            if (_itemDiscountThreshold2 != Constants.DEFAULT_DECIMAL_VALUE && itemQuantity >= _itemDiscountThreshold2)
            {
                itemDiscountPercent = _itemDiscountPercent2;
            }
            else if (_itemDiscountThreshold1 != Constants.DEFAULT_DECIMAL_VALUE && itemQuantity >= _itemDiscountThreshold1)
            {
                itemDiscountPercent = _itemDiscountPercent1;
            } 
            else if (_itemDiscountThreshold != Constants.DEFAULT_DECIMAL_VALUE && itemQuantity >= _itemDiscountThreshold)
            {
                itemDiscountPercent = _itemDiscountPercent;
            }

            if (itemDiscountPercent != Constants.DEFAULT_DECIMAL_VALUE)
            {
                TxtItemDiscount.Text = Math.Round((itemPrice * itemDiscountPercent) / 100, 2).ToString();
            }
            else
            {
                TxtItemDiscount.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
            }
        }

        private void CalculatePOSDetailByDiscountPercent()
        {
            if (!string.IsNullOrWhiteSpace(TxtSubTotal.Text.Trim())
                && decimal.TryParse(TxtSubTotal.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtDiscountPercent.Text.Trim())
                && decimal.TryParse(TxtDiscountPercent.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtDiscount.Text.Trim())
                && decimal.TryParse(TxtDiscount.Text.Trim(), out _))
            {
                var subTotal = Convert.ToDecimal(TxtSubTotal.Text.Trim());
                var discountPercent = Convert.ToDecimal(TxtDiscountPercent.Text.Trim());
                var discount = Math.Round(subTotal * (discountPercent / 100), 2);
                var discountTotal = subTotal - discount;
                var deliveryChargePercent = Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim());
                var deliveryCharge = Math.Round((discountTotal * (deliveryChargePercent / 100)), 2);
                var deliveryChargeTotal = discountTotal + deliveryCharge;
                var receivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE
                    : Convert.ToDecimal(RichReceivedAmount.Text.Trim());

                TxtDiscount.Text = discount.ToString();
                TxtDiscountTotal.Text = discountTotal.ToString();
                TxtDeliveryCharge.Text = deliveryCharge.ToString();
                TxtDeliveryChargeTotal.Text = deliveryChargeTotal.ToString();
                TxtTotal.Text = deliveryChargeTotal.ToString();
                RichBalanceAmount.Text = Math.Round(deliveryChargeTotal - receivedAmount, 2).ToString();
            }
        }

        private void CalculatePOSDetailByDeliveryChargePercent()
        {
            if (!string.IsNullOrWhiteSpace(TxtDiscountTotal.Text.Trim())
                && decimal.TryParse(TxtDiscountTotal.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtDeliveryChargePercent.Text.Trim())
                && decimal.TryParse(TxtDeliveryChargePercent.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtDeliveryCharge.Text.Trim())
                && decimal.TryParse(TxtDeliveryCharge.Text.Trim(), out _))
            {
                var discountTotal = Convert.ToDecimal(TxtDiscountTotal.Text.Trim());
                var deliveryChargePercent = Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim());
                var deliveryCharge = Math.Round(discountTotal * (deliveryChargePercent / 100), 2);
                var deliveryChargeTotal = discountTotal + deliveryCharge;
                var receivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE
                    : Convert.ToDecimal(RichReceivedAmount.Text.Trim());

                TxtDeliveryCharge.Text = deliveryCharge.ToString();
                TxtDeliveryChargeTotal.Text = deliveryChargeTotal.ToString();
                TxtTotal.Text = deliveryChargeTotal.ToString();
                RichBalanceAmount.Text = Math.Round(deliveryChargeTotal - receivedAmount, 2).ToString();
            }
        }

        private void LoadPosDetails(List<SoldItemView> soldItemViewList)
        {
            try
            {
                var subTotal = soldItemViewList.Sum(x => x.Total);
                TxtSubTotal.Text = subTotal.ToString();

                var discountPercent = _setting.Discount;
                var deliveryChargePercent = _setting.DeliveryCharge;

                var receivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichReceivedAmount.Text.Trim());

                TxtDiscountPercent.Text = discountPercent.ToString();
                TxtDeliveryChargePercent.Text = deliveryChargePercent.ToString();

                var discount = Math.Round(subTotal * (discountPercent / 100), 2);
                TxtDiscount.Text = discount.ToString();
                
                var discountTotal = Math.Round(subTotal - (subTotal * (discountPercent / 100)), 2);
                TxtDiscountTotal.Text = discountTotal.ToString();
                
                var deliveryCharge = Math.Round(discountTotal * (deliveryChargePercent / 100), 2);
                TxtDeliveryCharge.Text = deliveryCharge.ToString();
                
                var deliveryChargeTotal = Math.Round(discountTotal + (discountTotal * (deliveryChargePercent / 100)), 2);
                TxtDeliveryChargeTotal.Text = deliveryChargeTotal.ToString();
                
                TxtTotal.Text = deliveryChargeTotal.ToString();

                var balanceAmount = Math.Round(deliveryChargeTotal - receivedAmount, 2);
                RichBalanceAmount.Text = balanceAmount.ToString();
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
                if (posDetailView.ActionType == Constants.CASH && (Convert.ToDecimal(RichReceivedAmount.Text.Trim()) > Convert.ToDecimal(TxtTotal.Text.Trim())))
                {
                    RichBalanceAmount.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
                    TxtChangeMoney.Text = (Convert.ToDecimal(RichReceivedAmount.Text.Trim()) - Convert.ToDecimal(TxtTotal.Text.Trim())).ToString();
                }
                else
                {
                    RichBalanceAmount.Text = (Convert.ToDecimal(TxtTotal.Text.Trim()) - Convert.ToDecimal(RichReceivedAmount.Text.Trim())).ToString();
                    TxtChangeMoney.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
                }
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
