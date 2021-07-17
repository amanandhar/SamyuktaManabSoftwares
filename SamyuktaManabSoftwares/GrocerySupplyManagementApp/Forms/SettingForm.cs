using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SettingForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ITaxService _taxService;
        private readonly IItemService _itemService;

        #region Constructor
        public SettingForm(IFiscalYearService fiscalYearService, IPurchasedItemService purchasedItemService,
            ITaxService taxService, IItemService itemService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _purchasedItemService = purchasedItemService;
            _taxService = taxService;
            _itemService = itemService;
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
            CompanyInfoForm companyInfoForm = new CompanyInfoForm();
            companyInfoForm.Show();
        }

        private void BtnAddNewCode_Click(object sender, EventArgs e)
        {
            AddNewCodeForm addNewCodeForm = new AddNewCodeForm(_itemService, _purchasedItemService);
            addNewCodeForm.Show();
        }

        private void BtnUserSetup_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Show();
        }

        private void BtnFiscalYearForm_Click(object sender, EventArgs e)
        {
            FiscalYearForm fiscalYearForm = new FiscalYearForm(_fiscalYearService);
            fiscalYearForm.Show();
        }

        private void BtnSetPassword_Click(object sender, EventArgs e)
        {
            SetPasswordForm setPasswordForm = new SetPasswordForm();
            setPasswordForm.Show();
        }

        private void BtnVatTaxSetup_Click(object sender, EventArgs e)
        {
            TaxSetupForm taxSetupForm = new TaxSetupForm(_taxService);
            taxSetupForm.Show();
        }
        #endregion
    }
}
