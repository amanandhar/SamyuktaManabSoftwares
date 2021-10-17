
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnUpdate = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnEdit = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSave = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddSupplier = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboAction = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSearchSupplier = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
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
            this.label4 = new System.Windows.Forms.Label();
            this.RichAmount = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DataGridSupplierList = new System.Windows.Forms.DataGridView();
            this.MaskEndOfDayFrom = new System.Windows.Forms.MaskedTextBox();
            this.MaskEndOfDayTo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSavePayment = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnShowPurchase = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddPurchase = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnShowTransaction = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSupplierList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnDelete);
            this.groupBox3.Controls.Add(this.BtnUpdate);
            this.groupBox3.Controls.Add(this.BtnEdit);
            this.groupBox3.Controls.Add(this.BtnSave);
            this.groupBox3.Controls.Add(this.BtnAddSupplier);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(944, 322);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 210);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create Supplier";
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.Red;
            this.BtnDelete.BackgroundColor = System.Drawing.Color.Red;
            this.BtnDelete.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnDelete.BorderRadius = 35;
            this.BtnDelete.BorderSize = 0;
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatAppearance.BorderSize = 0;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(11, 167);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(122, 35);
            this.BtnDelete.TabIndex = 48;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.TextColor = System.Drawing.Color.White;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdate.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdate.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnUpdate.BorderRadius = 35;
            this.BtnUpdate.BorderSize = 0;
            this.BtnUpdate.Enabled = false;
            this.BtnUpdate.FlatAppearance.BorderSize = 0;
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnUpdate.Location = new System.Drawing.Point(11, 131);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(122, 35);
            this.BtnUpdate.TabIndex = 47;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.TextColor = System.Drawing.Color.White;
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.Red;
            this.BtnEdit.BackgroundColor = System.Drawing.Color.Red;
            this.BtnEdit.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnEdit.BorderRadius = 35;
            this.BtnEdit.BorderSize = 0;
            this.BtnEdit.Enabled = false;
            this.BtnEdit.FlatAppearance.BorderSize = 0;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(11, 95);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(122, 35);
            this.BtnEdit.TabIndex = 46;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.TextColor = System.Drawing.Color.White;
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSave.BorderRadius = 35;
            this.BtnSave.BorderSize = 0;
            this.BtnSave.Enabled = false;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(10, 59);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(122, 35);
            this.BtnSave.TabIndex = 45;
            this.BtnSave.Text = "Save";
            this.BtnSave.TextColor = System.Drawing.Color.White;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnAddSupplier
            // 
            this.BtnAddSupplier.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddSupplier.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddSupplier.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAddSupplier.BorderRadius = 35;
            this.BtnAddSupplier.BorderSize = 0;
            this.BtnAddSupplier.Enabled = false;
            this.BtnAddSupplier.FlatAppearance.BorderSize = 0;
            this.BtnAddSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddSupplier.ForeColor = System.Drawing.Color.White;
            this.BtnAddSupplier.Location = new System.Drawing.Point(10, 23);
            this.BtnAddSupplier.Name = "BtnAddSupplier";
            this.BtnAddSupplier.Size = new System.Drawing.Size(122, 35);
            this.BtnAddSupplier.TabIndex = 44;
            this.BtnAddSupplier.Text = "Add ";
            this.BtnAddSupplier.TextColor = System.Drawing.Color.White;
            this.BtnAddSupplier.UseVisualStyleBackColor = false;
            this.BtnAddSupplier.Click += new System.EventHandler(this.BtnAddSuppliers_Click);
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
            this.TxtTotalAmount.Location = new System.Drawing.Point(597, 19);
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
            this.label14.Location = new System.Drawing.Point(422, 78);
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
            this.ComboBank.Location = new System.Drawing.Point(56, 47);
            this.ComboBank.Name = "ComboBank";
            this.ComboBank.Size = new System.Drawing.Size(215, 26);
            this.ComboBank.TabIndex = 22;
            this.ComboBank.SelectedValueChanged += new System.EventHandler(this.ComboBank_SelectedValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(9, 51);
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
            this.label13.Location = new System.Drawing.Point(62, 80);
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
            this.ComboPayment.Location = new System.Drawing.Point(126, 17);
            this.ComboPayment.Name = "ComboPayment";
            this.ComboPayment.Size = new System.Drawing.Size(145, 26);
            this.ComboPayment.TabIndex = 18;
            this.ComboPayment.SelectedValueChanged += new System.EventHandler(this.ComboPaymentType_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(198, 21);
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
            this.label10.Location = new System.Drawing.Point(497, 23);
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
            this.label9.Location = new System.Drawing.Point(10, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 18);
            this.label9.TabIndex = 33;
            this.label9.Text = "Date From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(6, 19);
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
            this.label2.Location = new System.Drawing.Point(5, 48);
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
            this.label3.Location = new System.Drawing.Point(6, 77);
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
            this.label6.Location = new System.Drawing.Point(423, 49);
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
            this.ComboAction.Location = new System.Drawing.Point(369, 18);
            this.ComboAction.Name = "ComboAction";
            this.ComboAction.Size = new System.Drawing.Size(120, 26);
            this.ComboAction.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnSearchSupplier);
            this.groupBox1.Controls.Add(this.TxtSupplierId);
            this.groupBox1.Controls.Add(this.TxtOwner);
            this.groupBox1.Controls.Add(this.TxtSupplierName);
            this.groupBox1.Controls.Add(this.TxtAddress);
            this.groupBox1.Controls.Add(this.TxtEmail);
            this.groupBox1.Controls.Add(this.TxtContactNumber);
            this.groupBox1.Controls.Add(this.TxtBalance);
            this.groupBox1.Controls.Add(this.TxtBillNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TextBoxDebitCredit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(16, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 120);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier\'sDetails";
            // 
            // BtnSearchSupplier
            // 
            this.BtnSearchSupplier.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchSupplier.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchSupplier.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSearchSupplier.BorderRadius = 10;
            this.BtnSearchSupplier.BorderSize = 0;
            this.BtnSearchSupplier.Enabled = false;
            this.BtnSearchSupplier.FlatAppearance.BorderSize = 0;
            this.BtnSearchSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchSupplier.ForeColor = System.Drawing.Color.White;
            this.BtnSearchSupplier.Location = new System.Drawing.Point(349, 14);
            this.BtnSearchSupplier.Name = "BtnSearchSupplier";
            this.BtnSearchSupplier.Size = new System.Drawing.Size(70, 28);
            this.BtnSearchSupplier.TabIndex = 50;
            this.BtnSearchSupplier.Text = "Search";
            this.BtnSearchSupplier.TextColor = System.Drawing.Color.White;
            this.BtnSearchSupplier.UseVisualStyleBackColor = false;
            this.BtnSearchSupplier.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtSupplierId
            // 
            this.TxtSupplierId.BackColor = System.Drawing.Color.White;
            this.TxtSupplierId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSupplierId.Location = new System.Drawing.Point(101, 15);
            this.TxtSupplierId.Name = "TxtSupplierId";
            this.TxtSupplierId.ReadOnly = true;
            this.TxtSupplierId.Size = new System.Drawing.Size(65, 26);
            this.TxtSupplierId.TabIndex = 49;
            // 
            // TxtOwner
            // 
            this.TxtOwner.BackColor = System.Drawing.Color.White;
            this.TxtOwner.Enabled = false;
            this.TxtOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOwner.Location = new System.Drawing.Point(101, 45);
            this.TxtOwner.Name = "TxtOwner";
            this.TxtOwner.Size = new System.Drawing.Size(318, 26);
            this.TxtOwner.TabIndex = 48;
            // 
            // TxtSupplierName
            // 
            this.TxtSupplierName.BackColor = System.Drawing.Color.White;
            this.TxtSupplierName.Enabled = false;
            this.TxtSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSupplierName.Location = new System.Drawing.Point(168, 15);
            this.TxtSupplierName.Name = "TxtSupplierName";
            this.TxtSupplierName.Size = new System.Drawing.Size(180, 26);
            this.TxtSupplierName.TabIndex = 47;
            // 
            // TxtAddress
            // 
            this.TxtAddress.BackColor = System.Drawing.Color.White;
            this.TxtAddress.Enabled = false;
            this.TxtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAddress.Location = new System.Drawing.Point(101, 74);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(318, 26);
            this.TxtAddress.TabIndex = 46;
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.Color.White;
            this.TxtEmail.Enabled = false;
            this.TxtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtEmail.Location = new System.Drawing.Point(489, 15);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(275, 26);
            this.TxtEmail.TabIndex = 45;
            // 
            // TxtContactNumber
            // 
            this.TxtContactNumber.BackColor = System.Drawing.Color.White;
            this.TxtContactNumber.Enabled = false;
            this.TxtContactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContactNumber.Location = new System.Drawing.Point(489, 45);
            this.TxtContactNumber.Name = "TxtContactNumber";
            this.TxtContactNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtContactNumber.Size = new System.Drawing.Size(105, 26);
            this.TxtContactNumber.TabIndex = 44;
            this.TxtContactNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtContactNumber_KeyPress);
            // 
            // TxtBalance
            // 
            this.TxtBalance.BackColor = System.Drawing.Color.White;
            this.TxtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtBalance.Location = new System.Drawing.Point(489, 75);
            this.TxtBalance.Name = "TxtBalance";
            this.TxtBalance.ReadOnly = true;
            this.TxtBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBalance.Size = new System.Drawing.Size(213, 26);
            this.TxtBalance.TabIndex = 43;
            // 
            // TxtBillNo
            // 
            this.TxtBillNo.BackColor = System.Drawing.Color.White;
            this.TxtBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBillNo.Location = new System.Drawing.Point(654, 45);
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
            this.label7.Location = new System.Drawing.Point(596, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 18);
            this.label7.TabIndex = 38;
            this.label7.Text = "Bill No";
            // 
            // TextBoxDebitCredit
            // 
            this.TextBoxDebitCredit.BackColor = System.Drawing.Color.White;
            this.TextBoxDebitCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDebitCredit.Location = new System.Drawing.Point(705, 75);
            this.TextBoxDebitCredit.Name = "TextBoxDebitCredit";
            this.TextBoxDebitCredit.ReadOnly = true;
            this.TextBoxDebitCredit.Size = new System.Drawing.Size(60, 26);
            this.TextBoxDebitCredit.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(423, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 30;
            this.label4.Text = "Email ID";
            // 
            // RichAmount
            // 
            this.RichAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RichAmount.Enabled = false;
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(126, 76);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(145, 28);
            this.RichAmount.TabIndex = 33;
            this.RichAmount.Text = "";
            this.RichAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichAmount_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(57, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 18);
            this.label12.TabIndex = 17;
            this.label12.Text = "Payment";
            // 
            // DataGridSupplierList
            // 
            this.DataGridSupplierList.BackgroundColor = System.Drawing.Color.White;
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
            this.DataGridSupplierList.Location = new System.Drawing.Point(16, 173);
            this.DataGridSupplierList.Name = "DataGridSupplierList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridSupplierList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridSupplierList.Size = new System.Drawing.Size(915, 360);
            this.DataGridSupplierList.TabIndex = 42;
            this.DataGridSupplierList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridSupplierTransaction_DataBindingComplete);
            // 
            // MaskEndOfDayFrom
            // 
            this.MaskEndOfDayFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayFrom.Location = new System.Drawing.Point(92, 18);
            this.MaskEndOfDayFrom.Mask = "0000-00-00";
            this.MaskEndOfDayFrom.Name = "MaskEndOfDayFrom";
            this.MaskEndOfDayFrom.Size = new System.Drawing.Size(100, 24);
            this.MaskEndOfDayFrom.TabIndex = 17;
            this.MaskEndOfDayFrom.ValidatingType = typeof(System.DateTime);
            // 
            // MaskEndOfDayTo
            // 
            this.MaskEndOfDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDayTo.Location = new System.Drawing.Point(262, 18);
            this.MaskEndOfDayTo.Mask = "0000-00-00";
            this.MaskEndOfDayTo.Name = "MaskEndOfDayTo";
            this.MaskEndOfDayTo.Size = new System.Drawing.Size(100, 24);
            this.MaskEndOfDayTo.TabIndex = 44;
            this.MaskEndOfDayTo.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSavePayment);
            this.groupBox2.Controls.Add(this.BtnShowPurchase);
            this.groupBox2.Controls.Add(this.BtnAddPurchase);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(944, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 135);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transaction";
            // 
            // BtnSavePayment
            // 
            this.BtnSavePayment.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSavePayment.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSavePayment.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSavePayment.BorderRadius = 35;
            this.BtnSavePayment.BorderSize = 0;
            this.BtnSavePayment.Enabled = false;
            this.BtnSavePayment.FlatAppearance.BorderSize = 0;
            this.BtnSavePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSavePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSavePayment.ForeColor = System.Drawing.Color.White;
            this.BtnSavePayment.Location = new System.Drawing.Point(10, 92);
            this.BtnSavePayment.Name = "BtnSavePayment";
            this.BtnSavePayment.Size = new System.Drawing.Size(122, 35);
            this.BtnSavePayment.TabIndex = 43;
            this.BtnSavePayment.Text = "Save Payment";
            this.BtnSavePayment.TextColor = System.Drawing.Color.White;
            this.BtnSavePayment.UseVisualStyleBackColor = false;
            this.BtnSavePayment.Click += new System.EventHandler(this.BtnSavePayment_Click);
            // 
            // BtnShowPurchase
            // 
            this.BtnShowPurchase.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnShowPurchase.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnShowPurchase.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowPurchase.BorderRadius = 35;
            this.BtnShowPurchase.BorderSize = 0;
            this.BtnShowPurchase.Enabled = false;
            this.BtnShowPurchase.FlatAppearance.BorderSize = 0;
            this.BtnShowPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowPurchase.ForeColor = System.Drawing.Color.White;
            this.BtnShowPurchase.Location = new System.Drawing.Point(10, 56);
            this.BtnShowPurchase.Name = "BtnShowPurchase";
            this.BtnShowPurchase.Size = new System.Drawing.Size(122, 35);
            this.BtnShowPurchase.TabIndex = 42;
            this.BtnShowPurchase.Text = "Show Purchase";
            this.BtnShowPurchase.TextColor = System.Drawing.Color.White;
            this.BtnShowPurchase.UseVisualStyleBackColor = false;
            this.BtnShowPurchase.Click += new System.EventHandler(this.BtnShowPurchase_Click);
            // 
            // BtnAddPurchase
            // 
            this.BtnAddPurchase.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddPurchase.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddPurchase.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAddPurchase.BorderRadius = 35;
            this.BtnAddPurchase.BorderSize = 0;
            this.BtnAddPurchase.Enabled = false;
            this.BtnAddPurchase.FlatAppearance.BorderSize = 0;
            this.BtnAddPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddPurchase.ForeColor = System.Drawing.Color.White;
            this.BtnAddPurchase.Location = new System.Drawing.Point(10, 20);
            this.BtnAddPurchase.Name = "BtnAddPurchase";
            this.BtnAddPurchase.Size = new System.Drawing.Size(122, 35);
            this.BtnAddPurchase.TabIndex = 41;
            this.BtnAddPurchase.Text = "Add Purchase";
            this.BtnAddPurchase.TextColor = System.Drawing.Color.White;
            this.BtnAddPurchase.UseVisualStyleBackColor = false;
            this.BtnAddPurchase.Click += new System.EventHandler(this.BtnAddPurchase_Click);
            // 
            // BtnShowTransaction
            // 
            this.BtnShowTransaction.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnShowTransaction.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnShowTransaction.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowTransaction.BorderRadius = 35;
            this.BtnShowTransaction.BorderSize = 0;
            this.BtnShowTransaction.Enabled = false;
            this.BtnShowTransaction.FlatAppearance.BorderSize = 0;
            this.BtnShowTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowTransaction.ForeColor = System.Drawing.Color.White;
            this.BtnShowTransaction.Location = new System.Drawing.Point(759, 13);
            this.BtnShowTransaction.Name = "BtnShowTransaction";
            this.BtnShowTransaction.Size = new System.Drawing.Size(140, 35);
            this.BtnShowTransaction.TabIndex = 49;
            this.BtnShowTransaction.Text = "Show Transaction";
            this.BtnShowTransaction.TextColor = System.Drawing.Color.White;
            this.BtnShowTransaction.UseVisualStyleBackColor = false;
            this.BtnShowTransaction.Click += new System.EventHandler(this.BtnShowTransaction_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1103, 44);
            this.textBox1.TabIndex = 50;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ComboPayment);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.ComboBank);
            this.groupBox4.Controls.Add(this.RichAmount);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(801, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 120);
            this.groupBox4.TabIndex = 51;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Payment";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ComboAction);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.BtnShowTransaction);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.TxtTotalAmount);
            this.groupBox5.Controls.Add(this.MaskEndOfDayTo);
            this.groupBox5.Controls.Add(this.MaskEndOfDayFrom);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Red;
            this.groupBox5.Location = new System.Drawing.Point(17, 538);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(915, 55);
            this.groupBox5.TabIndex = 52;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Transaction";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DodgerBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Cyan;
            this.label5.Location = new System.Drawing.Point(386, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(296, 31);
            this.label5.TabIndex = 53;
            this.label5.Text = "Supplier Management";
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1088, 597);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DataGridSupplierList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(569, 240);
            this.Name = "SupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SupplierForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSupplierList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboAction;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TextBoxDebitCredit;
        private System.Windows.Forms.RichTextBox RichAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtBillNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView DataGridSupplierList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayFrom;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDayTo;
        private System.Windows.Forms.TextBox TxtBalance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtContactNumber;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtSupplierName;
        private System.Windows.Forms.TextBox TxtOwner;
        private System.Windows.Forms.TextBox TxtSupplierId;
        private CustomControls.Button.CustomButton BtnAddPurchase;
        private CustomControls.Button.CustomButton BtnShowPurchase;
        private CustomControls.Button.CustomButton BtnSavePayment;
        private CustomControls.Button.CustomButton BtnAddSupplier;
        private CustomControls.Button.CustomButton BtnSave;
        private CustomControls.Button.CustomButton BtnEdit;
        private CustomControls.Button.CustomButton BtnUpdate;
        private CustomControls.Button.CustomButton BtnDelete;
        private CustomControls.Button.CustomButton BtnShowTransaction;
        private CustomControls.Button.CustomButton BtnSearchSupplier;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
    }
}