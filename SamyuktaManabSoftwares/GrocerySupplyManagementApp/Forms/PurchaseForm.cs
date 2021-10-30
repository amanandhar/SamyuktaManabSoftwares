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
        private readonly bool _isReadOnly = false;

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
            _isReadOnly = true;
            LoadForm(supplierId, billNo);
        }
        #endregion

        #region Form Load Event
        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            if(!_isReadOnly)
            {
                ClearAllFields();
                EnableFields(Action.None);
                EnableFields(Action.Load);
                RichBillNo.Select();
            }
        }
        #endregion

        #region Button Click Event
        private void BtnSearchItem_Click(object sender, EventArgs e)
        {
            ItemListForm itemListForm = new ItemListForm(_itemService, this);
            itemListForm.ShowDialog();
            EnableFields(Action.None);
            EnableFields(Action.PopulateItem);
            RichTotalAmount.Focus();
        }

        private void BtnAddBill_Click(object sender, EventArgs e)
        {
            RichBillNo.Text = _purchasedItemService.GetNewBillNumber();
            EnableFields(Action.None);
            EnableFields(Action.Add);
            RichItemCode.Focus();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (ValidatePurchaseInfo())
            {
                AddToCart();
            }
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
                        Action = Constants.PURCHASE,
                        ActionType = Constants.CREDIT,
                        PartyId = _supplierForm.GetSupplierId(),
                        PartyNumber = RichBillNo.Text.Trim(),
                        DuePaymentAmount = _purchasedItemViewList.Sum(x => x.Total),
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _userTransactionService.AddUserTransaction(userTransaction);

                    _supplierForm.PopulateItemsPurchaseDetails(userTransaction.PartyNumber);

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
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnClearItem_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridPurchaseList.SelectedCells.Count == 1
                    || DataGridPurchaseList.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow;
                    if (DataGridPurchaseList.SelectedCells.Count == 1)
                    {
                        var selectedCell = DataGridPurchaseList.SelectedCells[0];
                        selectedRow = DataGridPurchaseList.Rows[selectedCell.RowIndex];
                    }
                    else
                    {
                        selectedRow = DataGridPurchaseList.SelectedRows[0];
                    }

                    string selectedId = selectedRow?.Cells["Id"]?.Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(selectedId))
                    {
                        DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (deleteResult == DialogResult.Yes)
                        {
                            var id = Convert.ToInt64(selectedId);
                            var itemToRemove = _purchasedItemViewList.Single(x => x.Id == id);
                            _purchasedItemViewList.Remove(itemToRemove);
                            TxtBillAmount.Text = _purchasedItemViewList.Sum(x => (x.Price * x.Quantity)).ToString();
                            LoadPurchasedItemViewList(_purchasedItemViewList);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        #endregion

        #region Rich Box Event
        private void RichTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void RichDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void RichVat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void RichQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void RichTotalAmount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateVatAndPurchasePrice();
        }

        private void RichDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateVatAndPurchasePrice();
        }

        private void RichVat_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateVatAndPurchasePrice();
        }

        private void RichQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateVatAndPurchasePrice();
        }

        private void RichTotalAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CalculateVatAndPurchasePrice();
            }
        }

        private void RichDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CalculateVatAndPurchasePrice();
            }
        }

        private void RichVat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CalculateVatAndPurchasePrice();
            }
        }

        private void RichQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                if (ValidatePurchaseInfo())
                {
                    AddToCart();
                }
            }
        }

        #endregion

        #region Checkbox Event
        private void ChkBoxVat_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBoxVat.Checked)
            {
                RichVat.Enabled = true;
            }
            else
            {
                RichVat.Enabled = false;
            }

            CalculateVatAndPurchasePrice();
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
            DataGridPurchaseList.Columns["Code"].Width = 125;
            DataGridPurchaseList.Columns["Code"].DisplayIndex = 2;

            DataGridPurchaseList.Columns["Name"].HeaderText = "Item Name";
            DataGridPurchaseList.Columns["Name"].Width = 200;
            DataGridPurchaseList.Columns["Name"].DisplayIndex = 3;

            DataGridPurchaseList.Columns["Brand"].HeaderText = "Item Brand";
            DataGridPurchaseList.Columns["Brand"].Width = 175;
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
                    BillNo = RichBillNo.Text.Trim(),
                    Code = RichItemCode.Text.Trim(),
                    Name = RichItemName.Text.Trim(),
                    Brand = RichItemBrand.Text.Trim(),
                    Unit = RichUnit.Text.Trim(),
                    Quantity = Convert.ToDecimal(RichQuantity.Text.Trim()),
                    Price = Convert.ToDecimal(RichPurchasePrice.Text.Trim()),
                    Total = (Convert.ToDecimal(RichQuantity.Text.Trim()) * Convert.ToDecimal(RichPurchasePrice.Text.Trim())),
                    AddedDate = DateTime.Now
                };

                _purchasedItemViewList.Add(purchasedItemView);
                TxtBillAmount.Text = _purchasedItemViewList.Sum(x => x.Total).ToString();
                ClearAllFields();
                LoadPurchasedItemViewList(_purchasedItemViewList);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Add)
            {
                BtnSearchItem.Enabled = true;
                BtnAddBill.Enabled = true;
            }
            else if (action == Action.PopulateItem)
            {
                RichTotalAmount.Enabled = true;
                RichDiscount.Enabled = true;
                RichQuantity.Enabled = true;

                ChkBoxVat.Enabled = true;

                BtnSearchItem.Enabled = true;
                BtnAddBill.Enabled = true;
                BtnAddItem.Enabled = true;
                BtnSaveItem.Enabled = true;
                BtnClearItem.Enabled = true;
                BtnRemoveItem.Enabled = true;
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
                RichTotalAmount.Enabled = false;
                RichDiscount.Enabled = false;
                RichVat.Enabled = false;
                RichQuantity.Enabled = false;
                RichPurchasePrice.Enabled = false;

                ChkBoxVat.Enabled = false;

                BtnSearchItem.Enabled = false;
                BtnAddBill.Enabled = false;
                BtnAddItem.Enabled = false;
                BtnSaveItem.Enabled = false;
                BtnClearItem.Enabled = false;
                BtnRemoveItem.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            RichItemCode.Clear();
            RichItemName.Clear();
            RichItemBrand.Clear();
            RichUnit.Clear();
            RichTotalAmount.Clear();
            RichDiscount.Clear();
            RichVat.Clear();
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
            TxtBillAmount.Text = _purchasedItemService.GetPurchasedItemTotalAmount(supplierId, billNo).ToString();
            RichBillNo.Text = billNo;

            BtnSearchItem.Enabled = false;
            BtnAddBill.Enabled = false;
            BtnAddItem.Enabled = false;
            BtnRemoveItem.Enabled = false;
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
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void CalculateVatAndPurchasePrice()
        {
            var totalAmount = string.IsNullOrWhiteSpace(RichTotalAmount.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichTotalAmount.Text.Trim());
            var discount = string.IsNullOrWhiteSpace(RichDiscount.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichDiscount.Text.Trim());

            if (totalAmount >= Constants.DEFAULT_DECIMAL_VALUE)
            {
                if (!ChkBoxVat.Checked)
                {
                    RichVat.Text = Math.Round(((totalAmount - discount) * Constants.VAT_DEFAULT_AMOUNT / 100), 2).ToString();
                }
            }

            var vat = string.IsNullOrWhiteSpace(RichVat.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichVat.Text.Trim());
            var quantity = string.IsNullOrWhiteSpace(RichQuantity.Text.Trim()) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(RichQuantity.Text.Trim());
            decimal purchasePrice;
            if (quantity > 0)
            {
                purchasePrice = Math.Round(((totalAmount - discount + vat) / quantity), 2);
            }
            else
            {
                purchasePrice = Math.Round((totalAmount - discount + vat), 2);
            }

            RichPurchasePrice.Text = purchasePrice.ToString();
        }

        #endregion

        #region Validation
        private bool ValidatePurchaseInfo()
        {
            var isValidated = false;

            var billNo = RichBillNo.Text.Trim();
            var itemName = RichItemName.Text.Trim();
            var unit = RichUnit.Text.Trim();
            var itemCode = RichItemCode.Text.Trim();
            var itemBrand = RichItemBrand.Text.Trim();
            var quantity = RichQuantity.Text.Trim();
            var purchasePrice = RichPurchasePrice.Text.Trim();

            if (string.IsNullOrWhiteSpace(billNo)
                || string.IsNullOrWhiteSpace(itemName)
                || string.IsNullOrWhiteSpace(unit)
                || string.IsNullOrWhiteSpace(itemCode)
                || string.IsNullOrWhiteSpace(itemBrand)
                || string.IsNullOrWhiteSpace(quantity)
                || string.IsNullOrWhiteSpace(purchasePrice))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Bill No " +
                    "\n * Item Name " +
                    "\n * Unit " +
                    "\n * Item Code " +
                    "\n * Item Brand " +
                    "\n * Quantity " +
                    "\n * Purchase Price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }
        #endregion
    }
}
