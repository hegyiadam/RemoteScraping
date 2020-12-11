using ComponentInterfaces.Tasks;

namespace ComponentInterfaces.Session
{
    public interface ISession
    {
        ISessionId Id { get; set; }

        void AddIterationTask(IIterationTask task);

        void AddScrapingTask(IProcessorTask task);

        void Execute();

        void SetRootUrl(string url);
    }
}