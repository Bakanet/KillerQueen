using System.Net.Sockets;

namespace Rednit_Server
{
	public class ClientData
	{
		/// <summary>
		/// The socket linked to the client.
		/// </summary>
		public TcpClient Client { get; }
		/// <summary>
		/// The login of the client if connected.
		/// </summary>
		public string Login { get; set; }
		/// <summary>
		/// Check if it is already being handled.
		/// </summary>
		public bool IsQueued { get; set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="client">The socket.</param>
		/// <param name="login">The login.</param>
		public ClientData(TcpClient client, string login)
		{
			Client = client;
			Login = login;
			IsQueued = false;
		}

		/// <summary>
		/// Check wether the instance is currently available or not.
		/// </summary>
		/// <returns></returns>
		public bool Available()
		{
			if (IsQueued)
				return false;
			return Client.Available > 0;
		}
	}
}