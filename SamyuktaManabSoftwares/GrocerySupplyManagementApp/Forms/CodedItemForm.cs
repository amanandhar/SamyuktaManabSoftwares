using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class CodedItemForm : Form, ICodedItemListForm
    {
        private readonly IItemService _itemService;
        private readonly ICodedItemService _codedItemService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;

        public DashboardForm _dashboard;
        private string _documentsDirectory;
        private const string ITEM_IMAGE_FOLDER = "Items";
        private string _uploadedImagePath = string.Empty;
        private long _selectedId = 0;
        private long _selectedItemId = 0;

        #region Constructor
        public CodedItemForm(IItemService itemService, ICodedItemService codedItemService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService, 
            DashboardForm dashboardForm)
        {
            InitializeComponent();

            _itemService = itemService;
            _codedItemService = codedItemService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
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
        private void BtnShowCodedItem_Click(object sender, EventArgs e)
        {
            CodedItemListForm codedItemListForm = new CodedItemListForm(_codedItemService, this, false);
            codedItemListForm.Show();
        }

        private void BtnPurchasedItem_Click(object sender, EventArgs e)
        {
            CodedItemListForm codedItemListForm = new CodedItemListForm(_codedItemService, this, true);
            codedItemListForm.Show();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            TxtCurrentPurchasePrice.Enabled = true;
            TxtQuantity.Enabled = true;
            TxtProfitPercent.Enabled = true;

            TxtCurrentPurchasePrice.Focus();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var codedItem = new CodedItem
                {
                    ItemId = _selectedItemId,
                    ItemSubCode = TxtItemSubCode.Text,
                    Unit = ComboItemUnit.Text,
                    Price = Convert.ToDecimal(TxtNewPurchasePrice.Text),
                    Quantity = Convert.ToInt64(TxtQuantity.Text),
                    TotalPrice = Convert.ToDecimal(TxtTotalPrice.Text),
                    ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text),
                    ProfitAmount = Convert.ToDecimal(TxtProfitAmount.Text),
                    SalesPrice = Convert.ToDecimal(TxtSalesPrice.Text),
                    SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text),
                };

                _codedItemService.UpdateCodedItem(_selectedItemId, codedItem);

                DialogResult result = MessageBox.Show(TxtItemCode.Text + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields(false);
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
            TxtItemSubCode.Enabled = true;
            TxtCurrentPurchasePrice.Enabled = true;
            TxtQuantity.Enabled = true;
            TxtProfitPercent.Enabled = true;

            TxtItemSubCode.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var codedItem = new CodedItem
                {
                    ItemId = _selectedItemId,
                    ItemSubCode = TxtItemSubCode.Text,
                    Unit = ComboItemUnit.Text,
                    Price = Convert.ToDecimal(TxtCurrentPurchasePrice.Text),
                    Quantity = Convert.ToInt64(TxtQuantity.Text),
                    TotalPrice = Convert.ToDecimal(TxtTotalPrice.Text),
                    ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text),
                    ProfitAmount = Convert.ToDecimal(TxtProfitAmount.Text),
                    SalesPrice = Convert.ToDecimal(TxtSalesPrice.Text),
                    SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text),
                    Date = DateTime.Now
                };

                _codedItemService.AddCodedItem(codedItem);

                DialogResult result = MessageBox.Show(TxtItemCode.Text + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            ClearAllFields();
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
            if (!string.IsNullOrWhiteSpace(TxtCurrentPurchasePrice.Text))
            {
                if(!string.IsNullOrWhiteSpace(TxtQuantity.Text))
                {
                    TxtTotalPrice.Text = (Convert.ToDecimal(TxtCurrentPurchasePrice.Text) * Convert.ToDecimal(TxtQuantity.Text)).ToString("0.00");
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
                TxtTotalPrice.Text = (Convert.ToDecimal(TxtCurrentPurchasePrice.Text) * Convert.ToDecimal(TxtQuantity.Text)).ToString("0.00");
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
        private void EnableFields(bool option = true)
        {
            TxtItemCode.Enabled = option;
            TxtItemSubCode.Enabled = option;
            TxtSalesPricePerUnit.Enabled = option;
            TxtItemName.Enabled = option;
            TxtItemBrand.Enabled = option;
            ComboItemUnit.Enabled = option;
            TxtNewPurchasePrice.Enabled = option;
            TxtQuantity.Enabled = option;
            TxtTotalPrice.Enabled = option;
            TxtProfitPercent.Enabled = option;
            TxtProfitAmount.Enabled = option;
            TxtSalesPrice.Enabled = option;
        }

        private void ClearAllFields()
        {
            TxtItemCode.Clear();
            TxtItemSubCode.Clear();
            TxtItemName.Clear();
            TxtItemBrand.Clear();
            ComboItemUnit.Text = string.Empty;
            TxtTotalStock.Clear();
            TxtCurrentPurchasePrice.Clear();
            TxtNewPurchasePrice.Clear();
            TxtQuantity.Clear();
            TxtTotalPrice.Clear();
            TxtProfitPercent.Clear();
            TxtProfitAmount.Clear();
            TxtSalesPrice.Clear();
            TxtSalesPricePerUnit.Clear();
        }

        public void PopulateCodedItem(bool isItemCoded, long id)
        {
            try
            {
                ClearAllFields();
                _selectedId = id;
                if(isItemCoded)
                {
                    var codedItem = _codedItemService.GetCodedItem(_selectedId);
                    _selectedItemId = codedItem.ItemId;
                    var item = _itemService.GetItem(_selectedItemId);

                    TxtItemCode.Text = item.Code;
                    TxtItemSubCode.Text = codedItem.ItemSubCode;
                    TxtItemName.Text = item.Name;
                    TxtItemBrand.Text = item.Brand;
                    ComboItemUnit.Text = codedItem.Unit;
                    StockFilterView filter = new StockFilterView
                    {
                        ItemCode = item.Code
                    };
                    TxtTotalStock.Text = (_purchasedItemService.GetPurchasedItemTotalQuantity(filter) - _soldItemService.GetSoldItemTotalQuantity(filter)).ToString();
                    TxtNewPurchasePrice.Text = _purchasedItemService.GetLatestPurchasePrice(_selectedItemId).ToString();
                    TxtCurrentPurchasePrice.Text = codedItem.Price.ToString();
                    TxtQuantity.Text = codedItem.Quantity.ToString();
                    TxtTotalPrice.Text = codedItem.TotalPrice.ToString();
                    TxtProfitPercent.Text = codedItem.ProfitPercent.ToString();
                    TxtProfitAmount.Text = codedItem.ProfitAmount.ToString();
                    TxtSalesPrice.Text = codedItem.SalesPrice.ToString();
                    TxtSalesPricePerUnit.Text = codedItem.SalesPricePerUnit.ToString();
                }
                else
                {
                    _selectedId = id;
                    var purchasedItem = _purchasedItemService.GetPurchasedItem(_selectedId);
                    _selectedItemId = purchasedItem.ItemId;
                    var item = _itemService.GetItem(_selectedItemId);
                    TxtItemCode.Text = item.Code;
                    TxtItemName.Text = item.Name;
                    TxtItemBrand.Text = item.Brand;
                    ComboItemUnit.Text = purchasedItem.Unit.ToString();
                    StockFilterView filter = new StockFilterView
                    {
                        ItemCode = item.Code
                    };

                    TxtTotalStock.Text = (_purchasedItemService.GetPurchasedItemTotalQuantity(filter) - _soldItemService.GetSoldItemTotalQuantity(filter)).ToString();
                    TxtNewPurchasePrice.Text = _purchasedItemService.GetLatestPurchasePrice(_selectedItemId).ToString();
                    TxtCurrentPurchasePrice.Text = purchasedItem.Price.ToString();
                }

                var fileName = TxtItemCode.Text + "-" + TxtItemName.Text + "-" + TxtItemName.Text + ".jpg";
                var filePath = Path.Combine(_documentsDirectory, ITEM_IMAGE_FOLDER, fileName);

                if (File.Exists(filePath))
                {
                    //PicBoxItemImage.Image = filePath;
                    PicBoxItemImage.ImageLocation = filePath;
                }

                EnableFields(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
