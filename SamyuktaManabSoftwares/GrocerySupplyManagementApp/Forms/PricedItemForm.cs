using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PricedItemForm : Form, IPricedItemListForm, IUnpricedItemListForm
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IItemService _itemService;
        private readonly IPricedItemService _pricedItemService;
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
            Customize,
            Done,
            Load,
            PopulatePricedItem,
            PopulateUnpricedItem,
            None
        }
        #endregion 

        #region Constructor
        public PricedItemForm(string username, ISettingService settingService,
            IItemService itemService, IPricedItemService pricedItemService,
            IStockService stockService, DashboardForm dashboardForm)
        {
            InitializeComponent();

            _settingService = settingService;
            _itemService = itemService;
            _pricedItemService = pricedItemService;
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
            EnableFields();
            EnableFields(Action.Load);
            TxtItemCode.Focus();
        }
        #endregion

        #region Button Click Event
        private void BtnBarcodeClear_Click(object sender, EventArgs e)
        {
            TxtBarcode.Clear();
        }

        private void BtnBarcode1Clear_Click(object sender, EventArgs e)
        {
            TxtBarcode1.Clear();
            TxtProfitPercent1.Clear();
            TxtProfitAmount1.Clear();
            TxtSalesPricePerUnit1.Clear();
        }

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

        private void BtnCustomize_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Customize);
            TxtCustomizedQuantity.Text = "1.000";
            TxtProfitPercent.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            AddPricedItem();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Edit);
            LoadCustomizedUnit();
            TxtSubCode.Focus();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePricedItemInfo(Action.Update))
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

                            relativeImagePath = TxtItemCode.Text.Trim() + "-" + TxtItemName.Text.Trim() + ".jpg";
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
                        SubCode = TxtSubCode.Text.Trim(),
                        CustomizedQuantity = string.IsNullOrWhiteSpace(TxtCustomizedQuantity.Text.Trim())
                            ? Constants.DEFAULT_DECIMAL_VALUE
                            : Convert.ToDecimal(TxtCustomizedQuantity.Text.Trim()),
                        CustomizedUnit = ComboCustomizedUnit.Text.Trim(),
                        Barcode = TxtBarcode.Text.Trim(),
                        ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text.Trim()),
                        Profit = Convert.ToDecimal(TxtProfitAmount.Text.Trim()),
                        SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text.Trim()),
                        Barcode1 = TxtBarcode1.Text.Trim(),
                        ProfitPercent1 = string.IsNullOrWhiteSpace(TxtProfitPercent1.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtProfitPercent1.Text.Trim()),
                        Profit1 = string.IsNullOrWhiteSpace(TxtProfitAmount1.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtProfitAmount1.Text.Trim()),
                        SalesPricePerUnit1 = string.IsNullOrWhiteSpace(TxtSalesPricePerUnit1.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtSalesPricePerUnit1.Text.Trim()),
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
                        EnableFields(Action.Update);
                        TxtItemCode.Focus();
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
                    var relativeImagePath = TxtItemCode.Text.Trim() + "-" + TxtItemName.Text.Trim() + ".jpg";
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Add);
            LoadCustomizedUnit();
            TxtSubCode.Focus();
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            if(ValidateCustomizedItem())
            {
                AddPricedItem();
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

        private void BtnExportToWord_Click(object sender, EventArgs e)
        {
            PricedItemListToPrintForm pricedItemListToPrintForm = new PricedItemListToPrintForm(_pricedItemService, _stockService);
            pricedItemListToPrintForm.ShowDialog();
        }

        private void BtnExportToWordWithBarcode_Click(object sender, EventArgs e)
        {
            PricedItemListToPrintForm pricedItemListToPrintForm = new PricedItemListToPrintForm(_pricedItemService, _stockService, true);
            pricedItemListToPrintForm.ShowDialog();
        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            PicBoxLoading.Visible = true;
            PicBoxLoading.Dock = DockStyle.Fill;
            BackgroundWorker.RunWorkerAsync();
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
                    var pricedItem = _pricedItemService.GetPricedItem(pricedItemCode);
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

        private void TxtCustomizedQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtCustomizedQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtPerUnitValue.Text.Trim())
                && decimal.TryParse(TxtPerUnitValue.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtCustomizedQuantity.Text.Trim())
                && decimal.TryParse(TxtCustomizedQuantity.Text.Trim(), out _))
            {
                var perUnitValue = Convert.ToDecimal(TxtPerUnitValue.Text.Trim());
                var customizedQuantity = string.IsNullOrWhiteSpace(TxtCustomizedQuantity.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE
                    : Convert.ToDecimal(TxtCustomizedQuantity.Text.Trim());
                var totalAmount = perUnitValue;
                var profitPercent = Convert.ToDecimal(TxtProfitPercent.Text.Trim());
                var profitAmount = Math.Round((totalAmount * (profitPercent / 100)) , 2);
                var salesPricePerUnit = totalAmount + profitAmount;
                var customizedSalesPrice = customizedQuantity == Constants.DEFAULT_DECIMAL_VALUE
                    ? salesPricePerUnit
                    : Math.Round((salesPricePerUnit * customizedQuantity), 2);
                TxtProfitAmount.Text = profitAmount.ToString("0.00");
                TxtSalesPricePerUnit.Text = salesPricePerUnit.ToString("0.00");
                TxtCustomizedSalesPrice.Text = customizedSalesPrice.ToString("0.00");
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

        private void TxtProfitPercent1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void TxtProfitPercent1_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateProfitAmount1();
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

        private void TxtProfitAmount1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void TxtProfitAmount1_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateProfitPercentage1();
        }
        #endregion

        #region Combo Box Event
        private void ComboCustomizedUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboCustomizedUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ComboCustomizedUnit.Text.Trim()))
            {
                TxtCustomizedQuantity.Clear();
                TxtCustomizedQuantity.Enabled = false;
                ComboCustomizedUnit.Focus();
            }
            else
            {
                TxtCustomizedQuantity.Enabled = true;
                TxtCustomizedQuantity.Focus();
            }
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

        #region BackgroundWorker Event
        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ExportToExcel();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            PicBoxLoading.Visible = false;
        }
        #endregion

        #region Helper Methods
        private void AddPricedItem()
        {
            try
            {
                if (ValidatePricedItemInfo(Action.Save))
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

                            relativeImagePath = TxtItemCode.Text.Trim() + "-" + TxtItemName.Text.Trim() + ".jpg";
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
                        SubCode = TxtSubCode.Text.Trim(),
                        CustomizedQuantity = string.IsNullOrWhiteSpace(TxtCustomizedQuantity.Text.Trim())
                            ? Constants.DEFAULT_DECIMAL_VALUE
                            : Convert.ToDecimal(TxtCustomizedQuantity.Text.Trim()),
                        CustomizedUnit = ComboCustomizedUnit.Text.Trim(),
                        Barcode = TxtBarcode.Text.Trim(),
                        ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text.Trim()),
                        Profit = Convert.ToDecimal(TxtProfitAmount.Text.Trim()),
                        SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text.Trim()),
                        Barcode1 = TxtBarcode1.Text.Trim(),
                        ProfitPercent1 = string.IsNullOrWhiteSpace(TxtProfitPercent1.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtProfitPercent1.Text.Trim()),
                        Profit1 = string.IsNullOrWhiteSpace(TxtProfitAmount1.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtProfitAmount1.Text.Trim()),
                        SalesPricePerUnit1 = string.IsNullOrWhiteSpace(TxtSalesPricePerUnit1.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtSalesPricePerUnit1.Text.Trim()),
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

        private void CalculateProfitAmount()
        {
            if (!string.IsNullOrWhiteSpace(TxtProfitPercent.Text.Trim())
                && decimal.TryParse(TxtProfitPercent.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtPerUnitValue.Text.Trim())
                && decimal.TryParse(TxtPerUnitValue.Text.Trim(), out _))
            {
                var profitPercent = Convert.ToDecimal(TxtProfitPercent.Text.Trim());
                var perUnitValue = Convert.ToDecimal(TxtPerUnitValue.Text.Trim());
                var customizedQuantity = string.IsNullOrWhiteSpace(TxtCustomizedQuantity.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE
                    : Convert.ToDecimal(TxtCustomizedQuantity.Text.Trim());
                var totalAmount = perUnitValue;
                var profitAmount = (totalAmount * (profitPercent / 100));
                var salesPricePerUnit = totalAmount + profitAmount;
                var customizedSalesPrice = customizedQuantity == Constants.DEFAULT_DECIMAL_VALUE
                    ? salesPricePerUnit
                    : Math.Round(salesPricePerUnit * customizedQuantity, 2);
                TxtProfitAmount.Text = profitAmount.ToString("0.00");
                TxtSalesPricePerUnit.Text = salesPricePerUnit.ToString("0.00");
                TxtCustomizedSalesPrice.Text = customizedSalesPrice.ToString("0.00");
            }
            else
            {
                TxtProfitAmount.Text = string.Empty;
                TxtSalesPricePerUnit.Text = string.Empty;
            }
        }

        private void CalculateProfitAmount1()
        {
            if (!string.IsNullOrWhiteSpace(TxtProfitPercent1.Text.Trim())
                && decimal.TryParse(TxtProfitPercent1.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtPerUnitValue.Text.Trim())
                && decimal.TryParse(TxtPerUnitValue.Text.Trim(), out _))
            {
                var profitPercent = Convert.ToDecimal(TxtProfitPercent1.Text.Trim());
                var perUnitValue = Convert.ToDecimal(TxtPerUnitValue.Text.Trim());
                var totalAmount = perUnitValue;
                var profitAmount = (totalAmount * (profitPercent / 100));
                var salesPricePerUnit = totalAmount + profitAmount;
                TxtProfitAmount1.Text = profitAmount.ToString("0.00");
                TxtSalesPricePerUnit1.Text = salesPricePerUnit.ToString("0.00");
            }
            else
            {
                TxtProfitAmount1.Text = string.Empty;
                TxtSalesPricePerUnit1.Text = string.Empty;
            }
        }

        private void CalculateProfitPercentage()
        {
            if (!string.IsNullOrWhiteSpace(TxtProfitAmount.Text.Trim())
                && decimal.TryParse(TxtProfitAmount.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtPerUnitValue.Text.Trim())
                && decimal.TryParse(TxtPerUnitValue.Text.Trim(), out _))
            {
                var profitAmount = Convert.ToDecimal(TxtProfitAmount.Text.Trim());
                var perUnitValue = Convert.ToDecimal(TxtPerUnitValue.Text.Trim());
                var customizedQuantity = string.IsNullOrWhiteSpace(TxtCustomizedQuantity.Text.Trim())
                    ? Constants.DEFAULT_DECIMAL_VALUE
                    : Convert.ToDecimal(TxtCustomizedQuantity.Text.Trim());
                var totalAmount = perUnitValue;
                var profitPercent = ((profitAmount / totalAmount) * 100);
                var salesPricePerUnit = totalAmount + profitAmount;
                var customizedSalesPrice = customizedQuantity == Constants.DEFAULT_DECIMAL_VALUE
                    ? salesPricePerUnit
                    : Math.Round(salesPricePerUnit * customizedQuantity, 2);
                TxtProfitPercent.Text = profitPercent.ToString("0.0000");
                TxtSalesPricePerUnit.Text = salesPricePerUnit.ToString("0.00");
                TxtCustomizedSalesPrice.Text = customizedSalesPrice.ToString("0.00");
            }
            else
            {
                TxtProfitPercent.Text = string.Empty;
                TxtSalesPricePerUnit.Text = string.Empty;
            }
        }

        private void CalculateProfitPercentage1()
        {
            if (!string.IsNullOrWhiteSpace(TxtProfitAmount1.Text.Trim())
                && decimal.TryParse(TxtProfitAmount1.Text.Trim(), out _)
                && !string.IsNullOrWhiteSpace(TxtPerUnitValue.Text.Trim())
                && decimal.TryParse(TxtPerUnitValue.Text.Trim(), out _))
            {
                var profitAmount = Convert.ToDecimal(TxtProfitAmount1.Text.Trim());
                var perUnitValue = Convert.ToDecimal(TxtPerUnitValue.Text.Trim());
                var totalAmount = perUnitValue;
                var profitPercent = ((profitAmount / totalAmount) * 100);
                var salesPricePerUnit = totalAmount + profitAmount;
                TxtProfitPercent1.Text = profitPercent.ToString("0.0000");
                TxtSalesPricePerUnit1.Text = salesPricePerUnit.ToString("0.00");
            }
            else
            {
                TxtProfitPercent1.Text = string.Empty;
                TxtSalesPricePerUnit1.Text = string.Empty;
            }
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Load)
            {
                TxtItemCode.Enabled = true;

                BtnCustomize.Enabled = true;
            }
            else if (action == Action.PopulatePricedItem)
            {
                TxtItemCode.Enabled = true;

                BtnCustomize.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAdd.Enabled = true;
            }
            else if (action == Action.PopulateUnpricedItem)
            {
                BtnCustomize.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == Action.Customize)
            {
                TxtBarcode.Enabled = true;
                TxtProfitPercent.Enabled = true;
                TxtProfitAmount.Enabled = true;

                TxtBarcode1.Enabled = true;
                TxtProfitPercent1.Enabled = true;
                TxtProfitAmount1.Enabled = true;

                BtnBarcodeClear.Enabled = true;
                BtnBarcode1Clear.Enabled = true;
                BtnSave.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                TxtItemCode.Enabled = true;
                TxtSubCode.Enabled = true;
                ComboCustomizedUnit.Enabled = true;

                TxtBarcode.Enabled = true;
                TxtProfitPercent.Enabled = true;
                TxtProfitAmount.Enabled = true;

                TxtBarcode1.Enabled = true;
                TxtProfitPercent1.Enabled = true;
                TxtProfitAmount1.Enabled = true;

                BtnBarcodeClear.Enabled = true;
                BtnBarcode1Clear.Enabled = true;
                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
            }
            else if (action == Action.Update)
            {
                TxtItemCode.Enabled = true;

                BtnCustomize.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == Action.Add)
            {
                TxtSubCode.Enabled = true;
                ComboCustomizedUnit.Enabled = true;

                TxtBarcode.Enabled = true;
                TxtProfitPercent.Enabled = true;
                TxtProfitAmount.Enabled = true;

                TxtBarcode1.Enabled = true;
                TxtProfitPercent1.Enabled = true;
                TxtProfitAmount1.Enabled = true;

                BtnBarcodeClear.Enabled = true;
                BtnBarcode1Clear.Enabled = true;
                BtnDone.Enabled = true;
                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
            }
            else if (action == Action.Done)
            {
                TxtItemCode.Enabled = true;

                BtnCustomize.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else
            {
                TxtItemCode.Enabled = false;
                TxtSubCode.Enabled = false;
                TxtCustomizedQuantity.Enabled = false;
                ComboCustomizedUnit.Enabled = false;

                TxtItemName.Enabled = false;
                TxtItemUnit.Enabled = false;
                TxtTotalStock.Enabled = false;
                TxtPerUnitValue.Enabled = false;

                TxtBarcode.Enabled = false;
                TxtProfitPercent.Enabled = false;
                TxtProfitAmount.Enabled = false;
                TxtSalesPricePerUnit.Enabled = false;

                TxtBarcode1.Enabled = false;
                TxtProfitPercent1.Enabled = false;
                TxtProfitAmount1.Enabled = false;
                TxtSalesPricePerUnit1.Enabled = false;

                BtnBarcodeClear.Enabled = false;
                BtnBarcode1Clear.Enabled = false;
                BtnCustomize.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
                BtnAdd.Enabled = false;
                BtnDone.Enabled = false;
                BtnAddImage.Enabled = false;
                BtnDeleteImage.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            TxtItemCode.Clear();
            TxtSubCode.Clear();
            TxtItemName.Clear();
            TxtItemUnit.Clear();
            TxtTotalStock.Clear();
            TxtPerUnitValue.Clear();
            TxtCustomizedSalesPrice.Clear();
            ComboCustomizedUnit.Text = String.Empty;
            TxtCustomizedQuantity.Clear();

            TxtBarcode.Clear();
            TxtProfitPercent.Clear();
            TxtProfitAmount.Clear();
            TxtSalesPricePerUnit.Clear();

            TxtBarcode1.Clear();
            TxtProfitPercent1.Clear();
            TxtProfitAmount1.Clear();
            TxtSalesPricePerUnit1.Clear();

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
                TxtSubCode.Text = pricedItem.SubCode;
                TxtItemName.Text = item.Name;
                TxtItemUnit.Text = item.Unit;
                StockFilter stockFilter = new StockFilter
                {
                    ItemCode = item.Code
                };

                TxtTotalStock.Text = _stockService.GetTotalStock(stockFilter).ToString();
                TxtBarcode.Text = string.IsNullOrWhiteSpace(pricedItem.Barcode) ? string.Empty : pricedItem.Barcode;
                var stockItem = _stockService.GetStockItem(pricedItem, stockFilter);

                TxtPerUnitValue.Text = stockItem.PerUnitValue.ToString();
                ComboCustomizedUnit.Text = pricedItem.CustomizedUnit;
                TxtCustomizedQuantity.Text = pricedItem.CustomizedQuantity.ToString();

                TxtBarcode.Text = string.IsNullOrWhiteSpace(pricedItem.Barcode) ? string.Empty : pricedItem.Barcode;
                TxtProfitPercent.Text = pricedItem.ProfitPercent == Constants.DEFAULT_DECIMAL_VALUE 
                    ? string.Empty 
                    : pricedItem.ProfitPercent.ToString();
                TxtProfitAmount.Text = stockItem.ProfitAmount.ToString();
                TxtSalesPricePerUnit.Text = stockItem.SalesPrice.ToString();
                TxtCustomizedSalesPrice.Text = (pricedItem.CustomizedQuantity == null || pricedItem.CustomizedQuantity == Constants.DEFAULT_DECIMAL_VALUE)
                    ? stockItem.SalesPrice.ToString()
                    : Math.Round(stockItem.SalesPrice * Convert.ToDecimal(pricedItem.CustomizedQuantity), 2).ToString();

                if (string.IsNullOrWhiteSpace(pricedItem.Barcode1))
                {
                    TxtBarcode1.Text = string.Empty;
                    TxtProfitPercent1.Text = string.Empty;
                    TxtProfitAmount1.Text = string.Empty;
                    TxtSalesPricePerUnit1.Text = string.Empty;
                }
                else
                {
                    TxtBarcode1.Text = pricedItem.Barcode1;
                    TxtProfitPercent1.Text = pricedItem.ProfitPercent == Constants.DEFAULT_DECIMAL_VALUE ? string.Empty : pricedItem.ProfitPercent1.ToString();
                  
                    pricedItem.ProfitPercent = pricedItem.ProfitPercent1;

                    var stockItem1 = _stockService.GetStockItem(pricedItem, stockFilter);
                    TxtProfitAmount1.Text = stockItem1.ProfitAmount.ToString();
                    TxtSalesPricePerUnit1.Text = stockItem1.SalesPrice.ToString();
                }

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
                TxtItemUnit.Text = item.Unit;
                StockFilter stockFilter = new StockFilter
                {
                    ItemCode = item.Code
                };

                TxtTotalStock.Text = _stockService.GetTotalStock(stockFilter).ToString();

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

        private void ExportToExcel()
        {
            Thread thread = new Thread((ThreadStart)(() =>
            {
                var dialogResult = SaveFileDialog.ShowDialog();
                var filename = SaveFileDialog.FileName;
                if (dialogResult == DialogResult.OK)
                {
                    var excelData = new Dictionary<string, List<MSExcelField>>();
                    var pricedItemViewListWithoutPrice = _pricedItemService.GetPricedItemViewList();
                    var excelPricedItemFieldList = pricedItemViewListWithoutPrice.Select(x => new MSExcelPricedItemField
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Name = x.Name,
                        Price = _stockService.GetStockItem(_pricedItemService.GetPricedItem(x.Id), new StockFilter() { ItemCode = x.Code }).SalesPrice
                    }).ToList();

                    MSExcel.Export(excelPricedItemFieldList, "Priced Item", filename);
                }
            }));

            // Run your code from a thread that joins the STA Thread
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void LoadCustomizedUnit()
        {
            ComboCustomizedUnit.Items.Clear();
            ComboCustomizedUnit.ValueMember = "Id";
            ComboCustomizedUnit.DisplayMember = "Value";

            if (TxtItemUnit.Text.Trim() == Constants.PIECES)
            {
                ComboCustomizedUnit.Items.Add(new ComboBoxItem { Id = Constants.PIECES, Value = Constants.PIECES });
                ComboCustomizedUnit.Items.Add(new ComboBoxItem { Id = Constants.PACKET, Value = Constants.PACKET });

                ComboCustomizedUnit.SelectedItem = Constants.PIECES;
                TxtCustomizedQuantity.Enabled = true;
            }
            else if (TxtItemUnit.Text.Trim() == Constants.KILOGRAM)
            {
                ComboCustomizedUnit.Items.Add(new ComboBoxItem { Id = Constants.KILOGRAM, Value = Constants.KILOGRAM });
                ComboCustomizedUnit.Items.Add(new ComboBoxItem { Id = Constants.GRAM, Value = Constants.GRAM });

                ComboCustomizedUnit.SelectedText = Constants.KILOGRAM;
                TxtCustomizedQuantity.Enabled = true;
            }
            else if (TxtItemUnit.Text.Trim() == Constants.LITER)
            {
                ComboCustomizedUnit.Items.Add(new ComboBoxItem { Id = Constants.LITER, Value = Constants.LITER });
                ComboCustomizedUnit.Items.Add(new ComboBoxItem { Id = Constants.BOX, Value = Constants.BOX });

                ComboCustomizedUnit.SelectedItem = Constants.LITER;
                TxtCustomizedQuantity.Enabled = true;
            }
            else
            {
                ComboCustomizedUnit.Enabled = false;
            }
        }
        #endregion

        #region Validation
        private bool ValidatePricedItemInfo(Action action)
        {
            var isValidated = false;

            var itemCode = TxtItemCode.Text.Trim();
            var profitPercent = TxtProfitPercent.Text.Trim();
            var profitAmount = TxtProfitAmount.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemCode)
                || string.IsNullOrWhiteSpace(profitPercent)
                || string.IsNullOrWhiteSpace(profitAmount))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Item Code " +
                    "\n * Profit Percent " +
                    "\n * Profit Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(profitPercent.IndexOf('.') != -1 && (profitPercent.Length - profitPercent.LastIndexOf('.') > 5))
            {
                MessageBox.Show("Please enter 4 decimal only in profit percentage", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (profitAmount.IndexOf('.') != -1 && (profitAmount.Length - profitAmount.LastIndexOf('.') > 3))
            {
                MessageBox.Show("Please enter 2 decimal only in profit amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (action == Action.Update)
            {
                var pricedItem = _pricedItemService.GetPricedItem(itemCode);
                if (pricedItem.Id != 0)
                {
                    if (_selectedId != pricedItem.Id)
                    {
                        MessageBox.Show("Item code: " + itemCode + " has been changed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        isValidated = true;
                    }
                }
                else
                {
                    MessageBox.Show("Item with " + itemCode + " does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }

        private bool ValidateCustomizedItem()
        {
            var isValidated = false;

            var itemCode = TxtItemCode.Text.Trim();
            var itemSubCode = TxtSubCode.Text.Trim();
            var customizedUnit = ComboCustomizedUnit.Text.Trim();
            var customizedQuantity = TxtCustomizedQuantity.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemCode)
                || string.IsNullOrWhiteSpace(itemSubCode)
                || string.IsNullOrWhiteSpace(customizedUnit)
                || string.IsNullOrWhiteSpace(customizedQuantity))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Item Code " +
                    "\n * Item Sub Code " +
                    "\n * Customized Unit " +
                    "\n * Customized Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (decimal.TryParse(customizedQuantity, out _) && Convert.ToDecimal(customizedQuantity) == Constants.DEFAULT_DECIMAL_VALUE)
            {
                MessageBox.Show("Customized quantity cannot be zero", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (customizedQuantity.IndexOf('.') != -1 && (customizedQuantity.Length - customizedQuantity.LastIndexOf('.') > 4))
            {
                MessageBox.Show("Please enter 3 decimal only in customized quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var pricedItem = _pricedItemService.GetPricedItem(itemCode, itemSubCode);
                if (pricedItem.Id != 0)
                {
                    MessageBox.Show("Item with " + itemCode + " and " + itemSubCode + " already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    isValidated = true;
                }
            }
            
            return isValidated;
        }
        #endregion
    }
}
