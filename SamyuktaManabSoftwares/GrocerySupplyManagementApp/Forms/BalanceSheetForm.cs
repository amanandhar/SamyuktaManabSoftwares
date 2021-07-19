﻿using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class BalanceSheetForm : Form
    {
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        
        #region Constructor
        public BalanceSheetForm(IBankTransactionService bankTransactionService, IPurchasedItemService purchasedItemService, ISoldItemService soldItemService,
            IUserTransactionService userTransactionService)
        {
            InitializeComponent();

            _bankTransactionService = bankTransactionService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
        }
        #endregion

        #region Form Load Event
        private void BalanceSheetForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                var totalDeliveryCharge = _userTransactionService.GetDeliveryCharge().ToList().Sum(x => x.Total);
                var totalMemberFee = _userTransactionService.GetMemberFee().ToList().Sum(x => x.Total);
                var totalOtherIncome = _userTransactionService.GetOtherIncome().ToList().Sum(x => x.Total);
                var totalSalesProfit = _userTransactionService.GetSalesProfit().ToList().Sum(x => x.Total);
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

                StockFilterView filter = new StockFilterView();

                var shareCapital = _bankTransactionService.GetTotalDeposit(Constants.SHARE_CAPITAL);
                var ownerEquity = _bankTransactionService.GetTotalDeposit(Constants.OWNER_EQUITY);
                var loadAmount = 0.0m;
                var payableAmount = Math.Abs(_userTransactionService.GetSupplierTotalBalance());
                var netProfit = (totalIncome > totalExpense) ? (totalIncome - totalExpense) : 0.0m;
                var libilitiesBalance = shareCapital + ownerEquity + loadAmount
                    + payableAmount + netProfit;

                var cashInHand = Math.Abs(_userTransactionService.GetCashInHand());
                var bankAccount = _bankTransactionService.GetTotalBalance();
                var stockValue = _purchasedItemService.GetPurchasedItemTotalAmount(filter) - _soldItemService.GetSoldItemTotalAmount(filter);
                var receivableAmount = _userTransactionService.GetMemberTotalBalance();
                var netLoss = (totalExpense > totalIncome) ? (totalExpense - totalIncome) : 0.0m;
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
                RichStockValue.Text = stockValue.ToString();
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
