using GrocerySupplyManagementApp.Services.Interfaces;
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
        private readonly IFiscalYearService _fiscalYearService;
        private readonly ITaxService _taxService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly ISoldItemService _soldItemService;
        private readonly IDailyTransactionService _transactionService;
        private readonly ICodedItemService _codedItemService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IIncomeDetailService _incomeDetailService;

        #region Constructor
        public DashboardForm(IMemberService memberService, ISupplierService supplierService, 
            IItemService itemService, IItemTransactionService itemTransactionService, 
            IFiscalYearService fiscalYearService, ITaxService taxService,
            IUserTransactionService userTransactionService, ISoldItemService soldItemService, 
            IDailyTransactionService transactionService, ICodedItemService codedItemService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IIncomeDetailService incomeDetailService)
        {
            InitializeComponent();

            _memberService = memberService;
            _supplierService = supplierService;
            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            _fiscalYearService = fiscalYearService;
            _taxService = taxService;
            _userTransactionService = userTransactionService;
            _soldItemService = soldItemService;
            _transactionService = transactionService;
            _codedItemService = codedItemService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _incomeDetailService = incomeDetailService;
        }
        #endregion

        #region Form Load Event
        private void DashboardForm_Load(object sender, EventArgs e)
        {

            RichBoxDateInAd.Text = "Date in AD: " + DateTime.Today.ToString("MM/dd/yyyy");
            RichBoxDateInAd.SelectionAlignment = HorizontalAlignment.Center;
            RichBoxDateInBs.Text = "Date in BS: " + DateTime.Today.ToString("MM/dd/yyyy");
            RichBoxDateInBs.SelectionAlignment = HorizontalAlignment.Center;

            RichBoxUsername.Text = "User Name: Bhai Raja Manandhar";
            RichBoxUsername.SelectionAlignment = HorizontalAlignment.Center;
            RichBoxFiscalYear.Text = "Fiscal Year: " + _fiscalYearService.GetFiscalYear().Year;
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

        #region Menu Button
        private void BtnPosMgmt_Click(object sender, EventArgs e)
        {
            PosForm posForm = new PosForm(_memberService, _itemService, 
                _fiscalYearService, _taxService, 
                _userTransactionService, _soldItemService, 
                _transactionService, _codedItemService, 
                _bankService, _bankTransactionService,
                _itemTransactionService);
            posForm.Show();
        }

        private void BtnSummaryMgmt_Click(object sender, EventArgs e)
        {
            SummaryForm summaryForm = new SummaryForm(_transactionService, _fiscalYearService, 
                _soldItemService, _userTransactionService,
                _bankTransactionService, _itemTransactionService);
            summaryForm.Show();
        }

        private void BtnMemberMgmt_Click(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm(_memberService, _userTransactionService, 
                _soldItemService, _bankService, 
                _bankTransactionService, _fiscalYearService, this);
            memberForm.Show();
        }

        private void BtnSupplierMgmt_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm(_supplierService, _itemService, 
                _itemTransactionService, _bankService, 
                _bankTransactionService, _userTransactionService, 
                _fiscalYearService);
            supplierForm.Show();
        }

        private void BtnItemMgmt_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm(_itemService, _itemTransactionService, 
                _codedItemService, this);
            itemForm.Show();
        }

        private void BtnStockMgmt_Click(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm(_itemTransactionService);
            stockForm.Show();
        }

        private void BtnIncomeExpenseMgmt_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseMgmtForm = new ExpenseForm(_fiscalYearService, _userTransactionService, 
                _bankService, _bankTransactionService);
            expenseMgmtForm.Show();
        }

        private void BtnBankingMgmt_Click(object sender, EventArgs e)
        {
            BankForm bankForm = new BankForm(_fiscalYearService, _bankService, 
                _bankTransactionService);
            bankForm.Show();
        }

        private void BtnSettingMgmt_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(_fiscalYearService, _taxService, _itemService);
            settingForm.Show();
        }

        private void BtnReportsMgmt_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm(_fiscalYearService, _userTransactionService, 
                _bankService, _bankTransactionService,
                _incomeDetailService, _itemTransactionService);
            reportForm.Show();
        }

        private void BtnStaffMgmt_Click(object sender, EventArgs e)
        {
            EmployeeForm staffForm = new EmployeeForm();
            staffForm.Show();
        }
        #endregion
    }
}
