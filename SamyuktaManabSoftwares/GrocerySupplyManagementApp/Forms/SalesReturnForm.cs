using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
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
    public partial class SalesReturnForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IItemService _itemService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;
        private readonly List<SoldItem> _soldItems;
        private readonly List<PurchasedItemView> _purchasedItemViewList = new List<PurchasedItemView>();

        #region Enum Action
        private enum Action
        {
            AddReturn,
            DeleteReturn,
            SaveReturn,
            ShowReturn,
            Load,
            None
        }
        #endregion

        #region Constructor
        public SalesReturnForm(IFiscalYearService fiscalYearService, IItemService itemService, 
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService,
            IUserTransactionService userTransactionService)
        {
            InitializeComponent();
            _fiscalYearService = fiscalYearService;
            _itemService = itemService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
            _soldItems = _soldItemService.GetSoldItems().ToList();
            LoadInvoiceNumbers();
        }
        #endregion

        #region Form Load Event
        private void SalesReturnForm_Load(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Load);
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            var salesReturnTransactionViewList = GetSalesReturnTransactions();
            TxtTotalAmount.Text = salesReturnTransactionViewList.ToList().Sum(x => x.Amount).ToString("#0.00");
            LoadSalesReturnTransactions(salesReturnTransactionViewList);
            EnableFields();
            EnableFields(Action.ShowReturn);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.AddReturn);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = (ComboBoxItem)ComboItemCode.SelectedItem;
                var itemCode = selectedItem?.Id;
                var purchasedItem = _purchasedItemService.GetPurchasedItemByItemId(Convert.ToInt64(itemCode));
                if(purchasedItem != null && !string.IsNullOrWhiteSpace(purchasedItem?.SupplierId))
                {
                    // Add Expense
                    var date = DateTime.Now;
                    var userTransactionExpense = new UserTransaction
                    {
                        EndOfDay = _endOfDay,
                        Action = Constants.EXPENSE,
                        ActionType = Constants.CASH,
                        Bank = null,
                        IncomeExpense = Constants.SALES_RETURN,
                        SubTotal = 0.0m,
                        DiscountPercent = 0.0m,
                        Discount = 0.0m,
                        VatPercent = 0.0m,
                        Vat = 0.0m,
                        DeliveryChargePercent = 0.0m,
                        DeliveryCharge = 0.0m,
                        DueAmount = Convert.ToDecimal(TxtItemPrice.Text),
                        ReceivedAmount = 0.0m,
                        AddedDate = date,
                        UpdatedDate = date
                    };
                    _userTransactionService.AddUserTransaction(userTransactionExpense);

                    // Add Purchase
                    List<PurchasedItem> purchasedItems = _purchasedItemViewList.Select(item => new PurchasedItem
                    {
                        EndOfDay = _endOfDay,
                        SupplierId = purchasedItem.SupplierId,
                        BillNo = item.BillNo,
                        ItemId = _itemService.GetItem(item.Code).Id,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        AddedDate = date,
                        UpdatedDate = date
                    }).ToList();

                    purchasedItems.ForEach(x =>
                    {
                        _purchasedItemService.AddPurchasedItem(x);
                    });

                    var userTransactionPurchase = new UserTransaction
                    {
                        EndOfDay = _endOfDay,
                        BillNo = ComboInvoiceNo.Text,
                        SupplierId = purchasedItem.SupplierId,
                        Action = Constants.PURCHASE,
                        ActionType = Constants.CASH,
                        IncomeExpense = Constants.SALES_RETURN,
                        SubTotal = 0.0m,
                        DiscountPercent = 0.0m,
                        Discount = 0.0m,
                        VatPercent = 0.0m,
                        Vat = 0.0m,
                        DeliveryChargePercent = 0.0m,
                        DeliveryCharge = 0.0m,
                        DueAmount = Convert.ToDecimal(TxtTotalAmount.Text),
                        ReceivedAmount = 0.00M,
                        AddedDate = date,
                        UpdatedDate = date
                    };

                    _userTransactionService.AddUserTransaction(userTransactionPurchase);

                    DialogResult result = MessageBox.Show("Item/s have been returned successfully.", "Message", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        var salesReturnTransactionViewList = GetSalesReturnTransactions();
                        TxtTotalAmount.Text = salesReturnTransactionViewList.ToList().Sum(x => x.Amount).ToString();
                        LoadSalesReturnTransactions(salesReturnTransactionViewList);
                        EnableFields();
                        EnableFields(Action.SaveReturn);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateGridSalesReturnList.SelectedRows.Count == 1)
                {
                    var selectedRow = DateGridSalesReturnList.SelectedRows[0];
                    var id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());

                    //_userTransactionService.DeleteUserTransaction();
                    //_purchasedItemService.DeletePurchasedItem();
                    //_userTransactionService.DeleteUserTransaction();
                    //var totalAmount = _userTransactionService.GetTotalBalance();
                    //TxtTotalAmount.Text = totalBalance.ToString();

                    var salesReturnTransactionViewList = GetSalesReturnTransactions();
                    TxtTotalAmount.Text = salesReturnTransactionViewList.ToList().Sum(x => x.Amount).ToString();
                    LoadSalesReturnTransactions(salesReturnTransactionViewList);
                    EnableFields();
                    EnableFields(Action.DeleteReturn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Grid Event
        private void DateGridSalesReturnList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DateGridSalesReturnList.Columns["Id"].Visible = false;

            DateGridSalesReturnList.Columns["EndOfDay"].HeaderText = "Date";
            DateGridSalesReturnList.Columns["EndOfDay"].Width = 120;
            DateGridSalesReturnList.Columns["EndOfDay"].DisplayIndex = 0;

            DateGridSalesReturnList.Columns["Description"].HeaderText = "Description";
            DateGridSalesReturnList.Columns["Description"].Width = 120;
            DateGridSalesReturnList.Columns["Description"].DisplayIndex = 1;

            DateGridSalesReturnList.Columns["ItemCode"].HeaderText = "Code";
            DateGridSalesReturnList.Columns["ItemCode"].Width = 120;
            DateGridSalesReturnList.Columns["ItemCode"].DisplayIndex = 2;

            DateGridSalesReturnList.Columns["ItemName"].HeaderText = "Name";
            DateGridSalesReturnList.Columns["ItemName"].Width = 150;
            DateGridSalesReturnList.Columns["ItemName"].DisplayIndex = 3;

            DateGridSalesReturnList.Columns["ItemQuantity"].HeaderText = "Quantity";
            DateGridSalesReturnList.Columns["ItemQuantity"].Width = 120;
            DateGridSalesReturnList.Columns["ItemQuantity"].DisplayIndex = 4;
            DateGridSalesReturnList.Columns["ItemQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DateGridSalesReturnList.Columns["ItemPrice"].HeaderText = "Price";
            DateGridSalesReturnList.Columns["ItemPrice"].Width = 120;
            DateGridSalesReturnList.Columns["ItemPrice"].DisplayIndex = 5;
            DateGridSalesReturnList.Columns["ItemPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DateGridSalesReturnList.Columns["SalesProfit"].HeaderText = "Profit";
            DateGridSalesReturnList.Columns["SalesProfit"].Width = 120;
            DateGridSalesReturnList.Columns["SalesProfit"].DisplayIndex = 6;
            DateGridSalesReturnList.Columns["SalesProfit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DateGridSalesReturnList.Columns["Amount"].HeaderText = "Amount";
            DateGridSalesReturnList.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DateGridSalesReturnList.Columns["Amount"].DisplayIndex = 7;
            DateGridSalesReturnList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DateGridSalesReturnList.Rows)
            {
                DateGridSalesReturnList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DateGridSalesReturnList.RowHeadersWidth = 50;
                DateGridSalesReturnList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods

        private List<SalesReturnTransactionView> GetSalesReturnTransactions()
        {
            var salesReturnTransactionFilter = new SalesReturnTransactionFilter();
            if (!string.IsNullOrWhiteSpace(MaskDtEODFrom.Text.Replace("-", string.Empty).Trim()))
            {
                salesReturnTransactionFilter.DateFrom = MaskDtEODFrom.Text.Trim();
            }

            if (!string.IsNullOrWhiteSpace(MaskDtEODTo.Text.Replace("-", string.Empty).Trim()))
            {
                salesReturnTransactionFilter.DateTo = MaskDtEODTo.Text.Trim();
            }

            var salesReturnTransactionViewList = _userTransactionService.GetSalesReturnTransactions(salesReturnTransactionFilter).ToList();
            return salesReturnTransactionViewList;
        }

        private void LoadSalesReturnTransactions(List<SalesReturnTransactionView> salesReturnTransactionViewList)
        {
            var bindingList = new BindingList<SalesReturnTransactionView>(salesReturnTransactionViewList);
            var source = new BindingSource(bindingList, null);
            DateGridSalesReturnList.DataSource = source;
        }

        private void EnableFields(Action action = Action.None)
        {
            if(action == Action.AddReturn)
            {
                ComboInvoiceNo.Enabled = true;
                TxtSalesProfit.Enabled = true;
                ComboItemCode.Enabled = true;
                TxtItemPrice.Enabled = true;
                TxtQuantity.Enabled = true;

                BtnSave.Enabled = true;
            }
            else if(action == Action.DeleteReturn)
            {
                BtnAdd.Enabled = true;
            }
            else if(action == Action.Load)
            {
                BtnAdd.Enabled = true;
            }
            else if(action == Action.SaveReturn)
            {
                BtnAdd.Enabled = true;
            }
            else if(action == Action.ShowReturn)
            {
                BtnAdd.Enabled = true;
            }
            else
            {
                ComboInvoiceNo.Enabled = false;
                TxtSalesProfit.Enabled = false;
                TxtTotalAmount.Enabled = false;
                ComboItemCode.Enabled = false;
                TxtItemName.Enabled = false;
                TxtItemPrice.Enabled = false;
                TxtQuantity.Enabled = false;

                BtnShow.Enabled = true;
                BtnAdd.Enabled = false;
                BtnSave.Enabled = false;
                BtnDelete.Enabled = true;
            }
        }

        private void ClearAllFields()
        {
            RadioAllTransaction.Checked = false;
            MaskDtEODFrom.Clear();
            MaskDtEODTo.Clear();

            ComboInvoiceNo.Text = string.Empty;
            TxtSalesProfit.Clear();
            TxtTotalAmount.Clear();
            ComboItemCode.Text = string.Empty;
            TxtItemName.Clear();
            TxtItemPrice.Clear();
            TxtQuantity.Clear();
        }

        private void LoadInvoiceNumbers()
        {
            ComboInvoiceNo.ValueMember = "Id";
            ComboInvoiceNo.DisplayMember = "Value";

            _soldItems.OrderBy(x => x.InvoiceNo).ToList().ForEach(x =>
            {
                ComboInvoiceNo.Items.Add(new ComboBoxItem { Id = x.InvoiceNo, Value = x.InvoiceNo });
            });
        }

        #endregion

        private void ComboInvoiceNo_SelectedValueChanged(object sender, EventArgs e)
        {
            var invoiceNo = ComboInvoiceNo.Text;
            var itemIds = _soldItems.Where(x => x.InvoiceNo == invoiceNo).Select(x => x.ItemId);
            var items = _itemService.GetItems();

            ComboItemCode.ValueMember = "Id";
            ComboItemCode.DisplayMember = "Value";
            ComboItemCode.Items.Clear();
            itemIds.OrderBy(x => x).ToList().ForEach(x =>
            {
                var item = items.Where(y => y.Id == x).FirstOrDefault();
                ComboItemCode.Items.Add(new ComboBoxItem { Id = x.ToString(), Value = item.Code });
            });

            ComboItemCode.Focus();
        }

        private void ComboItemCode_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxItem selectedItemCode = (ComboBoxItem)ComboItemCode.SelectedItem;

            if(!string.IsNullOrWhiteSpace(selectedItemCode?.Value))
            {
                var item = _itemService.GetItem(selectedItemCode.Value); ;
                if (item != null)
                {
                    TxtItemName.Text = item.Name;
                }
            }

            TxtSalesProfit.Focus();
        }
    }
}
