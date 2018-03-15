using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Server
{
    class StartServer
    {
        private static Thread serverThread;
        private static bool isRunning;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            serverThread = new Thread(new ThreadStart(ConsoleThread));
            serverThread.Start();

            /*MySQL.instance.MySQLInit();*/
            Database.instance.CheckPath(Database.instance.PATH_ACCOUNT);
            Network.instance.StartListener();
        }

        private static void ConsoleThread()
        {
            string line;
            isRunning = true;

            while (isRunning)
            {
                line = Console.ReadLine();

                if (line.Equals("/stop"))
                {
                    isRunning = false;
                    return;
                }
                else if(line.Equals("/help"))
                {
                    Console.WriteLine("=============HELP==============");
                    Console.WriteLine("/online");
                    Console.WriteLine("/alert [TEXT]");
                    Console.WriteLine("/kick [USER] <REASON>");
                    Console.WriteLine("/ban [USER] <TIME> <REASON>");
                    Console.WriteLine("/mute [USER] <TIME> <REASON>");
                    Console.WriteLine("/promote [USER]");
                    Console.WriteLine("/demote [USER]");
                    Console.WriteLine("================================");
                }
                else if(line.Equals("/online"))
                {
                    int i = 0;
                    Console.WriteLine("============ONLINE USERS==============");
                    Console.WriteLine("ID           USERNAME");
                    foreach (KeyValuePair<int, User> usr in Network.users)
                    {
                        if(Network.clients[usr.Key].socket != null && Network.clients[usr.Key].socket.Connected)
                        {
                            i++;
                            Console.WriteLine(usr.Key.ToString("D6") + "         " + usr.Value.username);
                        }
                    }
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Online users : " + i);
                    Console.WriteLine("======================================");
                }

                string[] temp = line.Split(' ');
                string[] args = new string[temp.Length - 1];
                string commandName = temp[0];
                Array.ConstrainedCopy(temp, 1, args, 0, args.Length);

                if (commandName == "/alert")
                {
                    if (args.Count() > 0)
                    {
                        string messageForAlert = "";

                        for (int i = 0; i < args.Length; i++)
                        {
                            messageForAlert += args[i] + " ";
                        }

                        ServerSendData.instance.SendNewMessage(0, messageForAlert);
                    }
                }
                if (commandName == "/kick")
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

                        Console.WriteLine("User " + userForKick + " has been kicked; Reason : " + reasonForKick);
                        ServerSendData.instance.SendKickUser("ADMIN", userForKick, reasonForKick);
                    }
                }
                if(commandName == "/ban")
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

                        Console.WriteLine("User " + userForBan  + " has been kicked; Reason : " + reasonForBan);
                        ServerSendData.instance.SendBanUser("ADMIN", userForBan, reasonForBan, banTime);
                    }
                }
                if (commandName == "/mute")
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

                        Console.WriteLine("User " + userForMute + " has been kicked; Reason : " + reasonForMute);
                        ServerSendData.instance.SendMuteUser("ADMIN", userForMute, reasonForMute, muteTime);
                    }
                }
                if (commandName == "/promote")
                {
                    if(args.Count() > 0)
                    {
                        string userForPromotion = args.ElementAt(0);

                        ServerSendData.instance.SendPromoteUser(userForPromotion);
                    }
                }
                if(commandName == "/demote")
                {
                    if(args.Count() > 0)
                    {
                        string userForDemotion = args.ElementAt(0);

                        ServerSendData.instance.SendDemotionUser(userForDemotion);
                    }
                }
            }
        }
    }
}