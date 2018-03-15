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
    public partial class formChat : Form
    {

        public formChat()
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


        private void formLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = labelTitleBar;
            FormController.instance.SetChatWindow(this);
            FormController.instance.SetChatWindow(listBoxActiveChat);
            FormController.instance.SetOnlineUsersWindow(listBoxOnline);
        }


        private void TimerUpdateActiveChat_Tick(object sender, EventArgs e)
        {
            if (FormController.instance.ShouldUpdateUserList())
            {
                ClientSendData.instance.SendOnlineUpdateRequest();
                FormController.instance.SetUpdateUserList(false);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(fieldInput.Text))
            {
                if (fieldInput.Text[0] == '/')
                {
                    ExecuteChatCommand(fieldInput.Text.ToLower());
                }
                else
                {
                    listBoxActiveChat.Items.Add("<" + User.instance.username + "> " + fieldInput.Text);
                    ClientSendData.instance.SendChatMessage(fieldInput.Text);                   
                }
                fieldInput.Text = string.Empty;
            }
        }

        private void fieldInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrWhiteSpace(fieldInput.Text))
            {
                if (fieldInput.Text[0] == '/')
                    ExecuteChatCommand(fieldInput.Text.ToLower());
                else
                    ClientSendData.instance.SendChatMessage(fieldInput.Text);

                fieldInput.Text = string.Empty;
            }
        }

        private void ExecuteChatCommand(string cmd)
        {
            string[] temp = cmd.Split(' ');
            string[] args = new string[temp.Length - 1];
            string commandName = temp[0];
            Array.ConstrainedCopy(temp, 1, args, 0, args.Length);

            if (commandName == "/help")
            {
                listBoxActiveChat.Items.Add("<SYSTEM> You can use the following commands : ");
                listBoxActiveChat.Items.Add("/pm [USER] [MESSAGE] - for private messages");
            }
            else if (commandName == "/pm")
            {
                if (args.Count() > 1)
                {
                    string userForPM = args.ElementAt(0);
                    string messageForPM = "";

                    for (int i = 1; i < args.Length; i++)
                    {
                        messageForPM += args[i] + " ";
                    }

                    listBoxActiveChat.Items.Add("[PM To] <" + userForPM + "> " + messageForPM);
                    ClientSendData.instance.SendChatPrivateMessage(userForPM, messageForPM);
                }
                else
                {
                    listBoxActiveChat.Items.Add("<SYSTEM> Wrong command format.");
                }
            }
            else if (commandName == "/kick")
            {
                if (args.Count() > 0)
                {
                    string userForKick = args.ElementAt(0);
                    string reasonForKick = "no reason";

                    if (args.Count() > 1)
                    {
                        reasonForKick = "";
                        for (int i = 1; i < args.Length; i++)
                        {
                            reasonForKick += args[i] + " ";
                        }
                    }

                    ClientSendData.instance.SendKickUser(User.instance.username, userForKick, reasonForKick);
                }
            }
            else if (commandName == "/ban")
            {
                if (args.Count() > 0)
                {
                    string userForBan = args.ElementAt(0);
                    string reasonForBan = "no reason";
                    int banTime = 60;

                    if (args.Count() > 1)
                    {

                        banTime = int.Parse(args[1]);

                        if (args.Count() > 2)
                        {
                            reasonForBan = "";
                            for (int i = 2; i < args.Length; i++)
                            {
                                reasonForBan += args[i] + " ";
                            }
                        }
                    }

                    ClientSendData.instance.SendBanUser(User.instance.username, userForBan, reasonForBan, banTime);
                }
            }
            else if (commandName == "/mute")
            {
                if (args.Count() > 0)
                {
                    string userForMute = args.ElementAt(0);
                    string reasonForMute = "no reason";
                    int muteTime = 60;

                    if (args.Count() > 1)
                    {

                        muteTime = int.Parse(args[1]);

                        if (args.Count() > 2)
                        {
                            reasonForMute = "";
                            for (int i = 2; i < args.Length; i++)
                            {
                                reasonForMute += args[i] + " ";
                            }
                        }
                    }

                    ClientSendData.instance.SendMuteUser(User.instance.username, userForMute, reasonForMute, muteTime);
                }
            }
        }

        public void ShowPopupMsg(string title, string msg)
        {
            var formPopup = new formPopup();
            formPopup.Show();
            formPopup.ErrorPopup(title, msg);
            this.Hide();
        }

 /*       private void fieldInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBoxActiveChat.Items.Add("<" + User.instance.username + "> " + fieldInput.Text);
                ClientSendData.instance.SendChatMessage(fieldInput.Text);
                fieldInput.Text = string.Empty;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }*/
    }
}
