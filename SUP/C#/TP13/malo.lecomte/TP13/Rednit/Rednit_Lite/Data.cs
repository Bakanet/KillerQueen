using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Newtonsoft.Json;
using Rednit_Lite.Properties;

namespace Rednit_Lite
{
    /// <summary>
    ///   The data needed for the execution of the client.
    /// </summary>
    public static class Data
	{
		#region Variables

	    /// <summary>
	    ///   The address of this client.
	    /// </summary>
	    private static string _address;

	    /// <summary>
	    ///   The port of this client.
	    /// </summary>
	    private static int _port;

	    /// <summary>
	    ///   The TcpClient connected to the server.
	    /// </summary>
	    private static TcpClient _client;

	    /// <summary>
	    ///   The Forms of this program.
	    /// </summary>
	    private static Dictionary<string, Form> _forms;

	    /// <summary>
	    ///   The next form to load.
	    /// </summary>
	    private static string _nextform;

	    /// <summary>
	    ///   The login of this client, when authenticated.
	    /// </summary>
	    private static string _login;

	    /// <summary>
	    ///   The login of a friend.
	    /// </summary>
	    private static string _friend;

	    /// <summary>
	    ///   The default profile to print when there is nothing else.
	    /// </summary>
	    private static UserData _default;

		#endregion

		#region Methods

	    /// <summary>
	    ///   Create the list of forms.
	    /// </summary>
	    private static void MakeFormsList()
		{
			_forms = new Dictionary<string, Form>
			{
				{"Connect", new FormConnect()},
				{"Match", new FormMatch()},
				{"Profile", new FormProfile()},
				{"Hack", new FormHack()},
				{"Friends", new FormList()},
				{"Chat", new FormChat()}
			};
		}

	    /// <summary>
	    ///   Initialize all data needed for the program.
	    ///   Connects the socket to the server.
	    ///   Imitialize the default profile.
	    /// </summary>
	    public static void Initialize()
		{
			var jsonFile = File.ReadAllText("config.json");
			dynamic json = JsonConvert.DeserializeObject(jsonFile);
			string addr = json.server.address;
			_address = addr;
			_port = json.server.port;
			_client = Network.ConnectSocket();
			MakeFormsList();
			_nextform = string.Empty;
			_login = string.Empty;
			_friend = string.Empty;

			byte[] pic;
			try
			{
				pic = ConvertImage.ImageToByteArray(Resources._default);
			}
			catch (Exception)
			{
				pic = null;
			}

			_default = new UserData
			{
				Login = "No more matches",
				Firstname = "Dolores",
				Lastname = "Abernathy",
				Age = 27,
				Description = "Doesnt look like anything to me.",
				Picture = pic,
				Books = true,
				AnimesSeries = true
			};
		}

		#endregion

		#region Getters / Setters

		public static string Address => _address;
		public static int Port => _port;
		public static TcpClient Client => _client;

		public static Dictionary<string, Form> Forms
		{
			get => _forms;
			set => _forms = value;
		}

		public static string NextForm
		{
			get => _nextform;
			set => _nextform = value;
		}

		public static string Login
		{
			get => _login;
			set => _login = value;
		}

		public static string Friend
		{
			get => _friend;
			set => _friend = value;
		}

		public static UserData Default => _default;

		#endregion
	}
}