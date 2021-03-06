
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberForm));
            this.ComboAction = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnUpdate = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnEdit = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSave = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddMember = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtShareMemberId = new System.Windows.Forms.TextBox();
            this.TxtMemberId = new System.Windows.Forms.TextBox();
            this.BtnSearchMember = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.TxtAccountNumber = new System.Windows.Forms.TextBox();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.TxtContactNumber = new System.Windows.Forms.TextBox();
            this.TxtBalance = new System.Windows.Forms.TextBox();
            this.TxtBalanceStatus = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ComboReceipt = new System.Windows.Forms.ComboBox();
            this.RichAmount = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ComboBank = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DataGridMemberList = new System.Windows.Forms.DataGridView();
            this.PicBoxMemberImage = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.OpenMemberImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.MaskEndOfDayFrom = new System.Windows.Forms.MaskedTextBox();
            this.MaskEndOfDayTo = new System.Windows.Forms.MaskedTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnShowTransaction = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BtnEditReceipt = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnRemoveReceipt = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSaveReceipt = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnShowSales = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnDeleteImage = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddImage = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMemberList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxMemberImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboAction
            // 
            this.ComboAction.AutoCompleteCustomSource.AddRange(new string[] {
            "Deposit,Withdrawl,Purchase"});
            this.ComboAction.BackColor = System.Drawing.Color.White;
            this.ComboAction.Enabled = false;
            this.ComboAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboAction.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ComboAction.FormattingEnabled = true;
            this.ComboAction.Location = new System.Drawing.Point(401, 17);
            this.ComboAction.Name = "ComboAction";
            this.ComboAction.Size = new System.Drawing.Size(120, 26);
            this.ComboAction.TabIndex = 25;
            this.ComboAction.SelectedValueChanged += new System.EventHandler(this.ComboAction_SelectedValueChanged);
            this.ComboAction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboAction_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnDelete);
            this.groupBox3.Controls.Add(this.BtnUpdate);
            this.groupBox3.Controls.Add(this.BtnEdit);
            this.groupBox3.Controls.Add(this.BtnSave);
            this.groupBox3.Controls.Add(this.BtnAddMember);
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(961, 392);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 205);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Member";
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
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(7, 163);
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
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnUpdate.Location = new System.Drawing.Point(7, 127);
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
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(6, 91);
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
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(7, 55);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(120, 35);
            this.BtnSave.TabIndex = 19;
            this.BtnSave.Text = "Save";
            this.BtnSave.TextColor = System.Drawing.Color.White;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnAddMember
            // 
            this.BtnAddMember.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddMember.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddMember.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddMember.BorderRadius = 35;
            this.BtnAddMember.BorderSize = 0;
            this.BtnAddMember.FlatAppearance.BorderSize = 0;
            this.BtnAddMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddMember.ForeColor = System.Drawing.Color.White;
            this.BtnAddMember.Location = new System.Drawing.Point(7, 19);
            this.BtnAddMember.Name = "BtnAddMember";
            this.BtnAddMember.Size = new System.Drawing.Size(120, 35);
            this.BtnAddMember.TabIndex = 18;
            this.BtnAddMember.Text = "Add";
            this.BtnAddMember.TextColor = System.Drawing.Color.White;
            this.BtnAddMember.UseVisualStyleBackColor = false;
            this.BtnAddMember.Click += new System.EventHandler(this.BtnAddMember_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(223, 21);
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
            this.label9.Location = new System.Drawing.Point(31, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "Date From ";
            // 
            // TxtAmount
            // 
            this.TxtAmount.BackColor = System.Drawing.Color.White;
            this.TxtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAmount.Location = new System.Drawing.Point(624, 17);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.ReadOnly = true;
            this.TxtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtAmount.Size = new System.Drawing.Size(125, 26);
            this.TxtAmount.TabIndex = 26;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(370, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(368, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Balance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(369, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Contact ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(5, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(5, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtShareMemberId);
            this.groupBox1.Controls.Add(this.TxtMemberId);
            this.groupBox1.Controls.Add(this.BtnSearchMember);
            this.groupBox1.Controls.Add(this.TxtAccountNumber);
            this.groupBox1.Controls.Add(this.TxtName);
            this.groupBox1.Controls.Add(this.TxtAddress);
            this.groupBox1.Controls.Add(this.TxtEmail);
            this.groupBox1.Controls.Add(this.TxtContactNumber);
            this.groupBox1.Controls.Add(this.TxtBalance);
            this.groupBox1.Controls.Add(this.TxtBalanceStatus);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(13, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 113);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Member Details";
            // 
            // TxtShareMemberId
            // 
            this.TxtShareMemberId.BackColor = System.Drawing.Color.White;
            this.TxtShareMemberId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtShareMemberId.Location = new System.Drawing.Point(288, 75);
            this.TxtShareMemberId.Name = "TxtShareMemberId";
            this.TxtShareMemberId.Size = new System.Drawing.Size(72, 26);
            this.TxtShareMemberId.TabIndex = 5;
            this.TxtShareMemberId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtShareMemberId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtShareMemberId_KeyPress);
            // 
            // TxtMemberId
            // 
            this.TxtMemberId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMemberId.Location = new System.Drawing.Point(86, 17);
            this.TxtMemberId.Name = "TxtMemberId";
            this.TxtMemberId.Size = new System.Drawing.Size(75, 26);
            this.TxtMemberId.TabIndex = 0;
            this.TxtMemberId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtMemberId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMemberId_KeyPress);
            // 
            // BtnSearchMember
            // 
            this.BtnSearchMember.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchMember.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchMember.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSearchMember.BorderRadius = 10;
            this.BtnSearchMember.BorderSize = 0;
            this.BtnSearchMember.FlatAppearance.BorderSize = 0;
            this.BtnSearchMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchMember.ForeColor = System.Drawing.Color.White;
            this.BtnSearchMember.Location = new System.Drawing.Point(290, 16);
            this.BtnSearchMember.Name = "BtnSearchMember";
            this.BtnSearchMember.Size = new System.Drawing.Size(70, 28);
            this.BtnSearchMember.TabIndex = 2;
            this.BtnSearchMember.Text = "Search";
            this.BtnSearchMember.TextColor = System.Drawing.Color.White;
            this.BtnSearchMember.UseVisualStyleBackColor = false;
            this.BtnSearchMember.Click += new System.EventHandler(this.BtnSearchMember_Click);
            // 
            // TxtAccountNumber
            // 
            this.TxtAccountNumber.BackColor = System.Drawing.Color.White;
            this.TxtAccountNumber.Enabled = false;
            this.TxtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAccountNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtAccountNumber.Location = new System.Drawing.Point(202, 17);
            this.TxtAccountNumber.Name = "TxtAccountNumber";
            this.TxtAccountNumber.Size = new System.Drawing.Size(87, 26);
            this.TxtAccountNumber.TabIndex = 1;
            this.TxtAccountNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtAccountNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAccountNumber_KeyPress);
            // 
            // TxtName
            // 
            this.TxtName.BackColor = System.Drawing.Color.White;
            this.TxtName.Enabled = false;
            this.TxtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtName.Location = new System.Drawing.Point(86, 46);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(274, 26);
            this.TxtName.TabIndex = 3;
            // 
            // TxtAddress
            // 
            this.TxtAddress.BackColor = System.Drawing.Color.White;
            this.TxtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAddress.Location = new System.Drawing.Point(86, 75);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(199, 26);
            this.TxtAddress.TabIndex = 4;
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.Color.White;
            this.TxtEmail.Enabled = false;
            this.TxtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtEmail.Location = new System.Drawing.Point(437, 17);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(225, 26);
            this.TxtEmail.TabIndex = 6;
            // 
            // TxtContactNumber
            // 
            this.TxtContactNumber.BackColor = System.Drawing.Color.White;
            this.TxtContactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContactNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtContactNumber.Location = new System.Drawing.Point(437, 46);
            this.TxtContactNumber.Name = "TxtContactNumber";
            this.TxtContactNumber.Size = new System.Drawing.Size(225, 26);
            this.TxtContactNumber.TabIndex = 7;
            // 
            // TxtBalance
            // 
            this.TxtBalance.BackColor = System.Drawing.Color.White;
            this.TxtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtBalance.Location = new System.Drawing.Point(437, 75);
            this.TxtBalance.Name = "TxtBalance";
            this.TxtBalance.ReadOnly = true;
            this.TxtBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBalance.Size = new System.Drawing.Size(159, 26);
            this.TxtBalance.TabIndex = 8;
            // 
            // TxtBalanceStatus
            // 
            this.TxtBalanceStatus.BackColor = System.Drawing.Color.White;
            this.TxtBalanceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalanceStatus.Location = new System.Drawing.Point(599, 75);
            this.TxtBalanceStatus.Name = "TxtBalanceStatus";
            this.TxtBalanceStatus.ReadOnly = true;
            this.TxtBalanceStatus.Size = new System.Drawing.Size(63, 26);
            this.TxtBalanceStatus.TabIndex = 9;
            this.TxtBalanceStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(167, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 18);
            this.label14.TabIndex = 23;
            this.label14.Text = "A/C ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Member ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(2, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 18);
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
            this.ComboReceipt.Location = new System.Drawing.Point(102, 18);
            this.ComboReceipt.Name = "ComboReceipt";
            this.ComboReceipt.Size = new System.Drawing.Size(137, 26);
            this.ComboReceipt.TabIndex = 10;
            this.ComboReceipt.SelectedValueChanged += new System.EventHandler(this.ComboPayment_SelectedValueChanged);
            this.ComboReceipt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboReceipt_KeyPress);
            // 
            // RichAmount
            // 
            this.RichAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RichAmount.Enabled = false;
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(102, 76);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(137, 28);
            this.RichAmount.TabIndex = 12;
            this.RichAmount.Text = "";
            this.RichAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichAmount_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(39, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "Amount";
            // 
            // ComboBank
            // 
            this.ComboBank.Enabled = false;
            this.ComboBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBank.FormattingEnabled = true;
            this.ComboBank.Location = new System.Drawing.Point(45, 47);
            this.ComboBank.Name = "ComboBank";
            this.ComboBank.Size = new System.Drawing.Size(194, 26);
            this.ComboBank.TabIndex = 11;
            this.ComboBank.SelectedValueChanged += new System.EventHandler(this.ComboBank_SelectedValueChanged);
            this.ComboBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboBank_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(40, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "Receipt";
            // 
            // DataGridMemberList
            // 
            this.DataGridMemberList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridMemberList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMemberList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridMemberList.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridMemberList.Location = new System.Drawing.Point(13, 166);
            this.DataGridMemberList.Name = "DataGridMemberList";
            this.DataGridMemberList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMemberList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridMemberList.Size = new System.Drawing.Size(938, 380);
            this.DataGridMemberList.TabIndex = 32;
            this.DataGridMemberList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridMemberTransactionList_DataBindingComplete);
            // 
            // PicBoxMemberImage
            // 
            this.PicBoxMemberImage.ErrorImage = null;
            this.PicBoxMemberImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxMemberImage.Image")));
            this.PicBoxMemberImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("PicBoxMemberImage.InitialImage")));
            this.PicBoxMemberImage.Location = new System.Drawing.Point(3, 9);
            this.PicBoxMemberImage.Name = "PicBoxMemberImage";
            this.PicBoxMemberImage.Size = new System.Drawing.Size(130, 133);
            this.PicBoxMemberImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxMemberImage.TabIndex = 33;
            this.PicBoxMemberImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PicBoxMemberImage);
            this.groupBox2.Location = new System.Drawing.Point(961, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 145);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(526, 21);
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
            this.MaskEndOfDayFrom.Enabled = false;
            this.MaskEndOfDayFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayFrom.Location = new System.Drawing.Point(117, 17);
            this.MaskEndOfDayFrom.Mask = "   0000-00-00";
            this.MaskEndOfDayFrom.Name = "MaskEndOfDayFrom";
            this.MaskEndOfDayFrom.Size = new System.Drawing.Size(100, 24);
            this.MaskEndOfDayFrom.TabIndex = 23;
            // 
            // MaskEndOfDayTo
            // 
            this.MaskEndOfDayTo.Enabled = false;
            this.MaskEndOfDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayTo.Location = new System.Drawing.Point(295, 18);
            this.MaskEndOfDayTo.Mask = "   0000-00-00";
            this.MaskEndOfDayTo.Name = "MaskEndOfDayTo";
            this.MaskEndOfDayTo.Size = new System.Drawing.Size(100, 24);
            this.MaskEndOfDayTo.TabIndex = 24;
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ComboAction);
            this.groupBox4.Controls.Add(this.TxtAmount);
            this.groupBox4.Controls.Add(this.BtnShowTransaction);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.MaskEndOfDayTo);
            this.groupBox4.Controls.Add(this.MaskEndOfDayFrom);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(13, 546);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(938, 55);
            this.groupBox4.TabIndex = 49;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Transaction";
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
            this.BtnShowTransaction.Location = new System.Drawing.Point(770, 13);
            this.BtnShowTransaction.Name = "BtnShowTransaction";
            this.BtnShowTransaction.Size = new System.Drawing.Size(140, 35);
            this.BtnShowTransaction.TabIndex = 27;
            this.BtnShowTransaction.Text = "Show Transaction";
            this.BtnShowTransaction.TextColor = System.Drawing.Color.White;
            this.BtnShowTransaction.UseVisualStyleBackColor = false;
            this.BtnShowTransaction.Click += new System.EventHandler(this.BtnShowTransaction_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.BtnEditReceipt);
            this.groupBox5.Controls.Add(this.BtnRemoveReceipt);
            this.groupBox5.Controls.Add(this.BtnSaveReceipt);
            this.groupBox5.Controls.Add(this.BtnShowSales);
            this.groupBox5.ForeColor = System.Drawing.Color.Red;
            this.groupBox5.Location = new System.Drawing.Point(961, 220);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(135, 168);
            this.groupBox5.TabIndex = 50;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Transaction";
            // 
            // BtnEditReceipt
            // 
            this.BtnEditReceipt.BackColor = System.Drawing.Color.Red;
            this.BtnEditReceipt.BackgroundColor = System.Drawing.Color.Red;
            this.BtnEditReceipt.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnEditReceipt.BorderRadius = 35;
            this.BtnEditReceipt.BorderSize = 0;
            this.BtnEditReceipt.FlatAppearance.BorderSize = 0;
            this.BtnEditReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditReceipt.ForeColor = System.Drawing.Color.White;
            this.BtnEditReceipt.Location = new System.Drawing.Point(7, 90);
            this.BtnEditReceipt.Name = "BtnEditReceipt";
            this.BtnEditReceipt.Size = new System.Drawing.Size(120, 35);
            this.BtnEditReceipt.TabIndex = 18;
            this.BtnEditReceipt.Text = "Edit Profit";
            this.BtnEditReceipt.TextColor = System.Drawing.Color.White;
            this.BtnEditReceipt.UseVisualStyleBackColor = false;
            this.BtnEditReceipt.Click += new System.EventHandler(this.BtnEditReceipt_Click);
            // 
            // BtnRemoveReceipt
            // 
            this.BtnRemoveReceipt.BackColor = System.Drawing.Color.Red;
            this.BtnRemoveReceipt.BackgroundColor = System.Drawing.Color.Red;
            this.BtnRemoveReceipt.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnRemoveReceipt.BorderRadius = 35;
            this.BtnRemoveReceipt.BorderSize = 0;
            this.BtnRemoveReceipt.FlatAppearance.BorderSize = 0;
            this.BtnRemoveReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemoveReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemoveReceipt.ForeColor = System.Drawing.Color.White;
            this.BtnRemoveReceipt.Location = new System.Drawing.Point(7, 126);
            this.BtnRemoveReceipt.Name = "BtnRemoveReceipt";
            this.BtnRemoveReceipt.Size = new System.Drawing.Size(120, 35);
            this.BtnRemoveReceipt.TabIndex = 17;
            this.BtnRemoveReceipt.Text = "Remove";
            this.BtnRemoveReceipt.TextColor = System.Drawing.Color.White;
            this.BtnRemoveReceipt.UseVisualStyleBackColor = false;
            this.BtnRemoveReceipt.Click += new System.EventHandler(this.BtnRemoveReceipt_Click);
            // 
            // BtnSaveReceipt
            // 
            this.BtnSaveReceipt.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveReceipt.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveReceipt.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSaveReceipt.BorderRadius = 35;
            this.BtnSaveReceipt.BorderSize = 0;
            this.BtnSaveReceipt.FlatAppearance.BorderSize = 0;
            this.BtnSaveReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveReceipt.ForeColor = System.Drawing.Color.White;
            this.BtnSaveReceipt.Location = new System.Drawing.Point(7, 54);
            this.BtnSaveReceipt.Name = "BtnSaveReceipt";
            this.BtnSaveReceipt.Size = new System.Drawing.Size(120, 35);
            this.BtnSaveReceipt.TabIndex = 16;
            this.BtnSaveReceipt.Text = "Save Receipt";
            this.BtnSaveReceipt.TextColor = System.Drawing.Color.White;
            this.BtnSaveReceipt.UseVisualStyleBackColor = false;
            this.BtnSaveReceipt.Click += new System.EventHandler(this.BtnSaveReceipt_Click);
            // 
            // BtnShowSales
            // 
            this.BtnShowSales.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnShowSales.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnShowSales.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnShowSales.BorderRadius = 35;
            this.BtnShowSales.BorderSize = 0;
            this.BtnShowSales.FlatAppearance.BorderSize = 0;
            this.BtnShowSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowSales.ForeColor = System.Drawing.Color.White;
            this.BtnShowSales.Location = new System.Drawing.Point(7, 18);
            this.BtnShowSales.Name = "BtnShowSales";
            this.BtnShowSales.Size = new System.Drawing.Size(120, 35);
            this.BtnShowSales.TabIndex = 15;
            this.BtnShowSales.Text = "Show Sales";
            this.BtnShowSales.TextColor = System.Drawing.Color.White;
            this.BtnShowSales.UseVisualStyleBackColor = false;
            this.BtnShowSales.Click += new System.EventHandler(this.BtnShowSales_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ComboBank);
            this.groupBox6.Controls.Add(this.ComboReceipt);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.RichAmount);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.Red;
            this.groupBox6.Location = new System.Drawing.Point(696, 45);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(255, 113);
            this.groupBox6.TabIndex = 51;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Reciept";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DodgerBlue;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Cyan;
            this.label11.Location = new System.Drawing.Point(414, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(293, 31);
            this.label11.TabIndex = 52;
            this.label11.Text = "Member Management";
            // 
            // BtnDeleteImage
            // 
            this.BtnDeleteImage.BackColor = System.Drawing.Color.Red;
            this.BtnDeleteImage.BackgroundColor = System.Drawing.Color.Red;
            this.BtnDeleteImage.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnDeleteImage.BorderRadius = 22;
            this.BtnDeleteImage.BorderSize = 0;
            this.BtnDeleteImage.FlatAppearance.BorderSize = 0;
            this.BtnDeleteImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeleteImage.ForeColor = System.Drawing.Color.White;
            this.BtnDeleteImage.Location = new System.Drawing.Point(1027, 194);
            this.BtnDeleteImage.Name = "BtnDeleteImage";
            this.BtnDeleteImage.Size = new System.Drawing.Size(52, 22);
            this.BtnDeleteImage.TabIndex = 14;
            this.BtnDeleteImage.Text = "Delete";
            this.BtnDeleteImage.TextColor = System.Drawing.Color.White;
            this.BtnDeleteImage.UseVisualStyleBackColor = false;
            this.BtnDeleteImage.Click += new System.EventHandler(this.BtnDeleteImage_Click);
            // 
            // BtnAddImage
            // 
            this.BtnAddImage.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddImage.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddImage.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddImage.BorderRadius = 22;
            this.BtnAddImage.BorderSize = 0;
            this.BtnAddImage.FlatAppearance.BorderSize = 0;
            this.BtnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddImage.ForeColor = System.Drawing.Color.White;
            this.BtnAddImage.Location = new System.Drawing.Point(975, 194);
            this.BtnAddImage.Name = "BtnAddImage";
            this.BtnAddImage.Size = new System.Drawing.Size(52, 22);
            this.BtnAddImage.TabIndex = 13;
            this.BtnAddImage.Text = "Add";
            this.BtnAddImage.TextColor = System.Drawing.Color.White;
            this.BtnAddImage.UseVisualStyleBackColor = false;
            this.BtnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
            // 
            // MemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1104, 602);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnDeleteImage);
            this.Controls.Add(this.BtnAddImage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DataGridMemberList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(569, 240);
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
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboAction;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView DataGridMemberList;
        private System.Windows.Forms.PictureBox PicBoxMemberImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtBalanceStatus;
        private System.Windows.Forms.RichTextBox RichAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ComboBank;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ComboReceipt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.OpenFileDialog OpenMemberImageDialog;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayFrom;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayTo;
        private System.Windows.Forms.TextBox TxtBalance;
        private System.Windows.Forms.TextBox TxtContactNumber;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtAccountNumber;
        private CustomControls.Button.CustomButton BtnSearchMember;
        private CustomControls.Button.CustomButton BtnShowSales;
        private CustomControls.Button.CustomButton BtnSaveReceipt;
        private CustomControls.Button.CustomButton BtnAddImage;
        private CustomControls.Button.CustomButton BtnDeleteImage;
        private CustomControls.Button.CustomButton BtnAddMember;
        private CustomControls.Button.CustomButton BtnSave;
        private CustomControls.Button.CustomButton BtnEdit;
        private CustomControls.Button.CustomButton BtnUpdate;
        private CustomControls.Button.CustomButton BtnDelete;
        private CustomControls.Button.CustomButton BtnShowTransaction;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtMemberId;
        private CustomControls.Button.CustomButton BtnRemoveReceipt;
        private System.Windows.Forms.TextBox TxtShareMemberId;
        private CustomControls.Button.CustomButton BtnEditReceipt;
    }
}