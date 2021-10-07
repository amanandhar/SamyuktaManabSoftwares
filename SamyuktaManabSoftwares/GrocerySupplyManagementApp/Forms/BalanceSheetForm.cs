using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class BalanceSheetForm : Form
    {
        private readonly ISettingService _settingService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IStockService _stockService;

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
            IUserTransactionService userTransactionService, IStockService stockService)
        {
            InitializeComponent();

            _settingService = settingService;
            _bankTransactionService = bankTransactionService;
            _userTransactionService = userTransactionService;
            _stockService = stockService;

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

                var totalPurchaseBonus = _userTransactionService
                    .GetPurchaseBonus(new IncomeTransactionFilter() { DateTo = endOfDay })
                    .ToList().Sum(x => x.Amount);
                var totalDeliveryCharge = _userTransactionService
                    .GetIncome(new IncomeTransactionFilter() { DateTo = endOfDay, Income = Constants.DELIVERY_CHARGE })
                    .ToList().Sum(x => x.Amount);
                var totalMemberFee = _userTransactionService
                    .GetIncome(new IncomeTransactionFilter() { DateTo = endOfDay, Income = Constants.MEMBER_FEE })
                    .ToList().Sum(x => x.Amount);
                var totalOtherIncome = _userTransactionService
                    .GetIncome(new IncomeTransactionFilter() { DateTo = endOfDay, Income = Constants.OTHER_INCOME })
                    .ToList().Sum(x => x.Amount);
                var totalSalesProfit = _userTransactionService
                    .GetSalesProfit(new IncomeTransactionFilter() { DateTo = endOfDay })
                    .ToList().Sum(x => x.Amount);

                var totalIncome = totalPurchaseBonus + totalDeliveryCharge + totalMemberFee + totalOtherIncome + totalSalesProfit;

                var totalAsset = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.ASSET });
                var totalDeliveryChargeExpense = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.DELIVERY_CHARGE });
                var totalElectricity = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.ELECTRICITY });
                var totalFuelAndTransportation = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.FUEL_TRANSPORTATION });
                var totalGuestHospitality = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.GUEST_HOSPITALITY });
                var totalLoanInterest = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.LOAN_INTEREST });
                var totalMiscellaneous = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.MISCELLANEOUS });
                var totalOfficeRent = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.OFFICE_RENT });
                var totalRepairMaintenance = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.REPAIR_MAINTENANCE });
                var totalSalesDiscount = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.SALES_DISCOUNT });
                var totalSalesReturn = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.SALES_RETURN });
                var totalStaffAllowance = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.STAFF_ALLOWANCE });
                var totalStaffSalary = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.STAFF_SALARY });
                var totalTelephoneInternet = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.TELEPHONE_INTERNET });

                var totalExpense = totalAsset + totalDeliveryChargeExpense + totalElectricity + totalFuelAndTransportation + totalGuestHospitality
                    + totalLoanInterest + totalMiscellaneous + totalOfficeRent + totalRepairMaintenance
                    + totalSalesDiscount + totalSalesReturn + totalStaffAllowance + totalStaffSalary + totalTelephoneInternet;

                var shareCapital = _bankTransactionService
                    .GetTotalDeposit(new BankTransactionFilter() { DateTo = endOfDay, Action = '1',  Narration = Constants.SHARE_CAPITAL });
                var ownerEquity = _bankTransactionService
                    .GetTotalDeposit(new BankTransactionFilter() { DateTo = endOfDay, Action = '1', Narration = Constants.OWNER_EQUITY });
                var loanAmount = 0.00m; // ToDo : Add loan form later
                var payableAmount = Math.Abs(_userTransactionService
                    .GetSupplierTotalBalance(new SupplierTransactionFilter() { DateTo = endOfDay }));
                var netProfit = (totalIncome > totalExpense) ? (totalIncome - totalExpense) : 0.00m;
                var liabilitiesBalance = shareCapital + ownerEquity + loanAmount
                    + payableAmount + netProfit;

                var cashInHand = Math.Abs(_userTransactionService.GetCashInHand(new UserTransactionFilter { DateTo = endOfDay }));
                var bankAccount = _bankTransactionService.GetTotalBalance(new BankTransactionFilter { DateTo = endOfDay } );

                var stockFilter = new StockFilter() { DateTo = endOfDay };
                var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var stockViewList = new List<StockView>();
                if (!string.IsNullOrWhiteSpace(stockFilter.DateFrom) && !string.IsNullOrWhiteSpace(stockFilter.DateTo))
                {
                    stockViewList = UtilityService
                        .CalculateStock(stocks.ToList())
                        .Where(x => x.EndOfDay.CompareTo(stockFilter.DateFrom) >= 0 && x.EndOfDay.CompareTo(stockFilter.DateTo) <= 0)
                        .ToList();
                }
                else if(!string.IsNullOrEmpty(stockFilter.DateFrom) && string.IsNullOrEmpty(stockFilter.DateTo))
                {
                    stockViewList = UtilityService
                        .CalculateStock(stocks.ToList())
                        .Where(x => x.EndOfDay.CompareTo(stockFilter.DateFrom) >= 0)
                        .ToList();
                }
                else if(string.IsNullOrEmpty(stockFilter.DateTo) && !string.IsNullOrEmpty(stockFilter.DateTo))
                {
                    stockViewList = UtilityService
                        .CalculateStock(stocks.ToList())
                        .Where(x => x.EndOfDay.CompareTo(stockFilter.DateTo) <= 0)
                        .ToList();
                }
                else
                {
                    stockViewList = UtilityService.CalculateStock(stocks.ToList());
                }

                var latestStockView = stockViewList.GroupBy(x => x.ItemCode)
                    .Select(x => x.OrderByDescending(y => y.AddedDate).FirstOrDefault())
                    .ToList();
                var stockValue = latestStockView.Count > 0 ? Math.Round(latestStockView.Sum(x => x.StockValue), 2) : 0.00m;

                var receivableAmount = _userTransactionService.GetMemberTotalBalance(new UserTransactionFilter() { DateTo = endOfDay });
                var netLoss = (totalExpense > totalIncome) ? (totalExpense - totalIncome) : 0.00m;
                var assetsBalance = cashInHand + bankAccount + stockValue + receivableAmount + netLoss;

                RichShareCapital.Text = shareCapital.ToString();
                RichOwnerEquity.Text = ownerEquity.ToString();
                RichLoanAmount.Text = loanAmount.ToString();
                RichPayableAmount.Text = payableAmount.ToString();
                RichNetProfit.Text = netProfit.ToString();
                RichLiabilitiesBalance.Text = liabilitiesBalance.ToString();

                RichCashInHand.Text = cashInHand.ToString();
                RichBankAccount.Text = bankAccount.ToString();
                RichStockValue.Text = stockValue.ToString("#.00");
                RichReceivableAmount.Text = receivableAmount.ToString();
                RichNetLoss.Text = netLoss.ToString();
                RichAssetsBalance.Text = assetsBalance.ToString();

                EnableFields();
                EnableFields(Action.Show);
            }
            catch (Exception ex)
            {
                throw ex;
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
                    MessageBox.Show(filename + " has been saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error while saving " + filename, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region 
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
