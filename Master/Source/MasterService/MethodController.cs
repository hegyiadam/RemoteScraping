using MasterService.ActiveObject;
using MasterService.RequestData;
using MasterService.RequestDatas;
using MasterService.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Future PageIteration([FromBody]PageIterationRequest pageIterationRequest)
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
                SessionId = executeSessionRequest.SessionId
            };
            Future future = proxy.ProcessRequest(task);
            futures.Add(future.Id.Serialize(), future);
            return future;
        }
        [HttpGet]
        [ActionName("GetFutureState")]
        public string GetFutureState(string taskId)
        {
            try
            {
                Future future = futures[taskId];
                return future.State.ToString();
            }
            catch
            {
                return "Resource was not found";
            }
        }
        [HttpGet]
        [ActionName("GetFutureResult")]
        public string GetFutureResult(string taskId)
        {
            try
            {
                Future future = futures[taskId];
                return JsonConvert.SerializeObject(future.Result);
            }
            catch
            {
                return "Resource was not found";
            }
        }
        
    }
}
