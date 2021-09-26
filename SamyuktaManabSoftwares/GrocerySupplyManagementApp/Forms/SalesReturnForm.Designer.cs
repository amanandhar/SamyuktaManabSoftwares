
namespace GrocerySupplyManagementApp.Forms
{
    partial class SalesReturnForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtQuantity = new System.Windows.Forms.TextBox();
            this.TxtItemPrice = new System.Windows.Forms.TextBox();
            this.TxtItemName = new System.Windows.Forms.TextBox();
            this.ComboItemCode = new System.Windows.Forms.ComboBox();
            this.TxtTotalAmount = new System.Windows.Forms.TextBox();
            this.TxtSalesProfit = new System.Windows.Forms.TextBox();
            this.ComboInvoiceNo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MaskDtEODTo = new System.Windows.Forms.MaskedTextBox();
            this.MaskDtEODFrom = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RadioAllTransaction = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnSave = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAdd = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnShow = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnDelete = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.DateGridSalesReturnList = new System.Windows.Forms.DataGridView();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateGridSalesReturnList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtQuantity);
            this.groupBox1.Controls.Add(this.TxtItemPrice);
            this.groupBox1.Controls.Add(this.TxtItemName);
            this.groupBox1.Controls.Add(this.ComboItemCode);
            this.groupBox1.Controls.Add(this.TxtTotalAmount);
            this.groupBox1.Controls.Add(this.TxtSalesProfit);
            this.groupBox1.Controls.Add(this.ComboInvoiceNo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.MaskDtEODTo);
            this.groupBox1.Controls.Add(this.MaskDtEODFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RadioAllTransaction);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TxtQuantity
            // 
            this.TxtQuantity.Enabled = false;
            this.TxtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQuantity.Location = new System.Drawing.Point(831, 96);
            this.TxtQuantity.Name = "TxtQuantity";
            this.TxtQuantity.Size = new System.Drawing.Size(69, 29);
            this.TxtQuantity.TabIndex = 122;
            // 
            // TxtItemPrice
            // 
            this.TxtItemPrice.Enabled = false;
            this.TxtItemPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemPrice.Location = new System.Drawing.Point(694, 96);
            this.TxtItemPrice.Name = "TxtItemPrice";
            this.TxtItemPrice.Size = new System.Drawing.Size(96, 29);
            this.TxtItemPrice.TabIndex = 121;
            // 
            // TxtItemName
            // 
            this.TxtItemName.Enabled = false;
            this.TxtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemName.Location = new System.Drawing.Point(694, 60);
            this.TxtItemName.Name = "TxtItemName";
            this.TxtItemName.Size = new System.Drawing.Size(175, 29);
            this.TxtItemName.TabIndex = 120;
            // 
            // ComboItemCode
            // 
            this.ComboItemCode.Enabled = false;
            this.ComboItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboItemCode.FormattingEnabled = true;
            this.ComboItemCode.Location = new System.Drawing.Point(694, 17);
            this.ComboItemCode.Name = "ComboItemCode";
            this.ComboItemCode.Size = new System.Drawing.Size(176, 32);
            this.ComboItemCode.TabIndex = 119;
            this.ComboItemCode.SelectedValueChanged += new System.EventHandler(this.ComboItemCode_SelectedValueChanged);
            // 
            // TxtTotalAmount
            // 
            this.TxtTotalAmount.Enabled = false;
            this.TxtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalAmount.Location = new System.Drawing.Point(381, 97);
            this.TxtTotalAmount.Name = "TxtTotalAmount";
            this.TxtTotalAmount.Size = new System.Drawing.Size(175, 29);
            this.TxtTotalAmount.TabIndex = 118;
            // 
            // TxtSalesProfit
            // 
            this.TxtSalesProfit.Enabled = false;
            this.TxtSalesProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSalesProfit.Location = new System.Drawing.Point(381, 59);
            this.TxtSalesProfit.Name = "TxtSalesProfit";
            this.TxtSalesProfit.Size = new System.Drawing.Size(175, 29);
            this.TxtSalesProfit.TabIndex = 117;
            // 
            // ComboInvoiceNo
            // 
            this.ComboInvoiceNo.Enabled = false;
            this.ComboInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboInvoiceNo.FormattingEnabled = true;
            this.ComboInvoiceNo.Location = new System.Drawing.Point(380, 17);
            this.ComboInvoiceNo.Name = "ComboInvoiceNo";
            this.ComboInvoiceNo.Size = new System.Drawing.Size(176, 32);
            this.ComboInvoiceNo.TabIndex = 115;
            this.ComboInvoiceNo.SelectedValueChanged += new System.EventHandler(this.ComboInvoiceNo_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(792, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 20);
            this.label9.TabIndex = 112;
            this.label9.Text = "Qty";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(585, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 110;
            this.label7.Text = "Item Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(586, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 109;
            this.label5.Text = "Item Code";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MaskDtEODTo
            // 
            this.MaskDtEODTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaskDtEODTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDtEODTo.Location = new System.Drawing.Point(117, 96);
            this.MaskDtEODTo.Mask = "   0000-00-00";
            this.MaskDtEODTo.Name = "MaskDtEODTo";
            this.MaskDtEODTo.Size = new System.Drawing.Size(120, 26);
            this.MaskDtEODTo.TabIndex = 105;
            // 
            // MaskDtEODFrom
            // 
            this.MaskDtEODFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaskDtEODFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDtEODFrom.Location = new System.Drawing.Point(117, 56);
            this.MaskDtEODFrom.Mask = "   0000-00-00";
            this.MaskDtEODFrom.Name = "MaskDtEODFrom";
            this.MaskDtEODFrom.Size = new System.Drawing.Size(120, 26);
            this.MaskDtEODFrom.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(28, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Date To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(28, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Date From";
            // 
            // RadioAllTransaction
            // 
            this.RadioAllTransaction.AutoSize = true;
            this.RadioAllTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAllTransaction.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioAllTransaction.Location = new System.Drawing.Point(34, 21);
            this.RadioAllTransaction.Name = "RadioAllTransaction";
            this.RadioAllTransaction.Size = new System.Drawing.Size(131, 24);
            this.RadioAllTransaction.TabIndex = 20;
            this.RadioAllTransaction.TabStop = true;
            this.RadioAllTransaction.Text = "All Transaction";
            this.RadioAllTransaction.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(587, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Item Price";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(265, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "Sales Profit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(265, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(265, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Invoice No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnSave);
            this.groupBox3.Controls.Add(this.BtnAdd);
            this.groupBox3.Controls.Add(this.BtnShow);
            this.groupBox3.Controls.Add(this.BtnDelete);
            this.groupBox3.Location = new System.Drawing.Point(945, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(145, 158);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSave.BorderRadius = 35;
            this.BtnSave.BorderSize = 0;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(12, 82);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(120, 35);
            this.BtnSave.TabIndex = 25;
            this.BtnSave.Text = "Save";
            this.BtnSave.TextColor = System.Drawing.Color.White;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAdd.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAdd.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAdd.BorderRadius = 35;
            this.BtnAdd.BorderSize = 0;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(12, 46);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 35);
            this.BtnAdd.TabIndex = 19;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.TextColor = System.Drawing.Color.White;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
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
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.Color.White;
            this.BtnShow.Location = new System.Drawing.Point(12, 10);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(120, 35);
            this.BtnShow.TabIndex = 24;
            this.BtnShow.Text = "Show";
            this.BtnShow.TextColor = System.Drawing.Color.White;
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.Red;
            this.BtnDelete.BackgroundColor = System.Drawing.Color.Red;
            this.BtnDelete.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnDelete.BorderRadius = 35;
            this.BtnDelete.BorderSize = 0;
            this.BtnDelete.FlatAppearance.BorderSize = 0;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(12, 118);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(120, 35);
            this.BtnDelete.TabIndex = 23;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.TextColor = System.Drawing.Color.White;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // DateGridSalesReturnList
            // 
            this.DateGridSalesReturnList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DateGridSalesReturnList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DateGridSalesReturnList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateGridSalesReturnList.Location = new System.Drawing.Point(15, 210);
            this.DateGridSalesReturnList.Name = "DateGridSalesReturnList";
            this.DateGridSalesReturnList.Size = new System.Drawing.Size(1075, 380);
            this.DateGridSalesReturnList.TabIndex = 21;
            this.DateGridSalesReturnList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DateGridSalesReturnList_DataBindingComplete);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(-1, -1);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(1103, 44);
            this.textBox4.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DodgerBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Cyan;
            this.label8.Location = new System.Drawing.Point(387, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(358, 31);
            this.label8.TabIndex = 23;
            this.label8.Text = "Sales Return Management";
            // 
            // SalesReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1088, 597);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.DateGridSalesReturnList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(750, 313);
            this.Name = "SalesReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SalesReturnForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DateGridSalesReturnList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DateGridSalesReturnList;
        private CustomControls.Button.CustomButton BtnAdd;
        private CustomControls.Button.CustomButton BtnShow;
        private CustomControls.Button.CustomButton BtnDelete;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RadioAllTransaction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox MaskDtEODTo;
        private System.Windows.Forms.MaskedTextBox MaskDtEODFrom;
        private CustomControls.Button.CustomButton BtnSave;
        private System.Windows.Forms.ComboBox ComboInvoiceNo;
        private System.Windows.Forms.TextBox TxtQuantity;
        private System.Windows.Forms.TextBox TxtItemPrice;
        private System.Windows.Forms.TextBox TxtItemName;
        private System.Windows.Forms.ComboBox ComboItemCode;
        private System.Windows.Forms.TextBox TxtTotalAmount;
        private System.Windows.Forms.TextBox TxtSalesProfit;
    }
}