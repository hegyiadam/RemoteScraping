using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace MasterService
{
    public class Program
    {
        private static void Main()
        {
            WebApp.Start<RestApi>(AppConfigManager.Instance.ServerAddress);
            Console.WriteLine("REST Api is online listening on " + AppConfigManager.Instance.ServerAddress);
            Thread thread = new Thread(() => HubComponents.HubHandler.StartHub());
            thread.Start();
            Console.ReadLine();
        }
    }
}