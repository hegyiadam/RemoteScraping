using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService
{
    public class Program
    {
        static void Main()
        {
            WebApp.Start<RestApi>(AppConfigManager.Instance.ServerAddress);
            Console.WriteLine("REST Api is online!");
            HubComponents.HubHandler.StartHub();
            Console.WriteLine("Hub is online!");
            Console.ReadLine();
        }
    }
}
