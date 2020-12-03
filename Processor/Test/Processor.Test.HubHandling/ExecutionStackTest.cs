// <copyright file="ExecutionStackTest.cs">Copyright ©  2020</copyright>
using System;
using System.Windows.Threading;
using HubHandling;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HubHandling.Tests
{
    /// <summary>This class contains parameterized unit tests for ExecutionStack</summary>
    [PexClass(typeof(ExecutionStack))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ExecutionStackTest
    {
        /// <summary>Test stub for Insert(Action, String, Object[])</summary>
        [PexMethod]
        public void InsertTest(
        )
        {

            ExecutionStack.StartExecution(Dispatcher.CurrentDispatcher);
            Action action = () =>
            {

            };
            ExecutionStack.Insert(action, "paramname", new Object[] {"param2", "param1"});
            // TODO: add assertions to method ExecutionStackTest.InsertTest(Action, String, Object[])
        }

        /// <summary>Test stub for StartExecution(Dispatcher)</summary>
        [PexMethod]
        public void StartExecutionTest()
        {
            ExecutionStack.StartExecution(Dispatcher.CurrentDispatcher);
            // TODO: add assertions to method ExecutionStackTest.StartExecutionTest(Dispatcher)
        }
    }
}
