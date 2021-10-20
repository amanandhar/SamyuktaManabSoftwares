
namespace GrocerySupplyManagementApp.Forms
{
    partial class UserForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.TxtConfirmPassword = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.ComboUserType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnShow = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChkReadOnly = new System.Windows.Forms.CheckBox();
            this.ChkEOD = new System.Windows.Forms.CheckBox();
            this.ChkBank = new System.Windows.Forms.CheckBox();
            this.ChkEmployee = new System.Windows.Forms.CheckBox();
            this.ChkMember = new System.Windows.Forms.CheckBox();
            this.ChkStockSummary = new System.Windows.Forms.CheckBox();
            this.ChkItemPricing = new System.Windows.Forms.CheckBox();
            this.ChkDailyTransaction = new System.Windows.Forms.CheckBox();
            this.ChkSupplier = new System.Windows.Forms.CheckBox();
            this.ChkDailySummary = new System.Windows.Forms.CheckBox();
            this.ChkPOS = new System.Windows.Forms.CheckBox();
            this.ChkSettings = new System.Windows.Forms.CheckBox();
            this.ChkReports = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnUpdate = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnEdit = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSave = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAdd = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(19, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(30, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(296, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Confirm Password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtUsername);
            this.groupBox1.Controls.Add(this.TxtConfirmPassword);
            this.groupBox1.Controls.Add(this.TxtPassword);
            this.groupBox1.Controls.Add(this.ComboUserType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnShow);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(236, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 110);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Information";
            // 
            // TxtUsername
            // 
            this.TxtUsername.Enabled = false;
            this.TxtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsername.Location = new System.Drawing.Point(112, 23);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(170, 29);
            this.TxtUsername.TabIndex = 0;
            // 
            // TxtConfirmPassword
            // 
            this.TxtConfirmPassword.Enabled = false;
            this.TxtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConfirmPassword.Location = new System.Drawing.Point(435, 60);
            this.TxtConfirmPassword.Name = "TxtConfirmPassword";
            this.TxtConfirmPassword.Size = new System.Drawing.Size(170, 29);
            this.TxtConfirmPassword.TabIndex = 4;
            this.TxtConfirmPassword.UseSystemPasswordChar = true;
            this.TxtConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtConfirmPassword_KeyDown);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Enabled = false;
            this.TxtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.Location = new System.Drawing.Point(112, 60);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(170, 29);
            this.TxtPassword.TabIndex = 3;
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // ComboUserType
            // 
            this.ComboUserType.Enabled = false;
            this.ComboUserType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboUserType.FormattingEnabled = true;
            this.ComboUserType.Location = new System.Drawing.Point(435, 22);
            this.ComboUserType.Name = "ComboUserType";
            this.ComboUserType.Size = new System.Drawing.Size(170, 32);
            this.ComboUserType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(344, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "User Type";
            // 
            // BtnShow
            // 
            this.BtnShow.Location = new System.Drawing.Point(284, 25);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(40, 29);
            this.BtnShow.TabIndex = 1;
            this.BtnShow.Text = "C";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkReadOnly);
            this.groupBox2.Controls.Add(this.ChkEOD);
            this.groupBox2.Controls.Add(this.ChkBank);
            this.groupBox2.Controls.Add(this.ChkEmployee);
            this.groupBox2.Controls.Add(this.ChkMember);
            this.groupBox2.Controls.Add(this.ChkStockSummary);
            this.groupBox2.Controls.Add(this.ChkItemPricing);
            this.groupBox2.Controls.Add(this.ChkDailyTransaction);
            this.groupBox2.Controls.Add(this.ChkSupplier);
            this.groupBox2.Controls.Add(this.ChkDailySummary);
            this.groupBox2.Controls.Add(this.ChkPOS);
            this.groupBox2.Controls.Add(this.ChkSettings);
            this.groupBox2.Controls.Add(this.ChkReports);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(236, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(640, 300);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Permission";
            // 
            // ChkReadOnly
            // 
            this.ChkReadOnly.AutoSize = true;
            this.ChkReadOnly.Enabled = false;
            this.ChkReadOnly.Location = new System.Drawing.Point(34, 21);
            this.ChkReadOnly.Name = "ChkReadOnly";
            this.ChkReadOnly.Size = new System.Drawing.Size(91, 20);
            this.ChkReadOnly.TabIndex = 5;
            this.ChkReadOnly.Text = "Read Only";
            this.ChkReadOnly.UseVisualStyleBackColor = true;
            this.ChkReadOnly.CheckedChanged += new System.EventHandler(this.ChkReadOnly_CheckedChanged);
            // 
            // ChkEOD
            // 
            this.ChkEOD.AutoSize = true;
            this.ChkEOD.Enabled = false;
            this.ChkEOD.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkEOD.Location = new System.Drawing.Point(34, 150);
            this.ChkEOD.Name = "ChkEOD";
            this.ChkEOD.Size = new System.Drawing.Size(95, 20);
            this.ChkEOD.TabIndex = 10;
            this.ChkEOD.Text = "End Of Day";
            this.ChkEOD.UseVisualStyleBackColor = true;
            this.ChkEOD.CheckedChanged += new System.EventHandler(this.ChkEOD_CheckedChanged);
            // 
            // ChkBank
            // 
            this.ChkBank.AutoSize = true;
            this.ChkBank.Enabled = false;
            this.ChkBank.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkBank.Location = new System.Drawing.Point(34, 47);
            this.ChkBank.Name = "ChkBank";
            this.ChkBank.Size = new System.Drawing.Size(58, 20);
            this.ChkBank.TabIndex = 6;
            this.ChkBank.Text = "Bank";
            this.ChkBank.UseVisualStyleBackColor = true;
            this.ChkBank.CheckedChanged += new System.EventHandler(this.ChkBank_CheckedChanged);
            // 
            // ChkEmployee
            // 
            this.ChkEmployee.AutoSize = true;
            this.ChkEmployee.Enabled = false;
            this.ChkEmployee.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkEmployee.Location = new System.Drawing.Point(34, 124);
            this.ChkEmployee.Name = "ChkEmployee";
            this.ChkEmployee.Size = new System.Drawing.Size(89, 20);
            this.ChkEmployee.TabIndex = 9;
            this.ChkEmployee.Text = "Employee";
            this.ChkEmployee.UseVisualStyleBackColor = true;
            this.ChkEmployee.CheckedChanged += new System.EventHandler(this.ChkEmployee_CheckedChanged);
            // 
            // ChkMember
            // 
            this.ChkMember.AutoSize = true;
            this.ChkMember.Enabled = false;
            this.ChkMember.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkMember.Location = new System.Drawing.Point(348, 47);
            this.ChkMember.Name = "ChkMember";
            this.ChkMember.Size = new System.Drawing.Size(77, 20);
            this.ChkMember.TabIndex = 12;
            this.ChkMember.Text = "Member";
            this.ChkMember.UseVisualStyleBackColor = true;
            this.ChkMember.CheckedChanged += new System.EventHandler(this.ChkMember_CheckedChanged);
            // 
            // ChkStockSummary
            // 
            this.ChkStockSummary.AutoSize = true;
            this.ChkStockSummary.Enabled = false;
            this.ChkStockSummary.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkStockSummary.Location = new System.Drawing.Point(348, 150);
            this.ChkStockSummary.Name = "ChkStockSummary";
            this.ChkStockSummary.Size = new System.Drawing.Size(121, 20);
            this.ChkStockSummary.TabIndex = 16;
            this.ChkStockSummary.Text = "Stock Summary";
            this.ChkStockSummary.UseVisualStyleBackColor = true;
            this.ChkStockSummary.CheckedChanged += new System.EventHandler(this.ChkStock_CheckedChanged);
            // 
            // ChkItemPricing
            // 
            this.ChkItemPricing.AutoSize = true;
            this.ChkItemPricing.Enabled = false;
            this.ChkItemPricing.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkItemPricing.Location = new System.Drawing.Point(34, 176);
            this.ChkItemPricing.Name = "ChkItemPricing";
            this.ChkItemPricing.Size = new System.Drawing.Size(96, 20);
            this.ChkItemPricing.TabIndex = 11;
            this.ChkItemPricing.Text = "Item Pricing";
            this.ChkItemPricing.UseVisualStyleBackColor = true;
            this.ChkItemPricing.CheckedChanged += new System.EventHandler(this.ChkItemPricing_CheckedChanged);
            // 
            // ChkDailyTransaction
            // 
            this.ChkDailyTransaction.AutoSize = true;
            this.ChkDailyTransaction.Enabled = false;
            this.ChkDailyTransaction.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkDailyTransaction.Location = new System.Drawing.Point(34, 98);
            this.ChkDailyTransaction.Name = "ChkDailyTransaction";
            this.ChkDailyTransaction.Size = new System.Drawing.Size(132, 20);
            this.ChkDailyTransaction.TabIndex = 8;
            this.ChkDailyTransaction.Text = "Daily Transaction";
            this.ChkDailyTransaction.UseVisualStyleBackColor = true;
            this.ChkDailyTransaction.CheckedChanged += new System.EventHandler(this.ChkDailyExpense_CheckedChanged);
            // 
            // ChkSupplier
            // 
            this.ChkSupplier.AutoSize = true;
            this.ChkSupplier.Enabled = false;
            this.ChkSupplier.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkSupplier.Location = new System.Drawing.Point(348, 176);
            this.ChkSupplier.Name = "ChkSupplier";
            this.ChkSupplier.Size = new System.Drawing.Size(77, 20);
            this.ChkSupplier.TabIndex = 17;
            this.ChkSupplier.Text = "Supplier";
            this.ChkSupplier.UseVisualStyleBackColor = true;
            this.ChkSupplier.CheckedChanged += new System.EventHandler(this.ChkSupplier_CheckedChanged);
            // 
            // ChkDailySummary
            // 
            this.ChkDailySummary.AutoSize = true;
            this.ChkDailySummary.Enabled = false;
            this.ChkDailySummary.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkDailySummary.Location = new System.Drawing.Point(34, 73);
            this.ChkDailySummary.Name = "ChkDailySummary";
            this.ChkDailySummary.Size = new System.Drawing.Size(118, 20);
            this.ChkDailySummary.TabIndex = 7;
            this.ChkDailySummary.Text = "Daily Summary";
            this.ChkDailySummary.UseVisualStyleBackColor = true;
            this.ChkDailySummary.CheckedChanged += new System.EventHandler(this.ChkDailySummary_CheckedChanged);
            // 
            // ChkPOS
            // 
            this.ChkPOS.AutoSize = true;
            this.ChkPOS.Enabled = false;
            this.ChkPOS.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkPOS.Location = new System.Drawing.Point(348, 73);
            this.ChkPOS.Name = "ChkPOS";
            this.ChkPOS.Size = new System.Drawing.Size(55, 20);
            this.ChkPOS.TabIndex = 13;
            this.ChkPOS.Text = "POS";
            this.ChkPOS.UseVisualStyleBackColor = true;
            this.ChkPOS.CheckedChanged += new System.EventHandler(this.ChkPOS_CheckedChanged);
            // 
            // ChkSettings
            // 
            this.ChkSettings.AutoSize = true;
            this.ChkSettings.Enabled = false;
            this.ChkSettings.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkSettings.Location = new System.Drawing.Point(348, 125);
            this.ChkSettings.Name = "ChkSettings";
            this.ChkSettings.Size = new System.Drawing.Size(75, 20);
            this.ChkSettings.TabIndex = 15;
            this.ChkSettings.Text = "Settings";
            this.ChkSettings.UseVisualStyleBackColor = true;
            this.ChkSettings.CheckedChanged += new System.EventHandler(this.ChkSetting_CheckedChanged);
            // 
            // ChkReports
            // 
            this.ChkReports.AutoSize = true;
            this.ChkReports.Enabled = false;
            this.ChkReports.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkReports.Location = new System.Drawing.Point(348, 99);
            this.ChkReports.Name = "ChkReports";
            this.ChkReports.Size = new System.Drawing.Size(75, 20);
            this.ChkReports.TabIndex = 14;
            this.ChkReports.Text = "Reports";
            this.ChkReports.UseVisualStyleBackColor = true;
            this.ChkReports.CheckedChanged += new System.EventHandler(this.ChkReport_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnDelete);
            this.groupBox3.Controls.Add(this.BtnUpdate);
            this.groupBox3.Controls.Add(this.BtnEdit);
            this.groupBox3.Controls.Add(this.BtnSave);
            this.groupBox3.Controls.Add(this.BtnAdd);
            this.groupBox3.Location = new System.Drawing.Point(236, 487);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(640, 79);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
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
            this.BtnDelete.Location = new System.Drawing.Point(497, 23);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(120, 35);
            this.BtnDelete.TabIndex = 22;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.TextColor = System.Drawing.Color.White;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdate.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnUpdate.BorderRadius = 35;
            this.BtnUpdate.BorderSize = 0;
            this.BtnUpdate.FlatAppearance.BorderSize = 0;
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnUpdate.Location = new System.Drawing.Point(376, 24);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(120, 35);
            this.BtnUpdate.TabIndex = 21;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.TextColor = System.Drawing.Color.White;
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.Red;
            this.BtnEdit.BackgroundColor = System.Drawing.Color.Red;
            this.BtnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnEdit.BorderRadius = 35;
            this.BtnEdit.BorderSize = 0;
            this.BtnEdit.FlatAppearance.BorderSize = 0;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(255, 23);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(120, 35);
            this.BtnEdit.TabIndex = 20;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.TextColor = System.Drawing.Color.White;
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSave.BorderRadius = 35;
            this.BtnSave.BorderSize = 0;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(134, 23);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(120, 35);
            this.BtnSave.TabIndex = 19;
            this.BtnSave.Text = "Save";
            this.BtnSave.TextColor = System.Drawing.Color.White;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAdd.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAdd.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAdd.BorderRadius = 35;
            this.BtnAdd.BorderSize = 0;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(13, 24);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 35);
            this.BtnAdd.TabIndex = 18;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.TextColor = System.Drawing.Color.White;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1104, 44);
            this.textBox1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DodgerBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Cyan;
            this.label6.Location = new System.Drawing.Point(445, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(251, 31);
            this.label6.TabIndex = 8;
            this.label6.Text = "User Management";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1088, 597);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Location = new System.Drawing.Point(725, 241);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ChkBank;
        private System.Windows.Forms.CheckBox ChkEmployee;
        private System.Windows.Forms.CheckBox ChkMember;
        private System.Windows.Forms.CheckBox ChkStockSummary;
        private System.Windows.Forms.CheckBox ChkItemPricing;
        private System.Windows.Forms.CheckBox ChkSupplier;
        private System.Windows.Forms.CheckBox ChkDailySummary;
        private System.Windows.Forms.CheckBox ChkPOS;
        private System.Windows.Forms.CheckBox ChkSettings;
        private System.Windows.Forms.CheckBox ChkReports;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ChkDailyTransaction;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.CheckBox ChkEOD;
        private System.Windows.Forms.CheckBox ChkReadOnly;
        private System.Windows.Forms.ComboBox ComboUserType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtConfirmPassword;
        private System.Windows.Forms.TextBox TxtPassword;
        private CustomControls.Button.CustomButton BtnAdd;
        private CustomControls.Button.CustomButton BtnDelete;
        private CustomControls.Button.CustomButton BtnUpdate;
        private CustomControls.Button.CustomButton BtnEdit;
        private CustomControls.Button.CustomButton BtnSave;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtUsername;
    }
}