using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class IDs
    {

        public const int
            SEND_MUTE_USER = 9,
            SEND_BAN_USER = 8,
            SEND_DEMOTE_USER = 7,
            SEND_PROMOTE_USER = 6,
            SEND_KICK_USER = 5,
            SEND_ONLINE_USERS = 4,
            SEND_NEW_MESSAGE = 3,
            SEND_SYNC_DATA = 2,
            SEND_USER_IN_CHATROOM = 1;

        public const int
            HANDLE_MUTE_USER = 7,
            HANDLE_BAN_USER = 6,
            HANDLE_KICK_USER = 5,
            HANDLE_ONLINE_UPDATE_REQUEST = 4,
            HANDLE_CHAT_MESSAGE = 3,
            HANDLE_CONNECT_TO_CHAT = 2,
            HANDLE_NEW_ACCOUNT = 1;

        public const int
            CHANNEL_DEFAULT = 0;
    }
}
