using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PricedItemListForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly IPricedItemService _pricedItemService;
        private readonly IPricedItemListForm _pricedItemListForm;
        private List<PricedItemView> _pricedItemViewList = new List<PricedItemView>();

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
            _pricedItemViewList = GetPricedItems();
            LoadPricedItems(_pricedItemViewList);
            RichSearchItemName.Focus();
        }
        #endregion

        #region Data Grid Event
        private void DataGridPricedItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }
            else if (dgv.CurrentRow.Selected)
            {
                var selectedRow = dgv.SelectedRows[0];
                if (selectedRow.Cells["Id"].Value != null)
                {
                    long pricedItemId = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    _pricedItemListForm.PopulatePricedItem(pricedItemId);
                }

                Close();
            }
            else if (e.RowIndex > -1 && e.ColumnIndex > -1 && DataGridPricedItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var selectedRow = DataGridPricedItemList.CurrentRow;
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
            DataGridPricedItemList.Columns["Code"].Width = 80;
            DataGridPricedItemList.Columns["Code"].DisplayIndex = 0;

            DataGridPricedItemList.Columns["SubCode"].HeaderText = "Sub";
            DataGridPricedItemList.Columns["SubCode"].Width = 50;
            DataGridPricedItemList.Columns["SubCode"].DisplayIndex = 1;

            DataGridPricedItemList.Columns["Name"].HeaderText = "Name";
            DataGridPricedItemList.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridPricedItemList.Columns["Name"].DisplayIndex = 2;

            foreach (DataGridViewRow row in DataGridPricedItemList.Rows)
            {
                DataGridPricedItemList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridPricedItemList.RowHeadersWidth = 50;
                DataGridPricedItemList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Rich Textbox Event
        private void RichSearchItemName_KeyUp(object sender, KeyEventArgs e)
        {
            SearchPricedItems();
        }

        private void RichSearchItemCode_KeyUp(object sender, KeyEventArgs e)
        {
            SearchPricedItems();
        }
        #endregion

        #region Helper Methods
        private List<PricedItemView> GetPricedItems()
        {
            var pricedItemViewList = _pricedItemService.GetPricedItemViewList().ToList();
            return pricedItemViewList;
        }

        private void LoadPricedItems(List<PricedItemView> pricedItemViewList)
        {
            var bindingList = new BindingList<PricedItemView>(pricedItemViewList);
            var source = new BindingSource(bindingList, null);
            DataGridPricedItemList.DataSource = source;
        }

        private void SearchPricedItems()
        {
            var itemName = RichSearchItemName.Text.Trim();
            var itemCode = RichSearchItemCode.Text.Trim();

            var pricedItemViewList = _pricedItemViewList.Where(x => x.Name.ToLower().StartsWith(itemName.ToLower()) && x.Code.ToLower().StartsWith(itemCode.ToLower())).ToList();
            LoadPricedItems(pricedItemViewList);
        }

        #endregion
    }
}
