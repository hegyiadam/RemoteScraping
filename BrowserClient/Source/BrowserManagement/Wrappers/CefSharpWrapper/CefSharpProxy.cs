using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.Wpf;

namespace BrowserManagement.Wrappers.CefSharpWrapper
{
    class CefSharpProxy : IJavaScriptExecutorBrowser
    {
        public ChromiumWebBrowser Browser { get; set; }
        public CefSharpProxy(ChromiumWebBrowser browser)
        {
            Browser = browser;
        }

        public void ExecuteScriptAsync(string javascript)
        {
            Browser.ExecuteScriptAsync(javascript);
        }

        public Task<JavascriptResponse> EvaluateScriptAsync(string javascript)
        {
            return Browser.EvaluateScriptAsync(javascript);
        }
    }
}
