using GrocerySupplyManagementApp.Services;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ReportForm : Form
    {
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        private readonly IPosTransactionService _posTransactionService;
        private readonly IBankDetailService _bankDetailService;
        private readonly IBankTransactionService _bankTransactionService;

        public ReportForm(IFiscalYearDetailService fiscalYearDetailService, IPosTransactionService posTransactionService,
            IBankDetailService bankDetailService, IBankTransactionService bankTransactionService)
        {
            InitializeComponent();

            _fiscalYearDetailService = fiscalYearDetailService;
            _posTransactionService = posTransactionService;
            _bankDetailService = bankDetailService;
            _bankTransactionService = bankTransactionService;
        }
         
        #region Button Click Event
        private void button5_Click(object sender, EventArgs e)
        {
            BalanceSheetForm balanceSheetForm = new BalanceSheetForm();
            balanceSheetForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProfitLossForm pfofitLossForm = new ProfitLossForm();
            pfofitLossForm.Show();
           
        }

        private void BtnDailyIncomeReport_Click(object sender, EventArgs e)
        {
            IncomeDetailForm incomeDetailForm = new IncomeDetailForm();
            incomeDetailForm.Show();
        }

        private void BtnDailyExpenseReport_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(_fiscalYearDetailService, _posTransactionService,
                _bankDetailService, _bankTransactionService);
            expenseForm.Show();
        }

        #endregion
    }
}
