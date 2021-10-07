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
    public partial class StockSummaryForm : Form
    {
        private readonly ISettingService _settingService;
        private readonly IItemService _itemService;
        private readonly IPricedItemService _pricedItemService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemItemService;
        private readonly IStockService _stockService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IStockAdjustmentService _stockAdjustmentService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Constructor
        public StockSummaryForm(string username, 
            ISettingService settingService, IItemService itemService,
            IPricedItemService pricedItemService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemItemService, 
            IStockService stockService, IUserTransactionService userTransactionService,
            IStockAdjustmentService stockAdjustmentService)
        {
            InitializeComponent();

            _settingService = settingService;
            _itemService = itemService;
            _pricedItemService = pricedItemService;
            _purchasedItemService = purchasedItemService;
            _soldItemItemService = soldItemItemService;
            _stockService = stockService;
            _userTransactionService = userTransactionService;
            _stockAdjustmentService = stockAdjustmentService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void StockForm_Load(object sender, EventArgs e)
        {
            MaskDtEODFrom.Text = _endOfDay;
            MaskDtEODTo.Text = _endOfDay;
            _purchasedItemService.GetPurchasedItemDetails().ToList().ForEach(purchasedItem =>
            {
                ComboItemCode.Items.Add(purchasedItem.Code);
            });

            LoadTotalStock();
        }

        #endregion

        #region Button Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void BtnStockAdjustment_Click(object sender, EventArgs e)
        {
            var stockAdjustmentForm = new StockAdjustmentForm(_username, _settingService, 
                _itemService, _pricedItemService, 
                _purchasedItemService, _soldItemItemService, 
                _userTransactionService, _stockService, _stockAdjustmentService);
            stockAdjustmentForm.ShowDialog();
        }
        #endregion

        #region DataGrid Event

        private void DataGridStockList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridStockList.Columns["AddedDate"].Visible = false;
            DataGridStockList.Columns["StockQuantity"].Visible = false;
            DataGridStockList.Columns["TotalPurchasePrice"].Visible = false;

            DataGridStockList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridStockList.Columns["EndOfDay"].Width = 75;
            DataGridStockList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridStockList.Columns["Description"].HeaderText = "Description";
            DataGridStockList.Columns["Description"].Width = 90;
            DataGridStockList.Columns["Description"].DisplayIndex = 1;

            DataGridStockList.Columns["Type"].HeaderText = "Type";
            DataGridStockList.Columns["Type"].Width = 70;
            DataGridStockList.Columns["Type"].DisplayIndex = 2;

            DataGridStockList.Columns["ItemCode"].HeaderText = "ItemCode";
            DataGridStockList.Columns["ItemCode"].Width = 75;
            DataGridStockList.Columns["ItemCode"].DisplayIndex = 3;

            DataGridStockList.Columns["ItemName"].HeaderText = "ItemName";
            DataGridStockList.Columns["ItemName"].Width = 150;
            DataGridStockList.Columns["ItemName"].DisplayIndex = 4;

            DataGridStockList.Columns["PurchaseQuantity"].HeaderText = "Purchase";
            DataGridStockList.Columns["PurchaseQuantity"].Width = 75;
            DataGridStockList.Columns["PurchaseQuantity"].DisplayIndex = 5;
            DataGridStockList.Columns["PurchaseQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["SalesQuantity"].HeaderText = "Sales";
            DataGridStockList.Columns["SalesQuantity"].Width = 60;
            DataGridStockList.Columns["SalesQuantity"].DisplayIndex = 6;
            DataGridStockList.Columns["SalesQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["Unit"].HeaderText = "Unit";
            DataGridStockList.Columns["Unit"].Width = 60;
            DataGridStockList.Columns["Unit"].DisplayIndex = 7;
            DataGridStockList.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridStockList.Columns["PurchasePrice"].HeaderText = "PurchasePrice";
            DataGridStockList.Columns["PurchasePrice"].Width = 95;
            DataGridStockList.Columns["PurchasePrice"].DisplayIndex = 8;
            DataGridStockList.Columns["PurchasePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["PurchasePrice"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["SalesPrice"].HeaderText = "SalesPrice";
            DataGridStockList.Columns["SalesPrice"].Width = 80;
            DataGridStockList.Columns["SalesPrice"].DisplayIndex = 9;
            DataGridStockList.Columns["SalesPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["SalesPrice"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["StockValue"].HeaderText = "Stock Value";
            DataGridStockList.Columns["StockValue"].Width = 105;
            DataGridStockList.Columns["StockValue"].DisplayIndex = 10;
            DataGridStockList.Columns["StockValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["StockValue"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["PerUnitValue"].HeaderText = "PerUnitValue";
            DataGridStockList.Columns["PerUnitValue"].Width = 90;
            DataGridStockList.Columns["PerUnitValue"].DisplayIndex = 11;
            DataGridStockList.Columns["PerUnitValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["PerUnitValue"].DefaultCellStyle.Format = "0.00";

            foreach (DataGridViewRow row in DataGridStockList.Rows)
            {
                DataGridStockList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridStockList.RowHeadersWidth = 50;
                DataGridStockList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        #endregion

        #region Helper Methods

        private void LoadItems()
        {
            var stockFilter = new StockFilter
            {
                DateFrom = UtilityService.GetDate(MaskDtEODFrom.Text),
                DateTo = UtilityService.GetDate(MaskDtEODTo.Text),
                ItemCode = ComboItemCode.Text
            };

            TxtPurchase.Text = _purchasedItemService.GetPurchasedItemTotalQuantity(stockFilter).ToString();
            TxtSales.Text = _soldItemItemService.GetSoldItemTotalQuantity(stockFilter).ToString();
            TxtBoxAdded.Text = _stockAdjustmentService.GetAddedStockTotalQuantity(stockFilter).ToString();
            TxtBoxDeducted.Text = _stockAdjustmentService.GetDeductedStockTotalQuantity(stockFilter).ToString();
            TxtStock.Text = ((Convert.ToInt64(TxtPurchase.Text) + Convert.ToInt64(TxtBoxAdded.Text))
                - (Convert.ToInt64(TxtBoxDeducted.Text) + Convert.ToDecimal(TxtSales.Text))).ToString();

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
            TxtValue.Text = latestStockView.Sum(x => Math.Round(x.StockValue, 2)).ToString();

            var bindingList = new BindingList<StockView>(stockViewList);
            var source = new BindingSource(bindingList, null);
            DataGridStockList.DataSource = source;
        }

        private void LoadTotalStock()
        {
            StockFilter stockFilter = new StockFilter();
            var totalPurchase = _purchasedItemService.GetPurchasedItemTotalQuantity(stockFilter);
            var totalSales = _soldItemItemService.GetSoldItemTotalQuantity(stockFilter);
            TxtTotalStock.Text = (totalPurchase - totalSales).ToString();

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
            TxtTotalValue.Text = latestStockView.Sum(x => Math.Round(x.StockValue, 2)).ToString();
        }

        #endregion
    }
}
