// <copyright file="IMDBFutureRepositoryTest.cs">Copyright ©  2020</copyright>

using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MasterService.ActiveObject.Tests
{
    /// <summary>This class contains parameterized unit tests for IMDBFutureRepository</summary>
    [TestClass]
    [PexClass(typeof(IMDBFutureRepository))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class IMDBFutureRepositoryTest
    {
        /// <summary>Test stub for GetFuture(FutureId)</summary>
        [PexMethod]
        public Future GetFutureTest([PexAssumeUnderTest] IMDBFutureRepository target, FutureId futureId)
        {
            Future result = target.GetFuture(futureId);
            return result;
            // TODO: add assertions to method IMDBFutureRepositoryTest.GetFutureTest(IMDBFutureRepository, FutureId)
        }

        /// <summary>Test stub for get_Instance()</summary>
        [PexMethod]
        public IMDBFutureRepository InstanceGetTest()
        {
            IMDBFutureRepository result = IMDBFutureRepository.Instance;
            return result;
            // TODO: add assertions to method IMDBFutureRepositoryTest.InstanceGetTest()
        }

        /// <summary>Test stub for RegisterFuture(Future)</summary>
        [PexMethod]
        public void RegisterFutureTest([PexAssumeUnderTest] IMDBFutureRepository target, Future future)
        {
            target.RegisterFuture(future);
            // TODO: add assertions to method IMDBFutureRepositoryTest.RegisterFutureTest(IMDBFutureRepository, Future)
        }

        /// <summary>Test stub for SetConfiguration(IFutureRepositoryConfig)</summary>
        [PexMethod]
        public void SetConfigurationTest(
            [PexAssumeUnderTest] IMDBFutureRepository target,
            IFutureRepositoryConfig futureRepositoryConfig
        )
        {
            target.SetConfiguration(futureRepositoryConfig);
            // TODO: add assertions to method IMDBFutureRepositoryTest.SetConfigurationTest(IMDBFutureRepository, IFutureRepositoryConfig)
        }

        /// <summary>Test stub for UnregisterFuture(FutureId)</summary>
        [PexMethod]
        public void UnregisterFutureTest([PexAssumeUnderTest] IMDBFutureRepository target, FutureId futureId)
        {
            target.UnregisterFuture(futureId);
            // TODO: add assertions to method IMDBFutureRepositoryTest.UnregisterFutureTest(IMDBFutureRepository, FutureId)
        }
    }
}