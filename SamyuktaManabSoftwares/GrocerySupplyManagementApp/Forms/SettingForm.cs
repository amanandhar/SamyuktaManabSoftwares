using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
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
            CompanyEnfoForm companyEnfoForm = new CompanyEnfoForm();
            companyEnfoForm.Show();
        }

        private void btnFiscalYearDateVat_Click(object sender, EventArgs e)
        {
            FiscalYearForm fiscalYearForm = new FiscalYearForm();
            fiscalYearForm.Show();
        }

        private void btnVatTaxSetup_Click(object sender, EventArgs e)
        {
            TaxSetupForm taxSetupForm = new TaxSetupForm();
            taxSetupForm.Show();
        }
    }
}
