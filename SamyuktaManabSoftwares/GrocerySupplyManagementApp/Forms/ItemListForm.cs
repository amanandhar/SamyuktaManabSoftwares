using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services;
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

        public ItemListForm(IItemService itemService, IItemListForm itemListForm, bool showEmptyItemCode)
        {
            InitializeComponent();

            _itemService = itemService;
            _itemListForm = itemListForm;
            _showEmptyItemCode = showEmptyItemCode;
        }

        private void ItemListForm_Load(object sender, EventArgs e)
        {
            var items = _itemService.GetItems(_showEmptyItemCode);

            var bindingList = new BindingList<Item>(items.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridItemList.DataSource = source;
        }

        private void DataGridItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }
                
            if (dgv.CurrentRow.Selected)
            {
                long itemId = Convert.ToInt64(dgv.CurrentRow.Cells["Id"].Value.ToString());
                _itemListForm.PopulateItem(itemId);
                this.Close();
            }
        }

        private void DataGridItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Set Columns Count
            DataGridItemList.Columns["Id"].Visible = false;

            //Add Columns
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
            }
        }
    }
}
