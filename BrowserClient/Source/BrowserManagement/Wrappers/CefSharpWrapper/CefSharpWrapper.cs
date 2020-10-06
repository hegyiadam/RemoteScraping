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
using System.Windows.Controls;
using System.Windows.Input;

namespace BrowserManagement.Wrappers.CefSharpWrapper
{
    public class CefSharpWrapper : IBrowserWrapper
    {
        private const string INVALID_BROWSER = "Invalid browser type was requested.";

        public event ControlKeyHandler ControlKeyPressed;

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
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            Thread.Sleep(2000);
            browser.KeyDown += Browser_KeyDown;
        }

        private void Browser_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                ControlKeyPressed?.Invoke();
            }
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            ScriptExecutor.ExecuteJavaScriptFileContent(JavaScriptFile.ImportJQuery);
        }


        public void AutoHighlightControl()
        {
            ScriptExecutor.ExecuteJavaScriptFileContent(JavaScriptFile.AutoHighlightControl);
        }

        public void RemoveAutoHighlightControl()
        {
            ScriptExecutor.ExecuteJavaScriptFileContent(JavaScriptFile.RemoveAutoHighlightControl);
        }

        public Task<JavascriptResponse> GetElementOnMousePosition()
        {
            Task<JavascriptResponse> response = ScriptExecutor.EvaluateJavaScriptFileContent(JavaScriptFile.GetControlOnMousePosition);
            return response;
        }

        public Task<JavascriptResponse> GetSiblingsOnMousePosition()
        {
            Task<JavascriptResponse> response = ScriptExecutor.EvaluateJavaScriptFileContent(JavaScriptFile.GetSiblingsOnMousePosition);
            return response;
        }

        public Control GetControl()
        {
            return Browser;
        }

        public void HighlightControl(string selector)
        {
            string validSelector = "\'BODY "+selector.Split(new string[] { "BODY" },StringSplitOptions.None)[1]+"\'";
            string fileContent = ScriptExecutor.ReadJavaScriptFromFile(JavaScriptFile.HighlightControl);
            string command = fileContent.Replace("{0}", validSelector);
            ScriptExecutor.ExecuteJavaScriptCommand(command);
        }

        public void RemoveHighlightControl(string selector)
        {
            string command = String.Format(ScriptExecutor.ReadJavaScriptFromFile(JavaScriptFile.RemoveHighlightControl), selector);
            ScriptExecutor.ExecuteJavaScriptCommand(command);
        }
    }
}
