using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonInterfaceConverter.Source.PythonInterfaceConverterLibrary
{
    public interface IApiInvocation
    {
        static void RunCommandOnPython(string methodName, List<object> parameters);
    }
}
