using CefSharp;
using CefSharp.Wpf;
using Logging;
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
        public ChromiumWebBrowser Browser { get; set; }

        public JavaScriptExecutor(ChromiumWebBrowser browser)
        {
            Browser = browser;
        }

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

        private void ExecuteJavaScriptCommand(string javaScriptCommand)
        {
            javaScriptCommand.Replace("\r", "").Replace("\n", "");
            Browser.ExecuteScriptAsync(javaScriptCommand);
        }
        private Task<JavascriptResponse> EvaluateJavaScriptCommand(string javaScriptCommand)
        {
            javaScriptCommand.Replace("\r", "").Replace("\n", "");
            Task<JavascriptResponse> task = Browser.EvaluateScriptAsync(javaScriptCommand);
            return task;
        }


        private string ReadJavaScriptFromFile(string javaScriptFilePath)
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
