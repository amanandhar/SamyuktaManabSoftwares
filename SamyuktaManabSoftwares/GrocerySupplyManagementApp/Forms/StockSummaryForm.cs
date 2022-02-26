using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class StockSummaryForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemItemService;
        private readonly IStockService _stockService;
        private readonly IStockAdjustmentService _stockAdjustmentService;

        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Constructor
        public StockSummaryForm(ISettingService settingService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemItemService,
            IStockService stockService, IStockAdjustmentService stockAdjustmentService)
        {
            InitializeComponent();

            _settingService = settingService;
            _purchasedItemService = purchasedItemService;
            _soldItemItemService = soldItemItemService;
            _stockService = stockService;
            _stockAdjustmentService = stockAdjustmentService;

            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void StockForm_Load(object sender, EventArgs e)
        {
            MaskDtEODFrom.Text = _endOfDay;
            MaskDtEODTo.Text = _endOfDay;
            ComboItemCode.Items.Clear();
            _purchasedItemService.GetPurchasedItemDetails().ToList().ForEach(purchasedItem =>
            {
                ComboItemCode.ValueMember = "Id";
                ComboItemCode.DisplayMember = "Value";

                ComboItemCode.Items.Add(new ComboBoxItem { Id = purchasedItem.Code, Value = purchasedItem.Code + " - " + purchasedItem.Name });
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

        #region Combo Box Event
        private void ComboItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void ComboItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                try
                {
                    LoadItems();
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    UtilityService.ShowExceptionMessageBox();
                }
            }
        }
        #endregion

        #region Radio Button Event
        private void RadioBtnAll_CheckedChanged(object sender, EventArgs e)
        {
            MaskDtEODFrom.Clear();
            MaskDtEODTo.Clear();
        }
        #endregion

        #region Mask Date Event
        private void MaskDtEOD_KeyDown(object sender, KeyEventArgs e)
        {
            RadioBtnAll.Checked = false;
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

            DataGridStockList.Columns["Description"].HeaderText = "Descrip";
            DataGridStockList.Columns["Description"].Width = 70;
            DataGridStockList.Columns["Description"].DisplayIndex = 1;

            DataGridStockList.Columns["Type"].HeaderText = "Type";
            DataGridStockList.Columns["Type"].Width = 50;
            DataGridStockList.Columns["Type"].DisplayIndex = 2;

            DataGridStockList.Columns["ItemCode"].HeaderText = "Item Code";
            DataGridStockList.Columns["ItemCode"].Width = 70;
            DataGridStockList.Columns["ItemCode"].DisplayIndex = 3;

            DataGridStockList.Columns["ItemName"].HeaderText = "Item Name";
            DataGridStockList.Columns["ItemName"].Width = 150;
            DataGridStockList.Columns["ItemName"].DisplayIndex = 4;

            DataGridStockList.Columns["PurchaseQuantity"].HeaderText = "Purchase";
            DataGridStockList.Columns["PurchaseQuantity"].Width = 70;
            DataGridStockList.Columns["PurchaseQuantity"].DisplayIndex = 5;
            DataGridStockList.Columns["PurchaseQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["SalesQuantity"].HeaderText = "Sales";
            DataGridStockList.Columns["SalesQuantity"].Width = 65;
            DataGridStockList.Columns["SalesQuantity"].DisplayIndex = 6;
            DataGridStockList.Columns["SalesQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["Unit"].HeaderText = "Unit";
            DataGridStockList.Columns["Unit"].Width = 60;
            DataGridStockList.Columns["Unit"].DisplayIndex = 7;
            DataGridStockList.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridStockList.Columns["PurchasePrice"].HeaderText = "Purchase Price";
            DataGridStockList.Columns["PurchasePrice"].Width = 75;
            DataGridStockList.Columns["PurchasePrice"].DisplayIndex = 8;
            DataGridStockList.Columns["PurchasePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["PurchasePrice"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["SalesPrice"].HeaderText = "Sales Price";
            DataGridStockList.Columns["SalesPrice"].Width = 70;
            DataGridStockList.Columns["SalesPrice"].DisplayIndex = 9;
            DataGridStockList.Columns["SalesPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["SalesPrice"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["StockValue"].HeaderText = "Stock Value";
            DataGridStockList.Columns["StockValue"].Width = 90;
            DataGridStockList.Columns["StockValue"].DisplayIndex = 10;
            DataGridStockList.Columns["StockValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["StockValue"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["PerUnitValue"].HeaderText = "Per Unit Value";
            DataGridStockList.Columns["PerUnitValue"].Width = 90;
            DataGridStockList.Columns["PerUnitValue"].DisplayIndex = 11;
            DataGridStockList.Columns["PerUnitValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["PerUnitValue"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["PartyId"].HeaderText = "Party Id";
            DataGridStockList.Columns["PartyId"].Width = 90;
            DataGridStockList.Columns["PartyId"].DisplayIndex = 12;
            DataGridStockList.Columns["PartyId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridStockList.Columns["PartyId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            if(!string.IsNullOrEmpty(ComboItemCode.Text.Trim()) && ComboItemCode.SelectedItem == null) {
                var comboItem = ComboItemCode.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Id == ComboItemCode.Text.Trim());
                ComboItemCode.SelectedItem = comboItem;
            }

            var stockFilter = new StockFilter
            {
                DateFrom = UtilityService.GetDate(MaskDtEODFrom.Text.Trim()),
                DateTo = UtilityService.GetDate(MaskDtEODTo.Text.Trim()),
                ItemCode = (ComboItemCode.SelectedItem as ComboBoxItem)?.Id?.Trim()
            };

            TxtPurchase.Text = _purchasedItemService.GetPurchasedItemTotalQuantity(stockFilter).ToString();
            TxtSales.Text = _soldItemItemService.GetSoldItemTotalQuantity(stockFilter).ToString();
            TxtBoxAdded.Text = _stockAdjustmentService.GetAddedStockTotalQuantity(stockFilter).ToString();
            TxtBoxDeducted.Text = _stockAdjustmentService.GetDeductedStockTotalQuantity(stockFilter).ToString();
            TxtStock.Text = ((Convert.ToDecimal(TxtPurchase.Text.Trim()) + Convert.ToDecimal(TxtBoxAdded.Text.Trim()))
                - (Convert.ToDecimal(TxtBoxDeducted.Text.Trim()) + Convert.ToDecimal(TxtSales.Text.Trim()))).ToString();

            var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
            var stockValue = _stockService.GetStockValue(stocks.ToList(), stockFilter);
            TxtValue.Text = stockValue.ToString();

            var stockViewList = _stockService.GetStockViewList(stocks.ToList(), stockFilter);
            var bindingList = new BindingList<StockView>(stockViewList);
            var source = new BindingSource(bindingList, null);
            DataGridStockList.DataSource = source;
        }

        private void LoadTotalStock()
        {
            StockFilter stockFilter = new StockFilter();
            TxtTotalStock.Text = _stockService.GetTotalStock(stockFilter).ToString();

            var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
            var stockValue = _stockService.GetStockValue(stocks.ToList(), stockFilter);
            TxtTotalValue.Text = stockValue.ToString();
        }

        #endregion
    }
}
