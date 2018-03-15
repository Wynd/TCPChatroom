using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Network
    {
        private int port = 11000;

        public TcpListener serverSocket;
        public static Network instance = new Network();
        public static Dictionary<int, Client> clients = new Dictionary<int, Client>();
        public static Dictionary<int, User> users = new Dictionary<int, User>();
        public static List<string> bannedUsers = new List<string>();
        public static List<string> mutedUsers = new List<string>();
        public static List<IPAddress> bannedIPs = new List<IPAddress>();

        public void StartListener()
        {
            serverSocket = new TcpListener(IPAddress.Any, port);
            serverSocket.Start();
            serverSocket.BeginAcceptTcpClient(OnClientConnect, null);
            Console.WriteLine("Server has successfully started.");
        }

        void OnClientConnect(IAsyncResult result)
        {
            TcpClient client = serverSocket.EndAcceptTcpClient(result);
            client.NoDelay = false;
            serverSocket.BeginAcceptTcpClient(OnClientConnect, null);

            int addrSplit = client.Client.RemoteEndPoint.ToString().IndexOf(':');
            string ipAddr = client.Client.RemoteEndPoint.ToString().Substring(0, addrSplit);
            string port = client.Client.RemoteEndPoint.ToString().Substring(addrSplit + 1);

            int clientIndex = BitConverter.ToInt32(IPAddress.Parse(ipAddr).GetAddressBytes(), 0) / int.Parse(port) + new Random().Next(1, 1000000);
            Client newClient = new Client();
            newClient.socket = client;
            newClient.index = clientIndex;
            newClient.ipAddress = client.Client.RemoteEndPoint.ToString();
            newClient.Start();
            if (!clients.ContainsKey(clientIndex))
                clients.Add(clientIndex, newClient);
            else
            {
                if (clients[clientIndex].socket != null)
                {
                    Console.WriteLine("Duplicate connection; " + clients[clientIndex].ipAddress + " terminated");
                    clients[clientIndex].socket.Close();
                    clients.Remove(clientIndex);
                    clients.Add(clientIndex, newClient);
                }
            }

            Console.WriteLine("Incoming Connection from " + newClient.ipAddress + "|| Index: " + clientIndex.ToString("D6"));
        }

    }
}
