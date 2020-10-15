﻿using Microsoft.Owin.Hosting;
using System;
using Microsoft.Owin;
using System.Threading;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;

namespace HubComponents
{
    public class HubHandler
    {
        private const string URL = "http://localhost:8080";

        public static void StartHub()
        {
            using (WebApp.Start(URL))
            {
                Console.WriteLine("HUB Server running on {0}", URL);
                Console.ReadLine();
            }
        }

    }
}
