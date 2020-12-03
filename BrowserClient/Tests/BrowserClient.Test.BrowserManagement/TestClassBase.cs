using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserManagement.Wrappers.CefSharpWrapper;
using CefSharp;
using CefSharp.Wpf;
using Moq;
using Moq.Protected;

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
