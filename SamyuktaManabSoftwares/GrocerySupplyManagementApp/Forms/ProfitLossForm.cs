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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IIncomeExpenseService _incomeExpenseService;

        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Action
        private enum Action
        {
            Load,
            Show,
            None
        }
        #endregion

        #region Constructor
        public ProfitLossForm(ISettingService settingService,
            IIncomeExpenseService incomeExpenseService)
        {
            InitializeComponent();

            _settingService = settingService;
            _incomeExpenseService = incomeExpenseService;

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

            var totalIncome = _incomeExpenseService.GetTotalIncome(_endOfDay);
            var totalExpense = _incomeExpenseService.GetTotalExpense(_endOfDay);
            if (totalIncome > totalExpense)
            {
                TxtNetIncome.Text = (totalIncome - totalExpense).ToString();
                TxtNetLoss.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
            }
            else if (totalIncome < totalExpense)
            {
                TxtNetIncome.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
                TxtNetLoss.Text = (totalExpense - totalIncome).ToString();
            }
            else
            {
                TxtNetIncome.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
                TxtNetLoss.Text = Constants.DEFAULT_DECIMAL_VALUE.ToString();
            }

            EnableFields();
            EnableFields(Action.Show);
        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = SaveFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var excelData = new Dictionary<string, List<MSExcelField>>();

                    var incomeFields = new List<MSExcelField>();
                    var incomes = GetIncome();
                    incomeFields.Add(new MSExcelField() { Order = 1, Field = Constants.BANK_INTEREST, Value = incomes.Where(x => x.Name == Constants.BANK_INTEREST).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    incomeFields.Add(new MSExcelField() { Order = 2, Field = Constants.DELIVERY_CHARGE, Value = incomes.Where(x => x.Name == Constants.DELIVERY_CHARGE).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    incomeFields.Add(new MSExcelField() { Order = 3, Field = Constants.OTHER_INCOME, Value = incomes.Where(x => x.Name == Constants.OTHER_INCOME).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    incomeFields.Add(new MSExcelField() { Order = 4, Field = Constants.SALES_PROFIT, Value = incomes.Where(x => x.Name == Constants.SALES_PROFIT).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    incomeFields.Add(new MSExcelField() { Order = 5, Field = Constants.STOCK_ADJUSTMENT, Value = incomes.Where(x => x.Name == Constants.STOCK_ADJUSTMENT).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    incomeFields.Add(new MSExcelField() { Order = 6, Field = Constants.TOTAL, Value = incomes.Where(x => x.Name == Constants.TOTAL).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    excelData.Add(Constants.INCOME, incomeFields);

                    var expenseFields = new List<MSExcelField>();
                    var expenses = GetExpense();
                    expenseFields.Add(new MSExcelField() { Order = 1, Field = Constants.ASSET, Value = expenses.Where(x => x.Name == Constants.ASSET).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 1, Field = Constants.COMMISSION, Value = expenses.Where(x => x.Name == Constants.COMMISSION).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 2, Field = Constants.DELIVERY_CHARGE, Value = expenses.Where(x => x.Name == Constants.DELIVERY_CHARGE).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 3, Field = Constants.ELECTRICITY, Value = expenses.Where(x => x.Name == Constants.ELECTRICITY).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 4, Field = Constants.FUEL_TRANSPORTATION, Value = expenses.Where(x => x.Name == Constants.FUEL_TRANSPORTATION).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 5, Field = Constants.GUEST_HOSPITALITY, Value = expenses.Where(x => x.Name == Constants.GUEST_HOSPITALITY).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 6, Field = Constants.LOAN_INTEREST, Value = expenses.Where(x => x.Name == Constants.LOAN_INTEREST).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 7, Field = Constants.MISCELLANEOUS, Value = expenses.Where(x => x.Name == Constants.MISCELLANEOUS).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 8, Field = Constants.OFFICE_RENT, Value = expenses.Where(x => x.Name == Constants.OFFICE_RENT).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 9, Field = Constants.REPAIR_MAINTENANCE, Value = expenses.Where(x => x.Name == Constants.REPAIR_MAINTENANCE).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 10, Field = Constants.SALES_DISCOUNT, Value = expenses.Where(x => x.Name == Constants.SALES_DISCOUNT).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 11, Field = Constants.SALES_RETURN, Value = expenses.Where(x => x.Name == Constants.SALES_RETURN).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 12, Field = Constants.STAFF_ALLOWANCE, Value = expenses.Where(x => x.Name == Constants.STAFF_ALLOWANCE).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 13, Field = Constants.STAFF_SALARY, Value = expenses.Where(x => x.Name == Constants.STAFF_SALARY).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 14, Field = Constants.STOCK_ADJUSTMENT, Value = expenses.Where(x => x.Name == Constants.STOCK_ADJUSTMENT).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 15, Field = Constants.TELEPHONE_INTERNET, Value = expenses.Where(x => x.Name == Constants.TELEPHONE_INTERNET).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    expenseFields.Add(new MSExcelField() { Order = 16, Field = Constants.TOTAL, Value = expenses.Where(x => x.Name == Constants.TOTAL).Select(x => x.Amount).FirstOrDefault().ToString(), IsColumn = false });
                    excelData.Add(Constants.EXPENSE, expenseFields);

                    var title = _endOfDay;
                    var sheetname = "Profit And Loss";
                    var filename = SaveFileDialog.FileName;

                    if (MSExcel.Export(excelData, title, sheetname, filename))
                    {
                        MessageBox.Show(filename + " has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error while saving " + filename, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
        }
        #endregion

        #region Helper Methods
        private List<IncomeExpenseView> GetIncome()
        {
            List<IncomeExpenseView> incomeExpenseView = null;
            try
            {
                var endOfDay = UtilityService.GetDate(MaskDtEOD.Text);
                var salesProfitAmount = _incomeExpenseService.GetSalesProfit(new IncomeTransactionFilter() { DateTo = endOfDay }).ToList().Sum(x => x.Amount);
                incomeExpenseView = new List<IncomeExpenseView>
                {
                    new IncomeExpenseView
                    {
                        Name = Constants.BANK_INTEREST,
                        Amount = _incomeExpenseService.GetTotalIncome(new IncomeTransactionFilter() { DateTo = endOfDay, IncomeType = Constants.BANK_INTEREST })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.DELIVERY_CHARGE,
                        Amount = _incomeExpenseService.GetTotalDeliveryCharge(new IncomeTransactionFilter() { DateTo = endOfDay})
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.OTHER_INCOME,
                        Amount = _incomeExpenseService.GetTotalIncome(new IncomeTransactionFilter() { DateTo = endOfDay, IncomeType = Constants.OTHER_INCOME })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.SALES_PROFIT,
                        Amount = salesProfitAmount == 0 ? Constants.DEFAULT_DECIMAL_VALUE : salesProfitAmount
                    },
                     new IncomeExpenseView
                    {
                        Name = Constants.STOCK_ADJUSTMENT,
                        Amount = _incomeExpenseService.GetTotalIncome(new IncomeTransactionFilter() { DateTo = endOfDay, IncomeType = Constants.STOCK_ADJUSTMENT })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.TOTAL,
                        Amount = _incomeExpenseService.GetTotalIncome(endOfDay)
                    }
                };
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private List<IncomeExpenseView> GetExpense()
        {
            List<IncomeExpenseView> incomeExpenseView = null;
            try
            {
                var endOfDay = UtilityService.GetDate(MaskDtEOD.Text.Trim());
                incomeExpenseView = new List<IncomeExpenseView>
                {
                    new IncomeExpenseView
                    {
                        Name = Constants.ASSET,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.ASSET })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.COMMISSION,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.COMMISSION })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.DELIVERY_CHARGE,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.DELIVERY_CHARGE })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.ELECTRICITY,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.ELECTRICITY })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.FUEL_TRANSPORTATION,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.FUEL_TRANSPORTATION })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.GUEST_HOSPITALITY,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.GUEST_HOSPITALITY })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.LOAN_INTEREST,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.LOAN_INTEREST })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.MISCELLANEOUS,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.MISCELLANEOUS })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.OFFICE_RENT,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.OFFICE_RENT })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.REPAIR_MAINTENANCE,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.REPAIR_MAINTENANCE })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.SALES_DISCOUNT,
                        Amount = _incomeExpenseService.GetTotalSalesDiscount(new ExpenseTransactionFilter() { DateTo = endOfDay })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.SALES_RETURN,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.SALES_RETURN })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.STAFF_ALLOWANCE,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.STAFF_ALLOWANCE })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.STAFF_SALARY,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.STAFF_SALARY })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.STOCK_ADJUSTMENT,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.STOCK_ADJUSTMENT })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.TELEPHONE_INTERNET,
                        Amount = _incomeExpenseService.GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.TELEPHONE_INTERNET })
                    },
                    new IncomeExpenseView
                    {
                        Name = Constants.TOTAL,
                        Amount = _incomeExpenseService.GetTotalExpense(endOfDay)
                    }
                };
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
