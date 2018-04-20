using System;
using System.Net;

namespace Server
{
    static class MainClass
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("{0}: Usage port", AppDomain.CurrentDomain.FriendlyName);
                return;
            }

            try
            {
                if (!int.TryParse(args[0], out var port) || port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
                    Console.Error.WriteLine("Port {0} is invalid", args[0]);
                else
                    new Server(port).Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
