using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MasterService
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApp.Start<RestApi>("http://localhost:3333/");
            Console.ReadLine(); // block main thread

        }
    }
}
