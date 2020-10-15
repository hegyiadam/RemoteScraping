using ComponentInterfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.ActiveObject
{
    public interface IFutureRepository
    {
        void RegisterFuture(Future future);
        void UnregisterFuture(FutureId futureId);
        Future GetFuture(FutureId futureId);
        void SetConfiguration(IFutureRepositoryConfig futureRepositoryConfig);
    }
}
