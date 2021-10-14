
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RichBillNo = new System.Windows.Forms.RichTextBox();
            this.RichItemName = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSearchItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.RichUnit = new System.Windows.Forms.RichTextBox();
            this.RichItemCode = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RichItemBrand = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtTotalAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RichPurchasePrice = new System.Windows.Forms.RichTextBox();
            this.RichQuantity = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnClear = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSaveItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.DataGridPurchaseList = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnAddBonus = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddNewBill = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ChkBoxBonus = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPurchaseList)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(310, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Item Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(933, 23);
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
            this.label6.Location = new System.Drawing.Point(225, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Quantity";
            // 
            // RichBillNo
            // 
            this.RichBillNo.BackColor = System.Drawing.Color.White;
            this.RichBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBillNo.Location = new System.Drawing.Point(87, 60);
            this.RichBillNo.Name = "RichBillNo";
            this.RichBillNo.ReadOnly = true;
            this.RichBillNo.Size = new System.Drawing.Size(124, 28);
            this.RichBillNo.TabIndex = 0;
            this.RichBillNo.Text = "";
            // 
            // RichItemName
            // 
            this.RichItemName.BackColor = System.Drawing.Color.White;
            this.RichItemName.Enabled = false;
            this.RichItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichItemName.Location = new System.Drawing.Point(396, 18);
            this.RichItemName.Name = "RichItemName";
            this.RichItemName.Size = new System.Drawing.Size(204, 28);
            this.RichItemName.TabIndex = 1;
            this.RichItemName.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkBoxBonus);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.BtnSearchItem);
            this.groupBox1.Controls.Add(this.RichUnit);
            this.groupBox1.Controls.Add(this.RichItemCode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.RichItemBrand);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtTotalAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RichBillNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.RichPurchasePrice);
            this.groupBox1.Controls.Add(this.RichQuantity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.RichItemName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(15, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1070, 95);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Purchase Details";
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
            this.BtnSearchItem.Location = new System.Drawing.Point(217, 18);
            this.BtnSearchItem.Name = "BtnSearchItem";
            this.BtnSearchItem.Size = new System.Drawing.Size(70, 28);
            this.BtnSearchItem.TabIndex = 64;
            this.BtnSearchItem.Text = "Search";
            this.BtnSearchItem.TextColor = System.Drawing.Color.White;
            this.BtnSearchItem.UseVisualStyleBackColor = false;
            this.BtnSearchItem.Click += new System.EventHandler(this.BtnSearchItem_Click);
            // 
            // RichUnit
            // 
            this.RichUnit.BackColor = System.Drawing.Color.White;
            this.RichUnit.Enabled = false;
            this.RichUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichUnit.Location = new System.Drawing.Point(973, 18);
            this.RichUnit.Name = "RichUnit";
            this.RichUnit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichUnit.Size = new System.Drawing.Size(83, 28);
            this.RichUnit.TabIndex = 63;
            this.RichUnit.Text = "";
            // 
            // RichItemCode
            // 
            this.RichItemCode.Enabled = false;
            this.RichItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichItemCode.Location = new System.Drawing.Point(103, 18);
            this.RichItemCode.Name = "RichItemCode";
            this.RichItemCode.Size = new System.Drawing.Size(108, 28);
            this.RichItemCode.TabIndex = 25;
            this.RichItemCode.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(12, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 18);
            this.label8.TabIndex = 24;
            this.label8.Text = "Item Code";
            // 
            // RichItemBrand
            // 
            this.RichItemBrand.AutoWordSelection = true;
            this.RichItemBrand.BackColor = System.Drawing.Color.White;
            this.RichItemBrand.Enabled = false;
            this.RichItemBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichItemBrand.Location = new System.Drawing.Point(706, 18);
            this.RichItemBrand.Name = "RichItemBrand";
            this.RichItemBrand.Size = new System.Drawing.Size(204, 28);
            this.RichItemBrand.TabIndex = 2;
            this.RichItemBrand.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(621, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Amount";
            // 
            // TxtTotalAmount
            // 
            this.TxtTotalAmount.BackColor = System.Drawing.Color.White;
            this.TxtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalAmount.Location = new System.Drawing.Point(706, 56);
            this.TxtTotalAmount.Name = "TxtTotalAmount";
            this.TxtTotalAmount.ReadOnly = true;
            this.TxtTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalAmount.Size = new System.Drawing.Size(204, 26);
            this.TxtTotalAmount.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(435, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Price ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(12, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Bill No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(621, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "Item Brand";
            // 
            // RichPurchasePrice
            // 
            this.RichPurchasePrice.BackColor = System.Drawing.Color.White;
            this.RichPurchasePrice.Enabled = false;
            this.RichPurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichPurchasePrice.Location = new System.Drawing.Point(487, 57);
            this.RichPurchasePrice.Name = "RichPurchasePrice";
            this.RichPurchasePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichPurchasePrice.Size = new System.Drawing.Size(113, 28);
            this.RichPurchasePrice.TabIndex = 5;
            this.RichPurchasePrice.Text = "";
            this.RichPurchasePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichPurchasePrice_KeyPress);
            // 
            // RichQuantity
            // 
            this.RichQuantity.BackColor = System.Drawing.Color.White;
            this.RichQuantity.Enabled = false;
            this.RichQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichQuantity.Location = new System.Drawing.Point(293, 58);
            this.RichQuantity.Name = "RichQuantity";
            this.RichQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichQuantity.Size = new System.Drawing.Size(129, 28);
            this.RichQuantity.TabIndex = 3;
            this.RichQuantity.Text = "";
            this.RichQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichQuantity_KeyDown);
            this.RichQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichQuantity_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnClear);
            this.groupBox2.Controls.Add(this.BtnSaveItem);
            this.groupBox2.Controls.Add(this.BtnAddItem);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(938, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 175);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transaction";
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
            this.BtnDelete.Location = new System.Drawing.Point(14, 129);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(120, 35);
            this.BtnDelete.TabIndex = 68;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.TextColor = System.Drawing.Color.White;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnClear.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnClear.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnClear.BorderRadius = 35;
            this.BtnClear.BorderSize = 0;
            this.BtnClear.FlatAppearance.BorderSize = 0;
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.ForeColor = System.Drawing.Color.White;
            this.BtnClear.Location = new System.Drawing.Point(14, 93);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(120, 35);
            this.BtnClear.TabIndex = 67;
            this.BtnClear.Text = "Clear";
            this.BtnClear.TextColor = System.Drawing.Color.White;
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
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
            this.BtnSaveItem.Location = new System.Drawing.Point(13, 57);
            this.BtnSaveItem.Name = "BtnSaveItem";
            this.BtnSaveItem.Size = new System.Drawing.Size(120, 35);
            this.BtnSaveItem.TabIndex = 66;
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
            this.BtnAddItem.Location = new System.Drawing.Point(13, 21);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(120, 35);
            this.BtnAddItem.TabIndex = 65;
            this.BtnAddItem.Text = "Add to Cart";
            this.BtnAddItem.TextColor = System.Drawing.Color.White;
            this.BtnAddItem.UseVisualStyleBackColor = false;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // DataGridPurchaseList
            // 
            this.DataGridPurchaseList.BackgroundColor = System.Drawing.Color.White;
            this.DataGridPurchaseList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridPurchaseList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridPurchaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridPurchaseList.DefaultCellStyle = dataGridViewCellStyle8;
            this.DataGridPurchaseList.Location = new System.Drawing.Point(15, 148);
            this.DataGridPurchaseList.Name = "DataGridPurchaseList";
            this.DataGridPurchaseList.Size = new System.Drawing.Size(910, 420);
            this.DataGridPurchaseList.TabIndex = 60;
            this.DataGridPurchaseList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridPurchaseList_DataBindingComplete);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnAddBonus);
            this.groupBox4.Controls.Add(this.BtnAddNewBill);
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(937, 150);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(150, 108);
            this.groupBox4.TabIndex = 62;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "New Bill";
            // 
            // BtnAddBonus
            // 
            this.BtnAddBonus.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddBonus.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddBonus.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddBonus.BorderRadius = 35;
            this.BtnAddBonus.BorderSize = 0;
            this.BtnAddBonus.FlatAppearance.BorderSize = 0;
            this.BtnAddBonus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddBonus.ForeColor = System.Drawing.Color.White;
            this.BtnAddBonus.Location = new System.Drawing.Point(14, 56);
            this.BtnAddBonus.Name = "BtnAddBonus";
            this.BtnAddBonus.Size = new System.Drawing.Size(120, 35);
            this.BtnAddBonus.TabIndex = 64;
            this.BtnAddBonus.Text = "Add Bonus";
            this.BtnAddBonus.TextColor = System.Drawing.Color.White;
            this.BtnAddBonus.UseVisualStyleBackColor = false;
            this.BtnAddBonus.Click += new System.EventHandler(this.BtnAddBonus_Click);
            // 
            // BtnAddNewBill
            // 
            this.BtnAddNewBill.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddNewBill.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddNewBill.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddNewBill.BorderRadius = 35;
            this.BtnAddNewBill.BorderSize = 0;
            this.BtnAddNewBill.FlatAppearance.BorderSize = 0;
            this.BtnAddNewBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddNewBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddNewBill.ForeColor = System.Drawing.Color.White;
            this.BtnAddNewBill.Location = new System.Drawing.Point(14, 20);
            this.BtnAddNewBill.Name = "BtnAddNewBill";
            this.BtnAddNewBill.Size = new System.Drawing.Size(120, 35);
            this.BtnAddNewBill.TabIndex = 63;
            this.BtnAddNewBill.Text = "Add New Bill";
            this.BtnAddNewBill.TextColor = System.Drawing.Color.White;
            this.BtnAddNewBill.UseVisualStyleBackColor = false;
            this.BtnAddNewBill.Click += new System.EventHandler(this.BtnAddNewBill_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1103, 44);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(916, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 18);
            this.label10.TabIndex = 65;
            this.label10.Text = "Bonus";
            // 
            // ChkBoxBonus
            // 
            this.ChkBoxBonus.AutoSize = true;
            this.ChkBoxBonus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ChkBoxBonus.CausesValidation = false;
            this.ChkBoxBonus.ForeColor = System.Drawing.Color.OrangeRed;
            this.ChkBoxBonus.Location = new System.Drawing.Point(973, 64);
            this.ChkBoxBonus.Name = "ChkBoxBonus";
            this.ChkBoxBonus.Size = new System.Drawing.Size(15, 14);
            this.ChkBoxBonus.TabIndex = 66;
            this.ChkBoxBonus.UseVisualStyleBackColor = true;
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1094, 581);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox RichPurchasePrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox RichQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridPurchaseList;
        private System.Windows.Forms.RichTextBox RichItemBrand;
        private System.Windows.Forms.RichTextBox RichItemCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox RichUnit;
        private System.Windows.Forms.GroupBox groupBox4;
        private CustomControls.Button.CustomButton BtnSearchItem;
        private CustomControls.Button.CustomButton BtnAddNewBill;
        private CustomControls.Button.CustomButton BtnAddBonus;
        private CustomControls.Button.CustomButton BtnAddItem;
        private CustomControls.Button.CustomButton BtnSaveItem;
        private CustomControls.Button.CustomButton BtnClear;
        private CustomControls.Button.CustomButton BtnDelete;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ChkBoxBonus;
        private System.Windows.Forms.Label label10;
    }
}