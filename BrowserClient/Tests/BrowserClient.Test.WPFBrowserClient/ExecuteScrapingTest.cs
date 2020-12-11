// <copyright file="ExecuteScrapingTest.cs">Copyright ©  2020</copyright>
using MasterConnection.MasterCommands.SwaggerGenerated;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using WPFBrowserClient.Tests;

namespace WPFBrowserClient.ViewModel.Commands.ScrapingCommands.Tests
{
    /// <summary>This class contains parameterized unit tests for ExecuteScraping</summary>
    [PexClass(typeof(ExecuteScraping))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ExecuteScrapingTest : TestClassBase
    {
        /// <summary>Test stub for Execute(Object)</summary>
        [PexMethod]
        public void ExecuteTest([PexAssumeUnderTest] ExecuteScraping target, object parameter)
        {
            target.Execute(parameter);
            clientMock
                .Verify(x =>
                    x.ExecuteSessionAsync(It.IsAny<ExecuteSessionRequest>())
                    , Times.Exactly(1)
                    );
        }
    }
}