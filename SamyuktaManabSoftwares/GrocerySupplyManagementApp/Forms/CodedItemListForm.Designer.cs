
namespace GrocerySupplyManagementApp.Forms
{
    partial class CodedItemListForm
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
            this.DataGridCodedItemList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridCodedItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridCodedItemList
            // 
            this.DataGridCodedItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridCodedItemList.Location = new System.Drawing.Point(12, 12);
            this.DataGridCodedItemList.Name = "DataGridCodedItemList";
            this.DataGridCodedItemList.Size = new System.Drawing.Size(510, 437);
            this.DataGridCodedItemList.TabIndex = 0;
            this.DataGridCodedItemList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridPreparedItemList_CellDoubleClick);
            this.DataGridCodedItemList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridPreparedItemList_DataBindingComplete);
            // 
            // CodedItemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.DataGridCodedItemList);
            this.Name = "CodedItemListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PreparedItemList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridCodedItemList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridCodedItemList;
    }
}