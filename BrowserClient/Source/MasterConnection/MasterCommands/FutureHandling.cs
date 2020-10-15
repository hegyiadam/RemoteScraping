using MasterConnection.MasterCommands.SwaggerGenerated;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MasterConnection.MasterCommands
{
    public class FutureHandling
    {
        public static string GetState(FutureId futureId)
        {
            MethodClient methodClient = new MethodClient(new HttpClient());
            string currentState = methodClient.GetFutureStateAsync(futureId).Result.State;
            return currentState;
        }
    }
}
