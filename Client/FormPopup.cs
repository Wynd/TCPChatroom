using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class formPopup : Form
    {
        public formPopup()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void labelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Network.instance.CloseConnection();
            Application.Exit();          
        }


        private void formPopup_Load(object sender, EventArgs e)
        {
            //FormController.instance.SetErrorLabel(labelError);
        }

        public void ErrorPopup(string title, string msg)
        {
            labelTitleBar.Text = title;
            labelError.Visible = true;
            labelError.Text = msg;
        }

    }
}
