using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PricedItemForm : Form, IPricedItemListForm, IUnpricedItemListForm
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IItemService _itemService;
        private readonly IPricedItemService _pricedItemService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IStockService _stockService;

        public DashboardForm _dashboard;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;
        private string _baseImageFolder;
        private string _itemImageFolder;
        private string _uploadedImagePath = string.Empty;
        private long _selectedId = 0;
        private long _selectedItemId = 0;

        #region Enum
        private enum Action
        {
            Add,
            Save,
            Edit,
            Update,
            Delete,
            Load,
            PopulatePricedItem,
            PopulateUnpricedItem,
            None
        }
        #endregion 

        #region Constructor
        public PricedItemForm(string username, ISettingService settingService,
            IItemService itemService, IPricedItemService pricedItemService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService,
            IStockService stockService, DashboardForm dashboardForm)
        {
            InitializeComponent();

            _settingService = settingService;
            _itemService = itemService;
            _pricedItemService = pricedItemService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _stockService = stockService;

            _dashboard = dashboardForm;
            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void PricedItemForm_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
            _itemImageFolder = ConfigurationManager.AppSettings[Constants.ITEM_IMAGE_FOLDER].ToString();
            LoadItemUnits();
            EnableFields();
            EnableFields(Action.Load);
            TxtItemCode.Focus();
        }
        #endregion

        #region Button Click Event
        private void BtnSearchPricedItem_Click(object sender, EventArgs e)
        {
            PricedItemListForm pricedItemListForm = new PricedItemListForm(_pricedItemService, this);
            pricedItemListForm.ShowDialog();
        }

        private void BtnSearchUnpricedItem_Click(object sender, EventArgs e)
        {
            UnpricedItemListForm unpricedItemListForm = new UnpricedItemListForm(_pricedItemService, this);
            unpricedItemListForm.ShowDialog();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Add);
            TxtItemSubCode.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePricedItemInfo())
                {
                    string relativeImagePath = null;
                    string destinationFilePath = null;
                    if (!string.IsNullOrWhiteSpace(_uploadedImagePath) || !string.IsNullOrWhiteSpace(PicBoxItemImage.ImageLocation))
                    {
                        if (!Directory.Exists(_baseImageFolder))
                        {
                            DialogResult errorResult = MessageBox.Show("Base image folder is set correctly. Please check.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (errorResult == DialogResult.OK)
                            {
                                return;
                            }

                            return;
                        }
                        else
                        {
                            if (!Directory.Exists(Path.Combine(_baseImageFolder, _itemImageFolder)))
                            {
                                UtilityService.CreateFolder(_baseImageFolder, _itemImageFolder);
                            }

                            relativeImagePath = TxtItemCode.Text.Trim() + "-" + TxtItemName.Text.Trim() + "-" + TxtVolume.Text.Trim() + ".jpg";
                            destinationFilePath = Path.Combine(_baseImageFolder, _itemImageFolder, relativeImagePath);
                            if (!string.IsNullOrWhiteSpace(_uploadedImagePath))
                            {
                                File.Copy(_uploadedImagePath, destinationFilePath, true);
                            }
                            else
                            {
                                File.Copy(PicBoxItemImage.ImageLocation, destinationFilePath, true);
                            }
                        }
                    }

                    var pricedItem = new PricedItem
                    {
                        EndOfDay = _endOfDay,
                        ItemId = _selectedItemId,
                        Volume = Convert.ToDecimal(TxtVolume.Text.Trim()),
                        SubCode = TxtItemSubCode.Text.Trim(),
                        ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text.Trim()),
                        Profit = Convert.ToDecimal(TxtProfitAmount.Text.Trim()),
                        SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text.Trim()),
                        ImagePath = relativeImagePath,
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _pricedItemService.AddPricedItem(pricedItem);
                    DialogResult result = MessageBox.Show(TxtItemCode.Text + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields();
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
            EnableFields();
            EnableFields(Action.Edit);
            TxtItemSubCode.Focus();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePricedItemInfo())
                {
                    string relativeImagePath = null;
                    string destinationFilePath = null;
                    if (!string.IsNullOrWhiteSpace(_uploadedImagePath))
                    {
                        if (!Directory.Exists(_baseImageFolder))
                        {
                            DialogResult errorResult = MessageBox.Show("Base image folder is set correctly. Please check.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (errorResult == DialogResult.OK)
                            {
                                return;
                            }

                            return;
                        }
                        else
                        {
                            if (!Directory.Exists(Path.Combine(_baseImageFolder, _itemImageFolder)))
                            {
                                UtilityService.CreateFolder(_baseImageFolder, _itemImageFolder);
                            }

                            relativeImagePath = TxtItemCode.Text.Trim() + "-" + TxtItemName.Text.Trim() + "-" + TxtVolume.Text.Trim() + ".jpg";
                            destinationFilePath = Path.Combine(_baseImageFolder, _itemImageFolder, relativeImagePath);
                            File.Copy(_uploadedImagePath, destinationFilePath, true);
                        }
                    }
                    else
                    {
                        destinationFilePath = PicBoxItemImage.ImageLocation;
                    }

                    var pricedItem = new PricedItem
                    {
                        ItemId = _selectedItemId,
                        Volume = Convert.ToDecimal(TxtVolume.Text.Trim()),
                        SubCode = TxtItemSubCode.Text.Trim(),
                        ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text.Trim()),
                        Profit = Convert.ToDecimal(TxtProfitAmount.Text.Trim()),
                        SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text.Trim()),
                        ImagePath = relativeImagePath,
                        UpdatedBy = _username,
                        UpdatedDate = DateTime.Now
                    };

                    _pricedItemService.UpdatePricedItem(_selectedId, pricedItem);
                    DialogResult result = MessageBox.Show(TxtItemCode.Text.Trim() + " has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields();
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
                DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteResult == DialogResult.Yes)
                {
                    var relativeImagePath = TxtItemCode.Text.Trim() + "-" + TxtItemName.Text.Trim() + "-" + TxtVolume.Text.Trim() + ".jpg";
                    var absoluteImagePath = Path.Combine(_baseImageFolder, _itemImageFolder, relativeImagePath);
                    if (!string.IsNullOrWhiteSpace(absoluteImagePath) && File.Exists(absoluteImagePath))
                    {
                        UtilityService.DeleteImage(absoluteImagePath);
                    }

                    if (_pricedItemService.DeletePricedItem(_selectedId))
                    {
                        DialogResult result = MessageBox.Show(TxtItemCode.Text.Trim() + " has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            ClearAllFields();
                            EnableFields();
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

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            OpenItemImageDialog.InitialDirectory = _baseImageFolder;
            OpenItemImageDialog.Filter = "All files |*.*";
            OpenItemImageDialog.ShowDialog();
        }

        private void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            PicBoxItemImage.Image = PicBoxItemImage.InitialImage;
            _uploadedImagePath = string.Empty;
        }
        #endregion

        #region Textbox Event
        private void TxtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void TxtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                try
                {
                    var pricedItemCode = TxtItemCode.Text.Trim();
                    var pricedItem = _pricedItemService.GetPricedItem(pricedItemCode, string.Empty);
                    if(pricedItem.Id != 0)
                    {
                        PopulatePricedItem(pricedItem.Id);
                    }
                    else
                    {
                        MessageBox.Show("Item with " + pricedItemCode + " does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    UtilityService.ShowExceptionMessageBox();
                }
            }
        }

        private void TxtVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtVolume_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtVolume.Text.Trim()))
            {
                TxtCustomPerUnitValue.Text = (Convert.ToDecimal(TxtPerUnitValue.Text.Trim()) * Convert.ToDecimal(TxtVolume.Text.Trim())).ToString();
                CalculateProfitAmount();
            }
        }

        private void TxtProfitPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void TxtProfitPercent_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateProfitAmount();
        }

        private void TxtProfitAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void TxtProfitAmount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateProfitPercentage();
        }

        #endregion

        #region Combo Box Event
        private void ComboItemUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region OpenFileDialog Event
        private void OpenItemImageDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Activate();
                string[] files = OpenItemImageDialog.FileNames;
                _uploadedImagePath = files[0];
                PicBoxItemImage.Image = Image.FromFile(_uploadedImagePath);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }
        #endregion

        #region Helper Methods

        private void CalculateProfitAmount()
        {
            decimal value;
            if (!string.IsNullOrWhiteSpace(TxtProfitPercent.Text.Trim())
                && decimal.TryParse(TxtProfitPercent.Text.Trim(), out value)
                && !string.IsNullOrWhiteSpace(TxtCustomPerUnitValue.Text.Trim())
                && decimal.TryParse(TxtCustomPerUnitValue.Text.Trim(), out value))
            {
                var profitPercent = Convert.ToDecimal(TxtProfitPercent.Text.Trim());
                var customPerUnitValue = Convert.ToDecimal(TxtCustomPerUnitValue.Text.Trim());
                var profitAmount = (customPerUnitValue * (profitPercent / 100));
                TxtProfitAmount.Text = profitAmount.ToString("0.00");
                var salesPricePerUnit = customPerUnitValue + profitAmount;
                TxtSalesPricePerUnit.Text = salesPricePerUnit.ToString("0.00");
            }
            else
            {
                TxtProfitAmount.Text = string.Empty;
                TxtSalesPricePerUnit.Text = string.Empty;
            }
        }

        private void CalculateProfitPercentage()
        {
            decimal value;
            if (!string.IsNullOrWhiteSpace(TxtProfitAmount.Text.Trim())
                && decimal.TryParse(TxtProfitAmount.Text.Trim(), out value)
                && !string.IsNullOrWhiteSpace(TxtCustomPerUnitValue.Text.Trim())
                && decimal.TryParse(TxtProfitAmount.Text.Trim(), out value))
            {
                var profitAmount = Convert.ToDecimal(TxtProfitAmount.Text.Trim());
                var customPerUnitValue = Convert.ToDecimal(TxtCustomPerUnitValue.Text.Trim());
                var profitPercent = ((profitAmount / customPerUnitValue) * 100);
                TxtProfitPercent.Text = profitPercent.ToString("0.000");
                var salesPricePerUnit = customPerUnitValue + profitAmount;
                TxtSalesPricePerUnit.Text = salesPricePerUnit.ToString("0.00");
            }
            else
            {
                TxtProfitPercent.Text = string.Empty;
                TxtSalesPricePerUnit.Text = string.Empty;
            }
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Load)
            {
                TxtItemCode.Enabled = true;

                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == Action.PopulatePricedItem)
            {
                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == Action.PopulateUnpricedItem)
            {
                BtnAdd.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == Action.Add)
            {
                TxtItemSubCode.Enabled = true;
                TxtVolume.Enabled = true;
                TxtProfitPercent.Enabled = true;
                TxtProfitAmount.Enabled = true;

                BtnSave.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                TxtItemSubCode.Enabled = true;
                TxtVolume.Enabled = true;
                TxtProfitPercent.Enabled = true;
                TxtProfitAmount.Enabled = true;

                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
            }
            else
            {
                TxtItemCode.Enabled = false;
                TxtItemName.Enabled = false;
                ComboItemUnit.Enabled = false;
                TxtTotalStock.Enabled = false;
                TxtPerUnitValue.Enabled = false;
                TxtVolume.Enabled = false;
                TxtCustomPerUnitValue.Enabled = false;
                TxtItemSubCode.Enabled = false;
                TxtProfitPercent.Enabled = false;
                TxtProfitAmount.Enabled = false;
                TxtSalesPricePerUnit.Enabled = false;

                BtnAdd.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
                BtnAddImage.Enabled = false;
                BtnDeleteImage.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            TxtItemCode.Clear();
            TxtItemName.Clear();
            ComboItemUnit.Text = string.Empty;
            TxtTotalStock.Clear();
            TxtPerUnitValue.Clear();
            TxtItemSubCode.Clear();
            TxtVolume.Clear();
            TxtCustomPerUnitValue.Clear();
            TxtProfitPercent.Clear();
            TxtProfitAmount.Clear();
            TxtSalesPricePerUnit.Clear();
            PicBoxItemImage.Image = PicBoxItemImage.InitialImage;
        }

        public void PopulatePricedItem(long pricedId)
        {
            try
            {
                ClearAllFields();
                _selectedId = pricedId;
                var pricedItem = _pricedItemService.GetPricedItem(_selectedId);
                _selectedItemId = pricedItem.ItemId;
                var item = _itemService.GetItem(_selectedItemId);

                TxtItemCode.Text = item.Code;
                TxtVolume.Text = pricedItem.Volume.ToString();
                TxtItemName.Text = item.Name;
                ComboItemUnit.Text = item.Unit;
                StockFilter stockFilter = new StockFilter
                {
                    ItemCode = item.Code
                };

                TxtTotalStock.Text = (_purchasedItemService.GetPurchasedItemTotalQuantity(stockFilter) - _soldItemService.GetSoldItemTotalQuantity(stockFilter)).ToString();

                var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var perUnitValue = _stockService.GetPerUnitValue(stocks.ToList(), stockFilter);
                TxtPerUnitValue.Text = perUnitValue.ToString();

                TxtItemSubCode.Text = pricedItem.SubCode;
                TxtVolume.Text = pricedItem.Volume.ToString();
                TxtCustomPerUnitValue.Text = Math.Round((perUnitValue * pricedItem.Volume), 2).ToString();

                var profitPercent = pricedItem.ProfitPercent;
                TxtProfitPercent.Text = profitPercent.ToString();
                var customPerUnitValue = string.IsNullOrWhiteSpace(TxtCustomPerUnitValue.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtCustomPerUnitValue.Text.Trim());
                var profitAmount = Math.Round(customPerUnitValue * (profitPercent / 100), 2);
                TxtProfitAmount.Text = profitAmount.ToString();
                var salesPrice = customPerUnitValue + profitAmount;
                TxtSalesPricePerUnit.Text = Math.Round(salesPrice, 2).ToString();

                var absoluteImagePath = Path.Combine(_baseImageFolder, _itemImageFolder, pricedItem.ImagePath);
                if (File.Exists(absoluteImagePath))
                {
                    PicBoxItemImage.ImageLocation = absoluteImagePath;
                }
                else
                {
                    PicBoxItemImage.Image = PicBoxItemImage.InitialImage;
                }

                EnableFields();
                EnableFields(Action.PopulatePricedItem);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        public void PopulateUnpricedItem(long itemId)
        {
            try
            {
                ClearAllFields();

                _selectedItemId = itemId;
                var item = _itemService.GetItem(_selectedItemId);
                TxtItemCode.Text = item.Code;
                TxtItemName.Text = item.Name;
                ComboItemUnit.Text = item.Unit;
                StockFilter stockFilter = new StockFilter
                {
                    ItemCode = item.Code
                };

                TxtTotalStock.Text = (_purchasedItemService.GetPurchasedItemTotalQuantity(stockFilter) - _soldItemService.GetSoldItemTotalQuantity(stockFilter)).ToString();

                var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var perUnitValue = _stockService.GetPerUnitValue(stocks.ToList(), stockFilter);
                TxtPerUnitValue.Text = perUnitValue.ToString();

                EnableFields();
                EnableFields(Action.PopulateUnpricedItem);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void LoadItemUnits()
        {
            ComboItemUnit.Items.Clear();
            ComboItemUnit.ValueMember = "Id";
            ComboItemUnit.DisplayMember = "Value";

            ComboItemUnit.Items.Add(new ComboBoxItem { Id = Constants.KILOGRAM, Value = Constants.KILOGRAM });
            ComboItemUnit.Items.Add(new ComboBoxItem { Id = Constants.GRAM, Value = Constants.GRAM });
            ComboItemUnit.Items.Add(new ComboBoxItem { Id = Constants.LITER, Value = Constants.LITER });
            ComboItemUnit.Items.Add(new ComboBoxItem { Id = Constants.MILLI_LITER, Value = Constants.MILLI_LITER });
            ComboItemUnit.Items.Add(new ComboBoxItem { Id = Constants.PIECES, Value = Constants.PIECES });
            ComboItemUnit.Items.Add(new ComboBoxItem { Id = Constants.PACKET, Value = Constants.PACKET });
            ComboItemUnit.Items.Add(new ComboBoxItem { Id = Constants.BAG, Value = Constants.BAG });
            ComboItemUnit.Items.Add(new ComboBoxItem { Id = Constants.BOTTLE, Value = Constants.BOTTLE });
            ComboItemUnit.Items.Add(new ComboBoxItem { Id = Constants.CAN, Value = Constants.CAN });
            ComboItemUnit.Items.Add(new ComboBoxItem { Id = Constants.DOZEN, Value = Constants.DOZEN });
        }

        #endregion

        #region Validation
        private bool ValidatePricedItemInfo()
        {
            var isValidated = false;

            var itemCode = TxtItemCode.Text.Trim();
            var itemSubCode = TxtItemSubCode.Text.Trim();
            var volume = TxtVolume.Text.Trim();
            var profitPercent = TxtProfitPercent.Text.Trim();
            var profitAmount = TxtProfitAmount.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemCode)
                || string.IsNullOrWhiteSpace(itemSubCode)
                || string.IsNullOrWhiteSpace(volume)
                || string.IsNullOrWhiteSpace(profitPercent)
                || string.IsNullOrWhiteSpace(profitAmount))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Item Code " +
                    "\n * Item Sub Code " +
                    "\n * Volume " +
                    "\n * Profit Percent " +
                    "\n * Profit Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(profitPercent.IndexOf('.') != -1 && (profitPercent.Length - profitPercent.LastIndexOf('.') > 4))
            {
                MessageBox.Show("Please enter 3 decimal only in profit percentage", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (profitAmount.IndexOf('.') != -1 && (profitAmount.Length - profitAmount.LastIndexOf('.') > 3))
            {
                MessageBox.Show("Please enter 2 decimal only in profit amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var pricedItem = _pricedItemService.GetPricedItem(itemCode, string.Empty);
                if (pricedItem.Id != 0)
                {
                    isValidated = true;
                }
                else
                {
                    MessageBox.Show("Item with " + itemCode + " does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return isValidated;
        }
        #endregion
    }
}
