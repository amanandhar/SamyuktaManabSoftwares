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
    public partial class InvoiceReportForm : Form
    {
        public InvoiceReportForm()
        {
            InitializeComponent();
        }

        private void SalesReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sampleSalesDBDataSet.tbl_FullSales' table. You can move, or remove it, as needed.
            this.tbl_FullSalesTableAdapter.Fill(this.sampleSalesDBDataSet.tbl_FullSales);
            //this.Controls.Add(this.reportViewer1);
            this.reportViewer1.RefreshReport();
        }
    }
}
