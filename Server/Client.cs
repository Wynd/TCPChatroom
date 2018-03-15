using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        public int index;
        public string ipAddress;
        public TcpClient socket;
        public NetworkStream networkStream;
        private byte[] readBuffer;

        public void Start()
        {
            socket.SendBufferSize = 4096;
            socket.ReceiveBufferSize = 4096;
            networkStream = socket.GetStream();
            Array.Resize(ref readBuffer, socket.ReceiveBufferSize);
            networkStream.BeginRead(readBuffer, 0, socket.ReceiveBufferSize, OnReceiveData, null);
        }

        void CloseConnection()
        {
            socket.Close();
            socket = null;
        }

        void OnReceiveData(IAsyncResult result)
        {
            try
            {
                int readBytes = networkStream.EndRead(result);
                if (socket == null) return;
                if (readBytes <= 0)
                {
                    CloseConnection();
                    return;
                }

                byte[] newBytes = null;
                Array.Resize(ref newBytes, readBytes);
                Buffer.BlockCopy(readBuffer, 0, newBytes, 0, readBytes);

                ServerHandleData.instance.HandleData(index, newBytes);

                if (socket == null) return;

                networkStream.BeginRead(readBuffer, 0, socket.ReceiveBufferSize, OnReceiveData, null);
            }
            catch (Exception ex)
            {
                CloseConnection();
                return;
            }
        }
    }
}
