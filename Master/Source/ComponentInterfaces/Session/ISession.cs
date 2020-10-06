using ComponentInterfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentInterfaces.Session
{
    public interface ISession
    {
        ISessionId Id { get; set; }
        void SetRootUrl(string url);
        void AddIterationTask(IIterationTask task);
        void AddScrapingTask(IProcessorTask task);
        void Execute();
    }
}
