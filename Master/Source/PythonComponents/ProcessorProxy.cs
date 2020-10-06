using ComponentInterfaces.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonComponents
{
    public static class ProcessorProxy
    {
        public static void find_tag_by_css_selector(this IProcessor processor, String url,String css_selector)
{
processor.Client.find_tag_by_css_selector(url,css_selector);
}
public static void find_tag_by_css_selector2(this IProcessor processor, String url,String iteration_number,String css_selector)
{
processor.Client.find_tag_by_css_selector2(url,iteration_number,css_selector);
}
public static System.Object get_page_numbers(this IProcessor processor, String url,String page_iteration_selector)
{
return processor.Client.get_page_numbers(url,page_iteration_selector);
}
public static void do_action_on_iteration(this IProcessor processor, String url,String page_iteration_selector,String iteration_number,String action,String data)
{
processor.Client.do_action_on_iteration(url,page_iteration_selector,iteration_number,action,data);
}
public static System.Object get_iteration_links(this IProcessor processor, String url,String iteration_selector)
{
return processor.Client.get_iteration_links(url,iteration_selector);
}
public static System.Object get_iteration_links2(this IProcessor processor, String url,String iteration_number,String iteration_selector)
{
return processor.Client.get_iteration_links2(url,iteration_number,iteration_selector);
}
    }
}