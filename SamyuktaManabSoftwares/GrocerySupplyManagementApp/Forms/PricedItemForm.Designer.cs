
namespace GrocerySupplyManagementApp.Forms
{
    partial class PricedItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PricedItemForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PicBoxItemImage = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtItemUnit = new System.Windows.Forms.TextBox();
            this.TxtTotalStock = new System.Windows.Forms.TextBox();
            this.BtnSearchPricedItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtItemName = new System.Windows.Forms.TextBox();
            this.TxtItemCode = new System.Windows.Forms.TextBox();
            this.BtnExportToExcel = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.TxtPerUnitValue = new System.Windows.Forms.TextBox();
            this.TxtProfitPercent = new System.Windows.Forms.TextBox();
            this.TxtProfitAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtSalesPricePerUnit = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.customButton1 = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnDeleteImage = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddImage = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnDelete = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnUpdate = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnEdit = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSave = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAdd = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.OpenItemImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BtnBarcode1Clear = new System.Windows.Forms.Button();
            this.BtnBarcodeClear = new System.Windows.Forms.Button();
            this.TxtBarcode1 = new System.Windows.Forms.TextBox();
            this.TxtSalesPricePerUnit1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnExportToWord = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.TxtProfitAmount1 = new System.Windows.Forms.TextBox();
            this.TxtProfitPercent1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnExportToWordWithBarcode = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSearchUnpricedItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.PicBoxLoading = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxItemImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(26, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Item Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(26, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Item Unit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(22, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Purchase Unit Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(23, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Sales Price Per Unit";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PicBoxItemImage);
            this.groupBox1.Location = new System.Drawing.Point(922, 359);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 185);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // PicBoxItemImage
            // 
            this.PicBoxItemImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxItemImage.Image")));
            this.PicBoxItemImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("PicBoxItemImage.InitialImage")));
            this.PicBoxItemImage.Location = new System.Drawing.Point(4, 9);
            this.PicBoxItemImage.Name = "PicBoxItemImage";
            this.PicBoxItemImage.Size = new System.Drawing.Size(154, 171);
            this.PicBoxItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxItemImage.TabIndex = 0;
            this.PicBoxItemImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtItemUnit);
            this.groupBox2.Controls.Add(this.TxtTotalStock);
            this.groupBox2.Controls.Add(this.BtnSearchPricedItem);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TxtItemName);
            this.groupBox2.Controls.Add(this.TxtItemCode);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.BtnExportToExcel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(10, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 490);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stock Details";
            // 
            // TxtItemUnit
            // 
            this.TxtItemUnit.Enabled = false;
            this.TxtItemUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemUnit.Location = new System.Drawing.Point(22, 228);
            this.TxtItemUnit.Name = "TxtItemUnit";
            this.TxtItemUnit.Size = new System.Drawing.Size(330, 27);
            this.TxtItemUnit.TabIndex = 23;
            // 
            // TxtTotalStock
            // 
            this.TxtTotalStock.BackColor = System.Drawing.SystemColors.Window;
            this.TxtTotalStock.Enabled = false;
            this.TxtTotalStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalStock.Location = new System.Drawing.Point(23, 311);
            this.TxtTotalStock.Name = "TxtTotalStock";
            this.TxtTotalStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalStock.Size = new System.Drawing.Size(330, 29);
            this.TxtTotalStock.TabIndex = 5;
            // 
            // BtnSearchPricedItem
            // 
            this.BtnSearchPricedItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchPricedItem.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchPricedItem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSearchPricedItem.BorderRadius = 10;
            this.BtnSearchPricedItem.BorderSize = 0;
            this.BtnSearchPricedItem.FlatAppearance.BorderSize = 0;
            this.BtnSearchPricedItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchPricedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchPricedItem.ForeColor = System.Drawing.Color.White;
            this.BtnSearchPricedItem.Location = new System.Drawing.Point(265, 64);
            this.BtnSearchPricedItem.Name = "BtnSearchPricedItem";
            this.BtnSearchPricedItem.Size = new System.Drawing.Size(70, 31);
            this.BtnSearchPricedItem.TabIndex = 2;
            this.BtnSearchPricedItem.Text = "Search";
            this.BtnSearchPricedItem.TextColor = System.Drawing.Color.White;
            this.BtnSearchPricedItem.UseVisualStyleBackColor = false;
            this.BtnSearchPricedItem.Click += new System.EventHandler(this.BtnSearchPricedItem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(25, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Total Stock";
            // 
            // TxtItemName
            // 
            this.TxtItemName.Enabled = false;
            this.TxtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemName.Location = new System.Drawing.Point(23, 148);
            this.TxtItemName.Name = "TxtItemName";
            this.TxtItemName.Size = new System.Drawing.Size(330, 27);
            this.TxtItemName.TabIndex = 3;
            // 
            // TxtItemCode
            // 
            this.TxtItemCode.BackColor = System.Drawing.Color.White;
            this.TxtItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemCode.Location = new System.Drawing.Point(23, 65);
            this.TxtItemCode.Name = "TxtItemCode";
            this.TxtItemCode.Size = new System.Drawing.Size(240, 29);
            this.TxtItemCode.TabIndex = 1;
            this.TxtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtItemCode_KeyDown);
            this.TxtItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtItemCode_KeyPress);
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExportToExcel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnExportToExcel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnExportToExcel.BorderRadius = 10;
            this.BtnExportToExcel.BorderSize = 0;
            this.BtnExportToExcel.FlatAppearance.BorderSize = 0;
            this.BtnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.White;
            this.BtnExportToExcel.Location = new System.Drawing.Point(107, 406);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(175, 32);
            this.BtnExportToExcel.TabIndex = 22;
            this.BtnExportToExcel.Text = "Export Price To Excel";
            this.BtnExportToExcel.TextColor = System.Drawing.Color.White;
            this.BtnExportToExcel.UseVisualStyleBackColor = false;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // TxtPerUnitValue
            // 
            this.TxtPerUnitValue.BackColor = System.Drawing.SystemColors.Window;
            this.TxtPerUnitValue.Enabled = false;
            this.TxtPerUnitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPerUnitValue.Location = new System.Drawing.Point(20, 149);
            this.TxtPerUnitValue.Name = "TxtPerUnitValue";
            this.TxtPerUnitValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtPerUnitValue.Size = new System.Drawing.Size(465, 29);
            this.TxtPerUnitValue.TabIndex = 7;
            // 
            // TxtProfitPercent
            // 
            this.TxtProfitPercent.Enabled = false;
            this.TxtProfitPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProfitPercent.Location = new System.Drawing.Point(19, 228);
            this.TxtProfitPercent.Name = "TxtProfitPercent";
            this.TxtProfitPercent.Size = new System.Drawing.Size(100, 29);
            this.TxtProfitPercent.TabIndex = 8;
            this.TxtProfitPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtProfitPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProfitPercent_KeyPress);
            this.TxtProfitPercent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtProfitPercent_KeyUp);
            // 
            // TxtProfitAmount
            // 
            this.TxtProfitAmount.Enabled = false;
            this.TxtProfitAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProfitAmount.Location = new System.Drawing.Point(123, 228);
            this.TxtProfitAmount.Name = "TxtProfitAmount";
            this.TxtProfitAmount.Size = new System.Drawing.Size(120, 29);
            this.TxtProfitAmount.TabIndex = 9;
            this.TxtProfitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtProfitAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProfitAmount_KeyPress);
            this.TxtProfitAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtProfitAmount_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(22, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Profit Percentage %";
            // 
            // TxtSalesPricePerUnit
            // 
            this.TxtSalesPricePerUnit.BackColor = System.Drawing.SystemColors.Window;
            this.TxtSalesPricePerUnit.Enabled = false;
            this.TxtSalesPricePerUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSalesPricePerUnit.Location = new System.Drawing.Point(20, 311);
            this.TxtSalesPricePerUnit.Name = "TxtSalesPricePerUnit";
            this.TxtSalesPricePerUnit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtSalesPricePerUnit.Size = new System.Drawing.Size(223, 29);
            this.TxtSalesPricePerUnit.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.customButton1);
            this.groupBox3.Controls.Add(this.BtnDeleteImage);
            this.groupBox3.Controls.Add(this.BtnAddImage);
            this.groupBox3.Controls.Add(this.BtnDelete);
            this.groupBox3.Controls.Add(this.BtnUpdate);
            this.groupBox3.Controls.Add(this.BtnEdit);
            this.groupBox3.Controls.Add(this.BtnSave);
            this.groupBox3.Controls.Add(this.BtnAdd);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(922, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 300);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add Sales Price";
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.DodgerBlue;
            this.customButton1.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.customButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.customButton1.BorderRadius = 35;
            this.customButton1.BorderSize = 0;
            this.customButton1.FlatAppearance.BorderSize = 0;
            this.customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton1.ForeColor = System.Drawing.Color.White;
            this.customButton1.Location = new System.Drawing.Point(18, 215);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(120, 35);
            this.customButton1.TabIndex = 22;
            this.customButton1.Text = "Add Sub Code";
            this.customButton1.TextColor = System.Drawing.Color.White;
            this.customButton1.UseVisualStyleBackColor = false;
            // 
            // BtnDeleteImage
            // 
            this.BtnDeleteImage.BackColor = System.Drawing.Color.Red;
            this.BtnDeleteImage.BackgroundColor = System.Drawing.Color.Red;
            this.BtnDeleteImage.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnDeleteImage.BorderRadius = 20;
            this.BtnDeleteImage.BorderSize = 0;
            this.BtnDeleteImage.FlatAppearance.BorderSize = 0;
            this.BtnDeleteImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeleteImage.ForeColor = System.Drawing.Color.White;
            this.BtnDeleteImage.Location = new System.Drawing.Point(80, 263);
            this.BtnDeleteImage.Name = "BtnDeleteImage";
            this.BtnDeleteImage.Size = new System.Drawing.Size(59, 25);
            this.BtnDeleteImage.TabIndex = 21;
            this.BtnDeleteImage.Text = "Delete";
            this.BtnDeleteImage.TextColor = System.Drawing.Color.White;
            this.BtnDeleteImage.UseVisualStyleBackColor = false;
            this.BtnDeleteImage.Click += new System.EventHandler(this.BtnDeleteImage_Click);
            // 
            // BtnAddImage
            // 
            this.BtnAddImage.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddImage.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddImage.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddImage.BorderRadius = 20;
            this.BtnAddImage.BorderSize = 0;
            this.BtnAddImage.FlatAppearance.BorderSize = 0;
            this.BtnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddImage.ForeColor = System.Drawing.Color.White;
            this.BtnAddImage.Location = new System.Drawing.Point(18, 263);
            this.BtnAddImage.Name = "BtnAddImage";
            this.BtnAddImage.Size = new System.Drawing.Size(59, 25);
            this.BtnAddImage.TabIndex = 20;
            this.BtnAddImage.Text = "Add";
            this.BtnAddImage.TextColor = System.Drawing.Color.White;
            this.BtnAddImage.UseVisualStyleBackColor = false;
            this.BtnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
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
            this.BtnDelete.Location = new System.Drawing.Point(18, 178);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(120, 35);
            this.BtnDelete.TabIndex = 19;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.TextColor = System.Drawing.Color.White;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdate.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnUpdate.BorderRadius = 35;
            this.BtnUpdate.BorderSize = 0;
            this.BtnUpdate.FlatAppearance.BorderSize = 0;
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnUpdate.Location = new System.Drawing.Point(18, 141);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(120, 35);
            this.BtnUpdate.TabIndex = 18;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.TextColor = System.Drawing.Color.White;
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.Red;
            this.BtnEdit.BackgroundColor = System.Drawing.Color.Red;
            this.BtnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnEdit.BorderRadius = 35;
            this.BtnEdit.BorderSize = 0;
            this.BtnEdit.FlatAppearance.BorderSize = 0;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(18, 104);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(120, 35);
            this.BtnEdit.TabIndex = 17;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.TextColor = System.Drawing.Color.White;
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSave.BorderRadius = 35;
            this.BtnSave.BorderSize = 0;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(18, 67);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(120, 35);
            this.BtnSave.TabIndex = 16;
            this.BtnSave.Text = "Save";
            this.BtnSave.TextColor = System.Drawing.Color.White;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAdd.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAdd.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAdd.BorderRadius = 35;
            this.BtnAdd.BorderSize = 0;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(18, 30);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 35);
            this.BtnAdd.TabIndex = 15;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.TextColor = System.Drawing.Color.White;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // OpenItemImageDialog
            // 
            this.OpenItemImageDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenItemImageDialog_FileOk);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.BtnBarcode1Clear);
            this.groupBox5.Controls.Add(this.BtnBarcodeClear);
            this.groupBox5.Controls.Add(this.TxtBarcode1);
            this.groupBox5.Controls.Add(this.TxtSalesPricePerUnit1);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.BtnExportToWord);
            this.groupBox5.Controls.Add(this.TxtProfitAmount1);
            this.groupBox5.Controls.Add(this.TxtProfitPercent1);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.TxtBarcode);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.BtnExportToWordWithBarcode);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.TxtSalesPricePerUnit);
            this.groupBox5.Controls.Add(this.TxtPerUnitValue);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.BtnSearchUnpricedItem);
            this.groupBox5.Controls.Add(this.TxtProfitPercent);
            this.groupBox5.Controls.Add(this.TxtProfitAmount);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Red;
            this.groupBox5.Location = new System.Drawing.Point(397, 55);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(515, 490);
            this.groupBox5.TabIndex = 54;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Customized Details";
            // 
            // BtnBarcode1Clear
            // 
            this.BtnBarcode1Clear.Location = new System.Drawing.Point(388, 67);
            this.BtnBarcode1Clear.Name = "BtnBarcode1Clear";
            this.BtnBarcode1Clear.Size = new System.Drawing.Size(32, 23);
            this.BtnBarcode1Clear.TabIndex = 64;
            this.BtnBarcode1Clear.Text = "X";
            this.BtnBarcode1Clear.UseVisualStyleBackColor = true;
            this.BtnBarcode1Clear.Click += new System.EventHandler(this.BtnBarcode1Clear_Click);
            // 
            // BtnBarcodeClear
            // 
            this.BtnBarcodeClear.Location = new System.Drawing.Point(185, 67);
            this.BtnBarcodeClear.Name = "BtnBarcodeClear";
            this.BtnBarcodeClear.Size = new System.Drawing.Size(32, 23);
            this.BtnBarcodeClear.TabIndex = 63;
            this.BtnBarcodeClear.Text = "X";
            this.BtnBarcodeClear.UseVisualStyleBackColor = true;
            this.BtnBarcodeClear.Click += new System.EventHandler(this.BtnBarcodeClear_Click);
            // 
            // TxtBarcode1
            // 
            this.TxtBarcode1.BackColor = System.Drawing.SystemColors.Window;
            this.TxtBarcode1.Enabled = false;
            this.TxtBarcode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBarcode1.Location = new System.Drawing.Point(223, 64);
            this.TxtBarcode1.Name = "TxtBarcode1";
            this.TxtBarcode1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBarcode1.Size = new System.Drawing.Size(200, 29);
            this.TxtBarcode1.TabIndex = 11;
            this.TxtBarcode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtSalesPricePerUnit1
            // 
            this.TxtSalesPricePerUnit1.BackColor = System.Drawing.SystemColors.Window;
            this.TxtSalesPricePerUnit1.Enabled = false;
            this.TxtSalesPricePerUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSalesPricePerUnit1.Location = new System.Drawing.Point(261, 311);
            this.TxtSalesPricePerUnit1.Name = "TxtSalesPricePerUnit1";
            this.TxtSalesPricePerUnit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtSalesPricePerUnit1.Size = new System.Drawing.Size(224, 29);
            this.TxtSalesPricePerUnit1.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(265, 287);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(190, 20);
            this.label12.TabIndex = 62;
            this.label12.Text = "Sales Price Per Unit + 1";
            // 
            // BtnExportToWord
            // 
            this.BtnExportToWord.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExportToWord.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnExportToWord.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnExportToWord.BorderRadius = 10;
            this.BtnExportToWord.BorderSize = 0;
            this.BtnExportToWord.FlatAppearance.BorderSize = 0;
            this.BtnExportToWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportToWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportToWord.ForeColor = System.Drawing.Color.White;
            this.BtnExportToWord.Location = new System.Drawing.Point(26, 406);
            this.BtnExportToWord.Name = "BtnExportToWord";
            this.BtnExportToWord.Size = new System.Drawing.Size(225, 32);
            this.BtnExportToWord.TabIndex = 54;
            this.BtnExportToWord.Text = "Export Price Label To Word";
            this.BtnExportToWord.TextColor = System.Drawing.Color.White;
            this.BtnExportToWord.UseVisualStyleBackColor = false;
            this.BtnExportToWord.Click += new System.EventHandler(this.BtnExportToWord_Click);
            // 
            // TxtProfitAmount1
            // 
            this.TxtProfitAmount1.Enabled = false;
            this.TxtProfitAmount1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProfitAmount1.Location = new System.Drawing.Point(365, 228);
            this.TxtProfitAmount1.Name = "TxtProfitAmount1";
            this.TxtProfitAmount1.Size = new System.Drawing.Size(120, 29);
            this.TxtProfitAmount1.TabIndex = 13;
            this.TxtProfitAmount1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtProfitAmount1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProfitAmount1_KeyPress);
            this.TxtProfitAmount1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtProfitAmount1_KeyUp);
            // 
            // TxtProfitPercent1
            // 
            this.TxtProfitPercent1.Enabled = false;
            this.TxtProfitPercent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProfitPercent1.Location = new System.Drawing.Point(261, 228);
            this.TxtProfitPercent1.Name = "TxtProfitPercent1";
            this.TxtProfitPercent1.Size = new System.Drawing.Size(100, 29);
            this.TxtProfitPercent1.TabIndex = 12;
            this.TxtProfitPercent1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtProfitPercent1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProfitPercent1_KeyPress);
            this.TxtProfitPercent1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtProfitPercent1_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(264, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(188, 20);
            this.label11.TabIndex = 59;
            this.label11.Text = "Profit Percentage % + 1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(233, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(195, 20);
            this.label9.TabIndex = 58;
            this.label9.Text = "Customized Barcode + 1";
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.BackColor = System.Drawing.SystemColors.Window;
            this.TxtBarcode.Enabled = false;
            this.TxtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBarcode.Location = new System.Drawing.Point(20, 64);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBarcode.Size = new System.Drawing.Size(200, 29);
            this.TxtBarcode.TabIndex = 6;
            this.TxtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "Customized Barcode";
            // 
            // BtnExportToWordWithBarcode
            // 
            this.BtnExportToWordWithBarcode.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExportToWordWithBarcode.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnExportToWordWithBarcode.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnExportToWordWithBarcode.BorderRadius = 10;
            this.BtnExportToWordWithBarcode.BorderSize = 0;
            this.BtnExportToWordWithBarcode.FlatAppearance.BorderSize = 0;
            this.BtnExportToWordWithBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportToWordWithBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportToWordWithBarcode.ForeColor = System.Drawing.Color.White;
            this.BtnExportToWordWithBarcode.Location = new System.Drawing.Point(254, 406);
            this.BtnExportToWordWithBarcode.Name = "BtnExportToWordWithBarcode";
            this.BtnExportToWordWithBarcode.Size = new System.Drawing.Size(225, 32);
            this.BtnExportToWordWithBarcode.TabIndex = 55;
            this.BtnExportToWordWithBarcode.Text = "Export Barcode To Word";
            this.BtnExportToWordWithBarcode.TextColor = System.Drawing.Color.White;
            this.BtnExportToWordWithBarcode.UseVisualStyleBackColor = false;
            this.BtnExportToWordWithBarcode.Click += new System.EventHandler(this.BtnExportToWordWithBarcode_Click);
            // 
            // BtnSearchUnpricedItem
            // 
            this.BtnSearchUnpricedItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchUnpricedItem.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSearchUnpricedItem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSearchUnpricedItem.BorderRadius = 10;
            this.BtnSearchUnpricedItem.BorderSize = 0;
            this.BtnSearchUnpricedItem.FlatAppearance.BorderSize = 0;
            this.BtnSearchUnpricedItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchUnpricedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchUnpricedItem.ForeColor = System.Drawing.Color.White;
            this.BtnSearchUnpricedItem.Location = new System.Drawing.Point(425, 63);
            this.BtnSearchUnpricedItem.Name = "BtnSearchUnpricedItem";
            this.BtnSearchUnpricedItem.Size = new System.Drawing.Size(70, 31);
            this.BtnSearchUnpricedItem.TabIndex = 8;
            this.BtnSearchUnpricedItem.Text = "Search";
            this.BtnSearchUnpricedItem.TextColor = System.Drawing.Color.White;
            this.BtnSearchUnpricedItem.UseVisualStyleBackColor = false;
            this.BtnSearchUnpricedItem.Click += new System.EventHandler(this.BtnSearchUnpricedItem_Click);
            // 
            // PicBoxLoading
            // 
            this.PicBoxLoading.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxLoading.Image")));
            this.PicBoxLoading.Location = new System.Drawing.Point(958, 550);
            this.PicBoxLoading.Name = "PicBoxLoading";
            this.PicBoxLoading.Size = new System.Drawing.Size(78, 39);
            this.PicBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicBoxLoading.TabIndex = 53;
            this.PicBoxLoading.TabStop = false;
            this.PicBoxLoading.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1103, 44);
            this.textBox1.TabIndex = 55;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DodgerBlue;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Cyan;
            this.label10.Location = new System.Drawing.Point(371, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(344, 31);
            this.label10.TabIndex = 56;
            this.label10.Text = "Item Pricing Management";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "xlsx";
            this.SaveFileDialog.FileName = "PriceItemReport";
            this.SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            this.SaveFileDialog.InitialDirectory = "C:\\";
            // 
            // BackgroundWorker
            // 
            this.BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // PricedItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1088, 597);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PicBoxLoading);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(569, 240);
            this.Name = "PricedItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PricedItemForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxItemImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtSalesPricePerUnit;
        private System.Windows.Forms.TextBox TxtPerUnitValue;
        private System.Windows.Forms.TextBox TxtItemName;
        private System.Windows.Forms.TextBox TxtItemCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog OpenItemImageDialog;
        private System.Windows.Forms.TextBox TxtTotalStock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtProfitPercent;
        private System.Windows.Forms.TextBox TxtProfitAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox PicBoxItemImage;
        private System.Windows.Forms.GroupBox groupBox5;
        private CustomControls.Button.CustomButton BtnSearchPricedItem;
        private CustomControls.Button.CustomButton BtnSearchUnpricedItem;
        private CustomControls.Button.CustomButton BtnAdd;
        private CustomControls.Button.CustomButton BtnSave;
        private CustomControls.Button.CustomButton BtnEdit;
        private CustomControls.Button.CustomButton BtnUpdate;
        private CustomControls.Button.CustomButton BtnDelete;
        private CustomControls.Button.CustomButton BtnAddImage;
        private CustomControls.Button.CustomButton BtnDeleteImage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private CustomControls.Button.CustomButton BtnExportToExcel;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.PictureBox PicBoxLoading;
        private CustomControls.Button.CustomButton BtnExportToWord;
        private CustomControls.Button.CustomButton BtnExportToWordWithBarcode;
        private CustomControls.Button.CustomButton customButton1;
        private System.Windows.Forms.TextBox TxtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBarcode1;
        private System.Windows.Forms.TextBox TxtSalesPricePerUnit1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtProfitAmount1;
        private System.Windows.Forms.TextBox TxtProfitPercent1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnBarcode1Clear;
        private System.Windows.Forms.Button BtnBarcodeClear;
        private System.Windows.Forms.TextBox TxtItemUnit;
    }
}