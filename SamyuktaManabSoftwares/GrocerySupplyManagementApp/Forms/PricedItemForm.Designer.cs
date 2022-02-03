
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
            this.TxtItemSubCode = new System.Windows.Forms.TextBox();
            this.ComboItemUnit = new System.Windows.Forms.ComboBox();
            this.TxtTotalStock = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtPerUnitValue = new System.Windows.Forms.TextBox();
            this.TxtItemName = new System.Windows.Forms.TextBox();
            this.TxtItemCode = new System.Windows.Forms.TextBox();
            this.TxtCustomPerUnitValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtProfitPercent = new System.Windows.Forms.TextBox();
            this.TxtProfitAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtSalesPricePerUnit = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.OpenItemImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TxtItemVolume = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PicBoxLoading = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.BtnExportToWordWithBarcode = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSearchUnpricedItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddSubCode = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnDeleteImage = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAddImage = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnDelete = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnUpdate = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnEdit = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSave = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnAdd = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnSearchPricedItem = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnExportToExcel = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
            this.BtnExportToWord = new GrocerySupplyManagementApp.CustomControls.Button.CustomButton();
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
            this.label1.Location = new System.Drawing.Point(83, 61);
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
            this.label3.Location = new System.Drawing.Point(77, 140);
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
            this.label4.Location = new System.Drawing.Point(92, 215);
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
            this.label5.Location = new System.Drawing.Point(5, 368);
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
            this.label6.Location = new System.Drawing.Point(32, 368);
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
            this.groupBox2.Controls.Add(this.TxtItemSubCode);
            this.groupBox2.Controls.Add(this.ComboItemUnit);
            this.groupBox2.Controls.Add(this.TxtTotalStock);
            this.groupBox2.Controls.Add(this.BtnSearchPricedItem);
            this.groupBox2.Controls.Add(this.BtnExportToExcel);
            this.groupBox2.Controls.Add(this.BtnExportToWord);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TxtPerUnitValue);
            this.groupBox2.Controls.Add(this.TxtItemName);
            this.groupBox2.Controls.Add(this.TxtItemCode);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(10, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 490);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stock Details";
            // 
            // TxtItemSubCode
            // 
            this.TxtItemSubCode.BackColor = System.Drawing.Color.White;
            this.TxtItemSubCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemSubCode.Location = new System.Drawing.Point(265, 57);
            this.TxtItemSubCode.Name = "TxtItemSubCode";
            this.TxtItemSubCode.Size = new System.Drawing.Size(57, 29);
            this.TxtItemSubCode.TabIndex = 55;
            // 
            // ComboItemUnit
            // 
            this.ComboItemUnit.Enabled = false;
            this.ComboItemUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.ComboItemUnit.FormattingEnabled = true;
            this.ComboItemUnit.Location = new System.Drawing.Point(172, 208);
            this.ComboItemUnit.Name = "ComboItemUnit";
            this.ComboItemUnit.Size = new System.Drawing.Size(313, 32);
            this.ComboItemUnit.TabIndex = 5;
            this.ComboItemUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboItemUnit_KeyPress);
            // 
            // TxtTotalStock
            // 
            this.TxtTotalStock.BackColor = System.Drawing.SystemColors.Window;
            this.TxtTotalStock.Enabled = false;
            this.TxtTotalStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalStock.Location = new System.Drawing.Point(171, 286);
            this.TxtTotalStock.Name = "TxtTotalStock";
            this.TxtTotalStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalStock.Size = new System.Drawing.Size(315, 29);
            this.TxtTotalStock.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(74, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Total Stock";
            // 
            // TxtPerUnitValue
            // 
            this.TxtPerUnitValue.BackColor = System.Drawing.SystemColors.Window;
            this.TxtPerUnitValue.Enabled = false;
            this.TxtPerUnitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPerUnitValue.Location = new System.Drawing.Point(171, 364);
            this.TxtPerUnitValue.Name = "TxtPerUnitValue";
            this.TxtPerUnitValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtPerUnitValue.Size = new System.Drawing.Size(315, 29);
            this.TxtPerUnitValue.TabIndex = 7;
            // 
            // TxtItemName
            // 
            this.TxtItemName.Enabled = false;
            this.TxtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtItemName.Location = new System.Drawing.Point(170, 133);
            this.TxtItemName.Name = "TxtItemName";
            this.TxtItemName.Size = new System.Drawing.Size(315, 29);
            this.TxtItemName.TabIndex = 3;
            // 
            // TxtItemCode
            // 
            this.TxtItemCode.BackColor = System.Drawing.Color.White;
            this.TxtItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemCode.Location = new System.Drawing.Point(172, 57);
            this.TxtItemCode.Name = "TxtItemCode";
            this.TxtItemCode.Size = new System.Drawing.Size(87, 29);
            this.TxtItemCode.TabIndex = 1;
            this.TxtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtItemCode_KeyDown);
            this.TxtItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtItemCode_KeyPress);
            // 
            // TxtCustomPerUnitValue
            // 
            this.TxtCustomPerUnitValue.BackColor = System.Drawing.SystemColors.Window;
            this.TxtCustomPerUnitValue.Enabled = false;
            this.TxtCustomPerUnitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCustomPerUnitValue.Location = new System.Drawing.Point(197, 211);
            this.TxtCustomPerUnitValue.Name = "TxtCustomPerUnitValue";
            this.TxtCustomPerUnitValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtCustomPerUnitValue.Size = new System.Drawing.Size(171, 29);
            this.TxtCustomPerUnitValue.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(15, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 20);
            this.label11.TabIndex = 46;
            this.label11.Text = "Custom Per Unit Value";
            // 
            // TxtProfitPercent
            // 
            this.TxtProfitPercent.Enabled = false;
            this.TxtProfitPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProfitPercent.Location = new System.Drawing.Point(197, 287);
            this.TxtProfitPercent.Name = "TxtProfitPercent";
            this.TxtProfitPercent.Size = new System.Drawing.Size(78, 29);
            this.TxtProfitPercent.TabIndex = 12;
            this.TxtProfitPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtProfitPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProfitPercent_KeyPress);
            this.TxtProfitPercent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtProfitPercent_KeyUp);
            // 
            // TxtProfitAmount
            // 
            this.TxtProfitAmount.Enabled = false;
            this.TxtProfitAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProfitAmount.Location = new System.Drawing.Point(278, 287);
            this.TxtProfitAmount.Name = "TxtProfitAmount";
            this.TxtProfitAmount.Size = new System.Drawing.Size(90, 29);
            this.TxtProfitAmount.TabIndex = 13;
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
            this.label8.Location = new System.Drawing.Point(34, 291);
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
            this.TxtSalesPricePerUnit.Location = new System.Drawing.Point(197, 364);
            this.TxtSalesPricePerUnit.Name = "TxtSalesPricePerUnit";
            this.TxtSalesPricePerUnit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtSalesPricePerUnit.Size = new System.Drawing.Size(171, 29);
            this.TxtSalesPricePerUnit.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnAddSubCode);
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
            // OpenItemImageDialog
            // 
            this.OpenItemImageDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenItemImageDialog_FileOk);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TxtItemVolume);
            this.groupBox5.Controls.Add(this.BtnExportToWordWithBarcode);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.TxtSalesPricePerUnit);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.BtnSearchUnpricedItem);
            this.groupBox5.Controls.Add(this.TxtCustomPerUnitValue);
            this.groupBox5.Controls.Add(this.TxtProfitPercent);
            this.groupBox5.Controls.Add(this.TxtProfitAmount);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Red;
            this.groupBox5.Location = new System.Drawing.Point(523, 55);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(390, 490);
            this.groupBox5.TabIndex = 54;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Customized Details";
            // 
            // TxtItemVolume
            // 
            this.TxtItemVolume.BackColor = System.Drawing.SystemColors.Window;
            this.TxtItemVolume.Enabled = false;
            this.TxtItemVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemVolume.Location = new System.Drawing.Point(197, 135);
            this.TxtItemVolume.Name = "TxtItemVolume";
            this.TxtItemVolume.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtItemVolume.Size = new System.Drawing.Size(171, 29);
            this.TxtItemVolume.TabIndex = 57;
            this.TxtItemVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtItemVolume_KeyPress);
            this.TxtItemVolume.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtItemVolume_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(87, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "Item Volume";
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
            this.BtnExportToWordWithBarcode.Location = new System.Drawing.Point(103, 430);
            this.BtnExportToWordWithBarcode.Name = "BtnExportToWordWithBarcode";
            this.BtnExportToWordWithBarcode.Size = new System.Drawing.Size(265, 32);
            this.BtnExportToWordWithBarcode.TabIndex = 55;
            this.BtnExportToWordWithBarcode.Text = "Export Price With Barcode To Word";
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
            this.BtnSearchUnpricedItem.Location = new System.Drawing.Point(197, 56);
            this.BtnSearchUnpricedItem.Name = "BtnSearchUnpricedItem";
            this.BtnSearchUnpricedItem.Size = new System.Drawing.Size(171, 32);
            this.BtnSearchUnpricedItem.TabIndex = 8;
            this.BtnSearchUnpricedItem.Text = " Item Search ";
            this.BtnSearchUnpricedItem.TextColor = System.Drawing.Color.White;
            this.BtnSearchUnpricedItem.UseVisualStyleBackColor = false;
            this.BtnSearchUnpricedItem.Click += new System.EventHandler(this.BtnSearchUnpricedItem_Click);
            // 
            // BtnAddSubCode
            // 
            this.BtnAddSubCode.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddSubCode.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddSubCode.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAddSubCode.BorderRadius = 35;
            this.BtnAddSubCode.BorderSize = 0;
            this.BtnAddSubCode.FlatAppearance.BorderSize = 0;
            this.BtnAddSubCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddSubCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddSubCode.ForeColor = System.Drawing.Color.White;
            this.BtnAddSubCode.Location = new System.Drawing.Point(18, 215);
            this.BtnAddSubCode.Name = "BtnAddSubCode";
            this.BtnAddSubCode.Size = new System.Drawing.Size(120, 35);
            this.BtnAddSubCode.TabIndex = 22;
            this.BtnAddSubCode.Text = "Add Sub Code";
            this.BtnAddSubCode.TextColor = System.Drawing.Color.White;
            this.BtnAddSubCode.UseVisualStyleBackColor = false;
            this.BtnAddSubCode.Click += new System.EventHandler(this.BtnAddSubCode_Click);
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
            this.BtnSearchPricedItem.Location = new System.Drawing.Point(328, 56);
            this.BtnSearchPricedItem.Name = "BtnSearchPricedItem";
            this.BtnSearchPricedItem.Size = new System.Drawing.Size(157, 30);
            this.BtnSearchPricedItem.TabIndex = 2;
            this.BtnSearchPricedItem.Text = "Item Search";
            this.BtnSearchPricedItem.TextColor = System.Drawing.Color.White;
            this.BtnSearchPricedItem.UseVisualStyleBackColor = false;
            this.BtnSearchPricedItem.Click += new System.EventHandler(this.BtnSearchPricedItem_Click);
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
            this.BtnExportToExcel.Location = new System.Drawing.Point(305, 430);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(175, 32);
            this.BtnExportToExcel.TabIndex = 22;
            this.BtnExportToExcel.Text = "Export Price To Excel";
            this.BtnExportToExcel.TextColor = System.Drawing.Color.White;
            this.BtnExportToExcel.UseVisualStyleBackColor = false;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
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
            this.BtnExportToWord.Location = new System.Drawing.Point(57, 430);
            this.BtnExportToWord.Name = "BtnExportToWord";
            this.BtnExportToWord.Size = new System.Drawing.Size(245, 32);
            this.BtnExportToWord.TabIndex = 54;
            this.BtnExportToWord.Text = "Export Price With Lable To Word";
            this.BtnExportToWord.TextColor = System.Drawing.Color.White;
            this.BtnExportToWord.UseVisualStyleBackColor = false;
            this.BtnExportToWord.Click += new System.EventHandler(this.BtnExportToWord_Click);
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
        private System.Windows.Forms.ComboBox ComboItemUnit;
        private System.Windows.Forms.TextBox TxtCustomPerUnitValue;
        private System.Windows.Forms.Label label11;
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
        private CustomControls.Button.CustomButton BtnAddSubCode;
        private System.Windows.Forms.TextBox TxtItemVolume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtItemSubCode;
    }
}