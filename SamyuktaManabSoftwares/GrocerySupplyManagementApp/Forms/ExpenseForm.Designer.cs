
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MaskDtEODTo = new System.Windows.Forms.MaskedTextBox();
            this.MaskDtEODFrom = new System.Windows.Forms.MaskedTextBox();
            this.TxtTotalAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RadioAll = new System.Windows.Forms.RadioButton();
            this.ComboFilteredBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBank = new System.Windows.Forms.ComboBox();
            this.ComboPayment = new System.Windows.Forms.ComboBox();
            this.RichAmount = new System.Windows.Forms.RichTextBox();
            this.ComboExpense = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtNarration = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnRemove = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSaveExpense = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnShow = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.DataGridExpenseList = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridExpenseList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MaskDtEODTo);
            this.groupBox1.Controls.Add(this.MaskDtEODFrom);
            this.groupBox1.Controls.Add(this.TxtTotalAmount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.RadioAll);
            this.groupBox1.Controls.Add(this.ComboFilteredBy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(18, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtered Expense";
            // 
            // MaskDtEODTo
            // 
            this.MaskDtEODTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDtEODTo.Location = new System.Drawing.Point(347, 20);
            this.MaskDtEODTo.Mask = "   0000-00-00";
            this.MaskDtEODTo.Name = "MaskDtEODTo";
            this.MaskDtEODTo.Size = new System.Drawing.Size(105, 24);
            this.MaskDtEODTo.TabIndex = 2;
            this.MaskDtEODTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskDtEODTo_KeyDown);
            // 
            // MaskDtEODFrom
            // 
            this.MaskDtEODFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDtEODFrom.Location = new System.Drawing.Point(167, 20);
            this.MaskDtEODFrom.Mask = "   0000-00-00";
            this.MaskDtEODFrom.Name = "MaskDtEODFrom";
            this.MaskDtEODFrom.Size = new System.Drawing.Size(105, 24);
            this.MaskDtEODFrom.TabIndex = 1;
            this.MaskDtEODFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskDtEODFrom_KeyDown);
            // 
            // TxtTotalAmount
            // 
            this.TxtTotalAmount.BackColor = System.Drawing.Color.White;
            this.TxtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalAmount.Location = new System.Drawing.Point(167, 81);
            this.TxtTotalAmount.Name = "TxtTotalAmount";
            this.TxtTotalAmount.ReadOnly = true;
            this.TxtTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalAmount.Size = new System.Drawing.Size(285, 26);
            this.TxtTotalAmount.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(60, 84);
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
            this.label9.Location = new System.Drawing.Point(275, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = " Date To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(64, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date From";
            // 
            // RadioAll
            // 
            this.RadioAll.AutoSize = true;
            this.RadioAll.Checked = true;
            this.RadioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioAll.Location = new System.Drawing.Point(15, 23);
            this.RadioAll.Name = "RadioAll";
            this.RadioAll.Size = new System.Drawing.Size(47, 24);
            this.RadioAll.TabIndex = 0;
            this.RadioAll.TabStop = true;
            this.RadioAll.Text = "All";
            this.RadioAll.UseVisualStyleBackColor = true;
            this.RadioAll.CheckedChanged += new System.EventHandler(this.RadioAll_CheckedChanged);
            // 
            // ComboFilteredBy
            // 
            this.ComboFilteredBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboFilteredBy.FormattingEnabled = true;
            this.ComboFilteredBy.Location = new System.Drawing.Point(167, 50);
            this.ComboFilteredBy.Name = "ComboFilteredBy";
            this.ComboFilteredBy.Size = new System.Drawing.Size(285, 26);
            this.ComboFilteredBy.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(63, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filtered by ";
            // 
            // ComboBank
            // 
            this.ComboBank.Enabled = false;
            this.ComboBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBank.FormattingEnabled = true;
            this.ComboBank.Location = new System.Drawing.Point(200, 51);
            this.ComboBank.Name = "ComboBank";
            this.ComboBank.Size = new System.Drawing.Size(215, 28);
            this.ComboBank.TabIndex = 8;
            this.ComboBank.SelectedValueChanged += new System.EventHandler(this.ComboBank_SelectedValueChanged);
            this.ComboBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboBank_KeyPress);
            // 
            // ComboPayment
            // 
            this.ComboPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPayment.FormattingEnabled = true;
            this.ComboPayment.Location = new System.Drawing.Point(90, 51);
            this.ComboPayment.Name = "ComboPayment";
            this.ComboPayment.Size = new System.Drawing.Size(107, 28);
            this.ComboPayment.TabIndex = 7;
            this.ComboPayment.SelectedValueChanged += new System.EventHandler(this.ComboPayment_SelectedValueChanged);
            this.ComboPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboPayment_KeyPress);
            // 
            // RichAmount
            // 
            this.RichAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(300, 19);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(115, 29);
            this.RichAmount.TabIndex = 6;
            this.RichAmount.Text = "";
            this.RichAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichAmount_KeyPress);
            // 
            // ComboExpense
            // 
            this.ComboExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboExpense.FormattingEnabled = true;
            this.ComboExpense.Location = new System.Drawing.Point(90, 20);
            this.ComboExpense.Name = "ComboExpense";
            this.ComboExpense.Size = new System.Drawing.Size(208, 26);
            this.ComboExpense.TabIndex = 5;
            this.ComboExpense.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboExpense_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(10, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = " Expense";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtNarration);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.ComboExpense);
            this.groupBox3.Controls.Add(this.RichAmount);
            this.groupBox3.Controls.Add(this.ComboBank);
            this.groupBox3.Controls.Add(this.ComboPayment);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(498, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 125);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Expense Box";
            // 
            // TxtNarration
            // 
            this.TxtNarration.BackColor = System.Drawing.Color.White;
            this.TxtNarration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNarration.Location = new System.Drawing.Point(90, 84);
            this.TxtNarration.Name = "TxtNarration";
            this.TxtNarration.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtNarration.Size = new System.Drawing.Size(325, 26);
            this.TxtNarration.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(14, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Narration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(13, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Payment";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnRemove);
            this.groupBox4.Controls.Add(this.BtnSaveExpense);
            this.groupBox4.Controls.Add(this.BtnShow);
            this.groupBox4.Location = new System.Drawing.Point(938, 46);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(150, 125);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            // 
            // BtnRemove
            // 
            this.BtnRemove.BackColor = System.Drawing.Color.Red;
            this.BtnRemove.BackgroundColor = System.Drawing.Color.Red;
            this.BtnRemove.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnRemove.BorderRadius = 35;
            this.BtnRemove.BorderSize = 0;
            this.BtnRemove.FlatAppearance.BorderSize = 0;
            this.BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemove.ForeColor = System.Drawing.Color.White;
            this.BtnRemove.Location = new System.Drawing.Point(14, 82);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(120, 35);
            this.BtnRemove.TabIndex = 12;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.TextColor = System.Drawing.Color.White;
            this.BtnRemove.UseVisualStyleBackColor = false;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnSaveExpense
            // 
            this.BtnSaveExpense.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveExpense.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveExpense.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSaveExpense.BorderRadius = 35;
            this.BtnSaveExpense.BorderSize = 0;
            this.BtnSaveExpense.FlatAppearance.BorderSize = 0;
            this.BtnSaveExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveExpense.ForeColor = System.Drawing.Color.White;
            this.BtnSaveExpense.Location = new System.Drawing.Point(14, 46);
            this.BtnSaveExpense.Name = "BtnSaveExpense";
            this.BtnSaveExpense.Size = new System.Drawing.Size(120, 35);
            this.BtnSaveExpense.TabIndex = 11;
            this.BtnSaveExpense.Text = "Save ";
            this.BtnSaveExpense.TextColor = System.Drawing.Color.White;
            this.BtnSaveExpense.UseVisualStyleBackColor = false;
            this.BtnSaveExpense.Click += new System.EventHandler(this.BtnSaveExpense_Click);
            // 
            // BtnShow
            // 
            this.BtnShow.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnShow.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnShow.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnShow.BorderRadius = 35;
            this.BtnShow.BorderSize = 0;
            this.BtnShow.FlatAppearance.BorderSize = 0;
            this.BtnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.Color.White;
            this.BtnShow.Location = new System.Drawing.Point(14, 10);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(120, 35);
            this.BtnShow.TabIndex = 10;
            this.BtnShow.Text = "Show";
            this.BtnShow.TextColor = System.Drawing.Color.White;
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // DataGridExpenseList
            // 
            this.DataGridExpenseList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridExpenseList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridExpenseList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridExpenseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridExpenseList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridExpenseList.Location = new System.Drawing.Point(18, 176);
            this.DataGridExpenseList.Name = "DataGridExpenseList";
            this.DataGridExpenseList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridExpenseList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridExpenseList.Size = new System.Drawing.Size(1070, 414);
            this.DataGridExpenseList.TabIndex = 27;
            this.DataGridExpenseList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridExpenseList_DataBindingComplete);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1115, 44);
            this.textBox1.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DodgerBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Cyan;
            this.label8.Location = new System.Drawing.Point(369, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(375, 31);
            this.label8.TabIndex = 29;
            this.label8.Text = "Daily Expense Management";
            // 
            // ExpenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1104, 602);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DataGridExpenseList);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Location = new System.Drawing.Point(569, 240);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComboFilteredBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox RichAmount;
        private System.Windows.Forms.ComboBox ComboExpense;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton RadioAll;
        private System.Windows.Forms.ComboBox ComboPayment;
        private System.Windows.Forms.ComboBox ComboBank;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtTotalAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DataGridExpenseList;
        private System.Windows.Forms.MaskedTextBox MaskDtEODTo;
        private System.Windows.Forms.MaskedTextBox MaskDtEODFrom;
        private CustomControls.Button.CustomButton BtnShow;
        private CustomControls.Button.CustomButton BtnSaveExpense;
        private CustomControls.Button.CustomButton BtnRemove;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtNarration;
        private System.Windows.Forms.Label label10;
    }
}