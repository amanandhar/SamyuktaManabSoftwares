using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class BalanceSheetForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IStockService _stockService;
        private readonly IIncomeExpenseService _incomeExpenseService;
        private readonly ICapitalService _capitalService;

        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region 
        private enum Action
        {
            Load,
            Show,
            None
        }
        #endregion

        #region Constructor
        public BalanceSheetForm(ISettingService settingService, IBankTransactionService bankTransactionService, 
            IStockService stockService, IIncomeExpenseService incomeExpenseService, 
            ICapitalService capitalService)
        {
            InitializeComponent();

            _settingService = settingService;
            _bankTransactionService = bankTransactionService;
            _stockService = stockService;
            _incomeExpenseService = incomeExpenseService;
            _capitalService = capitalService;

            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void BalanceSheetForm_Load(object sender, EventArgs e)
        {
            MaskEndOfDay.Text = _endOfDay;
            EnableFields();
            EnableFields(Action.Load);
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                var endOfDay = UtilityService.GetDate(MaskEndOfDay.Text);
                var totalIncome = _incomeExpenseService.GetTotalIncome(endOfDay);
                var totalExpense = _incomeExpenseService.GetTotalExpense(endOfDay);

                var shareCapital = _bankTransactionService
                    .GetTotalDeposit(new BankTransactionFilter() { DateTo = endOfDay, Action = '1',  Narration = Constants.SHARE_CAPITAL });
                var ownerEquity = _bankTransactionService
                    .GetTotalDeposit(new BankTransactionFilter() { DateTo = endOfDay, Action = '1', Narration = Constants.OWNER_EQUITY });
                var loanAmount = Constants.DEFAULT_DECIMAL_VALUE; // ToDo : Add loan form later
                var payableAmount = Math.Abs(_capitalService
                    .GetSupplierTotalBalance(new SupplierTransactionFilter() { DateTo = endOfDay }));
                var netProfit = (totalIncome > totalExpense) ? (totalIncome - totalExpense) : Constants.DEFAULT_DECIMAL_VALUE;
                var liabilitiesBalance = shareCapital + ownerEquity + loanAmount
                    + payableAmount + netProfit;

                var cashInHand = Math.Abs(_capitalService.GetCashInHand(new UserTransactionFilter { DateTo = endOfDay }));
                var bankAccount = _bankTransactionService.GetTotalBalance(new BankTransactionFilter { DateTo = endOfDay } );

                var stockFilter = new StockFilter() { DateTo = endOfDay };
                var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var stockValue = _stockService.GetStockValue(stocks.ToList(), stockFilter);

                var receivableAmount = _capitalService.GetMemberTotalBalance(new UserTransactionFilter() { DateTo = endOfDay });
                var netLoss = (totalExpense > totalIncome) ? (totalExpense - totalIncome) : Constants.DEFAULT_DECIMAL_VALUE;
                var assetsBalance = cashInHand + bankAccount + stockValue + receivableAmount + netLoss;

                RichShareCapital.Text = shareCapital.ToString();
                RichOwnerEquity.Text = ownerEquity.ToString();
                RichLoanAmount.Text = loanAmount.ToString();
                RichPayableAmount.Text = payableAmount.ToString();
                RichNetProfit.Text = netProfit.ToString();
                RichLiabilitiesBalance.Text = liabilitiesBalance.ToString();

                RichCashInHand.Text = cashInHand.ToString();
                RichBankAccount.Text = bankAccount.ToString();
                RichStockValue.Text = stockValue.ToString("#0.00");
                RichReceivableAmount.Text = receivableAmount.ToString();
                RichNetLoss.Text = netLoss.ToString();
                RichAssetsBalance.Text = assetsBalance.ToString();

                EnableFields();
                EnableFields(Action.Show);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            var dialogResult = SaveFileDialog.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                var excelData = new Dictionary<string, List<ExcelField>>();

                var liabilitiesFields = new List<ExcelField>();
                liabilitiesFields.Add(new ExcelField() { Order = 1, Field = Constants.SHARE_CAPITAL, Value = RichShareCapital.Text, IsColumn = false });
                liabilitiesFields.Add(new ExcelField() { Order = 2, Field = Constants.OWNER_EQUITY, Value = RichOwnerEquity.Text, IsColumn = false });
                liabilitiesFields.Add(new ExcelField() { Order = 3, Field = Constants.LOAN_AMOUNT, Value = RichLoanAmount.Text, IsColumn = false });
                liabilitiesFields.Add(new ExcelField() { Order = 4, Field = Constants.PAYABLE_AMOUNT, Value = RichPayableAmount.Text, IsColumn = false });
                liabilitiesFields.Add(new ExcelField() { Order = 5, Field = Constants.NET_PROFIT, Value = RichNetProfit.Text, IsColumn = false });
                liabilitiesFields.Add(new ExcelField() { Order = 6, Field = Constants.BALANCE, Value = RichLiabilitiesBalance.Text, IsColumn = false });
                excelData.Add(Constants.LIABILITIES, liabilitiesFields);

                var assetsFields = new List<ExcelField>();
                assetsFields.Add(new ExcelField() { Order = 1, Field = Constants.CASH_IN_HAND, Value = RichCashInHand.Text, IsColumn = false });
                assetsFields.Add(new ExcelField() { Order = 2, Field = Constants.BANK_ACCOUNT, Value = RichBankAccount.Text, IsColumn = false });
                assetsFields.Add(new ExcelField() { Order = 3, Field = Constants.STOCK_VALUE, Value = RichStockValue.Text, IsColumn = false });
                assetsFields.Add(new ExcelField() { Order = 4, Field = Constants.RECEIVABLE_AMOUNT, Value = RichReceivableAmount.Text, IsColumn = false });
                assetsFields.Add(new ExcelField() { Order = 5, Field = Constants.NET_LOSS, Value = RichNetLoss.Text, IsColumn = false });
                assetsFields.Add(new ExcelField() { Order = 6, Field = Constants.BALANCE, Value = RichAssetsBalance.Text, IsColumn = false });
                excelData.Add(Constants.ASSETS, assetsFields);

                var title = _endOfDay;
                var sheetname = "Balance Sheet";
                var filename = SaveFileDialog.FileName;

                if (Excel.Export(excelData, title, sheetname, filename))
                {
                    MessageBox.Show(filename + " has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error while saving " + filename, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Helper Methods
        private void EnableFields(Action action = Action.None)
        {
            if(action == Action.Show)
            {
                BtnShow.Enabled = true;
                BtnExportToExcel.Enabled = true;
            }
            else if(action == Action.Load)
            {
                BtnShow.Enabled = true;
            }
            else
            {
                BtnShow.Enabled = false;
                BtnExportToExcel.Enabled = false;
            }
        }
        #endregion
    }
}
