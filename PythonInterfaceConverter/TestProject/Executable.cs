using PythonInterfaceConverterLibrary;
using System.Collections.Generic;
using System.Reflection;

namespace TestProject
{
	public class Executable : IExecutable
	{
		public void types(string attribute_name, int attribute23, bool attribute4, double attribut2e, string val)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(attribute_name);
			parameters.Add(attribute23);
			parameters.Add(attribute4);
			parameters.Add(attribut2e);
			parameters.Add(val);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void download_page(string url)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void get_element_with_attribute(string attribute_name, string attribute_value)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(attribute_name);
			parameters.Add(attribute_value);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void something_else(string attribute_name, string attribute, string val)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(attribute_name);
			parameters.Add(attribute);
			parameters.Add(val);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
	}
}
