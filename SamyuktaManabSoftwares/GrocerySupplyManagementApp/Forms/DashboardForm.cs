using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class DashboardForm : Form
    {
        #region Design
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            const int WM_NCPAINT = 0x85;
            if (m.Msg == WM_NCPAINT)
            {
                IntPtr hdc = GetWindowDC(m.HWnd);
                if ((int)hdc != 0)
                {
                    Graphics g = Graphics.FromHdc(hdc);
                    g.FillRectangle(Brushes.Green, new Rectangle(0, 0, 4800, 23));
                    g.Flush();
                    ReleaseDC(m.HWnd, hdc);
                }
            }
        }

        private Form activeForm = null;
        private Button activeButton = null;
        private bool isActiveButtonSubMenu = false;

        private void CustomizeDesign()
        {
            PanelReportsSubMenu.Visible = false;
            PanelSettingsSubMenu.Visible = false;
        }

        private void HideSubMenu()
        {
            if (PanelReportsSubMenu.Visible == true)
            {
                PanelReportsSubMenu.Visible = false;
            }

            if (PanelSettingsSubMenu.Visible == true)
            {
                PanelSettingsSubMenu.Visible = false;
            }
        }

        private void ShowSubMenu(Panel panel)
        {
            if (panel.Visible == false)
            {
                HideSubMenu();
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close(); ;
            }

            if(childForm != null)
            {
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                PanelBody.Controls.Add(childForm);
                PanelBody.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
        }

        private void SelectButton(Button button, bool isSubMenu = false)
        {
            if(activeButton != null)
            {
                activeButton.BackColor = isActiveButtonSubMenu ? Color.CornflowerBlue : Color.DodgerBlue;
            }

            activeButton = button;
            isActiveButtonSubMenu = isSubMenu; 
            activeButton.BackColor = Color.Silver;
        }
        #endregion

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
        public DashboardForm(string username, ISettingService settingService,
            ICompanyInfoService companyInfoService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IItemService itemService, IPricedItemService pricedItemService,
            IMemberService memberService, ISupplierService supplierService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService,
            IUserTransactionService userTransactionService, IStockService stockService,
            IEndOfDayService endOfDateService, IEmployeeService employeeService,
            IReportService reportService, IUserService userService,
            IItemCategoryService itemCategoryService, IShareMemberService shareMemberService,
            IStockAdjustmentService stockAdjustmentService, IPOSDetailService posDetailService,
            IIncomeExpenseService incomeExpenseService, ICapitalService capitalService
            )
        {
            InitializeComponent();
            CustomizeDesign();

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
            GetUserPermissions();

            var companyInfo = _companyInfoService.GetCompanyInfo();
            LblCompanyShortName.Text = companyInfo.ShortName;
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

        #region Button Click Events

        private void BtnPointOfSales_Click(object sender, EventArgs e)
        {
            PosForm posForm = new PosForm(_username,
                _settingService,
                _bankService, _bankTransactionService,
                _itemService, _pricedItemService,
                _memberService,
                _purchasedItemService, _soldItemService,
                _userTransactionService, _reportService,
                _companyInfoService, _employeeService,
                _stockService, _userService,
                _posDetailService, _stockAdjustmentService,
                _incomeExpenseService, _capitalService
                 );
            posForm.ShowDialog();

            //OpenChildForm(new PosForm(
            //    _userService,
            //    _bankService, _bankTransactionService,
            //    _itemService, _pricedItemService,
            //    _memberService,
            //    _purchasedItemService, _soldItemService,
            //    _userTransactionService, _reportService,
            //    _companyInfoService, _employeeService,
            //    _stockService
            //     ));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnDailySummary_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SummaryForm(_username,
                _settingService, _bankTransactionService,
                _purchasedItemService, _soldItemService,
                _userTransactionService, _userService,
                _stockAdjustmentService, _posDetailService,
                _capitalService));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnDailyTransaction_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DailyTransactionForm(_username,
                _settingService,
               _bankTransactionService,
               _purchasedItemService, _soldItemService,
               _userTransactionService, _userService,
               _stockAdjustmentService, _posDetailService
               ));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnStockSummary_Click(object sender, EventArgs e)
        {
           OpenChildForm(new StockSummaryForm(_username, 
               _settingService, _itemService, 
               _pricedItemService, _purchasedItemService,
                _soldItemService, _stockService,
                _userTransactionService, _stockAdjustmentService));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnMember_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MemberForm(_username,
                _settingService, _companyInfoService,
                _bankService, _bankTransactionService,
                _memberService, _soldItemService,
                _userTransactionService, _employeeService,
                _reportService, _posDetailService, _capitalService, this));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnSupplier_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SupplierForm(_username,
                _settingService, _bankService,
                _bankTransactionService, _itemService,
                _supplierService, _purchasedItemService,
                _userTransactionService, _capitalService));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnItemPricing_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PricedItemForm(_username, _itemService, _pricedItemService,
                _purchasedItemService, _soldItemService,
                _stockService, this));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnBank_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BankForm(_username,
                _settingService, _bankService,
                _bankTransactionService));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeForm(_username, _employeeService));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            SelectButton(sender as Button);
            ShowSubMenu(PanelReportsSubMenu);
        }

        private void BtnBalanceSheet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BalanceSheetForm(_settingService, _bankTransactionService,
               _stockService, _incomeExpenseService, 
               _capitalService));
            SelectButton(sender as Button, true);
        }

        private void BtnDailyIncome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new IncomeForm(_username,
                _settingService, _bankService, 
                _bankTransactionService, _userTransactionService,
                _incomeExpenseService));
            SelectButton(sender as Button, true);
        }

        private void BtnDailyExpense_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ExpenseForm(_username,
                _settingService, _bankService, 
                _bankTransactionService, _userTransactionService,
                _incomeExpenseService, _capitalService));
            SelectButton(sender as Button, true);
        }

        private void BtnProfitLoss_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProfitLossForm(_settingService,
                _incomeExpenseService));
            SelectButton(sender as Button, true);
        }

        private void BtnSalesPurchaseReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SalesPurchaseForm(_settingService, _userTransactionService));
            SelectButton(sender as Button, true);
        }

        private void BtnSalesReturn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SalesReturnForm(_username,
                _settingService, _itemService, 
                _purchasedItemService, _soldItemService,
                _userTransactionService));
            SelectButton(sender as Button, true);
        }

        private void BtnShareCapital_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ShareMemberForm(_username,
                _settingService, _bankService, 
                _bankTransactionService, _shareMemberService, 
                _userTransactionService, this));
            SelectButton(sender as Button, true);
        }

        private void BtnDeliveryPerson_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DeliveryPersonForm(_settingService, _userTransactionService,
                    _employeeService));
            SelectButton(sender as Button, true);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SelectButton(sender as Button);
            ShowSubMenu(PanelSettingsSubMenu);
        }

        private void BtnCompanyInformation_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CompanyInfoForm(_username, _companyInfoService));
            SelectButton(sender as Button, true);
        }

        private void BtnNewCodeSetup_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ItemForm(_username, _itemService, _itemCategoryService));
            SelectButton(sender as Button, true);
        }

        private void BtnSetup_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SetupForm(_username, _settingService));
            SelectButton(sender as Button, true);
        }

        private void BtnUserSetup_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserForm(_username, _userService));
            SelectButton(sender as Button, true);
        }

        private void BtnEOD_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Would you like to update EOD?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var currentEOD = _endOfDateService.GetEndOfDay(_setting.StartingDate);
                    var nextEOD = _endOfDateService.GetNextEndOfDay(currentEOD.Id);

                    var setting = new Setting
                    {
                        Id = _setting.Id,
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

                    if (_settingService.UpdateSetting(setting.Id, setting).Id == setting.Id)
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

        #region Label Click Event
        private void LblCompanyShortName_Click(object sender, EventArgs e)
        {
            OpenChildForm(null);
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

            RichBoxUsername.Text = "Username: " + _username;
            RichBoxUsername.SelectionAlignment = HorizontalAlignment.Center;
            RichBoxFiscalYear.Text = "Fiscal Year: " + _setting.FiscalYear;
            RichBoxFiscalYear.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void GetUserPermissions()
        {
            var user = _userService.GetUser(_username);
            if (user.POS)
            {
                BtnPointOfSales.Visible = true;
            }
            else
            {
                BtnPointOfSales.Visible = false;
            }

            if (user.DailySummary)
            {
                BtnDailySummary.Visible = true;
            }
            else
            {
                BtnDailySummary.Visible = false;
            }

            if (user.DailyTransaction)
            {
                BtnDailyTransaction.Visible = true;
            }
            else
            {
                BtnDailyTransaction.Visible = false;
            }

            if (user.StockSummary)
            {
                BtnStockSummary.Visible = true;
            }
            else
            {
                BtnStockSummary.Visible = false;
            }

            if (user.Member)
            {
                BtnMember.Visible = true;
            }
            else
            {
                BtnMember.Visible = false;
            }

            if (user.Supplier)
            {
                BtnSupplier.Visible = true;
            }
            else
            {
                BtnSupplier.Visible = false;
            }

            if (user.ItemPricing)
            {
                BtnItemPricing.Visible = true;
            }
            else
            {
                BtnItemPricing.Visible = false;
            }

            if (user.Bank)
            {
                BtnBank.Visible = true;
            }
            else
            {
                BtnBank.Visible = false;
            }

            if (user.Employee)
            {
                BtnEmployee.Visible = true;
            }
            else
            {
                BtnEmployee.Visible = false;
            }

            if (user.Reports)
            {
                BtnReports.Visible = true;
            }
            else
            {
                BtnReports.Visible = false;
            }

            if (user.Settings)
            {
                BtnSettings.Visible = true;
            }
            else
            {
                BtnSettings.Visible = false;
            }

            if (user.EOD)
            {
                BtnEOD.Visible = true;
            }
            else
            {
                BtnEOD.Visible = false;
            }

        }

        #endregion

    }
}
