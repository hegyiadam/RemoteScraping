using BrowserManagement.Wrappers.CefSharpWrapper.JavaScripts;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserManagement.Wrappers.CefSharpWrapper
{
    public class CefSharpWrapper : IBrowserWrapper
    {
        private JavaScriptExecutor ScriptExecutor
        {
            get
            {
                return new JavaScriptExecutor(Browser);
            }
        }

        public ChromiumWebBrowser Browser { get; set; }

        public CefSharpWrapper(ChromiumWebBrowser browser)
        {
            Browser = browser;
        }

        public void HighlightControl()
        {
            ScriptExecutor.ExecuteJavaScriptFileContent(JavaScriptFile.HighlightControl);
        }
    }
}
