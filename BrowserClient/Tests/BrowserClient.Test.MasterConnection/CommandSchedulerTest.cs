// <copyright file="CommandSchedulerTest.cs">Copyright ©  2020</copyright>

using System;
using MasterConnection.MasterCommands;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterConnection.MasterCommands.Tests
{
    [TestClass]
    [PexClass(typeof(CommandScheduler))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CommandSchedulerTest
    {

        [PexMethod]
        public CommandScheduler InstanceGet()
        {
            CommandScheduler result = CommandScheduler.Instance;
            return result;
        }
    }
}
