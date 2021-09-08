using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class StockForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemItemService;
        private readonly IStockService _stockService;

        private readonly string _endOfDay;

        #region Constructor
        public StockForm(IFiscalYearService fiscalYearService, IPurchasedItemService purchasedItemService, 
            ISoldItemService soldItemItemService, IStockService stockService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _purchasedItemService = purchasedItemService;
            _soldItemItemService = soldItemItemService;
            _stockService = stockService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }
        #endregion

        #region Form Load Event
        private void StockForm_Load(object sender, EventArgs e)
        {
            MaskEndOfDayFrom.Text = _endOfDay;
            MaskEndOfDayTo.Text = _endOfDay;
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
        #endregion

        #region DataGrid Event

        private void DataGridStockList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridStockList.Columns["AddedDate"].Visible = false;
            DataGridStockList.Columns["StockQuantity"].Visible = false;
            DataGridStockList.Columns["TotalPurchasePrice"].Visible = false;

            DataGridStockList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridStockList.Columns["EndOfDay"].Width = 80;
            DataGridStockList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridStockList.Columns["Description"].HeaderText = "Description";
            DataGridStockList.Columns["Description"].Width = 90;
            DataGridStockList.Columns["Description"].DisplayIndex = 1;

            DataGridStockList.Columns["ItemCode"].HeaderText = "ItemCode";
            DataGridStockList.Columns["ItemCode"].Width = 70;
            DataGridStockList.Columns["ItemCode"].DisplayIndex = 2;

            DataGridStockList.Columns["ItemName"].HeaderText = "ItemName";
            DataGridStockList.Columns["ItemName"].Width = 160;
            DataGridStockList.Columns["ItemName"].DisplayIndex = 3;

            DataGridStockList.Columns["PurchaseQuantity"].HeaderText = "Purchase";
            DataGridStockList.Columns["PurchaseQuantity"].Width = 70;
            DataGridStockList.Columns["PurchaseQuantity"].DisplayIndex = 4;
            DataGridStockList.Columns["PurchaseQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["SalesQuantity"].HeaderText = "Sales";
            DataGridStockList.Columns["SalesQuantity"].Width = 60;
            DataGridStockList.Columns["SalesQuantity"].DisplayIndex = 5;
            DataGridStockList.Columns["SalesQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["Unit"].HeaderText = "Unit";
            DataGridStockList.Columns["Unit"].Width = 60;
            DataGridStockList.Columns["Unit"].DisplayIndex = 6;
            DataGridStockList.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridStockList.Columns["PurchasePrice"].HeaderText = "PurchasPrice";
            DataGridStockList.Columns["PurchasePrice"].Width = 90;
            DataGridStockList.Columns["PurchasePrice"].DisplayIndex = 7;
            DataGridStockList.Columns["PurchasePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["PurchasePrice"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["SalesPrice"].HeaderText = "SalesPrice";
            DataGridStockList.Columns["SalesPrice"].Width = 80;
            DataGridStockList.Columns["SalesPrice"].DisplayIndex = 8;
            DataGridStockList.Columns["SalesPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["SalesPrice"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["StockValue"].HeaderText = "StockValue";
            DataGridStockList.Columns["StockValue"].Width = 95;
            DataGridStockList.Columns["StockValue"].DisplayIndex = 9;
            DataGridStockList.Columns["StockValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["StockValue"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["PerUnitValue"].HeaderText = "PerUnitValue";
            DataGridStockList.Columns["PerUnitValue"].Width = 90;
            DataGridStockList.Columns["PerUnitValue"].DisplayIndex = 10;
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
            StockFilter stockFilter = new StockFilter();
            var dateFrom = MaskEndOfDayFrom.Text;
            var dateTo = MaskEndOfDayTo.Text;

            if (!string.IsNullOrWhiteSpace(dateFrom.Replace("-", string.Empty).Trim()))
            {
                stockFilter.DateFrom = dateFrom.Trim();
            }

            if (!string.IsNullOrWhiteSpace(dateTo.Replace("-", string.Empty).Trim()))
            {
                stockFilter.DateTo = dateTo.Trim();
            }

            stockFilter.ItemCode = ComboItemCode.Text;

            TxtPurchase.Text = _purchasedItemService.GetPurchasedItemTotalQuantity(stockFilter).ToString();
            TxtSales.Text = _soldItemItemService.GetSoldItemTotalQuantity(stockFilter).ToString();
            TxtStock.Text = (Convert.ToDecimal(TxtPurchase.Text) - Convert.ToDecimal(TxtSales.Text)).ToString();

            var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
            var stockViewList = UtilityService.CalculateStock(stocks.ToList());
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
            var stockViewList = UtilityService.CalculateStock(stocks.ToList());
            var latestStockView = stockViewList.GroupBy(x => x.ItemCode)
                .Select(x => x.OrderByDescending(y => y.AddedDate).FirstOrDefault())
                .ToList();
            TxtTotalValue.Text = latestStockView.Sum(x => Math.Round(x.StockValue, 2)).ToString();
        }

        #endregion
    }
}
