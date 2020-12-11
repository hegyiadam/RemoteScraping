using BrowserManagement.Wrappers.CefSharpWrapper.JavaScripts;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CefSharp;
using CefSharp.Wpf;

namespace BrowserManagement.Wrappers.CefSharpWrapper
{
    public class CefSharpWrapper : IBrowserWrapper
    {
        private const string INVALID_BROWSER = "Invalid browser type was requested.";

        public CefSharpWrapper(ChromiumWebBrowser browser)
        {
            Browser = browser;
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            Thread.Sleep(2000);
            browser.KeyDown += Browser_KeyDown;
        }

        public event ControlKeyHandler ControlKeyPressed;

        public ChromiumWebBrowser Browser { get; set; }

        private JavaScriptExecutor ScriptExecutor
        {
            get
            {
                return new JavaScriptExecutor(Browser);
            }
        }

        public void AutoHighlightControl()
        {
            ScriptExecutor.ExecuteJavaScriptFileContent(JavaScriptFile.AutoHighlightControl);
        }

        public Control GetControl()
        {
            return Browser;
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

        public void HighlightControl(string selector)
        {
            string validSelector = ValidateSelector(selector);
            string fileContent = ScriptExecutor.ReadJavaScriptFromFile(JavaScriptFile.HighlightControl);
            string command = fileContent.Replace("{0}", validSelector);
            ScriptExecutor.ExecuteJavaScriptCommand(command);
        }

        public void RemoveAutoHighlightControl()
        {
            ScriptExecutor.ExecuteJavaScriptFileContent(JavaScriptFile.RemoveAutoHighlightControl);
        }

        public void RemoveHighlightControl(string selector)
        {
            string command = String.Format(ScriptExecutor.ReadJavaScriptFromFile(JavaScriptFile.RemoveHighlightControl), selector);
            ScriptExecutor.ExecuteJavaScriptCommand(command);
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            ScriptExecutor.ExecuteJavaScriptFileContent(JavaScriptFile.ImportJQuery);
        }

        private void Browser_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                ControlKeyPressed?.Invoke();
            }
        }

        private string RemoveBodyTag(string selector)
        {
            return "\'BODY " + selector.Split(new string[] { "BODY" }, StringSplitOptions.None)[1] + "\'";
        }

        private bool SelectorHasBodyTag(string selector)
        {
            return selector.ToUpper().Contains("BODY");
        }

        private string ValidateSelector(string selector)
        {
            string result = selector;
            if (SelectorHasBodyTag(selector))
            {
                result = RemoveBodyTag(selector);
            }
            return result;
        }
    }
}