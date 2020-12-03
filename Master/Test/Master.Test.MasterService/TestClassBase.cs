using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentInterfaces.Session;
using MasterService.Session;
using Moq;

namespace MasterService.Tests
{
    public class TestClassBase
    {
        public ISessionRepository CreateSessionRepository()
        {
            Mock<ISessionRepository> mock = new Mock<ISessionRepository>();
            mock.Setup<ISession>(x => x.GetSession(It.IsAny<SessionId>())).Returns(new Session.Session());
            return mock.Object;
        }
    }
}
