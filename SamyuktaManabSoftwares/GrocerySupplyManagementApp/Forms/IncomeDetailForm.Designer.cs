
namespace GrocerySupplyManagementApp.Forms
{
    partial class IncomeDetailForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MaskDateFrom = new System.Windows.Forms.MaskedTextBox();
            this.MaskDateTo = new System.Windows.Forms.MaskedTextBox();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ComboFilter = new System.Windows.Forms.ComboBox();
            this.RadioAll = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnShowExpense = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ComboAddIncome = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RichAddAmount = new System.Windows.Forms.RichTextBox();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnAddIncome = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnShow = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DataGridIncomeView = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridIncomeView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MaskDateFrom);
            this.groupBox3.Controls.Add(this.MaskDateTo);
            this.groupBox3.Controls.Add(this.TxtAmount);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.ComboFilter);
            this.groupBox3.Controls.Add(this.RadioAll);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(18, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 125);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            // 
            // MaskDateFrom
            // 
            this.MaskDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDateFrom.Location = new System.Drawing.Point(168, 19);
            this.MaskDateFrom.Mask = "   0000-00-00";
            this.MaskDateFrom.Name = "MaskDateFrom";
            this.MaskDateFrom.Size = new System.Drawing.Size(125, 24);
            this.MaskDateFrom.TabIndex = 24;
            this.MaskDateFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaskDateFrom_KeyUp);
            // 
            // MaskDateTo
            // 
            this.MaskDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDateTo.Location = new System.Drawing.Point(375, 21);
            this.MaskDateTo.Mask = "   0000-00-00";
            this.MaskDateTo.Name = "MaskDateTo";
            this.MaskDateTo.Size = new System.Drawing.Size(125, 24);
            this.MaskDateTo.TabIndex = 23;
            // 
            // TxtAmount
            // 
            this.TxtAmount.Enabled = false;
            this.TxtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAmount.Location = new System.Drawing.Point(375, 64);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Size = new System.Drawing.Size(125, 27);
            this.TxtAmount.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(308, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(307, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Date To";
            // 
            // ComboFilter
            // 
            this.ComboFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboFilter.FormattingEnabled = true;
            this.ComboFilter.Items.AddRange(new object[] {
            "Delivery Charge",
            "Member Fee",
            "Other Income",
            "Sales Profit",
            "Suppliers Commission"});
            this.ComboFilter.Location = new System.Drawing.Point(98, 64);
            this.ComboFilter.Name = "ComboFilter";
            this.ComboFilter.Size = new System.Drawing.Size(195, 28);
            this.ComboFilter.TabIndex = 8;
            this.ComboFilter.SelectedValueChanged += new System.EventHandler(this.ComboFilter_SelectedValueChanged);
            // 
            // RadioAll
            // 
            this.RadioAll.AutoSize = true;
            this.RadioAll.Checked = true;
            this.RadioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioAll.Location = new System.Drawing.Point(16, 21);
            this.RadioAll.Name = "RadioAll";
            this.RadioAll.Size = new System.Drawing.Size(49, 22);
            this.RadioAll.TabIndex = 19;
            this.RadioAll.TabStop = true;
            this.RadioAll.Text = "All ";
            this.RadioAll.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(10, 68);
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
            this.label3.Location = new System.Drawing.Point(81, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date From";
            // 
            // BtnShowExpense
            // 
            this.BtnShowExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowExpense.ForeColor = System.Drawing.Color.Red;
            this.BtnShowExpense.Location = new System.Drawing.Point(195, 63);
            this.BtnShowExpense.Name = "BtnShowExpense";
            this.BtnShowExpense.Size = new System.Drawing.Size(118, 33);
            this.BtnShowExpense.TabIndex = 26;
            this.BtnShowExpense.Text = "Show Expense ";
            this.BtnShowExpense.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = " Add Income";
            // 
            // ComboAddIncome
            // 
            this.ComboAddIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboAddIncome.FormattingEnabled = true;
            this.ComboAddIncome.Items.AddRange(new object[] {
            "Suppliers Commission",
            "Other Income"});
            this.ComboAddIncome.Location = new System.Drawing.Point(108, 19);
            this.ComboAddIncome.Name = "ComboAddIncome";
            this.ComboAddIncome.Size = new System.Drawing.Size(205, 28);
            this.ComboAddIncome.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(4, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = " Add Amount";
            // 
            // RichAddAmount
            // 
            this.RichAddAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAddAmount.Location = new System.Drawing.Point(108, 65);
            this.RichAddAmount.Name = "RichAddAmount";
            this.RichAddAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichAddAmount.Size = new System.Drawing.Size(86, 30);
            this.RichAddAmount.TabIndex = 17;
            this.RichAddAmount.Text = "";
            // 
            // BtnRemove
            // 
            this.BtnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemove.ForeColor = System.Drawing.Color.Red;
            this.BtnRemove.Location = new System.Drawing.Point(7, 85);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(125, 35);
            this.BtnRemove.TabIndex = 15;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            // 
            // BtnAddIncome
            // 
            this.BtnAddIncome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddIncome.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAddIncome.Location = new System.Drawing.Point(7, 48);
            this.BtnAddIncome.Name = "BtnAddIncome";
            this.BtnAddIncome.Size = new System.Drawing.Size(125, 35);
            this.BtnAddIncome.TabIndex = 16;
            this.BtnAddIncome.Text = "Save Income";
            this.BtnAddIncome.UseVisualStyleBackColor = true;
            this.BtnAddIncome.Click += new System.EventHandler(this.BtnAddIncome_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnRemove);
            this.groupBox1.Controls.Add(this.BtnShow);
            this.groupBox1.Controls.Add(this.BtnAddIncome);
            this.groupBox1.Location = new System.Drawing.Point(883, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 125);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // BtnShow
            // 
            this.BtnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShow.Location = new System.Drawing.Point(7, 11);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(125, 35);
            this.BtnShow.TabIndex = 2;
            this.BtnShow.Text = "Show ";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1045, 26);
            this.textBox1.TabIndex = 26;
            this.textBox1.Text = "                                                                                 " +
    "     \r\n   \r\nDaily Income Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.BtnShowExpense);
            this.groupBox2.Controls.Add(this.ComboAddIncome);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.RichAddAmount);
            this.groupBox2.Location = new System.Drawing.Point(543, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 125);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            // 
            // DataGridIncomeView
            // 
            this.DataGridIncomeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridIncomeView.Location = new System.Drawing.Point(18, 170);
            this.DataGridIncomeView.Name = "DataGridIncomeView";
            this.DataGridIncomeView.Size = new System.Drawing.Size(1005, 360);
            this.DataGridIncomeView.TabIndex = 32;
            this.DataGridIncomeView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridIncomeView_DataBindingComplete);
            // 
            // IncomeDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.DataGridIncomeView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "IncomeDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.IncomeDetailForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridIncomeView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnAddIncome;
        private System.Windows.Forms.ComboBox ComboAddIncome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox RichAddAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RadioAll;
        private System.Windows.Forms.ComboBox ComboFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnShowExpense;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridIncomeView;
        private System.Windows.Forms.MaskedTextBox MaskDateFrom;
        private System.Windows.Forms.MaskedTextBox MaskDateTo;
    }
}