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
    public partial class formLogin : Form
    {
        public formLogin()
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
            Application.Exit();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = labelTitleBar;
            fieldLogin.Text = "Username";
            //fieldPassword.Text = "Password (optional)";
            //fieldPassword.PasswordChar = '\0';
            fieldIpToConnect.Text = "IP To Connect";
        }


/*        private void fieldPassword_Enter(object sender, EventArgs e)
        {
            fieldPassword.BackColor = Color.FromArgb(126, 126, 154);
            if (fieldPassword.Text == "Password (optional)")
            {
                fieldPassword.Text = "";
                fieldPassword.PasswordChar = '◈';
            }
        }

        private void fieldPassword_Leave(object sender, EventArgs e)
        {
            if (fieldPassword.Text == "")
            {
                fieldPassword.Text = "Password (optional)";
                fieldPassword.PasswordChar = '\0';
            }
        }*/

        private void fieldLogin_Enter(object sender, EventArgs e)
        {
            fieldLogin.BackColor = Color.FromArgb(126, 126, 154);
            if (fieldLogin.Text == "Username")
            {
                fieldLogin.Text = "";                
            }
        }

        private void fieldLogin_Leave(object sender, EventArgs e)
        {
            if (fieldLogin.Text == "")
            {
                fieldLogin.Text = "Username";
            }
        }

        private void fieldIPToConnect_Enter(object sender, EventArgs e)
        {
            fieldIpToConnect.BackColor = Color.FromArgb(126, 126, 154);
            if (fieldIpToConnect.Text == "IP To Connect")
            {
                fieldIpToConnect.Text = "";
            }
        }

        private void fieldIPToConnect_Leave(object sender, EventArgs e)
        {
            if (fieldIpToConnect.Text == "")
            {
                fieldIpToConnect.Text = "IP To Connect";
            }
        }


        private void buttonConnect_Click(object sender, EventArgs e)
        {
            IPAddress address = null;

            bool loginFlag = string.IsNullOrWhiteSpace(fieldLogin.Text) || fieldLogin.Text == "Username";
            bool ipConnFlag = string.IsNullOrEmpty(fieldIpToConnect.Text) || !IPAddress.TryParse(fieldIpToConnect.Text, out address);

            if (loginFlag)
            {
                fieldLogin.BackColor = Color.Red;
                fieldLogin.Text = "";
            }
            if (ipConnFlag)
            {
                fieldIpToConnect.BackColor = Color.Red;
                fieldIpToConnect.Text = "";
            }

            if (!loginFlag && !ipConnFlag && address != null)
            {
                Network.instance.ConnectGameServer(fieldIpToConnect.Text);
                ClientSendData.instance.SendConnectToChatroom(fieldLogin.Text);
                ShowChatWindow();
            }
        }

        public void ShowChatWindow()
        {
            var formChat = new formChat();
            formChat.Show();
            this.Hide();
        }
    }
}
