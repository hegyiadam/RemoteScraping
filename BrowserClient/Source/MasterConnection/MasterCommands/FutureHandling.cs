using MasterConnection.MasterCommands.SwaggerGenerated;

namespace MasterConnection.MasterCommands
{
    public class FutureHandling
    {
        public static string GetState(FutureId futureId)
        {
            IMethodClient methodClient = ProtocolClient.Instance.Client;
            string currentState = methodClient.GetFutureStateAsync(futureId).Result.State;
            return currentState;
        }
    }
}