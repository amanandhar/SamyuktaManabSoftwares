
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RichBillNo = new System.Windows.Forms.RichTextBox();
            this.RichItemName = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnShowItem = new System.Windows.Forms.Button();
            this.BtnAddNew = new System.Windows.Forms.Button();
            this.RichItemCode = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RichItemBrand = new System.Windows.Forms.RichTextBox();
            this.TxtTotalAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RichPurchasePrice = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RichQuantity = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnAddItem = new System.Windows.Forms.Button();
            this.DataGridPurchaseList = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPurchaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Item Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(349, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Unit";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox7.Location = new System.Drawing.Point(-1, -1);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(1045, 26);
            this.textBox7.TabIndex = 53;
            this.textBox7.Text = "                                                                                 " +
    "       Purchase \r\nDetails";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(319, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Quantity";
            // 
            // RichBillNo
            // 
            this.RichBillNo.BackColor = System.Drawing.Color.White;
            this.RichBillNo.Enabled = false;
            this.RichBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichBillNo.Location = new System.Drawing.Point(104, 16);
            this.RichBillNo.Name = "RichBillNo";
            this.RichBillNo.Size = new System.Drawing.Size(185, 30);
            this.RichBillNo.TabIndex = 0;
            this.RichBillNo.Text = "";
            // 
            // RichItemName
            // 
            this.RichItemName.BackColor = System.Drawing.Color.White;
            this.RichItemName.Enabled = false;
            this.RichItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichItemName.Location = new System.Drawing.Point(104, 47);
            this.RichItemName.Name = "RichItemName";
            this.RichItemName.Size = new System.Drawing.Size(185, 30);
            this.RichItemName.TabIndex = 1;
            this.RichItemName.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.BtnShowItem);
            this.groupBox1.Controls.Add(this.BtnAddNew);
            this.groupBox1.Controls.Add(this.RichItemCode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.RichItemBrand);
            this.groupBox1.Controls.Add(this.TxtTotalAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ComboUnit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.RichPurchasePrice);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.RichQuantity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.RichBillNo);
            this.groupBox1.Controls.Add(this.RichItemName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(15, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 120);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // BtnShowItem
            // 
            this.BtnShowItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowItem.Location = new System.Drawing.Point(480, 15);
            this.BtnShowItem.Name = "BtnShowItem";
            this.BtnShowItem.Size = new System.Drawing.Size(40, 30);
            this.BtnShowItem.TabIndex = 61;
            this.BtnShowItem.Text = "C";
            this.BtnShowItem.UseVisualStyleBackColor = true;
            this.BtnShowItem.Click += new System.EventHandler(this.BtnShowItem_Click);
            // 
            // BtnAddNew
            // 
            this.BtnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnAddNew.Location = new System.Drawing.Point(562, 14);
            this.BtnAddNew.Name = "BtnAddNew";
            this.BtnAddNew.Size = new System.Drawing.Size(105, 35);
            this.BtnAddNew.TabIndex = 60;
            this.BtnAddNew.Text = "Add Bill";
            this.BtnAddNew.UseVisualStyleBackColor = true;
            this.BtnAddNew.Click += new System.EventHandler(this.BtnAddNew_Click);
            // 
            // RichItemCode
            // 
            this.RichItemCode.Enabled = false;
            this.RichItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichItemCode.Location = new System.Drawing.Point(390, 16);
            this.RichItemCode.Name = "RichItemCode";
            this.RichItemCode.Size = new System.Drawing.Size(90, 30);
            this.RichItemCode.TabIndex = 25;
            this.RichItemCode.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(304, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Item Code";
            // 
            // RichItemBrand
            // 
            this.RichItemBrand.AutoWordSelection = true;
            this.RichItemBrand.BackColor = System.Drawing.Color.White;
            this.RichItemBrand.Enabled = false;
            this.RichItemBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichItemBrand.Location = new System.Drawing.Point(104, 79);
            this.RichItemBrand.Name = "RichItemBrand";
            this.RichItemBrand.Size = new System.Drawing.Size(185, 30);
            this.RichItemBrand.TabIndex = 2;
            this.RichItemBrand.Text = "";
            // 
            // TxtTotalAmount
            // 
            this.TxtTotalAmount.Enabled = false;
            this.TxtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalAmount.Location = new System.Drawing.Point(669, 83);
            this.TxtTotalAmount.Name = "TxtTotalAmount";
            this.TxtTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalAmount.Size = new System.Drawing.Size(105, 27);
            this.TxtTotalAmount.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(575, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Price / Rate";
            // 
            // ComboUnit
            // 
            this.ComboUnit.Enabled = false;
            this.ComboUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboUnit.FormattingEnabled = true;
            this.ComboUnit.Items.AddRange(new object[] {
            "kg",
            "gram",
            "ltr",
            "pcs",
            "pkt",
            "dzn"});
            this.ComboUnit.Location = new System.Drawing.Point(390, 48);
            this.ComboUnit.Name = "ComboUnit";
            this.ComboUnit.Size = new System.Drawing.Size(90, 28);
            this.ComboUnit.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(15, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Item Brand";
            // 
            // RichPurchasePrice
            // 
            this.RichPurchasePrice.BackColor = System.Drawing.Color.White;
            this.RichPurchasePrice.Enabled = false;
            this.RichPurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichPurchasePrice.Location = new System.Drawing.Point(669, 51);
            this.RichPurchasePrice.Name = "RichPurchasePrice";
            this.RichPurchasePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichPurchasePrice.Size = new System.Drawing.Size(105, 30);
            this.RichPurchasePrice.TabIndex = 5;
            this.RichPurchasePrice.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(550, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Total Amount";
            // 
            // RichQuantity
            // 
            this.RichQuantity.BackColor = System.Drawing.Color.White;
            this.RichQuantity.Enabled = false;
            this.RichQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichQuantity.Location = new System.Drawing.Point(390, 78);
            this.RichQuantity.Name = "RichQuantity";
            this.RichQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichQuantity.Size = new System.Drawing.Size(90, 30);
            this.RichQuantity.TabIndex = 3;
            this.RichQuantity.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(16, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Bill No.";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.Red;
            this.BtnDelete.Location = new System.Drawing.Point(104, 64);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(95, 50);
            this.BtnDelete.TabIndex = 56;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSave.Location = new System.Drawing.Point(7, 64);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(95, 50);
            this.BtnSave.TabIndex = 57;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnClear.Location = new System.Drawing.Point(104, 12);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(95, 50);
            this.BtnClear.TabIndex = 58;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnAddItem);
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnClear);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(817, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 120);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddItem.ForeColor = System.Drawing.Color.Red;
            this.BtnAddItem.Location = new System.Drawing.Point(7, 12);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(95, 50);
            this.BtnAddItem.TabIndex = 59;
            this.BtnAddItem.Text = "Add Item";
            this.BtnAddItem.UseVisualStyleBackColor = true;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // DataGridPurchaseList
            // 
            this.DataGridPurchaseList.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridPurchaseList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridPurchaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridPurchaseList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridPurchaseList.Location = new System.Drawing.Point(16, 166);
            this.DataGridPurchaseList.Name = "DataGridPurchaseList";
            this.DataGridPurchaseList.Size = new System.Drawing.Size(1007, 360);
            this.DataGridPurchaseList.TabIndex = 60;
            this.DataGridPurchaseList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridPurchaseList_DataBindingComplete);
            this.DataGridPurchaseList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DataGridPurchaseList_RowPostPaint);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(669, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 35);
            this.button1.TabIndex = 62;
            this.button1.Text = "Add Bonus";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.DataGridPurchaseList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.groupBox1);
            this.Name = "PurchaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PurchaseForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPurchaseList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox RichBillNo;
        private System.Windows.Forms.RichTextBox RichItemName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox RichPurchasePrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox RichQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ComboUnit;
        private System.Windows.Forms.Button BtnAddItem;
        private System.Windows.Forms.TextBox TxtTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridPurchaseList;
        private System.Windows.Forms.RichTextBox RichItemBrand;
        private System.Windows.Forms.Button BtnAddNew;
        private System.Windows.Forms.RichTextBox RichItemCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnShowItem;
        private System.Windows.Forms.Button button1;
    }
}