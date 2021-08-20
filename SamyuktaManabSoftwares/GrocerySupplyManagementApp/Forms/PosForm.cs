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
        private readonly IFiscalYearService _fiscalYearService;
        private readonly ITaxService _taxService;
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

        private readonly string _endOfDay;
        private string _selectedInvoiceNo;
        private readonly List<SoldItemView> _soldItemViewList = new List<SoldItemView>();

        #region Constructor
        public PosForm(IFiscalYearService fiscalYearService, ITaxService taxService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IItemService itemService, IPricedItemService pricedItemService,
            IMemberService memberService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService, 
            IUserTransactionService userTransactionService, IReportService reportService,
            ICompanyInfoService companyInfoService, IEmployeeService employeeService
            )
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _taxService = taxService;
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

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }

        public PosForm(IMemberService memberService, IUserTransactionService userTransactionService, 
            ISoldItemService soldItemService, IEmployeeService employeeService, string invoiceNo)
        {
            InitializeComponent();

            _memberService = memberService;
            _userTransactionService = userTransactionService;
            _soldItemService = soldItemService;
            _employeeService = employeeService;

            _soldItemViewList = _soldItemService.GetSoldItemViewList(invoiceNo).ToList();
            LoadItems(_soldItemViewList);
            LoadPosDetails(invoiceNo);
        }
        #endregion

        #region Form Load Event
        private void PosForm_Load(object sender, EventArgs e)
        {
            LoadItems(_soldItemViewList);
            LoadDeliveryPersons();
        }
        #endregion

        #region Button Click Event
        private void BtnShowMember_Click(object sender, EventArgs e)
        {
            MemberListForm memberListForm = new MemberListForm(_memberService, _userTransactionService, this);
            memberListForm.ShowDialog();
        }

        private void BtnShowItem_Click(object sender, EventArgs e)
        {
            PricedItemListForm pricedItemListForm = new PricedItemListForm(_pricedItemService, this);
            pricedItemListForm.ShowDialog();
        }

        private void BtnDailySales_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_fiscalYearService, _bankTransactionService, _purchasedItemService,
                _soldItemService, _userTransactionService);
            transactionForm.Show();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddItemInCart();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnAddSale_Click(object sender, EventArgs e)
        {
            _selectedInvoiceNo = _userTransactionService.GetInvoiceNo();
            TxtInvoiceNo.Text = _selectedInvoiceNo;
            TxtInvoiceDate.Text = _endOfDay;

            BtnShowMember.Enabled = true;
            BtnShowItem.Enabled = true;
        }

        private void BtnSaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(ComboDeliveryPerson.Text) && TxtDeliveryChargePercent.Text != "0.00")
                {
                    DialogResult dialogResult = MessageBox.Show("Please fill the following fields: \n Delivery Person",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if(dialogResult == DialogResult.OK)
                    {
                        return;
                    }
                }

                var date = DateTime.Now;
                _soldItemViewList.ForEach(x =>
                {
                    var soldItem = new SoldItem
                    {
                        EndOfDay = TxtInvoiceDate.Text.Trim(),
                        MemberId = RichMemberId.Text.Trim(),
                        InvoiceNo = TxtInvoiceNo.Text.Trim(),
                        ItemId = _itemService.GetItem(x.ItemCode).Id,
                        Profit = x.Profit,
                        Quantity = x.Quantity,
                        Price = x.ItemPrice,
                        AddedDate = x.AddedDate,
                        UpdatedDate = x.AddedDate
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
                    SubTotal = Convert.ToDecimal(TxtSubTotal.Text.Trim()),
                    DiscountPercent = Convert.ToDecimal(TxtDiscountPercent.Text.Trim()),
                    Discount = Convert.ToDecimal(TxtDiscount.Text.Trim()),
                    DeliveryChargePercent = Convert.ToDecimal(TxtDeliveryChargePercent.Text.Trim()),
                    DeliveryCharge = Convert.ToDecimal(TxtDeliveryCharge.Text.Trim()),
                    DueAmount = Convert.ToDecimal(TxtGrandTotal.Text.Trim()),
                    ReceivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim()) ? 0.00m : Convert.ToDecimal(RichReceivedAmount.Text.Trim()),
                    AddedDate = date,
                    UpdatedDate = date
                };

                _userTransactionService.AddUserTransaction(userTransaction);

                var lastUserTransaction = _userTransactionService.GetLastUserTransaction(string.Empty);

                // Add Sales Discount
                if(Convert.ToDecimal(TxtDiscount.Text) != 0.00m)
                {
                    var userTransactionForSalesDiscount = new UserTransaction
                    {
                        EndOfDay = _endOfDay,
                        InvoiceNo = TxtInvoiceNo.Text.Trim(),
                        MemberId = RichMemberId.Text.Trim(),
                        Action = Constants.EXPENSE,
                        ActionType = RadioBtnCredit.Checked ? Constants.CREDIT : Constants.CASH,
                        IncomeExpense = Constants.SALES_DISCOUNT,
                        SubTotal = 0.0m,
                        DiscountPercent = 0.0m,
                        Discount = 0.0m,
                        VatPercent = 0.0m,
                        Vat = 0.0m,
                        DeliveryChargePercent = 0.0m,
                        DeliveryCharge = 0.0m,
                        DueAmount = Convert.ToDecimal(TxtDiscount.Text),
                        ReceivedAmount = 0.0m,
                        AddedDate = date,
                        UpdatedDate = date
                    };

                    _userTransactionService.AddUserTransaction(userTransactionForSalesDiscount);
                }

                // Add Delivery Charge
                if (Convert.ToDecimal(TxtDeliveryCharge.Text) != 0.00m)
                {
                    var userTransactionForDeliveryCharge = new UserTransaction
                    {
                        EndOfDay = _endOfDay,
                        InvoiceNo = TxtInvoiceNo.Text.Trim(),
                        MemberId = RichMemberId.Text.Trim(),
                        DeliveryPersonId = selectedDeliveryPerson?.Id.Trim(),
                        Action = Constants.RECEIPT,
                        ActionType = RadioBtnCredit.Checked ? Constants.CREDIT : Constants.CASH,
                        IncomeExpense = Constants.DELIVERY_CHARGE,
                        SubTotal = 0.0m,
                        DiscountPercent = 0.0m,
                        Discount = 0.0m,
                        VatPercent = 0.0m,
                        Vat = 0.0m,
                        DeliveryChargePercent = 0.0m,
                        DeliveryCharge = 0.0m,
                        DueAmount = 0.0m,
                        ReceivedAmount = Convert.ToDecimal(TxtDeliveryCharge.Text),
                        AddedDate = date,
                        UpdatedDate = date
                    };

                    _userTransactionService.AddUserTransaction(userTransactionForDeliveryCharge);
                }
                    

                ClearAllMemberFields();
                ClearAllItemFields();
                ClearAllInvoiceFields();
                _soldItemViewList.Clear();
                LoadItems(_soldItemViewList);
                EnableFields(false);
                RadioBtnCash.Checked = false;
                RadioBtnCredit.Checked = true;
                ComboDeliveryPerson.Text = string.Empty;

                DialogResult result = MessageBox.Show(userTransaction.InvoiceNo + " has been added successfully. \n Would you like to print the receipt?", 
                    "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    InvoiceReportForm invoiceReportForm = new InvoiceReportForm(_companyInfoService, _reportService, _selectedInvoiceNo);
                    invoiceReportForm.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void BtnPaymentIn_Click(object sender, EventArgs e)
        {
            RichPayment.Enabled = true;
            BtnSavePayment.Enabled = true;
            RichPayment.Focus();
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnSavePayment_Click(object sender, EventArgs e)
        {
            try
            {
                var date = DateTime.Now;
                var userTransaction = new UserTransaction
                {
                    EndOfDay = TxtInvoiceDate.Text,
                    MemberId = RichMemberId.Text,
                    Action = Constants.RECEIPT,
                    ActionType = Constants.CASH,
                    SubTotal = 0.00m,
                    DiscountPercent = 0.00m,
                    Discount = 0.00m,
                    VatPercent = 0.00m,
                    Vat = 0.00m,
                    DeliveryChargePercent = 0.00m,
                    DeliveryCharge = 0.00m,
                    DueAmount = 0.00m,
                    ReceivedAmount = Convert.ToDecimal(RichPayment.Text),
                    AddedDate = date,
                    UpdatedDate = date
                };

                _userTransactionService.AddUserTransaction(userTransaction);
                DialogResult result = MessageBox.Show("Payment has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllMemberFields();
                    ClearAllItemFields();
                    ClearAllInvoiceFields();
                    _soldItemViewList.Clear();
                    LoadItems(_soldItemViewList);
                    EnableFields(false);
                    RadioBtnCash.Checked = false;
                    RadioBtnCredit.Checked = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnBankTransfer_Click(object sender, EventArgs e)
        {
            BankTransferForm bankTransferForm = new BankTransferForm(_fiscalYearService, _bankService, _bankTransactionService, _userTransactionService);
            bankTransferForm.Show();
        }

        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(_fiscalYearService,
                _bankService, _bankTransactionService,
                _userTransactionService);
            expenseForm.Show();
        }

        #endregion

        #region RichTextBox Events
        private void RichReceivedAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void RichReceivedAmount_KeyUp(object sender, KeyEventArgs e)
        {
            RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(TxtDeliveryChargeTotal.Text) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text) ? "0.00" : RichReceivedAmount.Text), 2).ToString();
        }

        private void RichItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if(e.KeyChar == (char)Keys.Enter)
            {
                AddItemInCart();
            }
        }

        private void RichItemQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            BtnAddItem.Enabled = true;
        }

        private void RichMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var memberId = RichMemberId.Text.Replace("\n", "");
                PopulateMember(memberId);
            }
        }

        private void RichItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    var codes = RichItemCode.Text.Replace("\n", "").Split('-');
                    var itemCode = codes[0];
                    var itemSubCode = codes[1];
                    var pricedItem = _pricedItemService.GetPricedItem(itemCode, itemSubCode);
                    var item = _itemService.GetItem(pricedItem.ItemId);
                    StockFilter filter = new StockFilter
                    {
                        ItemCode = item.Code
                    };

                    var stock = _purchasedItemService.GetPurchasedItemTotalQuantity(filter) - _soldItemService.GetSoldItemTotalQuantity(filter);
                    if (stock < item.Threshold)
                    {
                        DialogResult result = MessageBox.Show("Stock is low. \nPlease add more stock.",
                            "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            TxtItemStock.ForeColor = Color.Red;
                        }
                    }

                    RichItemCode.Text = item.Code + "-" + pricedItem.ItemSubCode;
                    TxtItemName.Text = item.Name;
                    TxtItemBrand.Text = item.Brand;
                    TxtItemPrice.Text = pricedItem.SalesPricePerUnit.ToString();

                    TxtItemStock.Text = stock.ToString();
                    TxtItemUnit.Text = item.Unit;
                    TxtProfitAmount.Text = pricedItem.Profit.ToString();
                    if (File.Exists(pricedItem.ImagePath))
                    {
                        PicBoxItemImage.ImageLocation = pricedItem.ImagePath;
                    }

                    RichItemQuantity.Enabled = true;
                    RichItemQuantity.Focus();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        #endregion

        #region Radio Buttons Event
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

        #region Combobox Event
        private void ComboPayment_SelectedValueChanged(object sender, EventArgs e)
        {
            RichPayment.Enabled = true;
            BtnSavePayment.Enabled = true;
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
                DataGridSoldItemList.Columns["AddedDate"].Visible = false;

                DataGridSoldItemList.Columns["ItemCode"].HeaderText = "Code";
                DataGridSoldItemList.Columns["ItemCode"].Width = 70;
                DataGridSoldItemList.Columns["ItemCode"].DisplayIndex = 0;

                DataGridSoldItemList.Columns["ItemName"].HeaderText = "Name";
                DataGridSoldItemList.Columns["ItemName"].Width = 180;
                DataGridSoldItemList.Columns["ItemName"].DisplayIndex = 1;

                DataGridSoldItemList.Columns["ItemBrand"].HeaderText = "Brand";
                DataGridSoldItemList.Columns["ItemBrand"].Width = 180;
                DataGridSoldItemList.Columns["ItemBrand"].DisplayIndex = 2;

                DataGridSoldItemList.Columns["Unit"].HeaderText = "Unit";
                DataGridSoldItemList.Columns["Unit"].Width = 50;
                DataGridSoldItemList.Columns["Unit"].DisplayIndex = 3;

                DataGridSoldItemList.Columns["ItemPrice"].HeaderText = "Price";
                DataGridSoldItemList.Columns["ItemPrice"].Width = 80;
                DataGridSoldItemList.Columns["ItemPrice"].DisplayIndex = 4;
                DataGridSoldItemList.Columns["ItemPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridSoldItemList.Columns["Quantity"].HeaderText = "Quantity";
                DataGridSoldItemList.Columns["Quantity"].Width = 70;
                DataGridSoldItemList.Columns["Quantity"].DisplayIndex = 5;
                DataGridSoldItemList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridSoldItemList.Columns["Total"].HeaderText = "Total";
                DataGridSoldItemList.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DataGridSoldItemList.Columns["Total"].DisplayIndex = 6;
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
                    ItemCode = RichItemCode.Text.Split('-')[0],
                    ItemName = TxtItemName.Text,
                    ItemBrand = TxtItemBrand.Text,
                    Profit = string.IsNullOrWhiteSpace(TxtItemPrice.Text) ? 0.00m : Convert.ToDecimal(TxtProfitAmount.Text),
                    Unit = TxtItemUnit.Text,
                    ItemPrice = string.IsNullOrWhiteSpace(TxtItemPrice.Text) ? 0.00m : Convert.ToDecimal(TxtItemPrice.Text),
                    Quantity = string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text),
                    Total = Math.Round((string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text)) * (string.IsNullOrWhiteSpace(TxtItemPrice.Text) ? 0.00m : Convert.ToDecimal(TxtItemPrice.Text)), 2),
                    AddedDate = DateTime.Now
                }); ;

                LoadItems(_soldItemViewList);

                LoadPosDetails();

                ClearAllItemFields();

                BtnSaveInvoice.Enabled = true;
            }
            catch (Exception ex)
            {
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
            TxtProfitAmount.Clear();
            TxtItemStock.Clear();
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

        private void EnableFields(bool option)
        {
            BtnShowMember.Enabled = option;
            BtnShowItem.Enabled = option;
            BtnAddItem.Enabled = option;
            BtnSaveInvoice.Enabled = option;
        }

        public void PopulateMember(string memberId)
        {
            try
            {
                var member = _memberService.GetMember(memberId);

                RichMemberId.Text = member.MemberId;
                TxtName.Text = member.Name;
                TxtAddress.Text = member.Address;
                TxtContactNo.Text = member.ContactNo.ToString();
                TxtAccNo.Text = member.AccountNo;

                List<UserTransaction> userTransactions = _userTransactionService.GetUserTransactions(memberId).ToList();
                TxtBalance.Text = _userTransactionService.GetMemberTotalBalance(memberId).ToString();

                BtnPaymentIn.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PopulatePricedItem(long pricedId)
        {
            try
            {
                var pricedItem = _pricedItemService.GetPricedItem(pricedId);
                var item = _itemService.GetItem(pricedItem.ItemId);
                StockFilter filter = new StockFilter
                {
                    ItemCode = item.Code
                };

                var stock = _purchasedItemService.GetPurchasedItemTotalQuantity(filter) - _soldItemService.GetSoldItemTotalQuantity(filter);
                if(stock < item.Threshold)
                {
                    DialogResult result = MessageBox.Show("Stock is low. \nPlease add more stock.", 
                        "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if(result == DialogResult.OK)
                    {
                        TxtItemStock.ForeColor = Color.Red;
                    }
                }

                RichItemCode.Text = item.Code + "-" + pricedItem.ItemSubCode;
                TxtItemName.Text = item.Name;
                TxtItemBrand.Text = item.Brand;
                TxtItemPrice.Text = pricedItem.SalesPricePerUnit.ToString();
                
                TxtItemStock.Text = stock.ToString();
                TxtItemUnit.Text = item.Unit;
                TxtProfitAmount.Text = pricedItem.Profit.ToString();
                if (File.Exists(pricedItem.ImagePath))
                {
                    PicBoxItemImage.ImageLocation = pricedItem.ImagePath;
                }

                RichItemQuantity.Enabled = true;
                RichItemQuantity.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadPosDetails(SoldItemView soldItemGrid = null)
        {
            try
            {
                var tax = _taxService.GetTax();
                TxtDiscountPercent.Text = tax.Discount.ToString();
                TxtDeliveryChargePercent.Text = tax.DeliveryCharge.ToString();

                decimal subTotal;
                if (soldItemGrid == null)
                {
                    subTotal = string.IsNullOrWhiteSpace(TxtSubTotal.Text) ? 0.00m : Convert.ToDecimal(TxtSubTotal.Text);
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
                RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(TxtDeliveryChargeTotal.Text) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text) ? "0.00" : RichReceivedAmount.Text), 2).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadPosDetails(string invoiceNo)
        {
            try
            {
                var userTransaction = _userTransactionService.GetUserTransaction(invoiceNo);

                TxtSubTotal.Text = userTransaction.SubTotal.ToString();
                TxtDiscountPercent.Text = userTransaction.DiscountPercent.ToString();
                TxtDiscount.Text = userTransaction.Discount.ToString();
                TxtDiscountTotal.Text = (userTransaction.SubTotal - userTransaction.Discount).ToString();
                TxtDeliveryChargePercent.Text = userTransaction.DeliveryChargePercent.ToString();
                TxtDeliveryCharge.Text = userTransaction.DeliveryCharge.ToString();
                TxtDeliveryChargeTotal.Text = (userTransaction.SubTotal - userTransaction.Discount + userTransaction.Vat + userTransaction.DeliveryCharge).ToString();
                TxtGrandTotal.Text = userTransaction.DueAmount.ToString();
                RichReceivedAmount.Text = userTransaction.ReceivedAmount.ToString();
                RichBalanceAmount.Text = (userTransaction.DueAmount - userTransaction.ReceivedAmount).ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void LoadDeliveryPersons()
        {
            try
            {
                var deliveryPersons = _employeeService.GetDeliveryPersons().ToList();

                ComboDeliveryPerson.ValueMember = "Id";
                ComboDeliveryPerson.DisplayMember = "Value";

                deliveryPersons.OrderBy(x => x.Name).ToList().ForEach(x =>
                {
                    ComboDeliveryPerson.Items.Add(new ComboBoxItem { Id = x.EmployeeId, Value = x.Name });
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
