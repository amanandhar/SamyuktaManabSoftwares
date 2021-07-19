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
    public partial class CodedItemListForm : Form
    {
        private readonly ICodedItemService _codedItemService;
        public ICodedItemListForm _codedItemListForm;
        public bool _showCodedUncodedItem;

        #region Constructor
        public CodedItemListForm(ICodedItemService codedItemService, ICodedItemListForm codedItemListForm, bool showCodedUncodedItem)
        {
            InitializeComponent();

            _codedItemService = codedItemService;
            _codedItemListForm = codedItemListForm;
            _showCodedUncodedItem = showCodedUncodedItem;
        }
        #endregion

        #region Form Load Event
        private void CodedItemListForm_Load(object sender, EventArgs e)
        {
            IEnumerable<CodedItemView> codedItemViewList;
            if (_showCodedUncodedItem)
            {
                codedItemViewList = _codedItemService.GetCodedUnCodedItemViewList();
            }
            else
            {
                codedItemViewList = _codedItemService.GetCodedItemViewList();
            }
            
            var bindingList = new BindingList<CodedItemView>(codedItemViewList.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridCodedItemList.DataSource = source;
        }
        #endregion

        #region Data Grid Event
        private void DataGridCodedItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridCodedItemList.Columns["Id"].Visible = false;
            if(_showCodedUncodedItem)
            {
                DataGridCodedItemList.Columns["SubCode"].Visible = false;
            }

            DataGridCodedItemList.Columns["Code"].HeaderText = "Code";
            DataGridCodedItemList.Columns["Code"].Width = 50;
            DataGridCodedItemList.Columns["Code"].DisplayIndex = 0;

            if(!_showCodedUncodedItem)
            {
                DataGridCodedItemList.Columns["SubCode"].HeaderText = "Sub Code";
                DataGridCodedItemList.Columns["SubCode"].Width = 80;
                DataGridCodedItemList.Columns["SubCode"].DisplayIndex = 1;
            }

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

        private void DataGridCodedItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }

            if (dgv.CurrentRow.Selected)
            {
                var selectedRow = dgv.SelectedRows[0];
                if(selectedRow.Cells["SubCode"].Value != null)
                {
                    long codedItemId = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    _codedItemListForm.PopulateCodedItem(true, codedItemId);
                }
                else
                {
                    long purchasedItemId = Convert.ToInt64(selectedRow.Cells["Code"].Value.ToString());
                    _codedItemListForm.PopulateCodedItem(false, purchasedItemId);
                }
                

                Close();
            }
        }

        #endregion
    }
}
