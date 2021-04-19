using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
           
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BalanceSheetForm balanceSheetForm = new BalanceSheetForm();
            balanceSheetForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PfofitLossForm pfofitLossForm = new PfofitLossForm();
            pfofitLossForm.Show();
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
