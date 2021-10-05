using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SetupForm : Form
    {
        private readonly ISettingService _settingService;

        private readonly string _username;

        #region Constructor
        private enum Action
        {
            Edit,
            Save,
            Load,
            None
        }
        #endregion

        #region Constructor
        public SetupForm(string username, ISettingService settingService)
        {
            InitializeComponent();

            _settingService = settingService;

            _username = username;
        }
        #endregion

        #region Form Load Event
        private void SetupForm_Load(object sender, EventArgs e)
        {
            PopulateSettings();
            EnableFields();
            EnableFields(Action.Load);
        }
        #endregion

        #region Button Event
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Edit);
            TxtBoxDiscount.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var setting = new Setting
                {
                    Discount = Convert.ToDecimal(TxtBoxDiscount.Text.Trim()),
                    Vat = Convert.ToDecimal(TxtBoxVat.Text.Trim()),
                    DeliveryCharge = Convert.ToDecimal(TxtBoxDeliveryCharge.Text.Trim()),
                    FiscalYear = TxtBoxFiscalYear.Text.Trim(),
                    StartingDate = TxtBoxCompanyStartingDt.Text.Trim(),
                    StartingBillNo = TxtBoxStartingBillNo.Text.Trim(),
                    StartingInvoiceNo = TxtBoxStartingInvoiceNo.Text.Trim(),
                    AddedBy = _username,
                    AddedDate = DateTime.Now
                };

                var truncate = true;
                _settingService.AddSetting(setting, truncate);

                DialogResult result = MessageBox.Show("Setting has been saved successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    EnableFields();
                    EnableFields(Action.Save);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Helper Methods
        private void PopulateSettings()
        {
            var setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            if(setting != null)
            {
                TxtBoxDiscount.Text = setting.Discount.ToString();
                TxtBoxVat.Text = setting.Vat.ToString();
                TxtBoxDeliveryCharge.Text = setting.DeliveryCharge.ToString();
                TxtBoxFiscalYear.Text = setting.FiscalYear;
                TxtBoxCompanyStartingDt.Text = setting.StartingDate;
                TxtBoxStartingBillNo.Text = setting.StartingBillNo;
                TxtBoxStartingInvoiceNo.Text = setting.StartingInvoiceNo; ;
            }
        }

        private void EnableFields(Action action = Action.None)
        {
            if(action == Action.Edit)
            {
                TxtBoxDiscount.Enabled = true;
                TxtBoxVat.Enabled = true;
                TxtBoxDeliveryCharge.Enabled = true;
                TxtBoxFiscalYear.Enabled = true;
                TxtBoxCompanyStartingDt.Enabled = true;
                TxtBoxStartingBillNo.Enabled = true;
                TxtBoxStartingInvoiceNo.Enabled = true;

                BtnSave.Enabled = true;
            }
            else if (action == Action.Save)
            {
                BtnEdit.Enabled = true;
            }
            else if (action == Action.Load)
            {
                BtnEdit.Enabled = true;
            }
            else
            {
                TxtBoxDiscount.Enabled = false;
                TxtBoxVat.Enabled = false;
                TxtBoxDeliveryCharge.Enabled = false;
                TxtBoxFiscalYear.Enabled = false;
                TxtBoxCompanyStartingDt.Enabled = false;
                TxtBoxStartingBillNo.Enabled = false;
                TxtBoxStartingInvoiceNo.Enabled = false;

                BtnEdit.Enabled = false;
                BtnSave.Enabled = false;
            }
        }
        #endregion
    }
}
