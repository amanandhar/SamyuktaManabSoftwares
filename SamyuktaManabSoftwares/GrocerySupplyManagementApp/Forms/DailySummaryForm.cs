using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SummaryForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;

        #region Constructor
        public SummaryForm(IFiscalYearService fiscalYearService, IBankTransactionService bankTransactionService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService, 
            IUserTransactionService userTransactionService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankTransactionService = bankTransactionService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }
        #endregion

        #region Form Load Event
        private void SummaryForm_Load(object sender, EventArgs e)
        {
            MaskEndOfDay.Text = _endOfDay; 
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            string endOfDay = null;
            if (!string.IsNullOrWhiteSpace(MaskEndOfDay.Text.Replace("-", string.Empty).Trim()))
            {
                endOfDay = MaskEndOfDay.Text.Trim();
            }

            var previousSalesCash = _userTransactionService.GetPreviousTotalBalance(endOfDay, Constants.SALES, Constants.CASH);
            var previousSalesCredit = _userTransactionService.GetPreviousTotalBalance(endOfDay, Constants.SALES, Constants.CREDIT);
            var previousReceiptCash = _userTransactionService.GetPreviousTotalBalance(endOfDay, Constants.RECEIPT, Constants.CASH);
            var previousReceiptCheque = _userTransactionService.GetPreviousTotalBalance(endOfDay, Constants.RECEIPT, Constants.CHEQUE);
            var previousPaymentCash = _userTransactionService.GetPreviousTotalBalance(endOfDay, Constants.PAYMENT, Constants.CASH);
            var previousExpenseCash = _userTransactionService.GetPreviousTotalBalance(endOfDay, Constants.EXPENSE, Constants.CASH);
            var previousTransferCash = _userTransactionService.GetPreviousTotalBalance(endOfDay, Constants.TRANSFER, Constants.CASH);

            var openingBalanceCash = previousSalesCash + previousReceiptCash - (previousPaymentCash + previousExpenseCash + previousTransferCash);
            var openingBalanceCredit = previousSalesCredit - (previousReceiptCash + previousReceiptCheque);

            var salesCash = _userTransactionService.GetTotalBalance(endOfDay, Constants.SALES, Constants.CASH);
            var salesCredit = _userTransactionService.GetTotalBalance(endOfDay, Constants.SALES, Constants.CREDIT);
            var receiptCash = _userTransactionService.GetTotalBalance(endOfDay, Constants.RECEIPT, Constants.CASH);
            var receiptCheque = _userTransactionService.GetTotalBalance(endOfDay, Constants.RECEIPT, Constants.CHEQUE);
            var paymentCash = _userTransactionService.GetTotalBalance(endOfDay, Constants.PAYMENT, Constants.CASH);
            var expenseCash = _userTransactionService.GetTotalBalance(endOfDay, Constants.EXPENSE, Constants.CASH);
            var transferCash = _userTransactionService.GetTotalBalance(endOfDay, Constants.TRANSFER, Constants.CASH);
            var paymentCheque = _userTransactionService.GetTotalBalance(endOfDay, Constants.PAYMENT, Constants.CHEQUE);
            var expenseCheque = _userTransactionService.GetTotalBalance(endOfDay, Constants.EXPENSE, Constants.CHEQUE);

            TxtOpeningCashBalance.Text = openingBalanceCash.ToString();
            TxtOpeningCreditBalance.Text = openingBalanceCredit.ToString();
            TxtCashSales.Text = salesCash.ToString();
            TxtCreditSales.Text = salesCredit.ToString();
            TxtCashReceipt.Text = receiptCash.ToString();
            TxtChequeReceipt.Text = receiptCheque.ToString();
            TxtCashPayment.Text = (paymentCash + expenseCash + transferCash).ToString();
            TxtChequePayment.Text = (paymentCheque + expenseCheque).ToString();

            TxtCashBalance.Text = (openingBalanceCash + salesCash + receiptCash - (paymentCash + expenseCash + transferCash)).ToString();
            TxtCreditBalance.Text = (openingBalanceCredit + salesCredit - (receiptCash + receiptCheque)).ToString();

            var dailySummaryViewList = new List<DailySummaryView>() {
                new DailySummaryView() { Description = "Sales Cash", Debit = 0.00M, Credit = salesCash },
                new DailySummaryView() { Description = "Sales Credit", Debit = salesCredit, Credit = 0.00M },
                new DailySummaryView() { Description = "Receipt Cash", Debit = 0.00M, Credit = receiptCash },
                new DailySummaryView() { Description = "Receipt Cheque", Debit = 0.00M, Credit = receiptCheque },
                new DailySummaryView() { Description = "Payment Cash", Debit = paymentCash + expenseCash + transferCash, Credit = 0.00M },
                new DailySummaryView() { Description = "Payment Cheque", Debit = paymentCheque + expenseCheque, Credit = 0.00M }
            };

            LoadDailySummary(dailySummaryViewList);
        }

        private void BtnDailyTransactions_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_fiscalYearService,
                _bankTransactionService,
                _purchasedItemService, _soldItemService,
                _userTransactionService
                );

            transactionForm.Show();
        }
        #endregion

        #region DataGrid Event 
        private void DataGridSummaryList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridSummaryList.Columns["Description"].HeaderText = "Description";
            DataGridSummaryList.Columns["Description"].Width = 300;
            DataGridSummaryList.Columns["Description"].DisplayIndex = 0;

            DataGridSummaryList.Columns["Debit"].HeaderText = "Debit";
            DataGridSummaryList.Columns["Debit"].Width = 150;
            DataGridSummaryList.Columns["Debit"].DisplayIndex = 1;
            DataGridSummaryList.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridSummaryList.Columns["Credit"].HeaderText = "Credit";
            DataGridSummaryList.Columns["Credit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridSummaryList.Columns["Credit"].DisplayIndex = 2;
            DataGridSummaryList.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridSummaryList.Rows)
            {
                DataGridSummaryList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridSummaryList.RowHeadersWidth = 50;
                DataGridSummaryList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods 
        private void LoadDailySummary(List<DailySummaryView> dailySummaryViewList)
        {
            var bindingList = new BindingList<DailySummaryView>(dailySummaryViewList);
            var source = new BindingSource(bindingList, null);
            DataGridSummaryList.DataSource = source;
        }
        #endregion
    }
}
