using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PreparedItemListForm : Form
    {
        private readonly ICodedItemService _preparedItemService;
        public IPreparedItemListForm _preparedItemListForm;

        #region Constructor
        public PreparedItemListForm(ICodedItemService preparedItemService, IPreparedItemListForm preparedItemListForm)
        {
            InitializeComponent();

            _preparedItemService = preparedItemService;
            _preparedItemListForm = preparedItemListForm;
        }
        #endregion

        #region Form Load Event
        private void PreparedItemList_Load(object sender, EventArgs e)
        {
            var preparedItemsGrid = _preparedItemService.GetPreparedItemGrid();

            var bindingList = new BindingList<ItemCodedView>(preparedItemsGrid.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridPreparedItemList.DataSource = source;
        }
        #endregion

        #region Data Grid Event
        private void DataGridPreparedItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Set Columns Count
            DataGridPreparedItemList.Columns["Id"].Visible = false;

            //Add Columns
            DataGridPreparedItemList.Columns["Code"].HeaderText = "Code";
            DataGridPreparedItemList.Columns["Code"].Width = 50;
            DataGridPreparedItemList.Columns["Code"].DisplayIndex = 0;

            DataGridPreparedItemList.Columns["ItemSubCode"].HeaderText = "Sub Code";
            DataGridPreparedItemList.Columns["ItemSubCode"].Width = 80;
            DataGridPreparedItemList.Columns["ItemSubCode"].DisplayIndex = 1;

            DataGridPreparedItemList.Columns["Name"].HeaderText = "Name";
            DataGridPreparedItemList.Columns["Name"].Width = 200;
            DataGridPreparedItemList.Columns["Name"].DisplayIndex = 2;

            DataGridPreparedItemList.Columns["Brand"].HeaderText = "Brand";
            DataGridPreparedItemList.Columns["Brand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridPreparedItemList.Columns["Brand"].DisplayIndex = 3;

            foreach (DataGridViewRow row in DataGridPreparedItemList.Rows)
            {
                DataGridPreparedItemList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridPreparedItemList.RowHeadersWidth = 50;
            }
        }

        private void DataGridPreparedItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }

            if (dgv.CurrentRow.Selected)
            {
                long preparedItemId = Convert.ToInt64(dgv.CurrentRow.Cells["Id"].Value.ToString());
                _preparedItemListForm.PopulatePreparedItem(preparedItemId);
                this.Close();
            }
        }
        #endregion
    }
}
