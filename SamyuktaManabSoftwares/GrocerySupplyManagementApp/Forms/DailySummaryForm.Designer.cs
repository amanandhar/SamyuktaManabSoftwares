
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TxtCreditBalance = new System.Windows.Forms.TextBox();
            this.TxtCashBalance = new System.Windows.Forms.TextBox();
            this.TxtChequePayment = new System.Windows.Forms.TextBox();
            this.TxtCashPayment = new System.Windows.Forms.TextBox();
            this.TxtChequeReceipt = new System.Windows.Forms.TextBox();
            this.TxtCashReceipt = new System.Windows.Forms.TextBox();
            this.TxtCreditSales = new System.Windows.Forms.TextBox();
            this.TxtCashSales = new System.Windows.Forms.TextBox();
            this.TxtOpeningCreditBalance = new System.Windows.Forms.TextBox();
            this.TxtOpeningCashBalance = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
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
            this.groupBox1.Location = new System.Drawing.Point(18, 45);
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
            this.BtnDailyTransaction.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnDailyTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDailyTransaction.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnDailyTransaction.FlatAppearance.BorderSize = 2;
            this.BtnDailyTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnDailyTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDailyTransaction.ForeColor = System.Drawing.Color.Cyan;
            this.BtnDailyTransaction.Location = new System.Drawing.Point(836, 16);
            this.BtnDailyTransaction.Name = "BtnDailyTransaction";
            this.BtnDailyTransaction.Size = new System.Drawing.Size(145, 40);
            this.BtnDailyTransaction.TabIndex = 3;
            this.BtnDailyTransaction.Text = "DailyTransaction";
            this.BtnDailyTransaction.UseVisualStyleBackColor = false;
            this.BtnDailyTransaction.Click += new System.EventHandler(this.BtnDailyTransactions_Click);
            // 
            // BtnShow
            // 
            this.BtnShow.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnShow.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnShow.FlatAppearance.BorderSize = 2;
            this.BtnShow.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.Color.Cyan;
            this.BtnShow.Location = new System.Drawing.Point(719, 16);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(115, 40);
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
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opening Cash Balance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(95, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cash Sales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(90, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Credit Sales";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(80, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cash Receipt";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(73, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cash Payment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(61, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Cheque Receipt";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(54, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Cheque Payment";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(65, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Cash Balance";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.TxtCreditBalance);
            this.groupBox3.Controls.Add(this.TxtCashBalance);
            this.groupBox3.Controls.Add(this.TxtChequePayment);
            this.groupBox3.Controls.Add(this.TxtCashPayment);
            this.groupBox3.Controls.Add(this.TxtChequeReceipt);
            this.groupBox3.Controls.Add(this.TxtCashReceipt);
            this.groupBox3.Controls.Add(this.TxtCreditSales);
            this.groupBox3.Controls.Add(this.TxtCashSales);
            this.groupBox3.Controls.Add(this.TxtOpeningCreditBalance);
            this.groupBox3.Controls.Add(this.TxtOpeningCashBalance);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(652, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(375, 375);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.BlueViolet;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Cyan;
            this.textBox1.Location = new System.Drawing.Point(0, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(375, 26);
            this.textBox1.TabIndex = 31;
            this.textBox1.Text = "           Cash & Credit Balance In Hand";
            // 
            // TxtCreditBalance
            // 
            this.TxtCreditBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCreditBalance.Location = new System.Drawing.Point(189, 298);
            this.TxtCreditBalance.Name = "TxtCreditBalance";
            this.TxtCreditBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtCreditBalance.Size = new System.Drawing.Size(165, 26);
            this.TxtCreditBalance.TabIndex = 30;
            // 
            // TxtCashBalance
            // 
            this.TxtCashBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCashBalance.Location = new System.Drawing.Point(189, 270);
            this.TxtCashBalance.Name = "TxtCashBalance";
            this.TxtCashBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtCashBalance.Size = new System.Drawing.Size(165, 26);
            this.TxtCashBalance.TabIndex = 29;
            // 
            // TxtChequePayment
            // 
            this.TxtChequePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtChequePayment.Location = new System.Drawing.Point(189, 242);
            this.TxtChequePayment.Name = "TxtChequePayment";
            this.TxtChequePayment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtChequePayment.Size = new System.Drawing.Size(165, 26);
            this.TxtChequePayment.TabIndex = 28;
            // 
            // TxtCashPayment
            // 
            this.TxtCashPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCashPayment.Location = new System.Drawing.Point(189, 214);
            this.TxtCashPayment.Name = "TxtCashPayment";
            this.TxtCashPayment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtCashPayment.Size = new System.Drawing.Size(165, 26);
            this.TxtCashPayment.TabIndex = 27;
            // 
            // TxtChequeReceipt
            // 
            this.TxtChequeReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtChequeReceipt.Location = new System.Drawing.Point(189, 186);
            this.TxtChequeReceipt.Name = "TxtChequeReceipt";
            this.TxtChequeReceipt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtChequeReceipt.Size = new System.Drawing.Size(165, 26);
            this.TxtChequeReceipt.TabIndex = 26;
            // 
            // TxtCashReceipt
            // 
            this.TxtCashReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCashReceipt.Location = new System.Drawing.Point(189, 158);
            this.TxtCashReceipt.Name = "TxtCashReceipt";
            this.TxtCashReceipt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtCashReceipt.Size = new System.Drawing.Size(165, 26);
            this.TxtCashReceipt.TabIndex = 25;
            // 
            // TxtCreditSales
            // 
            this.TxtCreditSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCreditSales.Location = new System.Drawing.Point(189, 130);
            this.TxtCreditSales.Name = "TxtCreditSales";
            this.TxtCreditSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtCreditSales.Size = new System.Drawing.Size(165, 26);
            this.TxtCreditSales.TabIndex = 24;
            // 
            // TxtCashSales
            // 
            this.TxtCashSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCashSales.Location = new System.Drawing.Point(189, 102);
            this.TxtCashSales.Name = "TxtCashSales";
            this.TxtCashSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtCashSales.Size = new System.Drawing.Size(165, 26);
            this.TxtCashSales.TabIndex = 23;
            // 
            // TxtOpeningCreditBalance
            // 
            this.TxtOpeningCreditBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOpeningCreditBalance.Location = new System.Drawing.Point(189, 74);
            this.TxtOpeningCreditBalance.Name = "TxtOpeningCreditBalance";
            this.TxtOpeningCreditBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtOpeningCreditBalance.Size = new System.Drawing.Size(165, 26);
            this.TxtOpeningCreditBalance.TabIndex = 22;
            // 
            // TxtOpeningCashBalance
            // 
            this.TxtOpeningCashBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOpeningCashBalance.Location = new System.Drawing.Point(189, 46);
            this.TxtOpeningCashBalance.Name = "TxtOpeningCashBalance";
            this.TxtOpeningCashBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtOpeningCashBalance.Size = new System.Drawing.Size(165, 26);
            this.TxtOpeningCashBalance.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(8, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Opening Credit Balance";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(58, 301);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Credit Balance";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.BlueViolet;
            this.groupBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox4.BackgroundImage")));
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.ForeColor = System.Drawing.Color.Cyan;
            this.groupBox4.Location = new System.Drawing.Point(-4, 118);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1050, 30);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(436, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(187, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Daily Summery Report";
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
            this.DataGridSummaryList.Location = new System.Drawing.Point(16, 161);
            this.DataGridSummaryList.Name = "DataGridSummaryList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridSummaryList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridSummaryList.Size = new System.Drawing.Size(625, 367);
            this.DataGridSummaryList.TabIndex = 20;
            this.DataGridSummaryList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSummaryList_CellContentClick);
            this.DataGridSummaryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridSummaryList_DataBindingComplete);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.BlueViolet;
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
            this.ClientSize = new System.Drawing.Size(1045, 551);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DataGridSummaryList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Location = new System.Drawing.Point(569, 240);
            this.Name = "SummaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnDailyTransaction;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView DataGridSummaryList;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtOpeningCashBalance;
        private System.Windows.Forms.TextBox TxtOpeningCreditBalance;
        private System.Windows.Forms.TextBox TxtCashSales;
        private System.Windows.Forms.TextBox TxtCreditSales;
        private System.Windows.Forms.TextBox TxtCashReceipt;
        private System.Windows.Forms.TextBox TxtChequeReceipt;
        private System.Windows.Forms.TextBox TxtCashPayment;
        private System.Windows.Forms.TextBox TxtChequePayment;
        private System.Windows.Forms.TextBox TxtCashBalance;
        private System.Windows.Forms.TextBox TxtCreditBalance;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label14;
    }
}