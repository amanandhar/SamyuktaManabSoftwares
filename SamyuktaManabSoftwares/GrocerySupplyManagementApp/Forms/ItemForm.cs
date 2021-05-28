using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ItemForm : Form, IItemListForm
    {
        private readonly IItemService _itemService;
        private readonly IItemTransactionService _itemTransactionService;
        public DashboardForm _dashboard;
        private string _documentsDirectory;
        private const string ITEM_IMAGE_FOLDER = "Items";
        private string _uploadedImagePath = string.Empty;
        private long selectedItemId = 0;

        public ItemForm(IItemService itemService, IItemTransactionService itemTransactionService, DashboardForm dashboardForm)
        {
            InitializeComponent();

            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            _dashboard = dashboardForm;
        }

        #region Form Load Event
        private void ItemForm_Load(object sender, EventArgs e)
        {
            _documentsDirectory = ConfigurationManager.AppSettings["DocumentsDirectory"].ToString();
        }
        #endregion

        #region Button Click Events
        private void BtnItemSearch_Click(object sender, EventArgs e)
        {
            ItemListForm itemListForm = new ItemListForm(_itemService, _itemTransactionService, this, true);
            itemListForm.Show();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields(true);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var itemName = TextBoxItemName.Text;

                var item = new Item
                {
                    Id = selectedItemId,
                    Name = TextBoxItemName.Text,
                    Brand = TextBoxItemBrand.Text,
                    Code = TextBoxItemCode.Text,
                };

                var itemTrasaction = new ItemTransaction
                { 
                    ItemId = selectedItemId,
                    Unit = ComboItemUnit.Text,
                    PurchasePrice = Convert.ToDecimal(string.IsNullOrWhiteSpace(TextBoxPurchasePrice.Text) ? "0" : TextBoxPurchasePrice.Text),
                    SellPrice = Convert.ToDecimal(string.IsNullOrWhiteSpace(TextBoxSalesPrice.Text) ? "0" : TextBoxSalesPrice.Text),
                };

                _itemService.UpdateItem(selectedItemId, item);
                _itemTransactionService.UpdateItem(itemTrasaction);

                DialogResult result = MessageBox.Show(itemName + " has been updated successfully.", "Message", MessageBoxButtons.OK);
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
                var fileName = TextBoxItemCode.Text + "-" + TextBoxItemName.Text + "-" + TextBoxItemName.Text + ".jpg";
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

        #endregion

        #region Helper Methods
        private void EnableFields(bool option = true)
        {
            TextBoxItemCode.Enabled = option;
            TextBoxItemName.Enabled = option;
            TextBoxItemBrand.Enabled = option;
            ComboItemUnit.Enabled = option;
            TextBoxPurchasePrice.Enabled = option;
            TextBoxSalesPrice.Enabled = option;
        }

        private void ClearAllFields()
        {
            TextBoxItemCode.Clear();
            TextBoxItemName.Clear();
            TextBoxItemBrand.Clear();
            ComboItemUnit.Text = string.Empty;
            TextBoxPurchasePrice.Clear();
            TextBoxSalesPrice.Clear() ;
        }

        public void PopulateItem(long itemId)
        {
            try
            {
                selectedItemId = itemId;
                var itemTransaction = _itemTransactionService.GetItem(itemId);
                var item = _itemService.GetItem(itemId);
                TextBoxItemCode.Text = item.Code;
                TextBoxItemName.Text = item.Name;
                TextBoxItemBrand.Text = item.Brand;
                
                ComboItemUnit.Text = itemTransaction.Unit.ToString();
                TextBoxPurchasePrice.Text = itemTransaction.PurchasePrice.ToString();
                TextBoxSalesPrice.Text = itemTransaction.SellPrice.ToString();

                var fileName = TextBoxItemCode.Text + "-" + TextBoxItemName.Text + "-" + TextBoxItemName.Text + ".jpg";
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

                var fileName = TextBoxItemCode.Text + "-" + TextBoxItemName.Text + "-" + TextBoxItemName.Text;
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
    }
}
