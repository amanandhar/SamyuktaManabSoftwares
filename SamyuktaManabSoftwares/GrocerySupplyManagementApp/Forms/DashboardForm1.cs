using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class DashboardForm1 : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly ICompanyInfoService _companyInfoService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IItemService _itemService;
        private readonly IPricedItemService _pricedItemService;
        private readonly IMemberService _memberService;
        private readonly ISupplierService _supplierService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IStockService _stockService;
        private readonly IEndOfDayService _endOfDateService;
        private readonly IEmployeeService _employeeService;
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        private readonly IItemCategoryService _itemCategoryService;
        private readonly IShareMemberService _shareMemberService;
        private readonly IStockAdjustmentService _stockAdjustmentService;
        private readonly IPOSDetailService _posDetailService;
        private readonly IIncomeExpenseService _incomeExpenseService;
        private readonly ICapitalService _capitalService;

        private readonly string _username;
        private readonly Setting _setting;

        #region Constructor
        public DashboardForm1(string username,
            ISettingService settingService, ICompanyInfoService companyInfoService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IItemService itemService, IPricedItemService pricedItemService,
            IMemberService memberService, ISupplierService supplierService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService, 
            IUserTransactionService userTransactionService, IStockService stockService,
            IEndOfDayService endOfDateService, IEmployeeService employeeService, 
            IReportService reportService, IUserService userService,
            IItemCategoryService itemCategoryService, IShareMemberService shareMemberService,
            IStockAdjustmentService stockAdjustmentService, IPOSDetailService posDetailService,
            IIncomeExpenseService incomeExpenseService, ICapitalService capitalService)
        {
            InitializeComponent();

            _settingService = settingService;
            _companyInfoService = companyInfoService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _itemService = itemService;
            _pricedItemService = pricedItemService;
            _memberService = memberService;
            _supplierService = supplierService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _stockService = stockService;
            _endOfDateService = endOfDateService;
            _employeeService = employeeService;
            _reportService = reportService;
            _userService = userService;
            _itemCategoryService = itemCategoryService;
            _shareMemberService = shareMemberService;
            _stockAdjustmentService = stockAdjustmentService;
            _posDetailService = posDetailService;
            _incomeExpenseService = incomeExpenseService;
            _capitalService = capitalService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
        }
        #endregion

        #region Form Load Event
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadFiscalYear();

            var companyInfo = _companyInfoService.GetCompanyInfo();
            lblCompanyShortName.Text = companyInfo.ShortName;
            lblCompanyName.Text = companyInfo.Name;
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
            PosForm posForm = new PosForm( 
                _username,
                _settingService,
                _bankService, _bankTransactionService,
                _itemService, _pricedItemService,
                _memberService,
                _purchasedItemService, _soldItemService,
                _userTransactionService, _reportService,
                _companyInfoService, _employeeService,
                _stockService, _userService, _posDetailService,
                _stockAdjustmentService, _incomeExpenseService,
                _capitalService
                 );
            posForm.Show();
        }

        private void BtnSummaryMgmt_Click(object sender, EventArgs e)
        {
            SummaryForm summaryForm = new SummaryForm(_username,
                _settingService, _bankTransactionService,
                _purchasedItemService, _soldItemService, 
                _userTransactionService, _userService,
                _stockAdjustmentService, _posDetailService,
                _capitalService);
            summaryForm.Show();
        }

        private void BtnMemberMgmt_Click(object sender, EventArgs e)
        {
            //MemberForm memberForm = new MemberForm(_fiscalYearService,   
            //    _bankService, _bankTransactionService, 
            //    _memberService, _soldItemService,
            //    _userTransactionService, _employeeService,
            //    this);
            //memberForm.Show();
        }

        private void BtnSupplierMgmt_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm(_username,
                _settingService, _bankService,
                _bankTransactionService, _itemService, 
                _supplierService, _purchasedItemService, 
                _userTransactionService, _capitalService);
            supplierForm.Show();
        }

        private void BtnItemMgmt_Click(object sender, EventArgs e)
        {
            //PricedItemForm pricedItemForm = new PricedItemForm(_itemService, _pricedItemService, 
            //    _purchasedItemService, _soldItemService,
            //    _stockService, this);
            //pricedItemForm.Show();
        }

        private void BtnStockMgmt_Click(object sender, EventArgs e)
        {
            StockSummaryForm stockForm = new StockSummaryForm(
                _settingService, _purchasedItemService,
                _soldItemService, _stockService,
                _stockAdjustmentService);
            stockForm.Show();
        }

        private void BtnIncomeExpenseMgmt_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseMgmtForm = new ExpenseForm(_username,
                _settingService,  _bankService, 
                _bankTransactionService, _userTransactionService,
                _incomeExpenseService, _capitalService);
            expenseMgmtForm.Show();
        }

        private void BtnBankingMgmt_Click(object sender, EventArgs e)
        {
            BankForm bankForm = new BankForm(_username,
                _settingService, _bankService, 
                _bankTransactionService);
            bankForm.Show();
        }

        private void BtnEmployeeMgmt_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm(_username, _settingService, _employeeService);
            employeeForm.Show();
        }

        private void BtnEndOfDayMgmt_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Would you like to update EOD?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var currentEOD = _endOfDateService.GetEndOfDay(_setting.StartingDate);
                    var nextEOD = _endOfDateService.GetNextEndOfDay(currentEOD.Id);

                    var setting = new Setting
                    {
                        StartingInvoiceNo = _setting.StartingInvoiceNo,
                        StartingBillNo = _setting.StartingBillNo,
                        StartingDate = nextEOD.DateInBs,
                        FiscalYear = _setting.FiscalYear,
                        Discount = _setting.Discount,
                        Vat = _setting.Vat,
                        DeliveryCharge = _setting.DeliveryCharge,
                        UpdatedBy = _username,
                        UpdatedDate = DateTime.Now
                    };

                    if(_settingService.UpdateSetting(setting.Id, setting).Id == _setting.Id)
                    {
                        LoadFiscalYear();
                        Application.Exit();
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadFiscalYear()
        {
            var eod = _endOfDateService.GetEndOfDay(_setting.StartingDate);

            RichBoxDateInAd.Text = "Date in AD: " + eod.DateInAd.ToString("yyyy-MM-dd");
            RichBoxDateInAd.SelectionAlignment = HorizontalAlignment.Center;
            RichBoxDateInBs.Text = "Date in BS: " + eod.DateInBs;
            RichBoxDateInBs.SelectionAlignment = HorizontalAlignment.Center;

            RichBoxUsername.Text = "User Name: Bhai Raja Manandhar";
            RichBoxUsername.SelectionAlignment = HorizontalAlignment.Center;
            RichBoxFiscalYear.Text = "Fiscal Year: " + _setting.FiscalYear;
            RichBoxFiscalYear.SelectionAlignment = HorizontalAlignment.Center;
        }
        #endregion
    }
}
