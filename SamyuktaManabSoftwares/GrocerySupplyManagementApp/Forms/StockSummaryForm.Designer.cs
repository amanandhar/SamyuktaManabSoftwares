
namespace GrocerySupplyManagementApp.Forms
{
    partial class StockSummaryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboItemCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtBoxDeducted = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtBoxAdded = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnShow = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.MaskDtEODTo = new System.Windows.Forms.MaskedTextBox();
            this.TxtTotalValue = new System.Windows.Forms.TextBox();
            this.MaskDtEODFrom = new System.Windows.Forms.MaskedTextBox();
            this.TxtTotalStock = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtSales = new System.Windows.Forms.TextBox();
            this.TxtPurchase = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DataGridStockList = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(785, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item Code";
            // 
            // ComboItemCode
            // 
            this.ComboItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboItemCode.FormattingEnabled = true;
            this.ComboItemCode.Location = new System.Drawing.Point(865, 58);
            this.ComboItemCode.Name = "ComboItemCode";
            this.ComboItemCode.Size = new System.Drawing.Size(92, 26);
            this.ComboItemCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(735, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(197, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(4, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date From";
            // 
            // TxtStock
            // 
            this.TxtStock.BackColor = System.Drawing.Color.White;
            this.TxtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStock.Location = new System.Drawing.Point(783, 20);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.ReadOnly = true;
            this.TxtStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtStock.Size = new System.Drawing.Size(115, 26);
            this.TxtStock.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtBoxDeducted);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.TxtBoxAdded);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.BtnShow);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ComboItemCode);
            this.groupBox2.Controls.Add(this.TxtValue);
            this.groupBox2.Controls.Add(this.MaskDtEODTo);
            this.groupBox2.Controls.Add(this.TxtTotalValue);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.MaskDtEODFrom);
            this.groupBox2.Controls.Add(this.TxtTotalStock);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TxtStock);
            this.groupBox2.Controls.Add(this.TxtSales);
            this.groupBox2.Controls.Add(this.TxtPurchase);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1078, 95);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // TxtBoxDeducted
            // 
            this.TxtBoxDeducted.BackColor = System.Drawing.Color.White;
            this.TxtBoxDeducted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxDeducted.Location = new System.Drawing.Point(617, 21);
            this.TxtBoxDeducted.Name = "TxtBoxDeducted";
            this.TxtBoxDeducted.ReadOnly = true;
            this.TxtBoxDeducted.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBoxDeducted.Size = new System.Drawing.Size(115, 26);
            this.TxtBoxDeducted.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(540, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 18);
            this.label12.TabIndex = 32;
            this.label12.Text = "Deducted";
            // 
            // TxtBoxAdded
            // 
            this.TxtBoxAdded.BackColor = System.Drawing.Color.White;
            this.TxtBoxAdded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxAdded.Location = new System.Drawing.Point(421, 21);
            this.TxtBoxAdded.Name = "TxtBoxAdded";
            this.TxtBoxAdded.ReadOnly = true;
            this.TxtBoxAdded.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBoxAdded.Size = new System.Drawing.Size(115, 26);
            this.TxtBoxAdded.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(367, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 18);
            this.label11.TabIndex = 30;
            this.label11.Text = "Added";
            // 
            // BtnShow
            // 
            this.BtnShow.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnShow.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnShow.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnShow.BorderRadius = 35;
            this.BtnShow.BorderSize = 0;
            this.BtnShow.FlatAppearance.BorderSize = 0;
            this.BtnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.Color.White;
            this.BtnShow.Location = new System.Drawing.Point(963, 52);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(106, 35);
            this.BtnShow.TabIndex = 29;
            this.BtnShow.Text = "Show";
            this.BtnShow.TextColor = System.Drawing.Color.White;
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(902, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Value";
            // 
            // TxtValue
            // 
            this.TxtValue.BackColor = System.Drawing.Color.White;
            this.TxtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtValue.Location = new System.Drawing.Point(949, 20);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.ReadOnly = true;
            this.TxtValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtValue.Size = new System.Drawing.Size(115, 26);
            this.TxtValue.TabIndex = 24;
            // 
            // MaskDtEODTo
            // 
            this.MaskDtEODTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDtEODTo.Location = new System.Drawing.Point(262, 56);
            this.MaskDtEODTo.Mask = "0000-00-00";
            this.MaskDtEODTo.Name = "MaskDtEODTo";
            this.MaskDtEODTo.Size = new System.Drawing.Size(100, 26);
            this.MaskDtEODTo.TabIndex = 17;
            this.MaskDtEODTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtTotalValue
            // 
            this.TxtTotalValue.BackColor = System.Drawing.Color.White;
            this.TxtTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalValue.Location = new System.Drawing.Point(666, 58);
            this.TxtTotalValue.Name = "TxtTotalValue";
            this.TxtTotalValue.ReadOnly = true;
            this.TxtTotalValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalValue.Size = new System.Drawing.Size(115, 26);
            this.TxtTotalValue.TabIndex = 28;
            // 
            // MaskDtEODFrom
            // 
            this.MaskDtEODFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDtEODFrom.Location = new System.Drawing.Point(85, 55);
            this.MaskDtEODFrom.Mask = "0000-00-00";
            this.MaskDtEODFrom.Name = "MaskDtEODFrom";
            this.MaskDtEODFrom.Size = new System.Drawing.Size(100, 26);
            this.MaskDtEODFrom.TabIndex = 16;
            this.MaskDtEODFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaskDtEODFrom.ValidatingType = typeof(System.DateTime);
            // 
            // TxtTotalStock
            // 
            this.TxtTotalStock.BackColor = System.Drawing.Color.White;
            this.TxtTotalStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalStock.Location = new System.Drawing.Point(458, 58);
            this.TxtTotalStock.Name = "TxtTotalStock";
            this.TxtTotalStock.ReadOnly = true;
            this.TxtTotalStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalStock.Size = new System.Drawing.Size(115, 26);
            this.TxtTotalStock.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(578, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "Open Value";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(367, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 18);
            this.label10.TabIndex = 27;
            this.label10.Text = "Open Stock";
            // 
            // TxtSales
            // 
            this.TxtSales.BackColor = System.Drawing.Color.White;
            this.TxtSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSales.Location = new System.Drawing.Point(247, 20);
            this.TxtSales.Name = "TxtSales";
            this.TxtSales.ReadOnly = true;
            this.TxtSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtSales.Size = new System.Drawing.Size(115, 26);
            this.TxtSales.TabIndex = 21;
            // 
            // TxtPurchase
            // 
            this.TxtPurchase.BackColor = System.Drawing.Color.White;
            this.TxtPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPurchase.Location = new System.Drawing.Point(80, 20);
            this.TxtPurchase.Name = "TxtPurchase";
            this.TxtPurchase.ReadOnly = true;
            this.TxtPurchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtPurchase.Size = new System.Drawing.Size(115, 26);
            this.TxtPurchase.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(199, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "Sales";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(5, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "Purchase";
            // 
            // DataGridStockList
            // 
            this.DataGridStockList.BackgroundColor = System.Drawing.Color.White;
            this.DataGridStockList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridStockList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridStockList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridStockList.Location = new System.Drawing.Point(13, 145);
            this.DataGridStockList.Name = "DataGridStockList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridStockList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridStockList.Size = new System.Drawing.Size(1079, 440);
            this.DataGridStockList.TabIndex = 17;
            this.DataGridStockList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridStockList_DataBindingComplete);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1103, 44);
            this.textBox1.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DodgerBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Cyan;
            this.label5.Location = new System.Drawing.Point(365, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(393, 31);
            this.label5.TabIndex = 19;
            this.label5.Text = "Stock Summary Management";
            // 
            // StockSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1088, 597);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DataGridStockList);
            this.Controls.Add(this.groupBox2);
            this.Location = new System.Drawing.Point(569, 240);
            this.Name = "StockSummaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.StockForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridStockList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboItemCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DataGridStockList;
        private System.Windows.Forms.MaskedTextBox MaskDtEODTo;
        private System.Windows.Forms.MaskedTextBox MaskDtEODFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtPurchase;
        private System.Windows.Forms.TextBox TxtSales;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtTotalValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtTotalStock;
        private System.Windows.Forms.Label label9;
        private CustomControls.Button.CustomButton BtnShow;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBoxAdded;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtBoxDeducted;
        private System.Windows.Forms.Label label12;
    }
}