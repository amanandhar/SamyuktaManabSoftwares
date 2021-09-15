using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace GrocerySupplyManagementApp.CustomControls.ComboBox
{
    [DefaultEvent("OnSelectedIndexChanged")]
    public class CustomComboBox : UserControl
    {
        // Fields
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 1;

        // Items
        private System.Windows.Forms.ComboBox cmbList;
        private Label lblText;
        private System.Windows.Forms.Button btnIcon;

        // Properties
        [Category("Custom ComboBox")]
        public new Color BackColor 
        { 
            get => backColor; 
            set { 
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            } 
        }

        [Category("Custom ComboBox")]
        public Color IconColor
        {
            get => iconColor; 
            set
            {
                iconColor = value;
                btnIcon.Invalidate(); // Redraw icon
            }
        }

        [Category("Custom ComboBox")]
        public Color ListBackColor
        {
            get => listBackColor; 
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }

        [Category("Custom ComboBox")]
        public Color ListTextColor
        {
            get => listTextColor;
            set
            {
                listTextColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }

        [Category("Custom ComboBox")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                base.BackColor = borderColor; // Border Color
            }
        }

        [Category("Custom ComboBox")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.Padding = new Padding(borderSize); // Border Size
            }
        }

        [Category("Custom ComboBox")]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                lblText.ForeColor = value;
            }
        }

        [Category("Custom ComboBox")]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                lblText.Font = value;
                cmbList.Font = value; // Optional
            }
        }

        [Category("Custom ComboBox")]
        public string Texts
        {
            get => lblText.Text;
            set
            {
                lblText.Text = value;
            }
        }

        [Category("Custom ComboBox")]
        public ComboBoxStyle DropDownStyle
        {
            get => cmbList.DropDownStyle;
            set
            {
                if(cmbList.DropDownStyle != ComboBoxStyle.Simple)
                {
                    cmbList.DropDownStyle = value;
                }
            }
        }

        // Events
        public event EventHandler OnSelectedIndexChanged; // Default event

        // Contructor
        public CustomComboBox()
        {
            cmbList = new System.Windows.Forms.ComboBox();
            lblText = new System.Windows.Forms.Label();
            btnIcon = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ComboBox: Dropdown list
            cmbList.BackColor = listBackColor;
            cmbList.Font = new Font(this.Font.Name, 10F);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged); // Default event
            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged); // Refresh text

            // Button: Icon 
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click); // Open dropdown list
            btnIcon.Paint += new PaintEventHandler(Icon_Paint); // Draw icon;

            // Label: Text
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(this.Font.Name, 10F);
            lblText.Click += new EventHandler(Surface_Click);

            // User Control
            this.Controls.Add(lblText); //2
            this.Controls.Add(btnIcon); //1
            this.Controls.Add(cmbList); //0
            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize); // Border Size
            base.BackColor = borderColor; // Border Color
            this.ResumeLayout();
            AdjustComboBoxDimensions();
        }

        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = lblText.Width;
            cmbList.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cmbList.Width,
                Y = lblText.Bottom - cmbList.Height
            };
        }

        // Event Methods
        // Default Event
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnSelectedIndexChanged != null)
            {
                OnSelectedIndexChanged.Invoke(sender, e);
            }

            // Refresh text
            lblText.Text = cmbList.Text;
        }


        private void Surface_Click(object sender, EventArgs e)
        {
            // Select combo box
            cmbList.Select();
            if(cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                cmbList.DroppedDown = true; // Open dropdown list
            }
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            // Fields
            int iconWidth = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidth) / 2, (btnIcon.Height - iconHeight) / 2, iconWidth, iconHeight);
            Graphics graphics = e.Graphics;

            // Draw arrow down icon
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                graphics.DrawPath(pen, path);
            }
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            // Open dropdown list
            cmbList.Select();
            cmbList.DroppedDown = true;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            // Refresh text
            lblText.Text = cmbList.Text;
        }
    }
}
