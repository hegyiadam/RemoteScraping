using BrowserManagement.Wrappers.CefSharpWrapper.JavaScripts;
using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BrowserManagement.Wrappers.CefSharpWrapper
{
    public class CefSharpWrapper : IBrowserWrapper
    {
        private const string INVALID_BROWSER = "Invalid browser type was requested.";

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
            Thread.Sleep(2000);
            browser.MouseDown += Browser_MouseDown;
        }

        private void Browser_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show( e.OriginalSource.ToString());
        }

        public void HighlightControl()
        {
            ScriptExecutor.ExecuteJavaScriptFileContent(JavaScriptFile.HighlightControl);
        }

        public Task<JavascriptResponse> GetElementOnMousePosition()
        {
            Task<JavascriptResponse> response = ScriptExecutor.EvaluateJavaScriptFileContent(JavaScriptFile.GetControlOnMousePosition);
            return response;
        }

        public T GetBrowser<T>() where T : class
        {
            if(typeof(T) != typeof(ChromiumWebBrowser))
            {
                throw new InvalidOperationException(INVALID_BROWSER);
            }
            return Browser as T;
        }
    }
}
