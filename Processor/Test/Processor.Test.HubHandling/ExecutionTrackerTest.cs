// <copyright file="ExecutionTrackerTest.cs">Copyright ©  2020</copyright>

using System;
using HubHandling;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HubHandling.Tests
{
    /// <summary>This class contains parameterized unit tests for ExecutionTracker</summary>
    [TestClass]
    [PexClass(typeof(ExecutionTracker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ExecutionTrackerTest
    {

        /// <summary>Test stub for FinishExecution(String)</summary>
        [PexMethod]
        public void FinishExecutionTest(string commandName)
        {
            ExecutionTracker.FinishExecution(commandName);
            // TODO: add assertions to method ExecutionTrackerTest.FinishExecutionTest(String)
        }

        /// <summary>Test stub for StartExecution(String)</summary>
        [PexMethod]
        public void StartExecutionTest(string commandName)
        {
            ExecutionTracker.StartExecution(commandName);
            // TODO: add assertions to method ExecutionTrackerTest.StartExecutionTest(String)
        }
    }
}
