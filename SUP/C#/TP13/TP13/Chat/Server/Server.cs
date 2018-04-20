using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class Server
    {
        private readonly int _port;
        private readonly Socket _sock;
        private readonly List<Socket> _clients;

        public void Run()
        {
            try
            {
                Init();
                while (true)
                {
                    var client = Accept();
                    new Thread(() => HandleClient(client)) {IsBackground = true}.Start();
                    Console.WriteLine("[" + client.RemoteEndPoint + "] " + "Connected");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _sock.Close();
            }
        }

        public void HandleClient(Socket client)
        {
            try
            {
                while (true)
                {
                    ReceiveMessages(client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[" + client.RemoteEndPoint + "] " + e.Message);
                client.Close();
            }
        }

        public Server(int port)
        {
            throw  new NotImplementedException();
        }

        public void Init()
        {
            throw  new NotImplementedException();
        }

        public Socket Accept()
        {
            throw  new NotImplementedException();
        }

        public void ReceiveMessages(Socket client)
        {
            throw  new NotImplementedException();
        }

        public void SendMessage(string message, Socket sender)
        {
            throw  new NotImplementedException();
        }
    }
}

