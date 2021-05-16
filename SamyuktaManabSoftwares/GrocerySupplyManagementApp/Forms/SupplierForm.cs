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
        private readonly ISupplierTransactionService _supplierTransactionService;

        public SupplierForm(ISupplierService supplierService, IItemService itemService, ISupplierTransactionService supplierTransactionService)
        {
            InitializeComponent();

            _supplierService = supplierService;
            _itemService = itemService;
            _supplierTransactionService = supplierTransactionService;
        }

        #region Form Load Events
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields(false);
            //LoadSupplierTransaction();
        }
        #endregion

        #region Button Events
        private void BtnPurchase_Click(object sender, System.EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm(this, _itemService, _supplierTransactionService);
            purchaseForm.Show();
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
                TextBoxDebitCredit.Text = "-";
            }

            List<DTOs.SupplierTransaction> supplierTransactions = _supplierTransactionService.GetSupplierTransactions(RichSupplierName.Text).ToList();

            List<DTOs.SupplierTransaction> supplierTransactionsView = supplierTransactions.Select(x => new DTOs.SupplierTransaction
            {
                Date = x.Date,
                Particulars = x.Particulars,
                Debit = x.Debit,
                Credit = x.Credit,
                Balance = x.Balance
            }).ToList();

            var bindingList = new BindingList<DTOs.SupplierTransaction>(supplierTransactionsView);
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

        private void BtnPaymentSave_Click(object sender, EventArgs e)
        {
            try
            {
                _supplierTransactionService.AddSupplierTransaction(new SupplierTransaction
                {
                    SupplierName = RichSupplierName.Text,
                    Status = "Repayment",
                    BillNo = TextBoxBillNo.Text,
                    RepaymentType = ComboPaymentType.Text,
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void DataGridSupplierTransaction_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridSupplierTransaction.Columns["Date"].HeaderText = "Date";
            DataGridSupplierTransaction.Columns["Date"].Width = 250;
            DataGridSupplierTransaction.Columns["Date"].DisplayIndex = 0;

            DataGridSupplierTransaction.Columns["Particulars"].HeaderText = "Particulars";
            DataGridSupplierTransaction.Columns["Particulars"].Width = 150;
            DataGridSupplierTransaction.Columns["Particulars"].DisplayIndex = 1;

            DataGridSupplierTransaction.Columns["Debit"].HeaderText = "Debit";
            DataGridSupplierTransaction.Columns["Debit"].Width = 100;
            DataGridSupplierTransaction.Columns["Debit"].DisplayIndex = 2;

            DataGridSupplierTransaction.Columns["Credit"].HeaderText = "Credit";
            DataGridSupplierTransaction.Columns["Credit"].Width = 100;
            DataGridSupplierTransaction.Columns["Credit"].DisplayIndex = 3;

            DataGridSupplierTransaction.Columns["Balance"].HeaderText = "Balance";
            //DataGridSupplierTransaction.Columns["Balance"].Width = 100;
            DataGridSupplierTransaction.Columns["Balance"].DisplayIndex = 4;

            DataGridSupplierTransaction.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
   

            foreach (DataGridViewRow row in DataGridSupplierTransaction.Rows)
            {
                DataGridSupplierTransaction.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridSupplierTransaction.RowHeadersWidth = 50;
            }
        }
    }
}
