using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ReportForm : Form
    {
        private readonly ISettingService _settingService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IItemService _itemService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IStockService _stockService;
        private readonly IShareMemberService _shareMemberService;

        private readonly string _username;

        #region Constructor
        public ReportForm(string username,
            ISettingService settingService,
            IBankService bankService, IBankTransactionService bankTransactionService, 
            IItemService itemService, IPurchasedItemService purchasedItemService,
            ISoldItemService soldItemService, IUserTransactionService userTransactionService, 
            IStockService stockService, IShareMemberService shareMemberService
            )
        {
            InitializeComponent();

            _settingService = settingService;
            _bankTransactionService = bankTransactionService;
            _bankService = bankService;
            _itemService = itemService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _stockService = stockService;
            _shareMemberService = shareMemberService;

            _username = username;
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
            //ShareMemberForm shareMemberForm = new ShareMemberForm(_fiscalYearService, _bankService,
            //    _bankTransactionService, _shareMemberService,
            //    _userTransactionService, this);
            //shareMemberForm.ShowDialog();
        }

        private void BtnProfitLossForm_Click(object sender, EventArgs e)
        {
            ProfitLossForm profitLossForm = new ProfitLossForm(_settingService, _userTransactionService);
            profitLossForm.Show();
        }

        private void BtnDailyIncomeReport_Click(object sender, EventArgs e)
        {
            IncomeForm incomeDetailForm = new IncomeForm(_username,
                _settingService, _bankService, 
                _bankTransactionService, _userTransactionService);
            incomeDetailForm.Show();
        }

        private void BtnBalanceSheetForm_Click(object sender, EventArgs e)
        {
            BalanceSheetForm balanceSheetForm = new BalanceSheetForm(_settingService, _bankTransactionService,
                _userTransactionService, _stockService);
            balanceSheetForm.Show();
        }

        private void BtnDailyExpenseReport_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(_username,
                _settingService, _bankService, 
                _bankTransactionService, _userTransactionService);
            expenseForm.Show();
        }

        private void BtnSalesReturn_Click(object sender, EventArgs e)
        {
            SalesReturnForm salesReturnForm = new SalesReturnForm(_username,
                _settingService, _itemService, 
                _purchasedItemService, _soldItemService, 
                _userTransactionService);
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
