using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SettingForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly ICompanyInfoService _companyInfoService;
        private readonly ITaxService _taxService;
        private readonly IItemService _itemService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        private readonly IItemCategoryService _itemCategoryService;

        #region Constructor
        public SettingForm(IFiscalYearService fiscalYearService, ICompanyInfoService companyInfoService,
            ITaxService taxService, IItemService itemService,
            IBankTransactionService bankTransactionService, IPurchasedItemService purchasedItemService,
            ISoldItemService soldItemService, IUserTransactionService userTransactionService,
            IEmployeeService employeeService, IUserService userService,
            IItemCategoryService itemCategoryService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _companyInfoService = companyInfoService;
            _taxService = taxService;
            _itemService = itemService;
            _bankTransactionService = bankTransactionService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _employeeService = employeeService;
            _userService = userService;
            _itemCategoryService = itemCategoryService;
        }
        #endregion

        #region Form Load Event
        private void SettingForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button Click Event
        private void BtnCompanyInfo_Click(object sender, EventArgs e)
        {
            CompanyInfoForm companyInfoForm = new CompanyInfoForm(_companyInfoService);
            companyInfoForm.Show();
        }

        private void BtnAddNewCode_Click(object sender, EventArgs e)
        {
            ItemForm addNewCodeForm = new ItemForm(_itemService, _itemCategoryService);
            addNewCodeForm.Show();
        }

        private void BtnDelivery_Click(object sender, EventArgs e)
        {
            DeliveryPersonForm deliveryPersonForm = new DeliveryPersonForm(_fiscalYearService, _userTransactionService,
                _employeeService);
            deliveryPersonForm.ShowDialog();
        }

        private void BtnUserSetup_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(_userService);
            userForm.Show();
        }

        private void BtnFiscalYearForm_Click(object sender, EventArgs e)
        {
            FiscalYearForm fiscalYearForm = new FiscalYearForm(_fiscalYearService,
                _bankTransactionService, _purchasedItemService,
                _soldItemService, _userTransactionService);
            fiscalYearForm.Show();
        }

        private void BtnSetPassword_Click(object sender, EventArgs e)
        {
            SetPasswordForm setPasswordForm = new SetPasswordForm(_userService);
            setPasswordForm.Show();
        }

        private void BtnVatTaxSetup_Click(object sender, EventArgs e)
        {
            TaxSetupForm taxSetupForm = new TaxSetupForm(_taxService);
            taxSetupForm.Show();
        }

        private void BtnSetup_Click(object sender, EventArgs e)
        {
            SalesPurchaseForm setupForm = new SalesPurchaseForm();
            setupForm.ShowDialog();
        }

        #endregion
    }
}
