using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
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
        private readonly IItemService _itemService;
        private readonly IPricedItemService _pricedItemService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IStockService _stockService;

        public DashboardForm _dashboard;
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
        public PricedItemForm(IItemService itemService, IPricedItemService pricedItemService,
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
        }
        #endregion

        #region Form Load Event
        private void ItemForm_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
            LoadItemUnits();
            LoadCustomItemUnits();
        }
        #endregion

        #region Button Click Event
        private void BtnShowPricedItem_Click(object sender, EventArgs e)
        {
            PricedItemListForm pricedItemListForm = new PricedItemListForm(_pricedItemService, this);
            pricedItemListForm.ShowDialog();
        }

        private void BtnShowUnpricedItem_Click(object sender, EventArgs e)
        {
            UnpricedItemListForm unpricedItemListForm = new UnpricedItemListForm(_pricedItemService, this);
            unpricedItemListForm.ShowDialog();
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

                var date = DateTime.Now;
                var pricedItem = new PricedItem
                {
                    ItemId = _selectedItemId,
                    CustomUnit = ComboCustomItemUnit.Text,
                    Volume = Convert.ToInt64(TxtVolume.Text),
                    SubCode = TxtItemSubCode.Text,
                    ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text),
                    Profit = Convert.ToDecimal(TxtProfitAmount.Text),
                    SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text),
                    ImagePath = destinationFilePath,
                    UpdatedDate = date
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
                throw ex;
            }
        }

        private void BtnAddItemImage_Click(object sender, EventArgs e)
        {
            OpenItemImageDialog.InitialDirectory = _baseImageFolder;
            OpenItemImageDialog.Filter = "All files |*.*";
            OpenItemImageDialog.ShowDialog();
        }

        private void BtnDeleteItemImage_Click(object sender, EventArgs e)
        {
            PicBoxItemImage.Image = null;
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
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
                        if(!string.IsNullOrWhiteSpace(_uploadedImagePath))
                        {
                            File.Copy(_uploadedImagePath, destinationFilePath, true);
                        }
                        else
                        {
                            File.Copy(PicBoxItemImage.ImageLocation, destinationFilePath, true);
                        }
                    }
                }

                var date = DateTime.Now;
                var pricedItem = new PricedItem
                {
                    ItemId = _selectedItemId,
                    CustomUnit = ComboCustomItemUnit.Text,
                    Volume = Convert.ToInt64(TxtVolume.Text),
                    SubCode = TxtItemSubCode.Text,
                    ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text),
                    Profit = Convert.ToDecimal(TxtProfitAmount.Text),
                    SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text),
                    ImagePath = destinationFilePath,
                    AddedDate = date,
                    UpdatedDate = date
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
                throw ex;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult deleteResult = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(deleteResult == DialogResult.Yes)
                {
                    var fileName = TxtItemCode.Text + "-" + TxtItemName.Text + "-" + TxtItemBrand.Text + "-" + TxtVolume.Text + ".jpg";
                    var filePath = Path.Combine(_baseImageFolder, ITEM_IMAGE_FOLDER, fileName);
                    if(File.Exists(filePath))
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
                throw ex;
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
            catch(Exception ex)
            {
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
                if ((ComboItemUnit.Text == Constants.KILOGRAM && ComboCustomItemUnit.Text == Constants.GRAM)
                    || (ComboItemUnit.Text == Constants.LITER && ComboCustomItemUnit.Text == Constants.MILLI_LITER))
                {
                    TxtCustomPerUnitValue.Text = ((Convert.ToDecimal(TxtPerUnitValue.Text) * Convert.ToDecimal(TxtVolume.Text)) / 1000).ToString();
                }
                else
                {
                    TxtCustomPerUnitValue.Text = (Convert.ToDecimal(TxtPerUnitValue.Text) * Convert.ToDecimal(TxtVolume.Text)).ToString();
                }

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
                BtnAddItemImage.Enabled = true;
                BtnDeleteItemImage.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                TxtVolume.Enabled = true;
                TxtProfitPercent.Enabled = true;
                TxtItemSubCode.Enabled = true;

                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddItemImage.Enabled = true;
                BtnDeleteItemImage.Enabled = true;
            }
            else
            {
                TxtItemCode.Enabled = false;
                TxtItemName.Enabled = false;
                TxtItemBrand.Enabled = false;
                ComboItemUnit.Enabled = false;
                TxtTotalStock.Enabled = false;
                TxtPerUnitValue.Enabled = false;
                ComboCustomItemUnit.Enabled = false;
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
                BtnAddItemImage.Enabled = false;
                BtnDeleteItemImage.Enabled = false;
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
            ComboCustomItemUnit.Text = string.Empty;
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
                StockFilter filter = new StockFilter
                {
                    ItemCode = item.Code
                };

                TxtTotalStock.Text = (_purchasedItemService.GetPurchasedItemTotalQuantity(filter) - _soldItemService.GetSoldItemTotalQuantity(filter)).ToString();

                var stocks = _stockService.GetStocks(filter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var stockViewList = UtilityService.CalculateStock(stocks.ToList());
                var latestStockView = stockViewList.GroupBy(x => x.ItemCode)
                    .Select(x => x.OrderByDescending(y => y.AddedDate).FirstOrDefault())
                    .ToList();
                
                var perUnitValue = latestStockView.Sum(x => Math.Round(x.PerUnitValue, 2));
                TxtPerUnitValue.Text = perUnitValue.ToString();

                TxtItemSubCode.Text = pricedItem.SubCode;
                ComboCustomItemUnit.Text = pricedItem.CustomUnit;
                TxtVolume.Text = pricedItem.Volume.ToString();

                if ((ComboItemUnit.Text == Constants.KILOGRAM && ComboCustomItemUnit.Text == Constants.GRAM)
                || (ComboItemUnit.Text == Constants.LITER && ComboCustomItemUnit.Text == Constants.MILLI_LITER))
                {
                    TxtCustomPerUnitValue.Text = ((perUnitValue * pricedItem.Volume) / 1000).ToString();
                }
                else
                {
                    TxtCustomPerUnitValue.Text = (perUnitValue * pricedItem.Volume).ToString();
                }

                var profitPercent = pricedItem.ProfitPercent;
                TxtProfitPercent.Text = profitPercent.ToString();
                var customPerUnitValue = string.IsNullOrWhiteSpace(TxtCustomPerUnitValue.Text) ? 0.00M : Convert.ToDecimal(TxtCustomPerUnitValue.Text);
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
                ComboCustomItemUnit.Text = item.Unit;
                StockFilter filter = new StockFilter
                {
                    ItemCode = item.Code
                };

                TxtTotalStock.Text = (_purchasedItemService.GetPurchasedItemTotalQuantity(filter) - _soldItemService.GetSoldItemTotalQuantity(filter)).ToString();

                var stocks = _stockService.GetStocks(filter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var stockViewList = UtilityService.CalculateStock(stocks.ToList());
                var latestStockView = stockViewList.GroupBy(x => x.ItemCode)
                    .Select(x => x.OrderByDescending(y => y.AddedDate).FirstOrDefault())
                    .ToList();
                var perUnitValue = latestStockView.Sum(x => Math.Round(x.PerUnitValue, 2));
                TxtPerUnitValue.Text = perUnitValue.ToString();

                EnableFields();
                EnableFields(Action.PopulateUnpricedItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadItemUnits()
        {
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

        private void LoadCustomItemUnits()
        {
            ComboCustomItemUnit.ValueMember = "Id";
            ComboCustomItemUnit.DisplayMember = "Value";

            ComboCustomItemUnit.Items.Add(new ComboBoxItem { Id = Constants.KILOGRAM, Value = Constants.KILOGRAM });
            ComboCustomItemUnit.Items.Add(new ComboBoxItem { Id = Constants.GRAM, Value = Constants.GRAM });
            ComboCustomItemUnit.Items.Add(new ComboBoxItem { Id = Constants.LITER, Value = Constants.LITER });
            ComboCustomItemUnit.Items.Add(new ComboBoxItem { Id = Constants.MILLI_LITER, Value = Constants.MILLI_LITER });
            ComboCustomItemUnit.Items.Add(new ComboBoxItem { Id = Constants.PIECES, Value = Constants.PIECES });
            ComboCustomItemUnit.Items.Add(new ComboBoxItem { Id = Constants.PACKET, Value = Constants.PACKET });
            ComboCustomItemUnit.Items.Add(new ComboBoxItem { Id = Constants.BAG, Value = Constants.BAG });
            ComboCustomItemUnit.Items.Add(new ComboBoxItem { Id = Constants.BOTTLE, Value = Constants.BOTTLE });
            ComboCustomItemUnit.Items.Add(new ComboBoxItem { Id = Constants.CAN, Value = Constants.CAN });
            ComboCustomItemUnit.Items.Add(new ComboBoxItem { Id = Constants.DOZEN, Value = Constants.DOZEN });
        }

        #endregion
    }
}
