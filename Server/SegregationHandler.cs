using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class SegregationHandler
    {
        public static SegregationHandler instance = new SegregationHandler();

        public void StartUserSegregationPardon(User usr, int banTime, int type)
        {
            new Timer(new Pardon(usr, banTime, type).PardonUpdate, null, 0, 1000 * 60);
        }

        class Pardon
        {
            private User user;
            private int banTime;
            private int pardonType = 0; // 0 - ban / 1 - mute

            public Pardon(User usr, int time, int type)
            {
                this.user = usr;
                this.banTime = time;
                this.pardonType = type;
            }

            public void PardonUpdate(object o)
            {
                if (banTime > 0)
                    banTime--;
                else
                {
                    Console.WriteLine(user.username + "'s " + (pardonType == 0 ? "ban" : "mute") + " has been lifted");
                    if(pardonType == 0)
                        Network.bannedUsers.Remove(user.username);
                    if (pardonType == 1)
                        user.isMuted = false;
                    ServerSendData.instance.SendNewMessage(0, user.username + "'s " + (pardonType == 0 ? "ban" : "mute") + " has been lifted");
                }
            }
        }

    }
}
