namespace TestProject
{
	public interface IExecutable
	{
		void download_page(string url);
		void get_element_with_attribute(string attribute_name, string attribute_value);
		void something_else(string attribute_name, string attribute, string val);
	}
}
