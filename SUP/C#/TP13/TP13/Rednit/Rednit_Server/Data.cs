using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Npgsql;

namespace Rednit_Server
{
	public static class Data
	{
		#region Methods
		/// <summary>
		/// Initialize variables from JSON file 'config.json'.
		/// </summary>
		public static void InitializeData()
		{
			string jsonFile = File.ReadAllText("config.json");
			dynamic json = JsonConvert.DeserializeObject(jsonFile);
			string addr = json.server.address;
			IPAddress address = IPAddress.Parse(addr);
			int port = json.server.port;
			string dbHost = json.database.host;
			int dbPort = json.database.port;
			string database = json.database.database;
			string dbUserName = json.database.username;
			string dbPassword = json.database.password;
            Socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Socket.Bind(new IPEndPoint(address, port));
			Socket.Blocking = true;
            Clients = new List<ClientData>();
			Tasks = new BlockingCollection<ClientData>();
			ConnectDatabase(dbHost, dbPort, database, dbUserName, dbPassword);
		}

		/// <summary>
		/// Create the connection to database.
		/// </summary>
		private static void ConnectDatabase(string dbHost, int dbPort, string database, string dbUserName, string dbPassword)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("Host={0}; ", dbHost);
			sb.AppendFormat("Port={0}; ", dbPort);
			sb.AppendFormat("Database={0}; ", database);
			sb.AppendFormat("Username={0}; ", dbUserName);
			sb.AppendFormat("Password={0}", dbPassword);
			DbConnection = new NpgsqlConnection(sb.ToString());
		}
		#endregion
		
		#region Getters
		public static NpgsqlConnection DbConnection { get; private set; }
		public static Socket Socket { get; private set; }
		public static List<ClientData> Clients { get; private set; }
		public static BlockingCollection<ClientData> Tasks { get; private set; }
		#endregion
	}
}