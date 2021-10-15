using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
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

        private readonly IItemService _itemService;
        private readonly IPricedItemService _pricedItemService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IStockService _stockService;

        public DashboardForm _dashboard;

        private readonly string _username;
        private string _baseImageFolder;
        private const string ITEM_IMAGE_FOLDER = "Items";
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
            PopulatePricedItem,
            PopulateUnpricedItem,
            None
        }
        #endregion 

        #region Constructor
        public PricedItemForm(string username, 
            IItemService itemService, IPricedItemService pricedItemService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService,
            IStockService stockService, DashboardForm dashboardForm)
        {
            InitializeComponent();

            _itemService = itemService;
            _pricedItemService = pricedItemService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _stockService = stockService;

            _dashboard = dashboardForm;
            _username = username;
        }
        #endregion

        #region Form Load Event
        private void ItemForm_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
            LoadItemUnits();
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
                        if (!Directory.Exists(Path.Combine(_baseImageFolder, ITEM_IMAGE_FOLDER)))
                        {
                            UtilityService.CreateFolder(_baseImageFolder, ITEM_IMAGE_FOLDER);
                        }

                        var fileName = TxtItemCode.Text + "-" + TxtItemName.Text + "-" + TxtItemBrand.Text + "-" + TxtVolume.Text + ".jpg";
                        destinationFilePath = Path.Combine(_baseImageFolder, ITEM_IMAGE_FOLDER, fileName);
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
                    ItemId = _selectedItemId,
                    Volume = Convert.ToInt64(TxtVolume.Text),
                    SubCode = TxtItemSubCode.Text,
                    ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text),
                    Profit = Convert.ToDecimal(TxtProfitAmount.Text),
                    SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text),
                    ImagePath = destinationFilePath,
                    AddedBy = _username,
                    AddedDate = DateTime.Now
                };

                _pricedItemService.AddPricedItem(pricedItem);
                DialogResult result = MessageBox.Show(TxtItemCode.Text + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
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
                        if (!Directory.Exists(Path.Combine(_baseImageFolder, ITEM_IMAGE_FOLDER)))
                        {
                            UtilityService.CreateFolder(_baseImageFolder, ITEM_IMAGE_FOLDER);
                        }

                        var fileName = TxtItemCode.Text + "-" + TxtItemName.Text + "-" + TxtItemBrand.Text + "-" + TxtVolume.Text + ".jpg";
                        destinationFilePath = Path.Combine(_baseImageFolder, ITEM_IMAGE_FOLDER, fileName);
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
                    Volume = Convert.ToInt64(TxtVolume.Text),
                    SubCode = TxtItemSubCode.Text,
                    ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text),
                    Profit = Convert.ToDecimal(TxtProfitAmount.Text),
                    SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text),
                    ImagePath = destinationFilePath,
                    UpdatedBy = _username,
                    UpdatedDate = DateTime.Now
                };

                _pricedItemService.UpdatePricedItem(_selectedId, pricedItem);
                DialogResult result = MessageBox.Show(TxtItemCode.Text + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult deleteResult = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (deleteResult == DialogResult.Yes)
                {
                    var fileName = TxtItemCode.Text + "-" + TxtItemName.Text + "-" + TxtItemBrand.Text + "-" + TxtVolume.Text + ".jpg";
                    var filePath = Path.Combine(_baseImageFolder, ITEM_IMAGE_FOLDER, fileName);
                    if (File.Exists(filePath))
                    {
                        UtilityService.DeleteImage(filePath);
                    }

                    if (_pricedItemService.DeletePricedItem(_selectedId))
                    {
                        DialogResult result = MessageBox.Show(TxtItemCode.Text + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
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
                throw ex;
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
            PicBoxItemImage.Image = null;
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
            catch(Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
        #endregion

        #region Textbox Event

        private void TxtVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtVolume_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtVolume.Text))
            {
                TxtCustomPerUnitValue.Text = (Convert.ToDecimal(TxtPerUnitValue.Text) * Convert.ToDecimal(TxtVolume.Text)).ToString();
                CalculateProfit();
            }
        }

        private void TxtProfitPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtProfitPercent_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateProfit();
        }

        #endregion

        #region Helper Methods

        private void CalculateProfit()
        {
            if (!string.IsNullOrWhiteSpace(TxtProfitPercent.Text))
            {
                var profitPercent = Convert.ToDecimal(TxtProfitPercent.Text);
                var customPerUnitValue = Convert.ToDecimal(TxtCustomPerUnitValue.Text);
                var profitAmount = (customPerUnitValue * (profitPercent / 100));
                TxtProfitAmount.Text = profitAmount.ToString("0.00");
                var salesPrice = customPerUnitValue + profitAmount;
                TxtSalesPricePerUnit.Text = salesPrice.ToString("0.00");
            }
            else
            {
                TxtProfitAmount.Text = string.Empty;
                TxtSalesPricePerUnit.Text = string.Empty;
            }
        }

        private void EnableFields(Action action = Action.None)
        {
            if(action == Action.PopulatePricedItem)
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
            else if(action == Action.Add)
            {
                TxtVolume.Enabled = true;
                TxtProfitPercent.Enabled = true;
                TxtItemSubCode.Enabled = true;

                BtnSave.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                TxtVolume.Enabled = true;
                TxtProfitPercent.Enabled = true;
                TxtItemSubCode.Enabled = true;

                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
            }
            else
            {
                TxtItemCode.Enabled = false;
                TxtItemName.Enabled = false;
                TxtItemBrand.Enabled = false;
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
            TxtItemBrand.Clear();
            ComboItemUnit.Text = string.Empty;
            TxtTotalStock.Clear();
            TxtPerUnitValue.Clear();
            TxtItemSubCode.Clear();
            TxtVolume.Clear();
            TxtCustomPerUnitValue.Clear();
            TxtProfitPercent.Clear();
            TxtProfitAmount.Clear();
            TxtSalesPricePerUnit.Clear();
            PicBoxItemImage.Image = null;
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
                TxtItemBrand.Text = item.Brand;
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
                TxtCustomPerUnitValue.Text = (perUnitValue * pricedItem.Volume).ToString();

                var profitPercent = pricedItem.ProfitPercent;
                TxtProfitPercent.Text = profitPercent.ToString();
                var customPerUnitValue = string.IsNullOrWhiteSpace(TxtCustomPerUnitValue.Text) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(TxtCustomPerUnitValue.Text);
                var profitAmount = Math.Round(customPerUnitValue * (profitPercent / 100), 2);
                TxtProfitAmount.Text = profitAmount.ToString();
                var salesPrice = customPerUnitValue + profitAmount;
                TxtSalesPricePerUnit.Text = Math.Round(salesPrice, 2).ToString();

                if (File.Exists(pricedItem.ImagePath))
                {
                    PicBoxItemImage.ImageLocation = pricedItem.ImagePath;
                }

                EnableFields(); 
                EnableFields(Action.PopulatePricedItem);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
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
                TxtItemBrand.Text = item.Brand;
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
                throw ex;
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
    }
}
