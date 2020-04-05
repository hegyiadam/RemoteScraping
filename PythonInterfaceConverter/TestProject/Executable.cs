using PythonInterfaceConverterLibrary;
using System.Collections.Generic;
using System.Reflection;

namespace TestProject
{
	public class Executable : IExecutable
	{
		public void download_page(string url)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<string> parameters = new List<string>();
			parameters.Add(url);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void get_element_with_attribute(string attribute_name, string attribute_value)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<string> parameters = new List<string>();
			parameters.Add(attribute_name);
			parameters.Add( attribute_value);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void something_else(string attribute_name, string attribute, string val)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<string> parameters = new List<string>();
			parameters.Add(attribute_name);
			parameters.Add( attribute);
			parameters.Add( val);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
	}
}
