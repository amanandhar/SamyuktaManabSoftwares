
namespace GrocerySupplyManagementApp.Forms
{
    partial class BankForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtBalance = new System.Windows.Forms.TextBox();
            this.RichNarration = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ComboAction = new System.Windows.Forms.ComboBox();
            this.RichAmount = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnShowBank = new System.Windows.Forms.Button();
            this.RichAccountNo = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RichBankName = new System.Windows.Forms.RichTextBox();
            this.BtnDeleteTransaction = new System.Windows.Forms.Button();
            this.BtnSaveTransaction = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSaveBank = new System.Windows.Forms.Button();
            this.BtnEditBank = new System.Windows.Forms.Button();
            this.BtnUpdateBank = new System.Windows.Forms.Button();
            this.BtnAddBank = new System.Windows.Forms.Button();
            this.BtnDeleteBank = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DataGridBankDetails = new System.Windows.Forms.DataGridView();
            this.BtnShowTransaction = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBankDetails)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1045, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "                                                                                 " +
    "       Banking Transaction";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtBalance);
            this.groupBox1.Controls.Add(this.RichNarration);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.ComboAction);
            this.groupBox1.Controls.Add(this.RichAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.BtnShowBank);
            this.groupBox1.Controls.Add(this.RichAccountNo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.RichBankName);
            this.groupBox1.Location = new System.Drawing.Point(17, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(865, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Share Capital",
            "Owner Equity"});
            this.comboBox2.Location = new System.Drawing.Point(117, 47);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(216, 28);
            this.comboBox2.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(11, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Deposit Type";
            // 
            // TxtBalance
            // 
            this.TxtBalance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtBalance.Enabled = false;
            this.TxtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalance.Location = new System.Drawing.Point(700, 46);
            this.TxtBalance.Name = "TxtBalance";
            this.TxtBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBalance.Size = new System.Drawing.Size(147, 29);
            this.TxtBalance.TabIndex = 28;
            // 
            // RichNarration
            // 
            this.RichNarration.Enabled = false;
            this.RichNarration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichNarration.Location = new System.Drawing.Point(104, 76);
            this.RichNarration.Name = "RichNarration";
            this.RichNarration.Size = new System.Drawing.Size(744, 30);
            this.RichNarration.TabIndex = 26;
            this.RichNarration.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(11, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Narration";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(598, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Deposit /Withdraw";
            // 
            // ComboAction
            // 
            this.ComboAction.Enabled = false;
            this.ComboAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboAction.FormattingEnabled = true;
            this.ComboAction.Items.AddRange(new object[] {
            "Deposit",
            "Withdrawal"});
            this.ComboAction.Location = new System.Drawing.Point(737, 16);
            this.ComboAction.Name = "ComboAction";
            this.ComboAction.Size = new System.Drawing.Size(110, 28);
            this.ComboAction.TabIndex = 22;
            // 
            // RichAmount
            // 
            this.RichAmount.BackColor = System.Drawing.Color.White;
            this.RichAmount.Enabled = false;
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(449, 45);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(136, 30);
            this.RichAmount.TabIndex = 19;
            this.RichAmount.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(378, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = " Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(607, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Balance";
            // 
            // BtnShowBank
            // 
            this.BtnShowBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnShowBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowBank.ForeColor = System.Drawing.Color.Red;
            this.BtnShowBank.Location = new System.Drawing.Point(336, 15);
            this.BtnShowBank.Name = "BtnShowBank";
            this.BtnShowBank.Size = new System.Drawing.Size(40, 30);
            this.BtnShowBank.TabIndex = 6;
            this.BtnShowBank.Text = "C";
            this.BtnShowBank.UseVisualStyleBackColor = true;
            this.BtnShowBank.Click += new System.EventHandler(this.BtnShowBank_Click);
            // 
            // RichAccountNo
            // 
            this.RichAccountNo.Enabled = false;
            this.RichAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAccountNo.Location = new System.Drawing.Point(450, 15);
            this.RichAccountNo.Name = "RichAccountNo";
            this.RichAccountNo.Size = new System.Drawing.Size(135, 30);
            this.RichAccountNo.TabIndex = 10;
            this.RichAccountNo.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(390, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "A/C No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(11, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Bank Name";
            // 
            // RichBankName
            // 
            this.RichBankName.Enabled = false;
            this.RichBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBankName.Location = new System.Drawing.Point(104, 16);
            this.RichBankName.Name = "RichBankName";
            this.RichBankName.Size = new System.Drawing.Size(230, 30);
            this.RichBankName.TabIndex = 3;
            this.RichBankName.Text = "";
            // 
            // BtnDeleteTransaction
            // 
            this.BtnDeleteTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteTransaction.ForeColor = System.Drawing.Color.Red;
            this.BtnDeleteTransaction.Location = new System.Drawing.Point(8, 58);
            this.BtnDeleteTransaction.Name = "BtnDeleteTransaction";
            this.BtnDeleteTransaction.Size = new System.Drawing.Size(125, 45);
            this.BtnDeleteTransaction.TabIndex = 29;
            this.BtnDeleteTransaction.Text = "Remove";
            this.BtnDeleteTransaction.UseVisualStyleBackColor = true;
            this.BtnDeleteTransaction.Click += new System.EventHandler(this.BtnDeleteTransaction_Click);
            // 
            // BtnSaveTransaction
            // 
            this.BtnSaveTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveTransaction.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSaveTransaction.Location = new System.Drawing.Point(8, 12);
            this.BtnSaveTransaction.Name = "BtnSaveTransaction";
            this.BtnSaveTransaction.Size = new System.Drawing.Size(125, 45);
            this.BtnSaveTransaction.TabIndex = 24;
            this.BtnSaveTransaction.Text = "Save  Transaction";
            this.BtnSaveTransaction.UseVisualStyleBackColor = true;
            this.BtnSaveTransaction.Click += new System.EventHandler(this.BtnSaveTransaction_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(275, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date To ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(49, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date From ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSaveBank);
            this.groupBox2.Controls.Add(this.BtnEditBank);
            this.groupBox2.Controls.Add(this.BtnUpdateBank);
            this.groupBox2.Controls.Add(this.BtnAddBank);
            this.groupBox2.Controls.Add(this.BtnDeleteBank);
            this.groupBox2.Location = new System.Drawing.Point(891, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 202);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // BtnSaveBank
            // 
            this.BtnSaveBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSaveBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveBank.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSaveBank.Location = new System.Drawing.Point(8, 49);
            this.BtnSaveBank.Name = "BtnSaveBank";
            this.BtnSaveBank.Size = new System.Drawing.Size(125, 35);
            this.BtnSaveBank.TabIndex = 9;
            this.BtnSaveBank.Text = "Save";
            this.BtnSaveBank.UseVisualStyleBackColor = true;
            this.BtnSaveBank.Click += new System.EventHandler(this.BtnSaveBank_Click);
            // 
            // BtnEditBank
            // 
            this.BtnEditBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditBank.ForeColor = System.Drawing.Color.Red;
            this.BtnEditBank.Location = new System.Drawing.Point(8, 86);
            this.BtnEditBank.Name = "BtnEditBank";
            this.BtnEditBank.Size = new System.Drawing.Size(125, 35);
            this.BtnEditBank.TabIndex = 6;
            this.BtnEditBank.Text = "Edit";
            this.BtnEditBank.UseVisualStyleBackColor = true;
            this.BtnEditBank.Click += new System.EventHandler(this.BtnEditBank_Click);
            // 
            // BtnUpdateBank
            // 
            this.BtnUpdateBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdateBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdateBank.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnUpdateBank.Location = new System.Drawing.Point(8, 123);
            this.BtnUpdateBank.Name = "BtnUpdateBank";
            this.BtnUpdateBank.Size = new System.Drawing.Size(125, 35);
            this.BtnUpdateBank.TabIndex = 7;
            this.BtnUpdateBank.Text = "Update";
            this.BtnUpdateBank.UseVisualStyleBackColor = true;
            this.BtnUpdateBank.Click += new System.EventHandler(this.BtnUpdateBank_Click);
            // 
            // BtnAddBank
            // 
            this.BtnAddBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddBank.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAddBank.Location = new System.Drawing.Point(8, 12);
            this.BtnAddBank.Name = "BtnAddBank";
            this.BtnAddBank.Size = new System.Drawing.Size(125, 35);
            this.BtnAddBank.TabIndex = 5;
            this.BtnAddBank.Text = "Add Bank";
            this.BtnAddBank.UseVisualStyleBackColor = true;
            this.BtnAddBank.Click += new System.EventHandler(this.BtnAddBank_Click);
            // 
            // BtnDeleteBank
            // 
            this.BtnDeleteBank.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BtnDeleteBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDeleteBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteBank.ForeColor = System.Drawing.Color.Red;
            this.BtnDeleteBank.Location = new System.Drawing.Point(8, 160);
            this.BtnDeleteBank.Name = "BtnDeleteBank";
            this.BtnDeleteBank.Size = new System.Drawing.Size(125, 35);
            this.BtnDeleteBank.TabIndex = 4;
            this.BtnDeleteBank.Text = "Delete";
            this.BtnDeleteBank.UseVisualStyleBackColor = false;
            this.BtnDeleteBank.Click += new System.EventHandler(this.BtnDeleteBank_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(342, 496);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 26);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(135, 495);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(120, 26);
            this.textBox4.TabIndex = 9;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(716, 496);
            this.textBox5.Name = "textBox5";
            this.textBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox5.Size = new System.Drawing.Size(125, 26);
            this.textBox5.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(613, 500);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = " Total Amount";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnDeleteTransaction);
            this.groupBox4.Controls.Add(this.BtnSaveTransaction);
            this.groupBox4.Location = new System.Drawing.Point(891, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 110);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // DataGridBankDetails
            // 
            this.DataGridBankDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridBankDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridBankDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridBankDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridBankDetails.Location = new System.Drawing.Point(17, 149);
            this.DataGridBankDetails.Name = "DataGridBankDetails";
            this.DataGridBankDetails.Size = new System.Drawing.Size(863, 327);
            this.DataGridBankDetails.TabIndex = 0;
            this.DataGridBankDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridBankDetails_DataBindingComplete);
            // 
            // BtnShowTransaction
            // 
            this.BtnShowTransaction.BackColor = System.Drawing.SystemColors.Control;
            this.BtnShowTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnShowTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowTransaction.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowTransaction.Location = new System.Drawing.Point(8, 13);
            this.BtnShowTransaction.Name = "BtnShowTransaction";
            this.BtnShowTransaction.Size = new System.Drawing.Size(125, 70);
            this.BtnShowTransaction.TabIndex = 21;
            this.BtnShowTransaction.Text = "Show Transaction";
            this.BtnShowTransaction.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Deposit",
            "Withdrawl"});
            this.comboBox1.Location = new System.Drawing.Point(469, 496);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 26);
            this.comboBox1.TabIndex = 22;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnShowTransaction);
            this.groupBox3.Location = new System.Drawing.Point(891, 426);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 90);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            // 
            // BankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.DataGridBankDetails);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "BankForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BankForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBankDetails)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnShowBank;
        private System.Windows.Forms.RichTextBox RichAccountNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox RichBankName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAddBank;
        private System.Windows.Forms.Button BtnSaveBank;
        private System.Windows.Forms.Button BtnEditBank;
        private System.Windows.Forms.Button BtnUpdateBank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox RichAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ComboAction;
        private System.Windows.Forms.Button BtnSaveTransaction;
        private System.Windows.Forms.RichTextBox RichNarration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtBalance;
        private System.Windows.Forms.Button BtnDeleteTransaction;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DataGridBankDetails;
        private System.Windows.Forms.Button BtnDeleteBank;
        private System.Windows.Forms.Button BtnShowTransaction;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label7;
    }
}