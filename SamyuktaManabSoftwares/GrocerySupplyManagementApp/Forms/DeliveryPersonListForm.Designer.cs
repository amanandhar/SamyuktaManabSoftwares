
namespace GrocerySupplyManagementApp.Forms
{
    partial class DeliveryPersonListForm
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
            this.DataGridDeliveryPersonList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridDeliveryPersonList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridDeliveryPersonList
            // 
            this.DataGridDeliveryPersonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridDeliveryPersonList.Location = new System.Drawing.Point(12, 12);
            this.DataGridDeliveryPersonList.Name = "DataGridDeliveryPersonList";
            this.DataGridDeliveryPersonList.Size = new System.Drawing.Size(510, 437);
            this.DataGridDeliveryPersonList.TabIndex = 0;
            this.DataGridDeliveryPersonList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridDeliveryPersonList_CellDoubleClick);
            this.DataGridDeliveryPersonList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridDeliveryPersonList_DataBindingComplete);
            // 
            // DeliveryPersonListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.DataGridDeliveryPersonList);
            this.Name = "DeliveryPersonListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DeliveryPersonListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridDeliveryPersonList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridDeliveryPersonList;
    }
}