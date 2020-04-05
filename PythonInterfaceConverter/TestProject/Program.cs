using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IExecutable executable = new Executable();
            executable.download_page("Hello");
            executable.get_element_with_attribute("Hello","bello");
            executable.something_else("sdas", "dsada", "fsdfsdf");
            Console.ReadKey();
        }
    }
}
