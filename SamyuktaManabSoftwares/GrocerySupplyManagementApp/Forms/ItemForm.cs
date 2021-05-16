using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ItemForm : Form
    {
        private readonly IItemService _itemService;
        public DashboardForm _dashboard;
        private string _documentsDirectory;
        private const string ITEM_IMAGE_FOLDER = "Items";
        private string _uploadedImagePath = string.Empty;
        public ItemForm(IItemService itemService, DashboardForm dashboardForm)
        {
            InitializeComponent();

            _itemService = itemService;
            _dashboard = dashboardForm;
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            _documentsDirectory = ConfigurationManager.AppSettings["DocumentsDirectory"].ToString();
        }

        #region Button Click Events
        private void BtnItemSearch_Click(object sender, EventArgs e)
        {
            ItemListForm itemListForm = new ItemListForm(_itemService, this);
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
                    Code = TextBoxItemCode.Text,
                    Name = TextBoxItemName.Text,
                    Brand = TextBoxItemBrand.Text,
                    Unit = ComboItemUnit.Text,
                    PurchasePrice = Convert.ToDecimal(string.IsNullOrWhiteSpace(TextBoxPurchasePrice.Text) ? "0" : TextBoxPurchasePrice.Text),
                    SellPrice = Convert.ToDecimal(string.IsNullOrWhiteSpace(TextBoxSalesPrice.Text) ? "0" : TextBoxSalesPrice.Text),
                };

                _itemService.UpdateItem(itemName, item);

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

        public void PopulateItem(string itemName)
        {
            var item = _itemService.GetItem(itemName);

            TextBoxItemCode.Text = item.Code;
            TextBoxItemName.Text = item.Name;
            TextBoxItemBrand.Text = item.Brand;
            ComboItemUnit.Text = item.Unit.ToString();
            TextBoxPurchasePrice.Text = item.PurchasePrice.ToString();
            TextBoxSalesPrice.Text = item.SellPrice.ToString();

            EnableFields(false);
        }
        #endregion

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
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

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
    }
}
