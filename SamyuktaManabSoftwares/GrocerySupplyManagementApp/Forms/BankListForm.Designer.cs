
namespace GrocerySupplyManagementApp.Forms
{
    partial class BankListForm
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
            this.DataGridBankDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBankDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridBankDetails
            // 
            this.DataGridBankDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridBankDetails.Location = new System.Drawing.Point(12, 12);
            this.DataGridBankDetails.Name = "DataGridBankDetails";
            this.DataGridBankDetails.Size = new System.Drawing.Size(439, 426);
            this.DataGridBankDetails.TabIndex = 0;
            this.DataGridBankDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridBankDetails_CellDoubleClick);
            this.DataGridBankDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridBankDetails_DataBindingComplete);
            // 
            // BankListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 450);
            this.Controls.Add(this.DataGridBankDetails);
            this.Name = "BankListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BankListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBankDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridBankDetails;
    }
}