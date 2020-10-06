using PythonInterfaceConverterLibrary;
using System.Collections.Generic;
using System.Reflection;

namespace PythonInterfaceConverter.Example.TestProject
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
		public string download_page2(string url)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			return ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
	}
}