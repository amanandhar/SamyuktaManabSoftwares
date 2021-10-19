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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IItemService _itemService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;
        public SupplierForm _supplierForm;
        private readonly List<PurchasedItemView> _purchasedItemViewList = new List<PurchasedItemView>();

        #region enum
        private enum Action
        {
            Add,
            PopulateItem,
            Load,
            None
        }
        #endregion

        #region Constructor
        public PurchaseForm(string username,
            ISettingService settingService, IItemService itemService,
            IPurchasedItemService purchasedItemService, IUserTransactionService userTransactionService,
            SupplierForm supplierForm
            )
        {
            InitializeComponent();

            _settingService = settingService;
            _itemService = itemService;
            _purchasedItemService = purchasedItemService;
            _userTransactionService = userTransactionService;
            _supplierForm = supplierForm;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
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
            EnableFields(Action.None);
            EnableFields(Action.Load);
            RichBillNo.Select();
        }
        #endregion

        #region Button Click Event
        private void BtnSearchItem_Click(object sender, EventArgs e)
        {
            ItemListForm itemListForm = new ItemListForm(_itemService, this);
            itemListForm.ShowDialog();
            EnableFields(Action.None);
            EnableFields(Action.PopulateItem);
            RichQuantity.Focus();
        }

        private void BtnAddBill_Click(object sender, EventArgs e)
        {
            RichBillNo.Text = _purchasedItemService.GetLastBillNo();
            EnableFields(Action.None);
            EnableFields(Action.Add);
            RichItemCode.Focus();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            AddToCart();
        }

        private void BtnSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmation = MessageBox.Show("Do you want to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    List<PurchasedItem> purchasedItems = _purchasedItemViewList.Select(item => new PurchasedItem
                    {
                        EndOfDay = _endOfDay,
                        SupplierId = _supplierForm.GetSupplierId(),
                        BillNo = item.BillNo,
                        ItemId = _itemService.GetItem(item.Code).Id,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        AddedBy = _username,
                        AddedDate = item.AddedDate
                    }).ToList();
                   
                    purchasedItems.ForEach(purchasedItem =>
                    {
                        _purchasedItemService.AddPurchasedItem(purchasedItem);

                    });

                    var userTransaction = new UserTransaction()
                    {
                        EndOfDay = _endOfDay,
                        BillNo = RichBillNo.Text,
                        SupplierId = _supplierForm.GetSupplierId(),
                        Action = Constants.PURCHASE,
                        ActionType = Constants.CREDIT,
                        DuePaymentAmount = _purchasedItemViewList.Sum(x => x.Total),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _userTransactionService.AddUserTransaction(userTransaction);

                    _supplierForm.PopulateItemsPurchaseDetails(userTransaction.BillNo);

                    DialogResult result = MessageBox.Show("Purchased successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        Close();
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void BtnClearItem_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
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
                logger.Error(ex);
                throw ex;
            }
        }

        #endregion

        #region Rich Box Event
        private void RichQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                RichPurchasePrice.Focus();
            }
        }

        private void RichQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void RichPurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                AddToCart();
            }
        }

        private void RichPurchasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region DataGrid Event
        private void DataGridPurchaseList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridPurchaseList.Columns["Id"].Visible = false;
            DataGridPurchaseList.Columns["AddedDate"].Visible = false;

            DataGridPurchaseList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridPurchaseList.Columns["EndOfDay"].Width = 80;
            DataGridPurchaseList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridPurchaseList.Columns["BillNo"].HeaderText = "Bill No";
            DataGridPurchaseList.Columns["BillNo"].Width = 90;
            DataGridPurchaseList.Columns["BillNo"].DisplayIndex = 1;

            DataGridPurchaseList.Columns["Code"].HeaderText = "Item Code";
            DataGridPurchaseList.Columns["Code"].Width = 80;
            DataGridPurchaseList.Columns["Code"].DisplayIndex = 2;

            DataGridPurchaseList.Columns["Name"].HeaderText = "Item Name";
            DataGridPurchaseList.Columns["Name"].Width = 170;
            DataGridPurchaseList.Columns["Name"].DisplayIndex = 3;

            DataGridPurchaseList.Columns["Brand"].HeaderText = "Item Brand";
            DataGridPurchaseList.Columns["Brand"].Width = 140;
            DataGridPurchaseList.Columns["Brand"].DisplayIndex = 4;

            DataGridPurchaseList.Columns["Unit"].HeaderText = "Unit";
            DataGridPurchaseList.Columns["Unit"].Width = 50;
            DataGridPurchaseList.Columns["Unit"].DisplayIndex = 5;

            DataGridPurchaseList.Columns["Quantity"].HeaderText = "Quantity";
            DataGridPurchaseList.Columns["Quantity"].Width = 60;
            DataGridPurchaseList.Columns["Quantity"].DisplayIndex = 6;
            DataGridPurchaseList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridPurchaseList.Columns["Price"].HeaderText = "Price";
            DataGridPurchaseList.Columns["Price"].Width = 70;
            DataGridPurchaseList.Columns["Price"].DisplayIndex = 7;
            DataGridPurchaseList.Columns["Price"].DefaultCellStyle.Format = "0.00";
            DataGridPurchaseList.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridPurchaseList.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridPurchaseList.Columns["Total"].DisplayIndex = 9;
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

        private void AddToCart()
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
                    Quantity = Convert.ToDecimal(RichQuantity.Text),
                    Price = Convert.ToDecimal(RichPurchasePrice.Text),
                    Total = (Convert.ToDecimal(RichQuantity.Text) * Convert.ToDecimal(RichPurchasePrice.Text)),
                    AddedDate = DateTime.Now
                };

                _purchasedItemViewList.Add(purchasedItemView);
                TxtTotalAmount.Text = _purchasedItemViewList.Sum(x => x.Total).ToString();
                ClearAllFields();
                LoadPurchasedItemViewList(_purchasedItemViewList);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        private void EnableFields(Action action = Action.None)
        {
            if(action == Action.Add)
            {
                BtnSearchItem.Enabled = true;
                BtnAddBill.Enabled = true;
            }
            else if(action == Action.PopulateItem)
            {
                RichQuantity.Enabled = true;
                RichPurchasePrice.Enabled = true;

                BtnSearchItem.Enabled = true;
                BtnAddBill.Enabled = true;
                BtnAddItem.Enabled = true;
                BtnSaveItem.Enabled = true;
                BtnClearItem.Enabled = true;
                BtnDeleteItem.Enabled = true;
            }
            else if (action == Action.Load)
            {
                BtnAddBill.Enabled = true;
            }
            else
            {
                RichItemCode.Enabled = false;
                RichItemName.Enabled = false;
                RichItemBrand.Enabled = false;
                RichUnit.Enabled = false;
                RichQuantity.Enabled = false;
                RichPurchasePrice.Enabled = false;

                BtnSearchItem.Enabled = false;
                BtnAddBill.Enabled = false;
                BtnAddItem.Enabled = false;
                BtnSaveItem.Enabled = false;
                BtnClearItem.Enabled = false;
                BtnDeleteItem.Enabled = false;
            } 
        }

        private void ClearAllFields()
        {
            RichItemCode.Clear();
            RichItemName.Clear();
            RichItemBrand.Clear();
            RichUnit.Clear();
            RichQuantity.Clear();
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

            BtnSearchItem.Enabled = false;
            BtnAddItem.Enabled = false;
            BtnDeleteItem.Enabled = false;
            BtnClearItem.Enabled = false;
            BtnSaveItem.Enabled = false;
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
                logger.Error(ex);
                throw ex;
            }
        }

        #endregion
    }
}
