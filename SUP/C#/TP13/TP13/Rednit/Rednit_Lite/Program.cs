using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Rednit_Lite
{
	/// <summary>
	///   The main class.
	/// </summary>
	internal static class Program
	{
		/// <summary>
		///   The function called at the start of the client.
		///   Initialize this client.
		///   Run the FormConnect.
		///   Catch and handle exceptions thrown by the two actions above.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			try
			{
				Data.Initialize();
				Application.Run(Data.Forms["Connect"]);
				if (Data.Client != null)
					Data.Client.Close();
			}
			catch (SocketException)
			{
				if (Data.Client != null)
					Data.Client.Close();
				MessageBox.Show(@"Wether the server is down. Wether you did something you shouldn't have. Bye.",
					@"The server is unreachable.", MessageBoxButtons.OK);
			}
			catch (Exception e)
			{
				if (Data.Client != null)
					Data.Client.Close();
				MessageBox.Show(e.Message, @"Error", MessageBoxButtons.OK);
			}
		}
	}
}