
namespace GrocerySupplyManagementApp.Forms
{
    partial class IncomeForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MaskDtEODFrom = new System.Windows.Forms.MaskedTextBox();
            this.MaskDtEODTo = new System.Windows.Forms.MaskedTextBox();
            this.TxtTotalAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ComboFilteredBy = new System.Windows.Forms.ComboBox();
            this.RadioAll = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboBank = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RichAmount = new System.Windows.Forms.RichTextBox();
            this.ComboIncome = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnRemove = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSaveIncome = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnShow = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.DataGridIncomeList = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtBoxNarration = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridIncomeList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MaskDtEODFrom);
            this.groupBox3.Controls.Add(this.MaskDtEODTo);
            this.groupBox3.Controls.Add(this.TxtTotalAmount);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.ComboFilteredBy);
            this.groupBox3.Controls.Add(this.RadioAll);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(18, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(490, 125);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtered Income";
            // 
            // MaskDtEODFrom
            // 
            this.MaskDtEODFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDtEODFrom.Location = new System.Drawing.Point(149, 22);
            this.MaskDtEODFrom.Mask = "   0000-00-00";
            this.MaskDtEODFrom.Name = "MaskDtEODFrom";
            this.MaskDtEODFrom.Size = new System.Drawing.Size(125, 26);
            this.MaskDtEODFrom.TabIndex = 1;
            this.MaskDtEODFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskDtEODFrom_KeyDown);
            this.MaskDtEODFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaskDateFrom_KeyUp);
            // 
            // MaskDtEODTo
            // 
            this.MaskDtEODTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDtEODTo.Location = new System.Drawing.Point(349, 22);
            this.MaskDtEODTo.Mask = "   0000-00-00";
            this.MaskDtEODTo.Name = "MaskDtEODTo";
            this.MaskDtEODTo.Size = new System.Drawing.Size(125, 26);
            this.MaskDtEODTo.TabIndex = 2;
            this.MaskDtEODTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskDtEODTo_KeyDown);
            // 
            // TxtTotalAmount
            // 
            this.TxtTotalAmount.BackColor = System.Drawing.Color.White;
            this.TxtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalAmount.Location = new System.Drawing.Point(349, 68);
            this.TxtTotalAmount.Name = "TxtTotalAmount";
            this.TxtTotalAmount.ReadOnly = true;
            this.TxtTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalAmount.Size = new System.Drawing.Size(125, 26);
            this.TxtTotalAmount.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(278, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(279, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Date To";
            // 
            // ComboFilteredBy
            // 
            this.ComboFilteredBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboFilteredBy.FormattingEnabled = true;
            this.ComboFilteredBy.Location = new System.Drawing.Point(124, 66);
            this.ComboFilteredBy.Name = "ComboFilteredBy";
            this.ComboFilteredBy.Size = new System.Drawing.Size(150, 28);
            this.ComboFilteredBy.TabIndex = 3;
            this.ComboFilteredBy.SelectedValueChanged += new System.EventHandler(this.ComboFilter_SelectedValueChanged);
            // 
            // RadioAll
            // 
            this.RadioAll.AutoSize = true;
            this.RadioAll.Checked = true;
            this.RadioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioAll.Location = new System.Drawing.Point(12, 24);
            this.RadioAll.Name = "RadioAll";
            this.RadioAll.Size = new System.Drawing.Size(57, 24);
            this.RadioAll.TabIndex = 0;
            this.RadioAll.TabStop = true;
            this.RadioAll.Text = "All  ";
            this.RadioAll.UseVisualStyleBackColor = true;
            this.RadioAll.CheckedChanged += new System.EventHandler(this.RadioAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(35, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filtered by ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(63, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(12, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Bank Name";
            // 
            // ComboBank
            // 
            this.ComboBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBank.FormattingEnabled = true;
            this.ComboBank.Location = new System.Drawing.Point(117, 53);
            this.ComboBank.Name = "ComboBank";
            this.ComboBank.Size = new System.Drawing.Size(277, 28);
            this.ComboBank.TabIndex = 7;
            this.ComboBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboBank_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(13, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Narration";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(9, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = " Add Income";
            // 
            // RichAmount
            // 
            this.RichAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RichAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAmount.Location = new System.Drawing.Point(279, 20);
            this.RichAmount.Name = "RichAmount";
            this.RichAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAmount.Size = new System.Drawing.Size(115, 29);
            this.RichAmount.TabIndex = 6;
            this.RichAmount.Text = "";
            this.RichAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichAmount_KeyPress);
            // 
            // ComboIncome
            // 
            this.ComboIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboIncome.FormattingEnabled = true;
            this.ComboIncome.Location = new System.Drawing.Point(117, 20);
            this.ComboIncome.Name = "ComboIncome";
            this.ComboIncome.Size = new System.Drawing.Size(160, 28);
            this.ComboIncome.TabIndex = 5;
            this.ComboIncome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboIncome_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnRemove);
            this.groupBox1.Controls.Add(this.BtnSaveIncome);
            this.groupBox1.Controls.Add(this.BtnShow);
            this.groupBox1.Location = new System.Drawing.Point(938, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 125);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // BtnRemove
            // 
            this.BtnRemove.BackColor = System.Drawing.Color.Red;
            this.BtnRemove.BackgroundColor = System.Drawing.Color.Red;
            this.BtnRemove.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.BtnRemove.BorderRadius = 35;
            this.BtnRemove.BorderSize = 0;
            this.BtnRemove.FlatAppearance.BorderSize = 0;
            this.BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemove.ForeColor = System.Drawing.Color.White;
            this.BtnRemove.Location = new System.Drawing.Point(18, 82);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(120, 35);
            this.BtnRemove.TabIndex = 11;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.TextColor = System.Drawing.Color.White;
            this.BtnRemove.UseVisualStyleBackColor = false;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnSaveIncome
            // 
            this.BtnSaveIncome.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveIncome.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSaveIncome.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSaveIncome.BorderRadius = 35;
            this.BtnSaveIncome.BorderSize = 0;
            this.BtnSaveIncome.FlatAppearance.BorderSize = 0;
            this.BtnSaveIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveIncome.ForeColor = System.Drawing.Color.White;
            this.BtnSaveIncome.Location = new System.Drawing.Point(17, 46);
            this.BtnSaveIncome.Name = "BtnSaveIncome";
            this.BtnSaveIncome.Size = new System.Drawing.Size(120, 35);
            this.BtnSaveIncome.TabIndex = 10;
            this.BtnSaveIncome.Text = "Save Income";
            this.BtnSaveIncome.TextColor = System.Drawing.Color.White;
            this.BtnSaveIncome.UseVisualStyleBackColor = false;
            this.BtnSaveIncome.Click += new System.EventHandler(this.BtnSaveIncome_Click);
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
            this.BtnShow.Location = new System.Drawing.Point(17, 10);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(120, 35);
            this.BtnShow.TabIndex = 9;
            this.BtnShow.Text = "Show";
            this.BtnShow.TextColor = System.Drawing.Color.White;
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // DataGridIncomeList
            // 
            this.DataGridIncomeList.BackgroundColor = System.Drawing.Color.White;
            this.DataGridIncomeList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridIncomeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridIncomeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridIncomeList.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridIncomeList.Location = new System.Drawing.Point(18, 175);
            this.DataGridIncomeList.Name = "DataGridIncomeList";
            this.DataGridIncomeList.Size = new System.Drawing.Size(1070, 420);
            this.DataGridIncomeList.TabIndex = 32;
            this.DataGridIncomeList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridIncomeView_DataBindingComplete);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1103, 44);
            this.textBox1.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DodgerBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Cyan;
            this.label6.Location = new System.Drawing.Point(381, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(358, 31);
            this.label6.TabIndex = 34;
            this.label6.Text = "Daily Income Management";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtBoxNarration);
            this.groupBox2.Controls.Add(this.ComboIncome);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.ComboBank);
            this.groupBox2.Controls.Add(this.RichAmount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(518, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 125);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Income";
            // 
            // TxtBoxNarration
            // 
            this.TxtBoxNarration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxNarration.Location = new System.Drawing.Point(117, 86);
            this.TxtBoxNarration.Name = "TxtBoxNarration";
            this.TxtBoxNarration.Size = new System.Drawing.Size(277, 26);
            this.TxtBoxNarration.TabIndex = 8;
            // 
            // IncomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1088, 597);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DataGridIncomeList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(569, 240);
            this.Name = "IncomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.IncomeDetailForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridIncomeList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ComboIncome;
        private System.Windows.Forms.RichTextBox RichAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RadioAll;
        private System.Windows.Forms.ComboBox ComboFilteredBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridIncomeList;
        private System.Windows.Forms.MaskedTextBox MaskDtEODFrom;
        private System.Windows.Forms.MaskedTextBox MaskDtEODTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboBank;
        private System.Windows.Forms.Label label4;
        private CustomControls.Button.CustomButton BtnShow;
        private CustomControls.Button.CustomButton BtnSaveIncome;
        private CustomControls.Button.CustomButton BtnRemove;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtBoxNarration;
    }
}