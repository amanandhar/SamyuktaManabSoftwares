using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class StockAdjustmentForm : Form, IPricedItemListForm
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IItemService _itemService;
        private readonly IPricedItemService _pricedItemService;
        private readonly IStockService _stockService;
        private readonly IStockAdjustmentService _stockAdjustmentService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Enum
        private enum Action
        {
            Clear,
            Edit,
            Save,
            PopulateItem,
            Load,
            None
        }
        #endregion

        #region Constructor
        public StockAdjustmentForm(string username, ISettingService settingService,
            IItemService itemService, IPricedItemService pricedItemService,
            IStockService stockService, IStockAdjustmentService stockAdjustmentService)
        {
            InitializeComponent();

            _settingService = settingService;
            _itemService = itemService;
            _pricedItemService = pricedItemService;
            _stockService = stockService;
            _stockAdjustmentService = stockAdjustmentService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void StockAdjustmentForm_Load(object sender, EventArgs e)
        {
            LoadStockActions();
            LoadStockAdjustments();
            EnableFields();
            EnableFields(Action.Load);
        }
        #endregion

        #region Combo Box Event
        private void ComboAction_SelectedValueChanged(object sender, EventArgs e)
        {
            TxtBoxItemQuantity.Focus();
        }

        private void ComboAction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Button Event
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PricedItemListForm pricedItemListForm = new PricedItemListForm(_pricedItemService, this);
            pricedItemListForm.ShowDialog();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Edit);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridStockAdjustmentList.SelectedCells.Count == 1
                    || DataGridStockAdjustmentList.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow;
                    if (DataGridStockAdjustmentList.SelectedCells.Count == 1)
                    {
                        var selectedCell = DataGridStockAdjustmentList.SelectedCells[0];
                        selectedRow = DataGridStockAdjustmentList.Rows[selectedCell.RowIndex];
                    }
                    else
                    {
                        selectedRow = DataGridStockAdjustmentList.SelectedRows[0];
                    }

                    string selectedId = selectedRow?.Cells["Id"]?.Value?.ToString();
                    string selectedIncomeExpenseId = selectedRow?.Cells["IncomeExpenseId"]?.Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(selectedId) && !string.IsNullOrWhiteSpace(selectedIncomeExpenseId))
                    {
                        DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (deleteResult == DialogResult.Yes)
                        {
                            var id = Convert.ToInt64(selectedId);
                            var incomeExpenseId = Convert.ToInt64(selectedIncomeExpenseId);
                            _stockAdjustmentService.DeleteStockAdjustment(id, incomeExpenseId);
                            LoadStockAdjustments();
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateStockAdjustmentInfo())
                {
                    var stockAdjustmentType = ComboAction.Text.Trim();
                    IncomeExpense incomeExpense;
                    if (stockAdjustmentType == Constants.DEDUCT)
                    {
                        incomeExpense = new IncomeExpense
                        {
                            EndOfDay = _endOfDay,
                            Action = Constants.EXPENSE,
                            ActionType = Constants.DEDUCT,
                            Type = Constants.STOCK_ADJUSTMENT,
                            Narration = TxtBoxNarration.Text.Trim(),
                            PaymentAmount = Math.Round(Convert.ToDecimal(TxtBoxItemPrice.Text.Trim()) * Convert.ToDecimal(TxtBoxItemQuantity.Text.Trim()), 2),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };
                    }
                    else
                    {
                        incomeExpense = new IncomeExpense
                        {
                            EndOfDay = _endOfDay,
                            Action = Constants.INCOME,
                            ActionType = Constants.ADD,
                            Type = Constants.STOCK_ADJUSTMENT,
                            Narration = TxtBoxNarration.Text.Trim(),
                            ReceivedAmount = Math.Round(Convert.ToDecimal(TxtBoxItemPrice.Text.Trim()) * Convert.ToDecimal(TxtBoxItemQuantity.Text.Trim()), 2),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };
                    }

                    var incomeExpenseType = stockAdjustmentType == Constants.DEDUCT ? Constants.EXPENSE : Constants.INCOME;
                    var stockAdjustment = new StockAdjustment
                    {
                        EndOfDay = _endOfDay,
                        ItemId = _itemService.GetItem(TxtBoxItemCode.Text.Trim()).Id,
                        Unit = TxtBoxItemUnit.Text.Trim(),
                        Action = ComboAction.Text.Trim(),
                        Quantity = string.IsNullOrWhiteSpace(TxtBoxItemQuantity.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtBoxItemQuantity.Text),
                        Price = string.IsNullOrWhiteSpace(TxtBoxItemPrice.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtBoxItemPrice.Text),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _stockAdjustmentService.AddStockAdjustment(stockAdjustment, incomeExpense, incomeExpenseType, _username);

                    DialogResult result = MessageBox.Show("Stock adjustment done successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields(Action.None);
                        EnableFields(Action.Save);
                        LoadStockAdjustments();
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

        #region Text Box Event
        private void TxtBoxItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Grid Event
        private void DataGridStockAdjustmentList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridStockAdjustmentList.Columns["Id"].Visible = false;
            DataGridStockAdjustmentList.Columns["IncomeExpenseId"].Visible = false;

            DataGridStockAdjustmentList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridStockAdjustmentList.Columns["EndOfDay"].Width = 75;
            DataGridStockAdjustmentList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridStockAdjustmentList.Columns["Action"].HeaderText = "Description";
            DataGridStockAdjustmentList.Columns["Action"].Width = 120;
            DataGridStockAdjustmentList.Columns["Action"].DisplayIndex = 1;

            DataGridStockAdjustmentList.Columns["Narration"].HeaderText = "Narration";
            DataGridStockAdjustmentList.Columns["Narration"].Width = 230;
            DataGridStockAdjustmentList.Columns["Narration"].DisplayIndex = 2;

            DataGridStockAdjustmentList.Columns["ItemCode"].HeaderText = "Item Code";
            DataGridStockAdjustmentList.Columns["ItemCode"].Width = 120;
            DataGridStockAdjustmentList.Columns["ItemCode"].DisplayIndex = 3;

            DataGridStockAdjustmentList.Columns["ItemName"].HeaderText = "Item Name";
            DataGridStockAdjustmentList.Columns["ItemName"].Width = 230;
            DataGridStockAdjustmentList.Columns["ItemName"].DisplayIndex = 4;

            DataGridStockAdjustmentList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridStockAdjustmentList.Columns["Quantity"].Width = 100;
            DataGridStockAdjustmentList.Columns["Quantity"].DisplayIndex = 5;
            DataGridStockAdjustmentList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridStockAdjustmentList.Columns["Price"].HeaderText = "Price";
            DataGridStockAdjustmentList.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridStockAdjustmentList.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridStockAdjustmentList.Columns["Price"].DefaultCellStyle.Format = "0.00";

            foreach (DataGridViewRow row in DataGridStockAdjustmentList.Rows)
            {
                DataGridStockAdjustmentList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridStockAdjustmentList.RowHeadersWidth = 50;
                DataGridStockAdjustmentList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadStockAdjustments()
        {
            var stockAdjustmentViewList = _stockAdjustmentService.GetStockAdjustmentViewList().ToList();
            var bindingList = new BindingList<StockAdjustmentView>(stockAdjustmentViewList);
            var source = new BindingSource(bindingList, null);
            DataGridStockAdjustmentList.DataSource = source;
        }

        public void PopulatePricedItem(long pricedId)
        {
            try
            {
                var pricedItem = _pricedItemService.GetPricedItem(pricedId);
                var item = _itemService.GetItem(pricedItem.ItemId);

                var stockFilter = new StockFilter()
                {
                    ItemCode = item.Code
                };
                var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var perUnitValue = _stockService.GetPerUnitValue(stocks.ToList(), stockFilter);

                TxtBoxItemCode.Text = item.Code;
                TxtBoxItemName.Text = item.Name;
                TxtBoxItemUnit.Text = item.Unit;
                TxtBoxItemPrice.Text = perUnitValue.ToString();

                EnableFields();
                EnableFields(Action.PopulateItem);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void ClearAllFields()
        {
            TxtBoxItemCode.Clear();
            TxtBoxItemName.Clear();
            TxtBoxItemUnit.Clear();
            TxtBoxItemPrice.Clear();
            ComboAction.Text = string.Empty;
            TxtBoxItemQuantity.Clear();
            TxtBoxNarration.Clear();
        }

        private void LoadStockActions()
        {
            ComboAction.Items.Clear();
            ComboAction.ValueMember = "Id";
            ComboAction.DisplayMember = "Value";

            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.ADD, Value = Constants.ADD });
            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.DEDUCT, Value = Constants.DEDUCT });
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Load)
            {
                BtnEdit.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                ComboAction.Enabled = true;
                TxtBoxItemQuantity.Enabled = true;

                BtnSearch.Enabled = true;
            }
            else if (action == Action.PopulateItem)
            {
                ComboAction.Enabled = true;
                TxtBoxItemQuantity.Enabled = true;
                TxtBoxNarration.Enabled = true;

                BtnSearch.Enabled = true;
                BtnClear.Enabled = true;
                BtnSave.Enabled = true;
            }
            else if (action == Action.Save)
            {
                BtnEdit.Enabled = true;
            }
            else
            {
                TxtBoxItemCode.Enabled = false;
                TxtBoxItemName.Enabled = false;
                TxtBoxItemUnit.Enabled = false;
                TxtBoxItemPrice.Enabled = false;
                ComboAction.Enabled = false;
                TxtBoxItemQuantity.Enabled = false;
                TxtBoxNarration.Enabled = false;

                BtnSearch.Enabled = false;
                BtnClear.Enabled = false;
                BtnEdit.Enabled = false;
                BtnSave.Enabled = false;
            }
        }

        #endregion

        #region Validation
        private bool ValidateStockAdjustmentInfo()
        {
            var isValidated = false;

            var itemCode = TxtBoxItemCode.Text.Trim();
            var itemName = TxtBoxItemName.Text.Trim();
            var itemPrice = TxtBoxItemPrice.Text.Trim();
            var itemUnit = TxtBoxItemUnit.Text.Trim();
            var stockAction = ComboAction.Text.Trim();
            var itemQuantity = TxtBoxItemQuantity.Text.Trim();
            var narration = TxtBoxNarration.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemCode)
                || string.IsNullOrWhiteSpace(itemName)
                || string.IsNullOrWhiteSpace(itemPrice)
                || string.IsNullOrWhiteSpace(itemUnit)
                || string.IsNullOrWhiteSpace(stockAction)
                || string.IsNullOrWhiteSpace(itemQuantity)
                || string.IsNullOrWhiteSpace(narration))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Item Code " +
                    "\n * Item Name " +
                    "\n * Item Price " +
                    "\n * Item Unit " +
                    "\n * Stock Action " +
                    "\n * Item Quantity " +
                    "\n * Narration", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
