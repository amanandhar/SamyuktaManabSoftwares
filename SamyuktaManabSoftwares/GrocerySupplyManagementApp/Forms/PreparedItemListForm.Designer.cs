
namespace GrocerySupplyManagementApp.Forms
{
    partial class PreparedItemListForm
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
            this.DataGridPreparedItemList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPreparedItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridPreparedItemList
            // 
            this.DataGridPreparedItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridPreparedItemList.Location = new System.Drawing.Point(12, 12);
            this.DataGridPreparedItemList.Name = "DataGridPreparedItemList";
            this.DataGridPreparedItemList.Size = new System.Drawing.Size(510, 437);
            this.DataGridPreparedItemList.TabIndex = 0;
            this.DataGridPreparedItemList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridPreparedItemList_CellDoubleClick);
            this.DataGridPreparedItemList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridPreparedItemList_DataBindingComplete);
            // 
            // PreparedItemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.DataGridPreparedItemList);
            this.Name = "PreparedItemListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PreparedItemList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPreparedItemList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridPreparedItemList;
    }
}