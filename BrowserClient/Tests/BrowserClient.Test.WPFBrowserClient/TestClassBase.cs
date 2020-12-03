using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterConnection.MasterCommands;
using MasterConnection.MasterCommands.SwaggerGenerated;
using Moq;
using FutureState = MasterConnection.MasterCommands.FutureState;

namespace WPFBrowserClient.Tests
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
            var response = new Future()
            {
                Id = new FutureId()
                {
                    Id = "1"
                },
                Result = "{\"SerialNumber\": 1}",
                State = MasterConnection.MasterCommands.SwaggerGenerated.FutureState._2
            };
            handler.Setup<Task<Future>>(x => x.RootUrlAsync(It.IsAny<RootURLRequest>()))
                .ReturnsAsync(response);
            ProtocolClient.Instance.Client = handler.Object;
            clientMock = handler;
        }
    }
}
