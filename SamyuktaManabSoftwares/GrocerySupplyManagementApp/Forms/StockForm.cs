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
        private readonly IItemTransactionService _itemTransactionService;
        public StockForm(IItemService itemService, IItemTransactionService itemTransactionService)
        {
            InitializeComponent();

            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
        }

        #region Form Load Events
        private void StockForm_Load(object sender, EventArgs e)
        {
            _itemTransactionService.GetAllItemNames().ToList().ForEach(item =>
            {
                ComboFilter.Items.Add(item);
            });
        }

        #endregion

        #region Button Events
        private void BtnShow_Click(object sender, EventArgs e)
        {
            LoadItems();
        }


        #endregion

        #region Helper Methods

        private void LoadItems()
        {
            DTOs.StockFilterView filter = new DTOs.StockFilterView();

            if (!CheckBoxAllStock.Checked)
            {
                filter.ItemName = ComboFilter.Text;
                filter.DateFrom = MaskTextBoxDateFrom.Text;
                filter.DateTo = MaskTextBoxDateTo.Text;
            }

            TextBoxTotalStock.Text = _itemTransactionService.GetTotalItemCount(filter).ToString();

            List<Entities.ItemTransactionGrid> items = _itemTransactionService.GetItems(filter).ToList();

            var bindingList = new BindingList<Entities.ItemTransactionGrid>(items);
            var source = new BindingSource(bindingList, null);
            DataGridStockList.DataSource = source;
        }

        private void DataGridStockList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridStockList.Columns["SupplierName"].Visible = false;

            DataGridStockList.Columns["Code"].HeaderText = "Code";
            DataGridStockList.Columns["Code"].Width = 100;
            DataGridStockList.Columns["Code"].DisplayIndex = 0;

            DataGridStockList.Columns["Name"].HeaderText = "Name";
            DataGridStockList.Columns["Name"].Width = 300;
            DataGridStockList.Columns["Name"].DisplayIndex = 1;

            DataGridStockList.Columns["Brand"].HeaderText = "Brand";
            DataGridStockList.Columns["Brand"].Width = 300;
            DataGridStockList.Columns["Brand"].DisplayIndex = 2;

            DataGridStockList.Columns["Unit"].HeaderText = "Unit";
            DataGridStockList.Columns["Unit"].Width = 100;
            DataGridStockList.Columns["Unit"].DisplayIndex = 3;

            DataGridStockList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridStockList.Columns["Quantity"].DisplayIndex = 4;
            DataGridStockList.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridStockList.Columns["PurchasePrice"].Visible = false;
            DataGridStockList.Columns["PurchaseDate"].Visible = false;
            DataGridStockList.Columns["BillNo"].Visible = false;
            DataGridStockList.Columns["SellPrice"].Visible = false;

            foreach (DataGridViewRow row in DataGridStockList.Rows)
            {
                DataGridStockList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridStockList.RowHeadersWidth = 50;
            }
        }

        #endregion

        #region Checkbox Events
        private void CheckBoxAllStock_CheckedChanged(object sender, EventArgs e)
        {
            ComboFilter.Text = string.Empty;
        }
        #endregion

        #region Combobox Events
        private void ComboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxAllStock.Checked = false;
        }
        #endregion

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var name = DataGridStockList.SelectedCells[2].Value.ToString();
                var brand = DataGridStockList.SelectedCells[3].Value.ToString();
                _itemTransactionService.DeleteItem(name, brand);

                DialogResult result = MessageBox.Show("Item with name: " + name + " and brand: " + brand + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    LoadItems();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
