﻿using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Entities;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ItemListForm : Form
    {
        private readonly IItemService _itemService;
        private readonly IItemListForm _itemListForm;
        private List<Item> _items = new List<Item>();

        #region Constructor
        public ItemListForm(IItemService itemService,
            IItemListForm itemListForm)
        {
            InitializeComponent();

            _itemService = itemService;
            _itemListForm = itemListForm;
        }
        #endregion

        #region Form Load Event
        private void ItemListForm_Load(object sender, EventArgs e)
        {
            _items = GetItems();
            LoadItems(_items);
            RichSearchItemName.Focus();
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
            DataGridItemList.Columns["Unit"].Visible = false;
            DataGridItemList.Columns["Threshold"].Visible = false;
            DataGridItemList.Columns["AddedDate"].Visible = false;
            DataGridItemList.Columns["UpdatedDate"].Visible = false;

            DataGridItemList.Columns["Code"].HeaderText = "Code";
            DataGridItemList.Columns["Code"].Width = 150;
            DataGridItemList.Columns["Code"].DisplayIndex = 0;

            DataGridItemList.Columns["Name"].HeaderText = "Name";
            DataGridItemList.Columns["Name"].Width = 300;
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

        #region Rich Textbox Event
        private void RichSearchItemName_KeyUp(object sender, KeyEventArgs e)
        {
            SearchItems();
        }

        private void RichSearchItemCode_KeyUp(object sender, KeyEventArgs e)
        {
            SearchItems();
        }
        #endregion

        #region Helper Methods

        private List<Item> GetItems()
        {
            _items = _itemService.GetItems().ToList();
            return _items;
        }

        private void LoadItems(List<Item> items)
        {
            var bindingList = new BindingList<Item>(items);
            var source = new BindingSource(bindingList, null);
            DataGridItemList.DataSource = source;
        }

        private void SearchItems()
        {
            var itemName = RichSearchItemName.Text;
            var itemCode = RichSearchItemCode.Text;

            var items = _items.Where(x => x.Name.ToLower().StartsWith(itemName.ToLower()) && x.Code.ToLower().StartsWith(itemCode.ToLower())).ToList();
            LoadItems(items);
        }

        #endregion
        
    }
}
