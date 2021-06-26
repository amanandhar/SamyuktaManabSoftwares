using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services;
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
        private readonly ISupplierTransactionService _supplierTransactionService;
        private readonly IBankDetailService _bankDetailService;

        public SupplierForm(ISupplierService supplierService, IItemService itemService, 
            IItemTransactionService itemTransactionService, ISupplierTransactionService supplierTransactionService,
            IBankDetailService bankDetailService)
        {
            InitializeComponent();

            _supplierService = supplierService;
            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            _supplierTransactionService = supplierTransactionService;
            _bankDetailService = bankDetailService;
        }

        #region Form Load Events
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields(false);
        }
        #endregion

        #region Button Events
        private void BtnPurchase_Click(object sender, System.EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm(this, _itemService, _itemTransactionService, _supplierTransactionService);
            purchaseForm.Show();
        }

        private void BtnShowPurchase_Click(object sender, EventArgs e)
        {
            if(DataGridSupplierTransaction.SelectedRows.Count == 1)
            {
                var particulars = DataGridSupplierTransaction.SelectedCells[2].Value.ToString();

                if(particulars.ToLower() != "cash" && particulars.ToLower() != "cheque")
                {
                    var supplierName = RichSupplierName.Text;
                    var billNo = particulars;
                    PurchaseForm purchaseForm = new PurchaseForm(_itemService, _itemTransactionService, supplierName, billNo);
                    purchaseForm.Show();
                }
            }
        }

        private void BtnShowSupplier_Click(object sender, System.EventArgs e)
        {
            SupplierListForm supplierListForm = new SupplierListForm(_supplierService, this);
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
            var supplierName = RichSupplierName.Text;
            try
            {
                var supplier = _supplierService.UpdateSupplier(supplierName, new Supplier
                {
                    Name = RichSupplierName.Text,
                    Owner = RichOwner.Text,
                    Address = RichAddress.Text,
                    ContactNumber = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    Email = RichEmail.Text
                }); 

                DialogResult result = MessageBox.Show(supplierName + " has been updated successfully.", "Message", MessageBoxButtons.OK);
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

        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            var supplierName = RichSupplierName.Text;
            _supplierService.DeleteSupplier(supplierName);

            DialogResult result = MessageBox.Show(supplierName + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                ClearAllFields();
            }
        }

        private void BtnPaymentSave_Click(object sender, EventArgs e)
        {
            try
            {
                _supplierTransactionService.AddSupplierTransaction(new SupplierTransaction
                {
                    SupplierName = RichSupplierName.Text,
                    Status = "Payment",
                    BillNo = TextBoxBillNo.Text,
                    PaymentType = ComboPaymentType.Text,
                    Bank = ComboBank.Text,
                    Credit = Convert.ToDecimal(RichAmount.Text),
                    Date = DateTime.Now
                });
                DialogResult result = MessageBox.Show(ComboPaymentType.Text + " has been paid successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ComboPaymentType.Text = string.Empty;
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
                    if (particulars.ToLower() != "cash" && particulars.ToLower() != "cheque")
                    {
                        if (_supplierTransactionService.DeleteSupplierTransaction(id))
                        {
                            _itemTransactionService.DeleteItemTransactionBySupplierAndBill(supplierName, particulars);
                            LoadSupplierTransaction();
                        }
                    }

                    if (particulars.ToLower() == "cash" || particulars.ToLower() == "cheque")
                    {
                        _supplierTransactionService.DeleteSupplierTransaction(id);
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
            RichSupplierName.Enabled = option;
            RichOwner.Enabled = option;
            RichAddress.Enabled = option;
            RichContactNumber.Enabled = option;
            RichEmail.Enabled = option;
        }

        private void ClearAllFields()
        {
            RichSupplierName.Clear();
            RichOwner.Clear();
            RichAddress.Clear();
            RichContactNumber.Clear();
            RichEmail.Clear();
        }

        private void LoadSupplierTransaction()
        {
            var balance = _supplierTransactionService.GetBalance(RichSupplierName.Text);
            RichBalance.Text = balance.ToString();
            if (balance > 0)
            {
                TextBoxDebitCredit.Text = "DR";
            }
            else if(balance < 0)
            {
                TextBoxDebitCredit.Text = "CR";
            }
            else
            {
                TextBoxDebitCredit.Text = "NA";
            }

            List<DTOs.SupplierTransactionView> supplierTransactions = _supplierTransactionService.GetSupplierTransactions(RichSupplierName.Text).ToList();

            List<DTOs.SupplierTransactionView> supplierTransactionsView = supplierTransactions.Select(x => new DTOs.SupplierTransactionView
            {
                Id = x.Id,
                Date = x.Date,
                Particulars = x.Particulars,
                BillNoBank = x.BillNoBank,
                Debit = x.Debit,
                Credit = x.Credit,
                Balance = x.Balance
            }).ToList();

            var bindingList = new BindingList<DTOs.SupplierTransactionView>(supplierTransactionsView);
            var source = new BindingSource(bindingList, null);
            DataGridSupplierTransaction.DataSource = source;
        }

        public void PopulateSupplier(string supplierName)
        {
            var supplier = _supplierService.GetSupplier(supplierName);

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

        public void PopulateItemsPurchaseDetails(string billNo, decimal purchaseAmount)
        {
            TextBoxBillNo.Text = billNo;
            RichPurchaseAmount.Text = purchaseAmount.ToString();
            LoadSupplierTransaction();
        }

        public string GetSupplierName()
        {
            return RichSupplierName.Text;
        }
        #endregion

        #region DataGrid Events
        private void DataGridSupplierTransaction_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridSupplierTransaction.Columns["Id"].Visible = false;

            DataGridSupplierTransaction.Columns["Date"].HeaderText = "Date";
            DataGridSupplierTransaction.Columns["Date"].Width = 100;
            DataGridSupplierTransaction.Columns["Date"].DisplayIndex = 1;
            DataGridSupplierTransaction.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";

            DataGridSupplierTransaction.Columns["Particulars"].HeaderText = "Particulars";
            DataGridSupplierTransaction.Columns["Particulars"].Width = 150;
            DataGridSupplierTransaction.Columns["Particulars"].DisplayIndex = 2;

            DataGridSupplierTransaction.Columns["BillNoBank"].HeaderText = "Bill No/Bank";
            DataGridSupplierTransaction.Columns["BillNoBank"].Width = 150;
            DataGridSupplierTransaction.Columns["BillNoBank"].DisplayIndex = 3;

            DataGridSupplierTransaction.Columns["Debit"].HeaderText = "Debit";
            DataGridSupplierTransaction.Columns["Debit"].Width = 100;
            DataGridSupplierTransaction.Columns["Debit"].DisplayIndex = 4;

            DataGridSupplierTransaction.Columns["Credit"].HeaderText = "Credit";
            DataGridSupplierTransaction.Columns["Credit"].Width = 100;
            DataGridSupplierTransaction.Columns["Credit"].DisplayIndex = 5;

            DataGridSupplierTransaction.Columns["Balance"].HeaderText = "Balance";
            DataGridSupplierTransaction.Columns["Balance"].DisplayIndex = 6;
            DataGridSupplierTransaction.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
  
            foreach (DataGridViewRow row in DataGridSupplierTransaction.Rows)
            {
                DataGridSupplierTransaction.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridSupplierTransaction.RowHeadersWidth = 50;
            }
        }

        #endregion

        private void ComboPaymentType_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedPayment = ComboPaymentType.Text;
            if(selectedPayment.ToLower().Equals("cheque"))
            {
                var bankDetails = _bankDetailService.GetBankDetails().ToList();
                bankDetails.OrderBy(x => x.Name).ToList().ForEach(x =>
                {
                    ComboBank.Items.Add(x.Name);
                });
                
                ComboBank.Enabled = true;
                RichAmount.Enabled = true;
                ComboBank.Focus();
            }
            else
            {
                ComboBank.Enabled = false;
                RichAmount.Enabled = true;
                RichAmount.Focus();
            }
        }
    }
}
