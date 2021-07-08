using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SettingForm : Form
    {
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        private readonly ITaxDetailService _taxDetailService;
        private readonly IItemService _itemService;

        #region Constructor
        public SettingForm(IFiscalYearDetailService fiscalYearDetailService, ITaxDetailService taxDetailService, IItemService itemService)
        {
            InitializeComponent();

            _fiscalYearDetailService = fiscalYearDetailService;
            _taxDetailService = taxDetailService;
            _itemService = itemService;
        }
        #endregion

        #region Form Load Event
        private void SettingForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button Click Events
        private void BtnCompanyInfo_Click(object sender, EventArgs e)
        {
            CompanyInfoForm companyEnfoForm = new CompanyInfoForm();
            companyEnfoForm.Show();
        }

        private void BtnAddNewCode_Click(object sender, EventArgs e)
        {
            AddNewCodeForm addNewCodeForm = new AddNewCodeForm(_itemService);
            addNewCodeForm.Show();
        }

        private void BtnUserSetup_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Show();
        }

        private void BtnFiscalYearForm_Click(object sender, EventArgs e)
        {
            FiscalYearForm fiscalYearForm = new FiscalYearForm(_fiscalYearDetailService);
            fiscalYearForm.Show();
        }

        private void BtnSetPassword_Click(object sender, EventArgs e)
        {
            SetPasswordForm setPasswordForm = new SetPasswordForm();
            setPasswordForm.Show();
        }

        private void BtnVatTaxSetup_Click(object sender, EventArgs e)
        {
            TaxSetupForm taxSetupForm = new TaxSetupForm(_taxDetailService);
            taxSetupForm.Show();
        }
        #endregion
    }
}
