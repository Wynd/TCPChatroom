using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerHandleData
    {

        public static ServerHandleData instance = new ServerHandleData();

        public void HandleData(int index, byte[] data)
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
                case IDs.HANDLE_NEW_ACCOUNT:
                    HandleNewAccount(index, data);
                    break;
                case IDs.HANDLE_CONNECT_TO_CHAT:
                    HandleConnectToChatroom(index, data);
                    break;
                case IDs.HANDLE_CHAT_MESSAGE:
                    HandleChatMessage(index, data);
                    break;
                case IDs.HANDLE_ONLINE_UPDATE_REQUEST:
                    HandleOnlineUpdateRequest(index, data);
                    break;
                case IDs.HANDLE_KICK_USER:
                    HandleKickUser(index, data);
                    break;
                case IDs.HANDLE_BAN_USER:
                    HandleBanUser(index, data);
                    break;
                case IDs.HANDLE_MUTE_USER:
                    HandleMuteUser(index, data);
                    break;
            }
        }

        void HandleMuteUser(int index, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string sender = buffer.ReadString();
            string userForKick = buffer.ReadString();
            string reason = buffer.ReadString();
            int time = buffer.ReadInteger();

            foreach (KeyValuePair<int, User> u in Network.users)
                if (u.Value.username.ToLower() == sender.ToLower() && u.Value.isAdmin)
                    ServerSendData.instance.SendMuteUser(sender, userForKick, reason, time);

            buffer = null;
        }

        void HandleBanUser(int index, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string sender = buffer.ReadString();
            string userForKick = buffer.ReadString();
            string reason = buffer.ReadString();
            int time = buffer.ReadInteger();

            foreach (KeyValuePair<int, User> u in Network.users)
                if (u.Value.username.ToLower() == sender.ToLower() && u.Value.isAdmin)
                    ServerSendData.instance.SendBanUser(sender, userForKick, reason, time);

            buffer = null;
        }

        void HandleKickUser(int index, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string sender = buffer.ReadString();
            string userForKick = buffer.ReadString();
            string reason = buffer.ReadString();

            foreach(KeyValuePair<int, User> u in Network.users)
                if(u.Value.username.ToLower() == sender.ToLower() && u.Value.isAdmin)
                    ServerSendData.instance.SendKickUser(sender, userForKick, reason);

            buffer = null;
        }

        void HandleOnlineUpdateRequest(int index, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            if (Network.bannedUsers.Count > 0)
            {
                if (Network.bannedUsers.Contains(Network.users[index].username))
                    ServerSendData.instance.SendKickUser("ADMIN", Network.users[index].username, "This username is banned !");
                else
                {
                    if (Network.users.Count > 1)
                        ServerSendData.instance.SendOnlineUsers(index);
                }
            }
            else
            {
                if (Network.users.Count > 1)
                    ServerSendData.instance.SendOnlineUsers(index);
            }

            buffer = null;
        }

        void HandleChatMessage(int index, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string userForPM = buffer.ReadString();
            string msg = buffer.ReadString();

            ServerSendData.instance.SendNewMessage(index, msg, userForPM);       
            buffer = null;
        }

        void HandleConnectToChatroom(int index, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string username = buffer.ReadString();

            User u = new User();
            u.username = username;
            Network.users.Add(index, u);

            ServerSendData.instance.SendUserInChatroom(index, username);
            buffer = null;
        }

        void HandleNewAccount(int index, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packet = buffer.ReadInteger();

            string username = buffer.ReadString();
            string password = buffer.ReadString();

            buffer = null;

            if (Database.instance.AccountExists(username) == true)
            {
                return;
            }

            Database.instance.AddNewAccount(index, username, password);
            //ServerSendData.instance.SendUserInChatroom(index);
        }
    }
}
