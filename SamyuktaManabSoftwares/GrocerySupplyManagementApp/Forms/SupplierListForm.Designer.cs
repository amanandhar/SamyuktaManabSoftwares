
namespace GrocerySupplyManagementApp.Forms
{
    partial class SupplierListForm
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
            this.DataGridSupplierList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSupplierList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridSupplierList
            // 
            this.DataGridSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridSupplierList.Location = new System.Drawing.Point(12, 12);
            this.DataGridSupplierList.Name = "DataGridSupplierList";
            this.DataGridSupplierList.Size = new System.Drawing.Size(392, 426);
            this.DataGridSupplierList.TabIndex = 0;
            this.DataGridSupplierList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSupplierList_CellDoubleClick);
            // 
            // SupplierListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 450);
            this.Controls.Add(this.DataGridSupplierList);
            this.Name = "SupplierListForm";
            this.Text = "Supplier List Form";
            this.Load += new System.EventHandler(this.SupplierListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSupplierList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridSupplierList;
    }
}