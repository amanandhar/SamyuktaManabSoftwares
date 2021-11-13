using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class UnpricedItemListForm : Form
    {
        private readonly IPricedItemService _pricedItemService;
        public IUnpricedItemListForm _unpricedItemListForm;
        private List<UnpricedItemView> _unpricedItemViewList = new List<UnpricedItemView>();

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
            _unpricedItemViewList = GetUnpricedItems();
            LoadUnpricedItems(_unpricedItemViewList);
            RichSearchItemName.Focus();
        }
        #endregion

        #region Rich Textbox Event
        private void RichSearchItemName_KeyUp(object sender, KeyEventArgs e)
        {
            SearchUnpricedItems();
        }

        private void RichSearchItemCode_KeyUp(object sender, KeyEventArgs e)
        {
            SearchUnpricedItems();
        }
        #endregion

        #region Data Grid Event
        private void DataGridUnpricedItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                    long itemId = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    _unpricedItemListForm.PopulateUnpricedItem(itemId);
                }

                Close();
            }
            else if (e.RowIndex > -1 && e.ColumnIndex > -1 && DataGridUnpricedItemList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var selectedRow = DataGridUnpricedItemList.CurrentRow;
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
            DataGridUnpricedItemList.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridUnpricedItemList.Columns["Name"].DisplayIndex = 1;

            foreach (DataGridViewRow row in DataGridUnpricedItemList.Rows)
            {
                DataGridUnpricedItemList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridUnpricedItemList.RowHeadersWidth = 50;
                DataGridUnpricedItemList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        private List<UnpricedItemView> GetUnpricedItems()
        {
            var unpricedItemViewList = _pricedItemService.GetUnpricedItemViewList().ToList();
            return unpricedItemViewList;
        }

        private void LoadUnpricedItems(List<UnpricedItemView> unpricedItemViewList)
        {
            var bindingList = new BindingList<UnpricedItemView>(unpricedItemViewList);
            var source = new BindingSource(bindingList, null);
            DataGridUnpricedItemList.DataSource = source;
        }

        private void SearchUnpricedItems()
        {
            var itemName = RichSearchItemName.Text.Trim();
            var itemCode = RichSearchItemCode.Text.Trim();

            var unpricedItemViewList = _unpricedItemViewList.Where(x => x.Name.ToLower().StartsWith(itemName.ToLower()) && x.Code.ToLower().StartsWith(itemCode.ToLower())).ToList();
            LoadUnpricedItems(unpricedItemViewList);
        }
        #endregion
    }
}
