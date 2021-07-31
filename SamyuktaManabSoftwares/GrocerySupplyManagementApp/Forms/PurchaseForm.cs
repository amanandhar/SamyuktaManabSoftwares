using GrocerySupplyManagementApp.Entities;
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
    public partial class PurchaseForm : Form, IItemListForm
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IItemService _itemService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;
        public SupplierForm _supplierForm;
        private List<PurchasedItemView> _purchasedItemViewList = new List<PurchasedItemView>();

        #region Constructor
        public PurchaseForm(IFiscalYearService fiscalYearService, IItemService itemService,
            IPurchasedItemService purchasedItemService, IUserTransactionService userTransactionService,
            SupplierForm supplierForm
            )
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _itemService = itemService;
            _purchasedItemService = purchasedItemService;
            _userTransactionService = userTransactionService;
            _supplierForm = supplierForm;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }

        public PurchaseForm(IItemService itemService, IPurchasedItemService purchasedItemService, string supplierId, string billNo)
        {
            InitializeComponent();

            _itemService = itemService;
            _purchasedItemService = purchasedItemService;
            LoadForm(supplierId, billNo);
        }
        #endregion

        #region Form Load Event
        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            ClearAllFields();
            RichBillNo.Select();
        }
        #endregion

        #region Button Click Event
        private void BtnShowItem_Click(object sender, EventArgs e)
        {
            ItemListForm itemListForm = new ItemListForm(_itemService, this);
            itemListForm.Show();
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            RichBillNo.Text = _purchasedItemService.GetLastBillNo();
            EnableFields(true);
            RichItemCode.Focus();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                var purchasedItemView = new PurchasedItemView
                {
                    Id = _purchasedItemViewList.Count + 1,
                    EndOfDay = _endOfDay,
                    BillNo = RichBillNo.Text,
                    Code = RichItemCode.Text,
                    Name = RichItemName.Text,
                    Brand = RichItemBrand.Text,
                    Unit = RichUnit.Text,
                    Quantity = Convert.ToInt32(RichQuantity.Text),
                    Price = Convert.ToDecimal(RichPurchasePrice.Text),
                    Total = (Convert.ToInt64(RichQuantity.Text) * Convert.ToDecimal(RichPurchasePrice.Text))
                };
                
                _purchasedItemViewList.Add(purchasedItemView);
                TxtTotalAmount.Text = _purchasedItemViewList.Sum(x => (x.Price * x.Quantity)).ToString();
                ClearAllFields();
                LoadPurchasedItemViewList(_purchasedItemViewList);
                
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
                var date = DateTime.Now;
                List<PurchasedItem> purchasedItems = _purchasedItemViewList.Select(item => new PurchasedItem
                {
                    EndOfDay = _endOfDay,
                    SupplierId = _supplierForm.GetSupplierId(),
                    BillNo = item.BillNo,
                    ItemId = _itemService.GetItem(item.Code).Id,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    AddedDate = date,
                    UpdatedDate = date
                }).ToList();

                purchasedItems.ForEach(purchasedItem =>
                {
                    _purchasedItemService.AddPurchasedItem(purchasedItem);
                });

                var userTransaction = new UserTransaction
                {
                    EndOfDay = _endOfDay,
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
                    DueAmount = Convert.ToDecimal(TxtTotalAmount.Text),
                    ReceivedAmount = 0.0m,
                    AddedDate = date,
                    UpdatedDate = date
                };

                _userTransactionService.AddUserTransaction(userTransaction);

                _supplierForm.PopulateItemsPurchaseDetails(userTransaction.BillNo);
                Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridPurchaseList.SelectedRows.Count == 1)
                {
                    var selectedRow = DataGridPurchaseList.SelectedRows[0];
                    var id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                    var itemToRemove = _purchasedItemViewList.Single(x => x.Id == id);
                    _purchasedItemViewList.Remove(itemToRemove);
                    TxtTotalAmount.Text = _purchasedItemViewList.Sum(x => (x.Price * x.Quantity)).ToString();
                    LoadPurchasedItemViewList(_purchasedItemViewList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        #endregion

        #region DataGrid Event
        private void DataGridPurchaseList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridPurchaseList.Columns["Id"].Visible = false;

            DataGridPurchaseList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridPurchaseList.Columns["EndOfDay"].Width = 80;
            DataGridPurchaseList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridPurchaseList.Columns["BillNo"].HeaderText = "Bill No";
            DataGridPurchaseList.Columns["BillNo"].Width = 80;
            DataGridPurchaseList.Columns["BillNo"].DisplayIndex = 1;

            DataGridPurchaseList.Columns["Code"].HeaderText = "Item Code";
            DataGridPurchaseList.Columns["Code"].Width = 100;
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
            DataGridPurchaseList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridPurchaseList.Columns["Price"].HeaderText = "Price";
            DataGridPurchaseList.Columns["Price"].Width = 100;
            DataGridPurchaseList.Columns["Price"].DisplayIndex = 7;
            DataGridPurchaseList.Columns["Price"].DefaultCellStyle.Format = "0.00";
            DataGridPurchaseList.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridPurchaseList.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridPurchaseList.Columns["Total"].DisplayIndex = 8;
            DataGridPurchaseList.Columns["Total"].DefaultCellStyle.Format = "0.00";
            DataGridPurchaseList.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridPurchaseList.Rows)
            {
                DataGridPurchaseList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridPurchaseList.RowHeadersWidth = 50;
                DataGridPurchaseList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        #endregion

        #region Helper Methods
        private void LoadPurchasedItemViewList(List<PurchasedItemView> purchasedItemViewList)
        {
            var bindingList = new BindingList<PurchasedItemView>(purchasedItemViewList);
            var source = new BindingSource(bindingList, null);
            DataGridPurchaseList.DataSource = source;
        }

        private void EnableFields(bool option)
        {
            BtnShowItem.Enabled = option;
            RichItemCode.Enabled = option;
            RichItemName.Enabled = option;
            RichItemBrand.Enabled = option;
            RichUnit.Enabled = option;
            RichPurchasePrice.Enabled = option;
            RichQuantity.Enabled = option;
        }

        private void ClearAllFields()
        {
            RichItemCode.Clear();
            RichItemName.Clear();
            RichItemBrand.Clear();
            RichQuantity.Clear();
            RichUnit.Clear();
            RichPurchasePrice.Clear();
        }

        private void LoadForm(string supplierId, string billNo)
        {
            var purchasedItemViewList = _purchasedItemService.GetPurchasedItemBySupplierAndBill(supplierId, billNo).Select(purchasedItem => new PurchasedItemView
            {
                EndOfDay = purchasedItem.EndOfDay,
                BillNo = purchasedItem.BillNo,
                Code = _itemService.GetItem(purchasedItem.ItemId).Code,
                Name = _itemService.GetItem(purchasedItem.ItemId).Name,
                Brand = _itemService.GetItem(purchasedItem.ItemId).Brand,
                Unit = _itemService.GetItem(purchasedItem.ItemId).Unit,
                Quantity = purchasedItem.Quantity,
                Price = purchasedItem.Price,
                Total = (purchasedItem.Quantity * purchasedItem.Price)
            }).ToList();

            LoadPurchasedItemViewList(purchasedItemViewList);
            TxtTotalAmount.Text = _purchasedItemService.GetPurchasedItemTotalAmount(supplierId, billNo).ToString();
            RichBillNo.Text = billNo;

            BtnShowItem.Enabled = false;
            BtnAddNew.Enabled = false;
            BtnAddBonus.Enabled = false;
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
                RichUnit.Text = item.Unit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
