using PythonInterfaceConverter.Source.PythonInterfaceConverterLibrary;
using System.Collections.Generic;
using System.Reflection;

namespace PythonExecution
{
	public class Executable : IExecutable
	{
		public void find_tag_by_css_selector(string url, string css_selector)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(css_selector);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
	}
}