namespace PythonComponents.ClientInterface
{
    public interface IManagement
    {
        void get_session_result(string sessionId);

        void session_finished(string sessionId);

        void session_started(string sessionId);
    }
}