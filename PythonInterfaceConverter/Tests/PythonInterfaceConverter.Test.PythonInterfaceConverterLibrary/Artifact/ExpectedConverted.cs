using PythonInterfaceConverter.Source.PythonInterfaceConverterLibrary;
using System.Collections.Generic;
using System.Reflection;

namespace TestNamespace
{
    public class TestInterfaceName : ITestInterfaceName
    {
        public void TestMethod(string first_param, string second_para)
        {
            string methodName = MethodInfo.GetCurrentMethod().Name;
            List<object> parameters = new List<object>();
            parameters.Add(first_param);
            parameters.Add(second_para);
            ApiInvocation.RunCommandOnPython(methodName, parameters);
        }
        public void TestMethod2(string first_param, string second_para)
        {
            string methodName = MethodInfo.GetCurrentMethod().Name;
            List<object> parameters = new List<object>();
            parameters.Add(first_param);
            parameters.Add(second_para);
            ApiInvocation.RunCommandOnPython(methodName, parameters);
        }
    }
}