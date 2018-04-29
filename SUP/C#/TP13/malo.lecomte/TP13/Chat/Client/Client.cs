using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
	public class Client
	{
		private readonly Socket _sock;

		public void Run()
		{
			new Thread(() =>
			{
				while (true) ReceiveData();
			}) {IsBackground = true}.Start();

			while (true) SendData();
		}

		public Client(IPAddress address, int port)
		{
            _sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _sock.Connect(address, port);
		}

		public void ReceiveData()
		{
            byte[] buffer = new byte[1024];
            int number = _sock.Receive(buffer, SocketFlags.None);

            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, number));
        }

		public void SendData()
		{
            string str = Console.ReadLine();
            byte[] buffer = Encoding.ASCII.GetBytes(str);

            _sock.Send(buffer, str.Length, SocketFlags.None);
		}
	}
}