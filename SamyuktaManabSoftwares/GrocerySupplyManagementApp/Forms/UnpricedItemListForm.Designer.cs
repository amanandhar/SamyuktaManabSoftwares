
namespace GrocerySupplyManagementApp.Forms
{
    partial class UnpricedItemListForm
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
            this.DataGridUnpricedItemList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUnpricedItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridUnpricedItemList
            // 
            this.DataGridUnpricedItemList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DataGridUnpricedItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridUnpricedItemList.Location = new System.Drawing.Point(12, 12);
            this.DataGridUnpricedItemList.Name = "DataGridUnpricedItemList";
            this.DataGridUnpricedItemList.Size = new System.Drawing.Size(510, 287);
            this.DataGridUnpricedItemList.TabIndex = 0;
            this.DataGridUnpricedItemList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridUnpricedItemList_CellDoubleClick);
            this.DataGridUnpricedItemList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridUnpricedItemList_DataBindingComplete);
            // 
            // UnpricedItemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.DataGridUnpricedItemList);
            this.Location = new System.Drawing.Point(825, 312);
            this.Name = "UnpricedItemListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UnpricedItemListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUnpricedItemList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridUnpricedItemList;
    }
}