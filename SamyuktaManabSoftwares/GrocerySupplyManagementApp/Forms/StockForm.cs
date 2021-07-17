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
        private readonly IItemTransactionService _itemTransactionService;

        #region Constructor
        public StockForm(IItemTransactionService itemTransactionService)
        {
            InitializeComponent();

            _itemTransactionService = itemTransactionService;
        }
        #endregion

        #region Form Load Event
        private void StockForm_Load(object sender, EventArgs e)
        {

            _itemTransactionService.GetAllItemCodes().ToList().ForEach(code =>
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region DataGrid Event

        private void DataGridStockList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridStockList.Columns["Date"].Visible = false;

            DataGridStockList.Columns["EndOfDate"].HeaderText = "Date";
            DataGridStockList.Columns["EndOfDate"].Width = 80;
            DataGridStockList.Columns["EndOfDate"].DisplayIndex = 0;
            DataGridStockList.Columns["EndOfDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

            DataGridStockList.Columns["BillInvoiceNo"].HeaderText = "Bill/Invoice No";
            DataGridStockList.Columns["BillInvoiceNo"].Width = 100;
            DataGridStockList.Columns["BillInvoiceNo"].DisplayIndex = 1;

            DataGridStockList.Columns["Description"].HeaderText = "Description";
            DataGridStockList.Columns["Description"].Width = 100;
            DataGridStockList.Columns["Description"].DisplayIndex = 2;

            DataGridStockList.Columns["ItemCode"].HeaderText = "Code";
            DataGridStockList.Columns["ItemCode"].Width = 100;
            DataGridStockList.Columns["ItemCode"].DisplayIndex = 3;

            DataGridStockList.Columns["ItemName"].HeaderText = "Name";
            DataGridStockList.Columns["ItemName"].Width = 100;
            DataGridStockList.Columns["ItemName"].DisplayIndex = 4;

            DataGridStockList.Columns["ItemBrand"].HeaderText = "Brand";
            DataGridStockList.Columns["ItemBrand"].Width = 100;
            DataGridStockList.Columns["ItemBrand"].DisplayIndex = 5;

            DataGridStockList.Columns["PurchaseQuantity"].HeaderText = "Purchase Quantity";
            DataGridStockList.Columns["PurchaseQuantity"].Width = 100;
            DataGridStockList.Columns["PurchaseQuantity"].DisplayIndex = 6;
            DataGridStockList.Columns["PurchaseQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["PurchasePrice"].HeaderText = "Purchase Price";
            DataGridStockList.Columns["PurchasePrice"].Width = 100;
            DataGridStockList.Columns["PurchasePrice"].DisplayIndex = 7;
            DataGridStockList.Columns["PurchasePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["PurchaseTotal"].HeaderText = "Purchase Total";
            DataGridStockList.Columns["PurchaseTotal"].Width = 100;
            DataGridStockList.Columns["PurchaseTotal"].DisplayIndex = 8;
            DataGridStockList.Columns["PurchaseTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["PurchaseGrandTotal"].HeaderText = "Purchase Grand Total";
            DataGridStockList.Columns["PurchaseGrandTotal"].Width = 100;
            DataGridStockList.Columns["PurchaseGrandTotal"].DisplayIndex = 9;
            DataGridStockList.Columns["PurchaseGrandTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["SalesQuantity"].HeaderText = "Sales Quantity";
            DataGridStockList.Columns["SalesQuantity"].Width = 100;
            DataGridStockList.Columns["SalesQuantity"].DisplayIndex = 10;
            DataGridStockList.Columns["SalesQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["SalesPrice"].HeaderText = "Sales Price";
            DataGridStockList.Columns["SalesPrice"].Width = 100;
            DataGridStockList.Columns["SalesPrice"].DisplayIndex = 11;
            DataGridStockList.Columns["SalesPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["SalesTotal"].HeaderText = "Sales Total";
            DataGridStockList.Columns["SalesTotal"].Width = 100;
            DataGridStockList.Columns["SalesTotal"].DisplayIndex = 12;
            DataGridStockList.Columns["SalesTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["SalesGrandTotal"].HeaderText = "Sales Grand Total";
            DataGridStockList.Columns["SalesGrandTotal"].Width = 100;
            DataGridStockList.Columns["SalesGrandTotal"].DisplayIndex = 13;
            DataGridStockList.Columns["SalesGrandTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["BalanceQuantity"].HeaderText = "Balance Quantity";
            DataGridStockList.Columns["BalanceQuantity"].Width = 100;
            DataGridStockList.Columns["BalanceQuantity"].DisplayIndex = 14;
            DataGridStockList.Columns["BalanceQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["TotalStockValue"].HeaderText = "Total Stock Value";
            DataGridStockList.Columns["TotalStockValue"].Width = 100;
            DataGridStockList.Columns["TotalStockValue"].DisplayIndex = 15;
            DataGridStockList.Columns["TotalStockValue"].DefaultCellStyle.Format = "0.00";
            DataGridStockList.Columns["TotalStockValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockList.Columns["PerUnitValue"].HeaderText = "Per Unit Value";
            DataGridStockList.Columns["PerUnitValue"].Width = 100;
            DataGridStockList.Columns["PerUnitValue"].DisplayIndex = 16;
            DataGridStockList.Columns["PerUnitValue"].DefaultCellStyle.Format = "0.00";
            DataGridStockList.Columns["PerUnitValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

            TxtPurchase.Text = _itemTransactionService.GetTotalPurchaseItemCount(filter).ToString();
            TxtSales.Text = _itemTransactionService.GetTotalSalesItemCount(filter).ToString();
            TxtTotalStock.Text = (Convert.ToDecimal(TxtPurchase.Text) - Convert.ToDecimal(TxtSales.Text)).ToString();
            TxtTotalValue.Text = (_itemTransactionService.GetTotalPurchaseItemAmount(filter) - _itemTransactionService.GetTotalSalesItemAmount(filter)).ToString();

            List<StockView> items = _itemTransactionService.GetStockView(filter).ToList();

            var bindingList = new BindingList<StockView>(items);
            var source = new BindingSource(bindingList, null);
            DataGridStockList.DataSource = source;
        }

        private void ChangeCheckState(bool option)
        {
            CheckAllTransactions.Checked = option;
        }

        #endregion

    }
}
