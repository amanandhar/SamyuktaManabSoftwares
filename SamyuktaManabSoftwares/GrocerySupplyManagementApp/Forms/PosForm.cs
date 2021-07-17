using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
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
    public partial class PosForm : Form, IMemberListForm, ICodedItemListForm
    {
        private readonly IMemberService _memberService;
        private readonly IItemService _itemService;
        private readonly IFiscalYearService _fiscalYearService;
        private readonly ITaxService _taxService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly ISoldItemService _soldItemService;
        private readonly IDailyTransactionService _dailyTransactionService;
        private readonly ICodedItemService _codedItemService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IItemTransactionService _itemTransactionService;
        private List<SoldItemView> _soldItemViewList = new List<SoldItemView>();

        #region Constructor
        public PosForm(IMemberService memberService, IItemService itemService, 
            IFiscalYearService fiscalYearService, ITaxService taxService, 
            IUserTransactionService userTransactionService, ISoldItemService soldItemService, 
            IDailyTransactionService dailyTransactionService, ICodedItemService codedItemService, 
            IBankService bankService, IBankTransactionService bankTransactionService,
            IItemTransactionService itemTransactionService)
        {
            InitializeComponent();

            _memberService = memberService;
            _itemService = itemService;
            _fiscalYearService = fiscalYearService;
            _taxService = taxService;
            _userTransactionService = userTransactionService;
            _soldItemService = soldItemService;
            _dailyTransactionService = dailyTransactionService;
            _codedItemService = codedItemService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _itemTransactionService = itemTransactionService;
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
        }
        #endregion

        #region Button Click Event
        private void BtnShowMember_Click(object sender, EventArgs e)
        {
            MemberListForm memberListForm = new MemberListForm(_memberService, _userTransactionService, this);
            memberListForm.Show();
        }

        private void BtnShowItem_Click(object sender, EventArgs e)
        {
            CodedItemListForm preparedItemListForm = new CodedItemListForm(_codedItemService, this);
            preparedItemListForm.Show();
        }

        private void BtnDailySales_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_dailyTransactionService, _fiscalYearService, 
                _soldItemService, _userTransactionService,
                _bankTransactionService, _itemTransactionService);
            transactionForm.Show();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                _soldItemViewList.Add(new SoldItemView
                {
                    Id = DataGridSoldItemList.RowCount,
                    ItemCode = RichItemCode.Text,
                    ItemName = RichItemName.Text,
                    ItemBrand = RichItemBrand.Text,
                    Unit = RichItemUnit.Text,
                    ItemPrice = string.IsNullOrWhiteSpace(RichItemPrice.Text) ? 0.0m : Convert.ToDecimal(RichItemPrice.Text),
                    Quantity = string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text),
                    Total = (string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text)) * (string.IsNullOrWhiteSpace(RichItemPrice.Text) ? 0.0m : Convert.ToDecimal(RichItemPrice.Text)),
                    Date = DateTime.Now
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

        private void BtnAddSale_Click(object sender, EventArgs e)
        {
            var fiscalYear = _fiscalYearService.GetFiscalYear();
            RichInvoiceNo.Text = _userTransactionService.GetInvoiceNo();
            RichInvoiceDate.Text = fiscalYear.StartingDate.ToString("yyyy/MM/dd");

            BtnShowMember.Enabled = true;
            BtnShowItem.Enabled = true;
        }

        private void BtnSaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                var userTransaction = new UserTransaction
                {
                    InvoiceNo = RichInvoiceNo.Text.Trim(),
                    EndOfDate = Convert.ToDateTime(RichInvoiceDate.Text.Trim()),
                    MemberId = RichMemberId.Text.Trim(),
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
                    ReceivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim()) ? 0.0m : Convert.ToDecimal(RichReceivedAmount.Text.Trim()),
                    Date = DateTime.Now
                };

                _userTransactionService.AddUserTransaction(userTransaction);

                _soldItemViewList.ForEach(x =>
                {
                    var soldItem = new SoldItem
                    {
                        EndOfDate = Convert.ToDateTime(RichInvoiceDate.Text.Trim()),
                        MemberId = RichMemberId.Text.Trim(),
                        InvoiceNo = RichInvoiceNo.Text.Trim(),
                        ItemId = _itemService.GetItem(x.ItemCode).Id,
                        Unit = x.Unit,
                        Quantity = x.Quantity,
                        Price = x.ItemPrice,
                        Date = DateTime.Now
                    };

                    _soldItemService.AddSoldItem(soldItem);
                });

                DialogResult result = MessageBox.Show(userTransaction.InvoiceNo + " has been added successfully.", "Message", MessageBoxButtons.OK);
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
            var userTransaction = new UserTransaction
            {
                EndOfDate = Convert.ToDateTime(RichInvoiceDate.Text),
                MemberId = RichMemberId.Text,
                Action = Constants.RECEIPT,
                ActionType = Constants.CASH,
                SubTotal = 0.0m,
                DiscountPercent = 0.0m,
                Discount = 0.0m,
                VatPercent = 0.0m,
                Vat = 0.0m,
                DeliveryChargePercent = 0.0m,
                DeliveryCharge = 0.0m,
                DueAmount = 0.0m,
                ReceivedAmount = Convert.ToDecimal(RichPayment.Text),
                Date = DateTime.Now
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

        private void BtnBankTransfer_Click(object sender, EventArgs e)
        {
            BankTransferForm bankTransferForm = new BankTransferForm(_fiscalYearService, _bankService, _bankTransactionService, _userTransactionService);
            bankTransferForm.Show();
        }

        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(_fiscalYearService, _userTransactionService,
                _bankService, _bankTransactionService);
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
            RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(RichTextDeliveryChargeTotal.Text) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text) ? "0" : RichReceivedAmount.Text), 2).ToString();
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
            DataGridSoldItemList.Columns["Id"].Visible = false;
            DataGridSoldItemList.Columns["Date"].Visible = false;

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
            DataGridSoldItemList.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
        #endregion

        #region Helper Methods
        private void ClearAllMemberFields()
        {
            RichMemberId.Clear();
            RichAccNo.Clear();
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
            RichItemStock.Clear();
        }

        private void ClearAllInvoiceFields()
        {
            RichInvoiceNo.Clear();
            RichInvoiceDate.Clear();
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
                RichAccNo.Text = member.AccountNo;

                List<UserTransaction> userTransactions = _userTransactionService.GetUserTransactions(memberId).ToList();
                TxtBalance.Text = _userTransactionService.GetMemberTotalBalance(memberId).ToString();
                TxtBalanceStatus.Text = Convert.ToDecimal(TxtBalance.Text) <= 0.0m ? Constants.CLEAR : Constants.DUE;

                BtnPaymentIn.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PopulateCodedItem(long codedItemId)
        {
            try
            {
                var codedItem = _codedItemService.GetCodedItem(codedItemId);
                var item = _itemService.GetItem(codedItem.ItemId);

                RichItemCode.Text = item.Code;
                RichItemSubCode.Text = codedItem.ItemSubCode;
                RichItemName.Text = item.Name;
                RichItemBrand.Text = item.Brand;
                RichItemPrice.Text = codedItem.SalesPricePerUnit.ToString();
                StockFilterView filter = new StockFilterView
                {
                    ItemCode = item.Code
                };
                RichItemStock.Text = (_itemTransactionService.GetTotalPurchaseItemCount(filter) - _itemTransactionService.GetTotalSalesItemCount(filter)).ToString();
                RichItemUnit.Text = codedItem.Unit.ToString();
                RichItemQuantity.Enabled = true;
                RichItemQuantity.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadItems(List<SoldItemView> soldItemGrids)
        {
            var bindingList = new BindingList<SoldItemView>(soldItemGrids);
            var source = new BindingSource(bindingList, null);
            DataGridSoldItemList.DataSource = source;
        }

        private void LoadPosDetails(SoldItemView soldItemGrid = null)
        {
            var tax = _taxService.GetTax();
            RichTextDiscountPercent.Text = tax.Discount.ToString();
            RichTextVatPercent.Text = tax.Vat.ToString();
            RichTextDeliveryChargePercent.Text = tax.DeliveryCharge.ToString();

            decimal subTotal;
            if (soldItemGrid == null)
            {
                subTotal = string.IsNullOrWhiteSpace(RichSubTotal.Text) ? 0.0m : Convert.ToDecimal(RichSubTotal.Text);
                RichSubTotal.Text = Math.Round(subTotal + (Convert.ToDecimal(RichItemPrice.Text) * Convert.ToDecimal(RichItemQuantity.Text)), 2).ToString();
            }
            else
            {
                subTotal = Convert.ToDecimal(RichSubTotal.Text) - soldItemGrid.Total;
                RichSubTotal.Text = Math.Round(subTotal, 2).ToString();

            }

            RichTextDiscount.Text = Math.Round((Convert.ToDecimal(RichSubTotal.Text) * (Convert.ToDecimal(RichTextDiscountPercent.Text) / 100)), 2).ToString();
            RichTextDiscountTotal.Text = Math.Round(Convert.ToDecimal(RichSubTotal.Text) - (Convert.ToDecimal(RichSubTotal.Text) * (Convert.ToDecimal(RichTextDiscountPercent.Text) / 100)), 2).ToString();
            RichTextVat.Text = Math.Round((Convert.ToDecimal(RichTextDiscountTotal.Text) * (Convert.ToDecimal(RichTextVatPercent.Text) / 100)), 2).ToString();
            RichTextVatTotal.Text = Math.Round(Convert.ToDecimal(RichTextDiscountTotal.Text) + (Convert.ToDecimal(RichTextDiscountTotal.Text) * (Convert.ToDecimal(RichTextVatPercent.Text) / 100)), 2).ToString();
            RichTextDeliveryCharge.Text = Math.Round((Convert.ToDecimal(RichTextVatTotal.Text) * (Convert.ToDecimal(RichTextDeliveryChargePercent.Text) / 100)), 2).ToString();
            RichTextDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(RichTextVatTotal.Text) + (Convert.ToDecimal(RichTextVatTotal.Text) * (Convert.ToDecimal(RichTextDeliveryChargePercent.Text) / 100)), 2).ToString();
            RichGrandTotal.Text = RichTextDeliveryChargeTotal.Text;
            RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(RichTextDeliveryChargeTotal.Text) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text) ? "0" : RichReceivedAmount.Text), 2).ToString();
        }

        private void LoadPosDetails(string invoiceNo)
        {
            var userTransaction = _userTransactionService.GetUserTransaction(invoiceNo);

            RichSubTotal.Text = userTransaction.SubTotal.ToString();
            RichTextDiscountPercent.Text = userTransaction.DiscountPercent.ToString();
            RichTextDiscount.Text = userTransaction.Discount.ToString();
            RichTextDiscountTotal.Text = Math.Round(Convert.ToDecimal(userTransaction.SubTotal.ToString()) - Convert.ToDecimal(userTransaction.Discount.ToString()), 2).ToString();
            RichTextVatPercent.Text = userTransaction.VatPercent.ToString();
            RichTextVat.Text = userTransaction.Vat.ToString();
            RichTextVatTotal.Text = Math.Round(Convert.ToDecimal(RichTextDiscountTotal.Text) + Convert.ToDecimal(userTransaction.Vat.ToString()), 2).ToString();
            RichTextDeliveryChargePercent.Text = userTransaction.DeliveryChargePercent.ToString();
            RichTextDeliveryCharge.Text = userTransaction.DeliveryCharge.ToString();
            RichTextDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(RichTextVatTotal.Text) + Convert.ToDecimal(userTransaction.DeliveryCharge.ToString()), 2).ToString();
            RichGrandTotal.Text = userTransaction.DueAmount.ToString();
            RichReceivedAmount.Text = userTransaction.ReceivedAmount.ToString();
        }

        #endregion
    }
}
