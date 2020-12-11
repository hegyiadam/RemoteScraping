using System.Threading.Tasks;
using CefSharp;

namespace BrowserManagement.Wrappers.CefSharpWrapper
{
    public interface IJavaScriptExecutorBrowser
    {
        Task<JavascriptResponse> EvaluateScriptAsync(string javascript);

        void ExecuteScriptAsync(string javascript);
    }
}