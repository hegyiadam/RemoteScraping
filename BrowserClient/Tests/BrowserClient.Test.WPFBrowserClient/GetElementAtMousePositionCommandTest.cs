// <copyright file="GetElementAtMousePositionCommandTest.cs">Copyright ©  2020</copyright>

using MasterConnection.MasterCommands.SwaggerGenerated;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using WPFBrowserClient.Tests;

namespace WPFBrowserClient.ViewModel.Commands.Tests
{
    /// <summary>This class contains parameterized unit tests for GetElementAtMousePositionCommand</summary>
    [TestClass]
    [PexClass(typeof(GetElementAtMousePositionCommand))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GetElementAtMousePositionCommandTest : TestClassBase
    {
        /// <summary>Test stub for CanExecute(Object)</summary>
        [PexMethod]
        public bool CanExecuteTest([PexAssumeUnderTest] GetElementAtMousePositionCommand target, object parameter)
        {
            bool result = target.CanExecute(parameter);
            return result;
        }

        /// <summary>Test stub for CreateScrapingRequest(String)</summary>
        [PexMethod]
        public void CreateScrapingRequestTest([PexAssumeUnderTest] GetElementAtMousePositionCommand target, string selector)
        {
            target.CreateScrapingRequest(selector);
            clientMock.Verify(x => x.DownloadTagBySelectorAsync(It.IsAny<DownloadTagBySelectorRequest>()), Times.Exactly(1));
        }

        /// <summary>Test stub for Execute(Object)</summary>
        [PexMethod]
        public void ExecuteTest([PexAssumeUnderTest] GetElementAtMousePositionCommand target, object parameter)
        {
            target.Execute(parameter);
        }
    }
}