using GrocerySupplyManagementApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class StockForm : Form
    {
        private readonly IItemService _itemService;
        public StockForm(IItemService itemService)
        {
            InitializeComponent();

            _itemService = itemService;
        }

        #region Form Load Events
        private void StockForm_Load(object sender, EventArgs e)
        {
            _itemService.GetAllItemNames().ToList().ForEach(item =>
            {
                ComboFilter.Items.Add(item);
            });
        }

        #endregion

        #region Button Events
        private void BtnShow_Click(object sender, EventArgs e)
        {
            var filter = new DTOs.StockFilter
            {
                ItemName = ComboFilter.Text,
                DateFrom = MaskTextBoxDateFrom.Text,
                DateTo = MaskTextBoxDateTo.Text
            };

            TextBoxTotalStock.Text = _itemService.GetTotalItemCount(filter).ToString();
            
            List<Entities.Item> items = _itemService.GetItems(filter).ToList();

            var bindingList = new BindingList<Entities.Item>(items);
            var source = new BindingSource(bindingList, null);
            DataGridStockList.DataSource = source;
        }


        #endregion

        #region Helper Methods
        private void DataGridStockList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridStockList.Columns["SupplierName"].Visible = false;

            DataGridStockList.Columns["Code"].HeaderText = "Code";
            DataGridStockList.Columns["Code"].Width = 100;
            DataGridStockList.Columns["Code"].DisplayIndex = 0;

            DataGridStockList.Columns["Name"].HeaderText = "Name";
            DataGridStockList.Columns["Name"].Width = 250;
            DataGridStockList.Columns["Name"].DisplayIndex = 1;

            DataGridStockList.Columns["Brand"].HeaderText = "Brand";
            DataGridStockList.Columns["Brand"].Width = 250;
            DataGridStockList.Columns["Brand"].DisplayIndex = 2;

            DataGridStockList.Columns["Unit"].HeaderText = "Unit";
            DataGridStockList.Columns["Unit"].Width = 100;
            DataGridStockList.Columns["Unit"].DisplayIndex = 3;

            DataGridStockList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridStockList.Columns["Quantity"].Width = 100;
            DataGridStockList.Columns["Quantity"].DisplayIndex = 4;

            DataGridStockList.Columns["PurchasePrice"].Visible = false;

            DataGridStockList.Columns["PurchaseDate"].Visible = false;

            DataGridStockList.Columns["BillNo"].Visible = false;

            DataGridStockList.Columns["SellPrice"].HeaderText = "SellPrice";
            //DataGridStockList.Columns["SellPrice"].Width = 100;
            DataGridStockList.Columns["SellPrice"].DisplayIndex = 5;
            DataGridStockList.Columns["SellPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            foreach (DataGridViewRow row in DataGridStockList.Rows)
            {
                DataGridStockList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridStockList.RowHeadersWidth = 50;
            }
        }

        #endregion
    }
}
