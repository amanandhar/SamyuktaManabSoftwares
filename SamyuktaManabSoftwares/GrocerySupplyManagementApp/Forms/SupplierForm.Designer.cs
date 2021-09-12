
namespace GrocerySupplyManagementApp.Forms
{
    partial class SupplierForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierForm));
            this.BtnDelete = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnAddSupplier = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.TxtTotalAmount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ComboBank = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ComboPayment = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnShowSupplier = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboAction = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtSupplierId = new System.Windows.Forms.TextBox();
            this.TxtOwner = new System.Windows.Forms.TextBox();
            this.TxtSupplierName = new System.Windows.Forms.TextBox();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.TxtContactNumber = new System.Windows.Forms.TextBox();
            this.TxtBalance = new System.Windows.Forms.TextBox();
            this.TxtBillNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TextBoxDebitCredit = new System.Windows.Forms.TextBox();
            this.RichAmount = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnShowPurchase = new System.Windows.Forms.Button();
            this.BtnPurchase = new System.Windows.Forms.Button();
            this.BtnPaymentSave = new System.Windows.Forms.Button();
            this.DataGridSupplierList = new System.Windows.Forms.DataGridView();
            this.MaskEndOfDayFrom = new System.Windows.Forms.MaskedTextBox();
            this.MaskEndOfDayTo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnShowTransaction = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSupplierList)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BtnDelete.Location = new System.Drawing.Point(9, 169);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(126, 38);
            this.BtnDelete.TabIndex = 6;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnUpdate);
            this.groupBox3.Controls.Add(this.BtnAddSupplier);
            this.groupBox3.Controls.Add(this.BtnSave);
            this.groupBox3.Controls.Add(this.BtnEdit);
            this.groupBox3.Controls.Add(this.BtnDelete);
            this.groupBox3.Location = new System.Drawing.Point(887, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 225);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.Color.Cyan;
            this.BtnUpdate.Location = new System.Drawing.Point(8, 130);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(126, 38);
            this.BtnUpdate.TabIndex = 11;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnAddSupplier
            // 
            this.BtnAddSupplier.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnAddSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAddSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddSupplier.ForeColor = System.Drawing.Color.Cyan;
            this.BtnAddSupplier.Location = new System.Drawing.Point(8, 13);
            this.BtnAddSupplier.Name = "BtnAddSupplier";
            this.BtnAddSupplier.Size = new System.Drawing.Size(126, 38);
            this.BtnAddSupplier.TabIndex = 10;
            this.BtnAddSupplier.Text = "Add Suppliers";
            this.BtnAddSupplier.UseVisualStyleBackColor = false;
            this.BtnAddSupplier.Click += new System.EventHandler(this.BtnAddSupplier_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.Cyan;
            this.BtnSave.Location = new System.Drawing.Point(8, 52);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(126, 38);
            this.BtnSave.TabIndex = 9;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BtnEdit.Location = new System.Drawing.Point(8, 91);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(126, 38);
            this.BtnEdit.TabIndex = 8;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBox7.Location = new System.Drawing.Point(-9, -48);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(1055, 35);
            this.textBox7.TabIndex = 38;
            this.textBox7.Text = "                                                              Purchase\r\n Details";
            // 
            // TxtTotalAmount
            // 
            this.TxtTotalAmount.BackColor = System.Drawing.Color.White;
            this.TxtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalAmount.Location = new System.Drawing.Point(601, 506);
            this.TxtTotalAmount.Name = "TxtTotalAmount";
            this.TxtTotalAmount.ReadOnly = true;
            this.TxtTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalAmount.Size = new System.Drawing.Size(130, 26);
            this.TxtTotalAmount.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(554, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 18);
            this.label14.TabIndex = 23;
            this.label14.Text = "Balance";
            // 
            // ComboBank
            // 
            this.ComboBank.BackColor = System.Drawing.Color.White;
            this.ComboBank.Enabled = false;
            this.ComboBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBank.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ComboBank.FormattingEnabled = true;
            this.ComboBank.Location = new System.Drawing.Point(263, 100);
            this.ComboBank.Name = "ComboBank";
            this.ComboBank.Size = new System.Drawing.Size(190, 26);
            this.ComboBank.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(218, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 18);
            this.label15.TabIndex = 21;
            this.label15.Text = "Bank";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(555, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 18);
            this.label13.TabIndex = 19;
            this.label13.Text = "Amount";
            // 
            // ComboPayment
            // 
            this.ComboPayment.BackColor = System.Drawing.Color.White;
            this.ComboPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPayment.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ComboPayment.FormattingEnabled = true;
            this.ComboPayment.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboPayment.Location = new System.Drawing.Point(120, 100);
            this.ComboPayment.Name = "ComboPayment";
            this.ComboPayment.Size = new System.Drawing.Size(85, 26);
            this.ComboPayment.TabIndex = 18;
            this.ComboPayment.SelectedValueChanged += new System.EventHandler(this.ComboPaymentType_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(202, 508);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 18);
            this.label11.TabIndex = 35;
            this.label11.Text = "Date To";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(501, 510);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 18);
            this.label10.TabIndex = 34;
            this.label10.Text = "Total Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(14, 507);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 18);
            this.label9.TabIndex = 33;
            this.label9.Text = "Date From";
            // 
            // BtnShowSupplier
            // 
            this.BtnShowSupplier.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnShowSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnShowSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowSupplier.ForeColor = System.Drawing.Color.Cyan;
            this.BtnShowSupplier.Location = new System.Drawing.Point(383, 13);
            this.BtnShowSupplier.Name = "BtnShowSupplier";
            this.BtnShowSupplier.Size = new System.Drawing.Size(70, 29);
            this.BtnShowSupplier.TabIndex = 7;
            this.BtnShowSupplier.Text = "Search";
            this.BtnShowSupplier.UseVisualStyleBackColor = false;
            this.BtnShowSupplier.Click += new System.EventHandler(this.BtnShowSupplier_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Supplier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(22, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Owner Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(23, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(489, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Contact ";
            // 
            // ComboAction
            // 
            this.ComboAction.BackColor = System.Drawing.Color.White;
            this.ComboAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboAction.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ComboAction.FormattingEnabled = true;
            this.ComboAction.Items.AddRange(new object[] {
            "Purchase",
            "Payment"});
            this.ComboAction.Location = new System.Drawing.Point(373, 505);
            this.ComboAction.Name = "ComboAction";
            this.ComboAction.Size = new System.Drawing.Size(120, 26);
            this.ComboAction.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtSupplierId);
            this.groupBox1.Controls.Add(this.TxtOwner);
            this.groupBox1.Controls.Add(this.TxtSupplierName);
            this.groupBox1.Controls.Add(this.TxtAddress);
            this.groupBox1.Controls.Add(this.TxtEmail);
            this.groupBox1.Controls.Add(this.TxtContactNumber);
            this.groupBox1.Controls.Add(this.TxtBalance);
            this.groupBox1.Controls.Add(this.TxtBillNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ComboPayment);
            this.groupBox1.Controls.Add(this.TextBoxDebitCredit);
            this.groupBox1.Controls.Add(this.RichAmount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.ComboBank);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.BtnShowSupplier);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(16, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 135);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // TxtSupplierId
            // 
            this.TxtSupplierId.BackColor = System.Drawing.Color.White;
            this.TxtSupplierId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSupplierId.Location = new System.Drawing.Point(120, 15);
            this.TxtSupplierId.Name = "TxtSupplierId";
            this.TxtSupplierId.ReadOnly = true;
            this.TxtSupplierId.Size = new System.Drawing.Size(65, 26);
            this.TxtSupplierId.TabIndex = 49;
            // 
            // TxtOwner
            // 
            this.TxtOwner.BackColor = System.Drawing.Color.White;
            this.TxtOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOwner.Location = new System.Drawing.Point(120, 44);
            this.TxtOwner.Name = "TxtOwner";
            this.TxtOwner.Size = new System.Drawing.Size(333, 26);
            this.TxtOwner.TabIndex = 48;
            // 
            // TxtSupplierName
            // 
            this.TxtSupplierName.BackColor = System.Drawing.Color.White;
            this.TxtSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSupplierName.Location = new System.Drawing.Point(186, 15);
            this.TxtSupplierName.Name = "TxtSupplierName";
            this.TxtSupplierName.Size = new System.Drawing.Size(196, 26);
            this.TxtSupplierName.TabIndex = 47;
            // 
            // TxtAddress
            // 
            this.TxtAddress.BackColor = System.Drawing.Color.White;
            this.TxtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAddress.Location = new System.Drawing.Point(120, 72);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(333, 26);
            this.TxtAddress.TabIndex = 46;
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.Color.White;
            this.TxtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtEmail.Location = new System.Drawing.Point(555, 15);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(289, 26);
            this.TxtEmail.TabIndex = 45;
            // 
            // TxtContactNumber
            // 
            this.TxtContactNumber.BackColor = System.Drawing.Color.White;
            this.TxtContactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContactNumber.Location = new System.Drawing.Point(555, 44);
            this.TxtContactNumber.Name = "TxtContactNumber";
            this.TxtContactNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtContactNumber.Size = new System.Drawing.Size(110, 26);
            this.TxtContactNumber.TabIndex = 44;
            // 
            // TxtBalance
            // 
            this.TxtBalance.BackColor = System.Drawing.Color.White;
            this.TxtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtBalance.Location = new System.Drawing.Point(626, 73);
            this.TxtBalance.Name = "TxtBalance";
            this.TxtBalance.ReadOnly = true;
            this.TxtBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBalance.Size = new System.Drawing.Size(164, 26);
            this.TxtBalance.TabIndex = 43;
            // 
            // TxtBillNo
            // 
            this.TxtBillNo.BackColor = System.Drawing.Color.White;
            this.TxtBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBillNo.Location = new System.Drawing.Point(733, 44);
            this.TxtBillNo.Name = "TxtBillNo";
            this.TxtBillNo.ReadOnly = true;
            this.TxtBillNo.Size = new System.Drawing.Size(111, 26);
            this.TxtBillNo.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(672, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 18);
            this.label7.TabIndex = 38;
            this.label7.Text = "Bill No";
            // 
            // TextBoxDebitCredit
            // 
            this.TextBoxDebitCredit.BackColor = System.Drawing.Color.White;
            this.TextBoxDebitCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDebitCredit.Location = new System.Drawing.Point(792, 73);
            this.TextBoxDebitCredit.Name = "TextBoxDebitCredit";
            this.TextBoxDebitCredit.ReadOnly = true;
            this.TextBoxDebitCredit.Size = new System.Drawing.Size(52, 26);
            this.TextBoxDebitCredit.TabIndex = 35;
            // 
            // RichAmount
            // 
            this.RichAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RichAmount.Enabled = false;
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(625, 101);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(166, 28);
            this.RichAmount.TabIndex = 33;
            this.RichAmount.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(489, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 30;
            this.label4.Text = "Email ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(23, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 18);
            this.label12.TabIndex = 17;
            this.label12.Text = "Payment";
            // 
            // BtnShowPurchase
            // 
            this.BtnShowPurchase.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnShowPurchase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnShowPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnShowPurchase.Enabled = false;
            this.BtnShowPurchase.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.BtnShowPurchase.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowPurchase.ForeColor = System.Drawing.Color.Cyan;
            this.BtnShowPurchase.Location = new System.Drawing.Point(8, 51);
            this.BtnShowPurchase.Name = "BtnShowPurchase";
            this.BtnShowPurchase.Size = new System.Drawing.Size(126, 38);
            this.BtnShowPurchase.TabIndex = 40;
            this.BtnShowPurchase.Text = "Show Purchas";
            this.BtnShowPurchase.UseVisualStyleBackColor = false;
            this.BtnShowPurchase.Click += new System.EventHandler(this.BtnShowPurchase_Click);
            // 
            // BtnPurchase
            // 
            this.BtnPurchase.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnPurchase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPurchase.Enabled = false;
            this.BtnPurchase.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.BtnPurchase.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPurchase.ForeColor = System.Drawing.Color.Cyan;
            this.BtnPurchase.Location = new System.Drawing.Point(9, 12);
            this.BtnPurchase.Name = "BtnPurchase";
            this.BtnPurchase.Size = new System.Drawing.Size(126, 38);
            this.BtnPurchase.TabIndex = 37;
            this.BtnPurchase.Text = "Add Purchase";
            this.BtnPurchase.UseVisualStyleBackColor = false;
            this.BtnPurchase.Click += new System.EventHandler(this.BtnPurchase_Click);
            // 
            // BtnPaymentSave
            // 
            this.BtnPaymentSave.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnPaymentSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPaymentSave.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.BtnPaymentSave.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnPaymentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPaymentSave.ForeColor = System.Drawing.Color.Cyan;
            this.BtnPaymentSave.Location = new System.Drawing.Point(9, 90);
            this.BtnPaymentSave.Name = "BtnPaymentSave";
            this.BtnPaymentSave.Size = new System.Drawing.Size(126, 38);
            this.BtnPaymentSave.TabIndex = 36;
            this.BtnPaymentSave.Text = "Save Payment";
            this.BtnPaymentSave.UseVisualStyleBackColor = false;
            this.BtnPaymentSave.Click += new System.EventHandler(this.BtnPaymentSave_Click);
            // 
            // DataGridSupplierList
            // 
            this.DataGridSupplierList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DataGridSupplierList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridSupplierList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridSupplierList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridSupplierList.Location = new System.Drawing.Point(16, 183);
            this.DataGridSupplierList.Name = "DataGridSupplierList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridSupplierList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridSupplierList.Size = new System.Drawing.Size(860, 305);
            this.DataGridSupplierList.TabIndex = 42;
            this.DataGridSupplierList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridSupplierTransaction_DataBindingComplete);
            // 
            // MaskEndOfDayFrom
            // 
            this.MaskEndOfDayFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayFrom.Location = new System.Drawing.Point(96, 504);
            this.MaskEndOfDayFrom.Mask = "0000-00-00";
            this.MaskEndOfDayFrom.Name = "MaskEndOfDayFrom";
            this.MaskEndOfDayFrom.Size = new System.Drawing.Size(100, 26);
            this.MaskEndOfDayFrom.TabIndex = 17;
            this.MaskEndOfDayFrom.ValidatingType = typeof(System.DateTime);
            // 
            // MaskEndOfDayTo
            // 
            this.MaskEndOfDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayTo.Location = new System.Drawing.Point(266, 505);
            this.MaskEndOfDayTo.Mask = "0000-00-00";
            this.MaskEndOfDayTo.Name = "MaskEndOfDayTo";
            this.MaskEndOfDayTo.Size = new System.Drawing.Size(100, 26);
            this.MaskEndOfDayTo.TabIndex = 44;
            this.MaskEndOfDayTo.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox4
            // 
            this.groupBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox4.BackgroundImage")));
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(-1, -1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1043, 45);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Cyan;
            this.label5.Location = new System.Drawing.Point(349, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(350, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "Suppliership Management";
            // 
            // BtnShowTransaction
            // 
            this.BtnShowTransaction.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnShowTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnShowTransaction.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.BtnShowTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowTransaction.ForeColor = System.Drawing.Color.Cyan;
            this.BtnShowTransaction.Location = new System.Drawing.Point(739, 499);
            this.BtnShowTransaction.Name = "BtnShowTransaction";
            this.BtnShowTransaction.Size = new System.Drawing.Size(135, 38);
            this.BtnShowTransaction.TabIndex = 7;
            this.BtnShowTransaction.Text = "ShowTransaction";
            this.BtnShowTransaction.UseVisualStyleBackColor = false;
            this.BtnShowTransaction.Click += new System.EventHandler(this.BtnShowTransaction_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnPurchase);
            this.groupBox2.Controls.Add(this.BtnShowPurchase);
            this.groupBox2.Controls.Add(this.BtnPaymentSave);
            this.groupBox2.Location = new System.Drawing.Point(887, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 135);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1045, 551);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnShowTransaction);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.MaskEndOfDayTo);
            this.Controls.Add(this.MaskEndOfDayFrom);
            this.Controls.Add(this.DataGridSupplierList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.TxtTotalAmount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ComboAction);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(569, 240);
            this.Name = "SupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.SupplierForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSupplierList)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnAddSupplier;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox TxtTotalAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox ComboBank;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox ComboPayment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnShowSupplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboAction;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnPurchase;
        private System.Windows.Forms.Button BtnPaymentSave;
        private System.Windows.Forms.TextBox TextBoxDebitCredit;
        private System.Windows.Forms.RichTextBox RichAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtBillNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView DataGridSupplierList;
        private System.Windows.Forms.Button BtnShowPurchase;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayFrom;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayTo;
        private System.Windows.Forms.TextBox TxtBalance;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnShowTransaction;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtContactNumber;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtSupplierName;
        private System.Windows.Forms.TextBox TxtOwner;
        private System.Windows.Forms.TextBox TxtSupplierId;
    }
}