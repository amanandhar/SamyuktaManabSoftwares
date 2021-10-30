using GrocerySupplyManagementApp.DTOs;
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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IItemService _itemService;
        private readonly IItemCategoryService _itemCategoryService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;
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
        public ItemForm(string username, ISettingService settingService,
            IItemService itemService, IItemCategoryService itemCategoryService)
        {
            InitializeComponent();

            _settingService = settingService;
            _itemService = itemService;
            _itemCategoryService = itemCategoryService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void AddNewCodeForm_Load(object sender, EventArgs e)
        {
            EnableFields(Action.None);

            LoadItemCategoris();
            LoadItemUnits();
            LoadItems();
        }
        #endregion

        #region Button Event
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ItemListForm itemListForm = new ItemListForm(_itemService, this);
            itemListForm.ShowDialog();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EnableFields(Action.None);
            EnableFields(Action.Add);
            ComboCategory.Select();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateItemInfoOnSave())
                {
                    var item = new Item
                    {
                        EndOfDay = _endOfDay,
                        Code = RichItemCode.Text.Trim(),
                        Name = RichItemName.Text.Trim(),
                        Brand = RichItemBrand.Text.Trim(),
                        Unit = ComboUnit.Text.Trim(),
                        Threshold = Convert.ToDecimal(RichThreshold.Text.Trim()),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _itemService.AddItem(item);

                    var itemCode = item.Code.ToString();
                    var formattedItemCode = itemCode.Substring(1, itemCode.Length - 1);
                    var counter = formattedItemCode.TrimStart(new Char[] { '0' });
                    var itemCategory = new ItemCategory
                    {
                        EndOfDay = _endOfDay,
                        Counter = Convert.ToInt64(counter),
                        Name = ComboCategory.Text.Trim(),
                        ItemCode = RichItemCode.Text.Trim(),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _itemCategoryService.AddItemCategory(itemCategory);

                    DialogResult result = MessageBox.Show(item.Code + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields(Action.None);
                        LoadItems();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields(Action.None);
            EnableFields(Action.Edit);
            RichItemCode.Focus();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateItemInfoOnUpdate())
                {
                    if (selectedItemId != 0)
                    {
                        var item = new Item
                        {
                            Code = RichItemCode.Text.Trim(),
                            Name = RichItemName.Text.Trim(),
                            Brand = RichItemBrand.Text.Trim(),
                            Unit = ComboUnit.Text.Trim(),
                            Threshold = Convert.ToDecimal(RichThreshold.Text.Trim()),
                            UpdatedBy = _username,
                            UpdatedDate = DateTime.Now
                        };

                        _itemService.UpdateItem(selectedItemId, item);
                        DialogResult result = MessageBox.Show(item.Code + " has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
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
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedItemId != 0)
                {
                    DialogResult confirmation = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmation == DialogResult.Yes)
                    {
                        _itemService.DeleteItem(selectedItemId);
                        _itemCategoryService.DeleteItemCategory(RichItemCode.Text.Trim());
                        DialogResult actionResult = MessageBox.Show("Item has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }
        #endregion

        #region Combobox Event
        private void ComboCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxItem selectedCategory = (ComboBoxItem)ComboCategory.SelectedItem;
            var category = selectedCategory?.Value;
            if (!string.IsNullOrWhiteSpace(category))
            {
                var itemCategory = _itemCategoryService.GetItemCategory(category);
                if (itemCategory == null || string.IsNullOrWhiteSpace(itemCategory.ItemCode))
                {
                    RichItemCode.Text = category + "00101";
                }
                else
                {
                    var itemCode = itemCategory.ItemCode;
                    var formattedItemCode = itemCode.Substring(1, itemCode.Length - 1);
                    formattedItemCode = formattedItemCode.TrimStart(new Char[] { '0' });
                    var newItemCode = Convert.ToInt64(formattedItemCode) + 1;
                    var finalItemCode = newItemCode.ToString();

                    if (finalItemCode.Length == 1)
                    {
                        finalItemCode = "0000" + finalItemCode;
                    }
                    else if (finalItemCode.Length == 2)
                    {
                        finalItemCode = "000" + finalItemCode;
                    }
                    else if (finalItemCode.Length == 3)
                    {
                        finalItemCode = "00" + finalItemCode;
                    }
                    else if (finalItemCode.Length == 4)
                    {
                        finalItemCode = "0" + finalItemCode;
                    }

                    RichItemCode.Text = category + finalItemCode;
                }
            }
        }

        private void ComboCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Data Grid Event
        private void DataGridItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridItemList.Columns["Id"].Visible = false;
            DataGridItemList.Columns["EndOfDay"].Visible = false;
            DataGridItemList.Columns["AddedBy"].Visible = false;
            DataGridItemList.Columns["AddedDate"].Visible = false;
            DataGridItemList.Columns["UpdatedBy"].Visible = false;
            DataGridItemList.Columns["UpdatedDate"].Visible = false;

            DataGridItemList.Columns["Code"].HeaderText = "Code";
            DataGridItemList.Columns["Code"].Width = 100;
            DataGridItemList.Columns["Code"].DisplayIndex = 0;

            DataGridItemList.Columns["Name"].HeaderText = "Name";
            DataGridItemList.Columns["Name"].Width = 250;
            DataGridItemList.Columns["Name"].DisplayIndex = 1;

            DataGridItemList.Columns["Brand"].HeaderText = "Brand";
            DataGridItemList.Columns["Brand"].Width = 250;
            DataGridItemList.Columns["Brand"].DisplayIndex = 2;

            DataGridItemList.Columns["Unit"].HeaderText = "Unit";
            DataGridItemList.Columns["Unit"].Width = 80;
            DataGridItemList.Columns["Unit"].DisplayIndex = 3;

            DataGridItemList.Columns["Threshold"].HeaderText = "Threshold";
            DataGridItemList.Columns["Threshold"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridItemList.Columns["Threshold"].DisplayIndex = 4;

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
                BtnEdit.Enabled = true;
            }
            else if (action == Action.Add)
            {
                ComboCategory.Enabled = true;
                RichItemName.Enabled = true;
                RichItemBrand.Enabled = true;
                ComboUnit.Enabled = true;
                RichThreshold.Enabled = true;

                BtnAdd.Enabled = true;
                BtnSave.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                ComboCategory.Enabled = true;
                RichItemName.Enabled = true;
                RichItemBrand.Enabled = true;
                ComboUnit.Enabled = true;
                RichThreshold.Enabled = true;

                BtnUpdate.Enabled = true;
                BtnSave.Enabled = true;
            }
            else
            {
                ComboCategory.Enabled = false;
                RichItemCode.Enabled = false;
                RichItemName.Enabled = false;
                RichItemBrand.Enabled = false;
                ComboUnit.Enabled = false;
                RichThreshold.Enabled = false;

                BtnAdd.Enabled = true;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            ComboCategory.Text = string.Empty;
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
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void LoadItemUnits()
        {
            ComboUnit.Items.Clear();
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

        private void LoadItemCategoris()
        {
            ComboCategory.Items.Clear();
            ComboCategory.ValueMember = "Id";
            ComboCategory.DisplayMember = "Value";

            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_A, Value = Constants.CATEGORY_A });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_B, Value = Constants.CATEGORY_B });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_C, Value = Constants.CATEGORY_C });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_D, Value = Constants.CATEGORY_D });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_E, Value = Constants.CATEGORY_E });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_F, Value = Constants.CATEGORY_F });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_G, Value = Constants.CATEGORY_G });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_H, Value = Constants.CATEGORY_H });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_I, Value = Constants.CATEGORY_I });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_J, Value = Constants.CATEGORY_J });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_K, Value = Constants.CATEGORY_K });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_L, Value = Constants.CATEGORY_L });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_M, Value = Constants.CATEGORY_M });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_N, Value = Constants.CATEGORY_N });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_O, Value = Constants.CATEGORY_O });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_P, Value = Constants.CATEGORY_P });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_Q, Value = Constants.CATEGORY_Q });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_R, Value = Constants.CATEGORY_R });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_S, Value = Constants.CATEGORY_S });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_T, Value = Constants.CATEGORY_T });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_U, Value = Constants.CATEGORY_U });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_V, Value = Constants.CATEGORY_V });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_W, Value = Constants.CATEGORY_W });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_X, Value = Constants.CATEGORY_X });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_Y, Value = Constants.CATEGORY_Y });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_Z, Value = Constants.CATEGORY_Z });
        }
        #endregion

        #region Validation
        private bool ValidateItemInfoOnSave()
        {
            var isValidated = false;

            var category = ComboCategory.Text.Trim();
            var itemCode = RichItemCode.Text.Trim();
            var itemName = RichItemName.Text.Trim();
            var unit = ComboUnit.Text.Trim();
            var threshold = RichThreshold.Text.Trim();
            var itemBrand = RichItemBrand.Text.Trim();

            if (string.IsNullOrWhiteSpace(category)
                || string.IsNullOrWhiteSpace(itemCode)
                || string.IsNullOrWhiteSpace(itemName)
                || string.IsNullOrWhiteSpace(unit)
                || string.IsNullOrWhiteSpace(threshold)
                || string.IsNullOrWhiteSpace(itemBrand))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Category " +
                    "\n * Item Code " +
                    "\n * Item Name " +
                    "\n * Item Unit " +
                    "\n * Item Threshold " +
                    "\n * Item Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }

        private bool ValidateItemInfoOnUpdate()
        {
            var isValidated = false;

            var itemCode = RichItemCode.Text.Trim();
            var itemName = RichItemName.Text.Trim();
            var unit = ComboUnit.Text.Trim();
            var threshold = RichThreshold.Text.Trim();
            var itemBrand = RichItemBrand.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemCode)
                || string.IsNullOrWhiteSpace(itemName)
                || string.IsNullOrWhiteSpace(unit)
                || string.IsNullOrWhiteSpace(threshold)
                || string.IsNullOrWhiteSpace(itemBrand))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Item Code " +
                    "\n * Item Name " +
                    "\n * Item Unit " +
                    "\n * Item Threshold " +
                    "\n * Item Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }
        #endregion
    }
}
