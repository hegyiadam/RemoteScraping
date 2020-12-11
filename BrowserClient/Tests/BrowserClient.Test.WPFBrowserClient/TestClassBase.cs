using MasterConnection.MasterCommands;
using MasterConnection.MasterCommands.SwaggerGenerated;
using System.Threading.Tasks;
using Moq;

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
            handler
                .Setup<Task<Future>>(x =>
                    x.RootUrlAsync(It.IsAny<RootURLRequest>()))
                .ReturnsAsync(response);
            ProtocolClient.Instance.Client = handler.Object;
            clientMock = handler;
        }
    }
}