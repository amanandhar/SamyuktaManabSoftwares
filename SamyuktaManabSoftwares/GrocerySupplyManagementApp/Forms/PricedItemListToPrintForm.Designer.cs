
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PricedItemListToPrintForm));
            this.PanelBody = new System.Windows.Forms.Panel();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.PicBoxLoading = new System.Windows.Forms.PictureBox();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.BtnCancel = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnExport = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelBody
            // 
            this.PanelBody.AutoScroll = true;
            this.PanelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PanelBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelBody.Location = new System.Drawing.Point(12, 69);
            this.PanelBody.Name = "PanelBody";
            this.PanelBody.Size = new System.Drawing.Size(510, 300);
            this.PanelBody.TabIndex = 0;
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "docx";
            this.SaveFileDialog.FileName = "PriceItemReport";
            this.SaveFileDialog.Filter = "docx files (*.docx)|*.docx";
            this.SaveFileDialog.InitialDirectory = "C:\\";
            // 
            // PanelHeader
            // 
            this.PanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PanelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelHeader.Location = new System.Drawing.Point(12, 13);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(510, 54);
            this.PanelHeader.TabIndex = 26;
            // 
            // PicBoxLoading
            // 
            this.PicBoxLoading.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxLoading.Image")));
            this.PicBoxLoading.Location = new System.Drawing.Point(86, 415);
            this.PicBoxLoading.Name = "PicBoxLoading";
            this.PicBoxLoading.Size = new System.Drawing.Size(53, 31);
            this.PicBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicBoxLoading.TabIndex = 27;
            this.PicBoxLoading.TabStop = false;
            this.PicBoxLoading.Visible = false;
            // 
            // BackgroundWorker
            // 
            this.BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // PanelFooter
            // 
            this.PanelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PanelFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelFooter.Location = new System.Drawing.Point(12, 371);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(510, 32);
            this.PanelFooter.TabIndex = 28;
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
            this.BtnCancel.Location = new System.Drawing.Point(146, 414);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(120, 35);
            this.BtnCancel.TabIndex = 25;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.TextColor = System.Drawing.Color.White;
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
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
            this.BtnExport.Location = new System.Drawing.Point(272, 414);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(120, 35);
            this.BtnExport.TabIndex = 16;
            this.BtnExport.Text = "Export";
            this.BtnExport.TextColor = System.Drawing.Color.White;
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // PricedItemListToPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.PanelFooter);
            this.Controls.Add(this.PicBoxLoading);
            this.Controls.Add(this.PanelHeader);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.PanelBody);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PricedItemListToPrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PricedItemListToPrintForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelBody;
        private CustomControls.Button.CustomButton BtnExport;
        private CustomControls.Button.CustomButton BtnCancel;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.PictureBox PicBoxLoading;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.Panel PanelFooter;
    }
}