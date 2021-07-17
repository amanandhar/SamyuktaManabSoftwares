
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
            this.DataGridBankList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBankList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridBankList
            // 
            this.DataGridBankList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridBankList.Location = new System.Drawing.Point(12, 12);
            this.DataGridBankList.Name = "DataGridBankList";
            this.DataGridBankList.Size = new System.Drawing.Size(510, 437);
            this.DataGridBankList.TabIndex = 0;
            this.DataGridBankList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridBankDetails_CellDoubleClick);
            this.DataGridBankList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridBankDetails_DataBindingComplete);
            // 
            // BankListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.DataGridBankList);
            this.Name = "BankListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BankListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBankList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridBankList;
    }
}