using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ReportForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IIncomeDetailService _incomeDetailService;
        private readonly IItemTransactionService _itemTransactionService;

        #region Constructor
        public ReportForm(IFiscalYearService fiscalYearService, IUserTransactionService userTransactionService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IIncomeDetailService incomeDetailService, IItemTransactionService itemTransactionService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _userTransactionService = userTransactionService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _incomeDetailService = incomeDetailService;
            _itemTransactionService = itemTransactionService;
        }
        #endregion

        #region Form Load Event
        private void ReportForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button Click Event

        private void BtnProfitLossForm_Click(object sender, EventArgs e)
        {
            ProfitLossForm profitLossForm = new ProfitLossForm(_incomeDetailService, _userTransactionService);
            profitLossForm.Show();
        }

        private void BtnDailyIncomeReport_Click(object sender, EventArgs e)
        {
            IncomeForm incomeDetailForm = new IncomeForm(_fiscalYearService, _incomeDetailService, 
                _userTransactionService, _bankService,
                _bankTransactionService);
            incomeDetailForm.Show();
        }

        private void BtnBalanceSheetForm_Click(object sender, EventArgs e)
        {
            BalanceSheetForm balanceSheetForm = new BalanceSheetForm(_userTransactionService, _incomeDetailService,
                _bankTransactionService, _itemTransactionService);
            balanceSheetForm.Show();
        }

        private void BtnDailyExpenseReport_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(_fiscalYearService, _userTransactionService,
                _bankService, _bankTransactionService);
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
