using BrowserManagement.Wrappers.CefSharpWrapper;
using System.Threading.Tasks;
using CefSharp;
using Moq;

namespace BrowserManagement.Tests
{
    public class TestClassBase
    {
        public IJavaScriptExecutorBrowser CreateBrowser()
        {
            Mock<IJavaScriptExecutorBrowser> mock = new Mock<IJavaScriptExecutorBrowser>();
            mock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>()));
            mock.Setup<Task<JavascriptResponse>>(x => x.EvaluateScriptAsync(It.IsAny<string>()));
            mock.Setup(x => x.ExecuteScriptAsync(null));
            mock.Setup<Task<JavascriptResponse>>(x => x.EvaluateScriptAsync(null));
            return mock.Object;
        }
    }
}