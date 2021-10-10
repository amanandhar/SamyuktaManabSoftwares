using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
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
        private readonly ISettingService _settingService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly Setting _setting;
        private readonly string _endOfDay;
        private decimal _totalIncome = 0.00m;
        private decimal _totalExpense = 0.00m;

        #region Action
        private enum Action
        {
            Load,
            Show,
            None
        }
        #endregion

        #region Constructor
        public ProfitLossForm(ISettingService settingService, IUserTransactionService userTransactionService)
        {
            InitializeComponent();

            _settingService = settingService;
            _userTransactionService = userTransactionService;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void ProfitLossForm_Load(object sender, EventArgs e)
        {
            MaskDtEOD.Text = _endOfDay;
            EnableFields();
            EnableFields(Action.Load);
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
                TxtNetLoss.Text = 0.00m.ToString();
            }
            else if (_totalIncome < _totalExpense)
            {
                TxtNetIncome.Text = 0.00m.ToString();
                TxtNetLoss.Text = (_totalExpense - _totalIncome).ToString();
            }
            else
            {
                TxtNetIncome.Text = 0.00m.ToString();
                TxtNetLoss.Text = 0.00m.ToString();
            }

            EnableFields();
            EnableFields(Action.Show);
        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            var dialogResult = SaveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var excelData = new Dictionary<string, List<ExcelField>>();

                var incomeFields = new List<ExcelField>();
                var incomes = GetIncome();

                incomeFields.Add(new ExcelField() { Order = 1, Field = Constants.PURCHASE_BONUS, Value = incomes.Where(x => x.Name == Constants.PURCHASE_BONUS).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                incomeFields.Add(new ExcelField() { Order = 2, Field = Constants.DELIVERY_CHARGE, Value = incomes.Where(x => x.Name == Constants.DELIVERY_CHARGE).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                incomeFields.Add(new ExcelField() { Order = 3, Field = Constants.MEMBER_FEE, Value = incomes.Where(x => x.Name == Constants.MEMBER_FEE).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                incomeFields.Add(new ExcelField() { Order = 4, Field = Constants.OTHER_INCOME, Value = incomes.Where(x => x.Name == Constants.OTHER_INCOME).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                incomeFields.Add(new ExcelField() { Order = 5, Field = Constants.SALES_PROFIT, Value = incomes.Where(x => x.Name == Constants.SALES_PROFIT).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                incomeFields.Add(new ExcelField() { Order = 6, Field = Constants.STOCK_ADJUSTMENT, Value = incomes.Where(x => x.Name == Constants.STOCK_ADJUSTMENT).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                incomeFields.Add(new ExcelField() { Order = 7, Field = Constants.TOTAL, Value = incomes.Where(x => x.Name == Constants.TOTAL).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                excelData.Add(Constants.INCOME, incomeFields);

                var expenseFields = new List<ExcelField>();
                var expenses = GetExpense();
                expenseFields.Add(new ExcelField() { Order = 1, Field = Constants.ASSET, Value = expenses.Where(x => x.Name == Constants.ASSET).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 2, Field = Constants.DELIVERY_CHARGE, Value = expenses.Where(x => x.Name == Constants.DELIVERY_CHARGE).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 3, Field = Constants.ELECTRICITY, Value = expenses.Where(x => x.Name == Constants.ELECTRICITY).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 4, Field = Constants.FUEL_TRANSPORTATION, Value = expenses.Where(x => x.Name == Constants.FUEL_TRANSPORTATION).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 5, Field = Constants.GUEST_HOSPITALITY, Value = expenses.Where(x => x.Name == Constants.GUEST_HOSPITALITY).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 6, Field = Constants.LOAN_INTEREST, Value = expenses.Where(x => x.Name == Constants.LOAN_INTEREST).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 7, Field = Constants.MISCELLANEOUS, Value = expenses.Where(x => x.Name == Constants.MISCELLANEOUS).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 8, Field = Constants.OFFICE_RENT, Value = expenses.Where(x => x.Name == Constants.OFFICE_RENT).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 9, Field = Constants.REPAIR_MAINTENANCE, Value = expenses.Where(x => x.Name == Constants.REPAIR_MAINTENANCE).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 10, Field = Constants.SALES_DISCOUNT, Value = expenses.Where(x => x.Name == Constants.SALES_DISCOUNT).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 11, Field = Constants.SALES_RETURN, Value = expenses.Where(x => x.Name == Constants.SALES_RETURN).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 12, Field = Constants.STAFF_ALLOWANCE, Value = expenses.Where(x => x.Name == Constants.STAFF_ALLOWANCE).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 13, Field = Constants.STAFF_SALARY, Value = expenses.Where(x => x.Name == Constants.STAFF_SALARY).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 14, Field = Constants.STOCK_ADJUSTMENT, Value = expenses.Where(x => x.Name == Constants.STOCK_ADJUSTMENT).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 15, Field = Constants.TELEPHONE_INTERNET, Value = expenses.Where(x => x.Name == Constants.TELEPHONE_INTERNET).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                expenseFields.Add(new ExcelField() { Order = 16, Field = Constants.TOTAL, Value = expenses.Where(x => x.Name == Constants.TOTAL).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                excelData.Add(Constants.EXPENSE, expenseFields);

                var title = _endOfDay;
                var sheetname = "Profit And Loss";
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
        private List<IncomeExpenseView> GetIncome()
        {
            List<IncomeExpenseView> incomeExpenseView;
            try
            {
                var endOfDay = UtilityService.GetDate(MaskDtEOD.Text);

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
                var totalStockAdjustment = _userTransactionService
                    .GetIncome(new IncomeTransactionFilter() { DateTo = endOfDay, Income = Constants.STOCK_ADJUSTMENT })
                    .ToList().Sum(x => x.Amount);

                _totalIncome = totalPurchaseBonus + totalDeliveryCharge + totalMemberFee + totalOtherIncome + totalSalesProfit + totalStockAdjustment;

                incomeExpenseView = new List<IncomeExpenseView>
                {
                    new IncomeExpenseView
                    {
                        Name = Constants.PURCHASE_BONUS,
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
                        Name = Constants.STOCK_ADJUSTMENT,
                        Amount = totalStockAdjustment
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.TOTAL,
                        Amount = _totalIncome
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return incomeExpenseView;
        }

        private void LoadIncome()
        {
            try
            {
                var income = GetIncome();
                var bindingList = new BindingList<IncomeExpenseView>(income);
                var source = new BindingSource(bindingList, null);
                DataGridIncomeList.DataSource = source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<IncomeExpenseView> GetExpense()
        {
            List<IncomeExpenseView> incomeExpenseView;
            try
            {
                var endOfDay = UtilityService.GetDate(MaskDtEOD.Text);

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
                var totalStockAdjustment = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.STOCK_ADJUSTMENT });
                var totalTelephoneInternet = _userTransactionService
                    .GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.TELEPHONE_INTERNET });

                _totalExpense = totalAsset + totalDeliveryCharge + totalElectricity + totalFuelAndTransportation + totalGuestHospitality
                     + totalLoanInterest + totalMiscellaneous + totalOfficeRent + totalRepairMaintenance + totalSalesDiscount
                    + totalSalesReturn + totalStaffAllowance + totalStaffSalary + totalStockAdjustment + totalTelephoneInternet;

                incomeExpenseView = new List<IncomeExpenseView>
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
                        Name = Constants.STOCK_ADJUSTMENT,
                        Amount = totalStockAdjustment
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
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return incomeExpenseView;
        }

        private void LoadExpense()
        {
            try
            {
                var expense = GetExpense();
                var bindingList = new BindingList<IncomeExpenseView>(expense);
                var source = new BindingSource(bindingList, null);
                DataGridExpenseList.DataSource = source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Show)
            {
                BtnShow.Enabled = true;
                BtnExportToExcel.Enabled = true;
            }
            else if (action == Action.Load)
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
