using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PythonInterfaceConverter.Example.TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IExecutable executable = new Executable();

            try
            {
                executable.download_page("Hello");
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
            }

            Console.ReadKey();
        }
    }
}
