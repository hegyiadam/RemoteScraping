using MasterService.RequestData.DAO;

namespace MasterService.RequestData
{
    public class LinkIterationRequest
    {
        public string Selector { get; set; }
        public SessionIdDAO SessionId { get; set; }
    }
}