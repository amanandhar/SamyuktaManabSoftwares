using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Drawing;
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
        private readonly IUserService _userService;
        private readonly IItemCategoryService _itemCategoryService;

        #region Constructor
        public DashboardForm(IFiscalYearService fiscalYearService,
            ICompanyInfoService companyInfoService, ITaxService taxService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IItemService itemService, IPricedItemService pricedItemService,
            IMemberService memberService, ISupplierService supplierService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService,
            IUserTransactionService userTransactionService, IStockService stockService,
            IEndOfDayService endOfDateService, IEmployeeService employeeService,
            IReportService reportService, IUserService userService,
            IItemCategoryService itemCategoryService)
        {
            InitializeComponent();
            CustomizeDesign();

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
            _userService = userService;
            _itemCategoryService = itemCategoryService;
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

        #region Button Click Events

        private void BtnPointOfSales_Click(object sender, EventArgs e)
        {
            PosForm posForm = new PosForm(
                _fiscalYearService, _taxService,
                _bankService, _bankTransactionService,
                _itemService, _pricedItemService,
                _memberService,
                _purchasedItemService, _soldItemService,
                _userTransactionService, _reportService,
                _companyInfoService, _employeeService,
                _stockService
                 );
            posForm.ShowDialog();

            //OpenChildForm(new PosForm(
            //    _fiscalYearService, _taxService,
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
            OpenChildForm(new SummaryForm(_fiscalYearService, _bankTransactionService,
                _purchasedItemService, _soldItemService,
                _userTransactionService));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnStockSummary_Click(object sender, EventArgs e)
        {
           OpenChildForm(new StockForm(_fiscalYearService, _purchasedItemService,
                _soldItemService, _stockService));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnMember_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MemberForm(_fiscalYearService,
                _bankService, _bankTransactionService,
                _memberService, _soldItemService,
                _userTransactionService, _employeeService,
                this));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnSupplier_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SupplierForm(_fiscalYearService, _bankService,
                _bankTransactionService, _itemService,
                _supplierService, _purchasedItemService,
                _userTransactionService));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnItemPricing_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PricedItemForm(_itemService, _pricedItemService,
                _purchasedItemService, _soldItemService,
                _stockService, this));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnBank_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BankForm(_fiscalYearService, _bankService,
                _bankTransactionService));
            HideSubMenu();
            SelectButton(sender as Button);
        }

        private void BtnEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeForm(_employeeService));
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
            OpenChildForm(new BalanceSheetForm(_fiscalYearService, _bankTransactionService,
               _userTransactionService, _stockService));
            SelectButton(sender as Button, true);
        }

        private void BtnDailyIncome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new IncomeForm(_fiscalYearService,
                _bankService, _bankTransactionService, _userTransactionService));
            SelectButton(sender as Button, true);
        }

        private void BtnDailyExpense_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ExpenseForm(_fiscalYearService,
                _bankService, _bankTransactionService,
                _userTransactionService));
            SelectButton(sender as Button, true);
        }

        private void BtnProfitLoss_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProfitLossForm(_fiscalYearService, _userTransactionService));
            SelectButton(sender as Button, true);
        }

        private void BtnReportInvoice_Click(object sender, EventArgs e)
        {
            SelectButton(sender as Button, true);
        }

        private void BtnSalesReturn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SalesReturnForm());
            SelectButton(sender as Button, true);
        }

        private void BtnShareCapital_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ShareMemberForm());
            SelectButton(sender as Button, true);
        }

        private void BtnStockAdjustment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StockAdjustmentForm());
            SelectButton(sender as Button, true);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SelectButton(sender as Button);
            ShowSubMenu(PanelSettingsSubMenu);
        }

        private void BtnCompanyInformation_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CompanyInfoForm(_companyInfoService));
            SelectButton(sender as Button, true);
        }

        private void BtnDeliveryPerson_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DeliveryPersonForm(_fiscalYearService, _userTransactionService,
                _employeeService));
            SelectButton(sender as Button, true);
        }

        private void BtnFiscalYear_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FiscalYearForm(_fiscalYearService,
                _bankTransactionService, _purchasedItemService,
                _soldItemService, _userTransactionService));
            SelectButton(sender as Button, true);
        }

        private void BtnNewCodeSetup_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ItemForm(_itemService, _itemCategoryService));
            SelectButton(sender as Button, true);
        }

        private void BtnUserSetup_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserForm(_userService));
            SelectButton(sender as Button, true);
        }

        private void BtnUpdatePassword_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SetPasswordForm());
            SelectButton(sender as Button, true);
        }

        private void BtnVatSetup_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaxSetupForm(_taxService));
            SelectButton(sender as Button, true);
        }

        private void BtnSetup_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SetupForm());
            SelectButton(sender as Button, true);
        }

        private void BtnEOD_Click(object sender, EventArgs e)
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

                    if (_fiscalYearService.UpdateFiscalYear(newFiscalYear))
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

            RichBoxUsername.Text = "User: Bhai Raja Manandhar";
            RichBoxUsername.SelectionAlignment = HorizontalAlignment.Center;
            RichBoxFiscalYear.Text = "Fiscal Year: " + fiscalYear.Year;
            RichBoxFiscalYear.SelectionAlignment = HorizontalAlignment.Center;
        }
        #endregion

        private void lblCompanyShortName_Click(object sender, EventArgs e)
        {
            OpenChildForm(null);
        }
    }
}
