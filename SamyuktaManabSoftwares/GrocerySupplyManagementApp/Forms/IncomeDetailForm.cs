using GrocerySupplyManagementApp.Services;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class IncomeDetailForm : Form
    {
        private readonly IIncomeDetailService _incomeDetailService;

        #region Constructor
        public IncomeDetailForm(IIncomeDetailService incomeDetailService)
        {
            InitializeComponent();

            _incomeDetailService = incomeDetailService;
        }
        #endregion

        #region Form Load Event
        private void IncomeDetailForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            var income = ComboAddIncome.Text;
            if(income.Equals("1. Sales Profit"))
            {
                _incomeDetailService.GetIncomeDetails();
            }
        }
        #endregion

        #region DataGrid Event 
        private void DataGridIncomeView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        #endregion
    }
}
