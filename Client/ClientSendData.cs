using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ClientSendData
    {

        public static ClientSendData instance = new ClientSendData();

        public void SendDataToServer(byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            Network.instance.networkStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);
            buffer = null;
        }


        public void SendMuteUser(string sender, string username, string reason, int time)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_MUTE_USER);

            buffer.WriteString(sender);
            buffer.WriteString(username);
            buffer.WriteString(reason);
            buffer.WriteInteger(time);
            SendDataToServer(buffer.ToArray());

            buffer = null;
        }

        public void SendBanUser(string sender, string username, string reason, int time)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_BAN_USER);

            buffer.WriteString(sender);
            buffer.WriteString(username);
            buffer.WriteString(reason);
            buffer.WriteInteger(time);
            SendDataToServer(buffer.ToArray());

            buffer = null;
        }

        public void SendKickUser(string sender, string username, string reason)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_KICK_USER);

            buffer.WriteString(sender);
            buffer.WriteString(username);
            buffer.WriteString(reason);
            SendDataToServer(buffer.ToArray());

            buffer = null;
        }

        public void SendOnlineUpdateRequest()
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_ONLINE_UPDATE_REQUEST);
            SendDataToServer(buffer.ToArray());
            buffer = null;
        }

        public void SendChatMessage(string msg)
        {
            SendChatPrivateMessage("", msg);
        }

        public void SendChatPrivateMessage(string toUser, string msg)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_CHAT_MESSAGE);

            buffer.WriteString(toUser);
            buffer.WriteString(msg);

            SendDataToServer(buffer.ToArray());
            buffer = null;
        }

        public void SendConnectToChatroom(string username)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_CONNECT_TO_CHATROOM);

            buffer.WriteString(username);

            SendDataToServer(buffer.ToArray());
            buffer = null;
        }

        public void SendNewAccount(string username, string password)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_NEW_ACCOUNT);

            buffer.WriteString(username);
            buffer.WriteString(password);

            SendDataToServer(buffer.ToArray());
            buffer = null;
        }

    }
}
