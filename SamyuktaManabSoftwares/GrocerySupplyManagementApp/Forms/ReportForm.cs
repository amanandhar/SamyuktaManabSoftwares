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
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;

        #region Constructor
        public ReportForm(IFiscalYearService fiscalYearService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService, 
            IUserTransactionService userTransactionService
            )
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankTransactionService = bankTransactionService;
            _bankService = bankService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
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
            ProfitLossForm profitLossForm = new ProfitLossForm(_userTransactionService);
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
            BalanceSheetForm balanceSheetForm = new BalanceSheetForm(_bankTransactionService,
                _purchasedItemService, _soldItemService,
                _userTransactionService);
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
