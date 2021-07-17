using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SupplierListForm : Form
    {
        private readonly ISupplierService _supplierService;
        private readonly IUserTransactionService _userTransactionService;

        public SupplierForm _supplierForm;

        #region Constructor
        public SupplierListForm(ISupplierService supplierService, IUserTransactionService userTransactionService, SupplierForm supplierForm)
        {
            InitializeComponent();

            _supplierService = supplierService;
            _userTransactionService = userTransactionService;
            _supplierForm = supplierForm;
        }
        #endregion

        #region Form Load Event
        private void SupplierListForm_Load(object sender, EventArgs e)
        {
            var suppliers = _supplierService.GetSuppliers();
            List<SupplierView> supplierViewList = suppliers.ToList().Select(x => new SupplierView()
            {
                Id = x.Id,
                SupplierId = x.SupplierId,
                Name = x.Name,
                Owner = x.Owner,
                Balance = _userTransactionService.GetSupplierTotalBalance(x.SupplierId),
            }).ToList();

            var bindingList = new BindingList<SupplierView>(supplierViewList.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridSupplierList.DataSource = source;
        }
        #endregion

        #region Data Grid Event
        private void DataGridSupplierList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }

            if (dgv.SelectedRows.Count == 1)
            {
                var selectedRow = dgv.SelectedRows[0];
                string supplierId = selectedRow.Cells["SupplierId"].Value.ToString();
                _supplierForm.PopulateSupplier(supplierId);
                Close();
            }
        }

        private void DataGridSupplierList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridSupplierList.Columns["Id"].Visible = false;

            DataGridSupplierList.Columns["SupplierId"].HeaderText = "Id";
            DataGridSupplierList.Columns["SupplierId"].Width = 50;
            DataGridSupplierList.Columns["SupplierId"].DisplayIndex = 0;

            DataGridSupplierList.Columns["Name"].HeaderText = "Name";
            DataGridSupplierList.Columns["Name"].Width = 175;
            DataGridSupplierList.Columns["Name"].DisplayIndex = 1;

            DataGridSupplierList.Columns["Owner"].HeaderText = "Owner";
            DataGridSupplierList.Columns["Owner"].Width = 175;
            DataGridSupplierList.Columns["Owner"].DisplayIndex = 2;

            DataGridSupplierList.Columns["Balance"].HeaderText = "Balance";
            DataGridSupplierList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridSupplierList.Columns["Balance"].DisplayIndex = 3;
            DataGridSupplierList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        #endregion

    }
}
