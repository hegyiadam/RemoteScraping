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
get_page_numbers();
do_action_on_iteration();
get_iteration_links();
        }
        
        public void find_tag_by_css_selector()
{
Executable executable = new Executable();
_hubProxy.On<String,String>("find_tag_by_css_selector", (url,css_selector) => executable.find_tag_by_css_selector(url,css_selector));
}
public void get_page_numbers()
{
Executable executable = new Executable();
_hubProxy.On<String,String>("get_page_numbers", (url,page_iteration_selector) => executable.get_page_numbers(url,page_iteration_selector));
}
public void do_action_on_iteration()
{
Executable executable = new Executable();
_hubProxy.On<String,String,String,String,String>("do_action_on_iteration", (url,page_iteration_selector,iteration_number,action,data) => executable.do_action_on_iteration(url,page_iteration_selector,iteration_number,action,data));
}
public void get_iteration_links()
{
Executable executable = new Executable();
_hubProxy.On<String,String>("get_iteration_links", (url,iteration_selector) => executable.get_iteration_links(url,iteration_selector));
}
    }
}
