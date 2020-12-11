// <copyright file="AddPageIterationTaskTest.cs">Copyright ©  2020</copyright>

using MasterService.RequestData;
using MasterService.RequestData.DAO;
using MasterService.Tests;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MasterService.Tasks.Tests
{
    /// <summary>This class contains parameterized unit tests for AddPageIterationTask</summary>
    [TestClass]
    [PexClass(typeof(AddPageIterationTask))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AddPageIterationTaskTest : TestClassBase
    {
        [PexMethod(MaxBranches = 20000)]
        public void Call([PexAssumeUnderTest] AddPageIterationTask target)
        {
            target.Data = new PageIterationRequest()
            {
                Selector = "1",
                SessionId = new SessionIdDAO()
                {
                    SerialNumber = 1
                }
            };
            target.Call();
            // TODO: add assertions to method AddPageIterationTaskTest.Call(AddPageIterationTask)
        }

        /// <summary>Test stub for Call()</summary>
        [PexMethod]
        public void CallTest([PexAssumeUnderTest] AddPageIterationTask target)
        {
            target.Data = new PageIterationRequest()
            {
                Selector = "1",
                SessionId = new SessionIdDAO()
                {
                    SerialNumber = 1
                }
            };
            target.Call();
            // TODO: add assertions to method AddPageIterationTaskTest.CallTest(AddPageIterationTask)
        }
    }
}