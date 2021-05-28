using GrocerySupplyManagementApp.Services;
using System;
using System.Windows.Forms;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PurchaseForm : Form
    {
        public SupplierForm _supplierForm;
        private readonly IItemService _itemService;
        private readonly IItemTransactionService _itemTransactionService;
        private readonly ISupplierTransactionService _supplierTransactionService;
        private List<DTOs.ItemView> _items = new List<DTOs.ItemView>();
        
        public PurchaseForm(SupplierForm supplierForm, IItemService itemService, IItemTransactionService itemTransactionService, ISupplierTransactionService supplierTransactionService)
        {
            InitializeComponent();
            
            _supplierForm = supplierForm;
            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            _supplierTransactionService = supplierTransactionService;
        }

        public PurchaseForm(IItemService itemService, IItemTransactionService itemTransactionService, string supplierName, string billNo)
        {
            InitializeComponent();

            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            LoadForm(supplierName, billNo);
        }

        #region Form Load Events
        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            ClearAllFields();
            RichBillNo.Select();
        }
        #endregion

        #region Button Click Events
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new DTOs.ItemView
                {
                    Name = RichItemName.Text,
                    Brand = RichItemBrand.Text,
                    BillNo = RichBillNo.Text,
                    Quantity = Convert.ToInt32(RichQuantity.Text),
                    Unit = ComboUnit.Text,
                    PurchasePrice = Convert.ToDecimal(RichPurchasePrice.Text)
                };
                
                _items.Add(item);
                TextBoxTotalAmount.Text = _items.Sum(x => (x.PurchasePrice * x.Quantity)).ToString();
                ClearAllFields();
                LoadItems(_items);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            List<Item> items = _items.Select(item => new Item
            {
                Name = item.Name,
                Brand = item.Brand,
                Code = null
            }).ToList();

            items.ForEach(item =>
            {
                _itemService.AddItem(item);
            });
            
            List<ItemTransaction> itemTransactions = _items.Select(item => new ItemTransaction { 
                SupplierName = _supplierForm.GetSupplierName(),
                ItemId = _itemService.GetItemId(item.Name, item.Brand),
                Unit = item.Unit,
                Quantity = item.Quantity,
                PurchasePrice = item.PurchasePrice,
                PurchaseDate = dateTime,
                BillNo = item.BillNo,
                SellPrice = null    
            }).ToList();

            itemTransactions.ForEach(itemTransaction =>
            {
               _itemTransactionService.AddItem(itemTransaction);
            });

            _supplierTransactionService.AddSupplierTransaction(new SupplierTransaction
            {
                SupplierName = _supplierForm.GetSupplierName(),
                Status = "Purchase",
                BillNo = RichBillNo.Text,
                Debit = Convert.ToDecimal(TextBoxTotalAmount.Text),
                Date = dateTime
            });

            _supplierForm.PopulateItemsPurchaseDetails(RichBillNo.Text, Convert.ToDecimal(TextBoxTotalAmount.Text));
            this.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ItemTransaction selectedItem = (ItemTransaction)DataGridPurchaseList.CurrentRow.DataBoundItem;
            //_items = _items.Where(x => x.Name != selectedItem.Name).ToList();
            TextBoxTotalAmount.Text = _items.Sum(x => (x.PurchasePrice * x.Quantity)).ToString();
            LoadItems(_items);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        #endregion

        #region Helper Methods

        private void ClearAllFields()
        {
            RichItemName.Clear();
            RichItemBrand.Clear();
            //TextBoxTotalAmount.Clear();
            //RichBillNo.Clear();
            RichQuantity.Clear();
            ComboUnit.Text = string.Empty;
            RichPurchasePrice.Clear();
        }

        private void LoadItems(List<DTOs.ItemView> items)
        {
            var bindingList = new BindingList<DTOs.ItemView>(items);
            var source = new BindingSource(bindingList, null);
            if(!DataGridPurchaseList.Columns.Contains("Total"))
            {
                DataGridPurchaseList.Columns.Add("Total", "Total");
            }
            
            DataGridPurchaseList.DataSource = source;
        }

        private void LoadForm(string supplierName, string billNo)
        {
            var items = _itemTransactionService.GetItemsBySupplierAndBill(supplierName, billNo).Select(item => new DTOs.ItemView
            {
                Name = _itemService.GetItem(item.ItemId).Name,
                Brand = _itemService.GetItem(item.ItemId).Brand,
                Unit = item.Unit,
                Quantity = item.Quantity,
                PurchasePrice = item.PurchasePrice,
                BillNo = item.BillNo
            }).ToList();

            LoadItems(items);
            TextBoxTotalAmount.Text = _itemTransactionService.GetTotalAmountBySupplierAndBill(supplierName, billNo).ToString();
            RichBillNo.Text = billNo;

            BtnDelete.Enabled = false;
            BtnClear.Enabled = false;
            BtnSave.Enabled = false;
            BtnAddItem.Enabled = false;
        }

        #endregion

        #region DataGrid Events
        private void DataGridPurchaseList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridPurchaseList.Columns["BillNo"].Visible = false;

            DataGridPurchaseList.Columns["Name"].HeaderText = "Item Name";
            DataGridPurchaseList.Columns["Name"].Width = 140;
            DataGridPurchaseList.Columns["Name"].DisplayIndex = 1;

            DataGridPurchaseList.Columns["Brand"].HeaderText = "Item Brand";
            DataGridPurchaseList.Columns["Brand"].Width = 140;
            DataGridPurchaseList.Columns["Brand"].DisplayIndex = 2;

            DataGridPurchaseList.Columns["Unit"].HeaderText = "Unit";
            DataGridPurchaseList.Columns["Unit"].Width = 50;
            DataGridPurchaseList.Columns["Unit"].DisplayIndex = 3;

            DataGridPurchaseList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridPurchaseList.Columns["Quantity"].Width = 50;
            DataGridPurchaseList.Columns["Quantity"].DisplayIndex = 4;

            DataGridPurchaseList.Columns["PurchasePrice"].HeaderText = "Price";
            DataGridPurchaseList.Columns["PurchasePrice"].Width = 100;
            DataGridPurchaseList.Columns["PurchasePrice"].DisplayIndex = 5;

            DataGridPurchaseList.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridPurchaseList.Columns["Total"].DisplayIndex = 6;

            foreach (DataGridViewRow row in DataGridPurchaseList.Rows)
            {
                DataGridPurchaseList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridPurchaseList.RowHeadersWidth = 50;

                double quantity = string.IsNullOrEmpty(Convert.ToString(DataGridPurchaseList.Rows[row.Index].Cells["Quantity"].Value))
                ? 0.0
                : Convert.ToDouble(DataGridPurchaseList.Rows[row.Index].Cells["Quantity"].Value);

                double purchasePrice = string.IsNullOrEmpty(Convert.ToString(DataGridPurchaseList.Rows[row.Index].Cells["PurchasePrice"].Value))
                    ? 0.0
                    : Convert.ToDouble(DataGridPurchaseList.Rows[row.Index].Cells["PurchasePrice"].Value);
                
                row.Cells[DataGridPurchaseList.Columns["Total"].Index].Value = Convert.ToDouble(quantity * purchasePrice) == 0.0
                    ? string.Empty
                    : (quantity * purchasePrice).ToString();
            }
        }

        private void DataGridPurchaseList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //DataGridPurchaseList.Rows[e.RowIndex].Cells["SNo"].Value = (e.RowIndex + 1).ToString();
        }

        #endregion
    }
}
