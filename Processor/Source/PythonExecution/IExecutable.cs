namespace PythonExecution
{
	public interface IExecutable
	{
		void find_tag_by_css_selector(string url, string css_selector);
		void find_tag_by_css_selector2(string url, string page_iteration_selector, string iteration_number, string css_selector);
		void find_tag_by_content(string url, string text);
		void find_tag_by_content2(string url, string page_iteration_selector, string iteration_number, string text);
		void count_texts_on_page(string url, string texts);
		void count_texts_on_page2(string url, string page_iteration_selector, string iteration_number, string texts);
		void page_contains_text(string url, string text);
		void page_contains_text2(string url, string page_iteration_selector, string iteration_number, string text);
		string get_page_numbers(string url, string page_iteration_selector);
		string get_iteration_links(string url, string iteration_selector);
		string get_iteration_links2(string url, string page_iteration_selector, string iteration_number, string iteration_selector);
	}
}