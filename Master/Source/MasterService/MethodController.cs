﻿using ComponentInterfaces.Tasks;
using MasterService.ActiveObject;
using MasterService.RequestData;
using MasterService.RequestData.DAO;
using MasterService.RequestDatas;
using MasterService.Session;
using MasterService.Tasks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MasterService
{
    public class MethodController : ApiController
    {
        private static IFutureRepository futureRepository = IMDBFutureRepository.Instance;
        private Proxy proxy = new Proxy();

        [HttpPost]
        [ActionName("DownloadTagBySelector")]
        public Future DownloadTagBySelector
                            ([FromBody] DownloadTagBySelectorRequest selector)
        {
            DownloadTagBySelectorTask scrapingTask =
                new DownloadTagBySelectorTask(
                    selector.Selector,
                    new PythonComponents.ProcessorFilter());
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
        public Future ExecuteSession([FromBody] ExecuteSessionRequest executeSessionRequest)
        {
            ExecuteSessionTask task = new ExecuteSessionTask(new PythonComponents.ProcessorFilter())
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
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ActionName("GetFutureResult")]
        public JObject GetFutureResult([FromBody] FutureId futureId)
        {
            try
            {
                Future future = futureRepository.GetFuture(futureId);
                if (future.Result is string)
                {
                    string result = future.Result as string;
                    JObject jObject = JObject.Parse(result);
                    return jObject;
                }
                return JObject.FromObject(future.Result);
            }
            catch
            {
                return JObject.FromObject("Resource was not found");
            }
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
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ActionName("GetResult")]
        public Future GetResult([FromBody] string sessionIdString)
        {
            SessionId sessionId = new SessionId();
            sessionId.Deserialize(sessionIdString);
            GetResultTask task = new GetResultTask(new PythonComponents.ProcessorFilter())
            {
                SessionId = sessionId
            };
            Future future = CreateFuture(task);
            return future;
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ActionName("GetSessionData")]
        public List<SessionData> GetSessionData()
        {
            return SessionRepository.Instance.GetAllSessionData();
        }

        [HttpPost]
        [ActionName("LinkIteration")]
        public Future LinkIteration([FromBody] LinkIterationRequest linkIterationRequest)
        {
            AddLinkIterationTask task = new AddLinkIterationTask()
            {
                Data = linkIterationRequest
            };
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
        [ActionName("RootUrl")]
        public Future RootUrl([FromBody] RootURLRequest rootUrl)
        {
            Console.WriteLine(rootUrl.URL);
            SetRootUrlTask task = new SetRootUrlTask(rootUrl.URL);
            Future future = CreateFuture(task);
            return future;
        }

        private Future CreateFuture(ITask task)
        {
            Future future = proxy.ProcessRequest(task);
            futureRepository.RegisterFuture(future);
            return future;
        }
    }
}