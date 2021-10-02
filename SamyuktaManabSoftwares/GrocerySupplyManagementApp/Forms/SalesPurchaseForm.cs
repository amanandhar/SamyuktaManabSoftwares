using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SalesPurchaseForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IUserTransactionService _userTransactionService;

        private readonly string _endOfDay;

        #region Constructor
        public SalesPurchaseForm(IFiscalYearService fiscalYearService, IUserTransactionService userTransactionService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _userTransactionService = userTransactionService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
        }
        #endregion

        #region Form Load Event
        private void SalesPurchaseForm_Load(object sender, System.EventArgs e)
        {
            MaskDtEODFrom.Text = _endOfDay;
            MaskDtEODTo.Text = _endOfDay;

            LoadActions();
        }
        #endregion

        #region Button Event
        private void BtnShow_Click(object sender, System.EventArgs e)
        {
            LoadTransactions();
        }
        #endregion

        #region Radio Button Event
        private void RadioAll_CheckedChanged(object sender, System.EventArgs e)
        {
            MaskDtEODFrom.Clear();
            MaskDtEODTo.Clear();
        }
        #endregion

        #region Mask Date Event
        private void MaskDtEODFrom_KeyDown(object sender, KeyEventArgs e)
        {
            RadioAll.Checked = false;
        }

        private void MaskDtEODTo_KeyDown(object sender, KeyEventArgs e)
        {
            RadioAll.Checked = false;
        }
        #endregion

        #region #region Data Grid Event
        private void DataGridPurchaseSalesTransaction_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        #endregion

        #region Helper Methods
        private void LoadActions()
        {
            ComboAction.ValueMember = "Id";
            ComboAction.DisplayMember = "Value";

            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.PURCHASE, Value = Constants.PURCHASE });
            ComboAction.Items.Add(new ComboBoxItem { Id = Constants.SALES, Value = Constants.SALES });
        }

        public void LoadTransactions()
        {
            var purchaseSalesTransactionFilter = new PurchaseSalesTransactionFilter();
            if (!string.IsNullOrWhiteSpace(MaskDtEODFrom.Text.Replace("-", string.Empty).Trim()))
            {
                purchaseSalesTransactionFilter.DateFrom = MaskDtEODFrom.Text;
            }

            if (!string.IsNullOrWhiteSpace(MaskDtEODTo.Text.Replace("-", string.Empty).Trim()))
            {
                purchaseSalesTransactionFilter.DateTo = MaskDtEODTo.Text;
            }
            
            purchaseSalesTransactionFilter.Action = ComboAction.Text;

            /*
            List<PurchaseSalesTransactionView> purchaseSalesTransactionViewList = _userTransactionService.GetTransactionViewList(purchaseSalesTransactionFilter).ToList();
            TxtAmount.Text = purchaseSalesTransactionViewList.Sum(x => x.Amount).ToString();

            var bindingList = new BindingList<PurchaseSalesTransactionView>(purchaseSalesTransactionViewList);
            var source = new BindingSource(bindingList, null);
            DataGridPurchaseSalesTransaction.DataSource = source;
            */
        }
        #endregion
    }
}
