using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace BrowserManagement.Wrappers.CefSharpWrapper
{
    public interface IJavaScriptExecutorBrowser
    {
        void ExecuteScriptAsync(string javascript);
        Task<JavascriptResponse> EvaluateScriptAsync(string javascript);
    }
}
