using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ProfitLossForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;
        private decimal _totalIncome = 0.0m;
        private decimal _totalExpense = 0.0m;

        #region Constructor
        public ProfitLossForm(IFiscalYearService fiscalYearService, IUserTransactionService userTransactionService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _userTransactionService = userTransactionService;
            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }
        #endregion

        #region Form Load Event
        private void ProfitLossForm_Load(object sender, System.EventArgs e)
        {
            MaskEndOfDayFrom.Text = _endOfDay;
            MaskEndOfDayTo.Text = _endOfDay;
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, System.EventArgs e)
        {
            LoadIncome();
            LoadExpense();

            if (_totalIncome > _totalExpense)
            {
                TxtNetIncome.Text = (_totalIncome - _totalExpense).ToString();
                TxtNetLoss.Text = 0.0m.ToString();
            }
            else if (_totalIncome < _totalExpense)
            {
                TxtNetIncome.Text = 0.0m.ToString();
                TxtNetLoss.Text = (_totalExpense - _totalIncome).ToString();
            }
            else 
            {
                TxtNetIncome.Text = 0.0m.ToString();
                TxtNetLoss.Text = 0.0m.ToString();
            }
        }
        #endregion

        #region Data Grid Event
        private void DataGridIncomeList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridIncomeList.Columns["Name"].HeaderText = "Name";
            DataGridIncomeList.Columns["Name"].Width = 300;
            DataGridIncomeList.Columns["Name"].DisplayIndex = 0;

            DataGridIncomeList.Columns["Amount"].HeaderText = "Amount";
            DataGridIncomeList.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridIncomeList.Columns["Amount"].DisplayIndex = 1;

            foreach (DataGridViewRow row in DataGridIncomeList.Rows)
            {
                DataGridIncomeList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridIncomeList.RowHeadersWidth = 50;
                DataGridIncomeList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void DataGridExpenseList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridExpenseList.Columns["Name"].HeaderText = "Name";
            DataGridExpenseList.Columns["Name"].Width = 300;
            DataGridExpenseList.Columns["Name"].DisplayIndex = 0;

            DataGridExpenseList.Columns["Amount"].HeaderText = "Amount";
            DataGridExpenseList.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridExpenseList.Columns["Amount"].DisplayIndex = 1;

            foreach (DataGridViewRow row in DataGridExpenseList.Rows)
            {
                DataGridExpenseList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridExpenseList.RowHeadersWidth = 50;
                DataGridExpenseList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadIncome()
        {
            try
            {
                var dateFrom = MaskEndOfDayFrom.Text;
                var dateTo = MaskEndOfDayTo.Text;

                if (!string.IsNullOrWhiteSpace(dateFrom.Replace("-", string.Empty).Trim()))
                {
                    dateFrom = dateFrom.Trim();
                }

                if (!string.IsNullOrWhiteSpace(dateTo.Replace("-", string.Empty).Trim()))
                {
                    dateTo = dateTo.Trim();
                }

                var totalDeliveryCharge = _userTransactionService.GetIncome(new IncomeTransactionFilter(){ 
                    DateFrom = dateFrom,
                    DateTo = dateTo,
                    Income = Constants.DELIVERY_CHARGE
                }).ToList().Sum(x => x.Amount);
                var totalMemberFee = _userTransactionService.GetIncome(new IncomeTransactionFilter(){
                    DateFrom = dateFrom,
                    DateTo = dateTo,
                    Income = Constants.MEMBER_FEE
                }).ToList().Sum(x => x.Amount);
                var totalOtherIncome = _userTransactionService.GetIncome(new IncomeTransactionFilter(){
                    DateFrom = dateFrom,
                    DateTo = dateTo,
                    Income = Constants.OTHER_INCOME
                }).ToList().Sum(x => x.Amount);
                var totalSalesProfit = _userTransactionService.GetSalesProfit().ToList().Sum(x => x.Amount);
                _totalIncome = totalDeliveryCharge + totalMemberFee + totalOtherIncome + totalSalesProfit;

                List<IncomeExpenseView> incomeExpenseView = new List<IncomeExpenseView>
                {
                    new IncomeExpenseView
                    {
                        Name = Constants.DELIVERY_CHARGE,
                        Amount = totalDeliveryCharge
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.MEMBER_FEE,
                        Amount = totalMemberFee
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.OTHER_INCOME,
                        Amount = totalOtherIncome
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.SALES_PROFIT,
                        Amount = totalSalesProfit
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.TOTAL,
                        Amount = _totalIncome
                    }
                };

                var bindingList = new BindingList<IncomeExpenseView>(incomeExpenseView);
                var source = new BindingSource(bindingList, null);
                DataGridIncomeList.DataSource = source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadExpense()
        {
            try
            {
                var totalAsset = _userTransactionService.GetTotalExpense(Constants.ASSET);
                var totalDeliveryCharge = _userTransactionService.GetTotalExpense(Constants.DELIVERY_CHARGE);
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

                _totalExpense = totalAsset + totalDeliveryCharge + totalElectricity + totalFuelAndTransportation + totalGuestHospitality
                    + totalLoanFeeInterest + totalMiscellaneous + totalOfficeRent + totalRepairMaintenance
                    + totalSalesDiscount + totalStaffAllowance + totalStaffSalary + totalTelephoneInternet;

                List<IncomeExpenseView> incomeExpenseView = new List<IncomeExpenseView>
                {
                    new IncomeExpenseView
                    {
                        Name = Constants.ASSET,
                        Amount = totalAsset
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.DELIVERY_CHARGE,
                        Amount = totalDeliveryCharge
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.ELECTRICITY,
                        Amount = totalElectricity
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.FUEL_TRANSPORTATION,
                        Amount = totalFuelAndTransportation
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.GUEST_HOSPITALITY,
                        Amount = totalGuestHospitality
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.LOAN_FEE_INTEREST,
                        Amount = totalLoanFeeInterest
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.MISCELLANEOUS,
                        Amount = totalMiscellaneous
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.OFFICE_RENT,
                        Amount = totalOfficeRent
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.REPAIR_MAINTENANCE,
                        Amount = totalRepairMaintenance
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.SALES_DISCOUNT,
                        Amount = totalSalesDiscount
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.STAFF_ALLOWANCE,
                        Amount = totalStaffAllowance
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.STAFF_SALARY,
                        Amount = totalStaffSalary
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.TELEPHONE_INTERNET,
                        Amount = totalTelephoneInternet
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.TOTAL,
                        Amount = _totalExpense
                    }
                };

                var bindingList = new BindingList<IncomeExpenseView>(incomeExpenseView);
                var source = new BindingSource(bindingList, null);
                DataGridExpenseList.DataSource = source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void DataGridExpenseList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridIncomeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
