
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
            this.TxtConfirmPassword = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.ComboUserType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnShow = new System.Windows.Forms.Button();
            this.RichUsername = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChkReadOnly = new System.Windows.Forms.CheckBox();
            this.ChkEOD = new System.Windows.Forms.CheckBox();
            this.ChkBank = new System.Windows.Forms.CheckBox();
            this.ChkEmployee = new System.Windows.Forms.CheckBox();
            this.ChkMember = new System.Windows.Forms.CheckBox();
            this.ChkStock = new System.Windows.Forms.CheckBox();
            this.ChkItemPricing = new System.Windows.Forms.CheckBox();
            this.ChkDailyExpense = new System.Windows.Forms.CheckBox();
            this.ChkSupplier = new System.Windows.Forms.CheckBox();
            this.ChkDailySummary = new System.Windows.Forms.CheckBox();
            this.ChkPOS = new System.Windows.Forms.CheckBox();
            this.ChkSetting = new System.Windows.Forms.CheckBox();
            this.ChkReport = new System.Windows.Forms.CheckBox();
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
            this.groupBox1.Controls.Add(this.TxtConfirmPassword);
            this.groupBox1.Controls.Add(this.TxtPassword);
            this.groupBox1.Controls.Add(this.ComboUserType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnShow);
            this.groupBox1.Controls.Add(this.RichUsername);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.groupBox1.Location = new System.Drawing.Point(236, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 110);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Information";
            // 
            // TxtConfirmPassword
            // 
            this.TxtConfirmPassword.Enabled = false;
            this.TxtConfirmPassword.Location = new System.Drawing.Point(435, 66);
            this.TxtConfirmPassword.Name = "TxtConfirmPassword";
            this.TxtConfirmPassword.Size = new System.Drawing.Size(170, 26);
            this.TxtConfirmPassword.TabIndex = 39;
            this.TxtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Enabled = false;
            this.TxtPassword.Location = new System.Drawing.Point(112, 66);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(170, 26);
            this.TxtPassword.TabIndex = 38;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // ComboUserType
            // 
            this.ComboUserType.Enabled = false;
            this.ComboUserType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboUserType.FormattingEnabled = true;
            this.ComboUserType.Items.AddRange(new object[] {
            "Please Select"});
            this.ComboUserType.Location = new System.Drawing.Point(435, 25);
            this.ComboUserType.Name = "ComboUserType";
            this.ComboUserType.Size = new System.Drawing.Size(170, 26);
            this.ComboUserType.TabIndex = 10;
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
            this.BtnShow.TabIndex = 8;
            this.BtnShow.Text = "C";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // RichUsername
            // 
            this.RichUsername.Enabled = false;
            this.RichUsername.Location = new System.Drawing.Point(112, 26);
            this.RichUsername.Name = "RichUsername";
            this.RichUsername.Size = new System.Drawing.Size(170, 30);
            this.RichUsername.TabIndex = 7;
            this.RichUsername.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkReadOnly);
            this.groupBox2.Controls.Add(this.ChkEOD);
            this.groupBox2.Controls.Add(this.ChkBank);
            this.groupBox2.Controls.Add(this.ChkEmployee);
            this.groupBox2.Controls.Add(this.ChkMember);
            this.groupBox2.Controls.Add(this.ChkStock);
            this.groupBox2.Controls.Add(this.ChkItemPricing);
            this.groupBox2.Controls.Add(this.ChkDailyExpense);
            this.groupBox2.Controls.Add(this.ChkSupplier);
            this.groupBox2.Controls.Add(this.ChkDailySummary);
            this.groupBox2.Controls.Add(this.ChkPOS);
            this.groupBox2.Controls.Add(this.ChkSetting);
            this.groupBox2.Controls.Add(this.ChkReport);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.groupBox2.Location = new System.Drawing.Point(236, 168);
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
            this.ChkReadOnly.Location = new System.Drawing.Point(226, 38);
            this.ChkReadOnly.Name = "ChkReadOnly";
            this.ChkReadOnly.Size = new System.Drawing.Size(102, 24);
            this.ChkReadOnly.TabIndex = 37;
            this.ChkReadOnly.Text = "Read Only";
            this.ChkReadOnly.UseVisualStyleBackColor = true;
            this.ChkReadOnly.CheckedChanged += new System.EventHandler(this.ChkReadOnly_CheckedChanged);
            // 
            // ChkEOD
            // 
            this.ChkEOD.AutoSize = true;
            this.ChkEOD.Enabled = false;
            this.ChkEOD.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkEOD.Location = new System.Drawing.Point(354, 261);
            this.ChkEOD.Name = "ChkEOD";
            this.ChkEOD.Size = new System.Drawing.Size(208, 24);
            this.ChkEOD.TabIndex = 36;
            this.ChkEOD.Text = "End Of Day Management";
            this.ChkEOD.UseVisualStyleBackColor = true;
            this.ChkEOD.CheckedChanged += new System.EventHandler(this.ChkEOD_CheckedChanged);
            // 
            // ChkBank
            // 
            this.ChkBank.AutoSize = true;
            this.ChkBank.Enabled = false;
            this.ChkBank.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkBank.Location = new System.Drawing.Point(354, 80);
            this.ChkBank.Name = "ChkBank";
            this.ChkBank.Size = new System.Drawing.Size(167, 24);
            this.ChkBank.TabIndex = 35;
            this.ChkBank.Text = "Bank  Management";
            this.ChkBank.UseVisualStyleBackColor = true;
            this.ChkBank.CheckedChanged += new System.EventHandler(this.ChkBank_CheckedChanged);
            // 
            // ChkEmployee
            // 
            this.ChkEmployee.AutoSize = true;
            this.ChkEmployee.Enabled = false;
            this.ChkEmployee.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkEmployee.Location = new System.Drawing.Point(354, 214);
            this.ChkEmployee.Name = "ChkEmployee";
            this.ChkEmployee.Size = new System.Drawing.Size(196, 24);
            this.ChkEmployee.TabIndex = 34;
            this.ChkEmployee.Text = "Employee Management";
            this.ChkEmployee.UseVisualStyleBackColor = true;
            this.ChkEmployee.CheckedChanged += new System.EventHandler(this.ChkEmployee_CheckedChanged);
            // 
            // ChkMember
            // 
            this.ChkMember.AutoSize = true;
            this.ChkMember.Enabled = false;
            this.ChkMember.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkMember.Location = new System.Drawing.Point(62, 124);
            this.ChkMember.Name = "ChkMember";
            this.ChkMember.Size = new System.Drawing.Size(213, 24);
            this.ChkMember.TabIndex = 33;
            this.ChkMember.Text = "Membership Management";
            this.ChkMember.UseVisualStyleBackColor = true;
            this.ChkMember.CheckedChanged += new System.EventHandler(this.ChkMember_CheckedChanged);
            // 
            // ChkStock
            // 
            this.ChkStock.AutoSize = true;
            this.ChkStock.Enabled = false;
            this.ChkStock.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkStock.Location = new System.Drawing.Point(62, 261);
            this.ChkStock.Name = "ChkStock";
            this.ChkStock.Size = new System.Drawing.Size(236, 24);
            this.ChkStock.TabIndex = 32;
            this.ChkStock.Text = "Stock Inventary Management";
            this.ChkStock.UseVisualStyleBackColor = true;
            this.ChkStock.CheckedChanged += new System.EventHandler(this.ChkStock_CheckedChanged);
            // 
            // ChkItemPricing
            // 
            this.ChkItemPricing.AutoSize = true;
            this.ChkItemPricing.Enabled = false;
            this.ChkItemPricing.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkItemPricing.Location = new System.Drawing.Point(62, 214);
            this.ChkItemPricing.Name = "ChkItemPricing";
            this.ChkItemPricing.Size = new System.Drawing.Size(209, 24);
            this.ChkItemPricing.TabIndex = 31;
            this.ChkItemPricing.Text = "Item Pricing Management";
            this.ChkItemPricing.UseVisualStyleBackColor = true;
            this.ChkItemPricing.CheckedChanged += new System.EventHandler(this.ChkItemPricing_CheckedChanged);
            // 
            // ChkDailyExpense
            // 
            this.ChkDailyExpense.AutoSize = true;
            this.ChkDailyExpense.Enabled = false;
            this.ChkDailyExpense.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkDailyExpense.Location = new System.Drawing.Point(354, 38);
            this.ChkDailyExpense.Name = "ChkDailyExpense";
            this.ChkDailyExpense.Size = new System.Drawing.Size(226, 24);
            this.ChkDailyExpense.TabIndex = 30;
            this.ChkDailyExpense.Text = "Daily Expense Management";
            this.ChkDailyExpense.UseVisualStyleBackColor = true;
            this.ChkDailyExpense.CheckedChanged += new System.EventHandler(this.ChkDailyExpense_CheckedChanged);
            // 
            // ChkSupplier
            // 
            this.ChkSupplier.AutoSize = true;
            this.ChkSupplier.Enabled = false;
            this.ChkSupplier.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkSupplier.Location = new System.Drawing.Point(62, 168);
            this.ChkSupplier.Name = "ChkSupplier";
            this.ChkSupplier.Size = new System.Drawing.Size(213, 24);
            this.ChkSupplier.TabIndex = 29;
            this.ChkSupplier.Text = "Suppliership Management";
            this.ChkSupplier.UseVisualStyleBackColor = true;
            this.ChkSupplier.CheckedChanged += new System.EventHandler(this.ChkSupplier_CheckedChanged);
            // 
            // ChkDailySummary
            // 
            this.ChkDailySummary.AutoSize = true;
            this.ChkDailySummary.Enabled = false;
            this.ChkDailySummary.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkDailySummary.Location = new System.Drawing.Point(62, 80);
            this.ChkDailySummary.Name = "ChkDailySummary";
            this.ChkDailySummary.Size = new System.Drawing.Size(231, 24);
            this.ChkDailySummary.TabIndex = 28;
            this.ChkDailySummary.Text = "Daily Summary Management";
            this.ChkDailySummary.UseVisualStyleBackColor = true;
            this.ChkDailySummary.CheckedChanged += new System.EventHandler(this.ChkDailySummary_CheckedChanged);
            // 
            // ChkPOS
            // 
            this.ChkPOS.AutoSize = true;
            this.ChkPOS.Enabled = false;
            this.ChkPOS.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkPOS.Location = new System.Drawing.Point(62, 38);
            this.ChkPOS.Name = "ChkPOS";
            this.ChkPOS.Size = new System.Drawing.Size(159, 24);
            this.ChkPOS.TabIndex = 27;
            this.ChkPOS.Text = "POS Management";
            this.ChkPOS.UseVisualStyleBackColor = true;
            this.ChkPOS.CheckedChanged += new System.EventHandler(this.ChkPOS_CheckedChanged);
            // 
            // ChkSetting
            // 
            this.ChkSetting.AutoSize = true;
            this.ChkSetting.Enabled = false;
            this.ChkSetting.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkSetting.Location = new System.Drawing.Point(354, 124);
            this.ChkSetting.Name = "ChkSetting";
            this.ChkSetting.Size = new System.Drawing.Size(198, 24);
            this.ChkSetting.TabIndex = 26;
            this.ChkSetting.Text = "All Setting Management";
            this.ChkSetting.UseVisualStyleBackColor = true;
            this.ChkSetting.CheckedChanged += new System.EventHandler(this.ChkSetting_CheckedChanged);
            // 
            // ChkReport
            // 
            this.ChkReport.AutoSize = true;
            this.ChkReport.Enabled = false;
            this.ChkReport.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkReport.Location = new System.Drawing.Point(354, 168);
            this.ChkReport.Name = "ChkReport";
            this.ChkReport.Size = new System.Drawing.Size(196, 24);
            this.ChkReport.TabIndex = 25;
            this.ChkReport.Text = "All Report Management";
            this.ChkReport.UseVisualStyleBackColor = true;
            this.ChkReport.CheckedChanged += new System.EventHandler(this.ChkReport_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnDelete);
            this.groupBox3.Controls.Add(this.BtnUpdate);
            this.groupBox3.Controls.Add(this.BtnEdit);
            this.groupBox3.Controls.Add(this.BtnSave);
            this.groupBox3.Controls.Add(this.BtnAdd);
            this.groupBox3.Location = new System.Drawing.Point(236, 473);
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
            this.BtnDelete.Location = new System.Drawing.Point(506, 23);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(125, 35);
            this.BtnDelete.TabIndex = 9;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.TextColor = System.Drawing.Color.White;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnUpdate.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.BtnUpdate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnUpdate.BorderRadius = 35;
            this.BtnUpdate.BorderSize = 0;
            this.BtnUpdate.FlatAppearance.BorderSize = 0;
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnUpdate.Location = new System.Drawing.Point(381, 24);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(125, 35);
            this.BtnUpdate.TabIndex = 8;
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
            this.BtnEdit.Size = new System.Drawing.Size(125, 35);
            this.BtnEdit.TabIndex = 7;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.TextColor = System.Drawing.Color.White;
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnSave.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.BtnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSave.BorderRadius = 35;
            this.BtnSave.BorderSize = 0;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(129, 23);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(125, 35);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Save";
            this.BtnSave.TextColor = System.Drawing.Color.White;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnAdd.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.BtnAdd.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAdd.BorderRadius = 35;
            this.BtnAdd.BorderSize = 0;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(4, 24);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(125, 35);
            this.BtnAdd.TabIndex = 5;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.TextColor = System.Drawing.Color.White;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1104, 44);
            this.textBox1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Highlight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Cyan;
            this.label6.Location = new System.Drawing.Point(443, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 33);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
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
        private System.Windows.Forms.RichTextBox RichUsername;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ChkBank;
        private System.Windows.Forms.CheckBox ChkEmployee;
        private System.Windows.Forms.CheckBox ChkMember;
        private System.Windows.Forms.CheckBox ChkStock;
        private System.Windows.Forms.CheckBox ChkItemPricing;
        private System.Windows.Forms.CheckBox ChkSupplier;
        private System.Windows.Forms.CheckBox ChkDailySummary;
        private System.Windows.Forms.CheckBox ChkPOS;
        private System.Windows.Forms.CheckBox ChkSetting;
        private System.Windows.Forms.CheckBox ChkReport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ChkDailyExpense;
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
    }
}