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
        private string _documentsDirectory;
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
            _documentsDirectory = ConfigurationManager.AppSettings["DocumentsDirectory"].ToString();
        }
        #endregion

        #region Button Click Event
        private void BtnShowPricedItem_Click(object sender, EventArgs e)
        {
            PricedItemListForm pricedItemListForm = new PricedItemListForm(_pricedItemService, this);
            pricedItemListForm.Show();
        }

        private void BtnShowUnpricedItem_Click(object sender, EventArgs e)
        {
            UnpricedItemListForm unpricedItemListForm = new UnpricedItemListForm(_pricedItemService, this);
            unpricedItemListForm.Show();
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
                var pricedItem = new PricedItem
                {
                    ItemId = _selectedItemId,
                    ItemSubCode = TxtItemSubCode.Text,
                    Price = Convert.ToDecimal(TxtPerUnitValue.Text),
                    Quantity = Convert.ToInt32(TxtQuantity.Text),
                    TotalPrice = Convert.ToDecimal(TxtTotalPrice.Text),
                    ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text),
                    Profit = Convert.ToDecimal(TxtProfitAmount.Text),
                    SalesPrice = Convert.ToDecimal(TxtSalesPrice.Text),
                    SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text),
                    UpdatedDate = DateTime.Now
                };

                _pricedItemService.UpdatePricedItem(_selectedId, pricedItem);

                DialogResult result = MessageBox.Show(TxtItemCode.Text + "-" + TxtItemSubCode.Text + " has been updated successfully.", "Message", MessageBoxButtons.OK);
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
            OpenItemImageDialog.InitialDirectory = _documentsDirectory;
            OpenItemImageDialog.Filter = "All files |*.*";
            OpenItemImageDialog.ShowDialog();
        }

        private void BtnDeleteItemImage_Click(object sender, EventArgs e)
        {
            try
            {
                var fileName = TxtItemCode.Text + "-" + TxtItemName.Text + "-" + TxtItemName.Text + ".jpg";
                var filePath = Path.Combine(_documentsDirectory, ITEM_IMAGE_FOLDER, fileName);
                if (File.Exists(filePath))
                {
                    PicBoxItemImage.Image = null;
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

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
                var date = DateTime.Now;
                var pricedItem = new PricedItem
                {
                    ItemId = _selectedItemId,
                    ItemSubCode = TxtItemSubCode.Text,
                    Price = Convert.ToDecimal(TxtPerUnitValue.Text),
                    Quantity = Convert.ToInt32(TxtQuantity.Text),
                    TotalPrice = Convert.ToDecimal(TxtTotalPrice.Text),
                    ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text),
                    Profit = Convert.ToDecimal(TxtProfitAmount.Text),
                    SalesPrice = Convert.ToDecimal(TxtSalesPrice.Text),
                    SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text),
                    AddedDate = date,
                    UpdatedDate = date
                };

                _pricedItemService.AddPricedItem(pricedItem);

                DialogResult result = MessageBox.Show(TxtItemCode.Text + "-" + TxtItemSubCode.Text + " has been added successfully.", "Message", MessageBoxButtons.OK);
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
                _pricedItemService.DeletePricedItem(_selectedId);

                DialogResult result = MessageBox.Show(TxtItemCode.Text + "-" + TxtItemSubCode.Text + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
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

        #endregion

        #region OpenFileDialog Event
        private void OpenItemImageDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Activate();
                string[] files = OpenItemImageDialog.FileNames;
                _uploadedImagePath = files[0];
                PicBoxItemImage.Image = Image.FromFile(_uploadedImagePath);

                if (!Directory.Exists(Path.Combine(_documentsDirectory, ITEM_IMAGE_FOLDER)))
                {
                    UtilityService.CreateFolder(_documentsDirectory, ITEM_IMAGE_FOLDER);
                }

                var fileName = TxtItemCode.Text + "-" + TxtItemName.Text + "-" + TxtItemName.Text;
                var sourceFileName = _uploadedImagePath;
                var destinationFileName = Path.Combine(_documentsDirectory, ITEM_IMAGE_FOLDER) + "\\" + fileName + ".jpg"; // + Path.GetExtension(sourceFileName);
                File.Copy(sourceFileName, destinationFileName, true);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Textbox Event

        private void TxtCurrentPurchasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtCurrentPurchasePrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtPerUnitValue.Text))
            {
                if(!string.IsNullOrWhiteSpace(TxtQuantity.Text))
                {
                    TxtTotalPrice.Text = (Convert.ToDecimal(TxtPerUnitValue.Text) * Convert.ToDecimal(TxtQuantity.Text)).ToString("0.00");
                    if (!string.IsNullOrWhiteSpace(TxtProfitPercent.Text))
                    {
                        TxtProfitAmount.Text = (Convert.ToDecimal(TxtTotalPrice.Text) * (Convert.ToDecimal(TxtProfitPercent.Text) / 100)).ToString("0.00");
                        TxtSalesPrice.Text = (Convert.ToDecimal(TxtTotalPrice.Text) + Convert.ToDecimal(TxtProfitAmount.Text)).ToString("0.00");
                        TxtSalesPricePerUnit.Text = (Convert.ToDecimal(TxtSalesPrice.Text) / Convert.ToDecimal(TxtQuantity.Text)).ToString("0.00");
                    }
                    else
                    {
                        TxtProfitAmount.Text = string.Empty;
                        TxtSalesPrice.Text = string.Empty;
                        TxtSalesPricePerUnit.Text = string.Empty;
                    }
                }
            }
            else
            {
                TxtTotalPrice.Text = string.Empty;
                TxtProfitAmount.Text = string.Empty;
                TxtSalesPrice.Text = string.Empty;
                TxtSalesPricePerUnit.Text = string.Empty;
            }
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TxtQuantity.Text))
            {
                TxtTotalPrice.Text = (Convert.ToDecimal(TxtPerUnitValue.Text) * Convert.ToDecimal(TxtQuantity.Text)).ToString("0.00");
                if (!string.IsNullOrWhiteSpace(TxtProfitPercent.Text))
                {
                    TxtProfitAmount.Text = (Convert.ToDecimal(TxtTotalPrice.Text) * (Convert.ToDecimal(TxtProfitPercent.Text) / 100)).ToString("0.00");
                    TxtSalesPrice.Text = (Convert.ToDecimal(TxtTotalPrice.Text) + Convert.ToDecimal(TxtProfitAmount.Text)).ToString("0.00");
                    TxtSalesPricePerUnit.Text = (Convert.ToDecimal(TxtSalesPrice.Text) / Convert.ToDecimal(TxtQuantity.Text)).ToString("0.00");
                }
                else
                {
                    TxtProfitAmount.Text = string.Empty;
                    TxtSalesPrice.Text = string.Empty;
                    TxtSalesPricePerUnit.Text = string.Empty;
                }
            }
            else
            {
                TxtTotalPrice.Text = string.Empty;
                TxtProfitAmount.Text = string.Empty;
                TxtSalesPrice.Text = string.Empty;
                TxtSalesPricePerUnit.Text = string.Empty;
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
            if (!string.IsNullOrWhiteSpace(TxtProfitPercent.Text))
            {
                TxtProfitAmount.Text = (Convert.ToDecimal(TxtTotalPrice.Text) * (Convert.ToDecimal(TxtProfitPercent.Text) / 100)).ToString("0.00");
                TxtSalesPrice.Text = (Convert.ToDecimal(TxtTotalPrice.Text) + Convert.ToDecimal(TxtProfitAmount.Text)).ToString("0.00");
                TxtSalesPricePerUnit.Text = (Convert.ToDecimal(TxtSalesPrice.Text) / Convert.ToDecimal(TxtQuantity.Text)).ToString("0.00");
            }  
            else
            {
                TxtProfitAmount.Text = string.Empty;
                TxtSalesPrice.Text = string.Empty;
                TxtSalesPricePerUnit.Text = string.Empty;
            }
        }
        #endregion

        #region Helper Methods
        private void EnableFields(Action action = Action.None)
        {
            if(action == Action.PopulatePricedItem)
            {
                BtnAddNew.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddItemImage.Enabled = true;
                BtnDeleteItemImage.Enabled = true;
            }
            else if (action == Action.PopulateUnpricedItem)
            {
                BtnAddNew.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddItemImage.Enabled = true;
            }
            else if(action == Action.Add)
            {
                TxtItemSubCode.Enabled = true;
                TxtPerUnitValue.Enabled = true;
                TxtQuantity.Enabled = true;
                TxtProfitPercent.Enabled = true;

                BtnSave.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddItemImage.Enabled = true;
                BtnDeleteItemImage.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                TxtItemSubCode.Enabled = true;
                TxtPerUnitValue.Enabled = true;
                TxtQuantity.Enabled = true;
                TxtProfitPercent.Enabled = true;

                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddItemImage.Enabled = true;
                BtnDeleteItemImage.Enabled = true;
            }
            else
            {
                TxtItemCode.Enabled = false;
                TxtItemSubCode.Enabled = false;
                TxtItemName.Enabled = false;
                TxtItemBrand.Enabled = false;
                TxtUnit.Enabled = false;
                TxtTotalStock.Enabled = false;
                TxtPerUnitValue.Enabled = false;
                TxtQuantity.Enabled = false;
                TxtTotalPrice.Enabled = false;
                TxtProfitPercent.Enabled = false;
                TxtProfitAmount.Enabled = false;
                TxtSalesPrice.Enabled = false;
                TxtSalesPricePerUnit.Enabled = false;

                BtnAddNew.Enabled = false;
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
            TxtItemSubCode.Clear();
            TxtItemName.Clear();
            TxtItemBrand.Clear();
            TxtUnit.Clear();
            TxtTotalStock.Clear();
            TxtPerUnitValue.Clear();
            TxtQuantity.Clear();
            TxtTotalPrice.Clear();
            TxtProfitPercent.Clear();
            TxtProfitAmount.Clear();
            TxtSalesPrice.Clear();
            TxtSalesPricePerUnit.Clear();
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
                TxtItemSubCode.Text = pricedItem.ItemSubCode;
                TxtItemName.Text = item.Name;
                TxtItemBrand.Text = item.Brand;
                TxtUnit.Text = item.Unit;
                StockFilterView filter = new StockFilterView
                {
                    ItemCode = item.Code
                };
                TxtTotalStock.Text = (_purchasedItemService.GetPurchasedItemTotalQuantity(filter) - _soldItemService.GetSoldItemTotalQuantity(filter)).ToString();

                var stocks = _stockService.GetStocks(filter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var stockViewList = UtilityService.CalculateStock(stocks.ToList());
                var latestStockView = stockViewList.GroupBy(x => x.ItemCode)
                    .Select(x => x.OrderByDescending(y => y.AddedDate).FirstOrDefault())
                    .ToList();
                
                TxtPerUnitValue.Text = UtilityService.GetTruncatedValue(latestStockView.Sum(x => x.PerUnitValue), 2).ToString();

                TxtQuantity.Text = pricedItem.Quantity.ToString();
                TxtTotalPrice.Text = (Convert.ToDecimal(TxtPerUnitValue.Text) * Convert.ToInt64(TxtQuantity.Text)).ToString("0.00");
                TxtProfitPercent.Text = pricedItem.ProfitPercent.ToString();
                TxtProfitAmount.Text = (Convert.ToDecimal(TxtTotalPrice.Text) * (Convert.ToDecimal(TxtProfitPercent.Text) / 100)).ToString("0.00");
                TxtSalesPrice.Text = (Convert.ToDecimal(TxtTotalPrice.Text) + Convert.ToDecimal(TxtProfitAmount.Text)).ToString("0.00");
                TxtSalesPricePerUnit.Text = (Convert.ToDecimal(TxtSalesPrice.Text) / Convert.ToDecimal(TxtQuantity.Text)).ToString("0.00");

                var fileName = TxtItemCode.Text + "-" + TxtItemName.Text + "-" + TxtItemName.Text + ".jpg";
                var filePath = Path.Combine(_documentsDirectory, ITEM_IMAGE_FOLDER, fileName);

                if (File.Exists(filePath))
                {
                    //PicBoxItemImage.Image = filePath;
                    PicBoxItemImage.ImageLocation = filePath;
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
                TxtUnit.Text = item.Unit;
                StockFilterView filter = new StockFilterView
                {
                    ItemCode = item.Code
                };

                TxtTotalStock.Text = (_purchasedItemService.GetPurchasedItemTotalQuantity(filter) - _soldItemService.GetSoldItemTotalQuantity(filter)).ToString();

                var stocks = _stockService.GetStocks(filter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var stockViewList = UtilityService.CalculateStock(stocks.ToList());
                var latestStockView = stockViewList.GroupBy(x => x.ItemCode)
                    .Select(x => x.OrderByDescending(y => y.AddedDate).FirstOrDefault())
                    .ToList();
                TxtPerUnitValue.Text = latestStockView.Sum(x => UtilityService.GetTruncatedValue(x.PerUnitValue, 2)).ToString();

                var fileName = TxtItemCode.Text + "-" + TxtItemName.Text + "-" + TxtItemName.Text + ".jpg";
                var filePath = Path.Combine(_documentsDirectory, ITEM_IMAGE_FOLDER, fileName);

                if (File.Exists(filePath))
                {
                    //PicBoxItemImage.Image = filePath;
                    PicBoxItemImage.ImageLocation = filePath;
                }

                EnableFields();
                EnableFields(Action.PopulateUnpricedItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
