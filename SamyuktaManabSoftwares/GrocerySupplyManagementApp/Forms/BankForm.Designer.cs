
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtAccountNo = new System.Windows.Forms.TextBox();
            this.TxtBankName = new System.Windows.Forms.TextBox();
            this.BtnSearchBank = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtBalance = new System.Windows.Forms.TextBox();
            this.ComboType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ComboTransaction = new System.Windows.Forms.ComboBox();
            this.RichAmount = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDeleteBank = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnUpdateBank = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnEditBank = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSaveBank = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddBank = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnRemoveTransaction = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSaveTransaction = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.DataGridBankList = new System.Windows.Forms.DataGridView();
            this.ComboAction = new System.Windows.Forms.ComboBox();
            this.MaskEndOfDayFrom = new System.Windows.Forms.MaskedTextBox();
            this.MaskEndOfDayTo = new System.Windows.Forms.MaskedTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnShowTransaction = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBankList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.TxtAccountNo);
            this.groupBox1.Controls.Add(this.TxtBankName);
            this.groupBox1.Controls.Add(this.BtnSearchBank);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtBalance);
            this.groupBox1.Controls.Add(this.ComboType);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.ComboTransaction);
            this.groupBox1.Controls.Add(this.RichAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(14, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1074, 89);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bank Details";
            // 
            // TxtAccountNo
            // 
            this.TxtAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAccountNo.Location = new System.Drawing.Point(127, 50);
            this.TxtAccountNo.Name = "TxtAccountNo";
            this.TxtAccountNo.Size = new System.Drawing.Size(213, 26);
            this.TxtAccountNo.TabIndex = 34;
            // 
            // TxtBankName
            // 
            this.TxtBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBankName.Location = new System.Drawing.Point(127, 18);
            this.TxtBankName.Name = "TxtBankName";
            this.TxtBankName.Size = new System.Drawing.Size(213, 26);
            this.TxtBankName.TabIndex = 33;
            // 
            // BtnSearchBank
            // 
            this.BtnSearchBank.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchBank.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchBank.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSearchBank.BorderRadius = 10;
            this.BtnSearchBank.BorderSize = 0;
            this.BtnSearchBank.FlatAppearance.BorderSize = 0;
            this.BtnSearchBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchBank.ForeColor = System.Drawing.Color.White;
            this.BtnSearchBank.Location = new System.Drawing.Point(341, 16);
            this.BtnSearchBank.Name = "BtnSearchBank";
            this.BtnSearchBank.Size = new System.Drawing.Size(70, 28);
            this.BtnSearchBank.TabIndex = 32;
            this.BtnSearchBank.Text = "Search";
            this.BtnSearchBank.TextColor = System.Drawing.Color.White;
            this.BtnSearchBank.UseVisualStyleBackColor = false;
            this.BtnSearchBank.Click += new System.EventHandler(this.BtnSearchBank_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(803, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "Type";
            // 
            // TxtBalance
            // 
            this.TxtBalance.BackColor = System.Drawing.Color.White;
            this.TxtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalance.Location = new System.Drawing.Point(864, 49);
            this.TxtBalance.Name = "TxtBalance";
            this.TxtBalance.ReadOnly = true;
            this.TxtBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBalance.Size = new System.Drawing.Size(188, 27);
            this.TxtBalance.TabIndex = 28;
            // 
            // ComboType
            // 
            this.ComboType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboType.FormattingEnabled = true;
            this.ComboType.Location = new System.Drawing.Point(864, 16);
            this.ComboType.Name = "ComboType";
            this.ComboType.Size = new System.Drawing.Size(188, 26);
            this.ComboType.TabIndex = 30;
            this.ComboType.SelectedValueChanged += new System.EventHandler(this.ComboType_SelectedValueChanged);
            this.ComboType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboType_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(442, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 18);
            this.label11.TabIndex = 23;
            this.label11.Text = "Deposit / Withdraw";
            // 
            // ComboTransaction
            // 
            this.ComboTransaction.Enabled = false;
            this.ComboTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboTransaction.FormattingEnabled = true;
            this.ComboTransaction.Location = new System.Drawing.Point(579, 16);
            this.ComboTransaction.Name = "ComboTransaction";
            this.ComboTransaction.Size = new System.Drawing.Size(190, 26);
            this.ComboTransaction.TabIndex = 22;
            this.ComboTransaction.SelectedValueChanged += new System.EventHandler(this.ComboTransaction_SelectedValueChanged);
            this.ComboTransaction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboTransaction_KeyPress);
            // 
            // RichAmount
            // 
            this.RichAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RichAmount.Enabled = false;
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(579, 50);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(190, 28);
            this.RichAmount.TabIndex = 19;
            this.RichAmount.Text = "";
            this.RichAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichAmount_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(442, 54);
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
            this.label8.Location = new System.Drawing.Point(787, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Balance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(37, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Account No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(38, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Bank Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(223, 21);
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
            this.label2.Location = new System.Drawing.Point(33, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date From ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDeleteBank);
            this.groupBox2.Controls.Add(this.BtnUpdateBank);
            this.groupBox2.Controls.Add(this.BtnEditBank);
            this.groupBox2.Controls.Add(this.BtnSaveBank);
            this.groupBox2.Controls.Add(this.BtnAddBank);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(949, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 215);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Bank";
            // 
            // BtnDeleteBank
            // 
            this.BtnDeleteBank.BackColor = System.Drawing.Color.Red;
            this.BtnDeleteBank.BackgroundColor = System.Drawing.Color.Red;
            this.BtnDeleteBank.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnDeleteBank.BorderRadius = 35;
            this.BtnDeleteBank.BorderSize = 0;
            this.BtnDeleteBank.FlatAppearance.BorderSize = 0;
            this.BtnDeleteBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeleteBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteBank.ForeColor = System.Drawing.Color.White;
            this.BtnDeleteBank.Location = new System.Drawing.Point(10, 169);
            this.BtnDeleteBank.Name = "BtnDeleteBank";
            this.BtnDeleteBank.Size = new System.Drawing.Size(120, 35);
            this.BtnDeleteBank.TabIndex = 36;
            this.BtnDeleteBank.Text = "Delete";
            this.BtnDeleteBank.TextColor = System.Drawing.Color.White;
            this.BtnDeleteBank.UseVisualStyleBackColor = false;
            this.BtnDeleteBank.Click += new System.EventHandler(this.BtnDeleteBank_Click);
            // 
            // BtnUpdateBank
            // 
            this.BtnUpdateBank.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdateBank.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdateBank.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnUpdateBank.BorderRadius = 35;
            this.BtnUpdateBank.BorderSize = 0;
            this.BtnUpdateBank.FlatAppearance.BorderSize = 0;
            this.BtnUpdateBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdateBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdateBank.ForeColor = System.Drawing.Color.White;
            this.BtnUpdateBank.Location = new System.Drawing.Point(10, 133);
            this.BtnUpdateBank.Name = "BtnUpdateBank";
            this.BtnUpdateBank.Size = new System.Drawing.Size(120, 35);
            this.BtnUpdateBank.TabIndex = 35;
            this.BtnUpdateBank.Text = "Update";
            this.BtnUpdateBank.TextColor = System.Drawing.Color.White;
            this.BtnUpdateBank.UseVisualStyleBackColor = false;
            this.BtnUpdateBank.Click += new System.EventHandler(this.BtnUpdateBank_Click);
            // 
            // BtnEditBank
            // 
            this.BtnEditBank.BackColor = System.Drawing.Color.Red;
            this.BtnEditBank.BackgroundColor = System.Drawing.Color.Red;
            this.BtnEditBank.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnEditBank.BorderRadius = 35;
            this.BtnEditBank.BorderSize = 0;
            this.BtnEditBank.FlatAppearance.BorderSize = 0;
            this.BtnEditBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditBank.ForeColor = System.Drawing.Color.White;
            this.BtnEditBank.Location = new System.Drawing.Point(10, 97);
            this.BtnEditBank.Name = "BtnEditBank";
            this.BtnEditBank.Size = new System.Drawing.Size(120, 35);
            this.BtnEditBank.TabIndex = 34;
            this.BtnEditBank.Text = "Edit";
            this.BtnEditBank.TextColor = System.Drawing.Color.White;
            this.BtnEditBank.UseVisualStyleBackColor = false;
            this.BtnEditBank.Click += new System.EventHandler(this.BtnEditBank_Click);
            // 
            // BtnSaveBank
            // 
            this.BtnSaveBank.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveBank.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveBank.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSaveBank.BorderRadius = 35;
            this.BtnSaveBank.BorderSize = 0;
            this.BtnSaveBank.FlatAppearance.BorderSize = 0;
            this.BtnSaveBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveBank.ForeColor = System.Drawing.Color.White;
            this.BtnSaveBank.Location = new System.Drawing.Point(10, 61);
            this.BtnSaveBank.Name = "BtnSaveBank";
            this.BtnSaveBank.Size = new System.Drawing.Size(120, 35);
            this.BtnSaveBank.TabIndex = 33;
            this.BtnSaveBank.Text = "Save";
            this.BtnSaveBank.TextColor = System.Drawing.Color.White;
            this.BtnSaveBank.UseVisualStyleBackColor = false;
            this.BtnSaveBank.Click += new System.EventHandler(this.BtnSaveBank_Click);
            // 
            // BtnAddBank
            // 
            this.BtnAddBank.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddBank.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddBank.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddBank.BorderRadius = 35;
            this.BtnAddBank.BorderSize = 0;
            this.BtnAddBank.FlatAppearance.BorderSize = 0;
            this.BtnAddBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddBank.ForeColor = System.Drawing.Color.White;
            this.BtnAddBank.Location = new System.Drawing.Point(10, 25);
            this.BtnAddBank.Name = "BtnAddBank";
            this.BtnAddBank.Size = new System.Drawing.Size(120, 35);
            this.BtnAddBank.TabIndex = 32;
            this.BtnAddBank.Text = "Add Bank";
            this.BtnAddBank.TextColor = System.Drawing.Color.White;
            this.BtnAddBank.UseVisualStyleBackColor = false;
            this.BtnAddBank.Click += new System.EventHandler(this.BtnAddBank_Click);
            // 
            // TxtAmount
            // 
            this.TxtAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtAmount.Enabled = false;
            this.TxtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAmount.Location = new System.Drawing.Point(627, 19);
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
            this.label10.Location = new System.Drawing.Point(523, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = " Total Amount";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnRemoveTransaction);
            this.groupBox4.Controls.Add(this.BtnSaveTransaction);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(949, 134);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 105);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Transaction";
            // 
            // BtnRemoveTransaction
            // 
            this.BtnRemoveTransaction.BackColor = System.Drawing.Color.Red;
            this.BtnRemoveTransaction.BackgroundColor = System.Drawing.Color.Red;
            this.BtnRemoveTransaction.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnRemoveTransaction.BorderRadius = 35;
            this.BtnRemoveTransaction.BorderSize = 0;
            this.BtnRemoveTransaction.FlatAppearance.BorderSize = 0;
            this.BtnRemoveTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemoveTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemoveTransaction.ForeColor = System.Drawing.Color.White;
            this.BtnRemoveTransaction.Location = new System.Drawing.Point(10, 56);
            this.BtnRemoveTransaction.Name = "BtnRemoveTransaction";
            this.BtnRemoveTransaction.Size = new System.Drawing.Size(120, 35);
            this.BtnRemoveTransaction.TabIndex = 31;
            this.BtnRemoveTransaction.Text = "Remove";
            this.BtnRemoveTransaction.TextColor = System.Drawing.Color.White;
            this.BtnRemoveTransaction.UseVisualStyleBackColor = false;
            this.BtnRemoveTransaction.Click += new System.EventHandler(this.BtnRemoveTransaction_Click);
            // 
            // BtnSaveTransaction
            // 
            this.BtnSaveTransaction.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveTransaction.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveTransaction.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSaveTransaction.BorderRadius = 35;
            this.BtnSaveTransaction.BorderSize = 0;
            this.BtnSaveTransaction.FlatAppearance.BorderSize = 0;
            this.BtnSaveTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveTransaction.ForeColor = System.Drawing.Color.White;
            this.BtnSaveTransaction.Location = new System.Drawing.Point(10, 20);
            this.BtnSaveTransaction.Name = "BtnSaveTransaction";
            this.BtnSaveTransaction.Size = new System.Drawing.Size(120, 35);
            this.BtnSaveTransaction.TabIndex = 30;
            this.BtnSaveTransaction.Text = "Save";
            this.BtnSaveTransaction.TextColor = System.Drawing.Color.White;
            this.BtnSaveTransaction.UseVisualStyleBackColor = false;
            this.BtnSaveTransaction.Click += new System.EventHandler(this.BtnSaveTransaction_Click);
            // 
            // DataGridBankList
            // 
            this.DataGridBankList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridBankList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridBankList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridBankList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridBankList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridBankList.Location = new System.Drawing.Point(14, 141);
            this.DataGridBankList.Name = "DataGridBankList";
            this.DataGridBankList.ReadOnly = true;
            this.DataGridBankList.Size = new System.Drawing.Size(923, 405);
            this.DataGridBankList.TabIndex = 0;
            this.DataGridBankList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridBankDetails_DataBindingComplete);
            // 
            // ComboAction
            // 
            this.ComboAction.Enabled = false;
            this.ComboAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboAction.FormattingEnabled = true;
            this.ComboAction.Items.AddRange(new object[] {
            "Deposit",
            "Withdrawl"});
            this.ComboAction.Location = new System.Drawing.Point(396, 18);
            this.ComboAction.Name = "ComboAction";
            this.ComboAction.Size = new System.Drawing.Size(120, 26);
            this.ComboAction.TabIndex = 22;
            this.ComboAction.SelectedValueChanged += new System.EventHandler(this.ComboAction_SelectedValueChanged);
            this.ComboAction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboAction_KeyPress);
            // 
            // MaskEndOfDayFrom
            // 
            this.MaskEndOfDayFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayFrom.Location = new System.Drawing.Point(118, 18);
            this.MaskEndOfDayFrom.Mask = "   0000-00-00";
            this.MaskEndOfDayFrom.Name = "MaskEndOfDayFrom";
            this.MaskEndOfDayFrom.Size = new System.Drawing.Size(100, 24);
            this.MaskEndOfDayFrom.TabIndex = 22;
            // 
            // MaskEndOfDayTo
            // 
            this.MaskEndOfDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayTo.Location = new System.Drawing.Point(291, 18);
            this.MaskEndOfDayTo.Mask = "   0000-00-00";
            this.MaskEndOfDayTo.Name = "MaskEndOfDayTo";
            this.MaskEndOfDayTo.Size = new System.Drawing.Size(100, 24);
            this.MaskEndOfDayTo.TabIndex = 24;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1115, 44);
            this.textBox1.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DodgerBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(416, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 31);
            this.label4.TabIndex = 39;
            this.label4.Text = "Banking Management";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ComboAction);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.BtnShowTransaction);
            this.groupBox3.Controls.Add(this.TxtAmount);
            this.groupBox3.Controls.Add(this.MaskEndOfDayTo);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.MaskEndOfDayFrom);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(15, 547);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(920, 55);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transaction";
            // 
            // BtnShowTransaction
            // 
            this.BtnShowTransaction.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnShowTransaction.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnShowTransaction.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnShowTransaction.BorderRadius = 35;
            this.BtnShowTransaction.BorderSize = 0;
            this.BtnShowTransaction.Enabled = false;
            this.BtnShowTransaction.FlatAppearance.BorderSize = 0;
            this.BtnShowTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowTransaction.ForeColor = System.Drawing.Color.White;
            this.BtnShowTransaction.Location = new System.Drawing.Point(771, 13);
            this.BtnShowTransaction.Name = "BtnShowTransaction";
            this.BtnShowTransaction.Size = new System.Drawing.Size(140, 35);
            this.BtnShowTransaction.TabIndex = 37;
            this.BtnShowTransaction.Text = "Show Transaction";
            this.BtnShowTransaction.TextColor = System.Drawing.Color.White;
            this.BtnShowTransaction.UseVisualStyleBackColor = false;
            this.BtnShowTransaction.Click += new System.EventHandler(this.BtnShowTransaction_Click);
            // 
            // BankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1104, 602);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DataGridBankList);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(569, 240);
            this.Name = "BankForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BankForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBankList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox RichAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ComboTransaction;
        private System.Windows.Forms.TextBox TxtBalance;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DataGridBankList;
        private System.Windows.Forms.ComboBox ComboAction;
        private System.Windows.Forms.ComboBox ComboType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayFrom;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayTo;
        private CustomControls.Button.CustomButton BtnSaveTransaction;
        private CustomControls.Button.CustomButton BtnRemoveTransaction;
        private CustomControls.Button.CustomButton BtnAddBank;
        private CustomControls.Button.CustomButton BtnSaveBank;
        private CustomControls.Button.CustomButton BtnEditBank;
        private CustomControls.Button.CustomButton BtnUpdateBank;
        private CustomControls.Button.CustomButton BtnDeleteBank;
        private CustomControls.Button.CustomButton BtnShowTransaction;
        private CustomControls.Button.CustomButton BtnSearchBank;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtBankName;
        private System.Windows.Forms.TextBox TxtAccountNo;
    }
}