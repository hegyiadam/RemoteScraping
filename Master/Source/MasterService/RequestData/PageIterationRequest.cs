using MasterService.RequestData.DAO;

namespace MasterService.RequestData
{
    public class PageIterationRequest
    {
        public string Selector { get; set; }
        public SessionIdDAO SessionId { get; set; }
    }
}