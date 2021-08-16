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
        private List<SoldItemView> _soldItemViewList = new List<SoldItemView>();

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
            ISoldItemService soldItemService, string invoiceNo)
        {
            InitializeComponent();

            _memberService = memberService;
            _userTransactionService = userTransactionService;
            _soldItemService = soldItemService;

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

                ComboBoxItem selectedItem = (ComboBoxItem)ComboDeliveryPerson.SelectedItem;
                var userTransaction = new UserTransaction
                {
                    EndOfDay = TxtInvoiceDate.Text.Trim(),
                    InvoiceNo = TxtInvoiceNo.Text.Trim(),
                    MemberId = RichMemberId.Text.Trim(),
                    DeliveryPersonId = selectedItem.Id.Trim(),
                    Action = Constants.SALES,
                    ActionType = RadioBtnCredit.Checked ? Constants.CREDIT : Constants.CASH,
                    SubTotal = Convert.ToDecimal(RichSubTotal.Text.Trim()),
                    DiscountPercent = Convert.ToDecimal(RichTextDiscountPercent.Text.Trim()),
                    Discount = Convert.ToDecimal(RichTextDiscount.Text.Trim()),
                    VatPercent = Convert.ToDecimal(RichTextVatPercent.Text.Trim()),
                    Vat = Convert.ToDecimal(RichTextVat.Text.Trim()),
                    DeliveryChargePercent = Convert.ToDecimal(RichTextDeliveryChargePercent.Text.Trim()),
                    DeliveryCharge = Convert.ToDecimal(RichTextDeliveryCharge.Text.Trim()),
                    DueAmount = Convert.ToDecimal(RichGrandTotal.Text.Trim()),
                    ReceivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim()) ? 0.00m : Convert.ToDecimal(RichReceivedAmount.Text.Trim()),
                    AddedDate = date,
                    UpdatedDate = date
                };

                _userTransactionService.AddUserTransaction(userTransaction);

                // Add Sales Discount
                if(Convert.ToDecimal(RichTextDiscount.Text) != 0.00m)
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
                        DueAmount = Convert.ToDecimal(RichTextDiscount.Text),
                        ReceivedAmount = 0.0m,
                        AddedDate = date,
                        UpdatedDate = date
                    };

                    _userTransactionService.AddUserTransaction(userTransactionForSalesDiscount);
                }

                // Add Delivery Charge
                if (Convert.ToDecimal(RichTextDeliveryCharge.Text) != 0.00m)
                {
                    var userTransactionForDeliveryCharge = new UserTransaction
                    {
                        EndOfDay = _endOfDay,
                        InvoiceNo = TxtInvoiceNo.Text.Trim(),
                        MemberId = RichMemberId.Text.Trim(),
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
                        ReceivedAmount = Convert.ToDecimal(RichTextDeliveryCharge.Text),
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
            RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(RichTextDeliveryChargeTotal.Text) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text) ? "0.00" : RichReceivedAmount.Text), 2).ToString();
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
                    ItemCode = RichItemCode.Text,
                    ItemName = RichItemName.Text,
                    ItemBrand = RichItemBrand.Text,
                    Profit = string.IsNullOrWhiteSpace(RichItemPrice.Text) ? 0.00m : Convert.ToDecimal(TxtProfitAmount.Text),
                    Unit = RichItemUnit.Text,
                    ItemPrice = string.IsNullOrWhiteSpace(RichItemPrice.Text) ? 0.00m : Convert.ToDecimal(RichItemPrice.Text),
                    Quantity = string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text),
                    Total = Math.Round((string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text)) * (string.IsNullOrWhiteSpace(RichItemPrice.Text) ? 0.00m : Convert.ToDecimal(RichItemPrice.Text)), 2),
                    AddedDate = DateTime.Now
                });

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
            RichName.Clear();
            RichAddress.Clear();
            RichContactNo.Clear();
            RichPayment.Clear();
            TxtBalance.Clear();
        }

        private void ClearAllItemFields()
        {
            RichItemCode.Clear();
            RichItemSubCode.Clear();
            RichItemName.Clear();
            RichItemBrand.Clear();
            RichItemPrice.Clear();
            RichItemQuantity.Clear();
            RichItemUnit.Clear();
            TxtProfitAmount.Clear();
            RichItemStock.Clear();
            PicBoxItemImage.Image = null;
        }

        private void ClearAllInvoiceFields()
        {
            TxtInvoiceNo.Clear();
            TxtInvoiceDate.Clear();
            RichSubTotal.Clear();
            RichTextDiscountPercent.Clear();
            RichTextDiscount.Clear();
            RichTextDiscountTotal.Clear();
            RichTextVatPercent.Clear();
            RichTextVat.Clear();
            RichTextVatTotal.Clear();
            RichTextDeliveryChargePercent.Clear();
            RichTextDeliveryCharge.Clear();
            RichTextDeliveryChargeTotal.Clear();
            RichGrandTotal.Clear();
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
                RichName.Text = member.Name;
                RichAddress.Text = member.Address;
                RichContactNo.Text = member.ContactNo.ToString();
                TxtAccNo.Text = member.AccountNo;

                List<UserTransaction> userTransactions = _userTransactionService.GetUserTransactions(memberId).ToList();
                TxtBalance.Text = _userTransactionService.GetMemberTotalBalance(memberId).ToString();
                TxtBalanceStatus.Text = Convert.ToDecimal(TxtBalance.Text) <= 0.00m ? Constants.CLEAR : Constants.DUE;

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
                        RichItemStock.ForeColor = Color.Red;
                    }
                }

                RichItemCode.Text = item.Code;
                RichItemSubCode.Text = pricedItem.ItemSubCode;
                RichItemName.Text = item.Name;
                RichItemBrand.Text = item.Brand;
                RichItemPrice.Text = pricedItem.SalesPricePerUnit.ToString();
                
                RichItemStock.Text = stock.ToString();
                RichItemUnit.Text = item.Unit;
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
                RichTextDiscountPercent.Text = tax.Discount.ToString();
                RichTextVatPercent.Text = tax.Vat.ToString();
                RichTextDeliveryChargePercent.Text = tax.DeliveryCharge.ToString();

                decimal subTotal;
                if (soldItemGrid == null)
                {
                    subTotal = string.IsNullOrWhiteSpace(RichSubTotal.Text) ? 0.00m : Convert.ToDecimal(RichSubTotal.Text);
                    RichSubTotal.Text = (subTotal + Math.Round((Convert.ToDecimal(RichItemPrice.Text) * Convert.ToDecimal(RichItemQuantity.Text)), 2)).ToString();
                }
                else
                {
                    subTotal = Convert.ToDecimal(RichSubTotal.Text) - soldItemGrid.Total;
                    RichSubTotal.Text = subTotal.ToString();

                }

                RichTextDiscount.Text = Math.Round((Convert.ToDecimal(RichSubTotal.Text) * (Convert.ToDecimal(RichTextDiscountPercent.Text) / 100)), 2).ToString();
                RichTextDiscountTotal.Text = Math.Round(Convert.ToDecimal(RichSubTotal.Text) - (Convert.ToDecimal(RichSubTotal.Text) * (Convert.ToDecimal(RichTextDiscountPercent.Text) / 100)), 2).ToString();
                RichTextVat.Text = Math.Round((Convert.ToDecimal(RichTextDiscountTotal.Text) * (Convert.ToDecimal(RichTextVatPercent.Text) / 100)), 2).ToString();
                RichTextVatTotal.Text = Math.Round(Convert.ToDecimal(RichTextDiscountTotal.Text) + (Convert.ToDecimal(RichTextDiscountTotal.Text) * (Convert.ToDecimal(RichTextVatPercent.Text) / 100)), 2).ToString();
                RichTextDeliveryCharge.Text = Math.Round((Convert.ToDecimal(RichTextVatTotal.Text) * (Convert.ToDecimal(RichTextDeliveryChargePercent.Text) / 100)), 2).ToString();
                RichTextDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(RichTextVatTotal.Text) + (Convert.ToDecimal(RichTextVatTotal.Text) * (Convert.ToDecimal(RichTextDeliveryChargePercent.Text) / 100)), 2).ToString();
                RichGrandTotal.Text = RichTextDeliveryChargeTotal.Text;
                RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(RichTextDeliveryChargeTotal.Text) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text) ? "0.00" : RichReceivedAmount.Text), 2).ToString();
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

                RichSubTotal.Text = userTransaction.SubTotal.ToString();
                RichTextDiscountPercent.Text = userTransaction.DiscountPercent.ToString();
                RichTextDiscount.Text = userTransaction.Discount.ToString();
                RichTextDiscountTotal.Text = (userTransaction.SubTotal - userTransaction.Discount).ToString();
                RichTextVatPercent.Text = userTransaction.VatPercent.ToString();
                RichTextVat.Text = userTransaction.Vat.ToString();
                RichTextVatTotal.Text = (userTransaction.SubTotal - userTransaction.Discount + userTransaction.Vat).ToString();
                RichTextDeliveryChargePercent.Text = userTransaction.DeliveryChargePercent.ToString();
                RichTextDeliveryCharge.Text = userTransaction.DeliveryCharge.ToString();
                RichTextDeliveryChargeTotal.Text = (userTransaction.SubTotal - userTransaction.Discount + userTransaction.Vat + userTransaction.DeliveryCharge).ToString();
                RichGrandTotal.Text = userTransaction.DueAmount.ToString();
                RichReceivedAmount.Text = userTransaction.ReceivedAmount.ToString();
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
