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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IItemService _itemService;
        private readonly ISupplierService _supplierService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly ICapitalService _capitalService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Enum
        private enum Action
        {
            AddPurchase,
            AddSupplier,
            DeleteSupplier,
            EditSupplier,
            PopulateSupplier,
            SavePayment,
            ShowPurchase,
            SaveSupplier,
            SearchSupplier,
            ShowTransaction,
            UpdateSupplier,
            Load,
            None
        }
        #endregion 

        #region Constructor
        public SupplierForm(string username,
            ISettingService settingService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IItemService itemService, ISupplierService supplierService, 
            IPurchasedItemService purchasedItemService, IUserTransactionService userTransactionService,
            ICapitalService capitalService)
        {
            InitializeComponent();

            _settingService = settingService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _itemService = itemService;
            _supplierService = supplierService;
            _purchasedItemService = purchasedItemService;
            _userTransactionService = userTransactionService;
            _capitalService = capitalService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }

        #endregion

        #region Form Load Event
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            MaskEndOfDayFrom.Text = _endOfDay;
            MaskEndOfDayTo.Text = _endOfDay;
            LoadActions();
            LoadPayments();
            ClearAllFields();
            EnableFields();
            EnableFields(Action.Load);
        }
        #endregion

        #region Button Event

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SupplierListForm supplierListForm = new SupplierListForm(_supplierService, _capitalService, this);
            supplierListForm.ShowDialog();
        }

        private void BtnAddPurchase_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm(_username,
                _settingService, _itemService,
                _purchasedItemService, _userTransactionService, this);
            purchaseForm.Show();
        }

        private void BtnShowPurchase_Click(object sender, EventArgs e)
        {
            if (DataGridSupplierList.SelectedRows.Count == 1)
            {
                var selectedRow = DataGridSupplierList.SelectedRows[0];
                var action = selectedRow.Cells["Action"].Value.ToString();

                if (action.ToLower() == Constants.PURCHASE.ToLower())
                {
                    var supplierId = TxtSupplierId.Text;
                    var billNo = selectedRow.Cells["BillNo"].Value.ToString();
                    PurchaseForm purchaseForm = new PurchaseForm(_itemService, _purchasedItemService, supplierId, billNo);
                    purchaseForm.Show();
                }
            }
        }

        private void BtnSavePayment_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidateSupplierTransaction())
                {
                    var paymentType = ComboPayment.Text.Trim();
                    var paymentAmount = RichAmount.Text.Trim();
                    ComboBoxItem selectedItem = (ComboBoxItem)ComboBank.SelectedItem;

                    var paymentAmt = Convert.ToDecimal(paymentAmount);
                    if (paymentType.ToLower() == Constants.CASH.ToLower())
                    {
                        var cashBalance = _capitalService.GetCashBalance(_endOfDay);
                        if (paymentAmt > cashBalance)
                        {
                            var warningResult = MessageBox.Show("No sufficient cash available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (warningResult == DialogResult.OK)
                            {
                                RichAmount.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        var bankId = Convert.ToInt64(selectedItem?.Id);
                        var bankBalance = _bankTransactionService.GetTotalBalance(new BankTransactionFilter { BankId = bankId });
                        if (paymentAmt > bankBalance)
                        {
                            var warningResult = MessageBox.Show("No sufficient amount in bank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (warningResult == DialogResult.OK)
                            {
                                RichAmount.Focus();
                                return;
                            }
                        }
                    }

                    var balance = Convert.ToDecimal(TxtBalance.Text);
                    if (paymentAmt > balance)
                    {
                        var warningResult = MessageBox.Show("Receipt cannot be greater than balance.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (warningResult == DialogResult.OK)
                        {
                            RichAmount.Focus();
                        }
                    }
                    else
                    {
                        var userTransaction = new UserTransaction
                        {
                            EndOfDay = _endOfDay,
                            BillNo = TxtBillNo.Text,
                            SupplierId = TxtSupplierId.Text,
                            Action = Constants.PAYMENT,
                            ActionType = ComboPayment.Text,
                            Bank = ComboBank.Text,
                            PaymentAmount = Convert.ToDecimal(RichAmount.Text),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };
                        _userTransactionService.AddUserTransaction(userTransaction);

                        if (ComboPayment.Text.ToLower() == Constants.CHEQUE.ToLower())
                        {
                            var lastUserTransaction = _userTransactionService.GetLastUserTransaction(_username, string.Empty);
                            var bankTransaction = new BankTransaction
                            {
                                EndOfDay = _endOfDay,
                                BankId = Convert.ToInt64(selectedItem.Id),
                                TransactionId = lastUserTransaction.Id,
                                Action = '0',
                                Debit = Constants.DEFAULT_DECIMAL_VALUE,
                                Credit = Convert.ToDecimal(RichAmount.Text),
                                Narration = TxtSupplierId.Text + " - " + TxtSupplierName.Text,
                                AddedBy = _username,
                                AddedDate = DateTime.Now
                            };

                            _bankTransactionService.AddBankTransaction(bankTransaction);
                        }

                        DialogResult result = MessageBox.Show(ComboPayment.Text + " has been paid successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            ComboPayment.Text = string.Empty;
                            ComboBank.Text = string.Empty;
                            RichAmount.Clear();
                            var supplierTransactionViewList = GetSupplierTransaction();
                            LoadSupplierTransaction(supplierTransactionViewList);
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

        private void BtnAddSuppliers_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields();
            EnableFields(Action.AddSupplier);
            TxtSupplierId.Text = _supplierService.GetNewSupplierId();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidateSupplierInfo())
                {
                    var supplier = new Supplier
                    {
                        EndOfDay = _endOfDay,
                        SupplierId = TxtSupplierId.Text,
                        Name = TxtSupplierName.Text,
                        Address = TxtAddress.Text,
                        ContactNo = string.IsNullOrEmpty(TxtContactNumber.Text) ? 0 : Convert.ToInt64(TxtContactNumber.Text),
                        Email = TxtEmail.Text,
                        Owner = TxtOwner.Text,
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _supplierService.AddSupplier(supplier);
                    DialogResult result = MessageBox.Show(supplier.Name + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields();
                        EnableFields(Action.SaveSupplier);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.EditSupplier);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var supplierId = TxtSupplierId.Text;
            try
            {
                if (ValidateSupplierInfo())
                {
                    var supplier = _supplierService.UpdateSupplier(supplierId, new Supplier
                    {
                        SupplierId = TxtSupplierId.Text,
                        Name = TxtSupplierName.Text,
                        Owner = TxtOwner.Text,
                        Address = TxtAddress.Text,
                        ContactNo = string.IsNullOrEmpty(TxtContactNumber.Text) ? 0 : Convert.ToInt64(TxtContactNumber.Text),
                        Email = TxtEmail.Text,
                        UpdatedBy = _username,
                        UpdatedDate = DateTime.Now
                    });

                    DialogResult result = MessageBox.Show(TxtSupplierName.Text + " has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        DataGridSupplierList.DataSource = null;
                        EnableFields();
                        EnableFields(Action.UpdateSupplier);
                    }
                }   
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var supplierName = TxtSupplierName.Text;
            _supplierService.DeleteSupplier(supplierName);

            DialogResult result = MessageBox.Show(supplierName + " has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                ClearAllFields();
                DataGridSupplierList.DataSource = null;
                EnableFields();
                EnableFields(Action.DeleteSupplier);
            }
        }

        private void BtnShowTransaction_Click(object sender, EventArgs e)
        {
            var supplierFilter = new SupplierTransactionFilter();
            if (!string.IsNullOrWhiteSpace(TxtSupplierId.Text))
            {
                supplierFilter.SupplierId = TxtSupplierId.Text;
            }

            supplierFilter.DateFrom = UtilityService.GetDate(MaskEndOfDayFrom.Text);
            supplierFilter.DateTo = UtilityService.GetDate(MaskEndOfDayTo.Text);
            supplierFilter.Action = ComboAction.Text;

            var supplierTransactionViewList = GetSupplierTransaction(supplierFilter);
            var balance = supplierTransactionViewList.Sum(x => x.Balance);
            TxtTotalAmount.Text = balance.ToString();
            TxtBalance.Text = balance.ToString();
            LoadSupplierTransaction(supplierTransactionViewList);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridSupplierList.SelectedRows.Count == 1)
                {
                    var supplierName = TxtSupplierName.Text;
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
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        #endregion

        #region Text Box Event
        private void TxtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void RichAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
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

        private void ComboBank_SelectedValueChanged(object sender, EventArgs e)
        {
            RichAmount.Enabled = true;
            RichAmount.Focus();
        }

        #endregion

        #region DataGrid Event
        private void DataGridSupplierTransaction_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridSupplierList.Columns["Id"].Visible = false;

            DataGridSupplierList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridSupplierList.Columns["EndOfDay"].Width = 90;
            DataGridSupplierList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridSupplierList.Columns["Action"].HeaderText = "Description";
            DataGridSupplierList.Columns["Action"].Width = 100;
            DataGridSupplierList.Columns["Action"].DisplayIndex = 1;

            DataGridSupplierList.Columns["ActionType"].HeaderText = "Type";
            DataGridSupplierList.Columns["ActionType"].Width = 230;
            DataGridSupplierList.Columns["ActionType"].DisplayIndex = 2;

            DataGridSupplierList.Columns["BillNo"].HeaderText = "Bill No";
            DataGridSupplierList.Columns["BillNo"].Width = 100;
            DataGridSupplierList.Columns["BillNo"].DisplayIndex = 3;

            DataGridSupplierList.Columns["DuePaymentAmount"].HeaderText = "Debit";
            DataGridSupplierList.Columns["DuePaymentAmount"].Width = 100;
            DataGridSupplierList.Columns["DuePaymentAmount"].DisplayIndex = 4;
            DataGridSupplierList.Columns["DuePaymentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridSupplierList.Columns["PaymentAmount"].HeaderText = "Credit";
            DataGridSupplierList.Columns["PaymentAmount"].Width = 100;
            DataGridSupplierList.Columns["PaymentAmount"].DisplayIndex = 5;
            DataGridSupplierList.Columns["PaymentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
            var supplierId = TxtSupplierId.Text.Trim();
            var balance = _capitalService.GetSupplierTotalBalance(new SupplierTransactionFilter() { SupplierId = supplierId });
            
            if (balance > 0)
            {
                TxtBalance.Text = balance.ToString();
                TextBoxDebitCredit.Text = Constants.DUE;
            }
            else if (balance < 0)
            {
                TxtBalance.Text = decimal.Negate(balance).ToString();
                TextBoxDebitCredit.Text = Constants.OWNED;
            }
            else
            {
                TxtBalance.Text = balance.ToString();
                TextBoxDebitCredit.Text = Constants.CLEAR;
            }

            return _userTransactionService
                .GetSupplierTransactions(new SupplierTransactionFilter() { SupplierId = supplierId })
                .ToList();
        }

        private List<SupplierTransactionView> GetSupplierTransaction(SupplierTransactionFilter supplierFilter)
        {
            return _userTransactionService.GetSupplierTransactions(supplierFilter).ToList();
        }

        private void LoadSupplierTransaction(List<SupplierTransactionView> supplierTransactionViewList)
        {
            var bindingList = new BindingList<SupplierTransactionView>(supplierTransactionViewList);
            var source = new BindingSource(bindingList, null);
            DataGridSupplierList.DataSource = source;
        }

        private void EnableFields(Action action = Action.None)
        {
            if(action == Action.AddPurchase)
            {
            }
            else if (action == Action.AddSupplier)
            {
                TxtSupplierName.Enabled = true;
                TxtOwner.Enabled = true;
                TxtAddress.Enabled = true;
                TxtContactNumber.Enabled = true;
                TxtEmail.Enabled = true;

                BtnSave.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == Action.DeleteSupplier)
            {
                BtnAddSupplier.Enabled = true;
            }
            else if (action == Action.EditSupplier)
            {
                TxtSupplierName.Enabled = true;
                TxtOwner.Enabled = true;
                TxtAddress.Enabled = true;
                TxtContactNumber.Enabled = true;
                TxtEmail.Enabled = true;

                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == Action.PopulateSupplier)
            {
                BtnAddSupplier.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddPurchase.Enabled = true;
                BtnShowPurchase.Enabled = true;
                BtnSavePayment.Enabled = true;
            }
            else if (action == Action.Load)
            {
                BtnAddSupplier.Enabled = true;
            }
            else if (action == Action.SavePayment)
            {

            }
            else if (action == Action.SaveSupplier)
            {
                BtnAddSupplier.Enabled = true;
            }
            else if (action == Action.ShowPurchase)
            {

            }
            else if (action == Action.SearchSupplier)
            {
                BtnAddSupplier.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == Action.ShowTransaction)
            {

            }
            else if (action == Action.UpdateSupplier)
            {
                BtnAddSupplier.Enabled = true;
            }
            else
            {
                BtnSearchSupplier.Enabled = true;
                BtnAddPurchase.Enabled = false;
                BtnShowPurchase.Enabled = false;
                BtnSavePayment.Enabled = false;
                BtnAddSupplier.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
                BtnShowTransaction.Enabled = true;

                TxtSupplierName.Enabled = false;
                TxtOwner.Enabled = false;
                TxtAddress.Enabled = false;
                TxtContactNumber.Enabled = false;
                TxtEmail.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            TxtSupplierId.Clear();
            TxtSupplierName.Clear();
            TxtOwner.Clear();
            TxtAddress.Clear();
            TxtContactNumber.Clear();
            TxtEmail.Clear();
        }

        public void PopulateSupplier(string supplierName)
        {
            var supplier = _supplierService.GetSupplier(supplierName);

            TxtSupplierId.Text = supplier.SupplierId;
            TxtSupplierName.Text = supplier.Name;
            TxtOwner.Text = supplier.Owner;
            TxtAddress.Text = supplier.Address;
            TxtContactNumber.Text = supplier.ContactNo.ToString();
            TxtEmail.Text = supplier.Email;
            
            TxtTotalAmount.Clear();
            ComboAction.Text = string.Empty;

            BtnAddPurchase.Enabled = true;
            BtnShowPurchase.Enabled = true;

            EnableFields();
            EnableFields(Action.PopulateSupplier);
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
            return TxtSupplierName.Text;
        }

        public string GetSupplierId()
        {
            return TxtSupplierId.Text;
        }

        public void LoadActions()
        {
            ComboAction.Items.Clear();
            ComboAction.ValueMember = "Id";
            ComboAction.DisplayMember = "Value";

            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.PAYMENT, Value = Constants.PAYMENT });
            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.PURCHASE, Value = Constants.PURCHASE });
        }

        public void LoadPayments()
        {
            ComboAction.Items.Clear();
            ComboPayment.ValueMember = "Id";
            ComboPayment.DisplayMember = "Value";

            ComboPayment.Items.Add(new ComboBoxItem { Id = Constants.CASH, Value = Constants.CASH });
            ComboPayment.Items.Add(new ComboBoxItem { Id = Constants.CHEQUE, Value = Constants.CHEQUE });
        }
        #endregion

        #region Validation
        private bool ValidateSupplierInfo()
        {
            var isValidated = false;

            var supplierId = TxtSupplierId.Text.Trim();
            var supplierName = TxtSupplierName.Text.Trim();

            if (string.IsNullOrWhiteSpace(supplierId)
                || string.IsNullOrWhiteSpace(supplierName))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Supplier Id " +
                    "\n * Supplier Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }

        private bool ValidateSupplierTransaction()
        {
            var isValidated = false;

            var payment = ComboPayment.Text.Trim();
            var bank = ComboBank.Text.Trim();
            var amount = RichAmount.Text.Trim();

            if (string.IsNullOrWhiteSpace(payment)
                || (payment == Constants.CASH && string.IsNullOrWhiteSpace(amount)))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Payment " +
                    "\n * Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(payment)
                || (payment == Constants.CHEQUE && string.IsNullOrWhiteSpace(bank))
                || string.IsNullOrWhiteSpace(amount))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Payment " +
                    "\n * Bank " +
                    "\n * Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
