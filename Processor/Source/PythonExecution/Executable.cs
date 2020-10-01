using PythonInterfaceConverterLibrary;
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
		public void get_page_numbers(string url, string page_iteration_selector)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(page_iteration_selector);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void do_action_on_iteration(string url, string page_iteration_selector, string iteration_number, string action, string data)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(page_iteration_selector);
			parameters.Add(iteration_number);
			parameters.Add(action);
			parameters.Add(data);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void get_iteration_links(string url, string iteration_selector)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(iteration_selector);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
	}
}