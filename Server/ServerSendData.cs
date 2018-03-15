using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerSendData
    {

        public static ServerSendData instance = new ServerSendData();

        public void SendDataToChatroom(int indexToIgnore, byte[] data)
        {
            foreach (KeyValuePair<int, User> pair in Network.users)
            {
                if (pair.Key != indexToIgnore)
                {
                    if (Network.clients[pair.Key].socket != null && Network.clients[pair.Key].socket.Connected)
                    {
                        ByteBuffer buffer = new ByteBuffer();
                        buffer.WriteBytes(data);
                        Network.clients[pair.Key].networkStream.BeginWrite(buffer.ToArray(), 0, buffer.ToArray().Length, null, null);
                        buffer = null;
                    }
                }
            }
        }

        public void SendDataTo(int clientIndex, byte[] data)
        {
            if (Network.clients[clientIndex].socket != null && Network.clients[clientIndex].socket.Connected)
            {
                ByteBuffer buffer = new ByteBuffer();
                buffer.WriteBytes(data);
                Network.clients[clientIndex].networkStream.BeginWrite(buffer.ToArray(), 0, buffer.ToArray().Length, null, null);
                buffer = null;
            }
        }


        public void SendMuteUser(string sender, string username, string reason, int time)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_MUTE_USER);

            buffer.WriteString(sender);
            buffer.WriteString(username);
            buffer.WriteString(reason);
            buffer.WriteInteger(time);

            int clientIndex = -1;

            foreach (KeyValuePair<int, User> u in Network.users)
            {
                if (u.Value.username.ToLower() == username.ToLower())
                {
                    Console.WriteLine("User " + username + " has been muted for " + time + " minutes; Reason: " + reason);
                    clientIndex = u.Key;
                    u.Value.isMuted = true;
                    SegregationHandler.instance.StartUserSegregationPardon(u.Value, time, 1);
                }
            }

            SendDataTo(clientIndex, buffer.ToArray());
            SendDataToChatroom(clientIndex, buffer.ToArray());
            buffer = null;
        }

        public void SendBanUser(string sender, string username, string reason, int banTime)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_BAN_USER);

            buffer.WriteString(sender);
            buffer.WriteString(username);
            buffer.WriteString(reason);
            buffer.WriteInteger(banTime);

            int clientIndex = -1;

            foreach (KeyValuePair<int, User> u in Network.users)
            {
                if (u.Value.username.ToLower() == username.ToLower())
                {
                    Console.WriteLine("User " + username + " has been banned for " + banTime + " minutes; Reason: " + reason);                  
                    clientIndex = u.Key;
                    Network.bannedUsers.Add(u.Value.username);
                    SegregationHandler.instance.StartUserSegregationPardon(u.Value, banTime, 0);
                }
            }

            SendDataTo(clientIndex, buffer.ToArray());
            SendDataToChatroom(clientIndex, buffer.ToArray());
            buffer = null;
        }

        public void SendDemotionUser(string username)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_DEMOTE_USER);

            buffer.WriteString(username);

            int clientIndex = -1;

            foreach (KeyValuePair<int, User> u in Network.users)
            {
                if (u.Value.username.ToLower() == username.ToLower())
                {
                    Console.WriteLine("User " + username + " has been demoted");
                    u.Value.isAdmin = false;
                    clientIndex = u.Key;
                }
            }

            SendDataTo(clientIndex, buffer.ToArray());
            SendDataToChatroom(clientIndex, buffer.ToArray());
            buffer = null;
        }

        public void SendPromoteUser(string username)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_PROMOTE_USER);

            buffer.WriteString(username);

            int clientIndex = -1;

            foreach (KeyValuePair<int, User> u in Network.users)
            {
                if (u.Value.username.ToLower() == username.ToLower())
                {
                    Console.WriteLine("User " + username + " has been promoted");
                    u.Value.isAdmin = true;
                    clientIndex = u.Key;
                }
            }

            SendDataTo(clientIndex, buffer.ToArray());
            SendDataToChatroom(clientIndex, buffer.ToArray());
            buffer = null;
        }

        public void SendKickUser(string sender, string username, string reason)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_KICK_USER);

            buffer.WriteString(sender);
            buffer.WriteString(username);
            buffer.WriteString(reason);

            int clientIndex = -1;

            foreach (KeyValuePair<int, User> pair in Network.users)
                if (pair.Value.username.ToLower() == username.ToLower())
                    clientIndex = pair.Key;

            SendDataTo(clientIndex, buffer.ToArray());
            SendDataToChatroom(clientIndex, buffer.ToArray());
            Network.users.Remove(clientIndex);
            buffer = null;
        }

        public void SendOnlineUsers(int clientIndex)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_ONLINE_USERS);

            buffer.WriteInteger(Network.users.Count - 1);
            foreach (KeyValuePair<int, User> pair in Network.users)
            {
                if (pair.Key != clientIndex)
                {
                    buffer.WriteString(pair.Value.username);
                }
            }

            SendDataTo(clientIndex, buffer.ToArray());
            buffer = null;
        }

        public void SendNewMessage(int clientIndex, string msg)
        {
            SendNewMessage(clientIndex, msg, "");
        }

        public void SendNewMessage(int clientIndex, string msg, string userForPM)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_NEW_MESSAGE);

            if (clientIndex != 0 && clientIndex > 1)
                buffer.WriteString(Network.users[clientIndex].username);
            else if (clientIndex == 0)
                buffer.WriteString("ADMIN");
            else if (clientIndex == 1)
                buffer.WriteString("SYSTEM");
            buffer.WriteString(ChatFilter(msg));

            bool isPM = false;
            bool isConnected = false;
            int clientIndexOfUser = -1;

            if (!string.IsNullOrWhiteSpace(userForPM))
            {
                foreach (KeyValuePair<int, User> pair in Network.users)
                {
                    if (pair.Value.username == userForPM)
                    {
                        if (Network.clients[pair.Key].socket != null && Network.clients[pair.Key].socket.Connected)
                        {
                            isConnected = true;
                            isPM = true;
                            clientIndexOfUser = pair.Key;
                        }
                        else
                            isConnected = false;
                    }
                }
            }

            buffer.WriteInteger(isPM == true ? 1 : 0);

            if (clientIndex > 0)
            {
                if (!Network.users[clientIndex].isMuted)
                {
                    if (!isPM && string.IsNullOrWhiteSpace(userForPM))
                    {
                        SendDataTo(clientIndex, buffer.ToArray());
                        SendDataToChatroom(clientIndex, buffer.ToArray());
                    }
                    else
                    {
                        if (isConnected)
                            SendDataTo(clientIndexOfUser, buffer.ToArray());
                        else
                        {
                            buffer.Clear();
                            buffer.WriteInteger(IDs.SEND_NEW_MESSAGE);

                            buffer.WriteString("SYSTEM");
                            buffer.WriteString(userForPM + " is not ONLINE !");
                            buffer.WriteInteger(0);

                            SendDataTo(clientIndex, buffer.ToArray());
                        }
                    }
                }
                else
                {
                    buffer.Clear();
                    buffer.WriteInteger(IDs.SEND_NEW_MESSAGE);

                    buffer.WriteString("SYSTEM");
                    buffer.WriteString("You cannot use the chat function at the moment !");
                    buffer.WriteInteger(0);

                    SendDataTo(clientIndex, buffer.ToArray());
                }
            }
            else if(clientIndex == 0)
            {
                SendDataToChatroom(clientIndex, buffer.ToArray());
            }
            buffer = null;
        }

        public void SendUserInChatroom(int clientIndex, string username)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_USER_IN_CHATROOM);

            buffer.WriteString(username);

            SendDataToChatroom(clientIndex, buffer.ToArray());           
            SendSyncData(clientIndex);
            buffer = null;
        }

        public void SendSyncData(int clientIndex)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger(IDs.SEND_SYNC_DATA);

            buffer.WriteString(Network.users[clientIndex].username);

            string usr = Network.users[clientIndex].username;

            /*if (Network.bannedUsers.Count > 0)
            {

                Console.WriteLine(Network.bannedUsers.ContainsValue(usr));

                if (Network.bannedUsers.ContainsValue(usr))
                {
                    Console.WriteLine(Network.bannedUsers.ContainsValue(usr) + " is banned");
                    //ServerSendData.instance.SendKickUser("ADMIN", usr, "This username is banned !");
                }
            }*/

            SendDataTo(clientIndex, buffer.ToArray());
            buffer = null;
        }

        private string[] bannedWords = new string[] { "fuck", "piss", "dick", "pussy", "asshole", "bitch"};

        private string ChatFilter(string text)
        {
            string[] words = text.Split();
            string filteredText = "";

            foreach(string w in words)
            {
                string newWord = w;
                if (bannedWords.Contains(w.ToLower()))
                {
                    newWord = CensoringGenerator(w);
                }
                filteredText += newWord + " ";
            }

            return filteredText;
        }

        private char[] censorChar = new char[] { '!', '@', '#', '$', '%', '^', '&', '*' };
        private Random rand = new Random();

        private string CensoringGenerator(string s)
        {
            string finalWord = "";

            for(int i = 0; i < s.Length; i++)
                finalWord += censorChar[rand.Next(0, censorChar.Length - 1)];
            
            return finalWord;
        }
    }
}
