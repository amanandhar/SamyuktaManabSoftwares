
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewerInvoice = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerInvoice
            // 
            this.reportViewerInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewerInvoice.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerInvoice.LocalReport.ReportEmbeddedResource = "GrocerySupplyManagementApp.Reports.InvoiceReport.rdlc";
            this.reportViewerInvoice.Location = new System.Drawing.Point(0, 0);
            this.reportViewerInvoice.Name = "reportViewerInvoice";
            this.reportViewerInvoice.ServerReport.BearerToken = null;
            this.reportViewerInvoice.Size = new System.Drawing.Size(719, 787);
            this.reportViewerInvoice.TabIndex = 0;
            // 
            // InvoiceReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 787);
            this.Controls.Add(this.reportViewerInvoice);
            this.Name = "InvoiceReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.InvoiceReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerInvoice;
    }
}