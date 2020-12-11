// <copyright file="SetRootUrlTaskTest.cs">Copyright ©  2020</copyright>

using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MasterService.Tasks.Tests
{
    /// <summary>This class contains parameterized unit tests for SetRootUrlTask</summary>
    [TestClass]
    [PexClass(typeof(SetRootUrlTask))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SetRootUrlTaskTest
    {
        /// <summary>Test stub for Call()</summary>
        [PexMethod]
        public void CallTest([PexAssumeUnderTest] SetRootUrlTask target)
        {
            target.Call();
            // TODO: add assertions to method SetRootUrlTaskTest.CallTest(SetRootUrlTask)
        }

        /// <summary>Test stub for .ctor(String)</summary>
        [PexMethod]
        public SetRootUrlTask ConstructorTest(string url)
        {
            SetRootUrlTask target = new SetRootUrlTask(url);
            return target;
            // TODO: add assertions to method SetRootUrlTaskTest.ConstructorTest(String)
        }
    }
}