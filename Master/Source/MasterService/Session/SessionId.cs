using ComponentInterfaces.Session;

namespace MasterService.Session
{
    public class SessionId : ISessionId
    {
        public int SerialNumber { get; set; }

        public void Deserialize(string source)
        {
            SerialNumber = int.Parse(source);
        }

        public bool EqualsTo(ISessionId sessionId)
        {
            return sessionId.SerialNumber == SerialNumber;
        }

        public string Serialize()
        {
            return SerialNumber.ToString();
        }
    }
}