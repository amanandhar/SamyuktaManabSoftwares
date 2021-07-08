using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ProfitLossForm : Form
    {
        private readonly IIncomeDetailService _incomeDetailService;

        #region Constructor
        public ProfitLossForm(IIncomeDetailService incomeDetailService)
        {
            InitializeComponent();
            _incomeDetailService = incomeDetailService;
        }
        #endregion

        #region Form Load Event
        private void ProfitLossForm_Load(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, System.EventArgs e)
        {
            RichSalesProfit.Text = _incomeDetailService.GetIncomeDetails().ToList().Sum(x => x.Total).ToString();
            RichTotalAmount.Text = Convert.ToDecimal(RichSalesProfit.Text).ToString();
        }
        #endregion
    }
}
