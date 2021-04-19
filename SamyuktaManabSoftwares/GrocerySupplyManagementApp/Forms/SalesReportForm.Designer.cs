
namespace GrocerySupplyManagementApp.Forms
{
    partial class SalesReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sampleSalesDBDataSet = new GrocerySupplyManagementApp.SampleSalesDBDataSet();
            this.tblFullSalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_FullSalesTableAdapter = new GrocerySupplyManagementApp.SampleSalesDBDataSetTableAdapters.tbl_FullSalesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sampleSalesDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFullSalesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblFullSalesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GrocerySupplyManagementApp.Reports.SalesReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // sampleSalesDBDataSet
            // 
            this.sampleSalesDBDataSet.DataSetName = "SampleSalesDBDataSet";
            this.sampleSalesDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblFullSalesBindingSource
            // 
            this.tblFullSalesBindingSource.DataMember = "tbl_FullSales";
            this.tblFullSalesBindingSource.DataSource = this.sampleSalesDBDataSet;
            // 
            // tbl_FullSalesTableAdapter
            // 
            this.tbl_FullSalesTableAdapter.ClearBeforeFill = true;
            // 
            // SalesReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SalesReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesReportForm";
            this.Load += new System.EventHandler(this.SalesReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sampleSalesDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFullSalesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SampleSalesDBDataSet sampleSalesDBDataSet;
        private System.Windows.Forms.BindingSource tblFullSalesBindingSource;
        private SampleSalesDBDataSetTableAdapters.tbl_FullSalesTableAdapter tbl_FullSalesTableAdapter;
    }
}