// <copyright file="GetNavigationIteratorCommandTest.cs">Copyright ©  2020</copyright>

using System;
using MasterConnection.MasterCommands.SwaggerGenerated;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WPFBrowserClient.Tests;
using WPFBrowserClient.ViewModel.Commands;

namespace WPFBrowserClient.ViewModel.Commands.Tests
{
    /// <summary>This class contains parameterized unit tests for GetNavigationIteratorCommand</summary>
    [TestClass]
    [PexClass(typeof(GetNavigationIteratorCommand))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GetNavigationIteratorCommandTest : TestClassBase
    {

        /// <summary>Test stub for CanExecute(Object)</summary>
        [PexMethod]
        public bool CanExecuteTest([PexAssumeUnderTest] GetNavigationIteratorCommand target, object parameter)
        {
            bool result = target.CanExecute(parameter);
            return result;
        }

        /// <summary>Test stub for CreatePageIterationRequest(String)</summary>
        [PexMethod]
        public void CreatePageIterationRequestTest([PexAssumeUnderTest] GetNavigationIteratorCommand target, string selector)
        {
            target.CreatePageIterationRequest(selector);
            clientMock.Verify(x => x.PageIterationAsync(It.IsAny<PageIterationRequest>()), Times.Exactly(1));
        }

        /// <summary>Test stub for Execute(Object)</summary>
        [PexMethod]
        public void ExecuteTest([PexAssumeUnderTest] GetNavigationIteratorCommand target, object parameter)
        {
            target.Execute(parameter);
        }
    }
}
