using ComponentInterfaces.Processor;
// <copyright file="DownloadTagBySelectorTaskTest.cs">Copyright ©  2020</copyright>

using System;
using MasterService.Tasks;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterService.Tasks.Tests
{
    /// <summary>This class contains parameterized unit tests for DownloadTagBySelectorTask</summary>
    [TestClass]
    [PexClass(typeof(DownloadTagBySelectorTask))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DownloadTagBySelectorTaskTest
    {

        /// <summary>Test stub for .ctor(String, IProcessorFilter)</summary>
        [PexMethod]
        public DownloadTagBySelectorTask ConstructorTest(string selector, IProcessorFilter processorFilter)
        {
            DownloadTagBySelectorTask target = new DownloadTagBySelectorTask(selector, processorFilter);
            return target;
            // TODO: add assertions to method DownloadTagBySelectorTaskTest.ConstructorTest(String, IProcessorFilter)
        }

        /// <summary>Test stub for Call()</summary>
        [PexMethod]
        public void CallTest([PexAssumeUnderTest] DownloadTagBySelectorTask target)
        {
            target.Call();
            // TODO: add assertions to method DownloadTagBySelectorTaskTest.CallTest(DownloadTagBySelectorTask)
        }

        /// <summary>Test stub for Clone()</summary>
        [PexMethod]
        public object CloneTest([PexAssumeUnderTest] DownloadTagBySelectorTask target)
        {
            object result = target.Clone();
            return result;
            // TODO: add assertions to method DownloadTagBySelectorTaskTest.CloneTest(DownloadTagBySelectorTask)
        }
    }
}
