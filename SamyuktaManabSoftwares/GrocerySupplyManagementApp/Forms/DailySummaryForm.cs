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
        }
        #endregion

        #region Form Load Event
        private void SummaryForm_Load(object sender, EventArgs e)
        {

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
            decimal defaultValue = 0.0m;
            RichOpeningBalanceCash.Text = defaultValue.ToString();
            RichOpeningBalanceCredit.Text = defaultValue.ToString();
            RichSalesCash.Text = _userTransactionService.GetTotalBalance(Constants.SALES, Constants.CASH).ToString();
            RichSalesCredit.Text = _userTransactionService.GetTotalBalance(Constants.SALES, Constants.CREDIT).ToString();
            RichReceiptCash.Text = _userTransactionService.GetTotalBalance(Constants.RECEIPT, Constants.CASH).ToString();
            RichReceiptCheque.Text = _userTransactionService.GetTotalBalance(Constants.RECEIPT, Constants.CHEQUE).ToString();
            RichPaymentCash.Text = (_userTransactionService.GetTotalBalance(Constants.PAYMENT, Constants.CASH) +
                _userTransactionService.GetTotalBalance(Constants.EXPENSE, Constants.CASH) +
                _userTransactionService.GetTotalBalance(Constants.TRANSFER, Constants.CASH)).ToString();
            RichPaymentCheque.Text = (_userTransactionService.GetTotalBalance(Constants.PAYMENT, Constants.CHEQUE) +
                _userTransactionService.GetTotalBalance(Constants.EXPENSE, Constants.CHEQUE)).ToString();
            RichBalanceCash.Text = (Convert.ToDecimal(RichSalesCash.Text) + Convert.ToDecimal(RichReceiptCash.Text) - Convert.ToDecimal(RichPaymentCash.Text)).ToString();
            RichBalanceCredit.Text = (Convert.ToDecimal(RichOpeningBalanceCredit.Text) + Convert.ToDecimal(RichSalesCredit.Text)
                - (Convert.ToDecimal(RichReceiptCash.Text) + Convert.ToDecimal(RichReceiptCheque.Text))).ToString();
        }
        #endregion
    }
}
