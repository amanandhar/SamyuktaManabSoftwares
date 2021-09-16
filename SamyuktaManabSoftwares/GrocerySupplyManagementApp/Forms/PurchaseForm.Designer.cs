
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseForm));
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
            this.DataGridPurchaseList = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnAddNewBill = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddBonus = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSaveItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnClear = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnDelete = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPurchaseList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(7, 23);
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
            this.label3.Location = new System.Drawing.Point(244, 58);
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
            this.label6.Location = new System.Drawing.Point(549, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Quantity";
            // 
            // RichBillNo
            // 
            this.RichBillNo.BackColor = System.Drawing.Color.White;
            this.RichBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBillNo.Location = new System.Drawing.Point(413, 18);
            this.RichBillNo.Name = "RichBillNo";
            this.RichBillNo.ReadOnly = true;
            this.RichBillNo.Size = new System.Drawing.Size(125, 28);
            this.RichBillNo.TabIndex = 0;
            this.RichBillNo.Text = "";
            // 
            // RichItemName
            // 
            this.RichItemName.BackColor = System.Drawing.Color.White;
            this.RichItemName.Enabled = false;
            this.RichItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichItemName.Location = new System.Drawing.Point(90, 19);
            this.RichItemName.Name = "RichItemName";
            this.RichItemName.Size = new System.Drawing.Size(250, 28);
            this.RichItemName.TabIndex = 1;
            this.RichItemName.Text = "";
            // 
            // groupBox1
            // 
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(15, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(854, 98);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // BtnSearchItem
            // 
            this.BtnSearchItem.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnSearchItem.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnSearchItem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSearchItem.BorderRadius = 26;
            this.BtnSearchItem.BorderSize = 0;
            this.BtnSearchItem.FlatAppearance.BorderSize = 0;
            this.BtnSearchItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchItem.ForeColor = System.Drawing.Color.White;
            this.BtnSearchItem.Location = new System.Drawing.Point(765, 17);
            this.BtnSearchItem.Name = "BtnSearchItem";
            this.BtnSearchItem.Size = new System.Drawing.Size(79, 29);
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
            this.RichUnit.Location = new System.Drawing.Point(280, 53);
            this.RichUnit.Name = "RichUnit";
            this.RichUnit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichUnit.Size = new System.Drawing.Size(60, 28);
            this.RichUnit.TabIndex = 63;
            this.RichUnit.Text = "";
            // 
            // RichItemCode
            // 
            this.RichItemCode.Enabled = false;
            this.RichItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichItemCode.Location = new System.Drawing.Point(638, 19);
            this.RichItemCode.Name = "RichItemCode";
            this.RichItemCode.Size = new System.Drawing.Size(125, 28);
            this.RichItemCode.TabIndex = 25;
            this.RichItemCode.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(549, 23);
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
            this.RichItemBrand.Location = new System.Drawing.Point(91, 53);
            this.RichItemBrand.Name = "RichItemBrand";
            this.RichItemBrand.Size = new System.Drawing.Size(150, 28);
            this.RichItemBrand.TabIndex = 2;
            this.RichItemBrand.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(345, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Amount";
            // 
            // TxtTotalAmount
            // 
            this.TxtTotalAmount.BackColor = System.Drawing.Color.White;
            this.TxtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalAmount.Location = new System.Drawing.Point(413, 54);
            this.TxtTotalAmount.Name = "TxtTotalAmount";
            this.TxtTotalAmount.ReadOnly = true;
            this.TxtTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalAmount.Size = new System.Drawing.Size(125, 26);
            this.TxtTotalAmount.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(695, 58);
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
            this.label4.Location = new System.Drawing.Point(346, 23);
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
            this.label5.Location = new System.Drawing.Point(8, 58);
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
            this.RichPurchasePrice.Location = new System.Drawing.Point(744, 53);
            this.RichPurchasePrice.Name = "RichPurchasePrice";
            this.RichPurchasePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichPurchasePrice.Size = new System.Drawing.Size(90, 28);
            this.RichPurchasePrice.TabIndex = 5;
            this.RichPurchasePrice.Text = "";
            // 
            // RichQuantity
            // 
            this.RichQuantity.BackColor = System.Drawing.Color.White;
            this.RichQuantity.Enabled = false;
            this.RichQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichQuantity.Location = new System.Drawing.Point(615, 54);
            this.RichQuantity.Name = "RichQuantity";
            this.RichQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichQuantity.Size = new System.Drawing.Size(75, 28);
            this.RichQuantity.TabIndex = 3;
            this.RichQuantity.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnClear);
            this.groupBox2.Controls.Add(this.BtnSaveItem);
            this.groupBox2.Controls.Add(this.BtnAddItem);
            this.groupBox2.Location = new System.Drawing.Point(883, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 190);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            // 
            // DataGridPurchaseList
            // 
            this.DataGridPurchaseList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
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
            this.DataGridPurchaseList.Location = new System.Drawing.Point(15, 146);
            this.DataGridPurchaseList.Name = "DataGridPurchaseList";
            this.DataGridPurchaseList.Size = new System.Drawing.Size(855, 389);
            this.DataGridPurchaseList.TabIndex = 60;
            this.DataGridPurchaseList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridPurchaseList_DataBindingComplete);
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.BackgroundImage")));
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(1, -2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1041, 45);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Cyan;
            this.label9.Location = new System.Drawing.Point(374, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(312, 31);
            this.label9.TabIndex = 0;
            this.label9.Text = "Purchase Management";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnAddBonus);
            this.groupBox4.Controls.Add(this.BtnAddNewBill);
            this.groupBox4.Location = new System.Drawing.Point(883, 44);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 98);
            this.groupBox4.TabIndex = 62;
            this.groupBox4.TabStop = false;
            // 
            // BtnAddNewBill
            // 
            this.BtnAddNewBill.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnAddNewBill.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnAddNewBill.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddNewBill.BorderRadius = 40;
            this.BtnAddNewBill.BorderSize = 0;
            this.BtnAddNewBill.FlatAppearance.BorderSize = 0;
            this.BtnAddNewBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddNewBill.ForeColor = System.Drawing.Color.White;
            this.BtnAddNewBill.Location = new System.Drawing.Point(10, 12);
            this.BtnAddNewBill.Name = "BtnAddNewBill";
            this.BtnAddNewBill.Size = new System.Drawing.Size(134, 40);
            this.BtnAddNewBill.TabIndex = 63;
            this.BtnAddNewBill.Text = "Add New Bill";
            this.BtnAddNewBill.TextColor = System.Drawing.Color.White;
            this.BtnAddNewBill.UseVisualStyleBackColor = false;
            this.BtnAddNewBill.Click += new System.EventHandler(this.BtnAddNewBill_Click);
            // 
            // BtnAddBonus
            // 
            this.BtnAddBonus.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnAddBonus.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnAddBonus.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddBonus.BorderRadius = 40;
            this.BtnAddBonus.BorderSize = 0;
            this.BtnAddBonus.FlatAppearance.BorderSize = 0;
            this.BtnAddBonus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddBonus.ForeColor = System.Drawing.Color.White;
            this.BtnAddBonus.Location = new System.Drawing.Point(10, 53);
            this.BtnAddBonus.Name = "BtnAddBonus";
            this.BtnAddBonus.Size = new System.Drawing.Size(134, 40);
            this.BtnAddBonus.TabIndex = 64;
            this.BtnAddBonus.Text = "Add Bonus";
            this.BtnAddBonus.TextColor = System.Drawing.Color.White;
            this.BtnAddBonus.UseVisualStyleBackColor = false;
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnAddItem.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnAddItem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddItem.BorderRadius = 40;
            this.BtnAddItem.BorderSize = 0;
            this.BtnAddItem.FlatAppearance.BorderSize = 0;
            this.BtnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddItem.ForeColor = System.Drawing.Color.White;
            this.BtnAddItem.Location = new System.Drawing.Point(10, 9);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(134, 40);
            this.BtnAddItem.TabIndex = 65;
            this.BtnAddItem.Text = "Add Item";
            this.BtnAddItem.TextColor = System.Drawing.Color.White;
            this.BtnAddItem.UseVisualStyleBackColor = false;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // BtnSaveItem
            // 
            this.BtnSaveItem.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnSaveItem.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnSaveItem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSaveItem.BorderRadius = 40;
            this.BtnSaveItem.BorderSize = 0;
            this.BtnSaveItem.FlatAppearance.BorderSize = 0;
            this.BtnSaveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveItem.ForeColor = System.Drawing.Color.White;
            this.BtnSaveItem.Location = new System.Drawing.Point(6, 55);
            this.BtnSaveItem.Name = "BtnSaveItem";
            this.BtnSaveItem.Size = new System.Drawing.Size(134, 40);
            this.BtnSaveItem.TabIndex = 66;
            this.BtnSaveItem.Text = "Save Item";
            this.BtnSaveItem.TextColor = System.Drawing.Color.White;
            this.BtnSaveItem.UseVisualStyleBackColor = false;
            this.BtnSaveItem.Click += new System.EventHandler(this.BtnSaveItem_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnClear.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnClear.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnClear.BorderRadius = 40;
            this.BtnClear.BorderSize = 0;
            this.BtnClear.FlatAppearance.BorderSize = 0;
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClear.ForeColor = System.Drawing.Color.White;
            this.BtnClear.Location = new System.Drawing.Point(6, 101);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(134, 40);
            this.BtnClear.TabIndex = 67;
            this.BtnClear.Text = "Clear";
            this.BtnClear.TextColor = System.Drawing.Color.White;
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnDelete.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnDelete.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnDelete.BorderRadius = 40;
            this.BtnDelete.BorderSize = 0;
            this.BtnDelete.FlatAppearance.BorderSize = 0;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(10, 147);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(134, 40);
            this.BtnDelete.TabIndex = 68;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.TextColor = System.Drawing.Color.White;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1045, 551);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.DataGridPurchaseList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(569, 240);
            this.Name = "PurchaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.PurchaseForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPurchaseList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private CustomControls.Button.CustomButton BtnSearchItem;
        private CustomControls.Button.CustomButton BtnAddNewBill;
        private CustomControls.Button.CustomButton BtnAddBonus;
        private CustomControls.Button.CustomButton BtnAddItem;
        private CustomControls.Button.CustomButton BtnSaveItem;
        private CustomControls.Button.CustomButton BtnClear;
        private CustomControls.Button.CustomButton BtnDelete;
    }
}