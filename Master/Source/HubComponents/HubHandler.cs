using Microsoft.Owin.Hosting;
using System;
using Microsoft.Owin;
using System.Threading;

namespace HubComponents
{
    public class HubHandler
    {
        private const string URL = "http://localhost:8080";

        public static void StartHub()
        {
            using (WebApp.Start(URL))
            {
                Console.WriteLine("Server runing on {0}", URL);
                Console.ReadLine();
            }
        }
    }
}
