using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SummaryForm : Form
    {
        private readonly IDailyTransactionService _transactionService;
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        private readonly ISoldItemService _posSoldItemService;
        private readonly IUserTransactionService _posTransactionService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IItemTransactionService _itemTransactionService;

        #region Constructor
        public SummaryForm(IDailyTransactionService transactionService, IFiscalYearDetailService fiscalYearDetailService,
            ISoldItemService posSoldItemService, IUserTransactionService posTransactionService,
            IBankTransactionService bankTransactionService, IItemTransactionService itemTransactionService)
        {
            InitializeComponent();

            _transactionService = transactionService;
            _fiscalYearDetailService = fiscalYearDetailService;
            _posSoldItemService = posSoldItemService;
            _posTransactionService = posTransactionService;
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
            TransactionForm transactionForm = new TransactionForm(_transactionService, _fiscalYearDetailService, 
                _posSoldItemService, _posTransactionService,
                _bankTransactionService, _itemTransactionService);
            transactionForm.Show();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            decimal defaultValue = 0.0m;
            RichOpeningBalanceCash.Text = defaultValue.ToString();
            RichOpeningBalanceCredit.Text = defaultValue.ToString();
            RichSalesCash.Text = _posTransactionService.GetTotalBalance(Constants.SALES, Constants.CASH).ToString();
            RichSalesCredit.Text = _posTransactionService.GetTotalBalance(Constants.SALES, Constants.CREDIT).ToString();
            RichReceiptCash.Text = _posTransactionService.GetTotalBalance(Constants.RECEIPT, Constants.CASH).ToString();
            RichReceiptCheque.Text = _posTransactionService.GetTotalBalance(Constants.RECEIPT, Constants.CHEQUE).ToString();
            RichPaymentCash.Text = (_posTransactionService.GetTotalBalance(Constants.PAYMENT, Constants.CASH) +
                _posTransactionService.GetTotalBalance(Constants.EXPENSE, Constants.CASH) +
                _posTransactionService.GetTotalBalance(Constants.TRANSFER, Constants.CASH)).ToString();
            RichPaymentCheque.Text = (_posTransactionService.GetTotalBalance(Constants.PAYMENT, Constants.CHEQUE) +
                _posTransactionService.GetTotalBalance(Constants.EXPENSE, Constants.CHEQUE)).ToString();
            RichBalanceCash.Text = (Convert.ToDecimal(RichSalesCash.Text) + Convert.ToDecimal(RichReceiptCash.Text) - Convert.ToDecimal(RichPaymentCash.Text)).ToString();
            RichBalanceCredit.Text = (Convert.ToDecimal(RichOpeningBalanceCredit.Text) + Convert.ToDecimal(RichSalesCredit.Text)).ToString();
        }
        #endregion
    }
}
