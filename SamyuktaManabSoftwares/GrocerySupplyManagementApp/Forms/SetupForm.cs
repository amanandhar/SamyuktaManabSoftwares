using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SetupForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IEndOfDayService _endOfDayService;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Enum
        private enum Action
        {
            Edit,
            Save,
            Load,
            None
        }
        #endregion

        #region Constructor
        public SetupForm(string username, ISettingService settingService,
            IEndOfDayService endOfDayService)
        {
            InitializeComponent();

            _settingService = settingService;
            _endOfDayService = endOfDayService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
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
                if(ValidateSettingsInfo())
                {
                    var newEndOfDay = TxtBoxCompanyStartingDt.Text.Trim();

                    if (_endOfDayService.IsEndOfDayExist(newEndOfDay))
                    {
                        var setting = new Setting
                        {
                            Discount = Convert.ToDecimal(TxtBoxDiscount.Text.Trim()),
                            Vat = Convert.ToDecimal(TxtBoxVat.Text.Trim()),
                            DeliveryCharge = Convert.ToDecimal(TxtBoxDeliveryCharge.Text.Trim()),
                            FiscalYear = TxtBoxFiscalYear.Text.Trim(),
                            StartingDate = newEndOfDay,
                            StartingBillNo = TxtBoxStartingBillNo.Text.Trim(),
                            StartingInvoiceNo = TxtBoxStartingInvoiceNo.Text.Trim(),
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };

                        var truncate = true;
                        _settingService.AddSetting(setting, truncate);

                        if (!string.IsNullOrWhiteSpace(newEndOfDay))
                        {
                            _settingService.DeletePreviousTransactions(newEndOfDay);
                        }

                        DialogResult result = MessageBox.Show("Setting has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            EnableFields();
                            EnableFields(Action.Save);

                            //Close the application
                            Application.Exit();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(newEndOfDay + " is not valid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
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

        #region Validation
        private bool ValidateSettingsInfo()
        {
            var isValidated = false;

            var discount = TxtBoxDiscount.Text.Trim();
            var vat = TxtBoxVat.Text.Trim();
            var deliveryCharge = TxtBoxDeliveryCharge.Text.Trim();
            var fiscalYear = TxtBoxFiscalYear.Text.Trim();
            var companyStartingDate = TxtBoxCompanyStartingDt.Text.Trim();
            var startingBillNo = TxtBoxStartingBillNo.Text.Trim();
            var startingInvoiceNo = TxtBoxStartingInvoiceNo.Text.Trim();

            if (string.IsNullOrWhiteSpace(discount)
                || string.IsNullOrWhiteSpace(vat)
                || string.IsNullOrWhiteSpace(deliveryCharge)
                || string.IsNullOrWhiteSpace(fiscalYear)
                || string.IsNullOrWhiteSpace(companyStartingDate)
                || string.IsNullOrWhiteSpace(startingBillNo)
                || string.IsNullOrWhiteSpace(startingInvoiceNo))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Discount " +
                    "\n * Vat " +
                    "\n * Delivery Charge " +
                    "\n * Fiscal Year " +
                    "\n * Company Starting Date " +
                    "\n * Starting Bill No " +
                    "\n * Starting Invoice No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }
        #endregion
    }
}
