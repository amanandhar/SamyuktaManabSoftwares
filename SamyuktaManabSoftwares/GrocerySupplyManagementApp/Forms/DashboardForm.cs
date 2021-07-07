using GrocerySupplyManagementApp.Services;
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
        private readonly IPosTransactionService _posTransactionService;
        private readonly IPosSoldItemService _posSoldItemService;
        private readonly ITransactionService _transactionService;
        private readonly IPreparedItemService _preparedItemService;
        private readonly IBankDetailService _bankDetailService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IIncomeDetailService _incomeDetailService;

        #region Constructor
        public DashboardForm(IMemberService memberService, ISupplierService supplierService, IItemService itemService,
            IItemTransactionService itemTransactionService, ISupplierTransactionService supplierTransactionService, 
            IFiscalYearDetailService fiscalYearDetailService, ITaxDetailService taxDetailService,
            IPosTransactionService posTransactionService, IPosSoldItemService posSoldItemService, 
            ITransactionService transactionService, IPreparedItemService preparedItemService,
            IBankDetailService bankDetailService, IBankTransactionService bankTransactionService,
            IIncomeDetailService incomeDetailService)
        {
            InitializeComponent();

            _memberService = memberService;
            _supplierService = supplierService;
            _itemService = itemService;
            _itemTransactionService = itemTransactionService;
            _supplierTransactionService = supplierTransactionService;
            _fiscalYearDetailService = fiscalYearDetailService;
            _taxDetailService = taxDetailService;
            _posTransactionService = posTransactionService;
            _posSoldItemService = posSoldItemService;
            _transactionService = transactionService;
            _preparedItemService = preparedItemService;
            _bankDetailService = bankDetailService;
            _bankTransactionService = bankTransactionService;
            _incomeDetailService = incomeDetailService;
        }
        #endregion

        #region Form Load Load
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
            PosForm posForm = new PosForm(_memberService, _itemService, 
                _fiscalYearDetailService, _taxDetailService, 
                _posTransactionService, _posSoldItemService, 
                _transactionService, _preparedItemService, 
                _bankDetailService, _bankTransactionService,
                _itemTransactionService);
            posForm.Show();
        }

        private void BtnSummaryMgmt_Click(object sender, EventArgs e)
        {
            SummaryForm summaryForm = new SummaryForm(_transactionService, _fiscalYearDetailService, 
                _posSoldItemService, _posTransactionService,
                _bankTransactionService, _itemTransactionService);
            summaryForm.Show();
        }

        private void BtnMemberMgmt_Click(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm(_memberService, _posTransactionService, 
                _posSoldItemService, _bankDetailService, 
                _bankTransactionService, _fiscalYearDetailService, this);
            memberForm.Show();
        }

        private void BtnSupplierMgmt_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm(_supplierService, _itemService, 
                _itemTransactionService, _supplierTransactionService, 
                _bankDetailService, _bankTransactionService, _posTransactionService, _fiscalYearDetailService);
            supplierForm.Show();
        }

        private void BtnItemMgmt_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm(_itemService, _itemTransactionService, 
                _preparedItemService, this);
            itemForm.Show();
        }

        private void BtnStockMgmt_Click(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm(_itemTransactionService);
            stockForm.Show();
        }

        private void BtnIncomeExpenseMgmt_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseMgmtForm = new ExpenseForm(_fiscalYearDetailService, _posTransactionService, 
                _bankDetailService, _bankTransactionService);
            expenseMgmtForm.Show();
        }

        private void BtnBankingMgmt_Click(object sender, EventArgs e)
        {
            BankForm bankForm = new BankForm(_bankDetailService, _bankTransactionService);
            bankForm.Show();
        }

        private void BtnSettingMgmt_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(_fiscalYearDetailService, _taxDetailService, _itemService);
            settingForm.Show();
        }

        private void BtnReportsMgmt_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm(_fiscalYearDetailService, _posTransactionService, 
                _bankDetailService, _bankTransactionService,
                _incomeDetailService);
            reportForm.Show();
        }

        private void BtnStaffMgmt_Click(object sender, EventArgs e)
        {
            EmploeeForm staffForm = new EmploeeForm();
            staffForm.Show();
        }
        #endregion
    }
}
