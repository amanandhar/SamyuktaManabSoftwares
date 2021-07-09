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
            RichSalesProfit.Text = _incomeDetailService.GetSalesProfit().ToList().Sum(x => x.Total).ToString();
            RichMembershipFee.Text = _incomeDetailService.GetMemberFee().ToList().Sum(x => x.Total).ToString();
            RichSupplierCommission.Text = _incomeDetailService.GetSupplilersCommission().ToList().Sum(x => x.Total).ToString();
            RichDeliveryCharge.Text = _incomeDetailService.GetDeliveryCharge().ToList().Sum(x => x.Total).ToString();
            RichOtherIncome.Text = _incomeDetailService.GetOtherIncome().ToList().Sum(x => x.Total).ToString();
            
            RichTotalAmount.Text = (Convert.ToDecimal(RichSalesProfit.Text) 
                + Convert.ToDecimal(RichMembershipFee.Text) 
                + Convert.ToDecimal(RichSupplierCommission.Text) 
                + Convert.ToDecimal(RichDeliveryCharge.Text) 
                + Convert.ToDecimal(RichOtherIncome.Text)).ToString();
        }
        #endregion
    }
}
