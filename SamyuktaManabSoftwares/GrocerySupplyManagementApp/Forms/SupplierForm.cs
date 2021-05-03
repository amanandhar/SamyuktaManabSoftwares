using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SupplierForm : Form
    {
        private readonly ISupplierService _supplierService;
        private readonly IItemService _itemService;

        public SupplierForm(ISupplierService supplierService, IItemService itemService)
        {
            InitializeComponent();

            _supplierService = supplierService;
            _itemService = itemService;
        }

        #region Form Load Events
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields(false);
            LoadSuppliers();
        }
        #endregion

        #region Button Events
        private void BtnPurchase_Click(object sender, System.EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm(_itemService, this);
            purchaseForm.Show();
        }

        private void BtnShowSupplier_Click(object sender, System.EventArgs e)
        {
            SupplierListForm supplierListForm = new SupplierListForm(_supplierService, this);
            supplierListForm.Show();
        }

        private void BtnAddSupplier_Click(object sender, System.EventArgs e)
        {
            ClearAllFields();
            EnableFields(true);
        }
        

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                var supplier = _supplierService.AddSupplier(new Supplier
                {
                    Name = RichSupplierName.Text,
                    Owner = RichOwner.Text,
                    Address = RichAddress.Text,
                    ContactNumber = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text
                });

                DialogResult result = MessageBox.Show(supplier.Name + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    LoadSuppliers();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnEdit_Click(object sender, System.EventArgs e)
        {
            EnableFields(true);
        }

        private void BtnUpdate_Click(object sender, System.EventArgs e)
        {
            var supplierName = RichSupplierName.Text;
            try
            {
                var supplier = _supplierService.UpdateSupplier(supplierName, new Supplier
                {
                    Name = RichSupplierName.Text,
                    Owner = RichOwner.Text,
                    Address = RichAddress.Text,
                    ContactNumber = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text
                }); 

                DialogResult result = MessageBox.Show(supplierName + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    LoadSuppliers();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            var supplierName = RichSupplierName.Text;
            _supplierService.DeleteSupplier(supplierName);

            DialogResult result = MessageBox.Show(supplierName + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                ClearAllFields();
                LoadSuppliers();
            }
        }

        #endregion

        #region Helper Methods
        private void EnableFields(bool option = true)
        {
            RichSupplierName.Enabled = option;
            RichOwner.Enabled = option;
            RichAddress.Enabled = option;
            RichContactNumber.Enabled = option;
            RichEmail.Enabled = option;
        }

        private void ClearAllFields()
        {
            RichSupplierName.Clear();
            RichOwner.Clear();
            RichAddress.Clear();
            RichContactNumber.Clear();
            RichEmail.Clear();
        }

        private void LoadSuppliers()
        {
            
        }

        public void PopulateSupplier(string supplierName)
        {
            var supplier = _supplierService.GetSupplier(supplierName);

            RichSupplierName.Text = supplier.Name;
            RichOwner.Text = supplier.Owner;
            RichAddress.Text = supplier.Address;
            RichContactNumber.Text = supplier.ContactNumber.ToString();
            RichEmail.Text = supplier.Email;

            EnableFields(false);
        }
        #endregion
    }
}
