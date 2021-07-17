using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ItemListForm : Form
    {
        private readonly IPurchasedItemService _purchaseItemService;
        public IItemListForm _itemListForm;
        public bool _showEmptyItemCode;

        #region Constructor
        public ItemListForm(IPurchasedItemService purchaseItemService,
            IItemListForm itemListForm, bool showEmptyItemCode)
        {
            InitializeComponent();

            _purchaseItemService = purchaseItemService;
            _itemListForm = itemListForm;
            _showEmptyItemCode = showEmptyItemCode;
        }
        #endregion

        #region Form Load Event
        private void ItemListForm_Load(object sender, EventArgs e)
        {
            var purchasedItemViewList = _purchaseItemService.GetPurchasedItemViewList();

            var bindingList = new BindingList<PurchasedItemListView>(purchasedItemViewList.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridItemList.DataSource = source;
        }
        #endregion

        #region Data Grid Event
        private void DataGridItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }

            if (dgv.SelectedRows.Count == 1)
            {
                var selectedRow = dgv.SelectedRows[0];
                long itemId = Convert.ToInt64(selectedRow.Cells["ItemId"].Value.ToString());
                _itemListForm.PopulateItem(itemId);
                this.Close();
            }
        }

        private void DataGridItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridItemList.Columns["ItemId"].Visible = false;

            DataGridItemList.Columns["ItemCode"].HeaderText = "Code";
            DataGridItemList.Columns["ItemCode"].Width = 100;
            DataGridItemList.Columns["ItemCode"].DisplayIndex = 0;

            DataGridItemList.Columns["ItemName"].HeaderText = "Name";
            DataGridItemList.Columns["ItemName"].Width = 250;
            DataGridItemList.Columns["ItemName"].DisplayIndex = 1;

            DataGridItemList.Columns["ItemBrand"].HeaderText = "Brand";
            DataGridItemList.Columns["ItemBrand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridItemList.Columns["ItemBrand"].DisplayIndex = 2;

            foreach (DataGridViewRow row in DataGridItemList.Rows)
            {
                DataGridItemList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridItemList.RowHeadersWidth = 50;
                DataGridItemList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion
    }
}
