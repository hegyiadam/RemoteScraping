using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterConnection.MasterCommands;
using MasterConnection.MasterCommands.SwaggerGenerated;
using Moq;
using Newtonsoft.Json.Linq;

namespace MasterConnection.Tests
{
    public class TestClassBase
    {
        protected Mock<IMethodClient> clientMock;

        public TestClassBase()
        {
            CreateMock();
        }

        private void CreateMock()
        {
            var handler = new Mock<IMethodClient>();
            var sessionDAO = new SessionIdDAO();
            sessionDAO.SerialNumber = 1;
            var response = new JObject();
            response.Add("Result", JObject.FromObject(sessionDAO));
            handler.Setup<Task<object>>(x => x.GetFutureResultAsync(It.IsAny<FutureId>()))
                .ReturnsAsync(response);
            ProtocolClient.Instance.Client = handler.Object;
            clientMock = handler;
        }
    }
}
