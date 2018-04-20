using System;
using System.Net;

namespace Client
{
	internal static class MainClass
	{
		public static void Main(string[] args)
		{
			if (args.Length != 2)
			{
				Console.WriteLine("{0}: Usage ip port", AppDomain.CurrentDomain.FriendlyName);
				return;
			}

			try
			{
				if (!IPAddress.TryParse(args[0], out var address))
					Console.Error.WriteLine("IP Address {0} invalid", args[0]);
				else if (!int.TryParse(args[1], out var port) || port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
					Console.Error.WriteLine("Port {0} invalid", args[1]);
				else
					new Client(address, port).Run();
			}
			catch (Exception e)
			{
				Console.Error.WriteLine(e.Message);
			}
		}
	}
}