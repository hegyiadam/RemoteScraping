using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PythonInterfaceConverter.Source.PythonInterfaceConverterLibrary;
using HttpMock;
using System.Net;

namespace PythonInterfaceConverter.Test.PythonInterfaceConverterLibrary
{
    [TestClass]
    public class ApiInvocationTests
    {
        private IHttpServer stubHttp;

        [TestInitialize]
        public void TestInitialize()
        {
            stubHttp = HttpMockRepository.At("http://localhost:9191");
            stubHttp.Stub(x => x.Post("/run/testcommand")).OK();
        }
        [TestMethod]
        public void RunCommandOnPythonTest()
        {
            ApiInvocation.RunCommandOnPython("testcommand", new List<object>() { true });
        }
        [TestMethod]
        public void RunWrongCommandOnPythonTest()
        {
            Assert.ThrowsException<WebException>(()=> { ApiInvocation.RunCommandOnPython("", new List<object>() { }); });
        }
    }
}
