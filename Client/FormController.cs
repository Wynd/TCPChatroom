using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class FormController
    {

        public static FormController instance = new FormController();

        private formChat chatForm;
        private ListBox activeChat;
        private ListBox onlineUsers;

        private Label errorLabel;

        private bool updateUsersList = false;

        public void KickProcedure(string title, string kickMsg)
        {
            if (chatForm != null)
            {
                chatForm.Invoke((MethodInvoker)delegate
                {
                    chatForm.ShowPopupMsg(title, kickMsg);
                });
            }
        }

        public void AddNewUserInList(string newUser)
        {
            if (onlineUsers != null)
            {
                onlineUsers.Invoke((MethodInvoker)delegate
                {
                    onlineUsers.Items.Add(newUser);
                });
            }
        }

        public void RemoveUserFromList(string user)
        {
            if (onlineUsers != null)
            {
                onlineUsers.Invoke((MethodInvoker)delegate
                {
                    onlineUsers.Items.Remove(user);
                });
            }
        }

        public void AddNewMessage(string sender, string msg)
        {
            if (activeChat != null)
            {
                activeChat.Invoke((MethodInvoker)delegate
                {
                    activeChat.Items.Add("<" + sender + "> " + msg);
                    activeChat.TopIndex = activeChat.Items.Count - 1;
                });
            }
        }

        public void AddNewPrivateMessage(string sender, string msg)
        {
            if (activeChat != null)
            {
                activeChat.Invoke((MethodInvoker)delegate
                {
                    activeChat.Items.Add("[PM From] <" + sender + "> " + msg);
                    activeChat.TopIndex = activeChat.Items.Count - 1;
                });
            }
        }

        public void SetUpdateUserList(bool val)
        {
            updateUsersList = val;
        }

        public bool ShouldUpdateUserList()
        {
            return updateUsersList;
        }


        public void SetChatWindow(formChat chatForm)
        {
            this.chatForm = chatForm;
        }

        public void SetErrorLabel(Label lbl)
        {
            errorLabel = lbl;
        }

        public void SetChatWindow(ListBox box)
        {
            activeChat = box;
        }

        public void SetOnlineUsersWindow(ListBox box)
        {
            onlineUsers = box;
        }
    }
}
