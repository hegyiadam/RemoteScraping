using MasterService.ActiveObject;
using MasterService.Tasks;
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
        [ActionName("DownloadTagBySelector")]
        public Future DownloadTagBySelector([FromBody]SelectorRequest selector)
        {
            Console.WriteLine(selector.Selector);
            DownloadTagBySelectorTask task = new DownloadTagBySelectorTask(new PythonComponents.ProcessorFilter())
            {
                Selector = selector.Selector
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
    }
}
