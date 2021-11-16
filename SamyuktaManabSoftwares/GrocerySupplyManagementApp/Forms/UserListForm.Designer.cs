
namespace GrocerySupplyManagementApp.Forms
{
    partial class UserListForm
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
            this.DataGridUserList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridUserList
            // 
            this.DataGridUserList.BackgroundColor = System.Drawing.Color.White;
            this.DataGridUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridUserList.Location = new System.Drawing.Point(12, 10);
            this.DataGridUserList.Name = "DataGridUserList";
            this.DataGridUserList.ReadOnly = true;
            this.DataGridUserList.Size = new System.Drawing.Size(510, 240);
            this.DataGridUserList.TabIndex = 0;
            this.DataGridUserList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridUserList_CellDoubleClick);
            this.DataGridUserList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridUserList_DataBindingComplete);
            // 
            // UserListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 261);
            this.Controls.Add(this.DataGridUserList);
            this.MaximizeBox = false;
            this.Name = "UserListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UserListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUserList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridUserList;
    }
}