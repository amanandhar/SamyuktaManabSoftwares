using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class StockAdjustmentForm : Form, IPricedItemListForm
    {
        private readonly ISettingService _settingService;
        private readonly IItemService _itemService;
        private readonly IPricedItemService _pricedItemService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IStockService _stockService;
        private readonly IStockAdjustmentService _stockAdjustmentService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Enum
        private enum Action
        {
            Clear, 
            Edit,
            Save,
            PopulateItem,
            Load,
            None
        }
        #endregion

        #region Constructor
        public StockAdjustmentForm(string username, ISettingService settingService,
            IItemService itemService, IPricedItemService pricedItemService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService,
            IUserTransactionService userTransactionService, IStockService stockService,
            IStockAdjustmentService stockAdjustmentService)
        {
            InitializeComponent();

            _settingService = settingService;
            _itemService = itemService;
            _pricedItemService = pricedItemService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _stockService = stockService;
            _stockAdjustmentService = stockAdjustmentService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void StockAdjustmentForm_Load(object sender, EventArgs e)
        {
            LoadStockActions();
            EnableFields();
            EnableFields(Action.Load);
        }
        #endregion

        #region Button Event
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PricedItemListForm pricedItemListForm = new PricedItemListForm(_pricedItemService, this);
            pricedItemListForm.ShowDialog();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Edit);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var date = DateTime.Now;
                var stockAdjustment = new StockAdjustment
                {
                    EndOfDay = _endOfDay,
                    ItemId = _itemService.GetItem(TxtBoxItemCode.Text).Id,
                    Unit = TxtBoxItemUnit.Text,
                    Action = ComboAction.Text,
                    Quantity = string.IsNullOrWhiteSpace(TxtBoxItemQuantity.Text.Trim()) ? 0 : Convert.ToInt64(TxtBoxItemQuantity.Text),
                    Price = string.IsNullOrWhiteSpace(TxtItemPrice.Text.Trim()) ? 0 : Convert.ToInt64(TxtItemPrice.Text),
                    AddedBy = _username,
                    AddedDate = date
                };

                _stockAdjustmentService.AddStockAdjustment(stockAdjustment);

                DialogResult result = MessageBox.Show("Stock adjustment done successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields(Action.None);
                    EnableFields(Action.Save);
                }
                /*
                var date = DateTime.Now;
                var purchasedItem = new PurchasedItem
                {
                    EndOfDay = _endOfDay,
                    SupplierId =  null,
                    BillNo = null,
                    ItemId = _itemService.GetItem(TxtBoxItemCode.Text).Id,
                    Quantity = Convert.ToDecimal(TxtBoxItemQuantity.Text),
                    Price = 0.00m,
                    AddedBy = _username,
                    AddedDate = date
                };
                _purchasedItemService.AddPurchasedItem(purchasedItem);


                var userTransaction = new UserTransaction
                {
                    EndOfDay = _endOfDay,
                    BillNo = null,
                    SupplierId = null,
                    Action = Constants.ADD,
                    ActionType = null,
                    IncomeExpense = null,
                    SubTotal = 0.00m,
                    DiscountPercent = 0.00m,
                    Discount = 0.00m,
                    VatPercent = 0.00m,
                    Vat = 0.00m,
                    DeliveryChargePercent = 0.00m,
                    DeliveryCharge = 0.00m,
                    DueAmount = 0.00m,
                    ReceivedAmount = 0.00m,
                    AddedBy = _username,
                    AddedDate = date
                };

                _userTransactionService.AddUserTransaction(userTransaction);
                */
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Helper Methods
        public void PopulatePricedItem(long pricedId)
        {
            try
            {
                var stockFilter = new StockFilter()
                {
                    ItemCode = TxtBoxItemCode.Text.Trim()
                };

                var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var stockViewList = new List<StockView>();
                if (!string.IsNullOrWhiteSpace(stockFilter.DateFrom) && !string.IsNullOrWhiteSpace(stockFilter.DateTo))
                {
                    stockViewList = UtilityService.CalculateStock(stocks.ToList())
                        .Where(x => x.EndOfDay.CompareTo(stockFilter.DateFrom) >= 0 && x.EndOfDay.CompareTo(stockFilter.DateTo) <= 0)
                        .ToList();
                }
                else
                {
                    stockViewList = UtilityService.CalculateStock(stocks.ToList());
                }

                var latestStockView = stockViewList.GroupBy(x => x.ItemCode)
                    .Select(x => x.OrderByDescending(y => y.AddedDate).FirstOrDefault())
                    .ToList();

                var perUnitValue = latestStockView.Sum(x => Math.Round(x.PerUnitValue, 2));

                var pricedItem = _pricedItemService.GetPricedItem(pricedId);
                var item = _itemService.GetItem(pricedItem.ItemId);
                TxtBoxItemCode.Text = item.Code;
                TxtBoxItemName.Text = item.Name;
                TxtBoxItemBrand.Text = item.Brand;
                TxtBoxItemUnit.Text = pricedItem.CustomUnit;
                TxtItemPrice.Text = perUnitValue.ToString();

                EnableFields();
                EnableFields(Action.PopulateItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearAllFields()
        {
            TxtBoxItemCode.Clear();
            TxtBoxItemName.Clear();
            TxtBoxItemBrand.Clear();
            TxtBoxItemUnit.Clear();
            ComboAction.Text = string.Empty;
            TxtBoxItemQuantity.Clear();
        }

        private void LoadStockActions()
        {
            ComboAction.Items.Clear();
            ComboAction.ValueMember = "Id";
            ComboAction.DisplayMember = "Value";

            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.ADD, Value = Constants.ADD });
            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.DEDUCT, Value = Constants.DEDUCT });
        }

        private void EnableFields(Action action = Action.None)
        {
            if(action == Action.Load)
            {
                BtnEdit.Enabled = true;
            }
            else if(action == Action.Edit)
            {
                ComboAction.Enabled = true;
                TxtBoxItemQuantity.Enabled = true;

                BtnSearch.Enabled = true;
            }
            else if(action == Action.PopulateItem)
            {
                ComboAction.Enabled = true;
                TxtBoxItemQuantity.Enabled = true;

                BtnSearch.Enabled = true;
                BtnClear.Enabled = true;
                BtnSave.Enabled = true;
            }
            else if(action == Action.Save)
            {
                BtnEdit.Enabled = true;
            }
            else
            {
                TxtBoxItemCode.Enabled = false;
                TxtBoxItemName.Enabled = false;
                TxtBoxItemBrand.Enabled = false;
                TxtBoxItemUnit.Enabled = false;
                ComboAction.Enabled = false;
                TxtBoxItemQuantity.Enabled = false;

                BtnSearch.Enabled = false;
                BtnClear.Enabled = false;
                BtnEdit.Enabled = false;
                BtnSave.Enabled = false;
            }
        }
        #endregion

    }
}
