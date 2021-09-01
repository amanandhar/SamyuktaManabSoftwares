
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtBalance = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ComboActionType = new System.Windows.Forms.ComboBox();
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
            this.BtnShowTransaction = new System.Windows.Forms.Button();
            this.BtnSaveBank = new System.Windows.Forms.Button();
            this.BtnEditBank = new System.Windows.Forms.Button();
            this.BtnUpdateBank = new System.Windows.Forms.Button();
            this.BtnAddBank = new System.Windows.Forms.Button();
            this.BtnDeleteBank = new System.Windows.Forms.Button();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DataGridBankList = new System.Windows.Forms.DataGridView();
            this.ComboAction = new System.Windows.Forms.ComboBox();
            this.MaskEndOfDayFrom = new System.Windows.Forms.MaskedTextBox();
            this.MaskEndOfDayTo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBankList)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.ComboType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtBalance);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.ComboActionType);
            this.groupBox1.Controls.Add(this.RichAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.BtnShowBank);
            this.groupBox1.Controls.Add(this.RichAccountNo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.RichBankName);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 89);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // ComboType
            // 
            this.ComboType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboType.FormattingEnabled = true;
            this.ComboType.Items.AddRange(new object[] {
            "Share Capital",
            "Owner Equity"});
            this.ComboType.Location = new System.Drawing.Point(104, 50);
            this.ComboType.Name = "ComboType";
            this.ComboType.Size = new System.Drawing.Size(220, 26);
            this.ComboType.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(61, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "Type";
            // 
            // TxtBalance
            // 
            this.TxtBalance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtBalance.Enabled = false;
            this.TxtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalance.Location = new System.Drawing.Point(733, 50);
            this.TxtBalance.Name = "TxtBalance";
            this.TxtBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBalance.Size = new System.Drawing.Size(120, 27);
            this.TxtBalance.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(597, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 18);
            this.label11.TabIndex = 23;
            this.label11.Text = "Deposit / Withdraw";
            // 
            // ComboActionType
            // 
            this.ComboActionType.Enabled = false;
            this.ComboActionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboActionType.FormattingEnabled = true;
            this.ComboActionType.Items.AddRange(new object[] {
            "Deposit",
            "Withdrawal"});
            this.ComboActionType.Location = new System.Drawing.Point(733, 16);
            this.ComboActionType.Name = "ComboActionType";
            this.ComboActionType.Size = new System.Drawing.Size(120, 26);
            this.ComboActionType.TabIndex = 22;
            // 
            // RichAmount
            // 
            this.RichAmount.BackColor = System.Drawing.Color.White;
            this.RichAmount.Enabled = false;
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(459, 50);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(135, 28);
            this.RichAmount.TabIndex = 19;
            this.RichAmount.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(394, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = " Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(662, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Balance";
            // 
            // BtnShowBank
            // 
            this.BtnShowBank.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnShowBank.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnShowBank.BackgroundImage")));
            this.BtnShowBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnShowBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnShowBank.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnShowBank.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowBank.ForeColor = System.Drawing.Color.Cyan;
            this.BtnShowBank.Location = new System.Drawing.Point(324, 15);
            this.BtnShowBank.Name = "BtnShowBank";
            this.BtnShowBank.Size = new System.Drawing.Size(70, 29);
            this.BtnShowBank.TabIndex = 6;
            this.BtnShowBank.Text = "Search";
            this.BtnShowBank.UseVisualStyleBackColor = false;
            this.BtnShowBank.Click += new System.EventHandler(this.BtnShowBank_Click);
            // 
            // RichAccountNo
            // 
            this.RichAccountNo.Enabled = false;
            this.RichAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAccountNo.Location = new System.Drawing.Point(459, 15);
            this.RichAccountNo.Name = "RichAccountNo";
            this.RichAccountNo.Size = new System.Drawing.Size(135, 28);
            this.RichAccountNo.TabIndex = 10;
            this.RichAccountNo.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(400, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "A/C No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(16, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Bank Name";
            // 
            // RichBankName
            // 
            this.RichBankName.Enabled = false;
            this.RichBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBankName.Location = new System.Drawing.Point(104, 16);
            this.RichBankName.Name = "RichBankName";
            this.RichBankName.Size = new System.Drawing.Size(220, 28);
            this.RichBankName.TabIndex = 3;
            this.RichBankName.Text = "";
            // 
            // BtnDeleteTransaction
            // 
            this.BtnDeleteTransaction.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnDeleteTransaction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnDeleteTransaction.BackgroundImage")));
            this.BtnDeleteTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDeleteTransaction.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnDeleteTransaction.FlatAppearance.BorderSize = 2;
            this.BtnDeleteTransaction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnDeleteTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnDeleteTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteTransaction.ForeColor = System.Drawing.Color.Red;
            this.BtnDeleteTransaction.Location = new System.Drawing.Point(8, 51);
            this.BtnDeleteTransaction.Name = "BtnDeleteTransaction";
            this.BtnDeleteTransaction.Size = new System.Drawing.Size(125, 42);
            this.BtnDeleteTransaction.TabIndex = 29;
            this.BtnDeleteTransaction.Text = "Remove";
            this.BtnDeleteTransaction.UseVisualStyleBackColor = false;
            this.BtnDeleteTransaction.Click += new System.EventHandler(this.BtnDeleteTransaction_Click);
            // 
            // BtnSaveTransaction
            // 
            this.BtnSaveTransaction.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnSaveTransaction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSaveTransaction.BackgroundImage")));
            this.BtnSaveTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSaveTransaction.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnSaveTransaction.FlatAppearance.BorderSize = 2;
            this.BtnSaveTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSaveTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveTransaction.ForeColor = System.Drawing.Color.Cyan;
            this.BtnSaveTransaction.Location = new System.Drawing.Point(8, 10);
            this.BtnSaveTransaction.Name = "BtnSaveTransaction";
            this.BtnSaveTransaction.Size = new System.Drawing.Size(125, 40);
            this.BtnSaveTransaction.TabIndex = 24;
            this.BtnSaveTransaction.Text = "Save  ";
            this.BtnSaveTransaction.UseVisualStyleBackColor = false;
            this.BtnSaveTransaction.Click += new System.EventHandler(this.BtnSaveTransaction_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(264, 499);
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
            this.label2.Location = new System.Drawing.Point(46, 499);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date From ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnShowTransaction);
            this.groupBox2.Controls.Add(this.BtnSaveBank);
            this.groupBox2.Controls.Add(this.BtnEditBank);
            this.groupBox2.Controls.Add(this.BtnUpdateBank);
            this.groupBox2.Controls.Add(this.BtnAddBank);
            this.groupBox2.Controls.Add(this.BtnDeleteBank);
            this.groupBox2.Location = new System.Drawing.Point(891, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 350);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // BtnShowTransaction
            // 
            this.BtnShowTransaction.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnShowTransaction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnShowTransaction.BackgroundImage")));
            this.BtnShowTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnShowTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnShowTransaction.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnShowTransaction.FlatAppearance.BorderSize = 2;
            this.BtnShowTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowTransaction.ForeColor = System.Drawing.Color.Cyan;
            this.BtnShowTransaction.Location = new System.Drawing.Point(6, 304);
            this.BtnShowTransaction.Name = "BtnShowTransaction";
            this.BtnShowTransaction.Size = new System.Drawing.Size(125, 40);
            this.BtnShowTransaction.TabIndex = 21;
            this.BtnShowTransaction.Text = "Show Transaction";
            this.BtnShowTransaction.UseVisualStyleBackColor = false;
            this.BtnShowTransaction.Click += new System.EventHandler(this.BtnShowTransaction_Click);
            // 
            // BtnSaveBank
            // 
            this.BtnSaveBank.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnSaveBank.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSaveBank.BackgroundImage")));
            this.BtnSaveBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSaveBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSaveBank.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnSaveBank.FlatAppearance.BorderSize = 2;
            this.BtnSaveBank.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSaveBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveBank.ForeColor = System.Drawing.Color.Cyan;
            this.BtnSaveBank.Location = new System.Drawing.Point(8, 55);
            this.BtnSaveBank.Name = "BtnSaveBank";
            this.BtnSaveBank.Size = new System.Drawing.Size(125, 40);
            this.BtnSaveBank.TabIndex = 9;
            this.BtnSaveBank.Text = "Save";
            this.BtnSaveBank.UseVisualStyleBackColor = false;
            this.BtnSaveBank.Click += new System.EventHandler(this.BtnSaveBank_Click);
            // 
            // BtnEditBank
            // 
            this.BtnEditBank.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnEditBank.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnEditBank.BackgroundImage")));
            this.BtnEditBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnEditBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditBank.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnEditBank.FlatAppearance.BorderSize = 2;
            this.BtnEditBank.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnEditBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditBank.ForeColor = System.Drawing.Color.Red;
            this.BtnEditBank.Location = new System.Drawing.Point(8, 96);
            this.BtnEditBank.Name = "BtnEditBank";
            this.BtnEditBank.Size = new System.Drawing.Size(125, 40);
            this.BtnEditBank.TabIndex = 6;
            this.BtnEditBank.Text = "Edit";
            this.BtnEditBank.UseVisualStyleBackColor = false;
            this.BtnEditBank.Click += new System.EventHandler(this.BtnEditBank_Click);
            // 
            // BtnUpdateBank
            // 
            this.BtnUpdateBank.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnUpdateBank.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnUpdateBank.BackgroundImage")));
            this.BtnUpdateBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnUpdateBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdateBank.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnUpdateBank.FlatAppearance.BorderSize = 2;
            this.BtnUpdateBank.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnUpdateBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdateBank.ForeColor = System.Drawing.Color.Cyan;
            this.BtnUpdateBank.Location = new System.Drawing.Point(8, 137);
            this.BtnUpdateBank.Name = "BtnUpdateBank";
            this.BtnUpdateBank.Size = new System.Drawing.Size(125, 40);
            this.BtnUpdateBank.TabIndex = 7;
            this.BtnUpdateBank.Text = "Update";
            this.BtnUpdateBank.UseVisualStyleBackColor = false;
            this.BtnUpdateBank.Click += new System.EventHandler(this.BtnUpdateBank_Click);
            // 
            // BtnAddBank
            // 
            this.BtnAddBank.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnAddBank.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnAddBank.BackgroundImage")));
            this.BtnAddBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAddBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddBank.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnAddBank.FlatAppearance.BorderSize = 2;
            this.BtnAddBank.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAddBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddBank.ForeColor = System.Drawing.Color.Cyan;
            this.BtnAddBank.Location = new System.Drawing.Point(8, 14);
            this.BtnAddBank.Name = "BtnAddBank";
            this.BtnAddBank.Size = new System.Drawing.Size(125, 40);
            this.BtnAddBank.TabIndex = 5;
            this.BtnAddBank.Text = "Add Bank";
            this.BtnAddBank.UseVisualStyleBackColor = false;
            this.BtnAddBank.Click += new System.EventHandler(this.BtnAddBank_Click);
            // 
            // BtnDeleteBank
            // 
            this.BtnDeleteBank.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnDeleteBank.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnDeleteBank.BackgroundImage")));
            this.BtnDeleteBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDeleteBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDeleteBank.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnDeleteBank.FlatAppearance.BorderSize = 2;
            this.BtnDeleteBank.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnDeleteBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteBank.ForeColor = System.Drawing.Color.Red;
            this.BtnDeleteBank.Location = new System.Drawing.Point(8, 178);
            this.BtnDeleteBank.Name = "BtnDeleteBank";
            this.BtnDeleteBank.Size = new System.Drawing.Size(125, 40);
            this.BtnDeleteBank.TabIndex = 4;
            this.BtnDeleteBank.Text = "Delete";
            this.BtnDeleteBank.UseVisualStyleBackColor = false;
            this.BtnDeleteBank.Click += new System.EventHandler(this.BtnDeleteBank_Click);
            // 
            // TxtAmount
            // 
            this.TxtAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtAmount.Enabled = false;
            this.TxtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAmount.Location = new System.Drawing.Point(719, 496);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtAmount.Size = new System.Drawing.Size(125, 26);
            this.TxtAmount.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(616, 500);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = " Total Amount";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnDeleteTransaction);
            this.groupBox4.Controls.Add(this.BtnSaveTransaction);
            this.groupBox4.Location = new System.Drawing.Point(891, 45);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 100);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // DataGridBankList
            // 
            this.DataGridBankList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DataGridBankList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridBankList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridBankList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridBankList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridBankList.Location = new System.Drawing.Point(12, 137);
            this.DataGridBankList.Name = "DataGridBankList";
            this.DataGridBankList.Size = new System.Drawing.Size(870, 342);
            this.DataGridBankList.TabIndex = 0;
            this.DataGridBankList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridBankDetails_DataBindingComplete);
            // 
            // ComboAction
            // 
            this.ComboAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboAction.FormattingEnabled = true;
            this.ComboAction.Items.AddRange(new object[] {
            "Deposit",
            "Withdrawl"});
            this.ComboAction.Location = new System.Drawing.Point(475, 496);
            this.ComboAction.Name = "ComboAction";
            this.ComboAction.Size = new System.Drawing.Size(125, 26);
            this.ComboAction.TabIndex = 22;
            // 
            // MaskEndOfDayFrom
            // 
            this.MaskEndOfDayFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayFrom.Location = new System.Drawing.Point(133, 496);
            this.MaskEndOfDayFrom.Mask = "   0000-00-00";
            this.MaskEndOfDayFrom.Name = "MaskEndOfDayFrom";
            this.MaskEndOfDayFrom.Size = new System.Drawing.Size(105, 24);
            this.MaskEndOfDayFrom.TabIndex = 22;
            // 
            // MaskEndOfDayTo
            // 
            this.MaskEndOfDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayTo.Location = new System.Drawing.Point(333, 496);
            this.MaskEndOfDayTo.Mask = "   0000-00-00";
            this.MaskEndOfDayTo.Name = "MaskEndOfDayTo";
            this.MaskEndOfDayTo.Size = new System.Drawing.Size(105, 24);
            this.MaskEndOfDayTo.TabIndex = 24;
            // 
            // groupBox5
            // 
            this.groupBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox5.BackgroundImage")));
            this.groupBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(-4, -1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1046, 45);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Cyan;
            this.label4.Location = new System.Drawing.Point(397, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "Banking Management";
            // 
            // BankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.MaskEndOfDayTo);
            this.Controls.Add(this.MaskEndOfDayFrom);
            this.Controls.Add(this.ComboAction);
            this.Controls.Add(this.DataGridBankList);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtAmount);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "BankForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BankForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBankList)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ComboActionType;
        private System.Windows.Forms.Button BtnSaveTransaction;
        private System.Windows.Forms.TextBox TxtBalance;
        private System.Windows.Forms.Button BtnDeleteTransaction;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DataGridBankList;
        private System.Windows.Forms.Button BtnDeleteBank;
        private System.Windows.Forms.Button BtnShowTransaction;
        private System.Windows.Forms.ComboBox ComboAction;
        private System.Windows.Forms.ComboBox ComboType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayFrom;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayTo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
    }
}