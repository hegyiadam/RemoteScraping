using MasterService.ActiveObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.RequestData.DAO
{
    public class FutureStateDAO
    {
        public FutureStateDAO() { }
        public FutureStateDAO(FutureState futureState)
        {
            State = Enum.GetName(typeof(FutureState), futureState);
        }
        public string State { get; set; }
    }
}
