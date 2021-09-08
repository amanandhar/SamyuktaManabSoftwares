
namespace GrocerySupplyManagementApp.Forms
{
    partial class StockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboItemCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.BtnShow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtTotalValue = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtTotalStock = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtPurchase = new System.Windows.Forms.TextBox();
            this.TxtSales = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MaskEndOfDayTo = new System.Windows.Forms.MaskedTextBox();
            this.MaskEndOfDayFrom = new System.Windows.Forms.MaskedTextBox();
            this.DataGridStockList = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridStockList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(684, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item Code";
            // 
            // ComboItemCode
            // 
            this.ComboItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboItemCode.FormattingEnabled = true;
            this.ComboItemCode.Location = new System.Drawing.Point(770, 19);
            this.ComboItemCode.Name = "ComboItemCode";
            this.ComboItemCode.Size = new System.Drawing.Size(108, 26);
            this.ComboItemCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(480, 54);
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
            this.label3.Location = new System.Drawing.Point(177, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(10, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = " From";
            // 
            // TxtStock
            // 
            this.TxtStock.BackColor = System.Drawing.Color.White;
            this.TxtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStock.Location = new System.Drawing.Point(527, 50);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.ReadOnly = true;
            this.TxtStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtStock.Size = new System.Drawing.Size(130, 27);
            this.TxtStock.TabIndex = 9;
            // 
            // BtnShow
            // 
            this.BtnShow.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnShow.BackgroundImage")));
            this.BtnShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnShow.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.BtnShow.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnShow.Location = new System.Drawing.Point(12, 15);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(98, 38);
            this.BtnShow.TabIndex = 12;
            this.BtnShow.Text = " Show ";
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnShow);
            this.groupBox1.Location = new System.Drawing.Point(908, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 80);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtTotalValue);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TxtTotalStock);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TxtValue);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TxtPurchase);
            this.groupBox2.Controls.Add(this.TxtSales);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.MaskEndOfDayTo);
            this.groupBox2.Controls.Add(this.MaskEndOfDayFrom);
            this.groupBox2.Controls.Add(this.TxtStock);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ComboItemCode);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(889, 84);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // TxtTotalValue
            // 
            this.TxtTotalValue.BackColor = System.Drawing.Color.White;
            this.TxtTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalValue.Location = new System.Drawing.Point(556, 17);
            this.TxtTotalValue.Name = "TxtTotalValue";
            this.TxtTotalValue.ReadOnly = true;
            this.TxtTotalValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalValue.Size = new System.Drawing.Size(120, 27);
            this.TxtTotalValue.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(320, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 18);
            this.label10.TabIndex = 27;
            this.label10.Text = "Stock";
            // 
            // TxtTotalStock
            // 
            this.TxtTotalStock.BackColor = System.Drawing.Color.White;
            this.TxtTotalStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalStock.Location = new System.Drawing.Point(372, 17);
            this.TxtTotalStock.Name = "TxtTotalStock";
            this.TxtTotalStock.ReadOnly = true;
            this.TxtTotalStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalStock.Size = new System.Drawing.Size(130, 27);
            this.TxtTotalStock.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(509, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "Value";
            // 
            // TxtValue
            // 
            this.TxtValue.BackColor = System.Drawing.Color.White;
            this.TxtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtValue.Location = new System.Drawing.Point(748, 49);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.ReadOnly = true;
            this.TxtValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtValue.Size = new System.Drawing.Size(130, 27);
            this.TxtValue.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(669, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Value";
            // 
            // TxtPurchase
            // 
            this.TxtPurchase.BackColor = System.Drawing.Color.White;
            this.TxtPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPurchase.Location = new System.Drawing.Point(122, 50);
            this.TxtPurchase.Name = "TxtPurchase";
            this.TxtPurchase.ReadOnly = true;
            this.TxtPurchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtPurchase.Size = new System.Drawing.Size(130, 26);
            this.TxtPurchase.TabIndex = 22;
            // 
            // TxtSales
            // 
            this.TxtSales.BackColor = System.Drawing.Color.White;
            this.TxtSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSales.Location = new System.Drawing.Point(337, 50);
            this.TxtSales.Name = "TxtSales";
            this.TxtSales.ReadOnly = true;
            this.TxtSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtSales.Size = new System.Drawing.Size(130, 26);
            this.TxtSales.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(255, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "Total Sales";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(12, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "Total Purchase";
            // 
            // MaskEndOfDayTo
            // 
            this.MaskEndOfDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayTo.Location = new System.Drawing.Point(202, 19);
            this.MaskEndOfDayTo.Mask = "0000-00-00";
            this.MaskEndOfDayTo.Name = "MaskEndOfDayTo";
            this.MaskEndOfDayTo.Size = new System.Drawing.Size(112, 26);
            this.MaskEndOfDayTo.TabIndex = 17;
            // 
            // MaskEndOfDayFrom
            // 
            this.MaskEndOfDayFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayFrom.Location = new System.Drawing.Point(60, 18);
            this.MaskEndOfDayFrom.Mask = "0000-00-00";
            this.MaskEndOfDayFrom.Name = "MaskEndOfDayFrom";
            this.MaskEndOfDayFrom.Size = new System.Drawing.Size(112, 26);
            this.MaskEndOfDayFrom.TabIndex = 16;
            this.MaskEndOfDayFrom.ValidatingType = typeof(System.DateTime);
            // 
            // DataGridStockList
            // 
            this.DataGridStockList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DataGridStockList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridStockList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridStockList.DefaultCellStyle = dataGridViewCellStyle8;
            this.DataGridStockList.Location = new System.Drawing.Point(12, 133);
            this.DataGridStockList.Name = "DataGridStockList";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridStockList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DataGridStockList.Size = new System.Drawing.Size(1018, 399);
            this.DataGridStockList.TabIndex = 17;
            this.DataGridStockList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridStockList_DataBindingComplete);
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.BackgroundImage")));
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(-1, -1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1044, 45);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Cyan;
            this.label5.Location = new System.Drawing.Point(348, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(393, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "Stock Summary Management";
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.DataGridStockList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.StockForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridStockList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboItemCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DataGridStockList;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayTo;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtPurchase;
        private System.Windows.Forms.TextBox TxtSales;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtTotalValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtTotalStock;
        private System.Windows.Forms.Label label9;
    }
}