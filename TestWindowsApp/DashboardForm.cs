using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsApp
{
    public partial class DashboardForm : Form
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            const int WM_NCPAINT = 0x85;
            if (m.Msg == WM_NCPAINT)
            {
                IntPtr hdc = GetWindowDC(m.HWnd);
                if ((int)hdc != 0)
                {
                    Graphics g = Graphics.FromHdc(hdc);
                    g.FillRectangle(Brushes.Green, new Rectangle(0, 0, 4800, 23));
                    g.Flush();
                    ReleaseDC(m.HWnd, hdc);
                }
            }
        }

        public DashboardForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            PanelMediaSubMenu.Visible = false;
            PanelReports.Visible = false;
            PanelSettings.Visible = false;
        }

        private void HideSubMenu()
        {
            if(PanelMediaSubMenu.Visible == true)
            {
                PanelMediaSubMenu.Visible = false;
            }

            if(PanelReports.Visible == true)
            {
                PanelReports.Visible = false;
            }

            if(PanelSettings.Visible == true)
            {
                PanelSettings.Visible = false;
            }
        }

        private void ShowSubMenu(Panel panel)
        {
            if(panel.Visible == false)
            {
                HideSubMenu();
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
        }

        private void BtnMedia_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelMediaSubMenu);
        }

        private void BtnMedia1_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnMedia2_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnMedia3_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnMedia4_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelReports);
        }

        private void BtnReports1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportsForm());
        }

        private void BtnReports2_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnReports3_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnReports4_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelSettings);
        }

        private void BtnSettings1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SettingsForm());
        }

        private void BtnSettings2_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnSettings3_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnSettings4_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private Form activeForm = null;

        private void OpenChildForm(Form childForm)
        {
            if(activeForm != null)
            {
                activeForm.Close(); ;
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelBody.Controls.Add(childForm);
            PanelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
