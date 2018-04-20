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
			throw  new NotImplementedException();
		}

		public void SendData()
		{
			throw  new NotImplementedException();
		}
	}
}