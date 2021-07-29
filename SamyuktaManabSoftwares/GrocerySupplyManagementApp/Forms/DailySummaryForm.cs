using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
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
        private void BtnDailyTransactions_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_fiscalYearService,
                _bankTransactionService,
                _purchasedItemService, _soldItemService, 
                _userTransactionService
                );

            transactionForm.Show();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            var endOfDay = (MaskEndOfDay.Text).Trim();

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
            var expenseCash  = _userTransactionService.GetTotalBalance(endOfDay, Constants.EXPENSE, Constants.CASH);
            var transferCash = _userTransactionService.GetTotalBalance(endOfDay, Constants.TRANSFER, Constants.CASH);
            var paymentCheque = _userTransactionService.GetTotalBalance(endOfDay, Constants.PAYMENT, Constants.CHEQUE);
            var expenseCheque = _userTransactionService.GetTotalBalance(endOfDay, Constants.EXPENSE, Constants.CHEQUE);

            RichOpeningBalanceCash.Text = openingBalanceCash.ToString();
            RichOpeningBalanceCredit.Text = openingBalanceCredit.ToString();
            RichSalesCash.Text = salesCash.ToString();
            RichSalesCredit.Text = salesCredit.ToString();
            RichReceiptCash.Text = receiptCash.ToString();
            RichReceiptCheque.Text = receiptCheque.ToString();
            RichPaymentCash.Text = (paymentCash + expenseCash + transferCash).ToString();
            RichPaymentCheque.Text = (paymentCheque + expenseCheque).ToString();

            RichBalanceCash.Text = (openingBalanceCash + salesCash + receiptCash - (paymentCash + expenseCash + transferCash)).ToString();
            RichBalanceCredit.Text = (openingBalanceCredit + salesCredit - (receiptCash + receiptCheque)).ToString();
        }
        #endregion
    }
}
