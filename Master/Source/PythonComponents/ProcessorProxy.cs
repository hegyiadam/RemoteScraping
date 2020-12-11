using ComponentInterfaces.Processor;
using System;

namespace PythonComponents
{
    public static class ProcessorProxy
    {
        public static void find_tag_by_css_selector(this IProcessor processor, String url, String css_selector)
        {
            processor.Client.find_tag_by_css_selector(url, css_selector);
        }
        public static void find_tag_by_css_selector2(this IProcessor processor, String url, String page_iteration_selector, String iteration_number, String css_selector)
        {
            processor.Client.find_tag_by_css_selector2(url, page_iteration_selector, iteration_number, css_selector);
        }
        public static void get_page_numbers(this IProcessor processor, String url, String page_iteration_selector)
        {
            processor.Client.get_page_numbers(url, page_iteration_selector);
        }
        public static void get_iteration_links(this IProcessor processor, String url, String iteration_selector)
        {
            processor.Client.get_iteration_links(url, iteration_selector);
        }
        public static void get_iteration_links2(this IProcessor processor, String url, String page_iteration_selector, String iteration_number, String iteration_selector)
        {
            processor.Client.get_iteration_links2(url, page_iteration_selector, iteration_number, iteration_selector);
        }
        public static void session_started(this IProcessor processor, String sessionId)
        {
            processor.Client.session_started(sessionId);
        }
        public static void session_finished(this IProcessor processor, String sessionId)
        {
            processor.Client.session_finished(sessionId);
        }
        public static void get_session_result(this IProcessor processor, String sessionId)
        {
            processor.Client.get_session_result(sessionId);
        }
    }
}