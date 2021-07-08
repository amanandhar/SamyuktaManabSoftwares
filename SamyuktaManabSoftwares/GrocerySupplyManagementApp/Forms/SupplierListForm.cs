using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SupplierListForm : Form
    {
        private readonly ISupplierService _supplierService;
        private readonly IUserTransactionService _posTransactionService;

        public SupplierForm _supplierForm;

        #region Constructor
        public SupplierListForm(ISupplierService supplierService, IUserTransactionService posTransactionService, SupplierForm supplierForm)
        {
            InitializeComponent();

            _supplierService = supplierService;
            _posTransactionService = posTransactionService;
            _supplierForm = supplierForm;
        }
        #endregion

        #region Form Load Event
        private void SupplierListForm_Load(object sender, EventArgs e)
        {
            var suppliers = _supplierService.GetSuppliers();

            suppliers.ToList().ForEach(x => x.Balance = _posTransactionService.GetSupplierTotalBalance(x.SupplierId));

            var bindingList = new BindingList<Supplier>(suppliers.ToList());
            var source = new BindingSource(bindingList, null);

            DataGridSupplierList.AutoGenerateColumns = false;

            //Set Columns Count
            DataGridSupplierList.ColumnCount = 4;

            //Add Columns
            DataGridSupplierList.Columns[0].Name = "SupplierId";
            DataGridSupplierList.Columns[0].HeaderText = "Id";
            DataGridSupplierList.Columns[0].DataPropertyName = "SupplierId";
            DataGridSupplierList.Columns[0].Width = 50;

            DataGridSupplierList.Columns[1].Name = "Name";
            DataGridSupplierList.Columns[1].HeaderText = "Name";
            DataGridSupplierList.Columns[1].DataPropertyName = "Name";
            DataGridSupplierList.Columns[1].Width = 175;

            DataGridSupplierList.Columns[2].Name = "Owner";
            DataGridSupplierList.Columns[2].HeaderText = "Owner";
            DataGridSupplierList.Columns[2].DataPropertyName = "Owner";
            DataGridSupplierList.Columns[2].Width = 175;

            DataGridSupplierList.Columns[3].Name = "Balance";
            DataGridSupplierList.Columns[3].HeaderText = "Balance";
            DataGridSupplierList.Columns[3].DataPropertyName = "Balance";
            DataGridSupplierList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridSupplierList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridSupplierList.DataSource = source;
        }
        #endregion

        #region Data Grid Event
        private void DataGridSupplierList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                string supplierName = dgv.CurrentRow.Cells[1].Value.ToString();
                _supplierForm.PopulateSupplier(supplierName);
                this.Close();
            }
        }
        #endregion
    }
}
