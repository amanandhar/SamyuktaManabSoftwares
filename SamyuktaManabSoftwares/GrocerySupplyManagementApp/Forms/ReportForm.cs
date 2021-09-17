using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ReportForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IStockService _stockService;
        private readonly IShareMemberService _shareMemberService;

        #region Constructor
        public ReportForm(IFiscalYearService fiscalYearService,
            IBankService bankService, IBankTransactionService bankTransactionService, 
            IUserTransactionService userTransactionService, IStockService stockService,
            IShareMemberService shareMemberService
            )
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankTransactionService = bankTransactionService;
            _bankService = bankService;
            _userTransactionService = userTransactionService;
            _stockService = stockService;
            _shareMemberService = shareMemberService;
        }
        #endregion

        #region Form Load Event
        private void ReportForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button Click Event

        private void BtnShareCapital_Click(object sender, EventArgs e)
        {
            ShareMemberForm shareMemberForm = new ShareMemberForm(_shareMemberService);
            shareMemberForm.ShowDialog();
        }

        private void BtnProfitLossForm_Click(object sender, EventArgs e)
        {
            ProfitLossForm profitLossForm = new ProfitLossForm(_fiscalYearService, _userTransactionService);
            profitLossForm.Show();
        }

        private void BtnDailyIncomeReport_Click(object sender, EventArgs e)
        {
            IncomeForm incomeDetailForm = new IncomeForm(_fiscalYearService, 
                _bankService, _bankTransactionService, _userTransactionService);
            incomeDetailForm.Show();
        }

        private void BtnBalanceSheetForm_Click(object sender, EventArgs e)
        {
            BalanceSheetForm balanceSheetForm = new BalanceSheetForm(_fiscalYearService, _bankTransactionService,
                _userTransactionService, _stockService);
            balanceSheetForm.Show();
        }

        private void BtnDailyExpenseReport_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(_fiscalYearService,
                _bankService, _bankTransactionService,
                _userTransactionService);
            expenseForm.Show();
        }

        private void BtnSalesReturn_Click(object sender, EventArgs e)
        {
            SalesReturnForm salesReturnForm = new SalesReturnForm();
            salesReturnForm.Show();
        }

        private void BtnStockAdjustment_Click(object sender, EventArgs e)
        {
            StockAdjustmentForm stockAdjustmentForm = new StockAdjustmentForm();
            stockAdjustmentForm.Show();
        }

        #endregion

    }
}
