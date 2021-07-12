﻿
namespace GrocerySupplyManagementApp.Forms
{
    partial class TransactionForm
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
            this.ComboBankTransfer = new System.Windows.Forms.ComboBox();
            this.RadioBankTransfer = new System.Windows.Forms.RadioButton();
            this.RadioItemCode = new System.Windows.Forms.RadioButton();
            this.ComboPurchase = new System.Windows.Forms.ComboBox();
            this.RadioInvoiceNo = new System.Windows.Forms.RadioButton();
            this.ComboExpense = new System.Windows.Forms.ComboBox();
            this.ComboItemCode = new System.Windows.Forms.ComboBox();
            this.RadioExpense = new System.Windows.Forms.RadioButton();
            this.RadioAll = new System.Windows.Forms.RadioButton();
            this.RadioPayment = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.RadioSales = new System.Windows.Forms.RadioButton();
            this.ComboInvoiceNo = new System.Windows.Forms.ComboBox();
            this.ComboSales = new System.Windows.Forms.ComboBox();
            this.RadioReceipt = new System.Windows.Forms.RadioButton();
            this.MaskDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RadioPurchase = new System.Windows.Forms.RadioButton();
            this.ComboPayment = new System.Windows.Forms.ComboBox();
            this.ComboReceipt = new System.Windows.Forms.ComboBox();
            this.ComboUser = new System.Windows.Forms.ComboBox();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.RadioUser = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDeleteTransaction = new System.Windows.Forms.Button();
            this.BtnShowTransaction = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DataGridTransactionList = new System.Windows.Forms.DataGridView();
            this.GroupFilter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTransactionList)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupFilter
            // 
            this.GroupFilter.Controls.Add(this.ComboBankTransfer);
            this.GroupFilter.Controls.Add(this.RadioBankTransfer);
            this.GroupFilter.Controls.Add(this.RadioItemCode);
            this.GroupFilter.Controls.Add(this.ComboPurchase);
            this.GroupFilter.Controls.Add(this.RadioInvoiceNo);
            this.GroupFilter.Controls.Add(this.ComboExpense);
            this.GroupFilter.Controls.Add(this.ComboItemCode);
            this.GroupFilter.Controls.Add(this.RadioExpense);
            this.GroupFilter.Controls.Add(this.RadioAll);
            this.GroupFilter.Controls.Add(this.RadioPayment);
            this.GroupFilter.Controls.Add(this.label2);
            this.GroupFilter.Controls.Add(this.RadioSales);
            this.GroupFilter.Controls.Add(this.ComboInvoiceNo);
            this.GroupFilter.Controls.Add(this.ComboSales);
            this.GroupFilter.Controls.Add(this.RadioReceipt);
            this.GroupFilter.Controls.Add(this.MaskDate);
            this.GroupFilter.Controls.Add(this.label3);
            this.GroupFilter.Controls.Add(this.RadioPurchase);
            this.GroupFilter.Controls.Add(this.ComboPayment);
            this.GroupFilter.Controls.Add(this.ComboReceipt);
            this.GroupFilter.Controls.Add(this.ComboUser);
            this.GroupFilter.Controls.Add(this.TxtTotal);
            this.GroupFilter.Controls.Add(this.RadioUser);
            this.GroupFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupFilter.ForeColor = System.Drawing.Color.Red;
            this.GroupFilter.Location = new System.Drawing.Point(15, 26);
            this.GroupFilter.Name = "GroupFilter";
            this.GroupFilter.Size = new System.Drawing.Size(850, 137);
            this.GroupFilter.TabIndex = 5;
            this.GroupFilter.TabStop = false;
            // 
            // ComboBankTransfer
            // 
            this.ComboBankTransfer.Enabled = false;
            this.ComboBankTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBankTransfer.FormattingEnabled = true;
            this.ComboBankTransfer.Items.AddRange(new object[] {
            "Cash"});
            this.ComboBankTransfer.Location = new System.Drawing.Point(442, 73);
            this.ComboBankTransfer.Name = "ComboBankTransfer";
            this.ComboBankTransfer.Size = new System.Drawing.Size(115, 26);
            this.ComboBankTransfer.TabIndex = 44;
            // 
            // RadioBankTransfer
            // 
            this.RadioBankTransfer.AutoSize = true;
            this.RadioBankTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBankTransfer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioBankTransfer.Location = new System.Drawing.Point(270, 77);
            this.RadioBankTransfer.Name = "RadioBankTransfer";
            this.RadioBankTransfer.Size = new System.Drawing.Size(119, 22);
            this.RadioBankTransfer.TabIndex = 43;
            this.RadioBankTransfer.TabStop = true;
            this.RadioBankTransfer.Text = "Bank Transfer";
            this.RadioBankTransfer.UseVisualStyleBackColor = true;
            this.RadioBankTransfer.CheckedChanged += new System.EventHandler(this.RadioBankTransfer_CheckedChanged);
            // 
            // RadioItemCode
            // 
            this.RadioItemCode.AutoSize = true;
            this.RadioItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioItemCode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioItemCode.Location = new System.Drawing.Point(587, 19);
            this.RadioItemCode.Name = "RadioItemCode";
            this.RadioItemCode.Size = new System.Drawing.Size(115, 22);
            this.RadioItemCode.TabIndex = 32;
            this.RadioItemCode.TabStop = true;
            this.RadioItemCode.Text = "By Item Code";
            this.RadioItemCode.UseVisualStyleBackColor = true;
            this.RadioItemCode.CheckedChanged += new System.EventHandler(this.RadioItemCode_CheckedChanged);
            // 
            // ComboPurchase
            // 
            this.ComboPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPurchase.FormattingEnabled = true;
            this.ComboPurchase.Items.AddRange(new object[] {
            "Cash",
            "Credit"});
            this.ComboPurchase.Location = new System.Drawing.Point(132, 72);
            this.ComboPurchase.Name = "ComboPurchase";
            this.ComboPurchase.Size = new System.Drawing.Size(105, 26);
            this.ComboPurchase.TabIndex = 42;
            // 
            // RadioInvoiceNo
            // 
            this.RadioInvoiceNo.AutoSize = true;
            this.RadioInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioInvoiceNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioInvoiceNo.Location = new System.Drawing.Point(587, 47);
            this.RadioInvoiceNo.Name = "RadioInvoiceNo";
            this.RadioInvoiceNo.Size = new System.Drawing.Size(117, 22);
            this.RadioInvoiceNo.TabIndex = 35;
            this.RadioInvoiceNo.Text = "By Invoice No";
            this.RadioInvoiceNo.UseVisualStyleBackColor = true;
            this.RadioInvoiceNo.CheckedChanged += new System.EventHandler(this.RadioInvoiceNo_CheckedChanged);
            // 
            // ComboExpense
            // 
            this.ComboExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboExpense.FormattingEnabled = true;
            this.ComboExpense.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboExpense.Location = new System.Drawing.Point(442, 45);
            this.ComboExpense.Name = "ComboExpense";
            this.ComboExpense.Size = new System.Drawing.Size(115, 26);
            this.ComboExpense.TabIndex = 41;
            // 
            // ComboItemCode
            // 
            this.ComboItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboItemCode.FormattingEnabled = true;
            this.ComboItemCode.Location = new System.Drawing.Point(705, 17);
            this.ComboItemCode.Name = "ComboItemCode";
            this.ComboItemCode.Size = new System.Drawing.Size(120, 26);
            this.ComboItemCode.TabIndex = 31;
            // 
            // RadioExpense
            // 
            this.RadioExpense.AutoSize = true;
            this.RadioExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioExpense.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioExpense.Location = new System.Drawing.Point(270, 48);
            this.RadioExpense.Name = "RadioExpense";
            this.RadioExpense.Size = new System.Drawing.Size(166, 22);
            this.RadioExpense.TabIndex = 40;
            this.RadioExpense.TabStop = true;
            this.RadioExpense.Text = "By Expense Payment";
            this.RadioExpense.UseVisualStyleBackColor = true;
            this.RadioExpense.CheckedChanged += new System.EventHandler(this.RadioExpense_CheckedChanged);
            // 
            // RadioAll
            // 
            this.RadioAll.AutoSize = true;
            this.RadioAll.Checked = true;
            this.RadioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioAll.Location = new System.Drawing.Point(27, 18);
            this.RadioAll.Name = "RadioAll";
            this.RadioAll.Size = new System.Drawing.Size(49, 22);
            this.RadioAll.TabIndex = 2;
            this.RadioAll.TabStop = true;
            this.RadioAll.Text = "All  ";
            this.RadioAll.UseVisualStyleBackColor = true;
            // 
            // RadioPayment
            // 
            this.RadioPayment.AutoSize = true;
            this.RadioPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioPayment.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioPayment.Location = new System.Drawing.Point(270, 19);
            this.RadioPayment.Name = "RadioPayment";
            this.RadioPayment.Size = new System.Drawing.Size(172, 22);
            this.RadioPayment.TabIndex = 39;
            this.RadioPayment.TabStop = true;
            this.RadioPayment.Text = "By Purchase Payment";
            this.RadioPayment.UseVisualStyleBackColor = true;
            this.RadioPayment.CheckedChanged += new System.EventHandler(this.RadioPayment_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(81, 20);
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
            this.RadioSales.Location = new System.Drawing.Point(26, 102);
            this.RadioSales.Name = "RadioSales";
            this.RadioSales.Size = new System.Drawing.Size(84, 22);
            this.RadioSales.TabIndex = 3;
            this.RadioSales.Text = "By Sales";
            this.RadioSales.UseVisualStyleBackColor = true;
            this.RadioSales.CheckedChanged += new System.EventHandler(this.RadioSales_CheckedChanged);
            // 
            // ComboInvoiceNo
            // 
            this.ComboInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboInvoiceNo.FormattingEnabled = true;
            this.ComboInvoiceNo.Location = new System.Drawing.Point(705, 45);
            this.ComboInvoiceNo.Name = "ComboInvoiceNo";
            this.ComboInvoiceNo.Size = new System.Drawing.Size(120, 26);
            this.ComboInvoiceNo.TabIndex = 36;
            // 
            // ComboSales
            // 
            this.ComboSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboSales.FormattingEnabled = true;
            this.ComboSales.Items.AddRange(new object[] {
            "Cash",
            "Credit"});
            this.ComboSales.Location = new System.Drawing.Point(132, 100);
            this.ComboSales.Name = "ComboSales";
            this.ComboSales.Size = new System.Drawing.Size(105, 26);
            this.ComboSales.TabIndex = 38;
            // 
            // RadioReceipt
            // 
            this.RadioReceipt.AutoSize = true;
            this.RadioReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioReceipt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioReceipt.Location = new System.Drawing.Point(270, 105);
            this.RadioReceipt.Name = "RadioReceipt";
            this.RadioReceipt.Size = new System.Drawing.Size(101, 22);
            this.RadioReceipt.TabIndex = 14;
            this.RadioReceipt.Text = "By Receipt ";
            this.RadioReceipt.UseVisualStyleBackColor = true;
            this.RadioReceipt.CheckedChanged += new System.EventHandler(this.RadioReceipt_CheckedChanged);
            // 
            // MaskDate
            // 
            this.MaskDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDate.Location = new System.Drawing.Point(132, 17);
            this.MaskDate.Mask = "   0000-00-00";
            this.MaskDate.Name = "MaskDate";
            this.MaskDate.Size = new System.Drawing.Size(105, 24);
            this.MaskDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(586, 104);
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
            this.RadioPurchase.Location = new System.Drawing.Point(26, 74);
            this.RadioPurchase.Name = "RadioPurchase";
            this.RadioPurchase.Size = new System.Drawing.Size(110, 22);
            this.RadioPurchase.TabIndex = 18;
            this.RadioPurchase.Text = "By Purchase";
            this.RadioPurchase.UseVisualStyleBackColor = true;
            this.RadioPurchase.CheckedChanged += new System.EventHandler(this.RadioPurchase_CheckedChanged);
            // 
            // ComboPayment
            // 
            this.ComboPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPayment.FormattingEnabled = true;
            this.ComboPayment.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboPayment.Location = new System.Drawing.Point(442, 17);
            this.ComboPayment.Name = "ComboPayment";
            this.ComboPayment.Size = new System.Drawing.Size(115, 26);
            this.ComboPayment.TabIndex = 22;
            // 
            // ComboReceipt
            // 
            this.ComboReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboReceipt.FormattingEnabled = true;
            this.ComboReceipt.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboReceipt.Location = new System.Drawing.Point(442, 101);
            this.ComboReceipt.Name = "ComboReceipt";
            this.ComboReceipt.Size = new System.Drawing.Size(115, 26);
            this.ComboReceipt.TabIndex = 23;
            // 
            // ComboUser
            // 
            this.ComboUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboUser.FormattingEnabled = true;
            this.ComboUser.Location = new System.Drawing.Point(705, 73);
            this.ComboUser.Name = "ComboUser";
            this.ComboUser.Size = new System.Drawing.Size(120, 26);
            this.ComboUser.TabIndex = 37;
            // 
            // TxtTotal
            // 
            this.TxtTotal.Enabled = false;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(705, 101);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotal.Size = new System.Drawing.Size(120, 26);
            this.TxtTotal.TabIndex = 28;
            // 
            // RadioUser
            // 
            this.RadioUser.AutoSize = true;
            this.RadioUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioUser.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioUser.Location = new System.Drawing.Point(587, 76);
            this.RadioUser.Name = "RadioUser";
            this.RadioUser.Size = new System.Drawing.Size(79, 22);
            this.RadioUser.TabIndex = 19;
            this.RadioUser.Text = "By User";
            this.RadioUser.UseVisualStyleBackColor = true;
            this.RadioUser.CheckedChanged += new System.EventHandler(this.RadioUser_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDeleteTransaction);
            this.groupBox2.Controls.Add(this.BtnShowTransaction);
            this.groupBox2.Location = new System.Drawing.Point(879, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 137);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // BtnDeleteTransaction
            // 
            this.BtnDeleteTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteTransaction.ForeColor = System.Drawing.Color.Red;
            this.BtnDeleteTransaction.Location = new System.Drawing.Point(10, 72);
            this.BtnDeleteTransaction.Name = "BtnDeleteTransaction";
            this.BtnDeleteTransaction.Size = new System.Drawing.Size(130, 55);
            this.BtnDeleteTransaction.TabIndex = 1;
            this.BtnDeleteTransaction.Text = "Delete Transaction";
            this.BtnDeleteTransaction.UseVisualStyleBackColor = true;
            this.BtnDeleteTransaction.Click += new System.EventHandler(this.BtnDeleteTransaction_Click);
            // 
            // BtnShowTransaction
            // 
            this.BtnShowTransaction.BackColor = System.Drawing.SystemColors.Control;
            this.BtnShowTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowTransaction.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowTransaction.Location = new System.Drawing.Point(10, 15);
            this.BtnShowTransaction.Name = "BtnShowTransaction";
            this.BtnShowTransaction.Size = new System.Drawing.Size(130, 55);
            this.BtnShowTransaction.TabIndex = 0;
            this.BtnShowTransaction.Text = "Show Transaction";
            this.BtnShowTransaction.UseVisualStyleBackColor = false;
            this.BtnShowTransaction.Click += new System.EventHandler(this.BtnShowTransaction_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1045, 26);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "                                                                                 " +
    "                     Daily Sales\r\n & Other Transaction";
            // 
            // DataGridTransactionList
            // 
            this.DataGridTransactionList.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.DataGridTransactionList.Location = new System.Drawing.Point(14, 174);
            this.DataGridTransactionList.Name = "DataGridTransactionList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridTransactionList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridTransactionList.Size = new System.Drawing.Size(1015, 355);
            this.DataGridTransactionList.TabIndex = 4;
            this.DataGridTransactionList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridTransactionList_DataBindingComplete);
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.GroupFilter);
            this.Controls.Add(this.DataGridTransactionList);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "TransactionForm";
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
        private System.Windows.Forms.Button BtnDeleteTransaction;
        private System.Windows.Forms.Button BtnShowTransaction;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton RadioReceipt;
        private System.Windows.Forms.RadioButton RadioSales;
        private System.Windows.Forms.RadioButton RadioAll;
        private System.Windows.Forms.ComboBox ComboReceipt;
        private System.Windows.Forms.ComboBox ComboPayment;
        private System.Windows.Forms.RadioButton RadioUser;
        private System.Windows.Forms.RadioButton RadioPurchase;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.MaskedTextBox MaskDate;
        private System.Windows.Forms.DataGridView DataGridTransactionList;
        private System.Windows.Forms.RadioButton RadioItemCode;
        private System.Windows.Forms.ComboBox ComboItemCode;
        private System.Windows.Forms.RadioButton RadioInvoiceNo;
        private System.Windows.Forms.GroupBox GroupFilter;
        private System.Windows.Forms.ComboBox ComboInvoiceNo;
        private System.Windows.Forms.ComboBox ComboUser;
        private System.Windows.Forms.ComboBox ComboSales;
        private System.Windows.Forms.ComboBox ComboExpense;
        private System.Windows.Forms.RadioButton RadioExpense;
        private System.Windows.Forms.RadioButton RadioPayment;
        private System.Windows.Forms.ComboBox ComboPurchase;
        private System.Windows.Forms.ComboBox ComboBankTransfer;
        private System.Windows.Forms.RadioButton RadioBankTransfer;
    }
}