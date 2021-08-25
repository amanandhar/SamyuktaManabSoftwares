
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ComboAction = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnAddMember = new System.Windows.Forms.Button();
            this.BtnPaymentSave = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnShowSales = new System.Windows.Forms.Button();
            this.BtnClearAll = new System.Windows.Forms.Button();
            this.BtnShowTransaction = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.RichEmail = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtBalance = new System.Windows.Forms.TextBox();
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
            this.DataGridMemberList = new System.Windows.Forms.DataGridView();
            this.PicBoxMemberImage = new System.Windows.Forms.PictureBox();
            this.BtnAddImage = new System.Windows.Forms.Button();
            this.BtnDeleteImage = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.OpenMemberImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.MaskEndOfDayFrom = new System.Windows.Forms.MaskedTextBox();
            this.MaskEndOfDayTo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMemberList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxMemberImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboAction
            // 
            this.ComboAction.AutoCompleteCustomSource.AddRange(new string[] {
            "Deposit,Withdrawl,Purchase"});
            this.ComboAction.BackColor = System.Drawing.Color.White;
            this.ComboAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboAction.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ComboAction.FormattingEnabled = true;
            this.ComboAction.Items.AddRange(new object[] {
            "Sales",
            "Receipt"});
            this.ComboAction.Location = new System.Drawing.Point(467, 506);
            this.ComboAction.Name = "ComboAction";
            this.ComboAction.Size = new System.Drawing.Size(120, 26);
            this.ComboAction.TabIndex = 22;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnAddMember);
            this.groupBox3.Controls.Add(this.BtnPaymentSave);
            this.groupBox3.Controls.Add(this.BtnDelete);
            this.groupBox3.Controls.Add(this.BtnSave);
            this.groupBox3.Controls.Add(this.BtnEdit);
            this.groupBox3.Controls.Add(this.BtnUpdate);
            this.groupBox3.Controls.Add(this.BtnShowSales);
            this.groupBox3.Location = new System.Drawing.Point(891, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 275);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // BtnAddMember
            // 
            this.BtnAddMember.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnAddMember.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnAddMember.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAddMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddMember.ForeColor = System.Drawing.Color.Transparent;
            this.BtnAddMember.Location = new System.Drawing.Point(5, 85);
            this.BtnAddMember.Name = "BtnAddMember";
            this.BtnAddMember.Size = new System.Drawing.Size(130, 35);
            this.BtnAddMember.TabIndex = 14;
            this.BtnAddMember.Text = "Add Member";
            this.BtnAddMember.UseVisualStyleBackColor = false;
            this.BtnAddMember.Click += new System.EventHandler(this.BtnAddMember_Click);
            // 
            // BtnPaymentSave
            // 
            this.BtnPaymentSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnPaymentSave.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnPaymentSave.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnPaymentSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPaymentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPaymentSave.ForeColor = System.Drawing.Color.Transparent;
            this.BtnPaymentSave.Location = new System.Drawing.Point(5, 11);
            this.BtnPaymentSave.Name = "BtnPaymentSave";
            this.BtnPaymentSave.Size = new System.Drawing.Size(130, 35);
            this.BtnPaymentSave.TabIndex = 32;
            this.BtnPaymentSave.Text = "Save Receipt";
            this.BtnPaymentSave.UseVisualStyleBackColor = false;
            this.BtnPaymentSave.Click += new System.EventHandler(this.BtnPaymentSave_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.Transparent;
            this.BtnDelete.Location = new System.Drawing.Point(5, 233);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(130, 35);
            this.BtnDelete.TabIndex = 19;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnSave.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.Transparent;
            this.BtnSave.Location = new System.Drawing.Point(5, 122);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(130, 35);
            this.BtnSave.TabIndex = 15;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnEdit.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.Transparent;
            this.BtnEdit.Location = new System.Drawing.Point(5, 159);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(130, 35);
            this.BtnEdit.TabIndex = 16;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.Color.Transparent;
            this.BtnUpdate.Location = new System.Drawing.Point(5, 196);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(130, 35);
            this.BtnUpdate.TabIndex = 17;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnShowSales
            // 
            this.BtnShowSales.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnShowSales.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnShowSales.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowSales.ForeColor = System.Drawing.Color.Transparent;
            this.BtnShowSales.Location = new System.Drawing.Point(5, 48);
            this.BtnShowSales.Name = "BtnShowSales";
            this.BtnShowSales.Size = new System.Drawing.Size(130, 35);
            this.BtnShowSales.TabIndex = 25;
            this.BtnShowSales.Text = "Show Sales";
            this.BtnShowSales.UseVisualStyleBackColor = false;
            this.BtnShowSales.Click += new System.EventHandler(this.BtnShowSales_Click);
            // 
            // BtnClearAll
            // 
            this.BtnClearAll.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnClearAll.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnClearAll.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearAll.ForeColor = System.Drawing.Color.Transparent;
            this.BtnClearAll.Location = new System.Drawing.Point(771, 96);
            this.BtnClearAll.Name = "BtnClearAll";
            this.BtnClearAll.Size = new System.Drawing.Size(81, 28);
            this.BtnClearAll.TabIndex = 18;
            this.BtnClearAll.Text = "Clear All";
            this.BtnClearAll.UseVisualStyleBackColor = false;
            this.BtnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // BtnShowTransaction
            // 
            this.BtnShowTransaction.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnShowTransaction.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnShowTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowTransaction.ForeColor = System.Drawing.Color.Transparent;
            this.BtnShowTransaction.Location = new System.Drawing.Point(4, 12);
            this.BtnShowTransaction.Name = "BtnShowTransaction";
            this.BtnShowTransaction.Size = new System.Drawing.Size(147, 35);
            this.BtnShowTransaction.TabIndex = 24;
            this.BtnShowTransaction.Text = "Show Transaction";
            this.BtnShowTransaction.UseVisualStyleBackColor = false;
            this.BtnShowTransaction.Click += new System.EventHandler(this.BtnShowTransaction_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1045, 44);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = " Member Management";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(255, 510);
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
            this.label9.Location = new System.Drawing.Point(47, 509);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "Date From ";
            // 
            // TxtAmount
            // 
            this.TxtAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtAmount.Enabled = false;
            this.TxtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAmount.Location = new System.Drawing.Point(714, 506);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtAmount.Size = new System.Drawing.Size(130, 26);
            this.TxtAmount.TabIndex = 23;
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
            this.RichEmail.BackColor = System.Drawing.Color.White;
            this.RichEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichEmail.Location = new System.Drawing.Point(574, 13);
            this.RichEmail.Name = "RichEmail";
            this.RichEmail.ReadOnly = true;
            this.RichEmail.Size = new System.Drawing.Size(258, 26);
            this.RichEmail.TabIndex = 8;
            this.RichEmail.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(498, 17);
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
            this.label5.Location = new System.Drawing.Point(497, 70);
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
            this.label4.Location = new System.Drawing.Point(497, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Contact ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(27, 70);
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
            this.label2.Location = new System.Drawing.Point(26, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtBalance);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.ComboReceipt);
            this.groupBox1.Controls.Add(this.BtnClearAll);
            this.groupBox1.Controls.Add(this.RichAmount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ComboBank);
            this.groupBox1.Controls.Add(this.label6);
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
            this.groupBox1.Location = new System.Drawing.Point(17, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(858, 130);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // TxtBalance
            // 
            this.TxtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalance.Location = new System.Drawing.Point(574, 67);
            this.TxtBalance.Name = "TxtBalance";
            this.TxtBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBalance.Size = new System.Drawing.Size(192, 26);
            this.TxtBalance.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(204, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 20);
            this.label12.TabIndex = 31;
            this.label12.Text = "Bank";
            // 
            // ComboReceipt
            // 
            this.ComboReceipt.Enabled = false;
            this.ComboReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboReceipt.FormattingEnabled = true;
            this.ComboReceipt.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboReceipt.Location = new System.Drawing.Point(116, 95);
            this.ComboReceipt.Name = "ComboReceipt";
            this.ComboReceipt.Size = new System.Drawing.Size(85, 26);
            this.ComboReceipt.TabIndex = 5;
            this.ComboReceipt.SelectedValueChanged += new System.EventHandler(this.ComboPayment_SelectedValueChanged);
            // 
            // RichAmount
            // 
            this.RichAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RichAmount.Enabled = false;
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(574, 95);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(192, 28);
            this.RichAmount.TabIndex = 11;
            this.RichAmount.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(499, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Amount";
            // 
            // ComboBank
            // 
            this.ComboBank.Enabled = false;
            this.ComboBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBank.FormattingEnabled = true;
            this.ComboBank.Location = new System.Drawing.Point(253, 95);
            this.ComboBank.Name = "ComboBank";
            this.ComboBank.Size = new System.Drawing.Size(192, 26);
            this.ComboBank.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(27, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Receipt";
            // 
            // TxtBalanceStatus
            // 
            this.TxtBalanceStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtBalanceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalanceStatus.Location = new System.Drawing.Point(769, 67);
            this.TxtBalanceStatus.Name = "TxtBalanceStatus";
            this.TxtBalanceStatus.Size = new System.Drawing.Size(61, 26);
            this.TxtBalanceStatus.TabIndex = 10;
            // 
            // RichAccountNumber
            // 
            this.RichAccountNumber.BackColor = System.Drawing.Color.White;
            this.RichAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAccountNumber.Location = new System.Drawing.Point(238, 14);
            this.RichAccountNumber.Name = "RichAccountNumber";
            this.RichAccountNumber.ReadOnly = true;
            this.RichAccountNumber.Size = new System.Drawing.Size(88, 26);
            this.RichAccountNumber.TabIndex = 2;
            this.RichAccountNumber.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(199, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 20);
            this.label14.TabIndex = 23;
            this.label14.Text = "A/C ";
            // 
            // BtnShowMember
            // 
            this.BtnShowMember.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnShowMember.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnShowMember.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowMember.ForeColor = System.Drawing.Color.White;
            this.BtnShowMember.Location = new System.Drawing.Point(327, 13);
            this.BtnShowMember.Name = "BtnShowMember";
            this.BtnShowMember.Size = new System.Drawing.Size(73, 26);
            this.BtnShowMember.TabIndex = 5;
            this.BtnShowMember.Text = "Search";
            this.BtnShowMember.UseVisualStyleBackColor = false;
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
            this.RichContactNumber.BackColor = System.Drawing.Color.White;
            this.RichContactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichContactNumber.Location = new System.Drawing.Point(574, 40);
            this.RichContactNumber.Name = "RichContactNumber";
            this.RichContactNumber.Size = new System.Drawing.Size(193, 26);
            this.RichContactNumber.TabIndex = 7;
            this.RichContactNumber.Text = "";
            // 
            // RichAddress
            // 
            this.RichAddress.BackColor = System.Drawing.Color.White;
            this.RichAddress.Enabled = false;
            this.RichAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAddress.Location = new System.Drawing.Point(116, 68);
            this.RichAddress.Name = "RichAddress";
            this.RichAddress.ReadOnly = true;
            this.RichAddress.Size = new System.Drawing.Size(330, 26);
            this.RichAddress.TabIndex = 4;
            this.RichAddress.Text = "";
            // 
            // RichName
            // 
            this.RichName.BackColor = System.Drawing.Color.White;
            this.RichName.Enabled = false;
            this.RichName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichName.Location = new System.Drawing.Point(116, 41);
            this.RichName.Name = "RichName";
            this.RichName.ReadOnly = true;
            this.RichName.Size = new System.Drawing.Size(285, 26);
            this.RichName.TabIndex = 3;
            this.RichName.Text = "";
            // 
            // RichMemberId
            // 
            this.RichMemberId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RichMemberId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichMemberId.Location = new System.Drawing.Point(116, 14);
            this.RichMemberId.MaxLength = 5;
            this.RichMemberId.Name = "RichMemberId";
            this.RichMemberId.ReadOnly = true;
            this.RichMemberId.Size = new System.Drawing.Size(80, 26);
            this.RichMemberId.TabIndex = 1;
            this.RichMemberId.Text = "";
            // 
            // DataGridMemberList
            // 
            this.DataGridMemberList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DataGridMemberList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMemberList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridMemberList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridMemberList.Location = new System.Drawing.Point(16, 176);
            this.DataGridMemberList.Name = "DataGridMemberList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMemberList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridMemberList.Size = new System.Drawing.Size(858, 315);
            this.DataGridMemberList.TabIndex = 32;
            this.DataGridMemberList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridMemberTransactionList_DataBindingComplete);
            // 
            // PicBoxMemberImage
            // 
            this.PicBoxMemberImage.Location = new System.Drawing.Point(4, 9);
            this.PicBoxMemberImage.Name = "PicBoxMemberImage";
            this.PicBoxMemberImage.Size = new System.Drawing.Size(133, 133);
            this.PicBoxMemberImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxMemberImage.TabIndex = 33;
            this.PicBoxMemberImage.TabStop = false;
            // 
            // BtnAddImage
            // 
            this.BtnAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddImage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAddImage.Location = new System.Drawing.Point(905, 192);
            this.BtnAddImage.Name = "BtnAddImage";
            this.BtnAddImage.Size = new System.Drawing.Size(56, 25);
            this.BtnAddImage.TabIndex = 12;
            this.BtnAddImage.Text = "Add";
            this.BtnAddImage.UseVisualStyleBackColor = true;
            this.BtnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
            // 
            // BtnDeleteImage
            // 
            this.BtnDeleteImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteImage.ForeColor = System.Drawing.Color.Red;
            this.BtnDeleteImage.Location = new System.Drawing.Point(963, 192);
            this.BtnDeleteImage.Name = "BtnDeleteImage";
            this.BtnDeleteImage.Size = new System.Drawing.Size(56, 25);
            this.BtnDeleteImage.TabIndex = 13;
            this.BtnDeleteImage.Text = "Delete";
            this.BtnDeleteImage.UseVisualStyleBackColor = true;
            this.BtnDeleteImage.Click += new System.EventHandler(this.BtnDeleteImage_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PicBoxMemberImage);
            this.groupBox2.Location = new System.Drawing.Point(891, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 145);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnShowTransaction);
            this.groupBox4.Location = new System.Drawing.Point(876, 490);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(156, 52);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(615, 510);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 18);
            this.label13.TabIndex = 38;
            this.label13.Text = "Total Amount";
            // 
            // OpenMemberImageDialog
            // 
            this.OpenMemberImageDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenMemberImageDialog_FileOk);
            // 
            // MaskEndOfDayFrom
            // 
            this.MaskEndOfDayFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayFrom.Location = new System.Drawing.Point(134, 506);
            this.MaskEndOfDayFrom.Mask = "   0000-00-00";
            this.MaskEndOfDayFrom.Name = "MaskEndOfDayFrom";
            this.MaskEndOfDayFrom.Size = new System.Drawing.Size(105, 24);
            this.MaskEndOfDayFrom.TabIndex = 39;
            // 
            // MaskEndOfDayTo
            // 
            this.MaskEndOfDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayTo.Location = new System.Drawing.Point(329, 507);
            this.MaskEndOfDayTo.Mask = "   0000-00-00";
            this.MaskEndOfDayTo.Name = "MaskEndOfDayTo";
            this.MaskEndOfDayTo.Size = new System.Drawing.Size(105, 24);
            this.MaskEndOfDayTo.TabIndex = 40;
            // 
            // MemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.MaskEndOfDayTo);
            this.Controls.Add(this.MaskEndOfDayFrom);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnDeleteImage);
            this.Controls.Add(this.BtnAddImage);
            this.Controls.Add(this.DataGridMemberList);
            this.Controls.Add(this.ComboAction);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtAmount);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MemberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MemberForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMemberList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxMemberImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboAction;
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
        private System.Windows.Forms.TextBox TxtAmount;
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
        private System.Windows.Forms.RichTextBox RichAccountNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView DataGridMemberList;
        private System.Windows.Forms.PictureBox PicBoxMemberImage;
        private System.Windows.Forms.Button BtnAddImage;
        private System.Windows.Forms.Button BtnDeleteImage;
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
        private System.Windows.Forms.OpenFileDialog OpenMemberImageDialog;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayFrom;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayTo;
        private System.Windows.Forms.TextBox TxtBalance;
    }
}