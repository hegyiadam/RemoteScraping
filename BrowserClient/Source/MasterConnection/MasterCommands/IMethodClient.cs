using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterConnection.MasterCommands.SwaggerGenerated;

namespace MasterConnection.MasterCommands
{
    public interface IMethodClient
    {
        Task<Future> RootUrlAsync(RootURLRequest request);
        Task<FutureStateDAO> GetFutureStateAsync(FutureId futureId);
        Task<object> GetFutureResultAsync(FutureId futureId);
        Task<Future> ExecuteSessionAsync(ExecuteSessionRequest executeSessionRequest);
        Task<Future> LinkIterationAsync(LinkIterationRequest linkIterationRequest);
        Task<Future> DownloadTagBySelectorAsync(DownloadTagBySelectorRequest downloadTagBySelectorRequest);
        Task<Future> PageIterationAsync(PageIterationRequest pageIterationRequest);
    }
}
