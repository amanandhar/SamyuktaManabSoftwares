using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SettingForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly ITaxService _taxService;
        private readonly IItemService _itemService;
        private readonly IPurchasedItemService _purchasedItemService;

        #region Constructor
        public SettingForm(IFiscalYearService fiscalYearService, ITaxService taxService, 
            IItemService itemService, IPurchasedItemService purchasedItemService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _taxService = taxService;
            _itemService = itemService;
            _purchasedItemService = purchasedItemService;
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
            ItemForm addNewCodeForm = new ItemForm(_itemService);
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
