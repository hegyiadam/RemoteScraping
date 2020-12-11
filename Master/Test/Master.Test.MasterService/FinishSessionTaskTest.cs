using ComponentInterfaces.Processor;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// <copyright file="FinishSessionTaskTest.cs">Copyright ©  2020</copyright>

using System;

namespace MasterService.Tasks.Tests
{
    /// <summary>This class contains parameterized unit tests for FinishSessionTask</summary>
    [TestClass]
    [PexClass(typeof(FinishSessionTask))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class FinishSessionTaskTest
    {
        /// <summary>Test stub for Call()</summary>
        [PexMethod]
        public void CallTest([PexAssumeUnderTest] FinishSessionTask target)
        {
            target.Call();
            // TODO: add assertions to method FinishSessionTaskTest.CallTest(FinishSessionTask)
        }

        /// <summary>Test stub for Clone()</summary>
        [PexMethod]
        public object CloneTest([PexAssumeUnderTest] FinishSessionTask target)
        {
            object result = target.Clone();
            return result;
            // TODO: add assertions to method FinishSessionTaskTest.CloneTest(FinishSessionTask)
        }

        /// <summary>Test stub for .ctor(IProcessorFilter)</summary>
        [PexMethod]
        public FinishSessionTask ConstructorTest(IProcessorFilter processorFilter)
        {
            FinishSessionTask target = new FinishSessionTask(processorFilter);
            return target;
            // TODO: add assertions to method FinishSessionTaskTest.ConstructorTest(IProcessorFilter)
        }
    }
}