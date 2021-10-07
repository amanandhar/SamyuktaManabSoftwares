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
        private readonly ISettingService _settingService;
        private readonly IItemService _itemService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;
        private readonly List<SoldItem> _soldItems;
        private readonly List<SalesReturnTransactionView> _salesReturnTransactionViewList = new List<SalesReturnTransactionView>();

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
        public SalesReturnForm(string username,
            ISettingService settingService, IItemService itemService, 
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService,
            IUserTransactionService userTransactionService)
        {
            InitializeComponent();
            _settingService = settingService;
            _itemService = itemService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
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
            try
            {
                var salesReturnTransactionView = new SalesReturnTransactionView
                {
                    Id = _salesReturnTransactionViewList.Count + 1,
                    EndOfDay = _endOfDay,
                    Description = ComboInvoiceNo.Text,
                    ItemCode = ComboItemCode.Text,
                    ItemName = TxtItemName.Text,
                    ItemQuantity = Convert.ToDecimal(TxtQuantity.Text),
                    ItemPrice = Convert.ToDecimal(TxtItemPrice.Text),
                    SalesProfit = Convert.ToDecimal(TxtSalesProfit.Text),
                    Amount = Math.Round(Convert.ToDecimal(TxtQuantity.Text) * Convert.ToDecimal(TxtItemPrice.Text), 2) + Convert.ToDecimal(TxtSalesProfit.Text)
                };

                _salesReturnTransactionViewList.Add(salesReturnTransactionView);
                TxtTotalAmount.Text = _salesReturnTransactionViewList.Sum(x => (x.Amount)).ToString();
                ClearAllFields();
                LoadSalesReturnTransactions(_salesReturnTransactionViewList);
                EnableFields();
                EnableFields(Action.AddReturn);

            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                        IncomeExpense = Constants.SALES_RETURN,
                        SubTotal = 0.00m,
                        DiscountPercent = 0.00m,
                        Discount = 0.00m,
                        VatPercent = 0.00m,
                        Vat = 0.00m,
                        DeliveryChargePercent = 0.00m,
                        DeliveryCharge = 0.00m,
                        DueAmount = _salesReturnTransactionViewList.Sum(x => x.SalesProfit),
                        ReceivedAmount = 0.00m,
                        AddedBy = _username,
                        AddedDate = date
                    };
                    _userTransactionService.AddUserTransaction(userTransactionExpense);

                    // Add Purchase
                    List<PurchasedItem> purchasedItems = _salesReturnTransactionViewList.Select(salesReturn => new PurchasedItem
                    {
                        EndOfDay = _endOfDay,
                        SupplierId = purchasedItem.SupplierId,
                        BillNo = salesReturn.Description,
                        ItemId = Convert.ToInt64(selectedItem.Id),
                        Quantity = salesReturn.ItemQuantity,
                        Price = salesReturn.ItemPrice,
                        AddedBy = _username,
                        AddedDate = date
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
                        SubTotal = 0.00m,
                        DiscountPercent = 0.00m,
                        Discount = 0.00m,
                        VatPercent = 0.00m,
                        Vat = 0.00m,
                        DeliveryChargePercent = 0.00m,
                        DeliveryCharge = 0.00m,
                        DueAmount = _salesReturnTransactionViewList.Sum(x => x.ItemPrice),
                        ReceivedAmount = 0.00m,
                        AddedBy = _username,
                        AddedDate = date
                    };

                    _userTransactionService.AddUserTransaction(userTransactionPurchase);

                    DialogResult result = MessageBox.Show("Item/s have been returned successfully.", "Message", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields();
                        EnableFields(Action.SaveReturn);
                        ComboInvoiceNo.Text = string.Empty;
                        TxtTotalAmount.Clear();
                        DateGridSalesReturnList.DataSource = null;
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
            salesReturnTransactionFilter.DateFrom = UtilityService.GetDate(MaskDtEODFrom.Text);
            salesReturnTransactionFilter.DateTo = UtilityService.GetDate(MaskDtEODTo.Text);

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
                BtnSave.Enabled = true;
            }
            else if(action == Action.DeleteReturn)
            {
                BtnAdd.Enabled = true;
            }
            else if(action == Action.Load)
            {
                ComboInvoiceNo.Enabled = true;
                TxtSalesProfit.Enabled = true;
                ComboItemCode.Enabled = true;
                TxtItemPrice.Enabled = true;
                TxtQuantity.Enabled = true;

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

            //ComboInvoiceNo.Text = string.Empty;
            TxtSalesProfit.Clear();
            //TxtTotalAmount.Clear();
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
