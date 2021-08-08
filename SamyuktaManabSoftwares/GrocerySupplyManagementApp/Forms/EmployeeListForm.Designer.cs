
namespace GrocerySupplyManagementApp.Forms
{
    partial class EmployeeListForm
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
            this.DataGridEmployeeList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEmployeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridEmployeeList
            // 
            this.DataGridEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridEmployeeList.Location = new System.Drawing.Point(12, 12);
            this.DataGridEmployeeList.Name = "DataGridEmployeeList";
            this.DataGridEmployeeList.Size = new System.Drawing.Size(510, 437);
            this.DataGridEmployeeList.TabIndex = 0;
            this.DataGridEmployeeList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridEmployeeList_CellDoubleClick);
            this.DataGridEmployeeList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridEmployeeList_DataBindingComplete);
            // 
            // EmployeeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.DataGridEmployeeList);
            this.Name = "EmployeeListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EmployeeListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEmployeeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridEmployeeList;
    }
}