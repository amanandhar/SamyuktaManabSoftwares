using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SupplierForm : Form
    {
        private readonly ISupplierService _supplierService;
        private readonly IItemService _itemService;
        private readonly IItemTransactionService _itemTransactionService;
        private readonly IBankDetailService _bankDetailService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IUserTransactionService _posTransactionService;
        private readonly IFiscalYearDetailService _fiscalYearDetailService;

        #region Constructor
        public SupplierForm(ISupplierService supplierService, IItemService itemService, 
            IItemTransactionService itemTransactionService, 
            IBankDetailService bankDetailService, IBankTransactionService bankTransactionService, 
            IUserTransactionService posTransactionService,IFiscalYearDetailService fiscalYearDetailService)
        {
            InitializeComponent();

            _supplierService = supplierService;
            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            _bankDetailService = bankDetailService;
            _bankTransactionService = bankTransactionService;
            _posTransactionService = posTransactionService;
            _fiscalYearDetailService = fiscalYearDetailService;
        }

        #endregion

        #region Form Load Event
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields(false);
        }
        #endregion

        #region Button Events
        private void BtnPurchase_Click(object sender, System.EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm(this, _itemService,
                _itemTransactionService, _posTransactionService, 
                _fiscalYearDetailService);
            purchaseForm.Show();
        }

        private void BtnShowPurchase_Click(object sender, EventArgs e)
        {
            if(DataGridSupplierTransaction.SelectedRows.Count == 1)
            {
                var particulars = DataGridSupplierTransaction.SelectedCells[2].Value.ToString();

                if (particulars.ToLower() == Constants.PURCHASE.ToLower())
                {
                    var supplierName = RichSupplierName.Text;
                    var billNo = DataGridSupplierTransaction.SelectedCells[4].Value.ToString();
                    PurchaseForm purchaseForm = new PurchaseForm(_itemService, _itemTransactionService, supplierName, billNo);
                    purchaseForm.Show();
                }
            }
        }

        private void BtnShowSupplier_Click(object sender, System.EventArgs e)
        {
            SupplierListForm supplierListForm = new SupplierListForm(_supplierService, _posTransactionService, this);
            supplierListForm.Show();
        }

        private void BtnAddSupplier_Click(object sender, System.EventArgs e)
        {
            ClearAllFields();
            EnableFields(true);
        }
        
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                var supplier = _supplierService.AddSupplier(new Supplier
                {
                    SupplierId = RichSupplierId.Text,
                    Name = RichSupplierName.Text,
                    Owner = RichOwner.Text,
                    Address = RichAddress.Text,
                    ContactNumber = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text
                });

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
                    ContactNumber = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text
                }); 

                DialogResult result = MessageBox.Show(RichSupplierName.Text + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    DataGridSupplierTransaction.DataSource = null;
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
                DataGridSupplierTransaction.DataSource = null;
            }
        }

        private void BtnPaymentSave_Click(object sender, EventArgs e)
        {
            try
            {
                var fiscalYearDetail = _fiscalYearDetailService.GetFiscalYearDetail();
                var posTransaction = new UserTransaction
                {
                    InvoiceDate = fiscalYearDetail.StartingDate,
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
                    TotalAmount = 0.0m,
                    ReceivedAmount = Convert.ToDecimal(RichAmount.Text),
                    Date = DateTime.Now
                };
                _posTransactionService.AddPosTransaction(posTransaction);

                if(ComboPayment.Text.ToLower() == Constants.CHEQUE.ToLower())
                {
                    var lastPosTransaction = _posTransactionService.GetLastPosTransaction(string.Empty);

                    ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                    var bankTransaction = new BankTransaction
                    {
                        BankId = Convert.ToInt64(selectedItem.Id),
                        TransactionId = lastPosTransaction.Id,
                        Action = '0',
                        Debit = 0.0m,
                        Credit = Convert.ToDecimal(RichAmount.Text),
                        Narration = RichSupplierId.Text + " - " + RichSupplierName.Text,
                        Date = DateTime.Now
                    };
                    _bankTransactionService.AddBankTransaction(bankTransaction);
                }

                DialogResult result = MessageBox.Show(ComboPayment.Text + " has been paid successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ComboPayment.Text = string.Empty;
                    ComboBank.Text = string.Empty;
                    RichAmount.Clear();
                    LoadSupplierTransaction();
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
                if (DataGridSupplierTransaction.SelectedRows.Count == 1)
                {
                    var supplierName = RichSupplierName.Text;
                    var id = Convert.ToInt64(DataGridSupplierTransaction.SelectedCells[0].Value.ToString());
                    var particulars = DataGridSupplierTransaction.SelectedCells[2].Value.ToString();
                    if (particulars.ToLower() != Constants.CASH.ToLower() && particulars.ToLower() != Constants.CHEQUE.ToLower())
                    {
                        _itemTransactionService.DeleteItemTransaction(particulars);
                        LoadSupplierTransaction();
    
                    }

                    if (particulars.ToLower() == Constants.CASH.ToLower() || particulars.ToLower() == Constants.CHEQUE.ToLower())
                    {
                        LoadSupplierTransaction();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Helper Methods
        private void EnableFields(bool option = true)
        {
            RichSupplierId.Enabled = option;
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

        private void LoadSupplierTransaction()
        {
            var balance = _posTransactionService.GetSupplierTotalBalance(RichSupplierId.Text);
            RichBalance.Text = Decimal.Negate(balance).ToString();
            if (balance < 0)
            {
                TextBoxDebitCredit.Text = "Due";
            }
            else
            {
                TextBoxDebitCredit.Text = "Clear";
            }

            List<SupplierTransactionView> supplierTransactionViews = _posTransactionService.GetSupplierTransactions(RichSupplierId.Text).ToList();

            var bindingList = new BindingList<SupplierTransactionView>(supplierTransactionViews);
            var source = new BindingSource(bindingList, null);
            DataGridSupplierTransaction.DataSource = source;
        }

        public void PopulateSupplier(string supplierName)
        {
            var supplier = _supplierService.GetSupplier(supplierName);

            RichSupplierId.Text = supplier.SupplierId;
            RichSupplierName.Text = supplier.Name;
            RichOwner.Text = supplier.Owner;
            RichAddress.Text = supplier.Address;
            RichContactNumber.Text = supplier.ContactNumber.ToString();
            RichEmail.Text = supplier.Email;

            BtnPurchase.Enabled = true;
            BtnShowPurchase.Enabled = true;

            EnableFields(false);

            LoadSupplierTransaction();
        }

        public void PopulateItemsPurchaseDetails(string billNo)
        {
            TxtBillNo.Text = billNo;
            LoadSupplierTransaction();
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

        #region DataGrid Events
        private void DataGridSupplierTransaction_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridSupplierTransaction.Columns["Id"].Visible = false;

            DataGridSupplierTransaction.Columns["InvoiceDate"].HeaderText = "Date";
            DataGridSupplierTransaction.Columns["InvoiceDate"].Width = 100;
            DataGridSupplierTransaction.Columns["InvoiceDate"].DisplayIndex = 1;
            DataGridSupplierTransaction.Columns["InvoiceDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

            DataGridSupplierTransaction.Columns["Action"].HeaderText = "Particulars";
            DataGridSupplierTransaction.Columns["Action"].Width = 100;
            DataGridSupplierTransaction.Columns["Action"].DisplayIndex = 2;

            DataGridSupplierTransaction.Columns["ActionType"].HeaderText = "Type";
            DataGridSupplierTransaction.Columns["ActionType"].Width = 200;
            DataGridSupplierTransaction.Columns["ActionType"].DisplayIndex = 3;

            DataGridSupplierTransaction.Columns["BillNo"].HeaderText = "Bill No";
            DataGridSupplierTransaction.Columns["BillNo"].Width = 100;
            DataGridSupplierTransaction.Columns["BillNo"].DisplayIndex = 4;

            DataGridSupplierTransaction.Columns["TotalAmount"].HeaderText = "Debit";
            DataGridSupplierTransaction.Columns["TotalAmount"].Width = 100;
            DataGridSupplierTransaction.Columns["TotalAmount"].DisplayIndex = 5;

            DataGridSupplierTransaction.Columns["ReceivedAmount"].HeaderText = "Credit";
            DataGridSupplierTransaction.Columns["ReceivedAmount"].Width = 100;
            DataGridSupplierTransaction.Columns["ReceivedAmount"].DisplayIndex = 6;

            DataGridSupplierTransaction.Columns["Balance"].HeaderText = "Balance";
            DataGridSupplierTransaction.Columns["Balance"].DisplayIndex = 7;
            DataGridSupplierTransaction.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
  
            foreach (DataGridViewRow row in DataGridSupplierTransaction.Rows)
            {
                DataGridSupplierTransaction.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridSupplierTransaction.RowHeadersWidth = 50;
            }
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
                    var bankDetails = _bankDetailService.GetBankDetails().ToList();
                    if (bankDetails.Count > 0)
                    {
                        ComboBank.ValueMember = "Id";
                        ComboBank.DisplayMember = "Value";
                        bankDetails.OrderBy(x => x.Name).ToList().ForEach(x =>
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
    }
}
