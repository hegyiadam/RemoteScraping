// <copyright file="AddScrapingTaskTest.cs">Copyright ©  2020</copyright>

using System;
using MasterService.RequestData;
using MasterService.RequestData.DAO;
using MasterService.Tasks;
using MasterService.Tests;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterService.Tasks.Tests
{
    /// <summary>This class contains parameterized unit tests for AddScrapingTask</summary>
    [TestClass]
    [PexClass(typeof(AddScrapingTask))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AddScrapingTaskTest : TestClassBase
    {

        /// <summary>Test stub for Call()</summary>
        [PexMethod]
        public void CallTest([PexAssumeUnderTest] AddScrapingTask target)
        {
            target.Data = new DownloadTagBySelectorRequest()
            {
                Selector = "1",
                SessionId = new SessionIdDAO()
                {
                    SerialNumber = 1
                }
            };
            target.Call();
            // TODO: add assertions to method AddScrapingTaskTest.CallTest(AddScrapingTask)
        }

        [PexMethod(MaxBranches = 20000)]
        public void Call([PexAssumeUnderTest] AddScrapingTask target)
        {
            target.Data = new DownloadTagBySelectorRequest()
            {
                Selector = "1",
                SessionId = new SessionIdDAO()
                {
                    SerialNumber = 1
                }
            };
            target.Call();
            // TODO: add assertions to method AddScrapingTaskTest.Call(AddScrapingTask)
        }
    }
}
