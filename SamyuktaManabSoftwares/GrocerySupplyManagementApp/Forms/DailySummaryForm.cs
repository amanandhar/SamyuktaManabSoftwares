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
    public partial class SummaryForm : Form
    {
        private readonly ISettingService _settingService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IUserService _userService;
        private readonly ICapitalService _capitalService;
        private readonly IAtomicTransactionService _atomicTransactionService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Constructor
        public SummaryForm(string username, ISettingService settingService, IBankTransactionService bankTransactionService,
            IUserTransactionService userTransactionService, IUserService userService,
            ICapitalService capitalService, IAtomicTransactionService atomicTransactionService)
        {
            InitializeComponent();

            _settingService = settingService;
            _bankTransactionService = bankTransactionService;
            _userTransactionService = userTransactionService;
            _userService = userService;
            _capitalService = capitalService;
            _atomicTransactionService = atomicTransactionService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void SummaryForm_Load(object sender, EventArgs e)
        {
            MaskEndOfDay.Text = _endOfDay;
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            string endOfDay = UtilityService.GetDate(MaskEndOfDay.Text);

            var openingCashBalance = _capitalService.GetOpeningCashBalance(endOfDay);
            var openingCreditBalance = _capitalService.GetOpeningCreditBalance(endOfDay);
            var cashSales = _capitalService.GetTotalBalance(endOfDay, Constants.SALES, Constants.CASH);
            var creditSales = _capitalService.GetTotalBalance(endOfDay, Constants.SALES, Constants.CREDIT);
            var cashReceipt = _capitalService.GetTotalBalance(endOfDay, Constants.RECEIPT, Constants.CASH);
            var chequeReceipt = _capitalService.GetTotalBalance(endOfDay, Constants.RECEIPT, Constants.CHEQUE);
            var totalCashPayment = _capitalService.GetTotalCashPayment(endOfDay);
            var totalChequePayment = _capitalService.GetTotalChequePayment(endOfDay);
            var cashBalance = _capitalService.GetCashBalance(endOfDay);
            var creditBalance = _capitalService.GetCreditBalance(endOfDay);

            TxtOpeningCashBalance.Text = openingCashBalance.ToString();
            TxtOpeningCreditBalance.Text = openingCreditBalance.ToString();
            TxtCashSales.Text = cashSales.ToString();
            TxtCreditSales.Text = creditSales.ToString();
            TxtCashReceipt.Text = cashReceipt.ToString();
            TxtChequeReceipt.Text = chequeReceipt.ToString();
            TxtCashPayment.Text = totalCashPayment.ToString();
            TxtChequePayment.Text = totalChequePayment.ToString();
            TxtCashBalance.Text = cashBalance.ToString();
            TxtCreditBalance.Text = creditBalance.ToString();

            var dailySummaryViewList = new List<DailySummaryView>() {
                new DailySummaryView() { Description = "Sales Cash", Debit = Constants.DEFAULT_DECIMAL_VALUE, Credit = cashSales },
                new DailySummaryView() { Description = "Sales Credit", Debit = creditSales, Credit = Constants.DEFAULT_DECIMAL_VALUE },
                new DailySummaryView() { Description = "Receipt Cash", Debit = Constants.DEFAULT_DECIMAL_VALUE, Credit = cashReceipt },
                new DailySummaryView() { Description = "Receipt Cheque", Debit = Constants.DEFAULT_DECIMAL_VALUE, Credit = chequeReceipt },
                new DailySummaryView() { Description = "Payment Cash", Debit = totalCashPayment, Credit = Constants.DEFAULT_DECIMAL_VALUE },
                new DailySummaryView() { Description = "Payment Cheque", Debit = totalChequePayment, Credit = Constants.DEFAULT_DECIMAL_VALUE }
            };

            LoadDailySummary(dailySummaryViewList);
        }
        #endregion

        #region DataGrid Event 
        private void DataGridSummaryList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridSummaryList.Columns["Description"].HeaderText = "Description";
            DataGridSummaryList.Columns["Description"].Width = 300;
            DataGridSummaryList.Columns["Description"].DisplayIndex = 0;

            DataGridSummaryList.Columns["Debit"].HeaderText = "Debit";
            DataGridSummaryList.Columns["Debit"].Width = 140;
            DataGridSummaryList.Columns["Debit"].DisplayIndex = 1;
            DataGridSummaryList.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridSummaryList.Columns["Credit"].HeaderText = "Credit";
            DataGridSummaryList.Columns["Credit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridSummaryList.Columns["Credit"].DisplayIndex = 2;
            DataGridSummaryList.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridSummaryList.Rows)
            {
                DataGridSummaryList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridSummaryList.RowHeadersWidth = 50;
                DataGridSummaryList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods 
        private void LoadDailySummary(List<DailySummaryView> dailySummaryViewList)
        {
            var bindingList = new BindingList<DailySummaryView>(dailySummaryViewList);
            var source = new BindingSource(bindingList, null);
            DataGridSummaryList.DataSource = source;
        }
        #endregion
    }
}
