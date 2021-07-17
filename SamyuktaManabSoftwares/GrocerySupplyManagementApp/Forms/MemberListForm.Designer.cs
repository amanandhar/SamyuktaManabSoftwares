
namespace GrocerySupplyManagementApp.Forms
{
    partial class MemberListForm
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
            this.DataGridMemberList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMemberList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridMemberList
            // 
            this.DataGridMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridMemberList.Location = new System.Drawing.Point(12, 12);
            this.DataGridMemberList.Name = "DataGridMemberList";
            this.DataGridMemberList.Size = new System.Drawing.Size(495, 426);
            this.DataGridMemberList.TabIndex = 0;
            this.DataGridMemberList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridMemberList_CellDoubleClick);
            this.DataGridMemberList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridMemberList_DataBindingComplete);
            // 
            // MemberListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.DataGridMemberList);
            this.Name = "MemberListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MemberListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMemberList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridMemberList;
    }
}