using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
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
    public partial class SupplierForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IItemService _itemService;
        private readonly ISupplierService _supplierService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;

        #region Constructor
        public SupplierForm(IFiscalYearService fiscalYearService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IItemService itemService, ISupplierService supplierService, 
            IPurchasedItemService purchasedItemService, IUserTransactionService userTransactionService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _itemService = itemService;
            _supplierService = supplierService;
            _purchasedItemService = purchasedItemService;
            _userTransactionService = userTransactionService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }

        #endregion

        #region Form Load Event
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            MaskEndOfDayFrom.Text = _endOfDay;
            MaskEndOfDayTo.Text = _endOfDay;
            ClearAllFields();
            EnableFields(false);
        }
        #endregion

        #region Button Event
        private void BtnPurchase_Click(object sender, System.EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm(_fiscalYearService, _itemService,
                _purchasedItemService, _userTransactionService, this);
            purchaseForm.Show();
        }

        private void BtnShowPurchase_Click(object sender, EventArgs e)
        {
            if(DataGridSupplierList.SelectedRows.Count == 1)
            {
                var selectedRow = DataGridSupplierList.SelectedRows[0];
                var action = selectedRow.Cells["Action"].Value.ToString();

                if (action.ToLower() == Constants.PURCHASE.ToLower())
                {
                    var supplierId = RichSupplierId.Text;
                    var billNo = selectedRow.Cells["BillNo"].Value.ToString();
                    PurchaseForm purchaseForm = new PurchaseForm(_itemService, _purchasedItemService, supplierId, billNo);
                    purchaseForm.Show();
                }
            }
        }

        private void BtnShowSupplier_Click(object sender, System.EventArgs e)
        {
            SupplierListForm supplierListForm = new SupplierListForm(_supplierService, _userTransactionService, this);
            supplierListForm.ShowDialog();
        }

        private void BtnAddSupplier_Click(object sender, System.EventArgs e)
        {
            ClearAllFields();
            EnableFields(true);
            RichSupplierId.Text = _supplierService.GetNewSupplierId();
        }
        
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                var date = DateTime.Now;
                var supplier = new Supplier
                {
                    SupplierId = RichSupplierId.Text,
                    Name = RichSupplierName.Text,
                    Address = RichAddress.Text,
                    ContactNo = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text,
                    Owner = RichOwner.Text,
                    AddedDate = date,
                    UpdatedDate = date
                };

                _supplierService.AddSupplier(supplier);
                DialogResult result = MessageBox.Show(supplier.Name + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnEdit_Click(object sender, System.EventArgs e)
        {
            EnableFields(true);
        }

        private void BtnUpdate_Click(object sender, System.EventArgs e)
        {
            var supplierId = RichSupplierId.Text;
            try
            {
                var supplier = _supplierService.UpdateSupplier(supplierId, new Supplier
                {
                    SupplierId = RichSupplierId.Text,
                    Name = RichSupplierName.Text,
                    Owner = RichOwner.Text,
                    Address = RichAddress.Text,
                    ContactNo = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text,
                    UpdatedDate = DateTime.Now
                }); 

                DialogResult result = MessageBox.Show(RichSupplierName.Text + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    DataGridSupplierList.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            var supplierName = RichSupplierName.Text;
            _supplierService.DeleteSupplier(supplierName);

            DialogResult result = MessageBox.Show(supplierName + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                ClearAllFields();
                DataGridSupplierList.DataSource = null;
            }
        }

        private void BtnPaymentSave_Click(object sender, EventArgs e)
        {
            try
            {
                var date = DateTime.Now;
                var userTransaction = new UserTransaction
                {
                    EndOfDay = _endOfDay,
                    BillNo = TxtBillNo.Text,
                    SupplierId = RichSupplierId.Text,
                    Action = Constants.PAYMENT,
                    ActionType = ComboPayment.Text,
                    Bank = ComboBank.Text,
                    SubTotal = 0.0m,
                    DiscountPercent = 0.0m,
                    Discount = 0.0m,
                    VatPercent = 0.0m,
                    Vat = 0.0m,
                    DeliveryChargePercent = 0.0m,
                    DeliveryCharge = 0.0m,
                    DueAmount = 0.0m,
                    ReceivedAmount = Convert.ToDecimal(RichAmount.Text),
                    AddedDate = date,
                    UpdatedDate = date
                };
                _userTransactionService.AddUserTransaction(userTransaction);

                if(ComboPayment.Text.ToLower() == Constants.CHEQUE.ToLower())
                {
                    var lastUserTransaction = _userTransactionService.GetLastUserTransaction(string.Empty);

                    ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                    var bankTransaction = new BankTransaction
                    {
                        EndOfDay = _endOfDay,
                        BankId = Convert.ToInt64(selectedItem.Id),
                        TransactionId = lastUserTransaction.Id,
                        Action = '0',
                        Debit = 0.0m,
                        Credit = Convert.ToDecimal(RichAmount.Text),
                        Narration = RichSupplierId.Text + " - " + RichSupplierName.Text,
                        AddedDate = date,
                        UpdatedDate = date
                    };

                    _bankTransactionService.AddBankTransaction(bankTransaction);
                }

                DialogResult result = MessageBox.Show(ComboPayment.Text + " has been paid successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ComboPayment.Text = string.Empty;
                    ComboBank.Text = string.Empty;
                    RichAmount.Clear();
                    var supplierTransactionViewList = GetSupplierTransaction();
                    LoadSupplierTransaction(supplierTransactionViewList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridSupplierList.SelectedRows.Count == 1)
                {
                    var supplierName = RichSupplierName.Text;
                    var id = Convert.ToInt64(DataGridSupplierList.SelectedCells[0].Value.ToString());
                    var particulars = DataGridSupplierList.SelectedCells[2].Value.ToString();
                    if (particulars.ToLower() != Constants.CASH.ToLower() && particulars.ToLower() != Constants.CHEQUE.ToLower())
                    {
                        _purchasedItemService.DeletePurchasedItem(particulars);
                        var supplierTransactionViewList = GetSupplierTransaction();
                        LoadSupplierTransaction(supplierTransactionViewList);
                    }

                    if (particulars.ToLower() == Constants.CASH.ToLower() || particulars.ToLower() == Constants.CHEQUE.ToLower())
                    {
                        var supplierTransactionViewList = GetSupplierTransaction();
                        LoadSupplierTransaction(supplierTransactionViewList);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnShowTransaction_Click(object sender, EventArgs e)
        {
            var supplierFilter = new SupplierFilter();
            if(!string.IsNullOrWhiteSpace(RichSupplierId.Text))
            {
                supplierFilter.SupplierId = RichSupplierId.Text;
            }

            var dateFrom = MaskEndOfDayFrom.Text;
            var dateTo = MaskEndOfDayTo.Text;
            if (!string.IsNullOrWhiteSpace(dateFrom.Replace("-", string.Empty).Trim()))
            {
                supplierFilter.DateFrom = dateFrom.Trim();
            }

            if (!string.IsNullOrWhiteSpace(dateFrom.Replace("-", string.Empty).Trim()))
            {
                supplierFilter.DateTo = dateTo.Trim();
            }

            supplierFilter.Action = ComboAction.Text;

            var supplierTransactionViewList = GetSupplierTransaction(supplierFilter);
            var balance = supplierTransactionViewList.Sum(x => x.Balance);
            TxtTotalAmount.Text = balance.ToString();
            TxtBalance.Text = balance.ToString();
            LoadSupplierTransaction(supplierTransactionViewList);
        }

        #endregion

        #region Combo Events

        private void ComboPaymentType_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedPayment = ComboPayment.Text;
            if (!string.IsNullOrWhiteSpace(selectedPayment))
            {
                if (selectedPayment.ToLower() == Constants.CHEQUE.ToLower())
                {
                    var banks = _bankService.GetBanks().ToList();
                    if (banks.Count > 0)
                    {
                        ComboBank.ValueMember = "Id";
                        ComboBank.DisplayMember = "Value";
                        banks.OrderBy(x => x.Name).ToList().ForEach(x =>
                        {
                            ComboBank.Items.Add(new ComboBoxItem { Id = x.Id.ToString(), Value = x.Name });
                        });

                        ComboBank.Enabled = true;
                        RichAmount.Enabled = true;
                        ComboBank.Focus();
                    } 
                }
                else
                {
                    ComboBank.Enabled = false;
                    RichAmount.Enabled = true;
                    RichAmount.Focus();
                }
            }   
        }

        #endregion

        #region DataGrid Event
        private void DataGridSupplierTransaction_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridSupplierList.Columns["Id"].Visible = false;

            DataGridSupplierList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridSupplierList.Columns["EndOfDay"].Width = 100;
            DataGridSupplierList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridSupplierList.Columns["Action"].HeaderText = "Description";
            DataGridSupplierList.Columns["Action"].Width = 100;
            DataGridSupplierList.Columns["Action"].DisplayIndex = 1;

            DataGridSupplierList.Columns["ActionType"].HeaderText = "Type";
            DataGridSupplierList.Columns["ActionType"].Width = 200;
            DataGridSupplierList.Columns["ActionType"].DisplayIndex = 2;

            DataGridSupplierList.Columns["BillNo"].HeaderText = "Bill No";
            DataGridSupplierList.Columns["BillNo"].Width = 100;
            DataGridSupplierList.Columns["BillNo"].DisplayIndex = 3;

            DataGridSupplierList.Columns["DueAmount"].HeaderText = "Debit";
            DataGridSupplierList.Columns["DueAmount"].Width = 100;
            DataGridSupplierList.Columns["DueAmount"].DisplayIndex = 4;
            DataGridSupplierList.Columns["DueAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridSupplierList.Columns["ReceivedAmount"].HeaderText = "Credit";
            DataGridSupplierList.Columns["ReceivedAmount"].Width = 100;
            DataGridSupplierList.Columns["ReceivedAmount"].DisplayIndex = 5;
            DataGridSupplierList.Columns["ReceivedAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridSupplierList.Columns["Balance"].HeaderText = "Balance";
            DataGridSupplierList.Columns["Balance"].DisplayIndex = 6;
            DataGridSupplierList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridSupplierList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridSupplierList.Rows)
            {
                DataGridSupplierList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridSupplierList.RowHeadersWidth = 50;
                DataGridSupplierList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        #endregion

        #region Helper Methods
        private List<SupplierTransactionView> GetSupplierTransaction()
        {
            var balance = _userTransactionService.GetSupplierTotalBalance(RichSupplierId.Text);
            TxtBalance.Text = decimal.Negate(balance).ToString();
            if (balance < 0)
            {
                TextBoxDebitCredit.Text = "Due";
            }
            else
            {
                TextBoxDebitCredit.Text = "Clear";
            }

            return _userTransactionService.GetSupplierTransactions(RichSupplierId.Text).ToList();
        }

        private List<SupplierTransactionView> GetSupplierTransaction(SupplierFilter supplierFilter)
        {
            return _userTransactionService.GetSupplierTransactions(supplierFilter).ToList();
        }

        private void LoadSupplierTransaction(List<SupplierTransactionView> supplierTransactionViewList)
        {
            var bindingList = new BindingList<SupplierTransactionView>(supplierTransactionViewList);
            var source = new BindingSource(bindingList, null);
            DataGridSupplierList.DataSource = source;
        }

        private void EnableFields(bool option = true)
        {
            RichSupplierName.Enabled = option;
            RichOwner.Enabled = option;
            RichAddress.Enabled = option;
            RichContactNumber.Enabled = option;
            RichEmail.Enabled = option;
        }

        private void ClearAllFields()
        {
            RichSupplierId.Clear();
            RichSupplierName.Clear();
            RichOwner.Clear();
            RichAddress.Clear();
            RichContactNumber.Clear();
            RichEmail.Clear();
        }

        public void PopulateSupplier(string supplierName)
        {
            var supplier = _supplierService.GetSupplier(supplierName);

            RichSupplierId.Text = supplier.SupplierId;
            RichSupplierName.Text = supplier.Name;
            RichOwner.Text = supplier.Owner;
            RichAddress.Text = supplier.Address;
            RichContactNumber.Text = supplier.ContactNo.ToString();
            RichEmail.Text = supplier.Email;
            
            TxtTotalAmount.Clear();
            ComboAction.Text = string.Empty;

            BtnPurchase.Enabled = true;
            BtnShowPurchase.Enabled = true;

            EnableFields(false);
            var supplierTransactionViewList = GetSupplierTransaction();
            LoadSupplierTransaction(supplierTransactionViewList);
        }

        public void PopulateItemsPurchaseDetails(string billNo)
        {
            TxtBillNo.Text = billNo;
            var supplierTransactionViewList = GetSupplierTransaction();
            LoadSupplierTransaction(supplierTransactionViewList);
        }

        public string GetSupplierName()
        {
            return RichSupplierName.Text;
        }

        public string GetSupplierId()
        {
            return RichSupplierId.Text;
        }
        #endregion
    }
}
