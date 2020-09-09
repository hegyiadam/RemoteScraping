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

        private void ExecuteJavaScriptCommand(string javaScriptCommand)
        {
            javaScriptCommand.Replace("\r","").Replace("\n","");
            //Browser.ExecuteScriptAsync(javaScriptCommand);
            Browser.EvaluateScriptAsync("document.onclick = function (e){    var x = event.clientX,        y = event.clientY,        elementMouseIsOver = document.elementFromPoint(x, y);    elementMouseIsOver.style.border ='thick solid #0000FF';  };");
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
