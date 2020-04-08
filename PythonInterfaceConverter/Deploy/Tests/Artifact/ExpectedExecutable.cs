using PythonInterfaceConverterLibrary;
using System.Collections.Generic;
using System.Reflection;

namespace Test
{
    public class Executable : IExecutable
    {
        public void download_page(string url)
        {
            string methodName = MethodInfo.GetCurrentMethod().Name;
            List<object> parameters = new List<object>();
            parameters.Add(url);
            ApiInvocation.RunCommandOnPython(methodName, parameters);
        }
    }
}