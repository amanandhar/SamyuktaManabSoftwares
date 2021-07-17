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
        private readonly ISupplierService _supplierService;
        private readonly IItemService _itemService;
        private readonly IItemTransactionService _itemTransactionService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IFiscalYearService _fiscalYearService;

        #region Constructor
        public SupplierForm(ISupplierService supplierService, IItemService itemService, 
            IItemTransactionService itemTransactionService, 
            IBankService bankService, IBankTransactionService bankTransactionService, 
            IUserTransactionService userTransactionService,IFiscalYearService fiscalYearService)
        {
            InitializeComponent();

            _supplierService = supplierService;
            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _userTransactionService = userTransactionService;
            _fiscalYearService = fiscalYearService;
        }

        #endregion

        #region Form Load Event
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields(false);
            LoadSupplierTransaction();
        }
        #endregion

        #region Button Event
        private void BtnPurchase_Click(object sender, System.EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm(this, _itemService,
                _itemTransactionService, _userTransactionService, 
                _fiscalYearService);
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
                    PurchaseForm purchaseForm = new PurchaseForm(_itemService, _itemTransactionService, supplierId, billNo);
                    purchaseForm.Show();
                }
            }
        }

        private void BtnShowSupplier_Click(object sender, System.EventArgs e)
        {
            SupplierListForm supplierListForm = new SupplierListForm(_supplierService, _userTransactionService, this);
            supplierListForm.Show();
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
                var supplier = new Supplier
                {
                    SupplierId = RichSupplierId.Text,
                    Name = RichSupplierName.Text,
                    Address = RichAddress.Text,
                    ContactNo = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text,
                    Owner = RichOwner.Text,
                    Date = DateTime.Now
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
                    Email = RichEmail.Text
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
                var fiscalYear = _fiscalYearService.GetFiscalYear();
                var userTransaction = new UserTransaction
                {
                    EndOfDate = fiscalYear.StartingDate,
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
                    Date = DateTime.Now
                };
                _userTransactionService.AddUserTransaction(userTransaction);

                if(ComboPayment.Text.ToLower() == Constants.CHEQUE.ToLower())
                {
                    var lastUserTransaction = _userTransactionService.GetLastUserTransaction(string.Empty);

                    ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;
                    var bankTransaction = new BankTransaction
                    {
                        EndOfDate = fiscalYear.StartingDate,
                        BankId = Convert.ToInt64(selectedItem.Id),
                        TransactionId = lastUserTransaction.Id,
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
                if (DataGridSupplierList.SelectedRows.Count == 1)
                {
                    var supplierName = RichSupplierName.Text;
                    var id = Convert.ToInt64(DataGridSupplierList.SelectedCells[0].Value.ToString());
                    var particulars = DataGridSupplierList.SelectedCells[2].Value.ToString();
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

            DataGridSupplierList.Columns["EndOfDate"].HeaderText = "Date";
            DataGridSupplierList.Columns["EndOfDate"].Width = 100;
            DataGridSupplierList.Columns["EndOfDate"].DisplayIndex = 0;
            DataGridSupplierList.Columns["EndOfDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

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

        private void LoadSupplierTransaction()
        {
            var balance = _userTransactionService.GetSupplierTotalBalance(RichSupplierId.Text);
            RichBalance.Text = decimal.Negate(balance).ToString();
            if (balance < 0)
            {
                TextBoxDebitCredit.Text = "Due";
            }
            else
            {
                TextBoxDebitCredit.Text = "Clear";
            }

            List<SupplierTransactionView> supplierTransactionViews = _userTransactionService.GetSupplierTransactions(RichSupplierId.Text).ToList();

            var bindingList = new BindingList<SupplierTransactionView>(supplierTransactionViews);
            var source = new BindingSource(bindingList, null);
            DataGridSupplierList.DataSource = source;
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
    }
}
