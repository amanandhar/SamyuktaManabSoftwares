using GrocerySupplyManagementApp.Services;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SettingForm : Form
    {
        private readonly IFiscalYearDetailService _fiscalYearDetailService;
        private readonly ITaxDetailService _taxDetailService;

        public SettingForm(IFiscalYearDetailService fiscalYearDetailService, ITaxDetailService taxDetailService)
        {
            InitializeComponent();

            _fiscalYearDetailService = fiscalYearDetailService;
            _taxDetailService = taxDetailService;
        }

        private void btnUserSetup_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Show();
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            SetPasswordForm setPasswordForm = new SetPasswordForm();
            setPasswordForm.Show();
           
        }

        private void btnCompanyInfo_Click(object sender, EventArgs e)
        {
            CompanyInfoForm companyEnfoForm = new CompanyInfoForm();
            companyEnfoForm.Show();
        }

        private void btnFiscalYearDateVat_Click(object sender, EventArgs e)
        {
            FiscalYearForm fiscalYearForm = new FiscalYearForm(_fiscalYearDetailService);
            fiscalYearForm.Show();
        }

        private void btnVatTaxSetup_Click(object sender, EventArgs e)
        {
            TaxSetupForm taxSetupForm = new TaxSetupForm(_taxDetailService);
            taxSetupForm.Show();
        }
    }
}
