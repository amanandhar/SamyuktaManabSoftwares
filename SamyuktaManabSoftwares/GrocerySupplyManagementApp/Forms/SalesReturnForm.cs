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
            //LoadSalesReturnTransactions();
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

                // Start Expense
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

                // End of the expense

                List<PurchasedItem> purchasedItems = _purchasedItemViewList.Select(item => new PurchasedItem
                {
                    EndOfDay = _endOfDay,
                    SupplierId = null,
                    BillNo = item.BillNo,
                    ItemId = _itemService.GetItem(item.Code).Id,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    AddedDate = date,
                    UpdatedDate = date
                }).ToList();

                purchasedItems.ForEach(purchasedItem =>
                {
                    _purchasedItemService.AddPurchasedItem(purchasedItem);
                });

                var userTransactionPurchase = new UserTransaction
                {
                    EndOfDay = _endOfDay,
                    BillNo = ComboInvoiceNo.Text,
                    SupplierId = null,
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
                    //LoadSalesReturnTransactions();
                    EnableFields();
                    EnableFields(Action.SaveReturn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.DeleteReturn);
        }
        #endregion

        #region Grid Event
        private void DateGridSalesReturnList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DateGridSalesReturnList.Columns["Id"].Visible = false;

            DateGridSalesReturnList.Columns["EndOfDay"].HeaderText = "Date";
            DateGridSalesReturnList.Columns["EndOfDay"].Width = 100;
            DateGridSalesReturnList.Columns["EndOfDay"].DisplayIndex = 0;

            DateGridSalesReturnList.Columns["Description"].HeaderText = "Description";
            DateGridSalesReturnList.Columns["Description"].Width = 120;
            DateGridSalesReturnList.Columns["Description"].DisplayIndex = 1;

            DateGridSalesReturnList.Columns["Narration"].HeaderText = "Narration";
            DateGridSalesReturnList.Columns["Narration"].Width = 270;
            DateGridSalesReturnList.Columns["Narration"].DisplayIndex = 2;

            DateGridSalesReturnList.Columns["Debit"].HeaderText = "Debit";
            DateGridSalesReturnList.Columns["Debit"].Width = 100;
            DateGridSalesReturnList.Columns["Debit"].DisplayIndex = 3;
            DateGridSalesReturnList.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DateGridSalesReturnList.Columns["Credit"].HeaderText = "Credit";
            DateGridSalesReturnList.Columns["Credit"].Width = 100;
            DateGridSalesReturnList.Columns["Credit"].DisplayIndex = 4;
            DateGridSalesReturnList.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DateGridSalesReturnList.Columns["Balance"].HeaderText = "Balance";
            DateGridSalesReturnList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DateGridSalesReturnList.Columns["Balance"].DisplayIndex = 5;
            DateGridSalesReturnList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DateGridSalesReturnList.Rows)
            {
                DateGridSalesReturnList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DateGridSalesReturnList.RowHeadersWidth = 50;
                DateGridSalesReturnList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods

        //private List<SalesReturnTransactionView> GetSalesReturnTransactions()
        //{
        //    var salesReturnTransactionViewList = _userTransactionService.GetSalesReturnTransactionList().ToList();
        //    return salesReturnTransactionViewList;
        //}

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
                TxtTotalAmount.Enabled = true;
                ComboItemCode.Enabled = true;
                TxtItemName.Enabled = true;
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

            itemIds.OrderBy(x => x).ToList().ForEach(x =>
            {
                ComboItemCode.Items.Add(new ComboBoxItem { Id = x.ToString(), Value = items.Where(y => y.Id == x).Select(y => y.Code).FirstOrDefault() });
            });
        }

        private void ComboItemCode_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxItem selectedItemCode = (ComboBoxItem)ComboItemCode.SelectedItem;

            var item = _itemService.GetItem(selectedItemCode?.Id);
            if(item != null)
            {
                TxtItemName.Text = item.Name;
            }
        }
    }
}
