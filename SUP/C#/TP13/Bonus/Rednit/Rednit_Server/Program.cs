using System;
using System.Data;

namespace Rednit_Server
{
	internal static class Program
	{
		public static void Main()
		{
			try
			{
				Server.Initialize();
				Server.Start();
			}
			catch (Exception e)
			{
				if (Data.DbConnection != null && Data.DbConnection.State != ConnectionState.Closed)
					Data.DbConnection.Close();
				if (Data.Socket != null)
					Data.Socket.Close();
				Console.WriteLine(e.Message);
				Console.WriteLine("\nPress any key to continue ...");
				Console.ReadKey();
			}
			
			if (Data.DbConnection != null &&  Data.DbConnection.State != ConnectionState.Closed)
				Data.DbConnection.Close();
            if (Data.Socket != null)
                Data.Socket.Close();
        }
	}
}