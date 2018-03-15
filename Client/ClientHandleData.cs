using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ClientHandleData
    {

        public static ClientHandleData instance = new ClientHandleData();

        public void HandleData(byte[] data)
        {
            int packetnum;
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            packetnum = buffer.ReadInteger();
            buffer = null;
            if (packetnum == 0)
                return;

            switch (packetnum)
            {
                case IDs.HANDLE_USER_IN_CHATROOM:
                    HandleUserInChatroom(data);
                    break;
                case IDs.HANDLE_SYNC_DATA:
                    HandleSyncData(data);
                    break;
                case IDs.HANDLE_NEW_MESSAGE:
                    HandleNewMessage(data);
                    break;
                case IDs.HANDLE_ONLINE_USERS:
                    HandleOnlineUsers(data);
                    break;
                case IDs.HANDLE_KICK_USER:
                    HandleKickUser(data);
                    break;
                case IDs.HANDLE_PROMOTE_USER:
                    HandlePromoteUser(data);
                    break;
                case IDs.HANDLE_DEMOTE_USER:
                    HandleDemoteUser(data);
                    break;
                case IDs.HANDLE_BAN_USER:
                    HandleBanUser(data);
                    break;
                case IDs.HANDLE_MUTE_USER:
                    HandleMuteUser(data);
                    break;
            }
        }

        void HandleMuteUser(byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string sender = buffer.ReadString();
            string user = buffer.ReadString();
            string reason = buffer.ReadString();
            int time = buffer.ReadInteger();

            if (User.instance.username == user)
                FormController.instance.AddNewMessage(sender, "You've been muted for " + time + " minutes. Reason : " + reason);
            else
                FormController.instance.AddNewMessage(sender, "User " + user + " has been muted. Reason : " + reason);

            buffer = null;
        }

        void HandleBanUser(byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string sender = buffer.ReadString();
            string user = buffer.ReadString();
            string reason = buffer.ReadString();
            int time = buffer.ReadInteger();

            if (User.instance.username == user)
                FormController.instance.KickProcedure("Banned", "Banned by " + sender + " for " + time + " minutes. Reason : " + reason);
            else
                FormController.instance.AddNewMessage(sender, "User " + user + " has been banned. Reason : " + reason);

            buffer = null;
        }

        void HandleDemoteUser(byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string user = buffer.ReadString();

            if (User.instance.username == user)
                FormController.instance.AddNewMessage("ADMIN", "You've been demoted ! You can no longer use admin commands");
            else
                FormController.instance.AddNewMessage("ADMIN", "User " + user + " has been demoted");

            buffer = null;
        }
        
        void HandlePromoteUser(byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string user = buffer.ReadString();

            if (User.instance.username == user)
                FormController.instance.AddNewMessage("ADMIN", "You've been promoted ! You can now use admin commands");
            else
                FormController.instance.AddNewMessage("ADMIN", "User " + user + " has been promoted");

            buffer = null;
        }

        void HandleKickUser(byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string sender = buffer.ReadString();
            string user = buffer.ReadString();
            string reason = buffer.ReadString();

            FormController.instance.RemoveUserFromList(user);

            if (User.instance.username == user)
                FormController.instance.KickProcedure("Kicked", "Kick by " + sender + ".           Reason : " + reason);
            else
                FormController.instance.AddNewMessage(sender, "User " + user + " has been kicked. Reason : " + reason);       

            buffer = null;
        }

        void HandleOnlineUsers(byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            int users = buffer.ReadInteger();
            string[] usernames = new string[users];

            for (int i = 0; i < users; i++)
            {
                usernames[i] = buffer.ReadString();
                FormController.instance.AddNewUserInList(usernames[i]);
            }

            buffer = null;
        }

        void HandleNewMessage(byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string username = buffer.ReadString();
            string msg = buffer.ReadString();
            bool isPM = buffer.ReadInteger() == 1 ? true : false;

            if(isPM)
                FormController.instance.AddNewPrivateMessage(username, msg);
            else
                FormController.instance.AddNewMessage(username, msg);

            buffer = null;
        }

        void HandleUserInChatroom(byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string username = buffer.ReadString();

            FormController.instance.AddNewUserInList(username);
            FormController.instance.AddNewMessage("SYSTEM", username + " joined the server !");         

            buffer = null;
        }

        void HandleSyncData(byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string username = buffer.ReadString();

            buffer = null;

            User.instance.username = username;

            FormController.instance.SetUpdateUserList(true);

            FormController.instance.AddNewMessage("SYSTEM", "Welcome " + User.instance.username + " !");

            FormController.instance.AddNewUserInList(User.instance.username);          
        }
    }
}
