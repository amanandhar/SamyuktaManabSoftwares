using GrocerySupplyManagementApp.Services;
using System;
using System.Windows.Forms;
using GrocerySupplyManagementApp.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PurchaseForm : Form
    {
        private readonly IItemService _itemService;
        public SupplierForm _supplierForm;
        private List<Item> items = new List<Item>();

        public PurchaseForm(IItemService itemService, SupplierForm supplierForm)
        {
            InitializeComponent();

            _itemService = itemService;
            _supplierForm = supplierForm;
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new Item
                {
                    Name = RichItemName.Text,
                    Brand = RichBrandName.Text,
                    BillNo = RichBillNo.Text,
                    Quantity = Convert.ToInt32(RichQuantity.Text),
                    Unit = ComboUnit.Text,
                    PurchasePrice = Convert.ToDouble(TextBoxPurchasePrice.Text)
                };
                
                items.Add(item);
                TextBoxTotalAmount.Text = items.Sum(x => x.PurchasePrice).ToString();
                ClearAllFields();
                LoadItems(items);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Item selectedItem = (Item)DataGridPurchaseList.CurrentRow.DataBoundItem;
            items = items.Where(x => x.Name != selectedItem.Name).ToList();
            TextBoxTotalAmount.Text = items.Sum(x => x.PurchasePrice).ToString();
            LoadItems(items);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        #region Helper Methods

        private void ClearAllFields()
        {
            RichItemName.Clear();
            RichBrandName.Clear();
            //TextBoxTotalAmount.Clear();
            RichBillNo.Clear();
            RichQuantity.Clear();
            ComboUnit.Text = string.Empty;
            TextBoxPurchasePrice.Clear();
        }

        private void LoadItems(List<Item> items)
        {
            var bindingList = new BindingList<Item>(items);
            var source = new BindingSource(bindingList, null);
            DataGridPurchaseList.DataSource = source;

            DataGridPurchaseList.Columns["BillNo"].HeaderText = "Bill No";
            DataGridPurchaseList.Columns["BillNo"].Width = 80;
            DataGridPurchaseList.Columns["BillNo"].DisplayIndex = 0;

            DataGridPurchaseList.Columns["Name"].HeaderText = "Item Name";
            DataGridPurchaseList.Columns["Name"].Width = 150;
            DataGridPurchaseList.Columns["Name"].DisplayIndex = 1;

            DataGridPurchaseList.Columns["Brand"].HeaderText = "Item Brand";
            DataGridPurchaseList.Columns["Brand"].Width = 150;
            DataGridPurchaseList.Columns["Brand"].DisplayIndex = 2;

            DataGridPurchaseList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridPurchaseList.Columns["Quantity"].Width = 125;
            DataGridPurchaseList.Columns["Quantity"].DisplayIndex = 3;

            DataGridPurchaseList.Columns["Unit"].HeaderText = "Unit";
            DataGridPurchaseList.Columns["Unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridPurchaseList.Columns["Unit"].DisplayIndex = 4;

            DataGridPurchaseList.Columns["PurchasePrice"].Visible = false;
        }
        
        #endregion
    }
}
