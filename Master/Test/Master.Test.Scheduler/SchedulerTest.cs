// <copyright file="SchedulerTest.cs">Copyright ©  2020</copyright>
using System;
using ComponentInterfaces.Tasks;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scheduler;

namespace Scheduler.Tests
{
    /// <summary>This class contains parameterized unit tests for Scheduler</summary>
    [PexClass(typeof(global::Scheduler.Scheduler))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SchedulerTest
    {
        /// <summary>Test stub for Dispatch()</summary>
        [PexMethod]
        public void DispatchTest([PexAssumeUnderTest]global::Scheduler.Scheduler target)
        {
            target.Dispatch();
            // TODO: add assertions to method SchedulerTest.DispatchTest(Scheduler)
        }

        /// <summary>Test stub for Insert(ITask)</summary>
        [PexMethod]
        public void InsertTest([PexAssumeUnderTest]global::Scheduler.Scheduler target, ITask task)
        {
            target.Insert(task);
            // TODO: add assertions to method SchedulerTest.InsertTest(Scheduler, ITask)
        }

        /// <summary>Test stub for get_Instance()</summary>
        [PexMethod]
        public global::Scheduler.Scheduler InstanceGetTest()
        {
            global::Scheduler.Scheduler result = global::Scheduler.Scheduler.Instance;
            return result;
            // TODO: add assertions to method SchedulerTest.InstanceGetTest()
        }
    }
}
