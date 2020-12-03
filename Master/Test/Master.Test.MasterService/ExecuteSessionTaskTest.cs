using ComponentInterfaces.Processor;
// <copyright file="ExecuteSessionTaskTest.cs">Copyright ©  2020</copyright>

using System;
using MasterService.Tasks;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterService.Tasks.Tests
{
    /// <summary>This class contains parameterized unit tests for ExecuteSessionTask</summary>
    [TestClass]
    [PexClass(typeof(ExecuteSessionTask))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ExecuteSessionTaskTest
    {

        /// <summary>Test stub for .ctor(IProcessorFilter)</summary>
        [PexMethod]
        public ExecuteSessionTask ConstructorTest(IProcessorFilter processorFilter)
        {
            ExecuteSessionTask target = new ExecuteSessionTask(processorFilter);
            return target;
            // TODO: add assertions to method ExecuteSessionTaskTest.ConstructorTest(IProcessorFilter)
        }

        /// <summary>Test stub for Call()</summary>
        [PexMethod]
        public void CallTest([PexAssumeUnderTest] ExecuteSessionTask target)
        {
            target.Call();
            // TODO: add assertions to method ExecuteSessionTaskTest.CallTest(ExecuteSessionTask)
        }

        /// <summary>Test stub for Clone()</summary>
        [PexMethod]
        public object CloneTest([PexAssumeUnderTest] ExecuteSessionTask target)
        {
            object result = target.Clone();
            return result;
            // TODO: add assertions to method ExecuteSessionTaskTest.CloneTest(ExecuteSessionTask)
        }
    }
}
