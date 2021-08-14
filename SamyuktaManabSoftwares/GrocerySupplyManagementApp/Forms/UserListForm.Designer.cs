
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
            this.label2 = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridUserList
            // 
            this.DataGridUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridUserList.Location = new System.Drawing.Point(12, 49);
            this.DataGridUserList.Name = "DataGridUserList";
            this.DataGridUserList.Size = new System.Drawing.Size(510, 400);
            this.DataGridUserList.TabIndex = 0;
            this.DataGridUserList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridUserList_CellDoubleClick);
            this.DataGridUserList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridUserList_DataBindingComplete);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search By Username:";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearch.Location = new System.Drawing.Point(182, 14);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(100, 29);
            this.TxtSearch.TabIndex = 4;
            // 
            // UserListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataGridUserList);
            this.Name = "UserListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UserListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUserList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridUserList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtSearch;
    }
}