using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class HandleClient
    {
        TcpClient clientSocket = null;
        public Dictionary<TcpClient, string> clientList = null;

        public delegate void MessageDisplayHandler(string message, string userName);
        public event MessageDisplayHandler OnReceived;

        public delegate void DisconnectedHandler(TcpClient clientSocket);
        public event DisconnectedHandler OnDisconnected;


        public void startClient(TcpClient clientSocket, Dictionary<TcpClient, string> clientList)
        {
            this.clientSocket = clientSocket;
            this.clientList = clientList;

            Thread t = new Thread(doChat);
            t.IsBackground = true;
            t.Start();

        }

        private void doChat()
        {
            NetworkStream stream = null;
            try
            {
                byte[] buffer = new byte[1024];
                string msg = "";
                int bytes = 0;

                while (true)
                {
                    stream = clientSocket.GetStream();
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    msg = Encoding.Unicode.GetString(buffer, 0, bytes);
                    msg = msg.Substring(0, msg.IndexOf("$"));

                    if (OnReceived != null)
                        OnReceived(msg, clientList[clientSocket].ToString());
                    
                }

            }
            catch (SocketException ex)
            {
                if (clientSocket != null)
                    OnDisconnected(clientSocket);

                clientSocket.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                if (clientSocket != null)
                    OnDisconnected(clientSocket);

                clientSocket.Close();
                stream.Close();
            }
        }
        
    }
}
