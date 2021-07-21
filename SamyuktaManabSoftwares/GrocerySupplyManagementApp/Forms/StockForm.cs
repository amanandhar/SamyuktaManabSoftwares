﻿using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class StockForm : Form
    {
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemItemService;
        private readonly IStockService _stockService;

        #region Constructor
        public StockForm(IPurchasedItemService purchasedItemService, ISoldItemService soldItemItemService,
            IStockService stockService)
        {
            InitializeComponent();

            _purchasedItemService = purchasedItemService;
            _soldItemItemService = soldItemItemService;
            _stockService = stockService;
    }
        #endregion

        #region Form Load Event
        private void StockForm_Load(object sender, EventArgs e)
        {

            _soldItemItemService.GetSoldItemCodes().ToList().ForEach(code =>
            {
                ComboItemCode.Items.Add(code);
            });
        }

        #endregion

        #region Checkbox Event
        private void CheckAllTransactions_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckAllTransactions.Checked)
            {
                MaskDateFrom.Text = string.Empty;
                MaskDateTo.Text = string.Empty;
                ComboItemCode.Text = string.Empty;
            }
        }

        #endregion

        #region Combobox Event
        private void ComboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCheckState(false);
        }
        #endregion

        #region Mask Text Box Event
        private void MaskTextBoxDateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            ChangeCheckState(false);
        }

        private void MaskDateTo_KeyDown(object sender, KeyEventArgs e)
        {
            ChangeCheckState(false);
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
            DataGridStockList.Columns["Date"].Visible = false;

            DataGridStockList.Columns["EndOfDate"].HeaderText = "Date";
            DataGridStockList.Columns["EndOfDate"].Width = 100;
            DataGridStockList.Columns["EndOfDate"].DisplayIndex = 0;
            DataGridStockList.Columns["EndOfDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

            DataGridStockList.Columns["Type"].HeaderText = "Type";
            DataGridStockList.Columns["Type"].Width = 100;
            DataGridStockList.Columns["Type"].DisplayIndex = 1;

            DataGridStockList.Columns["ItemCode"].HeaderText = "Item Code";
            DataGridStockList.Columns["ItemCode"].Width = 100;
            DataGridStockList.Columns["ItemCode"].DisplayIndex = 2;

            DataGridStockList.Columns["ItemName"].HeaderText = "ItemName";
            DataGridStockList.Columns["ItemName"].Width = 180;
            DataGridStockList.Columns["ItemName"].DisplayIndex = 3;

            DataGridStockList.Columns["PurchaseQuantity"].HeaderText = "PurchaseQuantity";
            DataGridStockList.Columns["PurchaseQuantity"].Width = 80;
            DataGridStockList.Columns["PurchaseQuantity"].DisplayIndex = 4;
            DataGridStockList.Columns["PurchaseQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["SalesQuantity"].HeaderText = "Sales Quantity";
            DataGridStockList.Columns["SalesQuantity"].Width = 70;
            DataGridStockList.Columns["SalesQuantity"].DisplayIndex = 5;
            DataGridStockList.Columns["SalesQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["StockQuantity"].HeaderText = "Stock Quantity";
            DataGridStockList.Columns["StockQuantity"].Width = 70;
            DataGridStockList.Columns["StockQuantity"].DisplayIndex = 6;
            DataGridStockList.Columns["StockQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["PurchasePrice"].HeaderText = "Purchase Price";
            DataGridStockList.Columns["PurchasePrice"].Width = 100;
            DataGridStockList.Columns["PurchasePrice"].DisplayIndex = 7;
            DataGridStockList.Columns["PurchasePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["PurchasePrice"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["TotalPurchasePrice"].HeaderText = "Total Purchase Price";
            DataGridStockList.Columns["TotalPurchasePrice"].Width = 100;
            DataGridStockList.Columns["TotalPurchasePrice"].DisplayIndex = 8;
            DataGridStockList.Columns["TotalPurchasePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["TotalPurchasePrice"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["SalesPrice"].HeaderText = "Sales Price";
            DataGridStockList.Columns["SalesPrice"].Width = 100;
            DataGridStockList.Columns["SalesPrice"].DisplayIndex = 9;
            DataGridStockList.Columns["SalesPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["SalesPrice"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["StockValue"].HeaderText = "Stock Value";
            DataGridStockList.Columns["StockValue"].Width = 100;
            DataGridStockList.Columns["StockValue"].DisplayIndex = 10;
            DataGridStockList.Columns["StockValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockList.Columns["StockValue"].DefaultCellStyle.Format = "0.00";

            DataGridStockList.Columns["PerUnitValue"].HeaderText = "Per Unit Value";
            DataGridStockList.Columns["PerUnitValue"].Width = 100;
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

            StockFilterView filter = new StockFilterView();

            if (!CheckAllTransactions.Checked)
            {
                filter.ItemCode = ComboItemCode.Text;
                filter.DateFrom = MaskDateFrom.Text;
                filter.DateTo = MaskDateTo.Text;
            }

            TxtPurchase.Text = _purchasedItemService.GetPurchasedItemTotalQuantity(filter).ToString();
            TxtSales.Text = _soldItemItemService.GetSoldItemTotalQuantity(filter).ToString();
            TxtTotalStock.Text = (Convert.ToDecimal(TxtPurchase.Text) - Convert.ToDecimal(TxtSales.Text)).ToString();
            TxtTotalValue.Text = (_purchasedItemService.GetPurchasedItemTotalAmount(filter) - _soldItemItemService.GetSoldItemTotalAmount(filter)).ToString();

            var stocks = _stockService.GetStocks(filter).OrderBy(x => x.ItemCode).ThenBy(x => x.Date);

            var stockViewList = CalculateStock(stocks.ToList());

            var bindingList = new BindingList<StockView>(stockViewList);
            var source = new BindingSource(bindingList, null);
            DataGridStockList.DataSource = source;
        }

        private List<StockView> CalculateStock(List<Stock> stocks)
        {
            var stockViewList = new List<StockView>();
            int index = 0;
            var itemCode = string.Empty;
            foreach (var stock in stocks)
            {
                if (string.IsNullOrEmpty(itemCode))
                {
                    itemCode = stock.ItemCode;
                }

                var stockView = new StockView
                {
                    EndOfDate = stock.EndOfDate,
                    Type = stock.Type,
                    ItemCode = stock.ItemCode,
                    ItemName = stock.ItemName,
                    PurchaseQuantity = stock.PurchaseQuantity,
                    SalesQuantity = stock.SalesQuantity,
                    PurchasePrice = stock.PurchasePrice,
                    StockQuantity = stock.StockQuantity,
                    TotalPurchasePrice = stock.TotalPurchasePrice,
                    Date = stock.Date
                };

                if (index == 0 || itemCode != stock.ItemCode)
                {
                    itemCode = stock.ItemCode;

                    stockView.SalesPrice = 0.0m;
                    stockView.StockValue = stock.TotalPurchasePrice;
                    stockView.PerUnitValue = stock.TotalPurchasePrice / stock.PurchaseQuantity;
                }
                else
                {
                    stockView.SalesPrice = stockViewList[index - 1].PerUnitValue;
                    stockView.StockValue = stock.Type.StartsWith("BN") ? (stock.TotalPurchasePrice + stockViewList[index - 1].StockValue) : (stock.StockQuantity * stockViewList[index - 1].PerUnitValue);
                    stockView.PerUnitValue = stock.Type.StartsWith("BN") ? ((stock.TotalPurchasePrice + stockViewList[index - 1].StockValue) / stock.StockQuantity) : stockViewList[index - 1].PerUnitValue;
                }

                stockViewList.Add(stockView);
                index++;
            }

            return stockViewList;
        }

        private void ChangeCheckState(bool option)
        {
            CheckAllTransactions.Checked = option;
        }

        #endregion

    }
}
