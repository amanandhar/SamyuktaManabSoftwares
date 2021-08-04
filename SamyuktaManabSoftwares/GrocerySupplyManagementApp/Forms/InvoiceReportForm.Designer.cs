
namespace GrocerySupplyManagementApp.Forms
{
    partial class InvoiceReportForm
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
            this.tblFullSalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sampleSalesDBDataSet = new GrocerySupplyManagementApp.SampleSalesDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_FullSalesTableAdapter = new GrocerySupplyManagementApp.SampleSalesDBDataSetTableAdapters.tbl_FullSalesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tblFullSalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleSalesDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tblFullSalesBindingSource
            // 
            this.tblFullSalesBindingSource.DataMember = "tbl_FullSales";
            this.tblFullSalesBindingSource.DataSource = this.sampleSalesDBDataSet;
            // 
            // sampleSalesDBDataSet
            // 
            this.sampleSalesDBDataSet.DataSetName = "SampleSalesDBDataSet";
            this.sampleSalesDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.reportViewer1.Size = new System.Drawing.Size(889, 531);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_FullSalesTableAdapter
            // 
            this.tbl_FullSalesTableAdapter.ClearBeforeFill = true;
            // 
            // InvoiceReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 531);
            this.Controls.Add(this.reportViewer1);
            this.Name = "InvoiceReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.InvoiceReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblFullSalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleSalesDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SampleSalesDBDataSet sampleSalesDBDataSet;
        private System.Windows.Forms.BindingSource tblFullSalesBindingSource;
        private SampleSalesDBDataSetTableAdapters.tbl_FullSalesTableAdapter tbl_FullSalesTableAdapter;
    }
}