
namespace GrocerySupplyManagementApp.Forms
{
    partial class MemberForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnAddMember = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnClearAll = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnShowSales = new System.Windows.Forms.Button();
            this.BtnShowTransaction = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBoxDateTo = new System.Windows.Forms.TextBox();
            this.TxtBoxDateFrom = new System.Windows.Forms.TextBox();
            this.TextBoxTotal = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.RichEmail = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnPaymentSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.ComboReceipt = new System.Windows.Forms.ComboBox();
            this.RichAmount = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ComboBank = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtBalanceStatus = new System.Windows.Forms.TextBox();
            this.RichAccountNumber = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.BtnShowMember = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RichContactNumber = new System.Windows.Forms.RichTextBox();
            this.RichAddress = new System.Windows.Forms.RichTextBox();
            this.RichName = new System.Windows.Forms.RichTextBox();
            this.RichMemberId = new System.Windows.Forms.RichTextBox();
            this.RichBalance = new System.Windows.Forms.RichTextBox();
            this.DataGridMemberTransactionList = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMemberTransactionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "Deposit,Withdrawl,Purchase"});
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sales",
            "Reciept"});
            this.comboBox1.Location = new System.Drawing.Point(473, 498);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 26);
            this.comboBox1.TabIndex = 22;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnAddMember);
            this.groupBox3.Controls.Add(this.BtnDelete);
            this.groupBox3.Controls.Add(this.BtnClearAll);
            this.groupBox3.Controls.Add(this.BtnSave);
            this.groupBox3.Controls.Add(this.BtnEdit);
            this.groupBox3.Controls.Add(this.BtnUpdate);
            this.groupBox3.Location = new System.Drawing.Point(891, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 235);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // BtnAddMember
            // 
            this.BtnAddMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddMember.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAddMember.Location = new System.Drawing.Point(5, 9);
            this.BtnAddMember.Name = "BtnAddMember";
            this.BtnAddMember.Size = new System.Drawing.Size(130, 35);
            this.BtnAddMember.TabIndex = 14;
            this.BtnAddMember.Text = "Add Member";
            this.BtnAddMember.UseVisualStyleBackColor = true;
            this.BtnAddMember.Click += new System.EventHandler(this.BtnAddMember_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.Red;
            this.BtnDelete.Location = new System.Drawing.Point(5, 194);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(130, 35);
            this.BtnDelete.TabIndex = 19;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnClearAll
            // 
            this.BtnClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnClearAll.Location = new System.Drawing.Point(5, 157);
            this.BtnClearAll.Name = "BtnClearAll";
            this.BtnClearAll.Size = new System.Drawing.Size(130, 35);
            this.BtnClearAll.TabIndex = 18;
            this.BtnClearAll.Text = "Clear All";
            this.BtnClearAll.UseVisualStyleBackColor = true;
            this.BtnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSave.Location = new System.Drawing.Point(5, 46);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(130, 35);
            this.BtnSave.TabIndex = 15;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.Red;
            this.BtnEdit.Location = new System.Drawing.Point(5, 83);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(130, 35);
            this.BtnEdit.TabIndex = 16;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnUpdate.Location = new System.Drawing.Point(5, 120);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(130, 35);
            this.BtnUpdate.TabIndex = 17;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnShowSales
            // 
            this.BtnShowSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowSales.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowSales.Location = new System.Drawing.Point(686, 43);
            this.BtnShowSales.Name = "BtnShowSales";
            this.BtnShowSales.Size = new System.Drawing.Size(158, 32);
            this.BtnShowSales.TabIndex = 25;
            this.BtnShowSales.Text = "Show Sales";
            this.BtnShowSales.UseVisualStyleBackColor = true;
            this.BtnShowSales.Click += new System.EventHandler(this.BtnShowSales_Click);
            // 
            // BtnShowTransaction
            // 
            this.BtnShowTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowTransaction.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowTransaction.Location = new System.Drawing.Point(5, 12);
            this.BtnShowTransaction.Name = "BtnShowTransaction";
            this.BtnShowTransaction.Size = new System.Drawing.Size(130, 60);
            this.BtnShowTransaction.TabIndex = 24;
            this.BtnShowTransaction.Text = "Show Transaction";
            this.BtnShowTransaction.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1045, 26);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "                                                                                 " +
    "    \r\n   Member Details";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(272, 501);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 18);
            this.label10.TabIndex = 29;
            this.label10.Text = " Date To ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(55, 499);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "Date From ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(539, 503);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 18);
            this.label11.TabIndex = 30;
            this.label11.Text = "Total ";
            // 
            // TextBoxDateTo
            // 
            this.TextBoxDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDateTo.Location = new System.Drawing.Point(344, 498);
            this.TextBoxDateTo.Name = "TextBoxDateTo";
            this.TextBoxDateTo.Size = new System.Drawing.Size(120, 26);
            this.TextBoxDateTo.TabIndex = 21;
            // 
            // TxtBoxDateFrom
            // 
            this.TxtBoxDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxDateFrom.Location = new System.Drawing.Point(141, 496);
            this.TxtBoxDateFrom.Name = "TxtBoxDateFrom";
            this.TxtBoxDateFrom.Size = new System.Drawing.Size(120, 26);
            this.TxtBoxDateFrom.TabIndex = 20;
            // 
            // TextBoxTotal
            // 
            this.TextBoxTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotal.Location = new System.Drawing.Point(724, 498);
            this.TextBoxTotal.Name = "TextBoxTotal";
            this.TextBoxTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TextBoxTotal.Size = new System.Drawing.Size(130, 26);
            this.TextBoxTotal.TabIndex = 23;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBox2.Location = new System.Drawing.Point(-7, -46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1050, 35);
            this.textBox2.TabIndex = 27;
            this.textBox2.Text = "                                                       \r\n \r\n     \r\nMember Details" +
    "\r\n";
            // 
            // RichEmail
            // 
            this.RichEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichEmail.Location = new System.Drawing.Point(543, 13);
            this.RichEmail.Name = "RichEmail";
            this.RichEmail.Size = new System.Drawing.Size(301, 30);
            this.RichEmail.TabIndex = 8;
            this.RichEmail.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(471, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(466, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Balance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(451, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Contact No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(27, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(26, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnPaymentSave);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.ComboReceipt);
            this.groupBox1.Controls.Add(this.RichAmount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ComboBank);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BtnShowSales);
            this.groupBox1.Controls.Add(this.TxtBalanceStatus);
            this.groupBox1.Controls.Add(this.RichAccountNumber);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.BtnShowMember);
            this.groupBox1.Controls.Add(this.RichEmail);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RichContactNumber);
            this.groupBox1.Controls.Add(this.RichAddress);
            this.groupBox1.Controls.Add(this.RichName);
            this.groupBox1.Controls.Add(this.RichMemberId);
            this.groupBox1.Controls.Add(this.RichBalance);
            this.groupBox1.Location = new System.Drawing.Point(17, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(858, 145);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // BtnPaymentSave
            // 
            this.BtnPaymentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPaymentSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnPaymentSave.Location = new System.Drawing.Point(686, 107);
            this.BtnPaymentSave.Name = "BtnPaymentSave";
            this.BtnPaymentSave.Size = new System.Drawing.Size(158, 32);
            this.BtnPaymentSave.TabIndex = 32;
            this.BtnPaymentSave.Text = "Save Receipt";
            this.BtnPaymentSave.UseVisualStyleBackColor = true;
            this.BtnPaymentSave.Click += new System.EventHandler(this.BtnPaymentSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(197, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 20);
            this.label12.TabIndex = 31;
            this.label12.Text = "Bank";
            // 
            // ComboReceipt
            // 
            this.ComboReceipt.Enabled = false;
            this.ComboReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboReceipt.FormattingEnabled = true;
            this.ComboReceipt.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboReceipt.Location = new System.Drawing.Point(116, 108);
            this.ComboReceipt.Name = "ComboReceipt";
            this.ComboReceipt.Size = new System.Drawing.Size(80, 28);
            this.ComboReceipt.TabIndex = 5;
            this.ComboReceipt.SelectedValueChanged += new System.EventHandler(this.ComboPayment_SelectedValueChanged);
            // 
            // RichAmount
            // 
            this.RichAmount.Enabled = false;
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(543, 108);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(139, 30);
            this.RichAmount.TabIndex = 11;
            this.RichAmount.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(475, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Amount";
            // 
            // ComboBank
            // 
            this.ComboBank.Enabled = false;
            this.ComboBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBank.FormattingEnabled = true;
            this.ComboBank.Location = new System.Drawing.Point(244, 108);
            this.ComboBank.Name = "ComboBank";
            this.ComboBank.Size = new System.Drawing.Size(225, 28);
            this.ComboBank.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(26, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Receipt";
            // 
            // TxtBalanceStatus
            // 
            this.TxtBalanceStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtBalanceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalanceStatus.Location = new System.Drawing.Point(686, 78);
            this.TxtBalanceStatus.Name = "TxtBalanceStatus";
            this.TxtBalanceStatus.Size = new System.Drawing.Size(50, 27);
            this.TxtBalanceStatus.TabIndex = 10;
            // 
            // RichAccountNumber
            // 
            this.RichAccountNumber.BackColor = System.Drawing.Color.White;
            this.RichAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAccountNumber.Location = new System.Drawing.Point(249, 14);
            this.RichAccountNumber.Name = "RichAccountNumber";
            this.RichAccountNumber.Size = new System.Drawing.Size(120, 30);
            this.RichAccountNumber.TabIndex = 2;
            this.RichAccountNumber.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(208, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 20);
            this.label14.TabIndex = 23;
            this.label14.Text = "A/C ";
            // 
            // BtnShowMember
            // 
            this.BtnShowMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowMember.ForeColor = System.Drawing.Color.Red;
            this.BtnShowMember.Location = new System.Drawing.Point(370, 13);
            this.BtnShowMember.Name = "BtnShowMember";
            this.BtnShowMember.Size = new System.Drawing.Size(40, 30);
            this.BtnShowMember.TabIndex = 5;
            this.BtnShowMember.Text = "C";
            this.BtnShowMember.UseVisualStyleBackColor = true;
            this.BtnShowMember.Click += new System.EventHandler(this.BtnShowMember_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Member ID";
            // 
            // RichContactNumber
            // 
            this.RichContactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichContactNumber.Location = new System.Drawing.Point(543, 44);
            this.RichContactNumber.Name = "RichContactNumber";
            this.RichContactNumber.Size = new System.Drawing.Size(139, 30);
            this.RichContactNumber.TabIndex = 7;
            this.RichContactNumber.Text = "";
            // 
            // RichAddress
            // 
            this.RichAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAddress.Location = new System.Drawing.Point(116, 76);
            this.RichAddress.Name = "RichAddress";
            this.RichAddress.Size = new System.Drawing.Size(294, 30);
            this.RichAddress.TabIndex = 4;
            this.RichAddress.Text = "";
            // 
            // RichName
            // 
            this.RichName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichName.Location = new System.Drawing.Point(116, 45);
            this.RichName.Name = "RichName";
            this.RichName.Size = new System.Drawing.Size(294, 30);
            this.RichName.TabIndex = 3;
            this.RichName.Text = "";
            // 
            // RichMemberId
            // 
            this.RichMemberId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichMemberId.Location = new System.Drawing.Point(116, 14);
            this.RichMemberId.MaxLength = 5;
            this.RichMemberId.Name = "RichMemberId";
            this.RichMemberId.Size = new System.Drawing.Size(80, 30);
            this.RichMemberId.TabIndex = 1;
            this.RichMemberId.Text = "";
            // 
            // RichBalance
            // 
            this.RichBalance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichBalance.Enabled = false;
            this.RichBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBalance.Location = new System.Drawing.Point(543, 76);
            this.RichBalance.Name = "RichBalance";
            this.RichBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichBalance.Size = new System.Drawing.Size(139, 30);
            this.RichBalance.TabIndex = 9;
            this.RichBalance.Text = "";
            // 
            // DataGridMemberTransactionList
            // 
            this.DataGridMemberTransactionList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridMemberTransactionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridMemberTransactionList.Location = new System.Drawing.Point(18, 181);
            this.DataGridMemberTransactionList.Name = "DataGridMemberTransactionList";
            this.DataGridMemberTransactionList.Size = new System.Drawing.Size(858, 300);
            this.DataGridMemberTransactionList.TabIndex = 32;
            this.DataGridMemberTransactionList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridMemberTransactionList_DataBindingComplete);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 140);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(905, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 25);
            this.button1.TabIndex = 12;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(963, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 25);
            this.button2.TabIndex = 13;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(891, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 152);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnShowTransaction);
            this.groupBox4.Location = new System.Drawing.Point(891, 453);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 80);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(625, 502);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 18);
            this.label13.TabIndex = 38;
            this.label13.Text = "Total Amount";
            // 
            // MemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DataGridMemberTransactionList);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TextBoxDateTo);
            this.Controls.Add(this.TxtBoxDateFrom);
            this.Controls.Add(this.TextBoxTotal);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MemberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MemberForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMemberTransactionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnAddMember;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnClearAll;
        private System.Windows.Forms.Button BtnShowTransaction;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TextBoxDateTo;
        private System.Windows.Forms.TextBox TxtBoxDateFrom;
        private System.Windows.Forms.TextBox TextBoxTotal;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox RichEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnShowMember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RichContactNumber;
        private System.Windows.Forms.RichTextBox RichAddress;
        private System.Windows.Forms.RichTextBox RichName;
        private System.Windows.Forms.RichTextBox RichMemberId;
        private System.Windows.Forms.RichTextBox RichBalance;
        private System.Windows.Forms.RichTextBox RichAccountNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView DataGridMemberTransactionList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnShowSales;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtBalanceStatus;
        private System.Windows.Forms.RichTextBox RichAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ComboBank;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ComboReceipt;
        private System.Windows.Forms.Button BtnPaymentSave;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
    }
}