using ComponentInterfaces.Session;

namespace MasterService.RequestData
{
    public class AddScrapingTaskRequest
    {
        public ISessionId SessionId { get; set; }
    }
}