// <copyright file="GetClickIteratorCommandTest.cs">Copyright ©  2020</copyright>

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
    /// <summary>This class contains parameterized unit tests for GetClickIteratorCommand</summary>
    [TestClass]
    [PexClass(typeof(GetClickIteratorCommand))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GetClickIteratorCommandTest : TestClassBase
    {

        /// <summary>Test stub for CanExecute(Object)</summary>
        [PexMethod]
        public bool CanExecuteTest([PexAssumeUnderTest] GetClickIteratorCommand target, object parameter)
        {
            bool result = target.CanExecute(parameter);
            return result;
        }

        /// <summary>Test stub for CreateLinkIterationRequest(String)</summary>
        [PexMethod]
        public void CreateLinkIterationRequestTest([PexAssumeUnderTest] GetClickIteratorCommand target, string selector)
        {
            target.CreateLinkIterationRequest(selector);
            clientMock.Verify(x => x.LinkIterationAsync(It.IsAny<LinkIterationRequest>()), Times.Exactly(1));
        }

        /// <summary>Test stub for Execute(Object)</summary>
        [PexMethod]
        public void ExecuteTest([PexAssumeUnderTest] GetClickIteratorCommand target, object parameter)
        {
            target.Execute(parameter);
        }
    }
}
