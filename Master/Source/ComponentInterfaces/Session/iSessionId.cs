namespace ComponentInterfaces.Session
{
    public interface ISessionId
    {
        int SerialNumber { get; set; }

        void Deserialize(string source);

        bool EqualsTo(ISessionId sessionId);

        string Serialize();
    }
}