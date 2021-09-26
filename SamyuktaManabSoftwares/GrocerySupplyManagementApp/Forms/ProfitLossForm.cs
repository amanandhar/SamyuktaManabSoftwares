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
        private void ProfitLossForm_Load(object sender, EventArgs e)
        {
            MaskDtEOD.Text = _endOfDay;
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
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
            DataGridIncomeList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
            DataGridExpenseList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                var endOfDay = MaskDtEOD.Text;

                if (!string.IsNullOrWhiteSpace(endOfDay.Replace("-", string.Empty).Trim()))
                {
                    endOfDay = endOfDay.Trim();
                }

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
                    .GetIncome(new IncomeTransactionFilter() { DateTo = endOfDay, Income = Constants.OTHER_INCOME})
                    .ToList().Sum(x => x.Amount);
                var totalSalesProfit = _userTransactionService
                    .GetSalesProfit(new IncomeTransactionFilter() { DateTo = endOfDay })
                    .ToList().Sum(x => x.Amount);
                
                _totalIncome = totalPurchaseBonus + totalDeliveryCharge + totalMemberFee + totalOtherIncome + totalSalesProfit;

                List<IncomeExpenseView> incomeExpenseView = new List<IncomeExpenseView>
                {
                    new IncomeExpenseView
                    {
                        Name = Constants.BONUS,
                        Amount = totalPurchaseBonus
                    },
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
                var endOfDay = MaskDtEOD.Text;

                if (!string.IsNullOrWhiteSpace(endOfDay.Replace("-", string.Empty).Trim()))
                {
                    endOfDay = endOfDay.Trim();
                }

                var totalAsset = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.ASSET });
                var totalDeliveryCharge = _userTransactionService
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

                _totalExpense = totalAsset + totalDeliveryCharge + totalElectricity + totalFuelAndTransportation + totalGuestHospitality
                     + totalLoanInterest + totalMiscellaneous + totalOfficeRent + totalRepairMaintenance + totalSalesDiscount
                    + totalSalesReturn + totalStaffAllowance + totalStaffSalary + totalTelephoneInternet;

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
                        Name = Constants.LOAN_INTEREST,
                        Amount = totalLoanInterest
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
                        Name = Constants.SALES_RETURN,
                        Amount = totalSalesReturn
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
    }
}
