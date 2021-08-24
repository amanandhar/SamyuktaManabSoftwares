using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class BalanceSheetForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IStockService _stockService;

        private readonly string _endOfDay;

        #region Constructor
        public BalanceSheetForm(IFiscalYearService fiscalYearService, IBankTransactionService bankTransactionService, 
            IUserTransactionService userTransactionService, IStockService stockService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankTransactionService = bankTransactionService;
            _userTransactionService = userTransactionService;
            _stockService = stockService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }
        #endregion

        #region Form Load Event
        private void BalanceSheetForm_Load(object sender, EventArgs e)
        {
            MaskEndOfDay.Text = _endOfDay;
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                StockFilter filter = new StockFilter();
                var dateFrom = MaskEndOfDay.Text;
                var dateTo = MaskEndOfDay.Text;
                if (!string.IsNullOrWhiteSpace(dateFrom.Replace("-", string.Empty).Trim()))
                {
                    filter.DateFrom = dateFrom.Trim();
                }

                if (!string.IsNullOrWhiteSpace(dateFrom.Replace("-", string.Empty).Trim()))
                {
                    filter.DateTo = dateTo.Trim();
                }

                var totalDeliveryCharge = _userTransactionService.GetIncome(new IncomeTransactionFilter() { Income = Constants.DELIVERY_CHARGE}).ToList().Sum(x => x.Amount);
                var totalMemberFee = _userTransactionService.GetIncome(new IncomeTransactionFilter() { Income = Constants.MEMBER_FEE }).ToList().Sum(x => x.Amount);
                var totalOtherIncome = _userTransactionService.GetIncome(new IncomeTransactionFilter() { Income = Constants.OTHER_INCOME }).ToList().Sum(x => x.Amount);
                var totalSalesProfit = _userTransactionService.GetSalesProfit().ToList().Sum(x => x.Amount);
                var totalIncome = totalDeliveryCharge + totalMemberFee + totalOtherIncome + totalSalesProfit;

                var totalAsset = _userTransactionService.GetTotalExpense(Constants.ASSET);
                var totalElectricity = _userTransactionService.GetTotalExpense(Constants.ELECTRICITY);
                var totalFuelAndTransportation = _userTransactionService.GetTotalExpense(Constants.FUEL_TRANSPORTATION);
                var totalGuestHospitality = _userTransactionService.GetTotalExpense(Constants.GUEST_HOSPITALITY);
                var totalLoanFeeInterest = _userTransactionService.GetTotalExpense(Constants.LOAN_FEE_INTEREST);
                var totalMiscellaneous = _userTransactionService.GetTotalExpense(Constants.MISCELLANEOUS);
                var totalOfficeRent = _userTransactionService.GetTotalExpense(Constants.OFFICE_RENT);
                var totalRepairMaintenance = _userTransactionService.GetTotalExpense(Constants.REPAIR_MAINTENANCE);
                var totalSalesDiscount = _userTransactionService.GetTotalExpense(Constants.SALES_DISCOUNT);
                var totalStaffAllowance = _userTransactionService.GetTotalExpense(Constants.STAFF_ALLOWANCE);
                var totalStaffSalary = _userTransactionService.GetTotalExpense(Constants.STAFF_SALARY);
                var totalTelephoneInternet = _userTransactionService.GetTotalExpense(Constants.TELEPHONE_INTERNET);
                var totalExpense = totalAsset + totalElectricity + totalFuelAndTransportation + totalGuestHospitality
                    + totalLoanFeeInterest + totalMiscellaneous + totalOfficeRent + totalRepairMaintenance
                    + totalSalesDiscount + totalStaffAllowance + totalStaffSalary + totalTelephoneInternet;

                var shareCapital = _bankTransactionService.GetTotalDeposit(Constants.SHARE_CAPITAL);
                var ownerEquity = _bankTransactionService.GetTotalDeposit(Constants.OWNER_EQUITY);
                var loadAmount = 0.00m;
                var payableAmount = Math.Abs(_userTransactionService.GetSupplierTotalBalance(string.Empty));
                var netProfit = (totalIncome > totalExpense) ? (totalIncome - totalExpense) : 0.00m;
                var libilitiesBalance = shareCapital + ownerEquity + loadAmount
                    + payableAmount + netProfit;

                var cashInHand = Math.Abs(_userTransactionService.GetCashInHand());
                var bankAccount = _bankTransactionService.GetTotalBalance();

                var stocks = _stockService.GetStocks(filter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
                var stockViewList = UtilityService.CalculateStock(stocks.ToList());
                var latestStockView = stockViewList.GroupBy(x => x.ItemCode)
                    .Select(x => x.OrderByDescending(y => y.AddedDate).FirstOrDefault())
                    .ToList();
                var stockValue = latestStockView.Count > 0 ? Math.Round(latestStockView.Sum(x => x.StockValue), 2) : 0.00m;

                var receivableAmount = _userTransactionService.GetMemberTotalBalance(string.Empty);
                var netLoss = (totalExpense > totalIncome) ? (totalExpense - totalIncome) : 0.00m;
                var assetsBalance = cashInHand + bankAccount + stockValue + receivableAmount + netLoss;

                RichShareCapital.Text = shareCapital.ToString();
                RichOwnerEquity.Text = ownerEquity.ToString();
                RichLoanAmount.Text = loadAmount.ToString();
                RichPayableAmount.Text = payableAmount.ToString();
                RichNetProfit.Text = netProfit.ToString();
                RichNetLoss.Text = netLoss.ToString();
                RichLiabilitiesBalance.Text = libilitiesBalance.ToString();

                RichCashInHand.Text = cashInHand.ToString();
                RichBankAccount.Text = bankAccount.ToString();
                RichStockValue.Text = stockValue.ToString("#.00");
                RichReceivableAmount.Text = receivableAmount.ToString();
                RichAssetsBalance.Text = assetsBalance.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Helper Methods
        private void ClearAllFields()
        {
            RichShareCapital.Clear();
            RichOwnerEquity.Clear();
            RichLoanAmount.Clear();
            RichPayableAmount.Clear();
            RichNetProfit.Clear();
            RichLiabilitiesBalance.Clear();

            RichCashInHand.Clear();
            RichBankAccount.Clear();
            RichStockValue.Clear();
            RichReceivableAmount.Clear();
            RichNetLoss.Clear();
            RichAssetsBalance.Clear();
        }
        #endregion

    }
}
