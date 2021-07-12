
namespace GrocerySupplyManagementApp.Forms
{
    partial class ExpenseForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MaskDateTo = new System.Windows.Forms.MaskedTextBox();
            this.MaskDateFrom = new System.Windows.Forms.MaskedTextBox();
            this.TxtTotalAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RadioAll = new System.Windows.Forms.RadioButton();
            this.ComboFilteredBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnShow = new System.Windows.Forms.Button();
            this.ComboBank = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboPayment = new System.Windows.Forms.ComboBox();
            this.RichAmount = new System.Windows.Forms.RichTextBox();
            this.ComboExpense = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnSaveExpense = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DataGridExpenseList = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridExpenseList)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1045, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "                                                                                \r" +
    "\n   \r\n Daily Expense Details";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MaskDateTo);
            this.groupBox1.Controls.Add(this.MaskDateFrom);
            this.groupBox1.Controls.Add(this.TxtTotalAmount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.RadioAll);
            this.groupBox1.Controls.Add(this.ComboFilteredBy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // MaskDateTo
            // 
            this.MaskDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDateTo.Location = new System.Drawing.Point(347, 15);
            this.MaskDateTo.Mask = "   0000-00-00";
            this.MaskDateTo.Name = "MaskDateTo";
            this.MaskDateTo.Size = new System.Drawing.Size(105, 24);
            this.MaskDateTo.TabIndex = 27;
            // 
            // MaskDateFrom
            // 
            this.MaskDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDateFrom.Location = new System.Drawing.Point(167, 16);
            this.MaskDateFrom.Mask = "   0000-00-00";
            this.MaskDateFrom.Name = "MaskDateFrom";
            this.MaskDateFrom.Size = new System.Drawing.Size(105, 24);
            this.MaskDateFrom.TabIndex = 26;
            // 
            // TxtTotalAmount
            // 
            this.TxtTotalAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtTotalAmount.Enabled = false;
            this.TxtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalAmount.Location = new System.Drawing.Point(167, 86);
            this.TxtTotalAmount.Name = "TxtTotalAmount";
            this.TxtTotalAmount.Size = new System.Drawing.Size(285, 29);
            this.TxtTotalAmount.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(63, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Total Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(296, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = " To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(65, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date From";
            // 
            // RadioAll
            // 
            this.RadioAll.AutoSize = true;
            this.RadioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioAll.Location = new System.Drawing.Point(15, 17);
            this.RadioAll.Name = "RadioAll";
            this.RadioAll.Size = new System.Drawing.Size(47, 24);
            this.RadioAll.TabIndex = 19;
            this.RadioAll.TabStop = true;
            this.RadioAll.Text = "All";
            this.RadioAll.UseVisualStyleBackColor = true;
            this.RadioAll.CheckedChanged += new System.EventHandler(this.RadioAll_CheckedChanged);
            // 
            // ComboFilteredBy
            // 
            this.ComboFilteredBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboFilteredBy.FormattingEnabled = true;
            this.ComboFilteredBy.Items.AddRange(new object[] {
            "Asset (Computer, Furniture etc.)",
            "Delivery Charge",
            "Electricity",
            "Fuel & Transportation",
            "Guest & Hospitality",
            "Loan Fee & Interest",
            "Miscellaneous",
            "Office Rent ",
            "Repair & Maintenance",
            "Sales Discount",
            "Staff  Allowance",
            "Staff Salary ",
            "Telephone & Internet"});
            this.ComboFilteredBy.Location = new System.Drawing.Point(167, 50);
            this.ComboFilteredBy.Name = "ComboFilteredBy";
            this.ComboFilteredBy.Size = new System.Drawing.Size(285, 28);
            this.ComboFilteredBy.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(64, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filtered by ";
            // 
            // BtnRemove
            // 
            this.BtnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemove.ForeColor = System.Drawing.Color.Red;
            this.BtnRemove.Location = new System.Drawing.Point(9, 87);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(125, 35);
            this.BtnRemove.TabIndex = 15;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnShow
            // 
            this.BtnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShow.Location = new System.Drawing.Point(8, 11);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(125, 35);
            this.BtnShow.TabIndex = 16;
            this.BtnShow.Text = "Show";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // ComboBank
            // 
            this.ComboBank.Enabled = false;
            this.ComboBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBank.FormattingEnabled = true;
            this.ComboBank.Location = new System.Drawing.Point(82, 87);
            this.ComboBank.Name = "ComboBank";
            this.ComboBank.Size = new System.Drawing.Size(275, 28);
            this.ComboBank.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(6, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Bank";
            // 
            // ComboPayment
            // 
            this.ComboPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPayment.FormattingEnabled = true;
            this.ComboPayment.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboPayment.Location = new System.Drawing.Point(82, 51);
            this.ComboPayment.Name = "ComboPayment";
            this.ComboPayment.Size = new System.Drawing.Size(90, 28);
            this.ComboPayment.TabIndex = 21;
            this.ComboPayment.SelectedValueChanged += new System.EventHandler(this.ComboPayment_SelectedValueChanged);
            // 
            // RichAmount
            // 
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(255, 51);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(102, 30);
            this.RichAmount.TabIndex = 17;
            this.RichAmount.Text = "";
            // 
            // ComboExpense
            // 
            this.ComboExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboExpense.FormattingEnabled = true;
            this.ComboExpense.Items.AddRange(new object[] {
            "Asset (Computer, Furniture etc.)",
            "Delivery Charge",
            "Electricity",
            "Fuel & Transportation",
            "Guest & Hospitality",
            "Loan Fee & Interest",
            "Miscellaneous",
            "Office Rent ",
            "Repair & Maintenance",
            "Sales Discount",
            "Staff  Allowance",
            "Staff Salary ",
            "Telephone & Internet"});
            this.ComboExpense.Location = new System.Drawing.Point(82, 15);
            this.ComboExpense.Name = "ComboExpense";
            this.ComboExpense.Size = new System.Drawing.Size(275, 28);
            this.ComboExpense.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(4, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = " Expense";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(176, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = " Amount";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.ComboExpense);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.RichAmount);
            this.groupBox3.Controls.Add(this.ComboBank);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.ComboPayment);
            this.groupBox3.Location = new System.Drawing.Point(500, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(372, 125);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(7, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Payment";
            // 
            // BtnSaveExpense
            // 
            this.BtnSaveExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveExpense.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSaveExpense.Location = new System.Drawing.Point(8, 48);
            this.BtnSaveExpense.Name = "BtnSaveExpense";
            this.BtnSaveExpense.Size = new System.Drawing.Size(125, 35);
            this.BtnSaveExpense.TabIndex = 25;
            this.BtnSaveExpense.Text = "Save Expense";
            this.BtnSaveExpense.UseVisualStyleBackColor = true;
            this.BtnSaveExpense.Click += new System.EventHandler(this.BtnSaveExpense_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnRemove);
            this.groupBox4.Controls.Add(this.BtnShow);
            this.groupBox4.Controls.Add(this.BtnSaveExpense);
            this.groupBox4.Location = new System.Drawing.Point(882, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 125);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            // 
            // DataGridExpenseList
            // 
            this.DataGridExpenseList.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridExpenseList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridExpenseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridExpenseList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridExpenseList.Location = new System.Drawing.Point(18, 165);
            this.DataGridExpenseList.Name = "DataGridExpenseList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridExpenseList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridExpenseList.Size = new System.Drawing.Size(1004, 369);
            this.DataGridExpenseList.TabIndex = 27;
            this.DataGridExpenseList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridExpenseList_DataBindingComplete);
            // 
            // ExpenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.DataGridExpenseList);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox1);
            this.Name = "ExpenseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ExpenseForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridExpenseList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboFilteredBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox RichAmount;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.ComboBox ComboExpense;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton RadioAll;
        private System.Windows.Forms.ComboBox ComboPayment;
        private System.Windows.Forms.ComboBox ComboBank;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtTotalAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnSaveExpense;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DataGridExpenseList;
        private System.Windows.Forms.MaskedTextBox MaskDateTo;
        private System.Windows.Forms.MaskedTextBox MaskDateFrom;
    }
}