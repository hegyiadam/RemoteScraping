using ComponentInterfaces.Tasks;
using MasterService.ActiveObject;
using MasterService.RequestData;
using MasterService.RequestData.DAO;
using MasterService.RequestDatas;
using MasterService.Session;
using MasterService.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        private static IFutureRepository futureRepository = IMDBFutureRepository.Instance;

        [HttpPost]
        [ActionName("RootUrl")]
        public Future RootUrl([FromBody]RootURLRequest rootUrl)
        {
            Console.WriteLine(rootUrl.URL);
            SetRootUrlTask task = new SetRootUrlTask(rootUrl.URL);
            Future future = CreateFuture(task);
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
            Future future = CreateFuture(task);
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
            Future future = CreateFuture(task);
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
            Future future = CreateFuture(task);
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
            Future future = CreateFuture(task);
            return future;
        }
        [HttpPost]
        [ActionName("GetFutureState")]
        public FutureStateDAO GetFutureState([FromBody] FutureId futureId)
        {
            try
            {
                Future future = futureRepository.GetFuture(futureId);
                MasterService.RequestData.DAO.FutureStateDAO futureStateDAO = new MasterService.RequestData.DAO.FutureStateDAO(future.State);
                return new FutureStateDAO(future.State);
            }
            catch
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Future was not found"));
            }
        }
        [HttpPost]
        [ActionName("GetFutureResult")]
        public JObject GetFutureResult([FromBody] FutureId futureId)
        {
            try
            {
                Future future = futureRepository.GetFuture(futureId);
                return JObject.FromObject(future.Result);
            }
            catch
            {
                return JObject.FromObject("Resource was not found");
            }
        }

        private Future CreateFuture(ITask task)
        {
            Future future = proxy.ProcessRequest(task);
            futureRepository.RegisterFuture(future);
            return future;
        }

    }
}
