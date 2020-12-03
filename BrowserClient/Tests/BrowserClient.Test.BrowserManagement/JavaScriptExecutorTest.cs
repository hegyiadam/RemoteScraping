// <copyright file="JavaScriptExecutorTest.cs">Copyright ©  2020</copyright>
using System;
using System.Threading.Tasks;
using BrowserManagement.Tests;
using BrowserManagement.Wrappers.CefSharpWrapper;
using CefSharp;
using CefSharp.Wpf;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrowserManagement.Wrappers.CefSharpWrapper.Tests
{
    /// <summary>This class contains parameterized unit tests for JavaScriptExecutor</summary>
    [PexClass(typeof(JavaScriptExecutor))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class JavaScriptExecutorTest : TestClassBase
    {
        /// <summary>Test stub for .ctor(ChromiumWebBrowser)</summary>
        [PexMethod]
        public JavaScriptExecutor ConstructorTest()
        {
            JavaScriptExecutor target = new JavaScriptExecutor(CreateBrowser());
            return target;
            // TODO: add assertions to method JavaScriptExecutorTest.ConstructorTest(ChromiumWebBrowser)
        }

        /// <summary>Test stub for EvaluateJavaScriptCommand(String)</summary>
        [PexMethod]
        public Task<JavascriptResponse> EvaluateJavaScriptCommandTest(
            string javaScriptCommand
        )
        {
            JavaScriptExecutor target = new JavaScriptExecutor(CreateBrowser());
            Task<JavascriptResponse> result
               = target.EvaluateJavaScriptCommand(javaScriptCommand);
            return result;
            // TODO: add assertions to method JavaScriptExecutorTest.EvaluateJavaScriptCommandTest(JavaScriptExecutor, String)
        }

        /// <summary>Test stub for EvaluateJavaScriptFileContent(String)</summary>
        [PexMethod]
        public Task<JavascriptResponse> EvaluateJavaScriptFileContentTest(
            string javaScriptFilePath
        )
        {
            JavaScriptExecutor target = new JavaScriptExecutor(CreateBrowser());
            Task<JavascriptResponse> result
               = target.EvaluateJavaScriptFileContent(javaScriptFilePath);
            return result;
            // TODO: add assertions to method JavaScriptExecutorTest.EvaluateJavaScriptFileContentTest(JavaScriptExecutor, String)
        }

        /// <summary>Test stub for ExecuteJavaScriptCommand(String)</summary>
        [PexMethod]
        public void ExecuteJavaScriptCommandTest(
            string javaScriptCommand
        )
        {
            JavaScriptExecutor target = new JavaScriptExecutor(CreateBrowser());
            target.ExecuteJavaScriptCommand(javaScriptCommand);
            // TODO: add assertions to method JavaScriptExecutorTest.ExecuteJavaScriptCommandTest(JavaScriptExecutor, String)
        }

        /// <summary>Test stub for ExecuteJavaScriptFileContent(String)</summary>
        [PexMethod]
        public void ExecuteJavaScriptFileContentTest(
            string javaScriptFilePath
        )
        {
            JavaScriptExecutor target = new JavaScriptExecutor(CreateBrowser());
            target.ExecuteJavaScriptFileContent(javaScriptFilePath);
            // TODO: add assertions to method JavaScriptExecutorTest.ExecuteJavaScriptFileContentTest(JavaScriptExecutor, String)
        }

        /// <summary>Test stub for ReadJavaScriptFromFile(String)</summary>
        [PexMethod]
        public string ReadJavaScriptFromFileTest(
            string javaScriptFilePath
        )
        {
            JavaScriptExecutor target = new JavaScriptExecutor(CreateBrowser());
            string result = target.ReadJavaScriptFromFile(javaScriptFilePath);
            return result;
            // TODO: add assertions to method JavaScriptExecutorTest.ReadJavaScriptFromFileTest(JavaScriptExecutor, String)
        }
    }
}
