
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
            this.RadioAll = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnSave = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAdd = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnShow = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnRemove = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
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
            this.groupBox1.Controls.Add(this.RadioAll);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales Return";
            // 
            // TxtQuantity
            // 
            this.TxtQuantity.Enabled = false;
            this.TxtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQuantity.Location = new System.Drawing.Point(831, 97);
            this.TxtQuantity.Name = "TxtQuantity";
            this.TxtQuantity.Size = new System.Drawing.Size(69, 26);
            this.TxtQuantity.TabIndex = 9;
            // 
            // TxtItemPrice
            // 
            this.TxtItemPrice.Enabled = false;
            this.TxtItemPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemPrice.Location = new System.Drawing.Point(694, 97);
            this.TxtItemPrice.Name = "TxtItemPrice";
            this.TxtItemPrice.Size = new System.Drawing.Size(96, 26);
            this.TxtItemPrice.TabIndex = 8;
            // 
            // TxtItemName
            // 
            this.TxtItemName.Enabled = false;
            this.TxtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemName.Location = new System.Drawing.Point(694, 60);
            this.TxtItemName.Name = "TxtItemName";
            this.TxtItemName.Size = new System.Drawing.Size(206, 26);
            this.TxtItemName.TabIndex = 7;
            // 
            // ComboItemCode
            // 
            this.ComboItemCode.Enabled = false;
            this.ComboItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboItemCode.FormattingEnabled = true;
            this.ComboItemCode.Location = new System.Drawing.Point(694, 20);
            this.ComboItemCode.Name = "ComboItemCode";
            this.ComboItemCode.Size = new System.Drawing.Size(206, 28);
            this.ComboItemCode.TabIndex = 6;
            this.ComboItemCode.SelectedValueChanged += new System.EventHandler(this.ComboItemCode_SelectedValueChanged);
            this.ComboItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboItemCode_KeyPress);
            // 
            // TxtTotalAmount
            // 
            this.TxtTotalAmount.Enabled = false;
            this.TxtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalAmount.Location = new System.Drawing.Point(381, 97);
            this.TxtTotalAmount.Name = "TxtTotalAmount";
            this.TxtTotalAmount.Size = new System.Drawing.Size(175, 26);
            this.TxtTotalAmount.TabIndex = 5;
            // 
            // TxtSalesProfit
            // 
            this.TxtSalesProfit.Enabled = false;
            this.TxtSalesProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSalesProfit.Location = new System.Drawing.Point(381, 60);
            this.TxtSalesProfit.Name = "TxtSalesProfit";
            this.TxtSalesProfit.Size = new System.Drawing.Size(175, 26);
            this.TxtSalesProfit.TabIndex = 4;
            // 
            // ComboInvoiceNo
            // 
            this.ComboInvoiceNo.Enabled = false;
            this.ComboInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboInvoiceNo.FormattingEnabled = true;
            this.ComboInvoiceNo.Location = new System.Drawing.Point(380, 20);
            this.ComboInvoiceNo.Name = "ComboInvoiceNo";
            this.ComboInvoiceNo.Size = new System.Drawing.Size(176, 28);
            this.ComboInvoiceNo.TabIndex = 3;
            this.ComboInvoiceNo.SelectedValueChanged += new System.EventHandler(this.ComboInvoiceNo_SelectedValueChanged);
            this.ComboInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboInvoiceNo_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(796, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 18);
            this.label9.TabIndex = 112;
            this.label9.Text = "Qty";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(585, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 110;
            this.label7.Text = "Item Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(586, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 109;
            this.label5.Text = "Item Code";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MaskDtEODTo
            // 
            this.MaskDtEODTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaskDtEODTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDtEODTo.Location = new System.Drawing.Point(117, 99);
            this.MaskDtEODTo.Mask = "   0000-00-00";
            this.MaskDtEODTo.Name = "MaskDtEODTo";
            this.MaskDtEODTo.Size = new System.Drawing.Size(120, 26);
            this.MaskDtEODTo.TabIndex = 2;
            this.MaskDtEODTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskDtEODTo_KeyDown);
            // 
            // MaskDtEODFrom
            // 
            this.MaskDtEODFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaskDtEODFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDtEODFrom.Location = new System.Drawing.Point(117, 60);
            this.MaskDtEODFrom.Mask = "   0000-00-00";
            this.MaskDtEODFrom.Name = "MaskDtEODFrom";
            this.MaskDtEODFrom.Size = new System.Drawing.Size(120, 26);
            this.MaskDtEODFrom.TabIndex = 1;
            this.MaskDtEODFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskDtEODFrom_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(37, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Date To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(37, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Date From";
            // 
            // RadioAll
            // 
            this.RadioAll.AutoSize = true;
            this.RadioAll.Checked = true;
            this.RadioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioAll.Location = new System.Drawing.Point(39, 26);
            this.RadioAll.Name = "RadioAll";
            this.RadioAll.Size = new System.Drawing.Size(123, 22);
            this.RadioAll.TabIndex = 0;
            this.RadioAll.TabStop = true;
            this.RadioAll.Text = "All Transaction";
            this.RadioAll.UseVisualStyleBackColor = true;
            this.RadioAll.CheckedChanged += new System.EventHandler(this.RadioAll_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(587, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 18);
            this.label10.TabIndex = 13;
            this.label10.Text = "Item Price";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(256, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 18);
            this.label11.TabIndex = 15;
            this.label11.Text = "Total Sales Profit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(265, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(265, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 18);
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
            this.groupBox3.Controls.Add(this.BtnRemove);
            this.groupBox3.Location = new System.Drawing.Point(945, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(145, 150);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSave.BorderRadius = 30;
            this.BtnSave.BorderSize = 0;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(12, 76);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(120, 32);
            this.BtnSave.TabIndex = 12;
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
            this.BtnAdd.BorderRadius = 30;
            this.BtnAdd.BorderSize = 0;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(12, 43);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 32);
            this.BtnAdd.TabIndex = 11;
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
            this.BtnShow.BorderRadius = 30;
            this.BtnShow.BorderSize = 0;
            this.BtnShow.FlatAppearance.BorderSize = 0;
            this.BtnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.Color.White;
            this.BtnShow.Location = new System.Drawing.Point(12, 10);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(120, 32);
            this.BtnShow.TabIndex = 10;
            this.BtnShow.Text = "Show";
            this.BtnShow.TextColor = System.Drawing.Color.White;
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.BackColor = System.Drawing.Color.Red;
            this.BtnRemove.BackgroundColor = System.Drawing.Color.Red;
            this.BtnRemove.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnRemove.BorderRadius = 30;
            this.BtnRemove.BorderSize = 0;
            this.BtnRemove.FlatAppearance.BorderSize = 0;
            this.BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemove.ForeColor = System.Drawing.Color.White;
            this.BtnRemove.Location = new System.Drawing.Point(12, 109);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(120, 32);
            this.BtnRemove.TabIndex = 13;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.TextColor = System.Drawing.Color.White;
            this.BtnRemove.UseVisualStyleBackColor = false;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // DateGridSalesReturnList
            // 
            this.DateGridSalesReturnList.BackgroundColor = System.Drawing.Color.White;
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
        private CustomControls.Button.CustomButton BtnRemove;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RadioAll;
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