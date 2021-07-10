using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class BalanceSheetForm : Form
    {
        private readonly IUserTransactionService _userTransactionService;
        private readonly IIncomeDetailService _incomeDetailService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IItemTransactionService _itemTransactionService;

        #region Constructor
        public BalanceSheetForm(IUserTransactionService userTransactionService, IIncomeDetailService incomeDetailService,
            IBankTransactionService bankTransactionService, IItemTransactionService itemTransactionService)
        {
            InitializeComponent();

            _userTransactionService = userTransactionService;
            _incomeDetailService = incomeDetailService;
            _bankTransactionService = bankTransactionService;
            _itemTransactionService = itemTransactionService;
        }
        #endregion

        #region Form Load
        private void BalanceSheetForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                var totalDeliveryCharge = _incomeDetailService.GetDeliveryCharge().ToList().Sum(x => x.Total);
                var totalMemberFee = _incomeDetailService.GetMemberFee().ToList().Sum(x => x.Total);
                var totalOtherIncome = _incomeDetailService.GetOtherIncome().ToList().Sum(x => x.Total);
                var totalSalesProfit = _incomeDetailService.GetSalesProfit().ToList().Sum(x => x.Total);
                var totalSuppliersCommission = _incomeDetailService.GetSupplilersCommission().ToList().Sum(x => x.Total);
                var totalIncome = totalDeliveryCharge + totalMemberFee + totalOtherIncome + totalSalesProfit + totalSuppliersCommission;

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

                StockFilterView filter = new StockFilterView();

                var shareCapital = 0.0m;
                var ownerEquity = _bankTransactionService.GetBankTotalDeposit();
                var loadAmount = 0.0m;
                var payableAmount = decimal.Negate(_userTransactionService.GetSupplierTotalBalance());
                var netProfit = (totalIncome > totalExpense) ? (totalIncome - totalExpense) : 0.0m;
                var netLoss = (totalExpense > totalIncome) ? (totalExpense - totalIncome) : 0.0m;
                var libilitiesBalance = shareCapital + ownerEquity + loadAmount
                    + payableAmount + netProfit + netLoss;

                var cashInHand = decimal.Negate(_userTransactionService.GetCashInHand());
                var bankAccount = _bankTransactionService.GetBankBalance();
                var fixedAsset = totalAsset;
                var stockValue = _itemTransactionService.GetTotalPurchaseItemAmount(filter) - _itemTransactionService.GetTotalSalesItemAmount(filter);
                var receivableAmount = _userTransactionService.GetMemberTotalBalance();
                var report = 0.0m;
                var assetsBalance = cashInHand + bankAccount + fixedAsset + stockValue + receivableAmount + report;

                RichShareCapital.Text = shareCapital.ToString();
                RichOwnerEquity.Text = ownerEquity.ToString();
                RichLoanAmount.Text = loadAmount.ToString();
                RichPayableAmount.Text = payableAmount.ToString();
                RichNetProfit.Text = netProfit.ToString();
                RichNetLoss.Text = netLoss.ToString();
                RichLiabilitiesBalance.Text = libilitiesBalance.ToString();

                RichCashInHand.Text = cashInHand.ToString();
                RichBankAccount.Text = bankAccount.ToString();
                RichFixedAsset.Text = fixedAsset.ToString();
                RichStockValue.Text = stockValue.ToString();
                RichReceivableAmount.Text = receivableAmount.ToString();
                RichReport.Text = report.ToString();
                RichAssetsBalance.Text = assetsBalance.ToString();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #region Helper Methods
        private void ClearAllFields()
        {
            RichShareCapital.Clear();
            RichOwnerEquity.Clear();
            RichLoanAmount.Clear();
            RichPayableAmount.Clear();
            RichNetProfit.Clear();
            RichNetLoss.Clear();
            RichLiabilitiesBalance.Clear();

            RichCashInHand.Clear();
            RichBankAccount.Clear();
            RichFixedAsset.Clear();
            RichStockValue.Clear();
            RichReceivableAmount.Clear();
            RichReport.Clear();
            RichAssetsBalance.Clear();
        }
        #endregion
    }
}
