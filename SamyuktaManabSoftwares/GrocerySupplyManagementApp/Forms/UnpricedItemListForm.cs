using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class UnpricedItemListForm : Form
    {
        private readonly IPricedItemService _pricedItemService;
        public IUnpricedItemListForm _unpricedItemListForm;

        #region Constructor
        public UnpricedItemListForm(IPricedItemService pricedItemService, IUnpricedItemListForm unpricedItemListForm)
        {
            InitializeComponent();

            _pricedItemService = pricedItemService;
            _unpricedItemListForm = unpricedItemListForm;
        }
        #endregion

        #region Form Load Event
        private void UnpricedItemListForm_Load(object sender, EventArgs e)
        {
            LoadUnpricedItems();
        }
        #endregion

        #region Data Grid Event
        private void DataGridUnpricedItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                    long itemId = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    _unpricedItemListForm.PopulateUnpricedItem(itemId);
                }

                Close();
            }
        }

        private void DataGridUnpricedItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridUnpricedItemList.Columns["Id"].Visible = false;

            DataGridUnpricedItemList.Columns["Code"].HeaderText = "Code";
            DataGridUnpricedItemList.Columns["Code"].Width = 100;
            DataGridUnpricedItemList.Columns["Code"].DisplayIndex = 0;

            DataGridUnpricedItemList.Columns["Name"].HeaderText = "Name";
            DataGridUnpricedItemList.Columns["Name"].Width = 200;
            DataGridUnpricedItemList.Columns["Name"].DisplayIndex = 1;

            DataGridUnpricedItemList.Columns["Brand"].HeaderText = "Brand";
            DataGridUnpricedItemList.Columns["Brand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridUnpricedItemList.Columns["Brand"].DisplayIndex = 2;

            foreach (DataGridViewRow row in DataGridUnpricedItemList.Rows)
            {
                DataGridUnpricedItemList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridUnpricedItemList.RowHeadersWidth = 50;
                DataGridUnpricedItemList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadUnpricedItems()
        {
            var unpricedItemViewList = _pricedItemService.GetUnpricedItemViewList();

            var bindingList = new BindingList<UnpricedItemView>(unpricedItemViewList.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridUnpricedItemList.DataSource = source;
        }
        #endregion
    }
}
