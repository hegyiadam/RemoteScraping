namespace PythonComponents.ClientInterface
{
	public interface IExecutable
	{
		void find_tag_by_css_selector(string url, string css_selector);
		void find_tag_by_css_selector2(string url,string iteration_number, string css_selector);
		object get_page_numbers(string url, string page_iteration_selector);
		void do_action_on_iteration(string url, string page_iteration_selector, string iteration_number, string action, string data);
		object get_iteration_links(string url,  string iteration_selector);
		object get_iteration_links2(string url, string iteration_number, string iteration_selector);
	}
}
