using MasterConnection.MasterCommands.SwaggerGenerated;
// <copyright file="FutureHandlingTest.cs">Copyright ©  2020</copyright>

using System;
using MasterConnection.MasterCommands;
using MasterConnection.Tests;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterConnection.MasterCommands.Tests
{
    [TestClass]
    [PexClass(typeof(FutureHandling))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class FutureHandlingTest : TestClassBase
    {

        [PexMethod]
        [PexAllowedException(typeof(NullReferenceException))]
        public string GetState(FutureId futureId)
        {
            string result = FutureHandling.GetState(futureId);
            return result;
            // TODO: add assertions to method FutureHandlingTest.GetState(FutureId)
        }
    }
}
