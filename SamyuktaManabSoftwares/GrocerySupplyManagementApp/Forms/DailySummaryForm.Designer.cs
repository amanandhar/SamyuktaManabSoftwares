
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnDailyTransaction = new System.Windows.Forms.Button();
            this.BtnShow = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.RichBalanceCredit = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnDailyTransaction);
            this.groupBox1.Controls.Add(this.BtnShow);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1010, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BtnDailyTransaction
            // 
            this.BtnDailyTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDailyTransaction.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnDailyTransaction.Location = new System.Drawing.Point(860, 13);
            this.BtnDailyTransaction.Name = "BtnDailyTransaction";
            this.BtnDailyTransaction.Size = new System.Drawing.Size(144, 48);
            this.BtnDailyTransaction.TabIndex = 3;
            this.BtnDailyTransaction.Text = "Daily Transaction";
            this.BtnDailyTransaction.UseVisualStyleBackColor = true;
            this.BtnDailyTransaction.Click += new System.EventHandler(this.BtnDailyTransactions_Click);
            // 
            // BtnShow
            // 
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShow.Location = new System.Drawing.Point(748, 13);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(110, 48);
            this.BtnShow.TabIndex = 2;
            this.BtnShow.Text = "Show";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(131, 22);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 26);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(84, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.LightGray;
            this.textBox3.Location = new System.Drawing.Point(17, 15);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(337, 29);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "    CASH AND CREDIT IN HAND";
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
            this.label3.Location = new System.Drawing.Point(96, 124);
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
            this.label4.Location = new System.Drawing.Point(91, 156);
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
            this.label5.Location = new System.Drawing.Point(70, 188);
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
            this.label6.Location = new System.Drawing.Point(74, 252);
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
            this.label7.Location = new System.Drawing.Point(51, 220);
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
            this.label8.Location = new System.Drawing.Point(53, 284);
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
            this.label9.Location = new System.Drawing.Point(66, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Balance Cash";
            // 
            // RichOpeningBalanceCash
            // 
            this.RichOpeningBalanceCash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichOpeningBalanceCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichOpeningBalanceCash.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RichOpeningBalanceCash.Location = new System.Drawing.Point(189, 55);
            this.RichOpeningBalanceCash.Name = "RichOpeningBalanceCash";
            this.RichOpeningBalanceCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichOpeningBalanceCash.Size = new System.Drawing.Size(165, 30);
            this.RichOpeningBalanceCash.TabIndex = 9;
            this.RichOpeningBalanceCash.Text = "";
            // 
            // groupBox3
            // 
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
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Location = new System.Drawing.Point(652, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(375, 390);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label11.Location = new System.Drawing.Point(9, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Opening Balance Credit";
            // 
            // RichBalanceCash
            // 
            this.RichBalanceCash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichBalanceCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBalanceCash.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RichBalanceCash.Location = new System.Drawing.Point(189, 311);
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
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label10.Location = new System.Drawing.Point(58, 347);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Balance Credit";
            // 
            // RichPaymentCheque
            // 
            this.RichPaymentCheque.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichPaymentCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichPaymentCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.RichPaymentCheque.Location = new System.Drawing.Point(189, 279);
            this.RichPaymentCheque.Name = "RichPaymentCheque";
            this.RichPaymentCheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichPaymentCheque.Size = new System.Drawing.Size(165, 30);
            this.RichPaymentCheque.TabIndex = 16;
            this.RichPaymentCheque.Text = "";
            // 
            // RichPaymentCash
            // 
            this.RichPaymentCash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichPaymentCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichPaymentCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.RichPaymentCash.Location = new System.Drawing.Point(189, 247);
            this.RichPaymentCash.Name = "RichPaymentCash";
            this.RichPaymentCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichPaymentCash.Size = new System.Drawing.Size(165, 30);
            this.RichPaymentCash.TabIndex = 15;
            this.RichPaymentCash.Text = "";
            // 
            // RichReceiptCheque
            // 
            this.RichReceiptCheque.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichReceiptCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichReceiptCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.RichReceiptCheque.Location = new System.Drawing.Point(189, 215);
            this.RichReceiptCheque.Name = "RichReceiptCheque";
            this.RichReceiptCheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichReceiptCheque.Size = new System.Drawing.Size(165, 30);
            this.RichReceiptCheque.TabIndex = 14;
            this.RichReceiptCheque.Text = "";
            // 
            // RichReceiptCash
            // 
            this.RichReceiptCash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichReceiptCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichReceiptCash.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RichReceiptCash.Location = new System.Drawing.Point(189, 183);
            this.RichReceiptCash.Name = "RichReceiptCash";
            this.RichReceiptCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichReceiptCash.Size = new System.Drawing.Size(165, 30);
            this.RichReceiptCash.TabIndex = 13;
            this.RichReceiptCash.Text = "";
            // 
            // RichSalesCredit
            // 
            this.RichSalesCredit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichSalesCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichSalesCredit.ForeColor = System.Drawing.Color.Red;
            this.RichSalesCredit.Location = new System.Drawing.Point(189, 151);
            this.RichSalesCredit.Name = "RichSalesCredit";
            this.RichSalesCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichSalesCredit.Size = new System.Drawing.Size(165, 30);
            this.RichSalesCredit.TabIndex = 12;
            this.RichSalesCredit.Text = "";
            // 
            // RichSalesCash
            // 
            this.RichSalesCash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichSalesCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichSalesCash.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RichSalesCash.Location = new System.Drawing.Point(189, 119);
            this.RichSalesCash.Name = "RichSalesCash";
            this.RichSalesCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichSalesCash.Size = new System.Drawing.Size(165, 30);
            this.RichSalesCash.TabIndex = 11;
            this.RichSalesCash.Text = "";
            // 
            // RichOpeningBalanceCredit
            // 
            this.RichOpeningBalanceCredit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichOpeningBalanceCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichOpeningBalanceCredit.ForeColor = System.Drawing.Color.Red;
            this.RichOpeningBalanceCredit.Location = new System.Drawing.Point(189, 87);
            this.RichOpeningBalanceCredit.Name = "RichOpeningBalanceCredit";
            this.RichOpeningBalanceCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichOpeningBalanceCredit.Size = new System.Drawing.Size(165, 30);
            this.RichOpeningBalanceCredit.TabIndex = 10;
            this.RichOpeningBalanceCredit.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(-1, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1045, 27);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "                                                                     Daily Summar" +
    "y Report";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(-1, 101);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(1045, 24);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "                                                                               Su" +
    "mmary Report : \r\n2078-02-20";
            // 
            // RichBalanceCredit
            // 
            this.RichBalanceCredit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichBalanceCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBalanceCredit.ForeColor = System.Drawing.Color.Red;
            this.RichBalanceCredit.Location = new System.Drawing.Point(841, 474);
            this.RichBalanceCredit.Name = "RichBalanceCredit";
            this.RichBalanceCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichBalanceCredit.Size = new System.Drawing.Size(165, 30);
            this.RichBalanceCredit.TabIndex = 19;
            this.RichBalanceCredit.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(623, 385);
            this.dataGridView1.TabIndex = 20;
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RichBalanceCredit);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "SummaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SummaryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button BtnDailyTransaction;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox RichBalanceCredit;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}