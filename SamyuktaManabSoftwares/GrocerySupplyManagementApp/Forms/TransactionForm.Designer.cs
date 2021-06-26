
namespace GrocerySupplyManagementApp.Forms
{
    partial class TransactionForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupFilter = new System.Windows.Forms.GroupBox();
            this.ComboUsers = new System.Windows.Forms.ComboBox();
            this.ComboInvoice = new System.Windows.Forms.ComboBox();
            this.RadioInvoice = new System.Windows.Forms.RadioButton();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.ComboSalesItem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RadioSalesItem = new System.Windows.Forms.RadioButton();
            this.RadioUsers = new System.Windows.Forms.RadioButton();
            this.RadioPaymentIn = new System.Windows.Forms.RadioButton();
            this.RadioPaymentOut = new System.Windows.Forms.RadioButton();
            this.ComboPaymentOut = new System.Windows.Forms.ComboBox();
            this.ComboPaymentIn = new System.Windows.Forms.ComboBox();
            this.GroupSale = new System.Windows.Forms.GroupBox();
            this.RadioAll = new System.Windows.Forms.RadioButton();
            this.RadioCashSale = new System.Windows.Forms.RadioButton();
            this.RadioCreditSale = new System.Windows.Forms.RadioButton();
            this.MaskDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDeleteTransaction = new System.Windows.Forms.Button();
            this.BtnShowTransaction = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DataGridTransactionList = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.GroupFilter.SuspendLayout();
            this.GroupSale.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTransactionList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GroupFilter);
            this.groupBox1.Controls.Add(this.GroupSale);
            this.groupBox1.Controls.Add(this.MaskDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // GroupFilter
            // 
            this.GroupFilter.Controls.Add(this.ComboUsers);
            this.GroupFilter.Controls.Add(this.ComboInvoice);
            this.GroupFilter.Controls.Add(this.RadioInvoice);
            this.GroupFilter.Controls.Add(this.TxtTotal);
            this.GroupFilter.Controls.Add(this.ComboSalesItem);
            this.GroupFilter.Controls.Add(this.label3);
            this.GroupFilter.Controls.Add(this.RadioSalesItem);
            this.GroupFilter.Controls.Add(this.RadioUsers);
            this.GroupFilter.Controls.Add(this.RadioPaymentIn);
            this.GroupFilter.Controls.Add(this.RadioPaymentOut);
            this.GroupFilter.Controls.Add(this.ComboPaymentOut);
            this.GroupFilter.Controls.Add(this.ComboPaymentIn);
            this.GroupFilter.Location = new System.Drawing.Point(209, 8);
            this.GroupFilter.Name = "GroupFilter";
            this.GroupFilter.Size = new System.Drawing.Size(605, 125);
            this.GroupFilter.TabIndex = 5;
            this.GroupFilter.TabStop = false;
            // 
            // ComboUsers
            // 
            this.ComboUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboUsers.FormattingEnabled = true;
            this.ComboUsers.Location = new System.Drawing.Point(427, 16);
            this.ComboUsers.Name = "ComboUsers";
            this.ComboUsers.Size = new System.Drawing.Size(160, 26);
            this.ComboUsers.TabIndex = 37;
            // 
            // ComboInvoice
            // 
            this.ComboInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboInvoice.FormattingEnabled = true;
            this.ComboInvoice.Location = new System.Drawing.Point(427, 53);
            this.ComboInvoice.Name = "ComboInvoice";
            this.ComboInvoice.Size = new System.Drawing.Size(160, 26);
            this.ComboInvoice.TabIndex = 36;
            // 
            // RadioInvoice
            // 
            this.RadioInvoice.AutoSize = true;
            this.RadioInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioInvoice.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioInvoice.Location = new System.Drawing.Point(336, 55);
            this.RadioInvoice.Name = "RadioInvoice";
            this.RadioInvoice.Size = new System.Drawing.Size(93, 22);
            this.RadioInvoice.TabIndex = 35;
            this.RadioInvoice.TabStop = true;
            this.RadioInvoice.Text = "By Invoice";
            this.RadioInvoice.UseVisualStyleBackColor = true;
            this.RadioInvoice.CheckedChanged += new System.EventHandler(this.RadioInvoice_CheckedChanged);
            // 
            // TxtTotal
            // 
            this.TxtTotal.Enabled = false;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(427, 88);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotal.Size = new System.Drawing.Size(160, 29);
            this.TxtTotal.TabIndex = 28;
            // 
            // ComboSalesItem
            // 
            this.ComboSalesItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboSalesItem.FormattingEnabled = true;
            this.ComboSalesItem.Location = new System.Drawing.Point(149, 90);
            this.ComboSalesItem.Name = "ComboSalesItem";
            this.ComboSalesItem.Size = new System.Drawing.Size(150, 26);
            this.ComboSalesItem.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(305, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total Amount";
            // 
            // RadioSalesItem
            // 
            this.RadioSalesItem.AutoSize = true;
            this.RadioSalesItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioSalesItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioSalesItem.Location = new System.Drawing.Point(15, 92);
            this.RadioSalesItem.Name = "RadioSalesItem";
            this.RadioSalesItem.Size = new System.Drawing.Size(120, 22);
            this.RadioSalesItem.TabIndex = 32;
            this.RadioSalesItem.TabStop = true;
            this.RadioSalesItem.Text = "By Sales Item ";
            this.RadioSalesItem.UseVisualStyleBackColor = true;
            this.RadioSalesItem.CheckedChanged += new System.EventHandler(this.RadioSalesItem_CheckedChanged);
            // 
            // RadioUsers
            // 
            this.RadioUsers.AutoSize = true;
            this.RadioUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioUsers.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioUsers.Location = new System.Drawing.Point(336, 18);
            this.RadioUsers.Name = "RadioUsers";
            this.RadioUsers.Size = new System.Drawing.Size(87, 22);
            this.RadioUsers.TabIndex = 19;
            this.RadioUsers.Text = "By Users";
            this.RadioUsers.UseVisualStyleBackColor = true;
            // 
            // RadioPaymentIn
            // 
            this.RadioPaymentIn.AutoSize = true;
            this.RadioPaymentIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioPaymentIn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioPaymentIn.Location = new System.Drawing.Point(15, 19);
            this.RadioPaymentIn.Name = "RadioPaymentIn";
            this.RadioPaymentIn.Size = new System.Drawing.Size(120, 22);
            this.RadioPaymentIn.TabIndex = 14;
            this.RadioPaymentIn.Text = "By Payment In";
            this.RadioPaymentIn.UseVisualStyleBackColor = true;
            // 
            // RadioPaymentOut
            // 
            this.RadioPaymentOut.AutoSize = true;
            this.RadioPaymentOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioPaymentOut.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioPaymentOut.Location = new System.Drawing.Point(15, 55);
            this.RadioPaymentOut.Name = "RadioPaymentOut";
            this.RadioPaymentOut.Size = new System.Drawing.Size(133, 22);
            this.RadioPaymentOut.TabIndex = 18;
            this.RadioPaymentOut.Text = "By Payment Out";
            this.RadioPaymentOut.UseVisualStyleBackColor = true;
            // 
            // ComboPaymentOut
            // 
            this.ComboPaymentOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPaymentOut.FormattingEnabled = true;
            this.ComboPaymentOut.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboPaymentOut.Location = new System.Drawing.Point(149, 53);
            this.ComboPaymentOut.Name = "ComboPaymentOut";
            this.ComboPaymentOut.Size = new System.Drawing.Size(150, 26);
            this.ComboPaymentOut.TabIndex = 22;
            // 
            // ComboPaymentIn
            // 
            this.ComboPaymentIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPaymentIn.FormattingEnabled = true;
            this.ComboPaymentIn.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboPaymentIn.Location = new System.Drawing.Point(149, 17);
            this.ComboPaymentIn.Name = "ComboPaymentIn";
            this.ComboPaymentIn.Size = new System.Drawing.Size(150, 26);
            this.ComboPaymentIn.TabIndex = 23;
            // 
            // GroupSale
            // 
            this.GroupSale.Controls.Add(this.RadioAll);
            this.GroupSale.Controls.Add(this.RadioCashSale);
            this.GroupSale.Controls.Add(this.RadioCreditSale);
            this.GroupSale.Location = new System.Drawing.Point(16, 38);
            this.GroupSale.Name = "GroupSale";
            this.GroupSale.Size = new System.Drawing.Size(180, 95);
            this.GroupSale.TabIndex = 30;
            this.GroupSale.TabStop = false;
            // 
            // RadioAll
            // 
            this.RadioAll.AutoSize = true;
            this.RadioAll.Checked = true;
            this.RadioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioAll.Location = new System.Drawing.Point(10, 11);
            this.RadioAll.Name = "RadioAll";
            this.RadioAll.Size = new System.Drawing.Size(41, 22);
            this.RadioAll.TabIndex = 2;
            this.RadioAll.TabStop = true;
            this.RadioAll.Text = "All";
            this.RadioAll.UseVisualStyleBackColor = true;
            // 
            // RadioCashSale
            // 
            this.RadioCashSale.AutoSize = true;
            this.RadioCashSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioCashSale.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioCashSale.Location = new System.Drawing.Point(10, 37);
            this.RadioCashSale.Name = "RadioCashSale";
            this.RadioCashSale.Size = new System.Drawing.Size(94, 22);
            this.RadioCashSale.TabIndex = 3;
            this.RadioCashSale.Text = "Cash Sale";
            this.RadioCashSale.UseVisualStyleBackColor = true;
            // 
            // RadioCreditSale
            // 
            this.RadioCreditSale.AutoSize = true;
            this.RadioCreditSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioCreditSale.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioCreditSale.Location = new System.Drawing.Point(10, 65);
            this.RadioCreditSale.Name = "RadioCreditSale";
            this.RadioCreditSale.Size = new System.Drawing.Size(98, 22);
            this.RadioCreditSale.TabIndex = 4;
            this.RadioCreditSale.Text = "Credit Sale";
            this.RadioCreditSale.UseVisualStyleBackColor = true;
            // 
            // MaskDate
            // 
            this.MaskDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskDate.Location = new System.Drawing.Point(66, 12);
            this.MaskDate.Mask = "   0000-00-00";
            this.MaskDate.Name = "MaskDate";
            this.MaskDate.Size = new System.Drawing.Size(130, 26);
            this.MaskDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(18, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDeleteTransaction);
            this.groupBox2.Controls.Add(this.BtnShowTransaction);
            this.groupBox2.Location = new System.Drawing.Point(860, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 140);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // BtnDeleteTransaction
            // 
            this.BtnDeleteTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteTransaction.ForeColor = System.Drawing.Color.Red;
            this.BtnDeleteTransaction.Location = new System.Drawing.Point(12, 73);
            this.BtnDeleteTransaction.Name = "BtnDeleteTransaction";
            this.BtnDeleteTransaction.Size = new System.Drawing.Size(140, 55);
            this.BtnDeleteTransaction.TabIndex = 1;
            this.BtnDeleteTransaction.Text = "Delete Transaction";
            this.BtnDeleteTransaction.UseVisualStyleBackColor = true;
            this.BtnDeleteTransaction.Click += new System.EventHandler(this.BtnDeleteTransaction_Click);
            // 
            // BtnShowTransaction
            // 
            this.BtnShowTransaction.BackColor = System.Drawing.SystemColors.Control;
            this.BtnShowTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowTransaction.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowTransaction.Location = new System.Drawing.Point(12, 16);
            this.BtnShowTransaction.Name = "BtnShowTransaction";
            this.BtnShowTransaction.Size = new System.Drawing.Size(140, 55);
            this.BtnShowTransaction.TabIndex = 0;
            this.BtnShowTransaction.Text = "Show Transaction";
            this.BtnShowTransaction.UseVisualStyleBackColor = false;
            this.BtnShowTransaction.Click += new System.EventHandler(this.BtnShowTransaction_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(0, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1045, 26);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "                                                                                 " +
    "      Daily Sales\r\n Transaction";
            // 
            // DataGridTransactionList
            // 
            this.DataGridTransactionList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DataGridTransactionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridTransactionList.Location = new System.Drawing.Point(14, 180);
            this.DataGridTransactionList.Name = "DataGridTransactionList";
            this.DataGridTransactionList.Size = new System.Drawing.Size(1010, 345);
            this.DataGridTransactionList.TabIndex = 4;
            this.DataGridTransactionList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridTransactionList_DataBindingComplete);
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.DataGridTransactionList);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TransactionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GroupFilter.ResumeLayout(false);
            this.GroupFilter.PerformLayout();
            this.GroupSale.ResumeLayout(false);
            this.GroupSale.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTransactionList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnDeleteTransaction;
        private System.Windows.Forms.Button BtnShowTransaction;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton RadioPaymentIn;
        private System.Windows.Forms.RadioButton RadioCashSale;
        private System.Windows.Forms.RadioButton RadioCreditSale;
        private System.Windows.Forms.RadioButton RadioAll;
        private System.Windows.Forms.ComboBox ComboPaymentIn;
        private System.Windows.Forms.ComboBox ComboPaymentOut;
        private System.Windows.Forms.RadioButton RadioUsers;
        private System.Windows.Forms.RadioButton RadioPaymentOut;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.MaskedTextBox MaskDate;
        private System.Windows.Forms.DataGridView DataGridTransactionList;
        private System.Windows.Forms.RadioButton RadioSalesItem;
        private System.Windows.Forms.ComboBox ComboSalesItem;
        private System.Windows.Forms.GroupBox GroupSale;
        private System.Windows.Forms.RadioButton RadioInvoice;
        private System.Windows.Forms.GroupBox GroupFilter;
        private System.Windows.Forms.ComboBox ComboInvoice;
        private System.Windows.Forms.ComboBox ComboUsers;
    }
}