using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SupplierListForm : Form
    {
        private readonly ISupplierService _supplierService;
        public SupplierForm _supplierForm;

        public SupplierListForm(ISupplierService supplierService, SupplierForm supplierForm)
        {
            InitializeComponent();

            _supplierService = supplierService;
            _supplierForm = supplierForm;
        }

        private void SupplierListForm_Load(object sender, EventArgs e)
        {
            var suppliers = _supplierService.GetSuppliers();

            var bindingList = new BindingList<Supplier>(suppliers.ToList());
            var source = new BindingSource(bindingList, null);

            DataGridSupplierList.AutoGenerateColumns = false;

            //Set Columns Count
            DataGridSupplierList.ColumnCount = 2;

            //Add Columns
            DataGridSupplierList.Columns[0].Name = "SupplierName";
            DataGridSupplierList.Columns[0].HeaderText = "Name";
            DataGridSupplierList.Columns[0].DataPropertyName = "Name";
            DataGridSupplierList.Columns[0].Width = 250;

            DataGridSupplierList.Columns[1].Name = "SupplierOwner";
            DataGridSupplierList.Columns[1].HeaderText = "Owner";
            DataGridSupplierList.Columns[1].DataPropertyName = "Owner";
            DataGridSupplierList.Columns[1].Width = 250;

            DataGridSupplierList.DataSource = source;
        }

        private void DataGridSupplierList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                string supplierName = dgv.CurrentRow.Cells[0].Value.ToString();
                _supplierForm.PopulateSupplier(supplierName);
                this.Close();
            }
        }
    }
}
