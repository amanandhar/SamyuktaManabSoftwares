
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
            this.BtnDelete = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnAddSupplier = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnShowDetails = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ComboBank = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ComboPayment = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.RichContactNumber = new System.Windows.Forms.RichTextBox();
            this.BtnShowSupplier = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RichSupplierName = new System.Windows.Forms.RichTextBox();
            this.RichOwner = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RichSupplierId = new System.Windows.Forms.RichTextBox();
            this.BtnShowPurchase = new System.Windows.Forms.Button();
            this.TxtBillNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnPurchase = new System.Windows.Forms.Button();
            this.BtnPaymentSave = new System.Windows.Forms.Button();
            this.TextBoxDebitCredit = new System.Windows.Forms.TextBox();
            this.RichBalance = new System.Windows.Forms.RichTextBox();
            this.RichAmount = new System.Windows.Forms.RichTextBox();
            this.RichEmail = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.RichAddress = new System.Windows.Forms.RichTextBox();
            this.DataGridSupplierList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MaskEndOfDayFrom = new System.Windows.Forms.MaskedTextBox();
            this.MaskEndOfDayTo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSupplierList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.Red;
            this.BtnDelete.Location = new System.Drawing.Point(8, 161);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(135, 35);
            this.BtnDelete.TabIndex = 6;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnUpdate);
            this.groupBox3.Controls.Add(this.BtnAddSupplier);
            this.groupBox3.Controls.Add(this.BtnSave);
            this.groupBox3.Controls.Add(this.BtnEdit);
            this.groupBox3.Controls.Add(this.BtnDelete);
            this.groupBox3.Location = new System.Drawing.Point(882, 207);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 202);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnUpdate.Location = new System.Drawing.Point(8, 124);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(135, 35);
            this.BtnUpdate.TabIndex = 11;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnAddSupplier
            // 
            this.BtnAddSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddSupplier.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAddSupplier.Location = new System.Drawing.Point(8, 13);
            this.BtnAddSupplier.Name = "BtnAddSupplier";
            this.BtnAddSupplier.Size = new System.Drawing.Size(135, 35);
            this.BtnAddSupplier.TabIndex = 10;
            this.BtnAddSupplier.Text = "Add Suppliers";
            this.BtnAddSupplier.UseVisualStyleBackColor = true;
            this.BtnAddSupplier.Click += new System.EventHandler(this.BtnAddSupplier_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSave.Location = new System.Drawing.Point(8, 50);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(135, 35);
            this.BtnSave.TabIndex = 9;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.Red;
            this.BtnEdit.Location = new System.Drawing.Point(8, 87);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(135, 35);
            this.BtnEdit.TabIndex = 8;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnShowDetails
            // 
            this.BtnShowDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowDetails.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowDetails.Location = new System.Drawing.Point(8, 16);
            this.BtnShowDetails.Name = "BtnShowDetails";
            this.BtnShowDetails.Size = new System.Drawing.Size(135, 70);
            this.BtnShowDetails.TabIndex = 7;
            this.BtnShowDetails.Text = "Show Transaction";
            this.BtnShowDetails.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1043, 26);
            this.textBox1.TabIndex = 30;
            this.textBox1.Tag = "               ";
            this.textBox1.Text = "                                                                                 " +
    "   Suppliers Transaction\r\n";
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
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(697, 503);
            this.textBox3.Name = "textBox3";
            this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox3.Size = new System.Drawing.Size(130, 24);
            this.textBox3.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(624, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 20);
            this.label14.TabIndex = 23;
            this.label14.Text = "Balance";
            // 
            // ComboBank
            // 
            this.ComboBank.BackColor = System.Drawing.Color.White;
            this.ComboBank.Enabled = false;
            this.ComboBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBank.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ComboBank.FormattingEnabled = true;
            this.ComboBank.Location = new System.Drawing.Point(251, 109);
            this.ComboBank.Name = "ComboBank";
            this.ComboBank.Size = new System.Drawing.Size(205, 28);
            this.ComboBank.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(204, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 20);
            this.label15.TabIndex = 21;
            this.label15.Text = "Bank";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(467, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 20);
            this.label13.TabIndex = 19;
            this.label13.Text = "Amount";
            // 
            // ComboPayment
            // 
            this.ComboPayment.BackColor = System.Drawing.Color.White;
            this.ComboPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPayment.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ComboPayment.FormattingEnabled = true;
            this.ComboPayment.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboPayment.Location = new System.Drawing.Point(120, 109);
            this.ComboPayment.Name = "ComboPayment";
            this.ComboPayment.Size = new System.Drawing.Size(80, 28);
            this.ComboPayment.TabIndex = 18;
            this.ComboPayment.SelectedValueChanged += new System.EventHandler(this.ComboPaymentType_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(229, 506);
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
            this.label10.Location = new System.Drawing.Point(598, 506);
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
            this.label9.Location = new System.Drawing.Point(33, 505);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 18);
            this.label9.TabIndex = 33;
            this.label9.Text = "Date From";
            // 
            // RichContactNumber
            // 
            this.RichContactNumber.BackColor = System.Drawing.Color.White;
            this.RichContactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichContactNumber.Location = new System.Drawing.Point(531, 46);
            this.RichContactNumber.Name = "RichContactNumber";
            this.RichContactNumber.Size = new System.Drawing.Size(147, 30);
            this.RichContactNumber.TabIndex = 12;
            this.RichContactNumber.Text = "";
            // 
            // BtnShowSupplier
            // 
            this.BtnShowSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowSupplier.ForeColor = System.Drawing.Color.Red;
            this.BtnShowSupplier.Location = new System.Drawing.Point(410, 14);
            this.BtnShowSupplier.Name = "BtnShowSupplier";
            this.BtnShowSupplier.Size = new System.Drawing.Size(40, 30);
            this.BtnShowSupplier.TabIndex = 7;
            this.BtnShowSupplier.Text = "C";
            this.BtnShowSupplier.UseVisualStyleBackColor = true;
            this.BtnShowSupplier.Click += new System.EventHandler(this.BtnShowSupplier_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Supplier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(16, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Owner Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(18, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(461, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Contact ";
            // 
            // RichSupplierName
            // 
            this.RichSupplierName.BackColor = System.Drawing.Color.White;
            this.RichSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichSupplierName.Location = new System.Drawing.Point(180, 15);
            this.RichSupplierName.Name = "RichSupplierName";
            this.RichSupplierName.Size = new System.Drawing.Size(230, 30);
            this.RichSupplierName.TabIndex = 5;
            this.RichSupplierName.Text = "";
            // 
            // RichOwner
            // 
            this.RichOwner.BackColor = System.Drawing.Color.White;
            this.RichOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichOwner.Location = new System.Drawing.Point(120, 46);
            this.RichOwner.Name = "RichOwner";
            this.RichOwner.Size = new System.Drawing.Size(330, 30);
            this.RichOwner.TabIndex = 2;
            this.RichOwner.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Purchase",
            "Payment"});
            this.comboBox1.Location = new System.Drawing.Point(464, 502);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 26);
            this.comboBox1.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RichSupplierId);
            this.groupBox1.Controls.Add(this.BtnShowPurchase);
            this.groupBox1.Controls.Add(this.TxtBillNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ComboPayment);
            this.groupBox1.Controls.Add(this.BtnPurchase);
            this.groupBox1.Controls.Add(this.BtnPaymentSave);
            this.groupBox1.Controls.Add(this.TextBoxDebitCredit);
            this.groupBox1.Controls.Add(this.RichBalance);
            this.groupBox1.Controls.Add(this.RichAmount);
            this.groupBox1.Controls.Add(this.RichEmail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.ComboBank);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.RichContactNumber);
            this.groupBox1.Controls.Add(this.BtnShowSupplier);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.RichSupplierName);
            this.groupBox1.Controls.Add(this.RichOwner);
            this.groupBox1.Controls.Add(this.RichAddress);
            this.groupBox1.Location = new System.Drawing.Point(16, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1015, 145);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // RichSupplierId
            // 
            this.RichSupplierId.Enabled = false;
            this.RichSupplierId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichSupplierId.Location = new System.Drawing.Point(120, 15);
            this.RichSupplierId.Name = "RichSupplierId";
            this.RichSupplierId.Size = new System.Drawing.Size(60, 30);
            this.RichSupplierId.TabIndex = 42;
            this.RichSupplierId.Text = "";
            // 
            // BtnShowPurchase
            // 
            this.BtnShowPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnShowPurchase.Enabled = false;
            this.BtnShowPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowPurchase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnShowPurchase.Location = new System.Drawing.Point(872, 54);
            this.BtnShowPurchase.Name = "BtnShowPurchase";
            this.BtnShowPurchase.Size = new System.Drawing.Size(135, 40);
            this.BtnShowPurchase.TabIndex = 40;
            this.BtnShowPurchase.Text = "Show Purchase";
            this.BtnShowPurchase.UseVisualStyleBackColor = true;
            this.BtnShowPurchase.Click += new System.EventHandler(this.BtnShowPurchase_Click);
            // 
            // TxtBillNo
            // 
            this.TxtBillNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBillNo.Location = new System.Drawing.Point(741, 47);
            this.TxtBillNo.Name = "TxtBillNo";
            this.TxtBillNo.Size = new System.Drawing.Size(111, 26);
            this.TxtBillNo.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(680, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 38;
            this.label7.Text = "Bill No";
            // 
            // BtnPurchase
            // 
            this.BtnPurchase.Enabled = false;
            this.BtnPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPurchase.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnPurchase.Location = new System.Drawing.Point(872, 12);
            this.BtnPurchase.Name = "BtnPurchase";
            this.BtnPurchase.Size = new System.Drawing.Size(135, 40);
            this.BtnPurchase.TabIndex = 37;
            this.BtnPurchase.Text = "Purchase";
            this.BtnPurchase.UseVisualStyleBackColor = true;
            this.BtnPurchase.Click += new System.EventHandler(this.BtnPurchase_Click);
            // 
            // BtnPaymentSave
            // 
            this.BtnPaymentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPaymentSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnPaymentSave.Location = new System.Drawing.Point(872, 96);
            this.BtnPaymentSave.Name = "BtnPaymentSave";
            this.BtnPaymentSave.Size = new System.Drawing.Size(135, 40);
            this.BtnPaymentSave.TabIndex = 36;
            this.BtnPaymentSave.Text = "Save Payment ";
            this.BtnPaymentSave.UseVisualStyleBackColor = true;
            this.BtnPaymentSave.Click += new System.EventHandler(this.BtnPaymentSave_Click);
            // 
            // TextBoxDebitCredit
            // 
            this.TextBoxDebitCredit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBoxDebitCredit.Enabled = false;
            this.TextBoxDebitCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDebitCredit.Location = new System.Drawing.Point(802, 108);
            this.TextBoxDebitCredit.Name = "TextBoxDebitCredit";
            this.TextBoxDebitCredit.Size = new System.Drawing.Size(50, 27);
            this.TextBoxDebitCredit.TabIndex = 35;
            // 
            // RichBalance
            // 
            this.RichBalance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RichBalance.Enabled = false;
            this.RichBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBalance.Location = new System.Drawing.Point(701, 107);
            this.RichBalance.Name = "RichBalance";
            this.RichBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichBalance.Size = new System.Drawing.Size(100, 30);
            this.RichBalance.TabIndex = 34;
            this.RichBalance.Text = "";
            // 
            // RichAmount
            // 
            this.RichAmount.BackColor = System.Drawing.Color.White;
            this.RichAmount.Enabled = false;
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(531, 109);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(92, 28);
            this.RichAmount.TabIndex = 33;
            this.RichAmount.Text = "";
            // 
            // RichEmail
            // 
            this.RichEmail.BackColor = System.Drawing.Color.White;
            this.RichEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichEmail.Location = new System.Drawing.Point(531, 15);
            this.RichEmail.Name = "RichEmail";
            this.RichEmail.Size = new System.Drawing.Size(322, 30);
            this.RichEmail.TabIndex = 31;
            this.RichEmail.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(460, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Email ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(17, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "Payment";
            // 
            // RichAddress
            // 
            this.RichAddress.BackColor = System.Drawing.Color.White;
            this.RichAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAddress.Location = new System.Drawing.Point(120, 77);
            this.RichAddress.Name = "RichAddress";
            this.RichAddress.Size = new System.Drawing.Size(330, 30);
            this.RichAddress.TabIndex = 1;
            this.RichAddress.Text = "";
            // 
            // DataGridSupplierList
            // 
            this.DataGridSupplierList.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.DataGridSupplierList.Location = new System.Drawing.Point(18, 184);
            this.DataGridSupplierList.Name = "DataGridSupplierList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridSupplierList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridSupplierList.Size = new System.Drawing.Size(850, 300);
            this.DataGridSupplierList.TabIndex = 42;
            this.DataGridSupplierList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridSupplierTransaction_DataBindingComplete);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnShowDetails);
            this.groupBox2.Location = new System.Drawing.Point(882, 435);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 95);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            // 
            // MaskEndOfDayFrom
            // 
            this.MaskEndOfDayFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayFrom.Location = new System.Drawing.Point(118, 501);
            this.MaskEndOfDayFrom.Mask = "0000-00-00";
            this.MaskEndOfDayFrom.Name = "MaskEndOfDayFrom";
            this.MaskEndOfDayFrom.Size = new System.Drawing.Size(105, 26);
            this.MaskEndOfDayFrom.TabIndex = 17;
            this.MaskEndOfDayFrom.ValidatingType = typeof(System.DateTime);
            // 
            // MaskEndOfDayTo
            // 
            this.MaskEndOfDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayTo.Location = new System.Drawing.Point(296, 503);
            this.MaskEndOfDayTo.Mask = "0000-00-00";
            this.MaskEndOfDayTo.Name = "MaskEndOfDayTo";
            this.MaskEndOfDayTo.Size = new System.Drawing.Size(105, 26);
            this.MaskEndOfDayTo.TabIndex = 44;
            this.MaskEndOfDayTo.ValidatingType = typeof(System.DateTime);
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.MaskEndOfDayTo);
            this.Controls.Add(this.MaskEndOfDayFrom);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DataGridSupplierList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SupplierForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSupplierList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnShowDetails;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnAddSupplier;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox ComboBank;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox ComboPayment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox RichContactNumber;
        private System.Windows.Forms.Button BtnShowSupplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox RichSupplierName;
        private System.Windows.Forms.RichTextBox RichOwner;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox RichAddress;
        private System.Windows.Forms.Button BtnPurchase;
        private System.Windows.Forms.Button BtnPaymentSave;
        private System.Windows.Forms.TextBox TextBoxDebitCredit;
        private System.Windows.Forms.RichTextBox RichBalance;
        private System.Windows.Forms.RichTextBox RichAmount;
        private System.Windows.Forms.RichTextBox RichEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtBillNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView DataGridSupplierList;
        private System.Windows.Forms.Button BtnShowPurchase;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox RichSupplierId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayFrom;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayTo;
    }
}