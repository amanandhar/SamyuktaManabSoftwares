﻿using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ItemForm : Form, IItemListForm
    {
        private readonly IItemService _itemService;
        private long selectedItemId = 0;

        #region Enum
        enum Action
        {
            None = 0,
            Show,
            Add,
            Save,
            Edit,
            Update
        }
        #endregion

        #region Constructor
        public ItemForm(IItemService itemService)
        {
            InitializeComponent();

            _itemService = itemService;
        }
        #endregion

        #region Form Load Event
        private void AddNewCodeForm_Load(object sender, EventArgs e)
        {
            EnableFields(Action.None);
            LoadItems();
            LoadItemUnits();
        }
        #endregion

        #region Button Event
        private void BtnShowCode_Click(object sender, EventArgs e)
        {
            ItemListForm itemListForm = new ItemListForm(_itemService, this);
            itemListForm.ShowDialog();
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            EnableFields(Action.Add);
            RichItemCode.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var currentDate = DateTime.Now;
                var item = new Item
                {
                    Code = RichItemCode.Text,
                    Name = RichItemName.Text,
                    Brand = RichItemBrand.Text,
                    Unit = ComboUnit.Text,
                    Threshold = Convert.ToInt32(RichThreshold.Text),
                    AddedDate = currentDate,
                    UpdatedDate = currentDate
                };

                _itemService.AddItem(item);
                DialogResult result = MessageBox.Show(item.Code + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields(Action.None);
                    LoadItems();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields(Action.Edit);
            RichItemCode.Focus();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedItemId != 0)
                {
                    var item = new Item
                    {
                        Code = RichItemCode.Text,
                        Name = RichItemName.Text,
                        Brand = RichItemBrand.Text,
                        Unit = ComboUnit.Text,
                        Threshold = Convert.ToInt32(RichThreshold.Text),
                        UpdatedDate = DateTime.Now
                    };

                    _itemService.UpdateItem(selectedItemId, item);
                    DialogResult result = MessageBox.Show(item.Code + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields(Action.None);
                        LoadItems();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedItemId != 0)
                {
                    DialogResult questionResult = MessageBox.Show("Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (questionResult == DialogResult.Yes)
                    {
                        _itemService.DeleteItem(selectedItemId);
                        DialogResult actionResult = MessageBox.Show("Item has been deleted successfully.", "Message", MessageBoxButtons.OK);
                        if (actionResult == DialogResult.OK)
                        {
                            ClearAllFields();
                            EnableFields(Action.None);
                            LoadItems();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Data Grid Event
        private void DataGridItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridItemList.Columns["Id"].Visible = false;
            DataGridItemList.Columns["Unit"].Visible = false;
            DataGridItemList.Columns["Threshold"].Visible = false;
            DataGridItemList.Columns["AddedDate"].Visible = false;
            DataGridItemList.Columns["UpdatedDate"].Visible = false;

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

        #region Helper Methods
        private void LoadItems()
        {
            List<Item> items = _itemService.GetItems().ToList();
            var bindingList = new BindingList<Item>(items);
            var source = new BindingSource(bindingList, null);
            DataGridItemList.DataSource = source;
        }

        private void EnableFields(Action action)
        {
            if (action == Action.Show)
            {
                RichItemCode.Enabled = false;
                RichItemName.Enabled = false;
                RichItemBrand.Enabled = false;
                ComboUnit.Enabled = false;
                RichThreshold.Enabled = false;
                BtnAddNew.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = true;
                BtnUpdate.Enabled = false;
            }
            else if (action == Action.Add)
            {
                RichItemCode.Enabled = true;
                RichItemName.Enabled = true;
                RichItemBrand.Enabled = true;
                ComboUnit.Enabled = true;
                RichThreshold.Enabled = true;
                BtnAddNew.Enabled = true;
                BtnSave.Enabled = true;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
            }
            else if (action == Action.Edit)
            {
                RichItemCode.Enabled = true;
                RichItemName.Enabled = true;
                RichItemBrand.Enabled = true;
                ComboUnit.Enabled = true;
                RichThreshold.Enabled = true;
                BtnAddNew.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = true;
                BtnUpdate.Enabled = true;
            }
            else
            {
                RichItemCode.Enabled = false;
                RichItemName.Enabled = false;
                RichItemBrand.Enabled = false;
                ComboUnit.Enabled = false;
                RichThreshold.Enabled = false;
                BtnAddNew.Enabled = true;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            RichItemCode.Clear();
            RichItemName.Clear();
            RichItemBrand.Clear();
            ComboUnit.Text = string.Empty;
            RichThreshold.Clear();
        }

        public void PopulateItem(long itemId)
        {
            try
            {
                var item = _itemService.GetItem(itemId);
                selectedItemId = itemId;
                RichItemCode.Text = item.Code;
                RichItemName.Text = item.Name;
                RichItemBrand.Text = item.Brand;
                ComboUnit.Text = item.Unit;
                RichThreshold.Text = item.Threshold.ToString();

                EnableFields(Action.Show);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadItemUnits()
        {
            ComboUnit.ValueMember = "Id";
            ComboUnit.DisplayMember = "Value";

            ComboUnit.Items.Add(new ComboBoxItem { Id = Constants.KILOGRAM, Value = Constants.KILOGRAM });
            ComboUnit.Items.Add(new ComboBoxItem { Id = Constants.GRAM, Value = Constants.GRAM });
            ComboUnit.Items.Add(new ComboBoxItem { Id = Constants.LITER, Value = Constants.LITER });
            ComboUnit.Items.Add(new ComboBoxItem { Id = Constants.MILLI_LITER, Value = Constants.MILLI_LITER });
            ComboUnit.Items.Add(new ComboBoxItem { Id = Constants.PIECES, Value = Constants.PIECES });
            ComboUnit.Items.Add(new ComboBoxItem { Id = Constants.PACKET, Value = Constants.PACKET });
            ComboUnit.Items.Add(new ComboBoxItem { Id = Constants.BAG, Value = Constants.BAG });
            ComboUnit.Items.Add(new ComboBoxItem { Id = Constants.BOTTLE, Value = Constants.BOTTLE });
            ComboUnit.Items.Add(new ComboBoxItem { Id = Constants.CAN, Value = Constants.CAN });
            ComboUnit.Items.Add(new ComboBoxItem { Id = Constants.DOZEN, Value = Constants.DOZEN });
        }
        #endregion

       
    }
}
