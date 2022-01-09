
namespace GrocerySupplyManagementApp.Forms
{
    partial class PricedItemListToPrintForm
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
            this.PanelMain = new System.Windows.Forms.Panel();
            this.BtnExport = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnCancel = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.AutoScroll = true;
            this.PanelMain.BackColor = System.Drawing.Color.White;
            this.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMain.Location = new System.Drawing.Point(12, 12);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(510, 250);
            this.PanelMain.TabIndex = 0;
            // 
            // BtnExport
            // 
            this.BtnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExport.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnExport.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnExport.BorderRadius = 35;
            this.BtnExport.BorderSize = 0;
            this.BtnExport.FlatAppearance.BorderSize = 0;
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.Location = new System.Drawing.Point(307, 268);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(120, 35);
            this.BtnExport.TabIndex = 16;
            this.BtnExport.Text = "Export";
            this.BtnExport.TextColor = System.Drawing.Color.White;
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCancel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnCancel.BorderRadius = 35;
            this.BtnCancel.BorderSize = 0;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(123, 268);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(120, 35);
            this.BtnCancel.TabIndex = 25;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.TextColor = System.Drawing.Color.White;
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "docx";
            this.SaveFileDialog.FileName = "PriceItemReport";
            this.SaveFileDialog.Filter = "docx files (*.docx)|*.docx";
            this.SaveFileDialog.InitialDirectory = "C:\\";
            // 
            // PricedItemListToPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.PanelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PricedItemListToPrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PricedItemListToPrintForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMain;
        private CustomControls.Button.CustomButton BtnExport;
        private CustomControls.Button.CustomButton BtnCancel;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
    }
}