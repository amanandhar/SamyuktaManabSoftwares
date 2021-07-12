using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ItemForm : Form, IItemListForm, IPreparedItemListForm
    {
        private readonly IItemService _itemService;
        private readonly IItemTransactionService _itemTransactionService;
        private readonly ICodedItemService _preparedItemService;
        public DashboardForm _dashboard;
        private string _documentsDirectory;
        private const string ITEM_IMAGE_FOLDER = "Items";
        private string _uploadedImagePath = string.Empty;
        private long selectedItemId = 0;
        private long selectedPreparedItemId = 0;

        #region Constructor
        public ItemForm(IItemService itemService, IItemTransactionService itemTransactionService, 
            ICodedItemService preparedItemService, DashboardForm dashboardForm)
        {
            InitializeComponent();

            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            _preparedItemService = preparedItemService;
            _dashboard = dashboardForm;
        }
        #endregion

        #region Form Load Event
        private void ItemForm_Load(object sender, EventArgs e)
        {
            _documentsDirectory = ConfigurationManager.AppSettings["DocumentsDirectory"].ToString();
        }
        #endregion

        #region Button Click Events
        private void BtnItemSearch_Click(object sender, EventArgs e)
        {
            ItemListForm itemListForm = new ItemListForm(_itemService, this, true);
            itemListForm.Show();
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
                var preparedItem = new CodedItem
                {
                    ItemId = selectedPreparedItemId,
                    ItemSubCode = TxtItemSubCode.Text,
                    Unit = ComboItemUnit.Text,
                    Stock = Convert.ToInt64(TxtTotalStock.Text),
                    PurchasePrice = Convert.ToDecimal(TxtNewPurchasePrice.Text),
                    CurrentPurchasePrice = Convert.ToDecimal(TxtCurrentPurchasePrice.Text),
                    Quantity = Convert.ToInt64(TxtQuantity.Text),
                    Price = Convert.ToDecimal(TxtTotalPrice.Text),
                    ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text),
                    ProfitAmount = Convert.ToDecimal(TxtProfitAmount.Text),
                    SalesPrice = Convert.ToDecimal(TxtSalesPrice.Text),
                    SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text)
                };

                _preparedItemService.UpdatePreparedItem(selectedPreparedItemId, preparedItem);

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

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            ClearAllFields();
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
                var preparedItem = new CodedItem
                {
                    ItemId = selectedItemId,
                    ItemSubCode = TxtItemSubCode.Text,
                    Unit = ComboItemUnit.Text,
                    Stock = Convert.ToInt64(TxtTotalStock.Text),
                    PurchasePrice = Convert.ToDecimal(TxtNewPurchasePrice.Text),
                    CurrentPurchasePrice = Convert.ToDecimal(TxtCurrentPurchasePrice.Text),
                    Quantity = Convert.ToInt64(TxtQuantity.Text),
                    Price = Convert.ToDecimal(TxtTotalPrice.Text),
                    ProfitPercent = Convert.ToDecimal(TxtProfitPercent.Text),
                    ProfitAmount = Convert.ToDecimal(TxtProfitAmount.Text),
                    SalesPrice = Convert.ToDecimal(TxtSalesPrice.Text),
                    SalesPricePerUnit = Convert.ToDecimal(TxtSalesPricePerUnit.Text)
                };

                _preparedItemService.AddPreparedItem(preparedItem);

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

        private void BtnShowPreparedItem_Click(object sender, EventArgs e)
        {
            PreparedItemListForm preparedItemListForm = new PreparedItemListForm(_preparedItemService, this);
            preparedItemListForm.Show();
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
            TxtSalesPrice.Clear() ;
            TxtSalesPricePerUnit.Clear();
        }

        public void PopulateItem(long itemId)
        {
            try
            {
                selectedItemId = itemId;
                var itemTransaction = _itemTransactionService.GetItem(itemId);
                var item = _itemService.GetItem(itemId);
                TxtItemCode.Text = item.Code;
                TxtItemName.Text = item.Name;
                TxtItemBrand.Text = item.Brand;
                
                ComboItemUnit.Text = itemTransaction.Unit.ToString();

                StockFilterView filter = new StockFilterView
                {
                    ItemCode = item.Code
                };

                TxtTotalStock.Text = (_itemTransactionService.GetTotalPurchaseItemCount(filter) - _itemTransactionService.GetTotalSalesItemCount(filter)).ToString();

                TxtNewPurchasePrice.Text = itemTransaction.PurchasePrice.ToString();

                var fileName = TxtItemCode.Text + "-" + TxtItemName.Text + "-" + TxtItemName.Text + ".jpg";
                var filePath = Path.Combine(_documentsDirectory, ITEM_IMAGE_FOLDER, fileName);
                if (File.Exists(filePath))
                {
                    //PicBoxItemImage.Image = filePath;
                    PicBoxItemImage.ImageLocation = filePath;
                }

                EnableFields(false);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void PopulatePreparedItem(long preparedItemId)
        {
            try
            {
                selectedPreparedItemId = preparedItemId;
                var preparedItem = _preparedItemService.GetPreparedItem(preparedItemId);
                var item = _itemService.GetItem(preparedItem.ItemId);

                TxtItemCode.Text = item.Code;
                TxtItemSubCode.Text = preparedItem.ItemSubCode;
                TxtItemName.Text = item.Name;
                TxtItemBrand.Text = item.Brand;

                ComboItemUnit.Text = preparedItem.Unit;
                StockFilterView filter = new StockFilterView
                {
                    ItemCode = item.Code
                };
                TxtTotalStock.Text = (_itemTransactionService.GetTotalPurchaseItemCount(filter) - _itemTransactionService.GetTotalSalesItemCount(filter)).ToString();
                TxtCurrentPurchasePrice.Text = preparedItem.CurrentPurchasePrice.ToString();
                TxtNewPurchasePrice.Text = preparedItem.PurchasePrice.ToString();
                TxtQuantity.Text = preparedItem.Quantity.ToString();
                TxtTotalPrice.Text = preparedItem.Price.ToString();
                TxtProfitPercent.Text = preparedItem.ProfitPercent.ToString();
                TxtProfitAmount.Text = preparedItem.ProfitAmount.ToString();
                TxtSalesPrice.Text = preparedItem.SalesPrice.ToString();
                TxtSalesPricePerUnit.Text = preparedItem.SalesPricePerUnit.ToString();

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

        #region OpenFileDialog Events
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

        #region Textbox Events

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
    }
}
