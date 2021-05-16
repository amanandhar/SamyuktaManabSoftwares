using GrocerySupplyManagementApp.Entities;
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
        public ItemForm _itemForm;

        public ItemListForm(IItemService itemService, ItemForm itemForm)
        {
            InitializeComponent();

            _itemService = itemService;
            _itemForm = itemForm;
        }

        private void ItemListForm_Load(object sender, EventArgs e)
        {
            var items = _itemService.GetItems();

            var bindingList = new BindingList<Item>(items.ToList());
            var source = new BindingSource(bindingList, null);

            DataGridItemList.AutoGenerateColumns = false;

            //Set Columns Count
            DataGridItemList.ColumnCount = 2;

            //Add Columns
            DataGridItemList.Columns[0].Name = "Name";
            DataGridItemList.Columns[0].HeaderText = "Name";
            DataGridItemList.Columns[0].DataPropertyName = "Name";
            DataGridItemList.Columns[1].Width = 250;

            DataGridItemList.Columns[1].Name = "Brand";
            DataGridItemList.Columns[1].HeaderText = "Brand";
            DataGridItemList.Columns[1].DataPropertyName = "Brand";
            DataGridItemList.Columns[1].Width = 250;

            DataGridItemList.DataSource = source;
        }

        private void DataGridItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                string itemName = dgv.CurrentRow.Cells[0].Value.ToString();
                _itemForm.PopulateItem(itemName);
                this.Close();
            }
        }
    }
}
