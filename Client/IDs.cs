using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class IDs
    {

        public const int
            SEND_MUTE_USER = 7,
            SEND_BAN_USER = 6,
            SEND_KICK_USER = 5,
            SEND_ONLINE_UPDATE_REQUEST = 4,
            SEND_CHAT_MESSAGE = 3,
            SEND_CONNECT_TO_CHATROOM = 2,
            SEND_NEW_ACCOUNT = 1;

        public const int
            HANDLE_MUTE_USER = 9,
            HANDLE_BAN_USER = 8,
            HANDLE_DEMOTE_USER = 7,
            HANDLE_PROMOTE_USER = 6,
            HANDLE_KICK_USER = 5,
            HANDLE_ONLINE_USERS = 4,
            HANDLE_NEW_MESSAGE = 3,
            HANDLE_SYNC_DATA = 2,
            HANDLE_USER_IN_CHATROOM = 1;
    }
}
