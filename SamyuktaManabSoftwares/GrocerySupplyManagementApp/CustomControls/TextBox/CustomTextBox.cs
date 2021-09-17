using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.CustomControls.TextBox
{
    [DefaultEvent("_TextChanged")]
    public partial class CustomTextBox : UserControl
    {
        // Fields
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;
        private int borderRadius = 0;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = string.Empty;
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;

        public CustomTextBox()
        {
            InitializeComponent();
        }

        // Events
        public event EventHandler _TextChanged;

        #region Properties
        [Category("Custom TextBox")]
        public Color BorderColor
        {
            get => borderColor; 
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Custom TextBox")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Custom TextBox")]
        public bool UnderlinedStyle
        {
            get => underlinedStyle;
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("Custom TextBox")]
        public bool PasswordChar
        {
            get
            {
                return isPasswordChar;
            }
            set 
            {
                isPasswordChar = value;
                textBox1.UseSystemPasswordChar = value;
            }
        }

        [Category("Custom TextBox")]
        public bool Multiline
        {
            get
            {
                return textBox1.Multiline;
            }
            set
            {
                textBox1.Multiline = value;
            }
        }

        [Category("Custom TextBox")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        [Category("Custom TextBox")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("Custom TextBox")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if(this.DesignMode)
                {
                    UpdateControlHeight();
                }
            }
        }

        [Category("Custom TextBox")]
        public string Texts
        {
            get
            {
                if(IsPlaceholder)
                {
                    return string.Empty;
                }
                else
                {
                    return textBox1.Text;
                }
            }
            set
            {
                textBox1.Text = value;
                SetPlaceHolder();
            }
        }

        [Category("Custom TextBox")]
        public Color BorderFocusColor
        {
            get
            {
                return borderFocusColor;
            }
            set
            {
                borderFocusColor = value;
            }
        }

        [Category("Custom TextBox")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if(value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate(); // Redraw Control
                }
            }
        }

        [Category("Custom TextBox")]
        public Color PlaceholderColor
        {
            get
            {
                return placeholderColor;
            }
            set
            {
                placeholderColor = value;
                if(isPlaceholder)
                {
                    textBox1.ForeColor = value;
                }
            }
        }

        [Category("Custom TextBox")]
        public string PlaceholderText
        {
            get
            {
                return placeholderText;
            }
            set
            {
                placeholderText = value;
                textBox1.Text = string.Empty;
                SetPlaceHolder();
            }
        }

        [Category("Custom TextBox")]
        public bool IsPlaceholder { get => isPlaceholder; set => isPlaceholder = value; }

        [Category("Custom TextBox")]
        public bool IsPasswordChar { get => isPasswordChar; set => isPasswordChar = value; }
        #endregion

        private void SetPlaceHolder()
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != string.Empty)
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                if(isPasswordChar)
                {
                    textBox1.UseSystemPasswordChar = false;
                }
            }
        }

        private void RemovePlaceHolder()
        {
            if (isPlaceholder && placeholderText != string.Empty)
            {
                isPlaceholder = false;
                textBox1.Text = string.Empty;
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar)
                {
                    textBox1.UseSystemPasswordChar = true;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;

            if(borderRadius > 1) 
            {
                //Rounded Textbox
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    // - Drawing
                    this.Region = new Region(pathBorderSmooth); // set the rounded region of UserControl
                    if (borderRadius > 15)
                    {
                        SetTextBoxRoundedRegion();
                    }

                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    penBorder.Alignment = PenAlignment.Center;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    if(underlinedStyle)
                    {
                        // Draw border smoothing
                        graphics.DrawPath(penBorderSmooth, pathBorderSmooth);
                        // Draw border
                        graphics.SmoothingMode = SmoothingMode.None;
                        graphics.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        // Draw border smoothing
                        graphics.DrawPath(penBorderSmooth, pathBorderSmooth);
                        // Draw border
                        graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else 
            {
                // Squared, Normal Textbox
                // Draw border
                using (Pen penBorder = new Pen(BorderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (isFocused)
                    {
                        penBorder.Color = borderFocusColor;
                    }

                    if (underlinedStyle)
                    {
                        // Line Style
                        graphics.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        // Normal Style
                        graphics.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }
                }
            }
        }

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if(Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize * 2);
                textBox1.Region = new Region(pathTxt);
            }
        }

        private GraphicsPath GetFigurePath(RectangleF rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.DesignMode)
            {
                UpdateControlHeight();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            if(textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(_TextChanged != null)
            {
                _TextChanged.Invoke(sender, e);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceHolder();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceHolder();
        }
    }
}
