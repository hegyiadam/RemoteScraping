using MasterConnection.MasterCommands.SwaggerGenerated;
using System.Threading.Tasks;

namespace MasterConnection.MasterCommands
{
    public interface IMethodClient
    {
        Task<Future> DownloadTagBySelectorAsync(DownloadTagBySelectorRequest downloadTagBySelectorRequest);

        Task<Future> ExecuteSessionAsync(ExecuteSessionRequest executeSessionRequest);

        Task<object> GetFutureResultAsync(FutureId futureId);

        Task<FutureStateDAO> GetFutureStateAsync(FutureId futureId);

        Task<Future> LinkIterationAsync(LinkIterationRequest linkIterationRequest);

        Task<Future> PageIterationAsync(PageIterationRequest pageIterationRequest);

        Task<Future> RootUrlAsync(RootURLRequest request);
    }
}