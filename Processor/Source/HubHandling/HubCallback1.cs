using System;
using Microsoft.AspNet.SignalR.Client;
using PythonExecution;

namespace HubHandling
{
    public class HubCallback
    {
        IHubProxy _hubProxy;
        public HubCallback(IHubProxy hubProxy)
        {
            _hubProxy = hubProxy;
            find_tag_by_css_selector();
find_tag_by_css_selector2();
get_page_numbers();
get_iteration_links();
get_iteration_links2();
        }
        
        public void find_tag_by_css_selector()
{
Executable executable = new Executable();
_hubProxy.On<String,String>("find_tag_by_css_selector", (url,css_selector) => executable.find_tag_by_css_selector(url,css_selector));
}
public void find_tag_by_css_selector2()
{
Executable executable = new Executable();
_hubProxy.On<String,String,String,String>("find_tag_by_css_selector2", (url,page_iteration_selector,iteration_number,css_selector) => executable.find_tag_by_css_selector2(url,page_iteration_selector,iteration_number,css_selector));
}
public void get_page_numbers()
{
Executable executable = new Executable();
_hubProxy.On<String,String>("get_page_numbers", (url,page_iteration_selector) => executable.get_page_numbers(url,page_iteration_selector));
}
public void get_iteration_links()
{
Executable executable = new Executable();
_hubProxy.On<String,String>("get_iteration_links", (url,iteration_selector) => executable.get_iteration_links(url,iteration_selector));
}
public void get_iteration_links2()
{
Executable executable = new Executable();
_hubProxy.On<String,String,String,String>("get_iteration_links2", (url,page_iteration_selector,iteration_number,iteration_selector) => executable.get_iteration_links2(url,page_iteration_selector,iteration_number,iteration_selector));
}
    }
}
