using ComponentInterfaces.Session;
using ComponentInterfaces.Tasks;
using MasterService.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Session
{
    public class Session : ISession
    {
        private string _rootUrl;
        private List<IIterationTask> _iterationTasks = new List<IIterationTask>();
        private List<IProcessorTask> _scrapingTask = new List<IProcessorTask>();
        public ISessionId Id { get; set; }

        public Session()
        {
            Id = SessionIdFactory.Instance.CreateId();
        }

        public void AddIterationTask(IIterationTask task)
        {
            if (_scrapingTask.Count != 0)
            {
                throw new InvalidOperationException();
            }
            if(_iterationTasks.Count != 0)
            {
                _iterationTasks.Last().NextTasks.Add(task);
            }
            _iterationTasks.Add(task);
        }

        public void AddScrapingTask(IProcessorTask task)
        {
            if (_iterationTasks.Count != 0)
            {
                _iterationTasks.Last().NextTasks.Add(task);
            }
            _scrapingTask.Add(task);
        }

        public void Execute()
        {
            ValidateSession();
            if(_iterationTasks.Count != 0)
            {
                IIterationTask firstIterationTask = _iterationTasks[0];
                firstIterationTask.URL = _rootUrl;
                if (firstIterationTask.CanRun())
                {
                    firstIterationTask.Call();
                }
            }
        }

        private void ValidateSession()
        {
            if(_scrapingTask.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public void SetRootUrl(string url)
        {
            _rootUrl = url;
        }


    }
}
