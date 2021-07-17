using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SummaryForm : Form
    {
        private readonly IDailyTransactionService _transactionService;
        private readonly IFiscalYearService _fiscalYearService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IItemTransactionService _itemTransactionService;

        #region Constructor
        public SummaryForm(IDailyTransactionService transactionService, IFiscalYearService fiscalYearService,
            ISoldItemService soldItemService, IUserTransactionService userTransactionService,
            IBankTransactionService bankTransactionService, IItemTransactionService itemTransactionService)
        {
            InitializeComponent();

            _transactionService = transactionService;
            _fiscalYearService = fiscalYearService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _bankTransactionService = bankTransactionService;
            _itemTransactionService = itemTransactionService;
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
            TransactionForm transactionForm = new TransactionForm(_transactionService, _fiscalYearService, 
                _soldItemService, _userTransactionService,
                _bankTransactionService, _itemTransactionService);
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
            RichBalanceCredit.Text = (Convert.ToDecimal(RichOpeningBalanceCredit.Text) + Convert.ToDecimal(RichSalesCredit.Text)).ToString();
        }
        #endregion
    }
}
