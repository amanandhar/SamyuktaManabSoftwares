using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ItemListForm : Form
    {
        private readonly IItemService _itemService;
        public IItemListForm _itemListForm;
        public bool _showEmptyItemCode;

        #region Constructor
        public ItemListForm(IItemService itemService, IItemListForm itemListForm, bool showEmptyItemCode)
        {
            InitializeComponent();

            _itemService = itemService;
            _itemListForm = itemListForm;
            _showEmptyItemCode = showEmptyItemCode;
        }
        #endregion

        #region Form Load Event
        private void ItemListForm_Load(object sender, EventArgs e)
        {
            var items = _itemService.GetItems(_showEmptyItemCode);

            var bindingList = new BindingList<Item>(items.ToList());
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
                long itemId = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                _itemListForm.PopulateItem(itemId);
                this.Close();
            }
        }

        private void DataGridItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridItemList.Columns["Id"].Visible = false;

            DataGridItemList.Columns["Code"].HeaderText = "Code";
            DataGridItemList.Columns["Code"].Width = 100;
            DataGridItemList.Columns["Code"].DisplayIndex = 0;

            DataGridItemList.Columns["Name"].HeaderText = "Name";
            DataGridItemList.Columns["Name"].Width = 250;
            DataGridItemList.Columns["Name"].DisplayIndex = 1;

            DataGridItemList.Columns["Brand"].HeaderText = "Brand";
            DataGridItemList.Columns["Brand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridItemList.Columns["Brand"].DisplayIndex = 2;

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
