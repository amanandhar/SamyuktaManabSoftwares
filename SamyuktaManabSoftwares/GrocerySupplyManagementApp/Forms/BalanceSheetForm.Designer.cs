
namespace GrocerySupplyManagementApp.Forms
{
    partial class BalanceSheetForm
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
            this.BtnExportToExcel = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.MaskEndOfDay = new System.Windows.Forms.MaskedTextBox();
            this.linkLabel15 = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnShow = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.label4 = new System.Windows.Forms.Label();
            this.RichReceivableAmount = new System.Windows.Forms.RichTextBox();
            this.RichShareCapital = new System.Windows.Forms.RichTextBox();
            this.RichCashInHand = new System.Windows.Forms.RichTextBox();
            this.RichAssetsBalance = new System.Windows.Forms.RichTextBox();
            this.RichOwnerEquity = new System.Windows.Forms.RichTextBox();
            this.RichBankAccount = new System.Windows.Forms.RichTextBox();
            this.RichLoanAmount = new System.Windows.Forms.RichTextBox();
            this.RichPayableAmount = new System.Windows.Forms.RichTextBox();
            this.RichNetProfit = new System.Windows.Forms.RichTextBox();
            this.RichLiabilitiesBalance = new System.Windows.Forms.RichTextBox();
            this.RichStockValue = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.RichNetLoss = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnExportToExcel);
            this.groupBox1.Controls.Add(this.MaskEndOfDay);
            this.groupBox1.Controls.Add(this.linkLabel15);
            this.groupBox1.Location = new System.Drawing.Point(19, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExportToExcel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnExportToExcel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnExportToExcel.BorderRadius = 35;
            this.BtnExportToExcel.BorderSize = 0;
            this.BtnExportToExcel.Enabled = false;
            this.BtnExportToExcel.FlatAppearance.BorderSize = 0;
            this.BtnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.White;
            this.BtnExportToExcel.Location = new System.Drawing.Point(739, 12);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(155, 40);
            this.BtnExportToExcel.TabIndex = 1;
            this.BtnExportToExcel.Text = "Export To Excel";
            this.BtnExportToExcel.TextColor = System.Drawing.Color.White;
            this.BtnExportToExcel.UseVisualStyleBackColor = false;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // MaskEndOfDay
            // 
            this.MaskEndOfDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDay.Location = new System.Drawing.Point(224, 18);
            this.MaskEndOfDay.Mask = "   0000-00-00";
            this.MaskEndOfDay.Name = "MaskEndOfDay";
            this.MaskEndOfDay.Size = new System.Drawing.Size(117, 26);
            this.MaskEndOfDay.TabIndex = 22;
            // 
            // linkLabel15
            // 
            this.linkLabel15.AutoSize = true;
            this.linkLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.linkLabel15.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkLabel15.Location = new System.Drawing.Point(171, 21);
            this.linkLabel15.Name = "linkLabel15";
            this.linkLabel15.Size = new System.Drawing.Size(48, 20);
            this.linkLabel15.TabIndex = 21;
            this.linkLabel15.TabStop = true;
            this.linkLabel15.Text = "Date ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnShow);
            this.groupBox3.Location = new System.Drawing.Point(938, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 60);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
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
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.Color.White;
            this.BtnShow.Location = new System.Drawing.Point(9, 12);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(130, 40);
            this.BtnShow.TabIndex = 0;
            this.BtnShow.Text = "Show";
            this.BtnShow.TextColor = System.Drawing.Color.White;
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(232, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 6;
            // 
            // RichReceivableAmount
            // 
            this.RichReceivableAmount.Enabled = false;
            this.RichReceivableAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichReceivableAmount.Location = new System.Drawing.Point(194, 148);
            this.RichReceivableAmount.Name = "RichReceivableAmount";
            this.RichReceivableAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichReceivableAmount.Size = new System.Drawing.Size(250, 35);
            this.RichReceivableAmount.TabIndex = 10;
            this.RichReceivableAmount.Text = "";
            // 
            // RichShareCapital
            // 
            this.RichShareCapital.Enabled = false;
            this.RichShareCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichShareCapital.Location = new System.Drawing.Point(156, 33);
            this.RichShareCapital.Name = "RichShareCapital";
            this.RichShareCapital.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichShareCapital.Size = new System.Drawing.Size(250, 35);
            this.RichShareCapital.TabIndex = 24;
            this.RichShareCapital.Text = "";
            // 
            // RichCashInHand
            // 
            this.RichCashInHand.Enabled = false;
            this.RichCashInHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichCashInHand.Location = new System.Drawing.Point(194, 33);
            this.RichCashInHand.Name = "RichCashInHand";
            this.RichCashInHand.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichCashInHand.Size = new System.Drawing.Size(250, 35);
            this.RichCashInHand.TabIndex = 25;
            this.RichCashInHand.Text = "";
            // 
            // RichAssetsBalance
            // 
            this.RichAssetsBalance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichAssetsBalance.Enabled = false;
            this.RichAssetsBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAssetsBalance.Location = new System.Drawing.Point(193, 227);
            this.RichAssetsBalance.Name = "RichAssetsBalance";
            this.RichAssetsBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAssetsBalance.Size = new System.Drawing.Size(250, 35);
            this.RichAssetsBalance.TabIndex = 26;
            this.RichAssetsBalance.Text = "";
            // 
            // RichOwnerEquity
            // 
            this.RichOwnerEquity.Enabled = false;
            this.RichOwnerEquity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichOwnerEquity.Location = new System.Drawing.Point(156, 72);
            this.RichOwnerEquity.Name = "RichOwnerEquity";
            this.RichOwnerEquity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichOwnerEquity.Size = new System.Drawing.Size(250, 35);
            this.RichOwnerEquity.TabIndex = 29;
            this.RichOwnerEquity.Text = "";
            // 
            // RichBankAccount
            // 
            this.RichBankAccount.Enabled = false;
            this.RichBankAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBankAccount.Location = new System.Drawing.Point(194, 72);
            this.RichBankAccount.Name = "RichBankAccount";
            this.RichBankAccount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichBankAccount.Size = new System.Drawing.Size(250, 35);
            this.RichBankAccount.TabIndex = 30;
            this.RichBankAccount.Text = "";
            // 
            // RichLoanAmount
            // 
            this.RichLoanAmount.Enabled = false;
            this.RichLoanAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichLoanAmount.Location = new System.Drawing.Point(155, 110);
            this.RichLoanAmount.Name = "RichLoanAmount";
            this.RichLoanAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichLoanAmount.Size = new System.Drawing.Size(250, 35);
            this.RichLoanAmount.TabIndex = 31;
            this.RichLoanAmount.Text = "";
            // 
            // RichPayableAmount
            // 
            this.RichPayableAmount.Enabled = false;
            this.RichPayableAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichPayableAmount.Location = new System.Drawing.Point(155, 148);
            this.RichPayableAmount.Name = "RichPayableAmount";
            this.RichPayableAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichPayableAmount.Size = new System.Drawing.Size(250, 35);
            this.RichPayableAmount.TabIndex = 32;
            this.RichPayableAmount.Text = "";
            // 
            // RichNetProfit
            // 
            this.RichNetProfit.Enabled = false;
            this.RichNetProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichNetProfit.Location = new System.Drawing.Point(155, 186);
            this.RichNetProfit.Name = "RichNetProfit";
            this.RichNetProfit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichNetProfit.Size = new System.Drawing.Size(250, 35);
            this.RichNetProfit.TabIndex = 33;
            this.RichNetProfit.Text = "";
            // 
            // RichLiabilitiesBalance
            // 
            this.RichLiabilitiesBalance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichLiabilitiesBalance.Enabled = false;
            this.RichLiabilitiesBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichLiabilitiesBalance.Location = new System.Drawing.Point(156, 227);
            this.RichLiabilitiesBalance.Name = "RichLiabilitiesBalance";
            this.RichLiabilitiesBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichLiabilitiesBalance.Size = new System.Drawing.Size(250, 35);
            this.RichLiabilitiesBalance.TabIndex = 38;
            this.RichLiabilitiesBalance.Text = "";
            // 
            // RichStockValue
            // 
            this.RichStockValue.Enabled = false;
            this.RichStockValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichStockValue.Location = new System.Drawing.Point(194, 110);
            this.RichStockValue.Name = "RichStockValue";
            this.RichStockValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichStockValue.Size = new System.Drawing.Size(250, 35);
            this.RichStockValue.TabIndex = 28;
            this.RichStockValue.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.RichLiabilitiesBalance);
            this.groupBox2.Controls.Add(this.RichShareCapital);
            this.groupBox2.Controls.Add(this.RichNetProfit);
            this.groupBox2.Controls.Add(this.RichOwnerEquity);
            this.groupBox2.Controls.Add(this.RichPayableAmount);
            this.groupBox2.Controls.Add(this.RichLoanAmount);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(21, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 320);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Liabilities";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(78, 233);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 20);
            this.label14.TabIndex = 51;
            this.label14.Text = "Balance";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(76, 192);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 20);
            this.label13.TabIndex = 50;
            this.label13.Text = "Net Profit";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(35, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 20);
            this.label12.TabIndex = 49;
            this.label12.Text = "Payble Amount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(46, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 20);
            this.label11.TabIndex = 48;
            this.label11.Text = "Loan Amount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(38, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 47;
            this.label10.Text = "Owner\'s Equity";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(47, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 20);
            this.label9.TabIndex = 46;
            this.label9.Text = "Share Capital";
            // 
            // RichNetLoss
            // 
            this.RichNetLoss.Enabled = false;
            this.RichNetLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichNetLoss.Location = new System.Drawing.Point(193, 186);
            this.RichNetLoss.Name = "RichNetLoss";
            this.RichNetLoss.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichNetLoss.Size = new System.Drawing.Size(250, 35);
            this.RichNetLoss.TabIndex = 44;
            this.RichNetLoss.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.RichNetLoss);
            this.groupBox4.Controls.Add(this.RichAssetsBalance);
            this.groupBox4.Controls.Add(this.RichStockValue);
            this.groupBox4.Controls.Add(this.RichBankAccount);
            this.groupBox4.Controls.Add(this.RichCashInHand);
            this.groupBox4.Controls.Add(this.RichReceivableAmount);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox4.Location = new System.Drawing.Point(553, 167);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(530, 320);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Assets";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(115, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 50;
            this.label8.Text = "Balance";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(117, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 49;
            this.label7.Text = "Net Loss";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Receivable Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(95, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "Stock Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "Bank Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Cash In Hand";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1115, 44);
            this.textBox1.TabIndex = 48;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.DodgerBlue;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Aqua;
            this.label15.Location = new System.Drawing.Point(368, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(378, 31);
            this.label15.TabIndex = 49;
            this.label15.Text = "Balance Sheet Management";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Aqua;
            this.textBox2.Location = new System.Drawing.Point(-1, 125);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1115, 29);
            this.textBox2.TabIndex = 50;
            this.textBox2.Text = "                                                                                 " +
    "                 Balance Sheet";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "xlsx";
            this.SaveFileDialog.FileName = "BalanceSheetReport";
            this.SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            this.SaveFileDialog.InitialDirectory = "C:\\";
            this.SaveFileDialog.RestoreDirectory = true;
            // 
            // BalanceSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1104, 602);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(569, 240);
            this.Name = "BalanceSheetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BalanceSheetForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox RichReceivableAmount;
        private System.Windows.Forms.RichTextBox RichShareCapital;
        private System.Windows.Forms.RichTextBox RichCashInHand;
        private System.Windows.Forms.RichTextBox RichAssetsBalance;
        private System.Windows.Forms.RichTextBox RichOwnerEquity;
        private System.Windows.Forms.RichTextBox RichBankAccount;
        private System.Windows.Forms.RichTextBox RichLoanAmount;
        private System.Windows.Forms.RichTextBox RichPayableAmount;
        private System.Windows.Forms.RichTextBox RichNetProfit;
        private System.Windows.Forms.LinkLabel linkLabel15;
        private System.Windows.Forms.RichTextBox RichLiabilitiesBalance;
        private System.Windows.Forms.RichTextBox RichStockValue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox RichNetLoss;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private CustomControls.Button.CustomButton BtnShow;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox2;
        private CustomControls.Button.CustomButton BtnExportToExcel;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
    }
}