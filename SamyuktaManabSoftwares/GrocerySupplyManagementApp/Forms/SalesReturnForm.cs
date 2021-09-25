using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
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
            LoadSalesTransactions();
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
                    LoadSalesTransactions();
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

        }
        #endregion

        #region Helper Methods

        private void LoadSalesTransactions()
        {

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
            var soldITems = _soldItemService.GetSoldItems();
        }

        #endregion
    }
}
