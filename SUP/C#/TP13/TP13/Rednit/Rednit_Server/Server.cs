using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace Rednit_Server
{
	public static class Server
	{
		/// <summary>
		/// Start the server.
		/// Initialize the Data class.
		/// Connect to the databse.
		/// Start listening.
		/// </summary>
		public static void Initialize()
		{
			try {
				Data.InitializeData();
				Data.DbConnection.Open();
				Data.Socket.Listen(10);
			}
			catch (Exception e)
			{
				Console.WriteLine("[ERROR] Could not start the server.");
				Console.WriteLine(e);
				throw;
			}
		}

		/// <summary>
		/// Start accepting clients and handling their requests.
		/// </summary>
		public static void Start()
		{
			Console.WriteLine("[INFO] Server started.");
            Thread acceptTh = new Thread(AcceptClients) { IsBackground = true };
			Thread tasksTh = new Thread(HandleTasks) { IsBackground = true };
            try {
				acceptTh.Start();
	            tasksTh.Start();
                PollClients();
            }
			catch (Exception e)
			{
				Console.WriteLine("[ERROR] Unhandled exception during execution of the server:");
				Console.WriteLine(e);
				throw;
			}
		}

		/// <summary>
		/// Accept client in loop.
		/// Add the new client to the list.
		/// </summary>
        private static void AcceptClients()
        {
            while (true)
            {
                try
                {
                    Socket clisock = Data.Socket.Accept();
                    TcpClient client = new TcpClient
                    {
                        Client = clisock
                    };
                    Data.Clients.Add(new ClientData(client, string.Empty));
                }
                catch (Exception)
                {
                    break;
                }
            }
        }
		
		/// <summary>
		/// Loop on all clients and check if they have a new request.
		/// If, so it is sent to the Tasks queue.
		/// </summary>
        private static void PollClients()
        {
            while (true)
            {
                int i = 0;
                while (i < Data.Clients.Count)
                {
                    try
                    {
	                    var client = Data.Clients[i];
	                    if (client == null || !client.Client.Connected)
		                    Data.Clients.Remove(client);
	                    else if (client.Available())
	                    {
		                    client.IsQueued = true;
		                    Data.Tasks.Add(client);
	                    }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    i++;
                }
            }
	        // ReSharper disable once FunctionNeverReturns
        }

		/// <summary>
		/// It will take every task and execute HandleRequest on them.
		/// </summary>
		private static void HandleTasks()
		{
			while (true)
			{
				if (!Data.Tasks.TryTake(out var client, -1))
					continue;
				try
				{
					Thread requestTh = new Thread(() => HandleRequests(client)) { IsBackground = true};
					requestTh.Start();
				}
				catch (Exception e)
				{
					client.IsQueued = false;
					Console.WriteLine(e.Message);
					throw;
				}
			}
		}

		/// <summary>
		/// Handle client depending on the type of the request.
		/// </summary>
		/// <param name="client">The client to handle.</param>
        private static void HandleRequests(ClientData client)
        {
            Protocol msg = ReceiveMessage(client.Client);
            Protocol resp;
            string user = string.IsNullOrEmpty(client.Login) ? "Unkwown" : client.Login;
            switch (msg.Type)
            {
                case MessageType.Connect:
                    Console.WriteLine($"[INFO][Connection] request from {user}");
                    resp = Request.Connection(msg, client);
                    break;
                case MessageType.Create:
                    Console.WriteLine($"[INFO][Creation] request from {user}");
                    resp = Request.Creation(msg);
                    break;
                case MessageType.RequestData:
                    Console.WriteLine($"[INFO][RequestData] request from {user}");
                    resp = Request.GetData(msg);
                    break;
                case MessageType.SendData:
                    Console.WriteLine($"[INFO][SendData] request from {user}");
                    resp = Request.SendData(msg);
                    break;
                case MessageType.RequestMatch:
                    Console.WriteLine($"[INFO][RequestMatch] request from {user}");
                    resp = Request.AskMatch(msg);
                    break;
	            case MessageType.Like:
		            Console.WriteLine($"[INFO][Like] request from {user}");
		            resp = Request.ApplyLike(msg, client);
		            break;
	            case MessageType.Dislike:
		            Console.WriteLine($"[INFO][Dislike] request from {user}");
		            resp = Request.ApplyDislike(msg, client);
		            Request.GetFriends(new Protocol(MessageType.RequestFriends) {Login = client.Login}, client);
		            break;
		        case MessageType.RequestFriends:
			        Console.WriteLine($"[INFO][GetFriends] request from {user}");
			        resp = Request.GetFriends(msg, client);
			        break;
                case MessageType.MessageTo:
                    Console.WriteLine($"[INFO][MessageTo] request from {user}");
                    resp = Request.MessageTo(msg, client);
                    break;
                case MessageType.MessageFrom:
                    Console.WriteLine($"[INFO][MessageFrom] request from {user}");
                    resp = Request.MessageFrom(msg, client);
                    break;
                case MessageType.Error: case MessageType.Response:
                    resp = new Protocol(MessageType.Error)
                    { Message = "You are fucking hilarious." };
                    break;
	            default:
                    resp = new Protocol(MessageType.Error)
                    { Message = "You did something you shouldn't have, but I don't know what." };
                    break;
            }
            SendMessage(client.Client, resp);

	        client.IsQueued = false;
        }

		/// <summary>
		/// Receive a message, the same way as the client.
		/// </summary>
		/// <param name="client"></param>
		/// <returns></returns>
        private static Protocol ReceiveMessage(TcpClient client)
        {
            var message = new List<byte>();
            NetworkStream stream = client.GetStream();

			#pragma warning disable CS0652
            while (stream.DataAvailable)
                message.Add((byte)stream.ReadByte());
			#pragma warning restore CS0652

            return Formatter.FromByteArray<Protocol>(message.ToArray());
        }

		/// <summary>
		/// Send message.
		/// </summary>
		/// <param name="client"></param>
		/// <param name="msg"></param>
        private static void SendMessage(TcpClient client, Protocol msg)
        {
            client.Client.Send(Formatter.ToByteArray(msg));
        }
	}
}