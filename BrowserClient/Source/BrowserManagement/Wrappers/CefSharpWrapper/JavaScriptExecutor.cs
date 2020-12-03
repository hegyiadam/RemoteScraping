using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserManagement.Wrappers.CefSharpWrapper
{
    public class JavaScriptExecutor
    {
        public JavaScriptExecutor(ChromiumWebBrowser browser)
        {
            Browser = new CefSharpProxy(browser);

        }

        public JavaScriptExecutor(IJavaScriptExecutorBrowser browser)
        {
            Browser = browser;
        }

        public IJavaScriptExecutorBrowser Browser { get; set; }

        public void ExecuteJavaScriptFileContent(string javaScriptFilePath)
        {
            string javaScriptCommand = ReadJavaScriptFromFile(javaScriptFilePath);
            ExecuteJavaScriptCommand(javaScriptCommand);
        }
        public Task<JavascriptResponse> EvaluateJavaScriptFileContent(string javaScriptFilePath)
        {
            string javaScriptCommand = ReadJavaScriptFromFile(javaScriptFilePath);
            return EvaluateJavaScriptCommand(javaScriptCommand);
        }

        public void ExecuteJavaScriptCommand(string javaScriptCommand)
        {
            javaScriptCommand.Replace("\r", "").Replace("\n", "");
            Browser.ExecuteScriptAsync(javaScriptCommand);
        }
        public Task<JavascriptResponse> EvaluateJavaScriptCommand(string javaScriptCommand)
        {
            javaScriptCommand.Replace("\r", "").Replace("\n", "");
            Task<JavascriptResponse> task = Browser.EvaluateScriptAsync(javaScriptCommand);
            return task;
        }


        public string ReadJavaScriptFromFile(string javaScriptFilePath)
        {
            ValidateFile(javaScriptFilePath);

            string content = File.ReadAllText(javaScriptFilePath);

            return content;
        }

        private void ValidateFile(string javaScriptFilePath)
        {
            if(!File.Exists(javaScriptFilePath))
            {
                throw new FileNotFoundException(javaScriptFilePath);
            }
        }
    }
}
