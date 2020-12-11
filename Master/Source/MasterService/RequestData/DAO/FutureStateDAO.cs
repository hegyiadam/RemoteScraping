using MasterService.ActiveObject;
using System;

namespace MasterService.RequestData.DAO
{
    public class FutureStateDAO
    {
        public FutureStateDAO()
        {
        }

        public FutureStateDAO(FutureState futureState)
        {
            State = Enum.GetName(typeof(FutureState), futureState);
        }

        public string State { get; set; }
    }
}