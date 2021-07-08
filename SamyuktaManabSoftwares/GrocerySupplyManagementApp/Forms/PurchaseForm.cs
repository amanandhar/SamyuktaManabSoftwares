using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PurchaseForm : Form, IItemListForm
    {
        public SupplierForm _supplierForm;
        private readonly IItemService _itemService;
        private readonly IItemTransactionService _itemTransactionService;
        private readonly IUserTransactionService _posTransactionService;
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        private List<DTOs.ItemView> _items = new List<DTOs.ItemView>();

        #region Constructor
        public PurchaseForm(SupplierForm supplierForm, IItemService itemService, 
            IItemTransactionService itemTransactionService, IUserTransactionService posTransactionService, 
            IFiscalYearDetailService fiscalYearDetailService)
        {
            InitializeComponent();
            
            _supplierForm = supplierForm;
            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            _posTransactionService = posTransactionService;
            _fiscalYearDetailService = fiscalYearDetailService;
        }

        public PurchaseForm(IItemService itemService, IItemTransactionService itemTransactionService, string supplierName, string billNo)
        {
            InitializeComponent();

            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            LoadForm(supplierName, billNo);
        }
        #endregion

        #region Form Load Event
        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            ClearAllFields();
            RichBillNo.Select();
        }
        #endregion

        #region Button Click Events
        private void BtnShowItem_Click(object sender, EventArgs e)
        {
            ItemListForm itemListForm = new ItemListForm(_itemService, this, true);
            itemListForm.Show();
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            RichBillNo.Text = _itemTransactionService.GetBillNo();
            EnableFields(true);
            RichItemCode.Focus();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new DTOs.ItemView
                {
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    BillNo = RichBillNo.Text,
                    Code = RichItemCode.Text,
                    Name = RichItemName.Text,
                    Brand = RichItemBrand.Text,
                    Unit = ComboUnit.Text,
                    Quantity = Convert.ToInt32(RichQuantity.Text),
                    PurchasePrice = Convert.ToDecimal(RichPurchasePrice.Text)
                };
                
                _items.Add(item);
                TxtTotalAmount.Text = _items.Sum(x => (x.PurchasePrice * x.Quantity)).ToString();
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
            try
            {
                DateTime dateTime = DateTime.Now;

                List<PurchasedItem> itemTransactions = _items.Select(item => new PurchasedItem
                {
                    SupplierName = _supplierForm.GetSupplierName(),
                    ItemId = _itemService.GetItemId(item.Name, item.Brand),
                    Unit = item.Unit,
                    Quantity = item.Quantity,
                    PurchasePrice = item.PurchasePrice,
                    PurchaseDate = dateTime,
                    BillNo = item.BillNo
                }).ToList();

                itemTransactions.ForEach(itemTransaction =>
                {
                    _itemTransactionService.AddItem(itemTransaction);
                });

                var fiscalYearDetail = _fiscalYearDetailService.GetFiscalYearDetail();

                var posTransaction = new PosTransaction
                {
                    InvoiceDate = fiscalYearDetail.StartingDate,
                    BillNo = RichBillNo.Text,
                    SupplierId = _supplierForm.GetSupplierId(),
                    Action = Constants.PURCHASE,
                    ActionType = Constants.CREDIT,
                    SubTotal = 0.0m,
                    DiscountPercent = 0.0m,
                    Discount = 0.0m,
                    VatPercent = 0.0m,
                    Vat = 0.0m,
                    DeliveryChargePercent = 0.0m,
                    DeliveryCharge = 0.0m,
                    TotalAmount = Convert.ToDecimal(TxtTotalAmount.Text),
                    ReceivedAmount = 0.0m,
                    Date = DateTime.Now
                };

                _posTransactionService.AddPosTransaction(posTransaction);

                _supplierForm.PopulateItemsPurchaseDetails(posTransaction.BillNo);
                this.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            PurchasedItem selectedItem = (PurchasedItem)DataGridPurchaseList.CurrentRow.DataBoundItem;
            TxtTotalAmount.Text = _items.Sum(x => (x.PurchasePrice * x.Quantity)).ToString();
            LoadItems(_items);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        #endregion

        #region Helper Methods
        private void EnableFields(bool option)
        {
            RichItemCode.Enabled = option;
            RichItemName.Enabled = option;
            RichItemBrand.Enabled = option;
            ComboUnit.Enabled = option;
            RichPurchasePrice.Enabled = option;
            RichQuantity.Enabled = option;
        }

        private void ClearAllFields()
        {
            RichItemCode.Clear();
            RichItemName.Clear();
            RichItemBrand.Clear();
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
                Date = item.PurchaseDate.ToString("yyyy-MM-dd"),
                BillNo = item.BillNo,
                Code = _itemService.GetItem(item.ItemId).Code,
                Name = _itemService.GetItem(item.ItemId).Name,
                Brand = _itemService.GetItem(item.ItemId).Brand,
                Unit = item.Unit,
                Quantity = item.Quantity,
                PurchasePrice = item.PurchasePrice
            }).ToList();

            LoadItems(items);
            TxtTotalAmount.Text = _itemTransactionService.GetTotalAmountBySupplierAndBill(supplierName, billNo).ToString();
            RichBillNo.Text = billNo;

            BtnDelete.Enabled = false;
            BtnClear.Enabled = false;
            BtnSave.Enabled = false;
            BtnAddItem.Enabled = false;
        }

        public void PopulateItem(long itemCode)
        {
            try
            {
                var item = _itemService.GetItem(itemCode);
                RichItemCode.Text = item.Code;
                RichItemName.Text = item.Name;
                RichItemBrand.Text = item.Brand;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region DataGrid Events
        private void DataGridPurchaseList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridPurchaseList.Columns["Date"].HeaderText = "Date";
            DataGridPurchaseList.Columns["Date"].Width = 80;
            DataGridPurchaseList.Columns["Date"].DisplayIndex = 0;

            DataGridPurchaseList.Columns["BillNo"].HeaderText = "Bill No";
            DataGridPurchaseList.Columns["BillNo"].Width = 80;
            DataGridPurchaseList.Columns["BillNo"].DisplayIndex = 1;

            DataGridPurchaseList.Columns["Code"].HeaderText = "Item Code";
            DataGridPurchaseList.Columns["Code"].Width = 80;
            DataGridPurchaseList.Columns["Code"].DisplayIndex = 2;

            DataGridPurchaseList.Columns["Name"].HeaderText = "Item Name";
            DataGridPurchaseList.Columns["Name"].Width = 150;
            DataGridPurchaseList.Columns["Name"].DisplayIndex = 3;

            DataGridPurchaseList.Columns["Brand"].HeaderText = "Item Brand";
            DataGridPurchaseList.Columns["Brand"].Width = 150;
            DataGridPurchaseList.Columns["Brand"].DisplayIndex = 4;

            DataGridPurchaseList.Columns["Unit"].HeaderText = "Unit";
            DataGridPurchaseList.Columns["Unit"].Width = 80;
            DataGridPurchaseList.Columns["Unit"].DisplayIndex = 5;

            DataGridPurchaseList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridPurchaseList.Columns["Quantity"].Width = 80;
            DataGridPurchaseList.Columns["Quantity"].DisplayIndex = 6;

            DataGridPurchaseList.Columns["PurchasePrice"].HeaderText = "Price";
            DataGridPurchaseList.Columns["PurchasePrice"].Width = 100;
            DataGridPurchaseList.Columns["PurchasePrice"].DisplayIndex = 7;

            DataGridPurchaseList.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridPurchaseList.Columns["Total"].DisplayIndex = 8;

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
