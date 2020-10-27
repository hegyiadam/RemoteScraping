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
		public void find_tag_by_css_selector2(string url, string page_iteration_selector, string iteration_number, string css_selector)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(page_iteration_selector);
			parameters.Add(iteration_number);
			parameters.Add(css_selector);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void find_tag_by_content(string url, string text)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(text);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void find_tag_by_content2(string url, string page_iteration_selector, string iteration_number, string text)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(page_iteration_selector);
			parameters.Add(iteration_number);
			parameters.Add(text);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void count_texts_on_page(string url, string texts)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(texts);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void count_texts_on_page2(string url, string page_iteration_selector, string iteration_number, string texts)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(page_iteration_selector);
			parameters.Add(iteration_number);
			parameters.Add(texts);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void page_contains_text(string url, string text)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(text);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public void page_contains_text2(string url, string page_iteration_selector, string iteration_number, string text)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(page_iteration_selector);
			parameters.Add(iteration_number);
			parameters.Add(text);
			ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public string get_page_numbers(string url, string page_iteration_selector)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(page_iteration_selector);
			return ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public string get_iteration_links(string url, string iteration_selector)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(iteration_selector);
			return ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
		public string get_iteration_links2(string url, string page_iteration_selector, string iteration_number, string iteration_selector)
		{
			string methodName = MethodInfo.GetCurrentMethod().Name;
			List<object> parameters = new List<object>();
			parameters.Add(url);
			parameters.Add(page_iteration_selector);
			parameters.Add(iteration_number);
			parameters.Add(iteration_selector);
			return ApiInvocation.RunCommandOnPython(methodName, parameters);
		}
	}
}