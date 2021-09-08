
namespace GrocerySupplyManagementApp.Forms
{
    partial class CompanyInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyInfoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.RichRegistrationNo = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PicBoxCompanyLogo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RichPanVatNo = new System.Windows.Forms.RichTextBox();
            this.RichRegistrationDate = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnClearAll = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RichShortName = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.RichFacebookPage = new System.Windows.Forms.RichTextBox();
            this.RichWebsite = new System.Windows.Forms.RichTextBox();
            this.RichEmailId = new System.Windows.Forms.RichTextBox();
            this.RichContactNo = new System.Windows.Forms.RichTextBox();
            this.RichAddress = new System.Windows.Forms.RichTextBox();
            this.RichCompanyType = new System.Windows.Forms.RichTextBox();
            this.RichCompanyName = new System.Windows.Forms.RichTextBox();
            this.OpenCompanyLogoDialog = new System.Windows.Forms.OpenFileDialog();
            this.BtnAddImage = new System.Windows.Forms.Button();
            this.BtnDeleteImage = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxCompanyLogo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registration No.";
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnEdit.BackgroundImage")));
            this.BtnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEdit.Enabled = false;
            this.BtnEdit.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.Red;
            this.BtnEdit.Location = new System.Drawing.Point(9, 17);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(110, 35);
            this.BtnEdit.TabIndex = 1;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // RichRegistrationNo
            // 
            this.RichRegistrationNo.Enabled = false;
            this.RichRegistrationNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichRegistrationNo.Location = new System.Drawing.Point(142, 18);
            this.RichRegistrationNo.Name = "RichRegistrationNo";
            this.RichRegistrationNo.Size = new System.Drawing.Size(200, 35);
            this.RichRegistrationNo.TabIndex = 2;
            this.RichRegistrationNo.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PicBoxCompanyLogo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.groupBox1.Location = new System.Drawing.Point(16, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 145);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company Logo";
            // 
            // PicBoxCompanyLogo
            // 
            this.PicBoxCompanyLogo.Location = new System.Drawing.Point(6, 18);
            this.PicBoxCompanyLogo.Name = "PicBoxCompanyLogo";
            this.PicBoxCompanyLogo.Size = new System.Drawing.Size(133, 120);
            this.PicBoxCompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxCompanyLogo.TabIndex = 8;
            this.PicBoxCompanyLogo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(8, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "PAN/VAT No.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RichPanVatNo);
            this.groupBox2.Controls.Add(this.RichRegistrationDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.RichRegistrationNo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.groupBox2.Location = new System.Drawing.Point(174, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 145);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Company ID";
            // 
            // RichPanVatNo
            // 
            this.RichPanVatNo.Enabled = false;
            this.RichPanVatNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichPanVatNo.Location = new System.Drawing.Point(142, 98);
            this.RichPanVatNo.Name = "RichPanVatNo";
            this.RichPanVatNo.Size = new System.Drawing.Size(200, 35);
            this.RichPanVatNo.TabIndex = 7;
            this.RichPanVatNo.Text = "";
            // 
            // RichRegistrationDate
            // 
            this.RichRegistrationDate.Enabled = false;
            this.RichRegistrationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichRegistrationDate.Location = new System.Drawing.Point(142, 58);
            this.RichRegistrationDate.Name = "RichRegistrationDate";
            this.RichRegistrationDate.Size = new System.Drawing.Size(200, 35);
            this.RichRegistrationDate.TabIndex = 6;
            this.RichRegistrationDate.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(7, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Registration Date";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnClearAll);
            this.groupBox3.Controls.Add(this.BtnUpdate);
            this.groupBox3.Controls.Add(this.BtnEdit);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(539, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(130, 145);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // BtnClearAll
            // 
            this.BtnClearAll.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnClearAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnClearAll.BackgroundImage")));
            this.BtnClearAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnClearAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClearAll.Enabled = false;
            this.BtnClearAll.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnClearAll.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearAll.ForeColor = System.Drawing.Color.White;
            this.BtnClearAll.Location = new System.Drawing.Point(9, 91);
            this.BtnClearAll.Name = "BtnClearAll";
            this.BtnClearAll.Size = new System.Drawing.Size(110, 35);
            this.BtnClearAll.TabIndex = 3;
            this.BtnClearAll.Text = "Clear All";
            this.BtnClearAll.UseVisualStyleBackColor = false;
            this.BtnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnUpdate.BackgroundImage")));
            this.BtnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdate.Enabled = false;
            this.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BtnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnUpdate.Location = new System.Drawing.Point(9, 54);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(110, 35);
            this.BtnUpdate.TabIndex = 2;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(63, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Company Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(66, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Contact No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(66, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(66, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Email ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(66, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Website";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(66, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "FaceBook Page";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RichShortName);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.RichFacebookPage);
            this.groupBox4.Controls.Add(this.RichWebsite);
            this.groupBox4.Controls.Add(this.RichEmailId);
            this.groupBox4.Controls.Add(this.RichContactNo);
            this.groupBox4.Controls.Add(this.RichAddress);
            this.groupBox4.Controls.Add(this.RichCompanyType);
            this.groupBox4.Controls.Add(this.RichCompanyName);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.groupBox4.Location = new System.Drawing.Point(16, 225);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(653, 310);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Company Info";
            // 
            // RichShortName
            // 
            this.RichShortName.Enabled = false;
            this.RichShortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichShortName.Location = new System.Drawing.Point(473, 143);
            this.RichShortName.Name = "RichShortName";
            this.RichShortName.Size = new System.Drawing.Size(116, 35);
            this.RichShortName.TabIndex = 22;
            this.RichShortName.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(379, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 18);
            this.label11.TabIndex = 21;
            this.label11.Text = "Short Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(63, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Company Type";
            // 
            // RichFacebookPage
            // 
            this.RichFacebookPage.Enabled = false;
            this.RichFacebookPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichFacebookPage.Location = new System.Drawing.Point(189, 264);
            this.RichFacebookPage.Name = "RichFacebookPage";
            this.RichFacebookPage.Size = new System.Drawing.Size(400, 35);
            this.RichFacebookPage.TabIndex = 19;
            this.RichFacebookPage.Text = "";
            // 
            // RichWebsite
            // 
            this.RichWebsite.Enabled = false;
            this.RichWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichWebsite.Location = new System.Drawing.Point(189, 224);
            this.RichWebsite.Name = "RichWebsite";
            this.RichWebsite.Size = new System.Drawing.Size(400, 35);
            this.RichWebsite.TabIndex = 18;
            this.RichWebsite.Text = "";
            // 
            // RichEmailId
            // 
            this.RichEmailId.Enabled = false;
            this.RichEmailId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichEmailId.Location = new System.Drawing.Point(189, 184);
            this.RichEmailId.Name = "RichEmailId";
            this.RichEmailId.Size = new System.Drawing.Size(400, 35);
            this.RichEmailId.TabIndex = 17;
            this.RichEmailId.Text = "";
            // 
            // RichContactNo
            // 
            this.RichContactNo.Enabled = false;
            this.RichContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichContactNo.Location = new System.Drawing.Point(189, 144);
            this.RichContactNo.Name = "RichContactNo";
            this.RichContactNo.Size = new System.Drawing.Size(180, 35);
            this.RichContactNo.TabIndex = 16;
            this.RichContactNo.Text = "";
            this.RichContactNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichContactNo_KeyPress);
            // 
            // RichAddress
            // 
            this.RichAddress.Enabled = false;
            this.RichAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichAddress.Location = new System.Drawing.Point(189, 103);
            this.RichAddress.Name = "RichAddress";
            this.RichAddress.Size = new System.Drawing.Size(400, 35);
            this.RichAddress.TabIndex = 15;
            this.RichAddress.Text = "";
            // 
            // RichCompanyType
            // 
            this.RichCompanyType.Enabled = false;
            this.RichCompanyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichCompanyType.Location = new System.Drawing.Point(189, 63);
            this.RichCompanyType.Name = "RichCompanyType";
            this.RichCompanyType.Size = new System.Drawing.Size(400, 35);
            this.RichCompanyType.TabIndex = 14;
            this.RichCompanyType.Text = "";
            // 
            // RichCompanyName
            // 
            this.RichCompanyName.Enabled = false;
            this.RichCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichCompanyName.Location = new System.Drawing.Point(189, 23);
            this.RichCompanyName.Name = "RichCompanyName";
            this.RichCompanyName.Size = new System.Drawing.Size(400, 35);
            this.RichCompanyName.TabIndex = 13;
            this.RichCompanyName.Text = "";
            // 
            // OpenCompanyLogoDialog
            // 
            this.OpenCompanyLogoDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenCompanyLogoDialog_FileOk);
            // 
            // BtnAddImage
            // 
            this.BtnAddImage.Enabled = false;
            this.BtnAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddImage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAddImage.Location = new System.Drawing.Point(27, 194);
            this.BtnAddImage.Name = "BtnAddImage";
            this.BtnAddImage.Size = new System.Drawing.Size(56, 25);
            this.BtnAddImage.TabIndex = 15;
            this.BtnAddImage.Text = "Add";
            this.BtnAddImage.UseVisualStyleBackColor = true;
            this.BtnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
            // 
            // BtnDeleteImage
            // 
            this.BtnDeleteImage.Enabled = false;
            this.BtnDeleteImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteImage.ForeColor = System.Drawing.Color.Red;
            this.BtnDeleteImage.Location = new System.Drawing.Point(94, 194);
            this.BtnDeleteImage.Name = "BtnDeleteImage";
            this.BtnDeleteImage.Size = new System.Drawing.Size(56, 25);
            this.BtnDeleteImage.TabIndex = 15;
            this.BtnDeleteImage.Text = "Delete";
            this.BtnDeleteImage.UseVisualStyleBackColor = true;
            this.BtnDeleteImage.Click += new System.EventHandler(this.BtnDeleteImage_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox5.BackgroundImage")));
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(-4, -1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(689, 40);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Cyan;
            this.label12.Location = new System.Drawing.Point(228, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(259, 29);
            this.label12.TabIndex = 0;
            this.label12.Text = "Company Information";
            // 
            // CompanyInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(684, 549);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.BtnAddImage);
            this.Controls.Add(this.BtnDeleteImage);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CompanyInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CompanyInfoForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxCompanyLogo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.RichTextBox RichRegistrationNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox RichPanVatNo;
        private System.Windows.Forms.RichTextBox RichRegistrationDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox RichFacebookPage;
        private System.Windows.Forms.RichTextBox RichWebsite;
        private System.Windows.Forms.RichTextBox RichEmailId;
        private System.Windows.Forms.RichTextBox RichContactNo;
        private System.Windows.Forms.RichTextBox RichAddress;
        private System.Windows.Forms.RichTextBox RichCompanyType;
        private System.Windows.Forms.RichTextBox RichCompanyName;
        private System.Windows.Forms.Button BtnClearAll;
        private System.Windows.Forms.PictureBox PicBoxCompanyLogo;
        private System.Windows.Forms.OpenFileDialog OpenCompanyLogoDialog;
        private System.Windows.Forms.Button BtnAddImage;
        private System.Windows.Forms.Button BtnDeleteImage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox RichShortName;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
    }
}