using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PricedItemListForm : Form
    {
        private readonly IPricedItemService _pricedItemService;
        public IPricedItemListForm _pricedItemListForm;

        #region Constructor
        public PricedItemListForm(IPricedItemService pricedItemService, IPricedItemListForm pricedItemListForm)
        {
            InitializeComponent();

            _pricedItemService = pricedItemService;
            _pricedItemListForm = pricedItemListForm;
        }
        #endregion

        #region Form Load Event
        private void PricedItemListForm_Load(object sender, EventArgs e)
        {
            LoadPricedItems();
        }
        #endregion

        #region Data Grid Event
        private void DataGridPricedItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }

            if (dgv.CurrentRow.Selected)
            {
                var selectedRow = dgv.SelectedRows[0];
                if (selectedRow.Cells["Id"].Value != null)
                {
                    long pricedItemId = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    _pricedItemListForm.PopulatePricedItem(pricedItemId);
                }

                Close();
            }
        }

        private void DataGridPricedItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridPricedItemList.Columns["Id"].Visible = false;

            DataGridPricedItemList.Columns["Code"].HeaderText = "Code";
            DataGridPricedItemList.Columns["Code"].Width = 50;
            DataGridPricedItemList.Columns["Code"].DisplayIndex = 0;

            DataGridPricedItemList.Columns["SubCode"].HeaderText = "Sub Code";
            DataGridPricedItemList.Columns["SubCode"].Width = 80;
            DataGridPricedItemList.Columns["SubCode"].DisplayIndex = 1;

            DataGridPricedItemList.Columns["Name"].HeaderText = "Name";
            DataGridPricedItemList.Columns["Name"].Width = 200;
            DataGridPricedItemList.Columns["Name"].DisplayIndex = 2;

            DataGridPricedItemList.Columns["Brand"].HeaderText = "Brand";
            DataGridPricedItemList.Columns["Brand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridPricedItemList.Columns["Brand"].DisplayIndex = 3;

            foreach (DataGridViewRow row in DataGridPricedItemList.Rows)
            {
                DataGridPricedItemList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridPricedItemList.RowHeadersWidth = 50;
                DataGridPricedItemList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadPricedItems()
        {
            var pricedItemViewList = _pricedItemService.GetPricedItemViewList();

            var bindingList = new BindingList<PricedItemView>(pricedItemViewList.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridPricedItemList.DataSource = source;
        }
        #endregion
    }
}
