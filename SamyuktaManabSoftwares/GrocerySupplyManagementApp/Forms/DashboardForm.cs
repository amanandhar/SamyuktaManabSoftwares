﻿using GrocerySupplyManagementApp.Services;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly IMemberService _memberService;
        private readonly ISupplierService _supplierService;
        private readonly IItemService _itemService;
        private readonly IItemTransactionService _itemTransactionService;
        private readonly ISupplierTransactionService _supplierTransactionService;
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        private readonly ITaxDetailService _taxDetailService;

        public DashboardForm(IMemberService memberService, ISupplierService supplierService, IItemService itemService,
            IItemTransactionService itemTransactionService, ISupplierTransactionService supplierTransactionService, 
            IFiscalYearDetailService fiscalYearDetailService, ITaxDetailService taxDetailService)
        {
            InitializeComponent();

            _memberService = memberService;
            _supplierService = supplierService;
            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            _supplierTransactionService = supplierTransactionService;
            _fiscalYearDetailService = fiscalYearDetailService;
            _taxDetailService = taxDetailService;
        }

        #region Load
        private void DashboardForm_Load(object sender, EventArgs e)
        {

            RichBoxDateInAd.Text = "Date in AD: " + DateTime.Today.ToString("MM/dd/yyyy");
            RichBoxDateInAd.SelectionAlignment = HorizontalAlignment.Center;
            RichBoxDateInBs.Text = "Date in BS: " + DateTime.Today.ToString("MM/dd/yyyy");
            RichBoxDateInBs.SelectionAlignment = HorizontalAlignment.Center;

            RichBoxUsername.Text = "User Name: Bhai Raja Manandhar";
            RichBoxUsername.SelectionAlignment = HorizontalAlignment.Center;
            RichBoxFiscalYear.Text = "Fiscal Year: " + _fiscalYearDetailService.GetFiscalYearDetail().FiscalYear;
            RichBoxFiscalYear.SelectionAlignment = HorizontalAlignment.Center;
        }
        #endregion

        #region Timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            RichBoxTime.Text = "Time: " + DateTime.Now.ToString("hh:mm:ss");
            RichBoxTime.SelectionAlignment = HorizontalAlignment.Center;
        }
        #endregion

        #region Menu Buttons
        private void BtnPosMgmt_Click(object sender, EventArgs e)
        {
            PosForm posForm = new PosForm(_memberService, _itemService, _itemTransactionService, _fiscalYearDetailService, _taxDetailService);
            posForm.Show();
        }

        private void BtnTransactionMgmt_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm();
            transactionForm.Show();
        }

        private void BtnMemberMgmt_Click(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm(_memberService, this);
            memberForm.Show();
        }

        private void BtnSupplierMgmt_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm(_supplierService, _itemService, _itemTransactionService, _supplierTransactionService);
            supplierForm.Show();
        }

        private void BtnItemMgmt_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm(_itemService, _itemTransactionService, this);
            itemForm.Show();
        }

        private void BtnStockMgmt_Click(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm(_itemService, _itemTransactionService);
            stockForm.Show();
        }

        private void BtnSettingMgmt_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(_fiscalYearDetailService, _taxDetailService);
            settingForm.Show();
        }

        private void BtnReportsMgmt_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
        }

        private void BtnStaffMgmt_Click(object sender, EventArgs e)
        {
            StaffForm staffForm = new StaffForm();
            staffForm.Show();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            BankForm bankForm = new BankForm();
            bankForm.Show();
        }

        private void btnExpenseMgmt_Click(object sender, EventArgs e)
        {
            ExpenseMgmtForm expenseMgmtForm = new ExpenseMgmtForm();
            expenseMgmtForm.Show();
        }
    }
}
