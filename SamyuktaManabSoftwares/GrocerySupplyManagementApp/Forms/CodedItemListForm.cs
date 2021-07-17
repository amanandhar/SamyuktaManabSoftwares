using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class CodedItemListForm : Form
    {
        private readonly ICodedItemService _codedItemService;
        public ICodedItemListForm _codedItemListForm;

        #region Constructor
        public CodedItemListForm(ICodedItemService preparedItemService, ICodedItemListForm preparedItemListForm)
        {
            InitializeComponent();

            _codedItemService = preparedItemService;
            _codedItemListForm = preparedItemListForm;
        }
        #endregion

        #region Form Load Event
        private void PreparedItemList_Load(object sender, EventArgs e)
        {
            var codedItemViewList = _codedItemService.GetCodedItemViewList();
            var bindingList = new BindingList<CodedItemView>(codedItemViewList.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridCodedItemList.DataSource = source;
        }
        #endregion

        #region Data Grid Event
        private void DataGridPreparedItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridCodedItemList.Columns["Id"].Visible = false;

            DataGridCodedItemList.Columns["Code"].HeaderText = "Code";
            DataGridCodedItemList.Columns["Code"].Width = 50;
            DataGridCodedItemList.Columns["Code"].DisplayIndex = 0;

            DataGridCodedItemList.Columns["ItemSubCode"].HeaderText = "Sub Code";
            DataGridCodedItemList.Columns["ItemSubCode"].Width = 80;
            DataGridCodedItemList.Columns["ItemSubCode"].DisplayIndex = 1;

            DataGridCodedItemList.Columns["Name"].HeaderText = "Name";
            DataGridCodedItemList.Columns["Name"].Width = 200;
            DataGridCodedItemList.Columns["Name"].DisplayIndex = 2;

            DataGridCodedItemList.Columns["Brand"].HeaderText = "Brand";
            DataGridCodedItemList.Columns["Brand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridCodedItemList.Columns["Brand"].DisplayIndex = 3;

            foreach (DataGridViewRow row in DataGridCodedItemList.Rows)
            {
                DataGridCodedItemList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridCodedItemList.RowHeadersWidth = 50;
                DataGridCodedItemList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void DataGridPreparedItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }

            if (dgv.CurrentRow.Selected)
            {
                var selectedRow = dgv.SelectedRows[0];
                long codedItemId = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                _codedItemListForm.PopulateCodedItem(codedItemId);
                Close();
            }
        }
        #endregion
    }
}
