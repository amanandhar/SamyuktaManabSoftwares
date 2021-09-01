
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupFilter = new System.Windows.Forms.GroupBox();
            this.RadioService = new System.Windows.Forms.RadioButton();
            this.ComboService = new System.Windows.Forms.ComboBox();
            this.ComboBankTransfer = new System.Windows.Forms.ComboBox();
            this.RadioBankTransfer = new System.Windows.Forms.RadioButton();
            this.RadioItemCode = new System.Windows.Forms.RadioButton();
            this.ComboPurchase = new System.Windows.Forms.ComboBox();
            this.RadioInvoiceNo = new System.Windows.Forms.RadioButton();
            this.ComboExpense = new System.Windows.Forms.ComboBox();
            this.ComboItemCode = new System.Windows.Forms.ComboBox();
            this.RadioExpense = new System.Windows.Forms.RadioButton();
            this.RadioAll = new System.Windows.Forms.RadioButton();
            this.RadioPayment = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.RadioSales = new System.Windows.Forms.RadioButton();
            this.ComboInvoiceNo = new System.Windows.Forms.ComboBox();
            this.ComboSales = new System.Windows.Forms.ComboBox();
            this.RadioReceipt = new System.Windows.Forms.RadioButton();
            this.MaskEndOfDay = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RadioPurchase = new System.Windows.Forms.RadioButton();
            this.ComboPayment = new System.Windows.Forms.ComboBox();
            this.ComboReceipt = new System.Windows.Forms.ComboBox();
            this.ComboUser = new System.Windows.Forms.ComboBox();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.RadioUser = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDeleteTransaction = new System.Windows.Forms.Button();
            this.BtnShowTransaction = new System.Windows.Forms.Button();
            this.DataGridTransactionList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupFilter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTransactionList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupFilter
            // 
            this.GroupFilter.Controls.Add(this.RadioService);
            this.GroupFilter.Controls.Add(this.ComboService);
            this.GroupFilter.Controls.Add(this.ComboBankTransfer);
            this.GroupFilter.Controls.Add(this.RadioBankTransfer);
            this.GroupFilter.Controls.Add(this.RadioItemCode);
            this.GroupFilter.Controls.Add(this.ComboPurchase);
            this.GroupFilter.Controls.Add(this.RadioInvoiceNo);
            this.GroupFilter.Controls.Add(this.ComboExpense);
            this.GroupFilter.Controls.Add(this.ComboItemCode);
            this.GroupFilter.Controls.Add(this.RadioExpense);
            this.GroupFilter.Controls.Add(this.RadioAll);
            this.GroupFilter.Controls.Add(this.RadioPayment);
            this.GroupFilter.Controls.Add(this.label2);
            this.GroupFilter.Controls.Add(this.RadioSales);
            this.GroupFilter.Controls.Add(this.ComboInvoiceNo);
            this.GroupFilter.Controls.Add(this.ComboSales);
            this.GroupFilter.Controls.Add(this.RadioReceipt);
            this.GroupFilter.Controls.Add(this.MaskEndOfDay);
            this.GroupFilter.Controls.Add(this.label3);
            this.GroupFilter.Controls.Add(this.RadioPurchase);
            this.GroupFilter.Controls.Add(this.ComboPayment);
            this.GroupFilter.Controls.Add(this.ComboReceipt);
            this.GroupFilter.Controls.Add(this.ComboUser);
            this.GroupFilter.Controls.Add(this.TxtTotal);
            this.GroupFilter.Controls.Add(this.RadioUser);
            this.GroupFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupFilter.ForeColor = System.Drawing.Color.Red;
            this.GroupFilter.Location = new System.Drawing.Point(15, 43);
            this.GroupFilter.Name = "GroupFilter";
            this.GroupFilter.Size = new System.Drawing.Size(850, 125);
            this.GroupFilter.TabIndex = 5;
            this.GroupFilter.TabStop = false;
            // 
            // RadioService
            // 
            this.RadioService.AutoSize = true;
            this.RadioService.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioService.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioService.Location = new System.Drawing.Point(26, 43);
            this.RadioService.Name = "RadioService";
            this.RadioService.Size = new System.Drawing.Size(96, 22);
            this.RadioService.TabIndex = 46;
            this.RadioService.TabStop = true;
            this.RadioService.Text = "By Service";
            this.RadioService.UseVisualStyleBackColor = true;
            this.RadioService.CheckedChanged += new System.EventHandler(this.RadioService_CheckedChanged);
            // 
            // ComboService
            // 
            this.ComboService.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboService.FormattingEnabled = true;
            this.ComboService.Items.AddRange(new object[] {
            "Delivery Charge",
            "Sales Discount"});
            this.ComboService.Location = new System.Drawing.Point(132, 42);
            this.ComboService.Name = "ComboService";
            this.ComboService.Size = new System.Drawing.Size(115, 24);
            this.ComboService.TabIndex = 45;
            // 
            // ComboBankTransfer
            // 
            this.ComboBankTransfer.Enabled = false;
            this.ComboBankTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBankTransfer.FormattingEnabled = true;
            this.ComboBankTransfer.Items.AddRange(new object[] {
            "Cash"});
            this.ComboBankTransfer.Location = new System.Drawing.Point(442, 66);
            this.ComboBankTransfer.Name = "ComboBankTransfer";
            this.ComboBankTransfer.Size = new System.Drawing.Size(115, 24);
            this.ComboBankTransfer.TabIndex = 44;
            // 
            // RadioBankTransfer
            // 
            this.RadioBankTransfer.AutoSize = true;
            this.RadioBankTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBankTransfer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioBankTransfer.Location = new System.Drawing.Point(270, 69);
            this.RadioBankTransfer.Name = "RadioBankTransfer";
            this.RadioBankTransfer.Size = new System.Drawing.Size(119, 22);
            this.RadioBankTransfer.TabIndex = 43;
            this.RadioBankTransfer.TabStop = true;
            this.RadioBankTransfer.Text = "Bank Transfer";
            this.RadioBankTransfer.UseVisualStyleBackColor = true;
            this.RadioBankTransfer.CheckedChanged += new System.EventHandler(this.RadioBankTransfer_CheckedChanged);
            // 
            // RadioItemCode
            // 
            this.RadioItemCode.AutoSize = true;
            this.RadioItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioItemCode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioItemCode.Location = new System.Drawing.Point(587, 16);
            this.RadioItemCode.Name = "RadioItemCode";
            this.RadioItemCode.Size = new System.Drawing.Size(115, 22);
            this.RadioItemCode.TabIndex = 32;
            this.RadioItemCode.TabStop = true;
            this.RadioItemCode.Text = "By Item Code";
            this.RadioItemCode.UseVisualStyleBackColor = true;
            this.RadioItemCode.CheckedChanged += new System.EventHandler(this.RadioItemCode_CheckedChanged);
            // 
            // ComboPurchase
            // 
            this.ComboPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPurchase.FormattingEnabled = true;
            this.ComboPurchase.Items.AddRange(new object[] {
            "Cash",
            "Credit"});
            this.ComboPurchase.Location = new System.Drawing.Point(132, 68);
            this.ComboPurchase.Name = "ComboPurchase";
            this.ComboPurchase.Size = new System.Drawing.Size(115, 24);
            this.ComboPurchase.TabIndex = 42;
            // 
            // RadioInvoiceNo
            // 
            this.RadioInvoiceNo.AutoSize = true;
            this.RadioInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioInvoiceNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioInvoiceNo.Location = new System.Drawing.Point(587, 42);
            this.RadioInvoiceNo.Name = "RadioInvoiceNo";
            this.RadioInvoiceNo.Size = new System.Drawing.Size(117, 22);
            this.RadioInvoiceNo.TabIndex = 35;
            this.RadioInvoiceNo.Text = "By Invoice No";
            this.RadioInvoiceNo.UseVisualStyleBackColor = true;
            this.RadioInvoiceNo.CheckedChanged += new System.EventHandler(this.RadioInvoiceNo_CheckedChanged);
            // 
            // ComboExpense
            // 
            this.ComboExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboExpense.FormattingEnabled = true;
            this.ComboExpense.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboExpense.Location = new System.Drawing.Point(442, 40);
            this.ComboExpense.Name = "ComboExpense";
            this.ComboExpense.Size = new System.Drawing.Size(115, 24);
            this.ComboExpense.TabIndex = 41;
            // 
            // ComboItemCode
            // 
            this.ComboItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboItemCode.FormattingEnabled = true;
            this.ComboItemCode.Location = new System.Drawing.Point(705, 14);
            this.ComboItemCode.Name = "ComboItemCode";
            this.ComboItemCode.Size = new System.Drawing.Size(120, 24);
            this.ComboItemCode.TabIndex = 31;
            // 
            // RadioExpense
            // 
            this.RadioExpense.AutoSize = true;
            this.RadioExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioExpense.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioExpense.Location = new System.Drawing.Point(270, 42);
            this.RadioExpense.Name = "RadioExpense";
            this.RadioExpense.Size = new System.Drawing.Size(166, 22);
            this.RadioExpense.TabIndex = 40;
            this.RadioExpense.TabStop = true;
            this.RadioExpense.Text = "By Expense Payment";
            this.RadioExpense.UseVisualStyleBackColor = true;
            this.RadioExpense.CheckedChanged += new System.EventHandler(this.RadioExpense_CheckedChanged);
            // 
            // RadioAll
            // 
            this.RadioAll.AutoSize = true;
            this.RadioAll.Checked = true;
            this.RadioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioAll.Location = new System.Drawing.Point(27, 15);
            this.RadioAll.Name = "RadioAll";
            this.RadioAll.Size = new System.Drawing.Size(49, 22);
            this.RadioAll.TabIndex = 2;
            this.RadioAll.TabStop = true;
            this.RadioAll.Text = "All  ";
            this.RadioAll.UseVisualStyleBackColor = true;
            // 
            // RadioPayment
            // 
            this.RadioPayment.AutoSize = true;
            this.RadioPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioPayment.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioPayment.Location = new System.Drawing.Point(270, 15);
            this.RadioPayment.Name = "RadioPayment";
            this.RadioPayment.Size = new System.Drawing.Size(172, 22);
            this.RadioPayment.TabIndex = 39;
            this.RadioPayment.TabStop = true;
            this.RadioPayment.Text = "By Purchase Payment";
            this.RadioPayment.UseVisualStyleBackColor = true;
            this.RadioPayment.CheckedChanged += new System.EventHandler(this.RadioPayment_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(81, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date ";
            // 
            // RadioSales
            // 
            this.RadioSales.AutoSize = true;
            this.RadioSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioSales.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioSales.Location = new System.Drawing.Point(26, 95);
            this.RadioSales.Name = "RadioSales";
            this.RadioSales.Size = new System.Drawing.Size(84, 22);
            this.RadioSales.TabIndex = 3;
            this.RadioSales.Text = "By Sales";
            this.RadioSales.UseVisualStyleBackColor = true;
            this.RadioSales.CheckedChanged += new System.EventHandler(this.RadioSales_CheckedChanged);
            // 
            // ComboInvoiceNo
            // 
            this.ComboInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboInvoiceNo.FormattingEnabled = true;
            this.ComboInvoiceNo.Location = new System.Drawing.Point(705, 40);
            this.ComboInvoiceNo.Name = "ComboInvoiceNo";
            this.ComboInvoiceNo.Size = new System.Drawing.Size(120, 24);
            this.ComboInvoiceNo.TabIndex = 36;
            // 
            // ComboSales
            // 
            this.ComboSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboSales.FormattingEnabled = true;
            this.ComboSales.Items.AddRange(new object[] {
            "Cash",
            "Credit"});
            this.ComboSales.Location = new System.Drawing.Point(132, 94);
            this.ComboSales.Name = "ComboSales";
            this.ComboSales.Size = new System.Drawing.Size(115, 24);
            this.ComboSales.TabIndex = 38;
            // 
            // RadioReceipt
            // 
            this.RadioReceipt.AutoSize = true;
            this.RadioReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioReceipt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioReceipt.Location = new System.Drawing.Point(270, 95);
            this.RadioReceipt.Name = "RadioReceipt";
            this.RadioReceipt.Size = new System.Drawing.Size(101, 22);
            this.RadioReceipt.TabIndex = 14;
            this.RadioReceipt.Text = "By Receipt ";
            this.RadioReceipt.UseVisualStyleBackColor = true;
            this.RadioReceipt.CheckedChanged += new System.EventHandler(this.RadioReceipt_CheckedChanged);
            // 
            // MaskEndOfDay
            // 
            this.MaskEndOfDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskEndOfDay.Location = new System.Drawing.Point(132, 14);
            this.MaskEndOfDay.Mask = "   0000-00-00";
            this.MaskEndOfDay.Name = "MaskEndOfDay";
            this.MaskEndOfDay.Size = new System.Drawing.Size(115, 26);
            this.MaskEndOfDay.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(586, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total Amount";
            // 
            // RadioPurchase
            // 
            this.RadioPurchase.AutoSize = true;
            this.RadioPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioPurchase.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioPurchase.Location = new System.Drawing.Point(26, 68);
            this.RadioPurchase.Name = "RadioPurchase";
            this.RadioPurchase.Size = new System.Drawing.Size(110, 22);
            this.RadioPurchase.TabIndex = 18;
            this.RadioPurchase.Text = "By Purchase";
            this.RadioPurchase.UseVisualStyleBackColor = true;
            this.RadioPurchase.CheckedChanged += new System.EventHandler(this.RadioPurchase_CheckedChanged);
            // 
            // ComboPayment
            // 
            this.ComboPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPayment.FormattingEnabled = true;
            this.ComboPayment.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboPayment.Location = new System.Drawing.Point(442, 14);
            this.ComboPayment.Name = "ComboPayment";
            this.ComboPayment.Size = new System.Drawing.Size(115, 24);
            this.ComboPayment.TabIndex = 22;
            // 
            // ComboReceipt
            // 
            this.ComboReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboReceipt.FormattingEnabled = true;
            this.ComboReceipt.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.ComboReceipt.Location = new System.Drawing.Point(442, 92);
            this.ComboReceipt.Name = "ComboReceipt";
            this.ComboReceipt.Size = new System.Drawing.Size(115, 24);
            this.ComboReceipt.TabIndex = 23;
            // 
            // ComboUser
            // 
            this.ComboUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboUser.FormattingEnabled = true;
            this.ComboUser.Location = new System.Drawing.Point(705, 66);
            this.ComboUser.Name = "ComboUser";
            this.ComboUser.Size = new System.Drawing.Size(120, 24);
            this.ComboUser.TabIndex = 37;
            // 
            // TxtTotal
            // 
            this.TxtTotal.Enabled = false;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(705, 92);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotal.Size = new System.Drawing.Size(120, 26);
            this.TxtTotal.TabIndex = 28;
            // 
            // RadioUser
            // 
            this.RadioUser.AutoSize = true;
            this.RadioUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioUser.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RadioUser.Location = new System.Drawing.Point(587, 69);
            this.RadioUser.Name = "RadioUser";
            this.RadioUser.Size = new System.Drawing.Size(79, 22);
            this.RadioUser.TabIndex = 19;
            this.RadioUser.Text = "By User";
            this.RadioUser.UseVisualStyleBackColor = true;
            this.RadioUser.CheckedChanged += new System.EventHandler(this.RadioUser_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDeleteTransaction);
            this.groupBox2.Controls.Add(this.BtnShowTransaction);
            this.groupBox2.Location = new System.Drawing.Point(879, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 123);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // BtnDeleteTransaction
            // 
            this.BtnDeleteTransaction.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnDeleteTransaction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnDeleteTransaction.BackgroundImage")));
            this.BtnDeleteTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDeleteTransaction.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnDeleteTransaction.FlatAppearance.BorderSize = 2;
            this.BtnDeleteTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnDeleteTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteTransaction.ForeColor = System.Drawing.Color.Cyan;
            this.BtnDeleteTransaction.Location = new System.Drawing.Point(10, 63);
            this.BtnDeleteTransaction.Name = "BtnDeleteTransaction";
            this.BtnDeleteTransaction.Size = new System.Drawing.Size(130, 45);
            this.BtnDeleteTransaction.TabIndex = 1;
            this.BtnDeleteTransaction.Text = "Delete Transaction";
            this.BtnDeleteTransaction.UseVisualStyleBackColor = false;
            this.BtnDeleteTransaction.Click += new System.EventHandler(this.BtnDeleteTransaction_Click);
            // 
            // BtnShowTransaction
            // 
            this.BtnShowTransaction.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnShowTransaction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnShowTransaction.BackgroundImage")));
            this.BtnShowTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnShowTransaction.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnShowTransaction.FlatAppearance.BorderSize = 2;
            this.BtnShowTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnShowTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowTransaction.ForeColor = System.Drawing.Color.Cyan;
            this.BtnShowTransaction.Location = new System.Drawing.Point(10, 17);
            this.BtnShowTransaction.Name = "BtnShowTransaction";
            this.BtnShowTransaction.Size = new System.Drawing.Size(130, 45);
            this.BtnShowTransaction.TabIndex = 0;
            this.BtnShowTransaction.Text = "Show Transaction";
            this.BtnShowTransaction.UseVisualStyleBackColor = false;
            this.BtnShowTransaction.Click += new System.EventHandler(this.BtnShowTransaction_Click);
            // 
            // DataGridTransactionList
            // 
            this.DataGridTransactionList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DataGridTransactionList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridTransactionList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridTransactionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridTransactionList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridTransactionList.Location = new System.Drawing.Point(14, 171);
            this.DataGridTransactionList.Name = "DataGridTransactionList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridTransactionList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridTransactionList.Size = new System.Drawing.Size(1015, 365);
            this.DataGridTransactionList.TabIndex = 4;
            this.DataGridTransactionList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridTransactionList_CellContentClick);
            this.DataGridTransactionList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridTransactionList_DataBindingComplete);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-3, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1048, 45);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(329, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Daily Transaction Management";
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupFilter);
            this.Controls.Add(this.DataGridTransactionList);
            this.Controls.Add(this.groupBox2);
            this.Name = "TransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TransactionForm_Load);
            this.GroupFilter.ResumeLayout(false);
            this.GroupFilter.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTransactionList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnDeleteTransaction;
        private System.Windows.Forms.Button BtnShowTransaction;
        private System.Windows.Forms.RadioButton RadioReceipt;
        private System.Windows.Forms.RadioButton RadioSales;
        private System.Windows.Forms.RadioButton RadioAll;
        private System.Windows.Forms.ComboBox ComboReceipt;
        private System.Windows.Forms.ComboBox ComboPayment;
        private System.Windows.Forms.RadioButton RadioUser;
        private System.Windows.Forms.RadioButton RadioPurchase;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.MaskedTextBox MaskEndOfDay;
        private System.Windows.Forms.DataGridView DataGridTransactionList;
        private System.Windows.Forms.RadioButton RadioItemCode;
        private System.Windows.Forms.ComboBox ComboItemCode;
        private System.Windows.Forms.RadioButton RadioInvoiceNo;
        private System.Windows.Forms.GroupBox GroupFilter;
        private System.Windows.Forms.ComboBox ComboInvoiceNo;
        private System.Windows.Forms.ComboBox ComboUser;
        private System.Windows.Forms.ComboBox ComboSales;
        private System.Windows.Forms.ComboBox ComboExpense;
        private System.Windows.Forms.RadioButton RadioExpense;
        private System.Windows.Forms.RadioButton RadioPayment;
        private System.Windows.Forms.ComboBox ComboPurchase;
        private System.Windows.Forms.ComboBox ComboBankTransfer;
        private System.Windows.Forms.RadioButton RadioBankTransfer;
        private System.Windows.Forms.RadioButton RadioService;
        private System.Windows.Forms.ComboBox ComboService;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}