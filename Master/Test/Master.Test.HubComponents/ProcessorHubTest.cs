using ComponentInterfaces.Processor;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PythonComponents.ClientInterface;

// <copyright file="ProcessorHubTest.cs">Copyright ©  2020</copyright>

using System;
using System.Threading.Tasks;

namespace HubComponents.Tests
{
    /// <summary>This class contains parameterized unit tests for ProcessorHub</summary>
    [TestClass]
    [PexClass(typeof(ProcessorHub))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ProcessorHubTest
    {
        /// <summary>Test stub for get_Clients()</summary>
        [PexMethod]
        [PexAllowedException(typeof(IndexOutOfRangeException))]
        public object ClientsGetTest()
        {
            object result = ProcessorHub.Clients;
            return result;
            // TODO: add assertions to method ProcessorHubTest.ClientsGetTest()
        }

        /// <summary>Test stub for DownloadTag(String)</summary>
        [PexMethod]
        public void DownloadTagTest([PexAssumeUnderTest] ProcessorHub target, string selector)
        {
            target.DownloadTag(selector);
            // TODO: add assertions to method ProcessorHubTest.DownloadTagTest(ProcessorHub, String)
        }

        /// <summary>Test stub for GetClient(String)</summary>
        [PexMethod]
        public object GetClientTest([PexAssumeUnderTest] ProcessorHub target, string connectionId)
        {
            object result = target.GetClient(connectionId);
            return result;
            // TODO: add assertions to method ProcessorHubTest.GetClientTest(ProcessorHub, String)
        }

        /// <summary>Test stub for GetExecutableClient()</summary>
        [PexMethod]
        public IExecutable GetExecutableClientTest([PexAssumeUnderTest] ProcessorHub target)
        {
            IExecutable result = target.GetExecutableClient();
            return result;
            // TODO: add assertions to method ProcessorHubTest.GetExecutableClientTest(ProcessorHub)
        }

        /// <summary>Test stub for OnConnected()</summary>
        [PexMethod]
        public Task OnConnectedTest([PexAssumeUnderTest] ProcessorHub target)
        {
            Task result = target.OnConnected();
            return result;
            // TODO: add assertions to method ProcessorHubTest.OnConnectedTest(ProcessorHub)
        }

        /// <summary>Test stub for OnDisconnected(Boolean)</summary>
        [PexMethod]
        public Task OnDisconnectedTest([PexAssumeUnderTest] ProcessorHub target, bool stopCalled)
        {
            Task result = target.OnDisconnected(stopCalled);
            return result;
            // TODO: add assertions to method ProcessorHubTest.OnDisconnectedTest(ProcessorHub, Boolean)
        }

        /// <summary>Test stub for OnReconnected()</summary>
        [PexMethod]
        public Task OnReconnectedTest([PexAssumeUnderTest] ProcessorHub target)
        {
            Task result = target.OnReconnected();
            return result;
            // TODO: add assertions to method ProcessorHubTest.OnReconnectedTest(ProcessorHub)
        }

        /// <summary>Test stub for SendResult(String, String)</summary>
        [PexMethod]
        public void SendResultTest(
            [PexAssumeUnderTest] ProcessorHub target,
            string methodName,
            string result
        )
        {
            target.SendResult(methodName, result);
            // TODO: add assertions to method ProcessorHubTest.SendResultTest(ProcessorHub, String, String)
        }

        /// <summary>Test stub for SubscribeToEvent(String, Action`1&lt;String&gt;, IProcessor)</summary>
        [PexMethod]
        public void SubscribeToEventTest(
            string name,
            Action<string> action,
            IProcessor processor
        )
        {
            ProcessorHub.SubscribeToEvent(name, action, processor);
            // TODO: add assertions to method ProcessorHubTest.SubscribeToEventTest(String, Action`1<String>, IProcessor)
        }
    }
}