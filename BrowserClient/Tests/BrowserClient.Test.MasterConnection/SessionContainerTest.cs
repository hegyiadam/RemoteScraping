// <copyright file="SessionContainerTest.cs">Copyright ©  2020</copyright>

using System;
using MasterConnection.MasterCommands;
using MasterConnection.MasterCommands.SwaggerGenerated;
using MasterConnection.Tests;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MasterConnection.MasterCommands.Tests
{
    [TestClass]
    [PexClass(typeof(SessionContainer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SessionContainerTest : TestClassBase
    {

        [PexMethod]
        public SessionContainer InstanceGet()
        {
            SessionContainer result = SessionContainer.Instance;
            return result;
            // TODO: add assertions to method SessionContainerTest.InstanceGet()
        }


        /// <summary>Test stub for CreateScrapingRequest(String)</summary>
        [PexMethod]
        public void CreateRootUrlRequest(string url)
        {
            SessionContainer.Instance.CreateRootUrlRequest(url);
            clientMock.Verify(x => x.RootUrlAsync(It.IsAny<RootURLRequest>()), Times.Exactly(1));
        }
        /// <summary>Test stub for CreateScrapingRequest(String)</summary>
        [PexMethod]
        public void GetFutureResult(FutureId futureId)
        {
            SessionContainer.Instance.GetFutureResult(futureId);
            clientMock.Verify(x => x.GetFutureResultAsync(It.IsAny<FutureId>()), Times.Exactly(1));
        }
    }
}
