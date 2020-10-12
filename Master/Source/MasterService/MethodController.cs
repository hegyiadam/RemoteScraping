using MasterService.ActiveObject;
using MasterService.RequestData;
using MasterService.RequestDatas;
using MasterService.Session;
using MasterService.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MasterService
{
    public class MethodController : ApiController
    {
        private Proxy proxy = new Proxy();
        private static Dictionary<string, Future> futures = new Dictionary<string, Future>();

        [HttpPost]
        [ActionName("RootUrl")]
        public Future RootUrl([FromBody]RootURLRequest rootUrl)
        {
            Console.WriteLine(rootUrl.URL);
            SetRootUrlTask task = new SetRootUrlTask(rootUrl.URL);
            Future future = proxy.ProcessRequest(task);
            futures.Add(future.Id.Serialize(), future);
            return future;
        }
        [HttpPost]
        [ActionName("PageIteration")]
        public Future PageIteration(PageIterationRequest pageIterationRequest)
        {
            AddPageIterationTask task = new AddPageIterationTask()
            {
                Data = pageIterationRequest
            };
            Future future = proxy.ProcessRequest(task);
            futures.Add(future.Id.Serialize(), future);
            return future;
        }
        [HttpPost]
        [ActionName("LinkIteration")]
        public Future LinkIteration([FromBody]LinkIterationRequest linkIterationRequest)
        {
            AddLinkIterationTask task = new AddLinkIterationTask()
            {
                Data = linkIterationRequest
            };
            Future future = proxy.ProcessRequest(task);
            futures.Add(future.Id.Serialize(), future);
            return future;
        }
        [HttpPost]
        [ActionName("DownloadTagBySelector")]
        public Future DownloadTagBySelector([FromBody]DownloadTagBySelectorRequest selector)
        {
            DownloadTagBySelectorTask scrapingTask = new DownloadTagBySelectorTask(selector.Selector, new PythonComponents.ProcessorFilter());
            AddScrapingTask task = new AddScrapingTask()
            {
                Data = new AddScrapingTaskRequest()
                {
                    SessionId = new SessionId()
                    {
                        SerialNumber = selector.SessionId.SerialNumber
                    }
                },
                Task = scrapingTask
            };
            Future future = proxy.ProcessRequest(task);
            futures.Add(future.Id.Serialize(), future);
            return future;
        }
        [HttpPost]
        [ActionName("ExecuteSession")]
        public Future ExecuteSession([FromBody]ExecuteSessionRequest executeSessionRequest)
        {
            ExecuteSessionTask task = new ExecuteSessionTask()
            {
                SessionId = new SessionId()
                {
                    SerialNumber = executeSessionRequest.SessionId.SerialNumber
                }
            };
            Future future = proxy.ProcessRequest(task);
            futures.Add(future.Id.Serialize(), future);
            return future;
        }
        [HttpPost]
        [ActionName("GetFutureState")]
        public MasterService.RequestData.DAO.TaskStateDAO GetFutureState([FromBody] GetFutureStateRequest getFutureStateRequest)
        {
            try
            {
                Future future = futures[getFutureStateRequest.Id];
                MasterService.RequestData.DAO.TaskStateDAO taskStateDAO = new MasterService.RequestData.DAO.TaskStateDAO()
                {
                    State = future.State.ToString()
                };
                return taskStateDAO;
            }
            catch
            {
                return null;
            }
        }
        [HttpPost]
        [ActionName("GetFutureResult")]
        public JObject GetFutureResult([FromBody] GetFutureStateRequest getFutureStateRequest)
        {
            try
            {
                Future future = futures[getFutureStateRequest.Id];
                return JObject.FromObject(future.Result);
            }
            catch
            {
                return JObject.FromObject("Resource was not found");
            }
        }
        
    }
}
