using ComponentInterfaces.Processor;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// <copyright file="PageIterationTaskTest.cs">Copyright ©  2020</copyright>

using System;

namespace MasterService.Tasks.Tests
{
    /// <summary>This class contains parameterized unit tests for PageIterationTask</summary>
    [TestClass]
    [PexClass(typeof(PageIterationTask))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PageIterationTaskTest
    {
        /// <summary>Test stub for Call()</summary>
        [PexMethod]
        public void CallTest([PexAssumeUnderTest] PageIterationTask target)
        {
            target.Call();
            // TODO: add assertions to method PageIterationTaskTest.CallTest(PageIterationTask)
        }

        /// <summary>Test stub for Clone()</summary>
        [PexMethod]
        public object CloneTest([PexAssumeUnderTest] PageIterationTask target)
        {
            object result = target.Clone();
            return result;
            // TODO: add assertions to method PageIterationTaskTest.CloneTest(PageIterationTask)
        }

        /// <summary>Test stub for .ctor(String, IProcessorFilter)</summary>
        [PexMethod]
        public PageIterationTask ConstructorTest(string selector, IProcessorFilter processorFilter)
        {
            PageIterationTask target = new PageIterationTask(selector, processorFilter);
            return target;
            // TODO: add assertions to method PageIterationTaskTest.ConstructorTest(String, IProcessorFilter)
        }
    }
}