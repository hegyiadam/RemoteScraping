using ComponentInterfaces.Processor;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// <copyright file="GetResultTaskTest.cs">Copyright ©  2020</copyright>

using System;

namespace MasterService.Tasks.Tests
{
    /// <summary>This class contains parameterized unit tests for GetResultTask</summary>
    [TestClass]
    [PexClass(typeof(GetResultTask))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GetResultTaskTest
    {
        /// <summary>Test stub for Call()</summary>
        [PexMethod]
        public void CallTest([PexAssumeUnderTest] GetResultTask target)
        {
            target.Call();
            // TODO: add assertions to method GetResultTaskTest.CallTest(GetResultTask)
        }

        /// <summary>Test stub for Clone()</summary>
        [PexMethod]
        public object CloneTest([PexAssumeUnderTest] GetResultTask target)
        {
            object result = target.Clone();
            return result;
            // TODO: add assertions to method GetResultTaskTest.CloneTest(GetResultTask)
        }

        /// <summary>Test stub for .ctor(IProcessorFilter)</summary>
        [PexMethod]
        public GetResultTask ConstructorTest(IProcessorFilter processorFilter)
        {
            GetResultTask target = new GetResultTask(processorFilter);
            return target;
            // TODO: add assertions to method GetResultTaskTest.ConstructorTest(IProcessorFilter)
        }
    }
}