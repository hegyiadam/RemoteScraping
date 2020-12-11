using MasterService.RequestData.DAO;

namespace MasterService.RequestData
{
    public class DownloadTagBySelectorRequest : AddScrapingTaskRequest
    {
        public string Selector { get; set; }
        public SessionIdDAO SessionId { get; set; }
    }
}