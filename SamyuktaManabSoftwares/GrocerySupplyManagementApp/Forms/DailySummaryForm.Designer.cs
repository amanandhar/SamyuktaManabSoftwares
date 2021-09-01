
namespace GrocerySupplyManagementApp.Forms
{
    partial class SummaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MaskEndOfDay = new System.Windows.Forms.MaskedTextBox();
            this.BtnDailyTransaction = new System.Windows.Forms.Button();
            this.BtnShow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.RichOpeningBalanceCash = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.RichBalanceCash = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.RichPaymentCheque = new System.Windows.Forms.RichTextBox();
            this.RichPaymentCash = new System.Windows.Forms.RichTextBox();
            this.RichReceiptCheque = new System.Windows.Forms.RichTextBox();
            this.RichReceiptCash = new System.Windows.Forms.RichTextBox();
            this.RichSalesCredit = new System.Windows.Forms.RichTextBox();
            this.RichSalesCash = new System.Windows.Forms.RichTextBox();
            this.RichOpeningBalanceCredit = new System.Windows.Forms.RichTextBox();
            this.RichBalanceCredit = new System.Windows.Forms.RichTextBox();
            this.DataGridSummaryList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSummaryList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MaskEndOfDay);
            this.groupBox1.Controls.Add(this.BtnDailyTransaction);
            this.groupBox1.Controls.Add(this.BtnShow);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1010, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // MaskEndOfDay
            // 
            this.MaskEndOfDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDay.Location = new System.Drawing.Point(261, 23);
            this.MaskEndOfDay.Mask = "   0000-00-00";
            this.MaskEndOfDay.Name = "MaskEndOfDay";
            this.MaskEndOfDay.Size = new System.Drawing.Size(125, 26);
            this.MaskEndOfDay.TabIndex = 4;
            // 
            // BtnDailyTransaction
            // 
            this.BtnDailyTransaction.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnDailyTransaction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnDailyTransaction.BackgroundImage")));
            this.BtnDailyTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDailyTransaction.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnDailyTransaction.FlatAppearance.BorderSize = 2;
            this.BtnDailyTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnDailyTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDailyTransaction.ForeColor = System.Drawing.Color.Transparent;
            this.BtnDailyTransaction.Location = new System.Drawing.Point(839, 16);
            this.BtnDailyTransaction.Name = "BtnDailyTransaction";
            this.BtnDailyTransaction.Size = new System.Drawing.Size(152, 40);
            this.BtnDailyTransaction.TabIndex = 3;
            this.BtnDailyTransaction.Text = "Daily Transaction";
            this.BtnDailyTransaction.UseVisualStyleBackColor = false;
            this.BtnDailyTransaction.Click += new System.EventHandler(this.BtnDailyTransactions_Click);
            // 
            // BtnShow
            // 
            this.BtnShow.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnShow.BackgroundImage")));
            this.BtnShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnShow.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnShow.FlatAppearance.BorderSize = 2;
            this.BtnShow.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnShow.Location = new System.Drawing.Point(728, 16);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(110, 40);
            this.BtnShow.TabIndex = 2;
            this.BtnShow.Text = "Show";
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(213, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(14, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opening Balance Cash";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(96, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sales Cash";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(91, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sales Credit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(81, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Receipt Cash";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(74, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Payment Cash";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(62, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Receipt Cheque";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(51, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Payment Cheque ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(65, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Balance Cash";
            // 
            // RichOpeningBalanceCash
            // 
            this.RichOpeningBalanceCash.BackColor = System.Drawing.Color.White;
            this.RichOpeningBalanceCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichOpeningBalanceCash.ForeColor = System.Drawing.Color.Black;
            this.RichOpeningBalanceCash.Location = new System.Drawing.Point(189, 55);
            this.RichOpeningBalanceCash.Name = "RichOpeningBalanceCash";
            this.RichOpeningBalanceCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichOpeningBalanceCash.Size = new System.Drawing.Size(165, 30);
            this.RichOpeningBalanceCash.TabIndex = 9;
            this.RichOpeningBalanceCash.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.RichBalanceCash);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.RichPaymentCheque);
            this.groupBox3.Controls.Add(this.RichPaymentCash);
            this.groupBox3.Controls.Add(this.RichReceiptCheque);
            this.groupBox3.Controls.Add(this.RichReceiptCash);
            this.groupBox3.Controls.Add(this.RichSalesCredit);
            this.groupBox3.Controls.Add(this.RichSalesCash);
            this.groupBox3.Controls.Add(this.RichOpeningBalanceCredit);
            this.groupBox3.Controls.Add(this.RichOpeningBalanceCash);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(652, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(375, 382);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox4.BackgroundImage")));
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(-5, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(380, 35);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Cyan;
            this.label13.Location = new System.Drawing.Point(81, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(217, 24);
            this.label13.TabIndex = 0;
            this.label13.Text = "Cash && Credit In Hand";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(9, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Opening Balance Credit";
            // 
            // RichBalanceCash
            // 
            this.RichBalanceCash.BackColor = System.Drawing.Color.White;
            this.RichBalanceCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBalanceCash.ForeColor = System.Drawing.Color.Black;
            this.RichBalanceCash.Location = new System.Drawing.Point(189, 295);
            this.RichBalanceCash.Name = "RichBalanceCash";
            this.RichBalanceCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichBalanceCash.Size = new System.Drawing.Size(165, 30);
            this.RichBalanceCash.TabIndex = 18;
            this.RichBalanceCash.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(58, 330);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Balance Credit";
            // 
            // RichPaymentCheque
            // 
            this.RichPaymentCheque.BackColor = System.Drawing.Color.White;
            this.RichPaymentCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichPaymentCheque.ForeColor = System.Drawing.Color.Black;
            this.RichPaymentCheque.Location = new System.Drawing.Point(189, 265);
            this.RichPaymentCheque.Name = "RichPaymentCheque";
            this.RichPaymentCheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichPaymentCheque.Size = new System.Drawing.Size(165, 30);
            this.RichPaymentCheque.TabIndex = 16;
            this.RichPaymentCheque.Text = "";
            // 
            // RichPaymentCash
            // 
            this.RichPaymentCash.BackColor = System.Drawing.Color.White;
            this.RichPaymentCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichPaymentCash.ForeColor = System.Drawing.Color.Black;
            this.RichPaymentCash.Location = new System.Drawing.Point(189, 235);
            this.RichPaymentCash.Name = "RichPaymentCash";
            this.RichPaymentCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichPaymentCash.Size = new System.Drawing.Size(165, 30);
            this.RichPaymentCash.TabIndex = 15;
            this.RichPaymentCash.Text = "";
            // 
            // RichReceiptCheque
            // 
            this.RichReceiptCheque.BackColor = System.Drawing.Color.White;
            this.RichReceiptCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichReceiptCheque.ForeColor = System.Drawing.Color.Black;
            this.RichReceiptCheque.Location = new System.Drawing.Point(189, 205);
            this.RichReceiptCheque.Name = "RichReceiptCheque";
            this.RichReceiptCheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichReceiptCheque.Size = new System.Drawing.Size(165, 30);
            this.RichReceiptCheque.TabIndex = 14;
            this.RichReceiptCheque.Text = "";
            // 
            // RichReceiptCash
            // 
            this.RichReceiptCash.BackColor = System.Drawing.Color.White;
            this.RichReceiptCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichReceiptCash.ForeColor = System.Drawing.Color.Black;
            this.RichReceiptCash.Location = new System.Drawing.Point(189, 175);
            this.RichReceiptCash.Name = "RichReceiptCash";
            this.RichReceiptCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichReceiptCash.Size = new System.Drawing.Size(165, 30);
            this.RichReceiptCash.TabIndex = 13;
            this.RichReceiptCash.Text = "";
            // 
            // RichSalesCredit
            // 
            this.RichSalesCredit.BackColor = System.Drawing.Color.White;
            this.RichSalesCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichSalesCredit.ForeColor = System.Drawing.Color.Black;
            this.RichSalesCredit.Location = new System.Drawing.Point(189, 145);
            this.RichSalesCredit.Name = "RichSalesCredit";
            this.RichSalesCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichSalesCredit.Size = new System.Drawing.Size(165, 30);
            this.RichSalesCredit.TabIndex = 12;
            this.RichSalesCredit.Text = "";
            // 
            // RichSalesCash
            // 
            this.RichSalesCash.BackColor = System.Drawing.Color.White;
            this.RichSalesCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichSalesCash.ForeColor = System.Drawing.Color.Black;
            this.RichSalesCash.Location = new System.Drawing.Point(189, 115);
            this.RichSalesCash.Name = "RichSalesCash";
            this.RichSalesCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichSalesCash.Size = new System.Drawing.Size(165, 30);
            this.RichSalesCash.TabIndex = 11;
            this.RichSalesCash.Text = "";
            // 
            // RichOpeningBalanceCredit
            // 
            this.RichOpeningBalanceCredit.BackColor = System.Drawing.Color.White;
            this.RichOpeningBalanceCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichOpeningBalanceCredit.ForeColor = System.Drawing.Color.Black;
            this.RichOpeningBalanceCredit.Location = new System.Drawing.Point(189, 85);
            this.RichOpeningBalanceCredit.Name = "RichOpeningBalanceCredit";
            this.RichOpeningBalanceCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichOpeningBalanceCredit.Size = new System.Drawing.Size(165, 30);
            this.RichOpeningBalanceCredit.TabIndex = 10;
            this.RichOpeningBalanceCredit.Text = "";
            // 
            // RichBalanceCredit
            // 
            this.RichBalanceCredit.BackColor = System.Drawing.Color.White;
            this.RichBalanceCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBalanceCredit.ForeColor = System.Drawing.Color.Black;
            this.RichBalanceCredit.Location = new System.Drawing.Point(841, 448);
            this.RichBalanceCredit.Name = "RichBalanceCredit";
            this.RichBalanceCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichBalanceCredit.Size = new System.Drawing.Size(165, 30);
            this.RichBalanceCredit.TabIndex = 19;
            this.RichBalanceCredit.Text = "";
            // 
            // DataGridSummaryList
            // 
            this.DataGridSummaryList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DataGridSummaryList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridSummaryList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridSummaryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridSummaryList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridSummaryList.Location = new System.Drawing.Point(16, 128);
            this.DataGridSummaryList.Name = "DataGridSummaryList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridSummaryList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridSummaryList.Size = new System.Drawing.Size(625, 375);
            this.DataGridSummaryList.TabIndex = 20;
            this.DataGridSummaryList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSummaryList_CellContentClick);
            this.DataGridSummaryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridSummaryList_DataBindingComplete);
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(-4, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1050, 45);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Cyan;
            this.label12.Location = new System.Drawing.Point(338, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(385, 31);
            this.label12.TabIndex = 0;
            this.label12.Text = "Daily Summery Management";
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DataGridSummaryList);
            this.Controls.Add(this.RichBalanceCredit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "SummaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SummaryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSummaryList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox RichOpeningBalanceCash;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox RichPaymentCash;
        private System.Windows.Forms.RichTextBox RichReceiptCheque;
        private System.Windows.Forms.RichTextBox RichReceiptCash;
        private System.Windows.Forms.RichTextBox RichSalesCredit;
        private System.Windows.Forms.RichTextBox RichSalesCash;
        private System.Windows.Forms.RichTextBox RichOpeningBalanceCredit;
        private System.Windows.Forms.RichTextBox RichBalanceCash;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox RichPaymentCheque;
        private System.Windows.Forms.Button BtnDailyTransaction;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox RichBalanceCredit;
        private System.Windows.Forms.DataGridView DataGridSummaryList;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
    }
}