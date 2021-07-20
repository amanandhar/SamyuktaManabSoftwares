
namespace GrocerySupplyManagementApp.Forms
{
    partial class PricedItemListForm
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
            this.DataGridPricedItemList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPricedItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridPricedItemList
            // 
            this.DataGridPricedItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridPricedItemList.Location = new System.Drawing.Point(12, 12);
            this.DataGridPricedItemList.Name = "DataGridPricedItemList";
            this.DataGridPricedItemList.Size = new System.Drawing.Size(510, 437);
            this.DataGridPricedItemList.TabIndex = 0;
            this.DataGridPricedItemList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridPricedItemList_CellDoubleClick);
            this.DataGridPricedItemList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridPricedItemList_DataBindingComplete);
            // 
            // PricedItemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.DataGridPricedItemList);
            this.Name = "PricedItemListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PricedItemListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPricedItemList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridPricedItemList;
    }
}