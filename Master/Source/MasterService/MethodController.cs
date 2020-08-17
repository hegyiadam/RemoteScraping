using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace MasterService
{
    public class MethodController : ApiController
    {
        [HttpGet]
        [ActionName("MethodOne")]
        public string GetElementById(string id)
        {
            return id;
        }
    }
}
