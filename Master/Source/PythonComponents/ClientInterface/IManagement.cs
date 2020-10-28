namespace PythonComponents.ClientInterface
{
    public interface IManagement
    {
        void session_started(string sessionId);
        void session_finished(string sessionId);
        void get_session_result(string sessionId);
    }
}
