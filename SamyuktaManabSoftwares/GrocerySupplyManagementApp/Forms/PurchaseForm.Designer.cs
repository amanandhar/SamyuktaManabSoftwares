
namespace GrocerySupplyManagementApp.Forms
{
    partial class PurchaseForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RichBillNo = new System.Windows.Forms.RichTextBox();
            this.RichItemName = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkBoxVat = new System.Windows.Forms.CheckBox();
            this.RichVat = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.RichDiscount = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.RichTotalAmount = new System.Windows.Forms.RichTextBox();
            this.RichUnit = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.RichQuantity = new System.Windows.Forms.RichTextBox();
            this.BtnSearchItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RichItemCode = new System.Windows.Forms.RichTextBox();
            this.TxtBillAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.RichPurchasePrice = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnRemoveItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnClearItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSaveItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.DataGridPurchaseList = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnAddBill = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPurchaseList)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(450, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(919, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Unit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(435, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Quantity";
            // 
            // RichBillNo
            // 
            this.RichBillNo.BackColor = System.Drawing.Color.White;
            this.RichBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBillNo.Location = new System.Drawing.Point(117, 18);
            this.RichBillNo.Name = "RichBillNo";
            this.RichBillNo.ReadOnly = true;
            this.RichBillNo.Size = new System.Drawing.Size(115, 28);
            this.RichBillNo.TabIndex = 1;
            this.RichBillNo.Text = "";
            // 
            // RichItemName
            // 
            this.RichItemName.BackColor = System.Drawing.Color.White;
            this.RichItemName.Enabled = false;
            this.RichItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichItemName.Location = new System.Drawing.Point(508, 19);
            this.RichItemName.Name = "RichItemName";
            this.RichItemName.Size = new System.Drawing.Size(285, 28);
            this.RichItemName.TabIndex = 5;
            this.RichItemName.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkBoxVat);
            this.groupBox1.Controls.Add(this.RichVat);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.RichDiscount);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.RichTotalAmount);
            this.groupBox1.Controls.Add(this.RichUnit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.RichQuantity);
            this.groupBox1.Controls.Add(this.BtnSearchItem);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.RichItemCode);
            this.groupBox1.Controls.Add(this.RichBillNo);
            this.groupBox1.Controls.Add(this.TxtBillAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RichItemName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RichPurchasePrice);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(11, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1065, 100);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Purchase Details";
            // 
            // ChkBoxVat
            // 
            this.ChkBoxVat.AutoSize = true;
            this.ChkBoxVat.Location = new System.Drawing.Point(663, 68);
            this.ChkBoxVat.Name = "ChkBoxVat";
            this.ChkBoxVat.Size = new System.Drawing.Size(15, 14);
            this.ChkBoxVat.TabIndex = 11;
            this.ChkBoxVat.UseVisualStyleBackColor = true;
            this.ChkBoxVat.CheckedChanged += new System.EventHandler(this.ChkBoxVat_CheckedChanged);
            // 
            // RichVat
            // 
            this.RichVat.BackColor = System.Drawing.Color.White;
            this.RichVat.Enabled = false;
            this.RichVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichVat.Location = new System.Drawing.Point(682, 60);
            this.RichVat.Multiline = false;
            this.RichVat.Name = "RichVat";
            this.RichVat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichVat.Size = new System.Drawing.Size(90, 28);
            this.RichVat.TabIndex = 12;
            this.RichVat.Text = "";
            this.RichVat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichVat_KeyDown);
            this.RichVat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichVat_KeyPress);
            this.RichVat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RichVat_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(596, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 18);
            this.label12.TabIndex = 29;
            this.label12.Text = "Vat 13%";
            // 
            // RichDiscount
            // 
            this.RichDiscount.BackColor = System.Drawing.Color.White;
            this.RichDiscount.Enabled = false;
            this.RichDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichDiscount.Location = new System.Drawing.Point(332, 58);
            this.RichDiscount.Multiline = false;
            this.RichDiscount.Name = "RichDiscount";
            this.RichDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichDiscount.Size = new System.Drawing.Size(90, 28);
            this.RichDiscount.TabIndex = 9;
            this.RichDiscount.Text = "";
            this.RichDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichDiscount_KeyDown);
            this.RichDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichDiscount_KeyPress);
            this.RichDiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RichDiscount_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(240, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 18);
            this.label11.TabIndex = 27;
            this.label11.Text = "Discount";
            // 
            // RichTotalAmount
            // 
            this.RichTotalAmount.BackColor = System.Drawing.Color.White;
            this.RichTotalAmount.Enabled = false;
            this.RichTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTotalAmount.Location = new System.Drawing.Point(117, 57);
            this.RichTotalAmount.Multiline = false;
            this.RichTotalAmount.Name = "RichTotalAmount";
            this.RichTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichTotalAmount.Size = new System.Drawing.Size(115, 28);
            this.RichTotalAmount.TabIndex = 8;
            this.RichTotalAmount.Text = "";
            this.RichTotalAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTotalAmount_KeyDown);
            this.RichTotalAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichTotalAmount_KeyPress);
            this.RichTotalAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RichTotalAmount_KeyUp);
            // 
            // RichUnit
            // 
            this.RichUnit.BackColor = System.Drawing.Color.White;
            this.RichUnit.Enabled = false;
            this.RichUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichUnit.Location = new System.Drawing.Point(957, 59);
            this.RichUnit.Name = "RichUnit";
            this.RichUnit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichUnit.Size = new System.Drawing.Size(90, 28);
            this.RichUnit.TabIndex = 7;
            this.RichUnit.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(7, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 18);
            this.label10.TabIndex = 25;
            this.label10.Text = "Total Amount";
            // 
            // RichQuantity
            // 
            this.RichQuantity.BackColor = System.Drawing.Color.White;
            this.RichQuantity.Enabled = false;
            this.RichQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichQuantity.Location = new System.Drawing.Point(499, 59);
            this.RichQuantity.Multiline = false;
            this.RichQuantity.Name = "RichQuantity";
            this.RichQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichQuantity.Size = new System.Drawing.Size(90, 28);
            this.RichQuantity.TabIndex = 10;
            this.RichQuantity.Text = "";
            this.RichQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichQuantity_KeyDown);
            this.RichQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichQuantity_KeyPress);
            this.RichQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RichQuantity_KeyUp);
            // 
            // BtnSearchItem
            // 
            this.BtnSearchItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchItem.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchItem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSearchItem.BorderRadius = 10;
            this.BtnSearchItem.BorderSize = 0;
            this.BtnSearchItem.FlatAppearance.BorderSize = 0;
            this.BtnSearchItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchItem.ForeColor = System.Drawing.Color.White;
            this.BtnSearchItem.Location = new System.Drawing.Point(977, 19);
            this.BtnSearchItem.Name = "BtnSearchItem";
            this.BtnSearchItem.Size = new System.Drawing.Size(70, 28);
            this.BtnSearchItem.TabIndex = 4;
            this.BtnSearchItem.Text = "Search";
            this.BtnSearchItem.TextColor = System.Drawing.Color.White;
            this.BtnSearchItem.UseVisualStyleBackColor = false;
            this.BtnSearchItem.Click += new System.EventHandler(this.BtnSearchItem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(235, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Bill Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Bill Number";
            // 
            // RichItemCode
            // 
            this.RichItemCode.Enabled = false;
            this.RichItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichItemCode.Location = new System.Drawing.Point(893, 20);
            this.RichItemCode.Name = "RichItemCode";
            this.RichItemCode.Size = new System.Drawing.Size(84, 28);
            this.RichItemCode.TabIndex = 3;
            this.RichItemCode.Text = "";
            // 
            // TxtBillAmount
            // 
            this.TxtBillAmount.BackColor = System.Drawing.Color.White;
            this.TxtBillAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBillAmount.Location = new System.Drawing.Point(332, 19);
            this.TxtBillAmount.Name = "TxtBillAmount";
            this.TxtBillAmount.ReadOnly = true;
            this.TxtBillAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBillAmount.Size = new System.Drawing.Size(115, 26);
            this.TxtBillAmount.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(776, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(799, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 18);
            this.label8.TabIndex = 24;
            this.label8.Text = " Item Code";
            // 
            // RichPurchasePrice
            // 
            this.RichPurchasePrice.BackColor = System.Drawing.Color.White;
            this.RichPurchasePrice.Enabled = false;
            this.RichPurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichPurchasePrice.Location = new System.Drawing.Point(822, 60);
            this.RichPurchasePrice.Multiline = false;
            this.RichPurchasePrice.Name = "RichPurchasePrice";
            this.RichPurchasePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichPurchasePrice.Size = new System.Drawing.Size(90, 28);
            this.RichPurchasePrice.TabIndex = 13;
            this.RichPurchasePrice.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnRemoveItem);
            this.groupBox2.Controls.Add(this.BtnClearItem);
            this.groupBox2.Controls.Add(this.BtnSaveItem);
            this.groupBox2.Controls.Add(this.BtnAddItem);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(933, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 180);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transaction";
            // 
            // BtnRemoveItem
            // 
            this.BtnRemoveItem.BackColor = System.Drawing.Color.Red;
            this.BtnRemoveItem.BackgroundColor = System.Drawing.Color.Red;
            this.BtnRemoveItem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnRemoveItem.BorderRadius = 35;
            this.BtnRemoveItem.BorderSize = 0;
            this.BtnRemoveItem.FlatAppearance.BorderSize = 0;
            this.BtnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.BtnRemoveItem.Location = new System.Drawing.Point(13, 132);
            this.BtnRemoveItem.Name = "BtnRemoveItem";
            this.BtnRemoveItem.Size = new System.Drawing.Size(120, 35);
            this.BtnRemoveItem.TabIndex = 18;
            this.BtnRemoveItem.Text = "Remove";
            this.BtnRemoveItem.TextColor = System.Drawing.Color.White;
            this.BtnRemoveItem.UseVisualStyleBackColor = false;
            this.BtnRemoveItem.Click += new System.EventHandler(this.BtnRemoveItem_Click);
            // 
            // BtnClearItem
            // 
            this.BtnClearItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnClearItem.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnClearItem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnClearItem.BorderRadius = 35;
            this.BtnClearItem.BorderSize = 0;
            this.BtnClearItem.FlatAppearance.BorderSize = 0;
            this.BtnClearItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearItem.ForeColor = System.Drawing.Color.White;
            this.BtnClearItem.Location = new System.Drawing.Point(13, 95);
            this.BtnClearItem.Name = "BtnClearItem";
            this.BtnClearItem.Size = new System.Drawing.Size(120, 35);
            this.BtnClearItem.TabIndex = 17;
            this.BtnClearItem.Text = "Clear";
            this.BtnClearItem.TextColor = System.Drawing.Color.White;
            this.BtnClearItem.UseVisualStyleBackColor = false;
            this.BtnClearItem.Click += new System.EventHandler(this.BtnClearItem_Click);
            // 
            // BtnSaveItem
            // 
            this.BtnSaveItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveItem.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveItem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSaveItem.BorderRadius = 35;
            this.BtnSaveItem.BorderSize = 0;
            this.BtnSaveItem.FlatAppearance.BorderSize = 0;
            this.BtnSaveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveItem.ForeColor = System.Drawing.Color.White;
            this.BtnSaveItem.Location = new System.Drawing.Point(12, 58);
            this.BtnSaveItem.Name = "BtnSaveItem";
            this.BtnSaveItem.Size = new System.Drawing.Size(120, 35);
            this.BtnSaveItem.TabIndex = 16;
            this.BtnSaveItem.Text = "Save";
            this.BtnSaveItem.TextColor = System.Drawing.Color.White;
            this.BtnSaveItem.UseVisualStyleBackColor = false;
            this.BtnSaveItem.Click += new System.EventHandler(this.BtnSaveItem_Click);
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddItem.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddItem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddItem.BorderRadius = 35;
            this.BtnAddItem.BorderSize = 0;
            this.BtnAddItem.FlatAppearance.BorderSize = 0;
            this.BtnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddItem.ForeColor = System.Drawing.Color.White;
            this.BtnAddItem.Location = new System.Drawing.Point(12, 21);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(120, 35);
            this.BtnAddItem.TabIndex = 15;
            this.BtnAddItem.Text = "Add to Cart";
            this.BtnAddItem.TextColor = System.Drawing.Color.White;
            this.BtnAddItem.UseVisualStyleBackColor = false;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // DataGridPurchaseList
            // 
            this.DataGridPurchaseList.BackgroundColor = System.Drawing.Color.White;
            this.DataGridPurchaseList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridPurchaseList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridPurchaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridPurchaseList.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridPurchaseList.Location = new System.Drawing.Point(10, 151);
            this.DataGridPurchaseList.Name = "DataGridPurchaseList";
            this.DataGridPurchaseList.Size = new System.Drawing.Size(912, 439);
            this.DataGridPurchaseList.TabIndex = 60;
            this.DataGridPurchaseList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridPurchaseList_DataBindingComplete);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnAddBill);
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(932, 149);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(145, 70);
            this.groupBox4.TabIndex = 62;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "New Bill";
            // 
            // BtnAddBill
            // 
            this.BtnAddBill.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddBill.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddBill.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddBill.BorderRadius = 35;
            this.BtnAddBill.BorderSize = 0;
            this.BtnAddBill.FlatAppearance.BorderSize = 0;
            this.BtnAddBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddBill.ForeColor = System.Drawing.Color.White;
            this.BtnAddBill.Location = new System.Drawing.Point(12, 21);
            this.BtnAddBill.Name = "BtnAddBill";
            this.BtnAddBill.Size = new System.Drawing.Size(120, 35);
            this.BtnAddBill.TabIndex = 14;
            this.BtnAddBill.Text = "Add Bill";
            this.BtnAddBill.TextColor = System.Drawing.Color.White;
            this.BtnAddBill.UseVisualStyleBackColor = false;
            this.BtnAddBill.Click += new System.EventHandler(this.BtnAddBill_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1107, 44);
            this.textBox1.TabIndex = 63;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.DodgerBlue;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Cyan;
            this.label9.Location = new System.Drawing.Point(403, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(312, 31);
            this.label9.TabIndex = 64;
            this.label9.Text = "Purchase Management";
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1088, 602);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.DataGridPurchaseList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(569, 240);
            this.Name = "PurchaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PurchaseForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPurchaseList)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox RichBillNo;
        private System.Windows.Forms.RichTextBox RichItemName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox RichPurchasePrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox RichQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtBillAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridPurchaseList;
        private System.Windows.Forms.RichTextBox RichItemCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox RichUnit;
        private System.Windows.Forms.GroupBox groupBox4;
        private CustomControls.Button.CustomButton BtnSearchItem;
        private CustomControls.Button.CustomButton BtnAddBill;
        private CustomControls.Button.CustomButton BtnAddItem;
        private CustomControls.Button.CustomButton BtnSaveItem;
        private CustomControls.Button.CustomButton BtnClearItem;
        private CustomControls.Button.CustomButton BtnRemoveItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox RichTotalAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox RichDiscount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox RichVat;
        private System.Windows.Forms.CheckBox ChkBoxVat;
    }
}