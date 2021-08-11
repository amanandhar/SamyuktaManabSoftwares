using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly ICompanyInfoService _companyInfoService;
        private readonly ITaxService _taxService;
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

        #region Constructor
        public DashboardForm(IFiscalYearService fiscalYearService, 
            ICompanyInfoService companyInfoService, ITaxService taxService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IItemService itemService, IPricedItemService pricedItemService,
            IMemberService memberService, ISupplierService supplierService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService, 
            IUserTransactionService userTransactionService, IStockService stockService,
            IEndOfDayService endOfDateService, IEmployeeService employeeService, 
            IReportService reportService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _companyInfoService = companyInfoService;
            _taxService = taxService;
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
        }
        #endregion

        #region Form Load Event
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadFiscalYear();
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
                _fiscalYearService, _taxService,
                _bankService, _bankTransactionService,
                _itemService, _pricedItemService,
                _memberService,
                _purchasedItemService, _soldItemService,
                _userTransactionService, _reportService,
                _companyInfoService, _employeeService
                 );
            posForm.Show();
        }

        private void BtnSummaryMgmt_Click(object sender, EventArgs e)
        {
            SummaryForm summaryForm = new SummaryForm(_fiscalYearService, _bankTransactionService,
                _purchasedItemService, _soldItemService, 
                _userTransactionService);
            summaryForm.Show();
        }

        private void BtnMemberMgmt_Click(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm(_fiscalYearService,   
                _bankService, _bankTransactionService, 
                _memberService, _soldItemService,
                _userTransactionService, this);
            memberForm.Show();
        }

        private void BtnSupplierMgmt_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm(_fiscalYearService, _bankService,
                _bankTransactionService, _itemService, 
                _supplierService, _purchasedItemService, 
                _userTransactionService);
            supplierForm.Show();
        }

        private void BtnItemMgmt_Click(object sender, EventArgs e)
        {
            PricedItemForm pricedItemForm = new PricedItemForm(_itemService, _pricedItemService, 
                _purchasedItemService, _soldItemService,
                _stockService, this);
            pricedItemForm.Show();
        }

        private void BtnStockMgmt_Click(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm(_purchasedItemService, _soldItemService,
                _stockService);
            stockForm.Show();
        }

        private void BtnIncomeExpenseMgmt_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseMgmtForm = new ExpenseForm(_fiscalYearService, 
                _bankService, _bankTransactionService,
                _userTransactionService);
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
            SettingForm settingForm = new SettingForm(_fiscalYearService, _companyInfoService,
                _taxService, _itemService,
                _bankTransactionService, _purchasedItemService,
                _soldItemService, _userTransactionService,
                _employeeService);
            settingForm.Show();
        }

        private void BtnReportsMgmt_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm(_fiscalYearService, _bankService, 
                _bankTransactionService, _purchasedItemService,
                _soldItemService, _userTransactionService,
                _stockService
                );
            reportForm.Show();
        }

        private void BtnStaffMgmt_Click(object sender, EventArgs e)
        {
            EmployeeForm staffForm = new EmployeeForm(_employeeService);
            staffForm.Show();
        }

        private void BtnEndOfDayMgmt_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Would you like to update EOD?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var currentFiscalYear = _fiscalYearService.GetFiscalYear();
                    var currentEOD = _endOfDateService.GetEndOfDay(currentFiscalYear.StartingDate);
                    var nextEOD = _endOfDateService.GetNextEndOfDay(currentEOD.Id);

                    var newFiscalYear = new FiscalYear
                    {
                        StartingInvoiceNo = currentFiscalYear.StartingInvoiceNo,
                        StartingBillNo = currentFiscalYear.StartingBillNo,
                        StartingDate = nextEOD.DateInBs,
                        Year = currentFiscalYear.Year,
                        UpdatedDate = DateTime.Now
                    };

                    if(_fiscalYearService.UpdateFiscalYear(newFiscalYear))
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
                throw ex;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadFiscalYear()
        {
            var fiscalYear = _fiscalYearService.GetFiscalYear();
            var eod = _endOfDateService.GetEndOfDay(fiscalYear.StartingDate);

            RichBoxDateInAd.Text = "Date in AD: " + eod.DateInAd.ToString("yyyy-MM-dd");
            RichBoxDateInAd.SelectionAlignment = HorizontalAlignment.Center;
            RichBoxDateInBs.Text = "Date in BS: " + eod.DateInBs;
            RichBoxDateInBs.SelectionAlignment = HorizontalAlignment.Center;

            RichBoxUsername.Text = "User Name: Bhai Raja Manandhar";
            RichBoxUsername.SelectionAlignment = HorizontalAlignment.Center;
            RichBoxFiscalYear.Text = "Fiscal Year: " + fiscalYear.Year;
            RichBoxFiscalYear.SelectionAlignment = HorizontalAlignment.Center;
        }
        #endregion

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
