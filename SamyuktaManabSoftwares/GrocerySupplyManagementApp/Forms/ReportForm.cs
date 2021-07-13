using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ReportForm : Form
    {
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        private readonly IUserTransactionService _posTransactionService;
        private readonly IBankDetailService _bankDetailService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IIncomeDetailService _incomeDetailService;
        private readonly IIncomeService _incomeService;
        private readonly IItemTransactionService _itemTransactionService;

        #region Constructor
        public ReportForm(IFiscalYearDetailService fiscalYearDetailService, IUserTransactionService posTransactionService,
            IBankDetailService bankDetailService, IBankTransactionService bankTransactionService,
            IIncomeDetailService incomeDetailService, IIncomeService incomeService,
            IItemTransactionService itemTransactionService)
        {
            InitializeComponent();

            _fiscalYearDetailService = fiscalYearDetailService;
            _posTransactionService = posTransactionService;
            _bankDetailService = bankDetailService;
            _bankTransactionService = bankTransactionService;
            _incomeDetailService = incomeDetailService;
            _incomeService = incomeService;
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
            ProfitLossForm profitLossForm = new ProfitLossForm(_incomeDetailService, _posTransactionService);
            profitLossForm.Show();
        }

        private void BtnDailyIncomeReport_Click(object sender, EventArgs e)
        {
            IncomeDetailForm incomeDetailForm = new IncomeDetailForm(_fiscalYearDetailService, _incomeDetailService, 
                _posTransactionService, _bankDetailService,
                _bankTransactionService);
            incomeDetailForm.Show();
        }

        private void BtnBalanceSheetForm_Click(object sender, EventArgs e)
        {
            BalanceSheetForm balanceSheetForm = new BalanceSheetForm(_posTransactionService, _incomeDetailService,
                _bankTransactionService, _itemTransactionService);
            balanceSheetForm.Show();
        }

        private void BtnDailyExpenseReport_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(_fiscalYearDetailService, _posTransactionService,
                _bankDetailService, _bankTransactionService);
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
