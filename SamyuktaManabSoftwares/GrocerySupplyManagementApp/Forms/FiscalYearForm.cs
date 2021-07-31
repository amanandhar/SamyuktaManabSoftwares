using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class FiscalYearForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;

        #region Constructor
        public FiscalYearForm(IFiscalYearService fiscalYearService,
            IBankTransactionService bankTransactionService, IPurchasedItemService purchasedItemService,
            ISoldItemService soldItemService, IUserTransactionService userTransactionService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _bankTransactionService = bankTransactionService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
        }
        #endregion

        #region Form Load Event
        private void FiscalYearForm_Load(object sender, EventArgs e)
        {
            var fiscalYear = _fiscalYearService.GetFiscalYear();
            if(fiscalYear != null)
            {
                RichInvoiceNo.Text = fiscalYear.StartingInvoiceNo;
                RichBillNo.Text = fiscalYear.StartingBillNo;
                RichCompanyStartingDate.Text = fiscalYear.StartingDate;
                RichFiscalYear.Text = fiscalYear.Year;
            }           
        }
        #endregion

        #region Button Click Event
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields(true);
            RichInvoiceNo.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var currentDate = DateTime.Now;
                var endOfDay = RichCompanyStartingDate.Text;
                var fiscalYear = new FiscalYear
                {
                    StartingInvoiceNo = RichInvoiceNo.Text,
                    StartingBillNo = RichBillNo.Text,
                    StartingDate = endOfDay,
                    Year = RichFiscalYear.Text,
                    AddedDate = currentDate,
                    UpdatedDate = currentDate
                };

                var truncate = true;
                _fiscalYearService.AddFiscalYear(fiscalYear, truncate);

                _bankTransactionService.DeleteBankTransactionAfterEndOfDay(endOfDay);
                _purchasedItemService.DeletePurchasedItemAfterEndOfDay(endOfDay);
                _soldItemService.DeleteSoldItemAfterEndOfDay(endOfDay);
                _userTransactionService.DeleteUserTransactionAfterEndOfDay(endOfDay);

                DialogResult result = MessageBox.Show("Fiscal year detail has been saved successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    EnableFields(false);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Helper Methods
        private void EnableFields(bool option)
        {
            RichInvoiceNo.Enabled = option;
            RichBillNo.Enabled = option;
            RichCompanyStartingDate.Enabled = option;
            RichFiscalYear.Enabled = option;
        }
        #endregion
    }
}
