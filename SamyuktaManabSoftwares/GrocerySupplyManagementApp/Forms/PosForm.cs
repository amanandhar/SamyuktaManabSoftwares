using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services;
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
        private readonly IPosInvoiceService _posInvoiceService;
        private readonly IPosTransactionService _posTransactionService;
        private readonly ITransactionService _transactionService;
        private readonly IPreparedItemService _preparedItemService;
        private readonly IBankDetailService _bankDetailService;
        private List<PosTransactionGrid> _posTransactionGrids = new List<PosTransactionGrid>();

        public PosForm(IMemberService memberService, IItemService itemService, 
            IFiscalYearDetailService fiscalYearDetailService, ITaxDetailService taxDetailService, 
            IPosInvoiceService posInvoiceService, IPosTransactionService posTransactionService, 
            ITransactionService transactionService, IPreparedItemService preparedItemService, IBankDetailService bankDetailService)
        {
            InitializeComponent();

            _memberService = memberService;
            _itemService = itemService;
            _fiscalYearDetailService = fiscalYearDetailService;
            _taxDetailService = taxDetailService;
            _posInvoiceService = posInvoiceService;
            _posTransactionService = posTransactionService;
            _transactionService = transactionService;
            _preparedItemService = preparedItemService;
            _bankDetailService = bankDetailService;
        }

        public PosForm(IMemberService memberService, IPosInvoiceService posInvoiceService, IPosTransactionService posTransactionService, string invoiceNo)
        {
            InitializeComponent();

            _memberService = memberService;
            _posInvoiceService = posInvoiceService;
            _posTransactionService = posTransactionService;

            _posTransactionGrids = _posTransactionService.GetPosTransactionGrid(invoiceNo).ToList();
            LoadItems(_posTransactionGrids);
            LoadPosDetails(invoiceNo);
        }

        #region Form Load
        private void PosForm_Load(object sender, EventArgs e)
        {
            LoadItems(_posTransactionGrids);
        }
        #endregion

        #region Button Click Events
        private void BtnShowMember_Click(object sender, EventArgs e)
        {
            MemberListForm memberListForm = new MemberListForm(_memberService, _posInvoiceService, this);
            memberListForm.Show();
        }

        private void BtnShowItem_Click(object sender, EventArgs e)
        {
            PreparedItemListForm preparedItemListForm = new PreparedItemListForm(_preparedItemService, this);
            preparedItemListForm.Show();
        }

        private void BtnDailySales_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_transactionService, _fiscalYearDetailService);
            transactionForm.Show();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                _posTransactionGrids.Add(new PosTransactionGrid
                {
                    Id = DataGridPosTransactionList.RowCount,
                    ItemCode = RichItemCode.Text,
                    ItemName = RichItemName.Text,
                    ItemBrand = RichItemBrand.Text,
                    Unit = RichItemUnit.Text,
                    ItemPrice = string.IsNullOrWhiteSpace(RichItemPrice.Text) ? 0.0m : Convert.ToDecimal(RichItemPrice.Text),
                    Quantity = string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text),
                    Total = (string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text)) * (string.IsNullOrWhiteSpace(RichItemPrice.Text) ? 0.0m : Convert.ToDecimal(RichItemPrice.Text)),
                    Date = DateTime.Now
                });

                LoadItems(_posTransactionGrids);

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
            RichInvoiceNo.Text = _posInvoiceService.GetInvoiceNo();
            RichInvoiceDate.Text = fiscalYearDetail.StartingDate.ToString("yyyy/MM/dd");

            BtnShowMember.Enabled = true;
            BtnShowItem.Enabled = true;
        }

        private void BtnSaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                var posInvoice = new PosInvoice
                {
                    InvoiceNo = RichInvoiceNo.Text.Trim(),
                    InvoiceDate = Convert.ToDateTime(RichInvoiceDate.Text.Trim()),
                    MemberId = RichMemberId.Text.Trim(),
                    PaymentType = RadioBtnCredit.Checked ? "Credit" : "Cash",
                    SubTotal = Convert.ToDecimal(RichSubTotal.Text.Trim()),
                    DiscountPercent = Convert.ToDecimal(RichTextDiscountPercent.Text.Trim()),
                    Discount = Convert.ToDecimal(RichTextDiscount.Text.Trim()),
                    VatPercent = Convert.ToDecimal(RichTextVatPercent.Text.Trim()),
                    Vat = Convert.ToDecimal(RichTextVat.Text.Trim()),
                    DeliveryChargePercent = Convert.ToDecimal(RichTextDeliveryChargePercent.Text.Trim()),
                    DeliveryCharge = Convert.ToDecimal(RichTextDeliveryCharge.Text.Trim()),
                    TotalAmount = Convert.ToDecimal(RichGrandTotal.Text.Trim()),
                    ReceivedAmount = string.IsNullOrWhiteSpace(RichReceivedAmount.Text.Trim()) ? 0.0m : Convert.ToDecimal(RichReceivedAmount.Text.Trim()),
                    Balance = Convert.ToDecimal(RichBalanceAmount.Text.Trim()),
                    Date = DateTime.Now
                };

                _posInvoiceService.AddPosInvoice(posInvoice);

                _posTransactionGrids.ForEach(x =>
                {
                    var posTransaction = new PosTransaction
                    {
                        InvoiceNo = RichInvoiceNo.Text.Trim(),
                        ItemCode = x.ItemCode,
                        ItemName = x.ItemName,
                        ItemBrand = x.ItemBrand,
                        Unit = x.Unit,
                        Price = x.ItemPrice,
                        Quantity = x.Quantity
                    };
                    _posTransactionService.AddPosTransaction(posTransaction);
                });

                DialogResult result = MessageBox.Show(posInvoice.InvoiceNo + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllMemberFields();
                    ClearAllItemFields();
                    ClearAllInvoiceFields();
                    _posTransactionGrids.Clear();
                    LoadItems(_posTransactionGrids);
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
            BtnShowMember.Enabled = true;
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridPosTransactionList.SelectedRows.Count == 1)
                {
                    var id = Convert.ToInt64(DataGridPosTransactionList.SelectedCells[0].Value.ToString());
                    var itemToRemove = _posTransactionGrids.Single(x => x.Id == id);
                    _posTransactionGrids.Remove(itemToRemove);

                    LoadItems(_posTransactionGrids);
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
            var posInvoice = new PosInvoice
            {
                InvoiceNo = "Cash",
                InvoiceDate = Convert.ToDateTime(RichInvoiceDate.Text),
                MemberId = RichMemberId.Text,
                PaymentType = "Payment In",
                SubTotal = 0.0m,
                DiscountPercent = 0.0m,
                Discount = 0.0m,
                VatPercent = 0.0m,
                Vat = 0.0m,
                DeliveryChargePercent = 0.0m,
                DeliveryCharge = 0.0m,
                TotalAmount = 0.0m,
                ReceivedAmount = Convert.ToDecimal(RichPayment.Text),
                Balance = 0.0m,
                Date = DateTime.Now
            };

            _posInvoiceService.AddPosInvoice(posInvoice);
            DialogResult result = MessageBox.Show("Payment has been added successfully.", "Message", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                ClearAllMemberFields();
                ClearAllItemFields();
                ClearAllInvoiceFields();
                _posTransactionGrids.Clear();
                LoadItems(_posTransactionGrids);
                EnableFields(false);
                RadioBtnCash.Checked = false;
                RadioBtnCredit.Checked = true;
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
                RichContactNo.Text = member.ContactNumber.ToString();
                RichAccNo.Text = member.AccountNumber;

                List<PosInvoice> posInvoices = _posInvoiceService.GetPosInvoicesByMemberId(memberId).ToList();
                TxtBalance.Text = posInvoices.Sum(x => x.Balance).ToString();
                TxtBalanceStatus.Text = posInvoices.Sum(x => x.Balance) == 0.0m ? "Clear" : "Due";

                RichPayment.Enabled = true;
                BtnSavePayment.Enabled = true;
                RichPayment.Focus();
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

        private void LoadItems(List<PosTransactionGrid> posTransactionGrids)
        {
            var bindingList = new BindingList<PosTransactionGrid>(posTransactionGrids);
            var source = new BindingSource(bindingList, null);
            DataGridPosTransactionList.DataSource = source;
        }

        private void LoadPosDetails(PosTransactionGrid posTransactionGrid = null)
        {
            var taxDetail = _taxDetailService.GetTaxDetail();
            RichTextDiscountPercent.Text = taxDetail.Discount.ToString();
            RichTextVatPercent.Text = taxDetail.Vat.ToString();
            RichTextDeliveryChargePercent.Text = taxDetail.DeliveryCharge.ToString();

            decimal subTotal;
            if (posTransactionGrid == null)
            {
               subTotal = string.IsNullOrWhiteSpace(RichSubTotal.Text) ? 0.0m : Convert.ToDecimal(RichSubTotal.Text);
                RichSubTotal.Text = Math.Round(subTotal + (Convert.ToDecimal(RichItemPrice.Text) * Convert.ToDecimal(RichItemQuantity.Text)), 2).ToString();
            }
            else
            {
                subTotal = Convert.ToDecimal(RichSubTotal.Text) - posTransactionGrid.Total;
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
            var posInvoice = _posInvoiceService.GetPosInvoice(invoiceNo);

            RichSubTotal.Text = posInvoice.SubTotal.ToString();
            RichTextDiscountPercent.Text = posInvoice.DiscountPercent.ToString();
            RichTextDiscount.Text = posInvoice.Discount.ToString();
            RichTextDiscountTotal.Text = Math.Round(Convert.ToDecimal(posInvoice.SubTotal.ToString()) - Convert.ToDecimal(posInvoice.Discount.ToString()), 2).ToString();
            RichTextVatPercent.Text = posInvoice.VatPercent.ToString();
            RichTextVat.Text = posInvoice.Vat.ToString();
            RichTextVatTotal.Text = Math.Round(Convert.ToDecimal(RichTextDiscountTotal.Text) + Convert.ToDecimal(posInvoice.Vat.ToString()), 2).ToString();
            RichTextDeliveryChargePercent.Text = posInvoice.DeliveryChargePercent.ToString();
            RichTextDeliveryCharge.Text = posInvoice.DeliveryCharge.ToString();
            RichTextDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(RichTextVatTotal.Text) + Convert.ToDecimal(posInvoice.DeliveryCharge.ToString()), 2).ToString();
            RichGrandTotal.Text = posInvoice.TotalAmount.ToString();
            RichReceivedAmount.Text = posInvoice.ReceivedAmount.ToString();
            RichBalanceAmount.Text = posInvoice.Balance.ToString();
        }

        #endregion

        #region DataGrid Events
        private void DataGridPosTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridPosTransactionList.Columns["Id"].Visible = false;
            DataGridPosTransactionList.Columns["Date"].Visible = false;

            DataGridPosTransactionList.Columns["ItemCode"].HeaderText = "Code";
            DataGridPosTransactionList.Columns["ItemCode"].Width = 70;
            DataGridPosTransactionList.Columns["ItemCode"].DisplayIndex = 1;

            DataGridPosTransactionList.Columns["ItemName"].HeaderText = "Name";
            DataGridPosTransactionList.Columns["ItemName"].Width = 180;
            DataGridPosTransactionList.Columns["ItemName"].DisplayIndex = 2;

            DataGridPosTransactionList.Columns["ItemBrand"].HeaderText = "Brand";
            DataGridPosTransactionList.Columns["ItemBrand"].Width = 180;
            DataGridPosTransactionList.Columns["ItemBrand"].DisplayIndex = 3;

            DataGridPosTransactionList.Columns["Unit"].HeaderText = "Unit";
            DataGridPosTransactionList.Columns["Unit"].Width = 50;
            DataGridPosTransactionList.Columns["Unit"].DisplayIndex = 4;

            DataGridPosTransactionList.Columns["ItemPrice"].HeaderText = "Price";
            DataGridPosTransactionList.Columns["ItemPrice"].Width = 80;
            DataGridPosTransactionList.Columns["ItemPrice"].DisplayIndex = 5;

            DataGridPosTransactionList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridPosTransactionList.Columns["Quantity"].Width = 70;
            DataGridPosTransactionList.Columns["Quantity"].DisplayIndex = 6;

            DataGridPosTransactionList.Columns["Total"].HeaderText = "Total";
            DataGridPosTransactionList.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridPosTransactionList.Columns["Total"].DisplayIndex = 7;

            foreach (DataGridViewRow row in DataGridPosTransactionList.Rows)
            {
                DataGridPosTransactionList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridPosTransactionList.RowHeadersWidth = 50;
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

        private void BtnBankTransfer_Click(object sender, EventArgs e)
        {
            BankTransferForm bankTransferForm = new BankTransferForm(_bankDetailService);
            bankTransferForm.Show();
        }

        private void ComboPayment_SelectedValueChanged(object sender, EventArgs e)
        {
            RichPayment.Enabled = true;
            BtnSavePayment.Enabled = true;
            RichPayment.Focus();
        }

        
    }
}
