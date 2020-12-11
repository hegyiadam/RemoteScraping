using ComponentInterfaces.Session;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// <copyright file="SessionRepositoryTest.cs">Copyright ©  2020</copyright>

using System;
using System.Collections.Generic;

namespace MasterService.Session.Tests
{
    /// <summary>This class contains parameterized unit tests for SessionRepository</summary>
    [TestClass]
    [PexClass(typeof(SessionRepository))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SessionRepositoryTest
    {
        /// <summary>Test stub for AddSession(ISession)</summary>
        [PexMethod]
        public void AddSessionTest([PexAssumeUnderTest] SessionRepository target, ISession session)
        {
            target.AddSession(session);
            // TODO: add assertions to method SessionRepositoryTest.AddSessionTest(SessionRepository, ISession)
        }

        /// <summary>Test stub for GetAllSessionData()</summary>
        [PexMethod]
        public List<SessionData> GetAllSessionDataTest([PexAssumeUnderTest] SessionRepository target)
        {
            List<SessionData> result = target.GetAllSessionData();
            return result;
            // TODO: add assertions to method SessionRepositoryTest.GetAllSessionDataTest(SessionRepository)
        }

        /// <summary>Test stub for GetSession(ISessionId)</summary>
        [PexMethod]
        public ISession GetSessionTest([PexAssumeUnderTest] SessionRepository target, ISessionId sessionId)
        {
            ISession result = target.GetSession(sessionId);
            return result;
            // TODO: add assertions to method SessionRepositoryTest.GetSessionTest(SessionRepository, ISessionId)
        }

        /// <summary>Test stub for get_Instance()</summary>
        [PexMethod]
        public SessionRepository InstanceGetTest()
        {
            SessionRepository result = SessionRepository.Instance;
            return result;
            // TODO: add assertions to method SessionRepositoryTest.InstanceGetTest()
        }
    }
}