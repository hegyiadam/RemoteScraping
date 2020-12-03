using System.Collections.Generic;
using ComponentInterfaces.Processor;
using PythonComponents;
// <copyright file="ProcessorManagerTest.cs">Copyright ©  2020</copyright>

using System;
using HubComponents;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HubComponents.Tests
{
    /// <summary>This class contains parameterized unit tests for ProcessorManager</summary>
    [TestClass]
    [PexClass(typeof(ProcessorManager))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ProcessorManagerTest
    {

        /// <summary>Test stub for AddProcessor(Processor)</summary>
        [PexMethod]
        public void AddProcessorTest([PexAssumeUnderTest] ProcessorManager target, Processor processor)
        {
            target.AddProcessor(processor);
            // TODO: add assertions to method ProcessorManagerTest.AddProcessorTest(ProcessorManager, Processor)
        }

        /// <summary>Test stub for AddResultListener(String, Action`1&lt;String&gt;, IProcessorId)</summary>
        [PexMethod]
        public void AddResultListenerTest(
            [PexAssumeUnderTest] ProcessorManager target,
            string methodName,
            Action<string> action,
            IProcessorId processorId
        )
        {
            target.AddResultListener(methodName, action, processorId);
            // TODO: add assertions to method ProcessorManagerTest.AddResultListenerTest(ProcessorManager, String, Action`1<String>, IProcessorId)
        }

        /// <summary>Test stub for GetProcessorId(String)</summary>
        [PexMethod]
        public IProcessorId GetProcessorIdTest([PexAssumeUnderTest] ProcessorManager target, string connectionId)
        {
            IProcessorId result = target.GetProcessorId(connectionId);
            return result;
            // TODO: add assertions to method ProcessorManagerTest.GetProcessorIdTest(ProcessorManager, String)
        }

        /// <summary>Test stub for GetProcessors(IProcessorFilter)</summary>
        [PexMethod]
        public IList<IProcessor> GetProcessorsTest([PexAssumeUnderTest] ProcessorManager target, IProcessorFilter processorFilter)
        {
            IList<IProcessor> result = target.GetProcessors(processorFilter);
            return result;
            // TODO: add assertions to method ProcessorManagerTest.GetProcessorsTest(ProcessorManager, IProcessorFilter)
        }

        /// <summary>Test stub for ResultTriggered(String, String, IProcessorId)</summary>
        [PexMethod]
        public void ResultTriggeredTest(
            [PexAssumeUnderTest] ProcessorManager target,
            string methodName,
            string result,
            IProcessorId processorId
        )
        {
            target.ResultTriggered(methodName, result, processorId);
            // TODO: add assertions to method ProcessorManagerTest.ResultTriggeredTest(ProcessorManager, String, String, IProcessorId)
        }

        /// <summary>Test stub for get_Instance()</summary>
        [PexMethod]
        public ProcessorManager InstanceGetTest()
        {
            ProcessorManager result = ProcessorManager.Instance;
            return result;
            // TODO: add assertions to method ProcessorManagerTest.InstanceGetTest()
        }
    }
}
