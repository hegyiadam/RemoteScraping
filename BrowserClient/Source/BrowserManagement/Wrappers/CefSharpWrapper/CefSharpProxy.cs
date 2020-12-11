using System.Threading.Tasks;
using CefSharp;
using CefSharp.Wpf;

namespace BrowserManagement.Wrappers.CefSharpWrapper
{
    internal class CefSharpProxy : IJavaScriptExecutorBrowser
    {
        public CefSharpProxy(ChromiumWebBrowser browser)
        {
            Browser = browser;
        }

        public ChromiumWebBrowser Browser { get; set; }

        public Task<JavascriptResponse> EvaluateScriptAsync(string javascript)
        {
            return Browser.EvaluateScriptAsync(javascript);
        }

        public void ExecuteScriptAsync(string javascript)
        {
            Browser.ExecuteScriptAsync(javascript);
        }
    }
}