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
            IUserTransactionService userTransactionService, IStockService stockService,
            IStockAdjustmentService stockAdjustmentService)
        {
            InitializeComponent();

            _settingService = settingService;
            _itemService = itemService;
            _pricedItemService = pricedItemService;
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

        #region Combo Box Event
        private void ComboAction_SelectedValueChanged(object sender, EventArgs e)
        {
            TxtBoxItemQuantity.Focus();
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
                if(ComboAction.Text == Constants.DEDUCT)
                {
                    var userTransaction = new UserTransaction
                    {
                        EndOfDay = _endOfDay,
                        Action = Constants.DEDUCT,
                        ActionType = Constants.ACTION_TYPE_NONE,
                        Expense = Constants.STOCK_ADJUSTMENT,
                        PaymentAmount = Convert.ToDecimal(TxtBoxItemPrice.Text),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };
                    _userTransactionService.AddUserTransaction(userTransaction);
                }
                else if(ComboAction.Text == Constants.ADD)
                {
                    var userTransaction = new UserTransaction
                    {
                        EndOfDay = _endOfDay,
                        Action = Constants.ADD,
                        ActionType = Constants.ACTION_TYPE_NONE,
                        Income = Constants.STOCK_ADJUSTMENT,
                        ReceivedAmount = Convert.ToDecimal(TxtBoxItemPrice.Text),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };
                    _userTransactionService.AddUserTransaction(userTransaction);
                }

                var lastUserTransaction = _userTransactionService.GetLastUserTransaction(string.Empty);
                var stockAdjustment = new StockAdjustment
                {
                    EndOfDay = _endOfDay,
                    UserTransactionId = lastUserTransaction.Id,
                    ItemId = _itemService.GetItem(TxtBoxItemCode.Text).Id,
                    Unit = TxtBoxItemUnit.Text,
                    Action = ComboAction.Text,
                    Quantity = string.IsNullOrWhiteSpace(TxtBoxItemQuantity.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtBoxItemQuantity.Text),
                    Price = string.IsNullOrWhiteSpace(TxtBoxItemPrice.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtBoxItemPrice.Text),
                    AddedBy = _username,
                    AddedDate = DateTime.Now
                };
                _stockAdjustmentService.AddStockAdjustment(stockAdjustment);

                DialogResult result = MessageBox.Show("Stock adjustment done successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields(Action.None);
                    EnableFields(Action.Save);
                }
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
                var pricedItem = _pricedItemService.GetPricedItem(pricedId);
                var item = _itemService.GetItem(pricedItem.ItemId);

                var stockFilter = new StockFilter()
                {
                    ItemCode = item.Code
                };
                var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var perUnitValue = _stockService.GetPerUnitValue(stocks.ToList(), stockFilter);

                TxtBoxItemCode.Text = item.Code;
                TxtBoxItemName.Text = item.Name;
                TxtBoxItemBrand.Text = item.Brand;
                TxtBoxItemUnit.Text = pricedItem.CustomUnit;
                TxtBoxItemPrice.Text = perUnitValue.ToString();

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
            TxtBoxItemPrice.Clear();
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
                TxtBoxItemPrice.Enabled = false;
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
