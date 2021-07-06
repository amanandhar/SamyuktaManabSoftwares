using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PosForm : Form, IMemberListForm, IPreparedItemListForm
    {
        private readonly IMemberService _memberService;
        private readonly IItemService _itemService;
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        private readonly ITaxDetailService _taxDetailService;
        private readonly IPosTransactionService _posTransactionService;
        private readonly IPosSoldItemService _posSoldItemService;
        private readonly ITransactionService _transactionService;
        private readonly IPreparedItemService _preparedItemService;
        private readonly IBankDetailService _bankDetailService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IItemTransactionService _itemTransactionService;
        private List<PosSoldItemGrid> _posSoldItemGrids = new List<PosSoldItemGrid>();

        #region Constructor
        public PosForm(IMemberService memberService, IItemService itemService, 
            IFiscalYearDetailService fiscalYearDetailService, ITaxDetailService taxDetailService, 
            IPosTransactionService posTransactionService, IPosSoldItemService posSoldItemService, 
            ITransactionService transactionService, IPreparedItemService preparedItemService, 
            IBankDetailService bankDetailService, IBankTransactionService bankTransactionService,
            IItemTransactionService itemTransactionService)
        {
            InitializeComponent();

            _memberService = memberService;
            _itemService = itemService;
            _fiscalYearDetailService = fiscalYearDetailService;
            _taxDetailService = taxDetailService;
            _posTransactionService = posTransactionService;
            _posSoldItemService = posSoldItemService;
            _transactionService = transactionService;
            _preparedItemService = preparedItemService;
            _bankDetailService = bankDetailService;
            _bankTransactionService = bankTransactionService;
            _itemTransactionService = itemTransactionService;
        }

        public PosForm(IMemberService memberService, IPosTransactionService posTransactionService, IPosSoldItemService posSoldItemService, string invoiceNo)
        {
            InitializeComponent();

            _memberService = memberService;
            _posTransactionService = posTransactionService;
            _posSoldItemService = posSoldItemService;

            _posSoldItemGrids = _posSoldItemService.GetPosSoldItemGrid(invoiceNo).ToList();
            LoadItems(_posSoldItemGrids);
            LoadPosDetails(invoiceNo);
        }
        #endregion

        #region Form Load
        private void PosForm_Load(object sender, EventArgs e)
        {
            LoadItems(_posSoldItemGrids);
        }
        #endregion

        #region Button Click Events
        private void BtnShowMember_Click(object sender, EventArgs e)
        {
            MemberListForm memberListForm = new MemberListForm(_memberService, _posTransactionService, this);
            memberListForm.Show();
        }

        private void BtnShowItem_Click(object sender, EventArgs e)
        {
            PreparedItemListForm preparedItemListForm = new PreparedItemListForm(_preparedItemService, this);
            preparedItemListForm.Show();
        }

        private void BtnDailySales_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_transactionService, _fiscalYearDetailService, 
                _posSoldItemService, _posTransactionService,
                _bankTransactionService, _itemTransactionService);
            transactionForm.Show();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                _posSoldItemGrids.Add(new PosSoldItemGrid
                {
                    Id = DataGridPosSoldItemList.RowCount,
                    ItemCode = RichItemCode.Text,
                    ItemName = RichItemName.Text,
                    ItemBrand = RichItemBrand.Text,
                    Unit = RichItemUnit.Text,
                    ItemPrice = string.IsNullOrWhiteSpace(RichItemPrice.Text) ? 0.0m : Convert.ToDecimal(RichItemPrice.Text),
                    Quantity = string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text),
                    Total = (string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text)) * (string.IsNullOrWhiteSpace(RichItemPrice.Text) ? 0.0m : Convert.ToDecimal(RichItemPrice.Text)),
                    Date = DateTime.Now
                });

                LoadItems(_posSoldItemGrids);

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
            var fiscalYearDetail = _fiscalYearDetailService.GetFiscalYearDetail();
            RichInvoiceNo.Text = _posTransactionService.GetInvoiceNo();
            RichInvoiceDate.Text = fiscalYearDetail.StartingDate.ToString("yyyy/MM/dd");

            BtnShowMember.Enabled = true;
            BtnShowItem.Enabled = true;
        }

        private void BtnSaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                var posTransaction = new PosTransaction
                {
                    InvoiceNo = RichInvoiceNo.Text.Trim(),
                    InvoiceDate = Convert.ToDateTime(RichInvoiceDate.Text.Trim()),
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
                    TotalAmount = Convert.ToDecimal(RichGrandTotal.Text.Trim()),
                    ReceivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim()) ? 0.0m : Convert.ToDecimal(RichReceivedAmount.Text.Trim()),
                    Date = DateTime.Now
                };

                _posTransactionService.AddPosTransaction(posTransaction);

                _posSoldItemGrids.ForEach(x =>
                {
                    var posSoldItem = new PosSoldItem
                    {
                        InvoiceNo = RichInvoiceNo.Text.Trim(),
                        ItemCode = x.ItemCode,
                        ItemName = x.ItemName,
                        ItemBrand = x.ItemBrand,
                        Unit = x.Unit,
                        Price = x.ItemPrice,
                        Quantity = x.Quantity
                    };
                    _posSoldItemService.AddPosSoldItem(posSoldItem);
                });

                DialogResult result = MessageBox.Show(posTransaction.InvoiceNo + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllMemberFields();
                    ClearAllItemFields();
                    ClearAllInvoiceFields();
                    _posSoldItemGrids.Clear();
                    LoadItems(_posSoldItemGrids);
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
                if (DataGridPosSoldItemList.SelectedRows.Count == 1)
                {
                    var id = Convert.ToInt64(DataGridPosSoldItemList.SelectedCells[0].Value.ToString());
                    var itemToRemove = _posSoldItemGrids.Single(x => x.Id == id);
                    _posSoldItemGrids.Remove(itemToRemove);

                    LoadItems(_posSoldItemGrids);
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
            var posTransaction = new PosTransaction
            {
                InvoiceDate = Convert.ToDateTime(RichInvoiceDate.Text),
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
                TotalAmount = 0.0m,
                ReceivedAmount = Convert.ToDecimal(RichPayment.Text),
                Date = DateTime.Now
            };

            _posTransactionService.AddPosTransaction(posTransaction);
            DialogResult result = MessageBox.Show("Payment has been added successfully.", "Message", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                ClearAllMemberFields();
                ClearAllItemFields();
                ClearAllInvoiceFields();
                _posSoldItemGrids.Clear();
                LoadItems(_posSoldItemGrids);
                EnableFields(false);
                RadioBtnCash.Checked = false;
                RadioBtnCredit.Checked = true;
            }
        }

        private void BtnBankTransfer_Click(object sender, EventArgs e)
        {
            BankTransferForm bankTransferForm = new BankTransferForm(_fiscalYearDetailService, _bankDetailService, _bankTransactionService, _posTransactionService);
            bankTransferForm.Show();
        }

        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(_fiscalYearDetailService, _posTransactionService,
                _bankDetailService, _bankTransactionService);
            expenseForm.Show();
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
                RichContactNo.Text = member.ContactNumber.ToString();
                RichAccNo.Text = member.AccountNumber;

                List<PosTransaction> posTransactions = _posTransactionService.GetPosTransactions(memberId).ToList();
                TxtBalance.Text = _posTransactionService.GetMemberTotalBalance(memberId).ToString();
                TxtBalanceStatus.Text = Convert.ToDecimal(TxtBalance.Text) <= 0.0m ? Constants.CLEAR : Constants.DUE;

                BtnPaymentIn.Enabled = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void PopulatePreparedItem(long preparedItemId)
        {
            try
            {
                var preparedItem = _preparedItemService.GetPreparedItem(preparedItemId);
                var item = _itemService.GetItem(preparedItem.ItemId);

                RichItemCode.Text = item.Code;
                RichItemSubCode.Text = preparedItem.ItemSubCode;
                RichItemName.Text = item.Name;
                RichItemBrand.Text = item.Brand;
                RichItemPrice.Text = preparedItem.SalesPricePerUnit.ToString();
                RichItemStock.Text = preparedItem.Stock.ToString();
                RichItemUnit.Text = preparedItem.Unit.ToString();

                RichItemQuantity.Enabled = true;
                RichItemQuantity.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadItems(List<PosSoldItemGrid> posSoldItemGrids)
        {
            var bindingList = new BindingList<PosSoldItemGrid>(posSoldItemGrids);
            var source = new BindingSource(bindingList, null);
            DataGridPosSoldItemList.DataSource = source;
        }

        private void LoadPosDetails(PosSoldItemGrid posSoldItemGrid = null)
        {
            var taxDetail = _taxDetailService.GetTaxDetail();
            RichTextDiscountPercent.Text = taxDetail.Discount.ToString();
            RichTextVatPercent.Text = taxDetail.Vat.ToString();
            RichTextDeliveryChargePercent.Text = taxDetail.DeliveryCharge.ToString();

            decimal subTotal;
            if (posSoldItemGrid == null)
            {
               subTotal = string.IsNullOrWhiteSpace(RichSubTotal.Text) ? 0.0m : Convert.ToDecimal(RichSubTotal.Text);
                RichSubTotal.Text = Math.Round(subTotal + (Convert.ToDecimal(RichItemPrice.Text) * Convert.ToDecimal(RichItemQuantity.Text)), 2).ToString();
            }
            else
            {
                subTotal = Convert.ToDecimal(RichSubTotal.Text) - posSoldItemGrid.Total;
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
            var posTransaction = _posTransactionService.GetPosTransaction(invoiceNo);

            RichSubTotal.Text = posTransaction.SubTotal.ToString();
            RichTextDiscountPercent.Text = posTransaction.DiscountPercent.ToString();
            RichTextDiscount.Text = posTransaction.Discount.ToString();
            RichTextDiscountTotal.Text = Math.Round(Convert.ToDecimal(posTransaction.SubTotal.ToString()) - Convert.ToDecimal(posTransaction.Discount.ToString()), 2).ToString();
            RichTextVatPercent.Text = posTransaction.VatPercent.ToString();
            RichTextVat.Text = posTransaction.Vat.ToString();
            RichTextVatTotal.Text = Math.Round(Convert.ToDecimal(RichTextDiscountTotal.Text) + Convert.ToDecimal(posTransaction.Vat.ToString()), 2).ToString();
            RichTextDeliveryChargePercent.Text = posTransaction.DeliveryChargePercent.ToString();
            RichTextDeliveryCharge.Text = posTransaction.DeliveryCharge.ToString();
            RichTextDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(RichTextVatTotal.Text) + Convert.ToDecimal(posTransaction.DeliveryCharge.ToString()), 2).ToString();
            RichGrandTotal.Text = posTransaction.TotalAmount.ToString();
            RichReceivedAmount.Text = posTransaction.ReceivedAmount.ToString();
        }

        #endregion

        #region DataGrid Events
        private void DataGridPosSoldItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridPosSoldItemList.Columns["Id"].Visible = false;
            DataGridPosSoldItemList.Columns["Date"].Visible = false;

            DataGridPosSoldItemList.Columns["ItemCode"].HeaderText = "Code";
            DataGridPosSoldItemList.Columns["ItemCode"].Width = 70;
            DataGridPosSoldItemList.Columns["ItemCode"].DisplayIndex = 1;

            DataGridPosSoldItemList.Columns["ItemName"].HeaderText = "Name";
            DataGridPosSoldItemList.Columns["ItemName"].Width = 180;
            DataGridPosSoldItemList.Columns["ItemName"].DisplayIndex = 2;

            DataGridPosSoldItemList.Columns["ItemBrand"].HeaderText = "Brand";
            DataGridPosSoldItemList.Columns["ItemBrand"].Width = 180;
            DataGridPosSoldItemList.Columns["ItemBrand"].DisplayIndex = 3;

            DataGridPosSoldItemList.Columns["Unit"].HeaderText = "Unit";
            DataGridPosSoldItemList.Columns["Unit"].Width = 50;
            DataGridPosSoldItemList.Columns["Unit"].DisplayIndex = 4;

            DataGridPosSoldItemList.Columns["ItemPrice"].HeaderText = "Price";
            DataGridPosSoldItemList.Columns["ItemPrice"].Width = 80;
            DataGridPosSoldItemList.Columns["ItemPrice"].DisplayIndex = 5;

            DataGridPosSoldItemList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridPosSoldItemList.Columns["Quantity"].Width = 70;
            DataGridPosSoldItemList.Columns["Quantity"].DisplayIndex = 6;

            DataGridPosSoldItemList.Columns["Total"].HeaderText = "Total";
            DataGridPosSoldItemList.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridPosSoldItemList.Columns["Total"].DisplayIndex = 7;

            foreach (DataGridViewRow row in DataGridPosSoldItemList.Rows)
            {
                DataGridPosSoldItemList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridPosSoldItemList.RowHeadersWidth = 50;
            }
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

    }
}
