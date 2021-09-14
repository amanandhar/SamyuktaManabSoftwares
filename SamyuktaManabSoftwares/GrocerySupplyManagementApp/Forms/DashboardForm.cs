using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
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


        private Form activeForm = null;

        public DashboardForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            PanelReportsSubMenu.Visible = false;
            PanelSettingsSubMenu.Visible = false;
        }

        private void HideSubMenu()
        {
            if (PanelReportsSubMenu.Visible == true)
            {
                PanelReportsSubMenu.Visible = false;
            }

            if (PanelSettingsSubMenu.Visible == true)
            {
                PanelSettingsSubMenu.Visible = false;
            }
        }

        private void ShowSubMenu(Panel panel)
        {
            if (panel.Visible == false)
            {
                HideSubMenu();
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
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

        private void BtnReports_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelReportsSubMenu);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelSettingsSubMenu);
        }

        #region Timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            RichBoxTime.Text = "Time: " + DateTime.Now.ToString("hh:mm:ss");
            RichBoxTime.SelectionAlignment = HorizontalAlignment.Center;
        }

        #endregion
    }
}
