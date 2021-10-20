﻿
namespace GrocerySupplyManagementApp.Forms
{
    partial class DailyTransactionForm
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
            this.GroupFilter = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboBankTransfer = new System.Windows.Forms.ComboBox();
            this.RadioBankTransfer = new System.Windows.Forms.RadioButton();
            this.ComboPurchase = new System.Windows.Forms.ComboBox();
            this.RadioInvoiceNo = new System.Windows.Forms.RadioButton();
            this.ComboExpensePayment = new System.Windows.Forms.ComboBox();
            this.RadioExpensePayment = new System.Windows.Forms.RadioButton();
            this.RadioAll = new System.Windows.Forms.RadioButton();
            this.RadioPurchasePayment = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.RadioSales = new System.Windows.Forms.RadioButton();
            this.ComboInvoiceNo = new System.Windows.Forms.ComboBox();
            this.ComboSales = new System.Windows.Forms.ComboBox();
            this.RadioReceipt = new System.Windows.Forms.RadioButton();
            this.MaskDtEOD = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RadioPurchase = new System.Windows.Forms.RadioButton();
            this.ComboPurchasePayment = new System.Windows.Forms.ComboBox();
            this.ComboReceipt = new System.Windows.Forms.ComboBox();
            this.ComboUser = new System.Windows.Forms.ComboBox();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnShow = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.DataGridTransactionList = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupFilter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTransactionList)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupFilter
            // 
            this.GroupFilter.Controls.Add(this.label4);
            this.GroupFilter.Controls.Add(this.ComboBankTransfer);
            this.GroupFilter.Controls.Add(this.RadioBankTransfer);
            this.GroupFilter.Controls.Add(this.ComboPurchase);
            this.GroupFilter.Controls.Add(this.RadioInvoiceNo);
            this.GroupFilter.Controls.Add(this.ComboExpensePayment);
            this.GroupFilter.Controls.Add(this.RadioExpensePayment);
            this.GroupFilter.Controls.Add(this.RadioAll);
            this.GroupFilter.Controls.Add(this.RadioPurchasePayment);
            this.GroupFilter.Controls.Add(this.label2);
            this.GroupFilter.Controls.Add(this.RadioSales);
            this.GroupFilter.Controls.Add(this.ComboInvoiceNo);
            this.GroupFilter.Controls.Add(this.ComboSales);
            this.GroupFilter.Controls.Add(this.RadioReceipt);
            this.GroupFilter.Controls.Add(this.MaskDtEOD);
            this.GroupFilter.Controls.Add(this.label3);
            this.GroupFilter.Controls.Add(this.RadioPurchase);
            this.GroupFilter.Controls.Add(this.ComboPurchasePayment);
            this.GroupFilter.Controls.Add(this.ComboReceipt);
            this.GroupFilter.Controls.Add(this.ComboUser);
            this.GroupFilter.Controls.Add(this.TxtTotal);
            this.GroupFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupFilter.ForeColor = System.Drawing.Color.Red;
            this.GroupFilter.Location = new System.Drawing.Point(15, 43);
            this.GroupFilter.Name = "GroupFilter";
            this.GroupFilter.Size = new System.Drawing.Size(915, 125);
            this.GroupFilter.TabIndex = 5;
            this.GroupFilter.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(708, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 18);
            this.label4.TabIndex = 47;
            this.label4.Text = "User";
            // 
            // ComboBankTransfer
            // 
            this.ComboBankTransfer.Enabled = false;
            this.ComboBankTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBankTransfer.FormattingEnabled = true;
            this.ComboBankTransfer.Location = new System.Drawing.Point(482, 66);
            this.ComboBankTransfer.Name = "ComboBankTransfer";
            this.ComboBankTransfer.Size = new System.Drawing.Size(125, 24);
            this.ComboBankTransfer.TabIndex = 11;
            // 
            // RadioBankTransfer
            // 
            this.RadioBankTransfer.AutoSize = true;
            this.RadioBankTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBankTransfer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioBankTransfer.Location = new System.Drawing.Point(310, 69);
            this.RadioBankTransfer.Name = "RadioBankTransfer";
            this.RadioBankTransfer.Size = new System.Drawing.Size(119, 22);
            this.RadioBankTransfer.TabIndex = 10;
            this.RadioBankTransfer.Text = "Bank Transfer";
            this.RadioBankTransfer.UseVisualStyleBackColor = true;
            this.RadioBankTransfer.CheckedChanged += new System.EventHandler(this.RadioBankTransfer_CheckedChanged);
            // 
            // ComboPurchase
            // 
            this.ComboPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPurchase.FormattingEnabled = true;
            this.ComboPurchase.Location = new System.Drawing.Point(142, 68);
            this.ComboPurchase.Name = "ComboPurchase";
            this.ComboPurchase.Size = new System.Drawing.Size(125, 24);
            this.ComboPurchase.TabIndex = 3;
            // 
            // RadioInvoiceNo
            // 
            this.RadioInvoiceNo.AutoSize = true;
            this.RadioInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioInvoiceNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioInvoiceNo.Location = new System.Drawing.Point(647, 42);
            this.RadioInvoiceNo.Name = "RadioInvoiceNo";
            this.RadioInvoiceNo.Size = new System.Drawing.Size(117, 22);
            this.RadioInvoiceNo.TabIndex = 14;
            this.RadioInvoiceNo.Text = "By Invoice No";
            this.RadioInvoiceNo.UseVisualStyleBackColor = true;
            this.RadioInvoiceNo.CheckedChanged += new System.EventHandler(this.RadioInvoiceNo_CheckedChanged);
            // 
            // ComboExpensePayment
            // 
            this.ComboExpensePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboExpensePayment.FormattingEnabled = true;
            this.ComboExpensePayment.Location = new System.Drawing.Point(482, 40);
            this.ComboExpensePayment.Name = "ComboExpensePayment";
            this.ComboExpensePayment.Size = new System.Drawing.Size(125, 24);
            this.ComboExpensePayment.TabIndex = 9;
            // 
            // RadioExpensePayment
            // 
            this.RadioExpensePayment.AutoSize = true;
            this.RadioExpensePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioExpensePayment.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioExpensePayment.Location = new System.Drawing.Point(310, 42);
            this.RadioExpensePayment.Name = "RadioExpensePayment";
            this.RadioExpensePayment.Size = new System.Drawing.Size(166, 22);
            this.RadioExpensePayment.TabIndex = 8;
            this.RadioExpensePayment.Text = "By Expense Payment";
            this.RadioExpensePayment.UseVisualStyleBackColor = true;
            this.RadioExpensePayment.CheckedChanged += new System.EventHandler(this.RadioExpense_CheckedChanged);
            // 
            // RadioAll
            // 
            this.RadioAll.AutoSize = true;
            this.RadioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioAll.Location = new System.Drawing.Point(37, 15);
            this.RadioAll.Name = "RadioAll";
            this.RadioAll.Size = new System.Drawing.Size(49, 22);
            this.RadioAll.TabIndex = 0;
            this.RadioAll.Text = "All  ";
            this.RadioAll.UseVisualStyleBackColor = true;
            this.RadioAll.CheckedChanged += new System.EventHandler(this.RadioAll_CheckedChanged);
            // 
            // RadioPurchasePayment
            // 
            this.RadioPurchasePayment.AutoSize = true;
            this.RadioPurchasePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioPurchasePayment.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioPurchasePayment.Location = new System.Drawing.Point(310, 15);
            this.RadioPurchasePayment.Name = "RadioPurchasePayment";
            this.RadioPurchasePayment.Size = new System.Drawing.Size(172, 22);
            this.RadioPurchasePayment.TabIndex = 6;
            this.RadioPurchasePayment.Text = "By Purchase Payment";
            this.RadioPurchasePayment.UseVisualStyleBackColor = true;
            this.RadioPurchasePayment.CheckedChanged += new System.EventHandler(this.RadioPayment_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(91, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date ";
            // 
            // RadioSales
            // 
            this.RadioSales.AutoSize = true;
            this.RadioSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioSales.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioSales.Location = new System.Drawing.Point(36, 95);
            this.RadioSales.Name = "RadioSales";
            this.RadioSales.Size = new System.Drawing.Size(84, 22);
            this.RadioSales.TabIndex = 4;
            this.RadioSales.Text = "By Sales";
            this.RadioSales.UseVisualStyleBackColor = true;
            this.RadioSales.CheckedChanged += new System.EventHandler(this.RadioSales_CheckedChanged);
            // 
            // ComboInvoiceNo
            // 
            this.ComboInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboInvoiceNo.FormattingEnabled = true;
            this.ComboInvoiceNo.Location = new System.Drawing.Point(765, 40);
            this.ComboInvoiceNo.Name = "ComboInvoiceNo";
            this.ComboInvoiceNo.Size = new System.Drawing.Size(125, 24);
            this.ComboInvoiceNo.TabIndex = 15;
            // 
            // ComboSales
            // 
            this.ComboSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboSales.FormattingEnabled = true;
            this.ComboSales.Location = new System.Drawing.Point(142, 94);
            this.ComboSales.Name = "ComboSales";
            this.ComboSales.Size = new System.Drawing.Size(125, 24);
            this.ComboSales.TabIndex = 5;
            // 
            // RadioReceipt
            // 
            this.RadioReceipt.AutoSize = true;
            this.RadioReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioReceipt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioReceipt.Location = new System.Drawing.Point(310, 95);
            this.RadioReceipt.Name = "RadioReceipt";
            this.RadioReceipt.Size = new System.Drawing.Size(101, 22);
            this.RadioReceipt.TabIndex = 12;
            this.RadioReceipt.Text = "By Receipt ";
            this.RadioReceipt.UseVisualStyleBackColor = true;
            this.RadioReceipt.CheckedChanged += new System.EventHandler(this.RadioReceipt_CheckedChanged);
            // 
            // MaskDtEOD
            // 
            this.MaskDtEOD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDtEOD.Location = new System.Drawing.Point(142, 14);
            this.MaskDtEOD.Mask = "   0000-00-00";
            this.MaskDtEOD.Name = "MaskDtEOD";
            this.MaskDtEOD.Size = new System.Drawing.Size(125, 26);
            this.MaskDtEOD.TabIndex = 1;
            this.MaskDtEOD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskDtEOD_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(646, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total Amount";
            // 
            // RadioPurchase
            // 
            this.RadioPurchase.AutoSize = true;
            this.RadioPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioPurchase.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioPurchase.Location = new System.Drawing.Point(36, 68);
            this.RadioPurchase.Name = "RadioPurchase";
            this.RadioPurchase.Size = new System.Drawing.Size(110, 22);
            this.RadioPurchase.TabIndex = 2;
            this.RadioPurchase.Text = "By Purchase";
            this.RadioPurchase.UseVisualStyleBackColor = true;
            this.RadioPurchase.CheckedChanged += new System.EventHandler(this.RadioPurchase_CheckedChanged);
            // 
            // ComboPurchasePayment
            // 
            this.ComboPurchasePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPurchasePayment.FormattingEnabled = true;
            this.ComboPurchasePayment.Location = new System.Drawing.Point(482, 14);
            this.ComboPurchasePayment.Name = "ComboPurchasePayment";
            this.ComboPurchasePayment.Size = new System.Drawing.Size(125, 24);
            this.ComboPurchasePayment.TabIndex = 7;
            // 
            // ComboReceipt
            // 
            this.ComboReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboReceipt.FormattingEnabled = true;
            this.ComboReceipt.Items.AddRange(new object[] {
            "Cash",
            "Cheque",
            "Share Cheque"});
            this.ComboReceipt.Location = new System.Drawing.Point(482, 92);
            this.ComboReceipt.Name = "ComboReceipt";
            this.ComboReceipt.Size = new System.Drawing.Size(125, 24);
            this.ComboReceipt.TabIndex = 13;
            // 
            // ComboUser
            // 
            this.ComboUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboUser.FormattingEnabled = true;
            this.ComboUser.Location = new System.Drawing.Point(765, 66);
            this.ComboUser.Name = "ComboUser";
            this.ComboUser.Size = new System.Drawing.Size(125, 24);
            this.ComboUser.TabIndex = 16;
            // 
            // TxtTotal
            // 
            this.TxtTotal.Enabled = false;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(765, 92);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotal.Size = new System.Drawing.Size(125, 26);
            this.TxtTotal.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnShow);
            this.groupBox2.Location = new System.Drawing.Point(941, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 123);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
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
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(9, 60);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(125, 40);
            this.BtnDelete.TabIndex = 19;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.TextColor = System.Drawing.Color.White;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
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
            this.BtnShow.Location = new System.Drawing.Point(9, 18);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(125, 40);
            this.BtnShow.TabIndex = 18;
            this.BtnShow.Text = "Show";
            this.BtnShow.TextColor = System.Drawing.Color.White;
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // DataGridTransactionList
            // 
            this.DataGridTransactionList.BackgroundColor = System.Drawing.Color.White;
            this.DataGridTransactionList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridTransactionList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridTransactionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridTransactionList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridTransactionList.Location = new System.Drawing.Point(14, 173);
            this.DataGridTransactionList.Name = "DataGridTransactionList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridTransactionList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridTransactionList.Size = new System.Drawing.Size(1072, 435);
            this.DataGridTransactionList.TabIndex = 4;
            this.DataGridTransactionList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridTransactionList_DataBindingComplete);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1103, 44);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(349, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Daily Transaction Management";
            // 
            // DailyTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1088, 597);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GroupFilter);
            this.Controls.Add(this.DataGridTransactionList);
            this.Controls.Add(this.groupBox2);
            this.Location = new System.Drawing.Point(532, 241);
            this.Name = "DailyTransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TransactionForm_Load);
            this.GroupFilter.ResumeLayout(false);
            this.GroupFilter.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTransactionList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RadioReceipt;
        private System.Windows.Forms.RadioButton RadioSales;
        private System.Windows.Forms.RadioButton RadioAll;
        private System.Windows.Forms.ComboBox ComboReceipt;
        private System.Windows.Forms.ComboBox ComboPurchasePayment;
        private System.Windows.Forms.RadioButton RadioPurchase;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.MaskedTextBox MaskDtEOD;
        private System.Windows.Forms.DataGridView DataGridTransactionList;
        private System.Windows.Forms.RadioButton RadioInvoiceNo;
        private System.Windows.Forms.GroupBox GroupFilter;
        private System.Windows.Forms.ComboBox ComboInvoiceNo;
        private System.Windows.Forms.ComboBox ComboUser;
        private System.Windows.Forms.ComboBox ComboSales;
        private System.Windows.Forms.ComboBox ComboExpensePayment;
        private System.Windows.Forms.RadioButton RadioExpensePayment;
        private System.Windows.Forms.RadioButton RadioPurchasePayment;
        private System.Windows.Forms.ComboBox ComboPurchase;
        private System.Windows.Forms.ComboBox ComboBankTransfer;
        private System.Windows.Forms.RadioButton RadioBankTransfer;
        private CustomControls.Button.CustomButton BtnDelete;
        private CustomControls.Button.CustomButton BtnShow;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}