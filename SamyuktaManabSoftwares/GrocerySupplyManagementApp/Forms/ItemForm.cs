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
        private const char ITEM_CATEGORY_SEPARATOR = '.';

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
                        Unit = ComboUnit.Text.Trim(),
                        Threshold = Convert.ToDecimal(RichThreshold.Text.Trim()),
                        DiscountPercent = Convert.ToDecimal(RichDiscountPercent.Text.Trim()),
                        DiscountThreshold = Convert.ToDecimal(RichDiscountThreshold.Text.Trim()),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _itemService.AddItem(item);

                    var itemCode = item.Code.ToString();
                    var formattedItemCode = itemCode.Split(ITEM_CATEGORY_SEPARATOR);
                    var counter = formattedItemCode[1].TrimStart(new Char[] { '0' });
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
                            Unit = ComboUnit.Text.Trim(),
                            Threshold = Convert.ToDecimal(RichThreshold.Text.Trim()),
                            DiscountPercent = Convert.ToDecimal(RichDiscountPercent.Text.Trim()),
                            DiscountThreshold = Convert.ToDecimal(RichDiscountThreshold.Text.Trim()),
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
                if (selectedItemId != 0 && !string.IsNullOrWhiteSpace(RichItemCode.Text.Trim()))
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
                    RichItemCode.Text = category + ITEM_CATEGORY_SEPARATOR + "00101";
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

                    RichItemCode.Text = category + ITEM_CATEGORY_SEPARATOR + finalItemCode;
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
            DataGridItemList.Columns["Name"].Width = 410;
            DataGridItemList.Columns["Name"].DisplayIndex = 1;

            DataGridItemList.Columns["Unit"].HeaderText = "Unit";
            DataGridItemList.Columns["Unit"].Width = 60;
            DataGridItemList.Columns["Unit"].DisplayIndex = 2;

            DataGridItemList.Columns["Threshold"].HeaderText = "Threshold";
            DataGridItemList.Columns["Threshold"].Width = 80;
            DataGridItemList.Columns["Threshold"].DisplayIndex = 4;
            DataGridItemList.Columns["Threshold"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridItemList.Columns["DiscountPercent"].HeaderText = "Dis. %";
            DataGridItemList.Columns["DiscountPercent"].Width = 70;
            DataGridItemList.Columns["DiscountPercent"].DisplayIndex = 5;
            DataGridItemList.Columns["DiscountPercent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridItemList.Columns["DiscountThreshold"].HeaderText = "Dis. Threshold";
            DataGridItemList.Columns["DiscountThreshold"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridItemList.Columns["DiscountThreshold"].DisplayIndex = 6;
            DataGridItemList.Columns["DiscountThreshold"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
            }
            else if (action == Action.Add)
            {
                ComboCategory.Enabled = true;
                RichItemName.Enabled = true;
                ComboUnit.Enabled = true;
                RichThreshold.Enabled = true;
                RichDiscountPercent.Enabled = true;
                RichDiscountThreshold.Enabled = true;

                BtnAdd.Enabled = true;
                BtnSave.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                ComboCategory.Enabled = true;
                RichItemName.Enabled = true;
                ComboUnit.Enabled = true;
                RichThreshold.Enabled = true;
                RichDiscountPercent.Enabled = true;
                RichDiscountThreshold.Enabled = true;

                BtnUpdate.Enabled = true;
                BtnSave.Enabled = true;
            }
            else
            {
                ComboCategory.Enabled = false;
                RichItemCode.Enabled = false;
                RichItemName.Enabled = false;
                ComboUnit.Enabled = false;
                RichThreshold.Enabled = false;
                RichDiscountPercent.Enabled = false;
                RichDiscountThreshold.Enabled = false;

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
            ComboUnit.Text = string.Empty;
            RichThreshold.Clear();
            RichDiscountPercent.Clear();
            RichDiscountThreshold.Clear();
        }

        public void PopulateItem(long itemId)
        {
            try
            {
                var item = _itemService.GetItem(itemId);
                selectedItemId = itemId;
                RichItemCode.Text = item.Code;
                RichItemName.Text = item.Name;
                ComboUnit.Text = item.Unit;
                RichThreshold.Text = item.Threshold.ToString();
                RichDiscountPercent.Text = item.DiscountPercent.ToString();
                RichDiscountThreshold.Text = item.DiscountThreshold.ToString();

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

            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_10, Value = Constants.CATEGORY_10 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_11, Value = Constants.CATEGORY_11 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_12, Value = Constants.CATEGORY_12 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_13, Value = Constants.CATEGORY_13 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_14, Value = Constants.CATEGORY_14 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_15, Value = Constants.CATEGORY_15 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_16, Value = Constants.CATEGORY_16 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_17, Value = Constants.CATEGORY_17 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_18, Value = Constants.CATEGORY_18 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_19, Value = Constants.CATEGORY_19 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_20, Value = Constants.CATEGORY_20 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_21, Value = Constants.CATEGORY_21 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_22, Value = Constants.CATEGORY_22 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_23, Value = Constants.CATEGORY_23 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_24, Value = Constants.CATEGORY_24 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_25, Value = Constants.CATEGORY_25 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_26, Value = Constants.CATEGORY_26 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_27, Value = Constants.CATEGORY_27 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_28, Value = Constants.CATEGORY_28 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_29, Value = Constants.CATEGORY_29 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_30, Value = Constants.CATEGORY_30 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_31, Value = Constants.CATEGORY_31 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_32, Value = Constants.CATEGORY_32 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_33, Value = Constants.CATEGORY_33 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_34, Value = Constants.CATEGORY_34 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_35, Value = Constants.CATEGORY_35 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_36, Value = Constants.CATEGORY_36 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_37, Value = Constants.CATEGORY_37 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_38, Value = Constants.CATEGORY_38 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_39, Value = Constants.CATEGORY_39 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_40, Value = Constants.CATEGORY_40 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_41, Value = Constants.CATEGORY_41 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_42, Value = Constants.CATEGORY_42 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_43, Value = Constants.CATEGORY_43 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_44, Value = Constants.CATEGORY_44 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_45, Value = Constants.CATEGORY_45 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_46, Value = Constants.CATEGORY_46 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_47, Value = Constants.CATEGORY_47 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_48, Value = Constants.CATEGORY_48 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_49, Value = Constants.CATEGORY_49 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_50, Value = Constants.CATEGORY_50 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_51, Value = Constants.CATEGORY_51 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_52, Value = Constants.CATEGORY_52 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_53, Value = Constants.CATEGORY_53 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_54, Value = Constants.CATEGORY_54 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_55, Value = Constants.CATEGORY_55 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_56, Value = Constants.CATEGORY_56 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_57, Value = Constants.CATEGORY_57 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_58, Value = Constants.CATEGORY_58 });
            ComboCategory.Items.Add(new ComboBoxItem { Id = Constants.CATEGORY_59, Value = Constants.CATEGORY_59 });
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
            var discountPercent = RichDiscountPercent.Text.Trim();
            var discountThreshold = RichDiscountThreshold.Text.Trim();

            if (string.IsNullOrWhiteSpace(category)
                || string.IsNullOrWhiteSpace(itemCode)
                || string.IsNullOrWhiteSpace(itemName)
                || string.IsNullOrWhiteSpace(unit)
                || string.IsNullOrWhiteSpace(threshold)
                || string.IsNullOrWhiteSpace(discountPercent)
                || string.IsNullOrWhiteSpace(discountThreshold))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Category " +
                    "\n * Item Code " +
                    "\n * Item Name " +
                    "\n * Item Unit " +
                    "\n * Item Threshold " +
                    "\n * Discount Percent " +
                    "\n * Discount Threshold ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            var discountPercent = RichDiscountPercent.Text.Trim();
            var discountThreshold = RichDiscountThreshold.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemCode)
                || string.IsNullOrWhiteSpace(itemName)
                || string.IsNullOrWhiteSpace(unit)
                || string.IsNullOrWhiteSpace(threshold)
                || string.IsNullOrWhiteSpace(discountPercent)
                || string.IsNullOrWhiteSpace(discountThreshold))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Item Code " +
                    "\n * Item Name " +
                    "\n * Item Unit " +
                    "\n * Item Threshold " +
                    "\n * Discount Percent " +
                    "\n * Discount Threshold ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
