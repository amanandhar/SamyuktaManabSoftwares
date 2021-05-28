using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PosForm : Form, IMemberListForm, IItemListForm
    {
        private readonly IMemberService _memberService;
        private readonly IItemService _itemService;
        private readonly IItemTransactionService _itemTransactionService;
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        private readonly ITaxDetailService _taxDetailService;
        private List<PosTransaction> _posTransactions = new List<PosTransaction>();

        public PosForm(IMemberService memberService, IItemService itemService, IItemTransactionService itemTransactionService, IFiscalYearDetailService fiscalYearDetailService, ITaxDetailService taxDetailService)
        {
            InitializeComponent();

            _memberService = memberService;
            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            _fiscalYearDetailService = fiscalYearDetailService;
            _taxDetailService = taxDetailService;
        }

        private void PosForm_Load(object sender, EventArgs e)
        {
            var fiscalYearDetail = _fiscalYearDetailService.GetFiscalYearDetail();
            RichInvoiceNo.Text = fiscalYearDetail.InvoiceNo;
            RichInvoiceDate.Text = fiscalYearDetail.StartingDate.ToString("yyyy/MM/dd");
        }

        private void BtnShowMember_Click(object sender, EventArgs e)
        {
            MemberListForm memberListForm = new MemberListForm(_memberService, this);
            memberListForm.Show();
        }

        private void BtnShowItem_Click(object sender, EventArgs e)
        {
            ItemListForm itemListForm = new ItemListForm(_itemService, _itemTransactionService, this, false);
            itemListForm.Show();
        }

        private void BtnDailySales_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm();
            transactionForm.Show();
        }

        public void PopulateMember(string memberId)
        {
            var member = _memberService.GetMember(memberId);

            RichMemberId.Text = member.MemberId;
            RichName.Text = member.Name;
            RichAddress.Text = member.Address;
            RichContactNo.Text = member.ContactNumber.ToString();
            RichEmailId.Text = member.Email;
            RichAccNo.Text = member.AccountNumber;
        }

        public void PopulateItem(long itemId)
        {
            try
            {
                var itemTransaction = _itemTransactionService.GetItem(itemId);
                var item = _itemService.GetItem(itemId);

                RichItemCode.Text = item.Code;
                RichItemName.Text = item.Name;
                RichItemBrand.Text = item.Brand;
                RichItemPrice.Text = itemTransaction.PurchasePrice.ToString();
                RichItemStock.Text = itemTransaction.Quantity.ToString();
                RichItemUnit.Text = itemTransaction.Unit.ToString();

                RichItemQuantity.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                var taxDetail = _taxDetailService.GetTaxDetail();
                RichTextDiscountPercent.Text = taxDetail.Discount.ToString();
                RichTextVatPercent.Text = taxDetail.Vat.ToString();
                RichTextDeliveryChargePercent.Text = taxDetail.DeliveryCharge.ToString();

                _posTransactions.Add(new PosTransaction
                {
                    ItemCode = RichItemCode.Text,
                    ItemName = RichItemName.Text,
                    ItemBrand = RichItemBrand.Text,
                    Unit = RichItemUnit.Text,
                    ItemPrice = string.IsNullOrWhiteSpace(RichItemPrice.Text) ? 0.0m : Convert.ToDecimal(RichItemPrice.Text),
                    Quantity = string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text),
                    Total = (string.IsNullOrWhiteSpace(RichItemQuantity.Text) ? 0 : Convert.ToInt32(RichItemQuantity.Text)) * (string.IsNullOrWhiteSpace(RichItemPrice.Text) ? 0.0m : Convert.ToDecimal(RichItemPrice.Text)),
                    Date = DateTime.Now
                }) ; 

                var subTotal = string.IsNullOrWhiteSpace(RichSubTotal.Text) ? 0.0m : Convert.ToDecimal(RichSubTotal.Text);
                RichSubTotal.Text = Math.Round(subTotal + (Convert.ToDecimal(RichItemPrice.Text) * Convert.ToDecimal(RichItemQuantity.Text)), 2).ToString();
                RichTextDiscount.Text = Math.Round((Convert.ToDecimal(RichSubTotal.Text) * (Convert.ToDecimal(RichTextDiscountPercent.Text) / 100)), 2).ToString();
                RichTextDiscountTotal.Text = Math.Round(Convert.ToDecimal(RichSubTotal.Text) - (Convert.ToDecimal(RichSubTotal.Text) * (Convert.ToDecimal(RichTextDiscountPercent.Text) / 100)), 2).ToString();
                RichTextVat.Text = Math.Round((Convert.ToDecimal(RichTextDiscountTotal.Text) * (Convert.ToDecimal(RichTextVatPercent.Text) / 100)), 2).ToString();
                RichTextVatTotal.Text = Math.Round(Convert.ToDecimal(RichTextDiscountTotal.Text) + (Convert.ToDecimal(RichTextDiscountTotal.Text) * (Convert.ToDecimal(RichTextVatPercent.Text) / 100)), 2).ToString();
                RichTextDeliveryCharge.Text = Math.Round((Convert.ToDecimal(RichTextVatTotal.Text) * (Convert.ToDecimal(RichTextDeliveryChargePercent.Text) / 100)), 2).ToString();
                RichTextDeliveryChargeTotal.Text = Math.Round(Convert.ToDecimal(RichTextVatTotal.Text) + (Convert.ToDecimal(RichTextVatTotal.Text) * (Convert.ToDecimal(RichTextDeliveryChargePercent.Text) / 100)), 2).ToString();
                RichGrandTotal.Text = RichTextDeliveryChargeTotal.Text;
                RichBalanceAmount.Text = Math.Round(Convert.ToDecimal(RichTextDeliveryChargeTotal.Text) - Convert.ToDecimal(string.IsNullOrWhiteSpace(RichReceivedAmount.Text) ? "0" : RichReceivedAmount.Text), 2).ToString();

                ClearAllFields();
                LoadItems(_posTransactions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Helper Methods

        private void ClearAllFields()
        {
            RichItemCode.Clear();
            RichItemName.Clear();
            RichItemBrand.Clear();
            RichItemPrice.Clear();
            RichItemQuantity.Clear();
            RichItemUnit.Clear();
            RichItemStock.Clear();
        }

        private void LoadItems(List<PosTransaction> posTransactions)
        {
            var bindingList = new BindingList<PosTransaction>(posTransactions);
            var source = new BindingSource(bindingList, null);
            DataGridPosTransactionList.DataSource = source;
        }

        #endregion

        #region DataGrid Events
        private void DataGridPosTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridPosTransactionList.Columns["Id"].Visible = false;
            DataGridPosTransactionList.Columns["Date"].Visible = false;

            DataGridPosTransactionList.Columns["ItemCode"].HeaderText = "Item Code";
            DataGridPosTransactionList.Columns["ItemCode"].Width = 70;
            DataGridPosTransactionList.Columns["ItemCode"].DisplayIndex = 1;

            DataGridPosTransactionList.Columns["ItemName"].HeaderText = "Item Name";
            DataGridPosTransactionList.Columns["ItemName"].Width = 180;
            DataGridPosTransactionList.Columns["ItemName"].DisplayIndex = 2;

            DataGridPosTransactionList.Columns["ItemBrand"].HeaderText = "Item Brand";
            DataGridPosTransactionList.Columns["ItemBrand"].Width = 180;
            DataGridPosTransactionList.Columns["ItemBrand"].DisplayIndex = 3;

            DataGridPosTransactionList.Columns["Unit"].HeaderText = "Unit";
            DataGridPosTransactionList.Columns["Unit"].Width = 50;
            DataGridPosTransactionList.Columns["Unit"].DisplayIndex = 4;

            DataGridPosTransactionList.Columns["ItemPrice"].HeaderText = "Item Price";
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
        #endregion
    }
}
