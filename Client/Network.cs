using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Network
    {
        public static Network instance = new Network();

        public int serverPort = 11000;
        public bool isConnected;

        public TcpClient playerSocket;
        public NetworkStream networkStream;

        private byte[] asyncBuff;
        public bool shouldHandleData;
        private byte[] bytesToSend;

        public void ConnectGameServer(string serverIpAddress)
        {
            try
            {
                if (playerSocket != null)
                {
                    if (playerSocket.Connected || isConnected)
                        return;
                    playerSocket.Close();
                    playerSocket = null;
                }

                playerSocket = new TcpClient();
                playerSocket.ReceiveBufferSize = 4096;
                playerSocket.SendBufferSize = 4096;
                playerSocket.NoDelay = false;
                Array.Resize(ref asyncBuff, 8192);
                playerSocket.BeginConnect("127.0.0.1", serverPort, new AsyncCallback(ConnectCallback), playerSocket);
                isConnected = true;

                System.Threading.Timer updateTimer = new System.Threading.Timer(Network.instance.Update, null, 0, 100);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not connect to the server");
                Console.WriteLine(ex.StackTrace);
                return;
            }
        }

        public void CloseConnection()
        {
            playerSocket.Close();
            playerSocket = null;
        }

        void ConnectCallback(IAsyncResult result)
        {
            if (playerSocket != null)
            {
                playerSocket.EndConnect(result);
                if (playerSocket.Connected == false)
                {
                    isConnected = false;
                    return;
                }
                else
                {
                    playerSocket.NoDelay = true;
                    networkStream = playerSocket.GetStream();
                    networkStream.BeginRead(asyncBuff, 0, 8192, OnReceive, null);
                }
            }
        }

        public void Update(Object o)
        {
            if (shouldHandleData)
            {
                ClientHandleData.instance.HandleData(bytesToSend);
                shouldHandleData = false;
            }
        }

        void OnReceive(IAsyncResult result)
        {
            if (playerSocket != null)
            {
                if (playerSocket == null)
                    return;

                int byteArray = networkStream.EndRead(result);
                bytesToSend = null;
                Array.Resize(ref bytesToSend, byteArray);
                Buffer.BlockCopy(asyncBuff, 0, bytesToSend, 0, byteArray);

                if (byteArray == 0)
                {
                    playerSocket.Close();
                    return;
                }

                shouldHandleData = true;

                if (playerSocket == null)
                    return;

                networkStream.BeginRead(asyncBuff, 0, 8192, OnReceive, null);
            }
        }
    }
}
